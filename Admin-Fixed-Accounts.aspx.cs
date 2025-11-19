using System;
using System.Data;
using System.Data.SqlClient;

namespace Banking_WEB
{
    public partial class Admin_Fixed_Accounts : System.Web.UI.Page
    {
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string accountNumber = txtSearch.Text.Trim();

            if (!string.IsNullOrEmpty(accountNumber))
            {
                string query = "SELECT * FROM Fixed_Account WHERE Account_Number = @AccountNumber";
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Banking_AppConnectionString6"].ToString();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@AccountNumber", accountNumber);

                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            reader.Read();
                            txtFixedAccountID.Text = reader["Account_Number"].ToString();
                            txtCurrentAmount.Text = reader["Current_Amount"].ToString();
                            txtRegisterClientID.Text = reader["Register_Client_ID_Passport"].ToString();
                            txtAccountCreatedAt.Text = reader["Account_Created_At"].ToString();
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No data found for the entered account number.');", true);
                        }
                    }
                    catch (Exception ex)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error: " + ex.Message + "');", true);
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
