using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace Banking_WEB
{
    public partial class Savings_Transaction_Management : System.Web.UI.Page
    {
       
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Banking_AppConnectionString6"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            
            string idPassport = txtSearch.Text.Trim();

           
            if (string.IsNullOrEmpty(idPassport))
            {
               
                Response.Write("<script>alert('Please enter an ID or Passport Number to search.');</script>");
                return;
            }

          
            string query = "SELECT * FROM Transaction_Savings WHERE Account_Number = @AccountNumber";

       
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                
                    cmd.Parameters.AddWithValue("@AccountNumber", idPassport);

                    try
                    {
                       
                        conn.Open();

                        
                        SqlDataReader reader = cmd.ExecuteReader();

                       
                        if (reader.HasRows)
                        {
                           
                            reader.Read();

                         
                            txtCurrentAmount.Text = reader["Transaction_Current_Amount"].ToString();
                            txtTransactionTransfer.Text = reader["Transaction_Transfer"].ToString();
                            txtTransactionDeposit.Text = reader["Transaction_Deposite"].ToString();
                            txtTransactionForeignAccount.Text = reader["Transaction_Foreign_Account_Number"].ToString();
                            Session["role"] = "admin";
                        }
                        else
                        {
                            
                            Response.Write("<script>alert('No data found for the given ID/Passport Number.');</script>");
                        }
                    }
                    catch (Exception ex)
                    {
                       
                        Response.Write("<script>alert('An error occurred: " + ex.Message + "');</script>");
                    }
                }
            }
        }
    }
}
