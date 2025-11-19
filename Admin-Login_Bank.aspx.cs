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
    public partial class Admin_Bank : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;


        public object TextBox_IDNumber { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
          

        }

        protected void Button_Sign_In_Click(object sender, EventArgs e)
        {
            Admin_Sign_In();

        }

        void Admin_Sign_In() {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM Admin_Manager WHERE Admin_Manager_ID = @id AND Admin_Manager_Pass_Word = @password", con);
                cmd.Parameters.AddWithValue("@id",Admin_ID.Text.Trim());
                cmd.Parameters.AddWithValue("@password", Admin_Password.Text.Trim());

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Alert", $"alert('{dr.GetValue(0).ToString()}');", true);

                        ClientScript.RegisterStartupScript(this.GetType(), "Alert", $"alert('You Have logged In Successfully');", true);
                        ClientScript.RegisterStartupScript(this.GetType(), "Alert", $"alert('{dr.GetValue(0).ToString()}');", true);
                        Session["username"] = dr.GetValue(1).ToString();
                        Session["fullname"] = dr.GetValue(2).ToString();
                        Session["role"] = "admin";
                        
                    }
                    Response.Redirect("Admin-Management_Bank.aspx");
                }
                else
                {


                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", $"alert('UnFortunately , You dont have an account with TrustedWealth Incoparations');", true);
                }

            }
            catch (Exception ex)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error: {ex.Message.Replace("'", "\\'")}');", true);

            }


        }
    }
}