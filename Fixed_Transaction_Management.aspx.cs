
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Banking_WEB
    {
        public partial class Fixed_Transaction_Management : System.Web.UI.Page
        {
            protected void btnSearch_Click(object sender, EventArgs e)
            {
                string accountNumber = txtSearch.Text.Trim();  

                if (!string.IsNullOrEmpty(accountNumber))
                {
                   
                    string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Banking_AppConnectionString6"].ToString();

                  
                    string query = "SELECT * FROM Transaction_Fixed WHERE Account_Number = @AccountNumber";

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

                                
                                txtTransactionFixedID.Text = reader["Transaction_Fixed_ID"].ToString();
                                txtCurrentAmount.Text = reader["Transaction_Current_Amount"].ToString();
                                txtTransactionTransfer.Text = reader["Transaction_Transfer"].ToString();
                                txtTransactionDeposit.Text = reader["Transaction_Deposite"].ToString();
                                txtTransactionForeignAccount.Text = reader["Transaction_Foreign_Account_Number"].ToString();
                            Session["role"] = "admin";
                            }
                            else
                            {
                                
                                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No transaction data found for this account number.');", true);
                            }
                        }
                        catch (Exception ex)
                        {
                            
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error: {ex.Message}');", true);
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


