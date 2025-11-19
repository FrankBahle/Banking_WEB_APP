using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Banking_WEB
{
    public partial class Site1 : System.Web.UI.MasterPage {
        public object ClientScript { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
         {
    

                try{

                if (Session["role"].ToString() =="Home")
                {
                    LinkButtonSignIn.Visible = true;
                    LinkButtonCreateAccount.Visible = true;
                    LinkButtonHome.Visible = true;
                    LinkButtonAdmin.Visible = true;

                    LinkButtonUserAccount.Visible = false;
                    LinkButtonLogout.Visible = false;
                }
                else if (Session["role"].ToString() == "user")
                {

                    LinkButtonUserAccount.Visible = true;
                    LinkButtonLogout.Visible = true;


                    LinkButtonSignIn.Visible = false;
                    LinkButtonCreateAccount.Visible = false;
                    LinkButtonAdmin.Visible = false;
                }
                else if (Session["role"].ToString() == "admin")
                {
                    LinkButtonUserAccount.Visible = false;
                    LinkButtonLogout.Visible = true;


                    LinkButtonSignIn.Visible = false;
                    LinkButtonCreateAccount.Visible = false;
                    LinkButtonAdmin.Visible = false;

                } else if (Session["role"].ToString() == "Create_Account") {

                    LinkButtonSignIn.Visible = true;
                    LinkButtonCreateAccount.Visible = false;
                    LinkButtonHome.Visible = true;
                    LinkButtonAdmin.Visible = true;

                    LinkButtonUserAccount.Visible = false;
                    LinkButtonLogout.Visible = false;

                }
               


            }
            catch (Exception ex) { 
                
                
                
                
                
                }
            
            
         }

        protected void LinkButtonHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void LinkButtonAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin-Login_Bank.aspx");
        }

        protected void LinkButtonUserAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("User-Account.aspx");
        }

        protected void LinkButtonSignIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Sign_In_Bank.aspx");
        }

        protected void LinkButtonLogout_Click(object sender, EventArgs e)
        {
            Response.Write("You Have Logged out of the account");
            Response.Redirect("HomePage.aspx");
        }

        protected void LinkButtonCreateAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration_Bank.aspx");
        }
    }
}