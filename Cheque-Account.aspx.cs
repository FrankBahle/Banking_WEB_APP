using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;

namespace Banking_WEB
{
    public partial class Cheque_Account : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] == null || Session["role"].ToString() == "")
            {
                Response.Redirect("User-Account.aspx");
            }
            else if (Session["role"].ToString() == "user")
            {
                
                //AddTransactionUser();
                AccountTransactions();
                //DeleteTransactionUser();
            }
           

        }

        string AccountNumber1;



        void DeleteTransactionUser()
        {
            try
            {

                string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("DELETE FROM Transaction_Cheque", con);

                    cmd.ExecuteNonQuery();
                    con.Close();

                }


                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Account has successfully been DELETED.');", true);

            }
            catch (Exception ex)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error: {ex.Message.Replace("'", "\\'")}');", true);
            }

        }

        void AddTransactionUser()
        {

            try
            {
                string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                SqlConnection con = new SqlConnection(strcon);

                string AccountNumber = Session["Account_Number_Cheque"]?.ToString();
                string Current_Cheque_String = Session["Current_Amount_Cheque"]?.ToString();
                decimal currentBalance = decimal.Parse(Current_Cheque_String);

                decimal withdrawAmount = 0;
                decimal transferAmount = 0;
                decimal DepositeAmount = 0;

                if (!string.IsNullOrWhiteSpace(txtWithdrawAmount.Text))
                    decimal.TryParse(txtWithdrawAmount.Text.Trim(), out withdrawAmount);
                if (!string.IsNullOrWhiteSpace(txtTransferAmount.Text))
                    decimal.TryParse(txtTransferAmount.Text.Trim(), out transferAmount);
                if (!string.IsNullOrWhiteSpace(txtDeposite.Text))
                    decimal.TryParse(txtDeposite.Text.Trim(), out DepositeAmount);

                if (withdrawAmount > currentBalance || transferAmount > currentBalance)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Transaction blocked: Amount exceeds current balance.');", true);
                    return;
                }


                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                if (!string.IsNullOrWhiteSpace(txtRecipientID.Text)) { 
               
                    if (TransferCheque(txtRecipientID.Text.Trim(), transferAmount.ToString().Trim()) == 0) {

                        
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Account number does not EXIST.');", true);

                        return;
                
                    }

                }
                else if (string.IsNullOrWhiteSpace(txtRecipientID.Text) && string.IsNullOrWhiteSpace(txtDeposite.Text) && string.IsNullOrWhiteSpace(txtWithdrawAmount.Text) && string.IsNullOrWhiteSpace(txtTransferAmount.Text))
                {
                    //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Account number does not EXIST.');", true);
                    return;

                }

                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Transaction_Cheque (" +
                    "Account_Number, Transaction_Current_Amount, Transaction_WithDrawal,Transaction_Transfer, Transaction_Deposite, Transaction_Foreign_Account_Number) " +
                    "VALUES (@Account_Number, @Transaction_Current_Amount, @Transaction_WithDrawal, @Transaction_Transfer,@Transaction_Deposite, @Transaction_Foreign_Account_Number)", con);

                cmd.Parameters.AddWithValue("@Account_Number", AccountNumber);
                cmd.Parameters.AddWithValue("@Transaction_Current_Amount", currentBalance);
                cmd.Parameters.AddWithValue("@Transaction_WithDrawal", withdrawAmount);
                cmd.Parameters.AddWithValue("@Transaction_Transfer", transferAmount);
                cmd.Parameters.AddWithValue("@Transaction_Deposite", DepositeAmount);
                cmd.Parameters.AddWithValue("@Transaction_Foreign_Account_Number", txtRecipientID.Text.Trim());

                
                cmd.ExecuteNonQuery();


                if (transferAmount > 0)
                    UpdateCurrentBalance(transferAmount.ToString(), false);
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Account transaction has been successfully recorded.');", true);

                if (withdrawAmount > 0)
                    UpdateCurrentBalance(withdrawAmount.ToString(), false);
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Account transaction has been successfully recorded.');", true);

                if (DepositeAmount > 0)
                    UpdateCurrentBalance(DepositeAmount.ToString(), true);
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Account transaction has been successfully recorded.');", true);





                con.Close();


                txtWithdrawAmount.Text = "";
                txtTransferAmount.Text = "";
                txtRecipientID.Text = "";
                txtDeposite.Text = "";

                
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error: {ex.Message.Replace("'", "\\'")}');", true);
            }


        }
        protected void btnDeposit_Click(object sender, EventArgs e)
        {
            AddTransactionUser();
            Response.Redirect(Request.RawUrl);
        }

        protected void btnWithdraw_Click(object sender, EventArgs e)
        {
            AddTransactionUser();
            Response.Redirect(Request.RawUrl);
        }

        protected void btnDeposite_Click(object sender, EventArgs e)
        {
            AddTransactionUser();
            Response.Redirect(Request.RawUrl);
        }


        void UpdateCurrentBalance(string amountStr, bool isDeposit)
        {
            try
            {
                string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                decimal currentBalance = decimal.Parse(Session["Current_Amount_Cheque"]?.ToString());
                decimal transactionAmount = decimal.Parse(amountStr);
                decimal newBalance = isDeposit ? currentBalance + transactionAmount : currentBalance - transactionAmount;

                if (newBalance < 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Transaction would result in negative balance.');", true);
                    return;
                }

                Session["Current_Amount_Cheque"] = newBalance;

                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand(
                        "UPDATE Cheque_Account SET Current_Amount = @Current_Amount WHERE Account_Number = @Account_Number", con);

                    cmd.Parameters.AddWithValue("@Current_Amount", newBalance);
                    cmd.Parameters.AddWithValue("@Account_Number", Session["Account_Number_Cheque"]);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Update Error: {ex.Message.Replace("'", "\\'")}');", true);
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////CHEQUE CURRENT BALANCE///////////////////////////////////////////
        void UpdateCurrentChequeBalance(string amountStr, bool isDeposit)
        {
            try
            {
                string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                string Acc = AccountNumber1;

                ////////////////////
                SqlConnection con1 = new SqlConnection(strcon);
                if (con1.State == ConnectionState.Closed)
                {
                    con1.Open();
                }


                SqlCommand cmd = new SqlCommand("SELECT * FROM Cheque_Account WHERE Account_Number = @AccountNumber", con1);
                cmd.Parameters.AddWithValue("@AccountNumber", Acc);

               

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                decimal newBalance = 0;

                if (dt.Rows.Count > 0)
                {
                    decimal currentBalance = decimal.Parse(dt.Rows[0][2].ToString());
                    decimal transactionAmount = decimal.Parse(amountStr);
                    newBalance = isDeposit ? currentBalance + transactionAmount : currentBalance - transactionAmount;

                }

               

                ///////////////////


                if (newBalance < 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Transaction would result in negative balance.');", true);
                    return;
                }
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand(
                        "UPDATE Cheque_Account SET Current_Amount = @Current_Amount WHERE Account_Number = @Account_Number", con);

                    cmd1.Parameters.AddWithValue("@Current_Amount", newBalance);
                    cmd1.Parameters.AddWithValue("@Account_Number", Acc);

                    cmd1.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Update Error: {ex.Message.Replace("'", "\\'")}');", true);
            }
        }

        ////////////////////////////////////////////////FIXED CURRENT BALANCE///////////////////////////////////////////
        void UpdateCurrentBalanceFixed(string amountStr, bool isDeposit)
        {
            try
            {
                string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                string Acc = AccountNumber1;

                ////////////////////
                SqlConnection con1 = new SqlConnection(strcon);
                if (con1.State == ConnectionState.Closed)
                {
                    con1.Open();
                }


                SqlCommand cmd = new SqlCommand("SELECT * FROM Fixed_Account WHERE Account_Number = @AccountNumber", con1);
                cmd.Parameters.AddWithValue("@AccountNumber", Acc);



                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                decimal newBalance = 0;

                if (dt.Rows.Count > 0)
                {
                    decimal currentBalance = decimal.Parse(dt.Rows[0][2].ToString());
                    decimal transactionAmount = decimal.Parse(amountStr);
                    newBalance = isDeposit ? currentBalance + transactionAmount : currentBalance - transactionAmount;

                }



                ///////////////////


                if (newBalance < 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Transaction would result in negative balance.');", true);
                    return;
                }
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand(
                        "UPDATE Fixed_Account SET Current_Amount = @Current_Amount WHERE Account_Number = @Account_Number", con);

                    cmd1.Parameters.AddWithValue("@Current_Amount", newBalance);
                    cmd1.Parameters.AddWithValue("@Account_Number", Acc);

                    cmd1.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Update Error: {ex.Message.Replace("'", "\\'")}');", true);
            }
        }
        ////////////////////////////////////////////////SAVINGS CURRENT BALANCE///////////////////////////////////////////
        void UpdateCurrentBalanceSavings(string amountStr, bool isDeposit)
        {
            try
            {
                string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                string Acc = AccountNumber1;

                ////////////////////
                SqlConnection con1 = new SqlConnection(strcon);
                if (con1.State == ConnectionState.Closed)
                {
                    con1.Open();
                }


                SqlCommand cmd = new SqlCommand("SELECT * FROM Savings_Account WHERE Account_Number = @AccountNumber", con1);
                cmd.Parameters.AddWithValue("@AccountNumber", Acc);



                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                decimal newBalance = 0;

                if (dt.Rows.Count > 0)
                {
                    decimal currentBalance = decimal.Parse(dt.Rows[0][2].ToString());
                    decimal transactionAmount = decimal.Parse(amountStr);
                    newBalance = isDeposit ? currentBalance + transactionAmount : currentBalance - transactionAmount;

                }



                ///////////////////


                if (newBalance < 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Transaction would result in negative balance.');", true);
                    return;
                }
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand(
                        "UPDATE Savings_Account SET Current_Amount = @Current_Amount WHERE Account_Number = @Account_Number", con);

                    cmd1.Parameters.AddWithValue("@Current_Amount", newBalance);
                    cmd1.Parameters.AddWithValue("@Account_Number", Acc);

                    cmd1.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Update Error: {ex.Message.Replace("'", "\\'")}');", true);
            }
        }


        ////////////////////////////////IS IT A NEW ACCOUNT//////////////////////////////////////////
        bool IsNewAccountInTable(string tableName, string accountNumber)
        {
           
            string safeTableName = tableName.Trim();

         
            if (safeTableName != "Cheque_Account" && safeTableName != "Savings_Account" && safeTableName != "Fixed_Account")
            {
                throw new ArgumentException("Invalid table name.");
            }

            string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            using (SqlConnection con = new SqlConnection(strcon))
            {
                string query = $"SELECT 1 FROM {safeTableName} WHERE Account_Number = @id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", accountNumber);
                    con.Open();
                    var result = cmd.ExecuteScalar();
                    return result == null;
                }
            }
        }


        ///////////////////////////////////////////////TRANSFER MONEY TO ANOTHER ACCOUNT////////////////////////////////////////////////


        protected int TransferCheque(string accountNumber, string StrFunds)
        {

            string amountString = StrFunds;
            decimal Funds = 0; 

            if (!string.IsNullOrWhiteSpace(StrFunds))
            {
                amountString = txtTransferAmount.Text.Trim();

                if (decimal.TryParse(amountString, out decimal parsedFunds))
                {
                    Funds = parsedFunds;
                }

            }
            else {

                return 0;
            }


            AccountNumber1 = accountNumber;




            if (accountNumber.StartsWith("CH"))
            {

                if (Session["Account_Number_Cheque"].ToString() == AccountNumber1)
                {

                    
                    return 0;


                }
                else
                {
                    if (IsNewAccountInTable("Cheque_Account", AccountNumber1))
                    {
                        return 0;

                    }


                    try
                    {
                        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                        using (SqlConnection con = new SqlConnection(strcon))
                        {
                            con.Open();

                            SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Transaction_Cheque (" +
                        "Account_Number, Transaction_Current_Amount, Transaction_Transfer, Transaction_Deposite, Transaction_Foreign_Account_Number) " +
                        "VALUES (@Account_Number, @Transaction_Current_Amount, @Transaction_Transfer ,@Transaction_Deposite, @Transaction_Foreign_Account_Number)", con);

                            cmd.Parameters.AddWithValue("@Account_Number", AccountNumber1);

                            cmd.Parameters.AddWithValue("@Transaction_Transfer", DBNull.Value);
                            cmd.Parameters.AddWithValue("@Transaction_Deposite", Funds);
                            cmd.Parameters.AddWithValue("@Transaction_Foreign_Account_Number", Session["Account_Number_Cheque"]);

                            UpdateCurrentChequeBalance(StrFunds, true);

                            cmd.Parameters.AddWithValue("@Transaction_Current_Amount", Session["Current_Amount_Cheque"]);

                            cmd.ExecuteNonQuery();
                        }

                    }
                    catch (Exception ex)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error: {ex.Message.Replace("'", "\\'")}');", true);
                    }

                }
            }
            else if (AccountNumber1.StartsWith("SA"))
            {
                if (IsNewAccountInTable("Savings_Account", AccountNumber1))
                {
                    return 0;

                }

                try
                {
                    string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        con.Open();

                        SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Transaction_Savings (" +
                    "Account_Number, Transaction_Current_Amount, Transaction_Transfer, Transaction_Deposite, Transaction_Foreign_Account_Number) " +
                    "VALUES (@Account_Number, @Transaction_Current_Amount, @Transaction_Transfer ,@Transaction_Deposite, @Transaction_Foreign_Account_Number)", con);

                        cmd.Parameters.AddWithValue("@Account_Number", AccountNumber1);
                        
                        cmd.Parameters.AddWithValue("@Transaction_Transfer", DBNull.Value);
                        cmd.Parameters.AddWithValue("@Transaction_Deposite", Funds);
                        cmd.Parameters.AddWithValue("@Transaction_Foreign_Account_Number", Session["Account_Number_Cheque"]);

                        UpdateCurrentBalanceSavings(StrFunds, true);

                        cmd.Parameters.AddWithValue("@Transaction_Current_Amount", Session["Current_Amount_Savings"]);

                        cmd.ExecuteNonQuery();
                    }

                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error: {ex.Message.Replace("'", "\\'")}');", true);
                }


            }
            else if (AccountNumber1.StartsWith("FX"))
            {
                if (IsNewAccountInTable("Fixed_Account", AccountNumber1))
                {
                    return 0;

                }

                try
                {
                    string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        con.Open();

                        SqlCommand cmd = new SqlCommand(
                         "INSERT INTO Transaction_Fixed (" +
                            "Account_Number, Transaction_Current_Amount, Transaction_Transfer, Transaction_Deposite, Transaction_Foreign_Account_Number) " +
                             "VALUES (@Account_Number, @Transaction_Current_Amount, @Transaction_Transfer ,@Transaction_Deposite, @Transaction_Foreign_Account_Number)", con);

                        cmd.Parameters.AddWithValue("@Account_Number", AccountNumber1);

                        cmd.Parameters.AddWithValue("@Transaction_Transfer", DBNull.Value);
                        cmd.Parameters.AddWithValue("@Transaction_Deposite", Funds);
                        cmd.Parameters.AddWithValue("@Transaction_Foreign_Account_Number", Session["Account_Number_Cheque"]);

                        UpdateCurrentBalanceFixed(StrFunds, true);

                        cmd.Parameters.AddWithValue("@Transaction_Current_Amount", Session["Current_Amount_Fixed"]);

                        cmd.ExecuteNonQuery();
                    }

                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error: {ex.Message.Replace("'", "\\'")}');", true);
                }

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Account number does not EXIST.');", true);
                
                return 0;
                
            }


            return 1;
        }

        protected void AccountTransactions()
        {
            // Check if Session["Account_Number_Cheque"] is not null or empty


            String AccountNumber = Session["Account_Number_Cheque"].ToString();

            if (AccountNumber != null && !string.IsNullOrEmpty(AccountNumber))
            {
                string query = "SELECT " +
                               "* " +
                               "FROM Transaction_Cheque WHERE Account_Number = @AccountNumber";

                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["con"].ToString();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@AccountNumber", AccountNumber);

                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            GridView1.DataSource = reader;
                            GridView1.DataBind();
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No transaction data found for the entered account number.');", true);
                        }
                    }
                    catch (Exception ex)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error: " + ex.Message + "');", true);
                        return;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            else
            {
               
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please enter a valid account number.');", true);
            }
        }

    }




}
