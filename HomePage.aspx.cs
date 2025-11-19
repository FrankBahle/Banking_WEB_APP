using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;


namespace Banking_WEB
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Session["role"]="Home";
        }


        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration_Bank.aspx");
        } 

        protected void LinkButton2_Click(object sender, EventArgs e) {
            Response.Redirect("Sign_In_Bank.aspx");
        }
    }
}