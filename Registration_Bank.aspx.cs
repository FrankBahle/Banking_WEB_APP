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
    public partial class WebForm1 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
     

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["role"] = "Create_Account";
        }

        protected void Button_Submit_Click(object sender, EventArgs e)
        {

            // Validate inputs before doing anything
            if (CheckMemberExists())
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Member already exists');", true);


            }
            else {

                signUp();
            }

           

        }

        private bool CheckMemberExists() {

           
           
                try
                {

                SqlConnection con = new SqlConnection(strcon);
                   if (con.State == ConnectionState.Closed)
                    {
                    con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Register_Client WHERE Register_Client_ID_Passport ='" + idNumber.Text.Trim() + "';", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                     da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;

                }
                else
                {
                    return false;
                }

          


            }
            catch (Exception ex)
                {
                    // Show the actual error message
     
                return true;
            }



        }


        void signUp() {
            try
            {

                string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Register_Client (Register_Client_ID_Passport, Register_Client_Name, Register_Client_Surname, Register_Client_Email, Register_Client_Phone_Number, Register_Client_Account_Type, Register_Client_Pass_Word, Register_Client_Confirm_Pass_Word , Register_Client_Status) " +
                        "VALUES (@Register_Client_ID_Passport, @Register_Client_Name, @Register_Client_Surname, @Register_Client_Email, @Register_Client_Phone_Number, @Register_Client_Account_Type, @Register_Client_Pass_Word, @Register_Client_Confirm_Pass_Word,@Register_Client_Status)", con);

                    // Parameters — in the correct orders
                    cmd.Parameters.AddWithValue("@Register_Client_ID_Passport", idNumber.Text.Trim());
                    cmd.Parameters.AddWithValue("@Register_Client_Name", firstName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Register_Client_Surname", lastName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Register_Client_Email", email.Text.Trim());
                    cmd.Parameters.AddWithValue("@Register_Client_Phone_Number", phone.Text.Trim());
                    cmd.Parameters.AddWithValue("@Register_Client_Account_Type", accountType.SelectedValue);
                    cmd.Parameters.AddWithValue("@Register_Client_Status","Pending");
                    cmd.Parameters.AddWithValue("@Register_Client_Pass_Word", password.Text.Trim());
                    cmd.Parameters.AddWithValue("@Register_Client_Confirm_Pass_Word", confirmPassword.Text.Trim());

                    cmd.ExecuteNonQuery();
                    con.Close();
                    // Close connection automatically with 'using'
                }

                // Show success alert
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Account has successfully been created.  ');", true);
            }
            catch (Exception ex)
            {
                // Show the actual error message
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error: {ex.Message.Replace("'", "\\'")}');", true);
            }


        }




      
    }
}