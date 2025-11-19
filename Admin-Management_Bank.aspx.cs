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
    public partial class Admin_Management_Bank : System.Web.UI.Page
    {



        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            GridViewAccounts.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckifAuthorExist())
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Member already exists');", true);

            }
            else
            {
                AddUser();
                clearForm();
               
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CheckifAuthorExist())
            {
                UpdateUser();
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Member DOES NOT already exists');", true);


            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteUser();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (CheckifAuthorExist())
            {


                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Member exists');", true);
                DisplayInfo();

            }
            else
            {

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Member DOESNT exists');", true);
                clearForm();

            }
        }

        void DisplayInfo() {
            try
            {

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM Register_Client WHERE Register_Client_ID_Passport ='" + txtSearch.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    txtSearch.Text = dt.Rows[0][0].ToString();
                    firstName.Text = dt.Rows[0][1].ToString();
                    lastName.Text = dt.Rows[0][2].ToString();
                    email.Text = dt.Rows[0][3].ToString();
                    phoneNumber.Text = dt.Rows[0][4].ToString();
                    accountType.SelectedValue = dt.Rows[0][5].ToString();
                    accountStatus.Text = dt.Rows[0][8].ToString();
                    accountType2.Text = dt.Rows[0][5].ToString();




                }
                 
                con.Close();

            }
            catch (Exception ex)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error: {ex.Message.Replace("'", "\\'")}');", true);

            }

        }


        bool CheckifAuthorExist()
        {

            try
            {

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM Register_Client WHERE Register_Client_ID_Passport ='" + txtSearch.Text.Trim() + "';", con);
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


                return true;
            }




        }


        void AddUser()
        {


            try
            {
                string selectedTypes = string.Join(",",
                                    accountType.Items.Cast<ListItem>()
                                    .Where(i => i.Selected)
                                     .Select(i => i.Value)
                                    );

                string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Register_Client (Register_Client_ID_Passport, Register_Client_Name, Register_Client_Surname, Register_Client_Email, Register_Client_Phone_Number, Register_Client_Account_Type) " +
                        "VALUES (@Register_Client_ID_Passport, @Register_Client_Name, @Register_Client_Surname, @Register_Client_Email, @Register_Client_Phone_Number)", con);


                    cmd.Parameters.AddWithValue("@Register_Client_ID_Passport", txtSearch.Text.Trim());
                    cmd.Parameters.AddWithValue("@Register_Client_Name", firstName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Register_Client_Surname", lastName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Register_Client_Email", email.Text.Trim());
                    cmd.Parameters.AddWithValue("@Register_Client_Phone_Number", phoneNumber.Text.Trim());
                    cmd.Parameters.AddWithValue("@Register_Client_Account_Type", selectedTypes);
                    cmd.Parameters.AddWithValue("@Register_Client_Status", accountStatus.SelectedValue);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    if (dt.Rows.Count>=1) {
                        string[] Status = dt.Rows[0][8].ToString().Trim().Split(',');



                    }
                  
                    cmd.ExecuteNonQuery();
                    con.Close();

                }


                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Account has successfully been created.');", true);
            }
            catch (Exception ex)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error: {ex.Message.Replace("'", "\\'")}');", true);
            }
            Response.Redirect(Request.RawUrl);

        }
        void UpdateUser()
            {
            try
            {
                string selectedTypes = string.Join(",",
                    accountType.Items.Cast<ListItem>()
                    .Where(i => i.Selected)
                     .Select(i => i.Value)
                    );

                string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand(
                     "UPDATE Register_Client SET " +
                     "Register_Client_Name = @Register_Client_Name, " +
                     "Register_Client_Surname = @Register_Client_Surname, " +
                     "Register_Client_Email = @Register_Client_Email, " +
                     "Register_Client_Phone_Number = @Register_Client_Phone_Number, " +
                     "Register_Client_Account_Type = @Register_Client_Account_Type, " +
                     "Register_Client_Status = @Register_Client_Status " +
                     "WHERE Register_Client_ID_Passport = @Register_Client_ID_Passport", con);



                    cmd.Parameters.AddWithValue("@Register_Client_ID_Passport", txtSearch.Text.Trim());
                    cmd.Parameters.AddWithValue("@Register_Client_Name", firstName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Register_Client_Surname", lastName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Register_Client_Email", email.Text.Trim());
                    cmd.Parameters.AddWithValue("@Register_Client_Phone_Number", phoneNumber.Text.Trim());
                    cmd.Parameters.AddWithValue("@Register_Client_Account_Type", selectedTypes);
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




        void DeleteUser()
        {
            try
            {

                string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand(
                     "DELETE FROM Register_Client WHERE " +
                     "Register_Client_ID_Passport = @Register_Client_ID_Passport", con);
                    cmd.Parameters.AddWithValue("@Register_Client_ID_Passport", txtSearch.Text.Trim());


                    cmd.ExecuteNonQuery();
                    con.Close();

                }


                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Account has successfully been DELETED.');", true);
                clearForm();
            }
            catch (Exception ex)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error: {ex.Message.Replace("'", "\\'")}');", true);
            }
            Response.Redirect(Request.RawUrl);
        }

        void clearForm() {
            txtSearch.Text = " ";
            firstName.Text = " ";
            lastName.Text = " ";
            email.Text = " ";
            phoneNumber.Text = " ";
            accountType.Text = " ";

            accountType2.Text =" ";
        }

        protected void GridViewAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

     

    }
}