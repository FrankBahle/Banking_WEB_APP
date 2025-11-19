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
    public partial class User_Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["role"] == null || Session["role"].ToString() == "")
            {
                Response.Redirect("Sign_Up_Bank.aspx");
            }
            else if (Session["role"].ToString() == "user")
            {
                LoadUserData();

            }
            
        }

        void LoadUserData()
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


                SqlCommand cmd = new SqlCommand("SELECT * FROM Register_Client WHERE Register_Client_ID_Passport = @id", con);
                cmd.Parameters.AddWithValue("@id", ID_Passport);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    txtSearch.Text = dt.Rows[0][0].ToString();
                    firstName.Text = dt.Rows[0][1].ToString();
                    lastName.Text = dt.Rows[0][2].ToString();
                    email.Text = dt.Rows[0][3].ToString();
                    phoneNumber.Text = dt.Rows[0][4].ToString();
                    password.Text = dt.Rows[0][6].ToString();
                    accountStatus.Text = dt.Rows[0][8].ToString();
                    accountType2.Text = dt.Rows[0][5].ToString();


                }

            }
            catch (Exception ex)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error: {ex.Message.Replace("'", "\\'")}');", true);

            }



        }

        protected void Button_Update_Profile_Click(object sender, EventArgs e)
        {
            UpdateUser();
            Response.Redirect(Request.RawUrl);
        }

        void UpdateUser()
        {
            try
            {
                string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    // Build SQL query conditionally
                    string updateQuery =
                        "UPDATE Register_Client SET " +
                        "Register_Client_Name = @Register_Client_Name, " +
                        "Register_Client_Surname = @Register_Client_Surname, " +
                        "Register_Client_Email = @Register_Client_Email, " +
                        "Register_Client_Phone_Number = @Register_Client_Phone_Number, ";

                    var selectedItems = accountType.Items.Cast<ListItem>()
                       .Where(i => i.Selected)
                       .Select(i => i.Value)
                       .ToList();

                    if (selectedItems.Count > 0)
                    {
                        updateQuery += "Register_Client_Account_Type = @Register_Client_Account_Type, ";
                    }

                    updateQuery +=
                        "Register_Client_Pass_Word = @Register_Client_Pass_Word, " +
                        "Register_Client_Confirm_Pass_Word = @Register_Client_Confirm_Pass_Word, " +
                        "Register_Client_Status = @Register_Client_Status " +
                        "WHERE Register_Client_ID_Passport = @Register_Client_ID_Passport";

                    SqlCommand cmd = new SqlCommand(updateQuery, con);

                    if (selectedItems.Count > 0)
                    {
                        string selectedTypes = string.Join(",", selectedItems);
                        cmd.Parameters.AddWithValue("@Register_Client_Account_Type", selectedTypes);
                    }

                    cmd.Parameters.AddWithValue("@Register_Client_ID_Passport", txtSearch.Text.Trim());
                    cmd.Parameters.AddWithValue("@Register_Client_Name", firstName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Register_Client_Surname", lastName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Register_Client_Email", email.Text.Trim());
                    cmd.Parameters.AddWithValue("@Register_Client_Phone_Number", phoneNumber.Text.Trim());

                    if (!string.IsNullOrWhiteSpace(NewPassword.Text))
                    {
                        cmd.Parameters.AddWithValue("@Register_Client_Pass_Word", NewPassword.Text.Trim());
                        cmd.Parameters.AddWithValue("@Register_Client_Confirm_Pass_Word", NewPassword.Text.Trim());
                    }
                    else
                    {
                        // Use the current password if new one is not provided
                        cmd.Parameters.AddWithValue("@Register_Client_Pass_Word", password.Text.Trim());
                        cmd.Parameters.AddWithValue("@Register_Client_Confirm_Pass_Word", password.Text.Trim());
                    }

                    cmd.Parameters.AddWithValue("@Register_Client_Status", accountStatus.SelectedValue);

                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Account has successfully been UPDATED.');", true);
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error: {ex.Message.Replace("'", "\\'")}');", true);
            }
        }


      
    }
}