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
    public partial class Sign_Up_Bank : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Sign_In_Click(object sender, EventArgs e)
        {

            Sign_In();

        }



   
        /// SA0001
        /// FX0001

        void Sign_In() {

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM Register_Client WHERE Register_Client_ID_Passport = @id AND Register_Client_Pass_Word = @password", con);
                cmd.Parameters.AddWithValue("@id", TextBox_IDNumber.Text.Trim());
                cmd.Parameters.AddWithValue("@password", TextBox_Password.Text.Trim());
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

                    if (status == "pending")
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Alert", $"alert('Your account is still [pending this will may take a while');", true);
                    }
                    else if (status == "inactive")
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Alert", $"alert('Unfortunately, your account is inactive.Please contact the bank to activate your account.');", true);

                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Alert", $"alert('You Have logged In Successfully');", true);
                        Response.Redirect("User-Account.aspx");
                    }


                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", $"alert('UnFortunately, You don’t have an account with TrustedWealth Incoparations');", true);
                }
            }
            catch (Exception ex)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error: {ex.Message.Replace("'", "\\'")}');", true);


            }



        }
    }
}