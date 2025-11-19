using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Banking_WEB
{
    public partial class User_Account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["role"] == null || Session["role"].ToString() == "")
            {
                Response.Redirect("Sign_Up_Bank.aspx");
            }
            else if(Session["role"].ToString() == "user")
            {
                LoadUserData();
                LoadUserDataCheque();
                LoadUserDataFixed();
                LoadUserDataSavings();
               // DeleteTransactionUser();
            }
        }



        void DeleteTransactionUser()
        {
            try
            {

                string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("DELETE FROM Fixed_Account", con);

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

        void LoadUserData() {
            try {

                string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                SqlConnection con = new SqlConnection(strcon);
                string ID_Passport = Session["ID_Passport"].ToString();

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("SELECT * FROM Register_Client WHERE Register_Client_ID_Passport = @id", con);
                cmd.Parameters.AddWithValue("@id", ID_Passport);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    Session["ID_Passport"] = dt.Rows[0][0].ToString();
                    Session["Username"] = dt.Rows[0][1].ToString();
                    Session["Surname"] = dt.Rows[0][2].ToString();
                    Session["Email"] = dt.Rows[0][3].ToString();
                    Session["Phone_Number"] = dt.Rows[0][4].ToString();
                    Session["Account_Type"] = dt.Rows[0][5].ToString();
                    Session["Password"] = dt.Rows[0][6].ToString();
                    Session["Status"] = dt.Rows[0][8].ToString();
                    Session["role"] = "user";

                    string status = Session["Status"]?.ToString().Trim().ToLower();
                    string Accounts = Session["Account_Type"]?.ToString().Trim().ToLower();
                    LoadAccounts(Accounts);

                }

            }
            catch (Exception ex)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error: {ex.Message.Replace("'", "\\'")}');", true);

            }


        }



        /// <summary>
        /// ///////////////////////////CHEQUE ACCOUNT///////////////////////////////////
        /// </summary>
        void LoadUserDataCheque()
        {
            try
            {

                string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                SqlConnection con = new SqlConnection(strcon);
                string ID_Passport = Session["ID_Passport"].ToString();

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("SELECT * FROM Cheque_Account WHERE Register_Client_ID_Passport = @id", con);
                cmd.Parameters.AddWithValue("@id", ID_Passport);

                CreateCheque(ID_Passport);


                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    Session["Account_Number_Cheque"] = dt.Rows[0][0].ToString();
                    Session["ID_Passport_Cheque"] = dt.Rows[0][1].ToString();
                    Session["Current_Amount_Cheque"] = dt.Rows[0][2].ToString();
                    Session["Account_Created_At_Cheque"] = dt.Rows[0][3].ToString();
                    Session["role"] = "user";
                }

            }
            catch (Exception ex)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error: {ex.Message.Replace("'", "\\'")}');", true);

            }


        }



        void CreateCheque(string idPassport)
        {
            if (IsNewAccountCheque(idPassport))
            {
                try
                {
                    string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        con.Open();

                        SqlCommand cmd = new SqlCommand(
                            "INSERT INTO Cheque_Account " +
                            "(Account_Number, Register_Client_ID_Passport, Current_Amount) " +
                            "VALUES (@Account_Number, @Register_Client_ID_Passport, @Current_Amount)", con);

                        cmd.Parameters.AddWithValue("@Account_Number", GenerateUniqueChequeAccountNumber());
                        cmd.Parameters.AddWithValue("@Register_Client_ID_Passport", idPassport);
                        cmd.Parameters.AddWithValue("@Current_Amount", GenerateRandomStartingAmount());

                        cmd.ExecuteNonQuery();
                    }

                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error: {ex.Message.Replace("'", "\\'")}');", true);
                }
            }
        }

        private string GenerateUniqueChequeAccountNumber()
        {
            string prefix = "CH";
            string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            int counter = 1;
            string newAccountNumber = "";

            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();

                while (true)
                {
                    newAccountNumber = prefix + counter.ToString("D4");

                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Cheque_Account WHERE Account_Number = @acc", con);
                    cmd.Parameters.AddWithValue("@acc", newAccountNumber);

                    int count = (int)cmd.ExecuteScalar();

                    if (count == 0)
                        break;

                    counter++;
                }

                con.Close();
            }

            return newAccountNumber;
        }




        /// <summary>
        /// /////////////////////////////FIXED ACCOUNT//////////////////////////////////
        /// </summary>



        void LoadUserDataFixed()
        {
            try
            {

                string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                SqlConnection con = new SqlConnection(strcon);
                string ID_Passport = Session["ID_Passport"].ToString();

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("SELECT * FROM Fixed_Account WHERE Register_Client_ID_Passport = @id", con);
                cmd.Parameters.AddWithValue("@id", ID_Passport);

                CreateFixed(ID_Passport);


                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    Session["Account_Number_Fixed"] = dt.Rows[0][0].ToString();
                    Session["ID_Passport_Fixed"] = dt.Rows[0][1].ToString();
                    Session["Current_Amount_Fixed"] = dt.Rows[0][2].ToString();
                    Session["Account_Created_At_Fixed"] = dt.Rows[0][3].ToString();
                    Session["role"] = "user";
                }

            }
            catch (Exception ex)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error: {ex.Message.Replace("'", "\\'")}');", true);

            }


        }



        void CreateFixed(string idPassport)
        {
            if (IsNewAccountFixed(idPassport))
            {
                try
                {
                    string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        con.Open();

                        SqlCommand cmd = new SqlCommand(
                            "INSERT INTO Fixed_Account " +
                            "(Account_Number, Register_Client_ID_Passport, Current_Amount) " +
                            "VALUES (@Account_Number, @Register_Client_ID_Passport, @Current_Amount)", con);

                        cmd.Parameters.AddWithValue("@Account_Number", GenerateUniqueFixedAccountNumber());
                        cmd.Parameters.AddWithValue("@Register_Client_ID_Passport", idPassport);
                        cmd.Parameters.AddWithValue("@Current_Amount", GenerateRandomStartingAmount());

                        cmd.ExecuteNonQuery();
                    }

                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error: {ex.Message.Replace("'", "\\'")}');", true);
                }
            }
        }

        private string GenerateUniqueFixedAccountNumber()
        {
            string prefix = "FX";
            string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            int counter = 1;
            string newAccountNumber = "";

            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();

                while (true)
                {
                    newAccountNumber = prefix + counter.ToString("D4");

                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Fixed_Account WHERE Account_Number = @acc", con);
                    cmd.Parameters.AddWithValue("@acc", newAccountNumber);

                    int count = (int)cmd.ExecuteScalar();

                    if (count == 0)
                        break;

                    counter++;
                }

                con.Close();
            }

            return newAccountNumber;
        }




        /// <summary>
        /// /////////////////////////////SAVING ACCOUNT//////////////////////////////////
        /// </summary>




        void LoadUserDataSavings()
        {
            try
            {

                string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                SqlConnection con = new SqlConnection(strcon);
                string ID_Passport = Session["ID_Passport"].ToString();

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("SELECT * FROM Savings_Account WHERE Register_Client_ID_Passport = @id", con);
                cmd.Parameters.AddWithValue("@id", ID_Passport);

                CreateSavings(ID_Passport);


                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    Session["Account_Number_Savings"] = dt.Rows[0][0].ToString();
                    Session["ID_Passport_Savings"] = dt.Rows[0][1].ToString();
                    Session["Current_Amount_Savings"] = dt.Rows[0][2].ToString();
                    Session["Account_Created_At_Savings"] = dt.Rows[0][3].ToString();
                    Session["role"] = "user";
                }

            }
            catch (Exception ex)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error: {ex.Message.Replace("'", "\\'")}');", true);

            }


        }



        void CreateSavings(string idPassport)
        {
            if (IsNewAccountSavings(idPassport))
            {
                try
                {
                    string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        con.Open();

                        SqlCommand cmd = new SqlCommand(
                            "INSERT INTO Savings_Account " +
                            "(Account_Number, Register_Client_ID_Passport, Current_Amount) " +
                            "VALUES (@Account_Number, @Register_Client_ID_Passport, @Current_Amount)", con);

                        cmd.Parameters.AddWithValue("@Account_Number", GenerateUniqueSavingAccountNumber());
                        cmd.Parameters.AddWithValue("@Register_Client_ID_Passport", idPassport);
                        cmd.Parameters.AddWithValue("@Current_Amount", GenerateRandomStartingAmount());

                        cmd.ExecuteNonQuery();
                    }

                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error: {ex.Message.Replace("'", "\\'")}');", true);
                }
            }
        }

        private string GenerateUniqueSavingAccountNumber()
        {
            string prefix = "SA";
            string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            int counter = 1;
            string newAccountNumber = "";

            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();

                while (true)
                {
                    newAccountNumber = prefix + counter.ToString("D4");

                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Savings_Account WHERE Account_Number = @acc", con);
                    cmd.Parameters.AddWithValue("@acc", newAccountNumber);

                    int count = (int)cmd.ExecuteScalar();

                    if (count == 0)
                        break;

                    counter++;
                }

                con.Close();
            }

            return newAccountNumber;
        }








        void LoadAccounts(string account_types)
        {

            string[] tokens = account_types.Split(',')
                                           .Select(s => s.Trim().ToLower())
                                           .ToArray();

           
            hlSavings.Visible = false;
            hlCheque.Visible = false;
            hlFixed.Visible = false;

           
            foreach (string type in tokens)
            {
                if (type == "savings")
                {
                    hlSavings.Visible = true;
                }
                else if (type == "cheque")
                {
                    hlCheque.Visible = true;
                }
                else if (type == "fixed")
                {
                    hlFixed.Visible = true;
                }
            }
        }



        bool IsNewAccountCheque(string idPassport)
        {
            string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                string query = "SELECT 1 FROM Cheque_Account WHERE Register_Client_ID_Passport = @id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", idPassport);
                    con.Open();
                    var result = cmd.ExecuteScalar();
                    return result == null; 
                }
            }
        }

        bool IsNewAccountFixed(string idPassport)
        {
            string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                string query = "SELECT 1 FROM Fixed_Account WHERE Register_Client_ID_Passport = @id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", idPassport);
                    con.Open();
                    var result = cmd.ExecuteScalar();
                    return result == null;
                }
            }
        }

        bool IsNewAccountSavings(string idPassport)
        {
            string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                string query = "SELECT 1 FROM Savings_Account WHERE Register_Client_ID_Passport = @id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", idPassport);
                    con.Open();
                    var result = cmd.ExecuteScalar();
                    return result == null;
                }
            }
        }



        private decimal GenerateRandomStartingAmount()
        {
            Random random = new Random();
            return 0; 
        }



    }
}