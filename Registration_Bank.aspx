<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Registration_Bank.aspx.cs" Inherits="Banking_WEB.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="d-flex flex-column min-vh-100">
  <main class="flex-grow-1">
    <div class="container-fluid mb-5">
      <div class="row">

        <style>
          .blurred-dark-blue {
            filter: blur(4px) brightness(60%);
            object-fit: cover;
          }

          .overlay-text {
            color: #a3c4dc;
            font-weight: 600;
            font-size: 2.5rem;
          }

          .overlay-subtext {
            color: #a3c4dc;
            font-weight: 500;
            font-size: 1.2rem;
          }
        </style>

        <div class="col-md-4 p-0">
          <div class="card text-bg-dark h-100 position-relative overflow-hidden">
            <img src="img/Register_Detials_Image.jpg" class="card-img h-100 blurred-dark-blue" alt="Banking Image">
            <div class="card-img-overlay d-flex justify-content-end align-items-end p-5">
              <div class="text-end">
                <h5 class="overlay-text">Join <b>TrustedWealth</b><br>and take control<br>of your financial future</h5>
              </div>
            </div>
          </div>
        </div>

    
        <div class="col-md-8 d-flex align-items-center justify-content-center bg-light py-5">
          <div class="card w-75">
            <div class="card-body">
              <div class="card-header bg-white border-0 pt-4">
                <h3 class="text-center text-primary">Create Your Account</h3>
              </div>

              <div class="row g-3">
                <div class="col-md-6 mb-3">
                  <label for="firstName" class="form-label">First Name</label>
                  <asp:TextBox ID="firstName" runat="server" CssClass="form-control form-control-lg" />
                </div>
                <div class="col-md-6 mb-3">
                  <label for="lastName" class="form-label">Last Name</label>
                  <asp:TextBox ID="lastName" runat="server" CssClass="form-control form-control-lg" />
                </div>
              </div>

              <div class="mb-3">
                <label for="idNumber" class="form-label">ID/Passport Number</label>
                <asp:TextBox ID="idNumber" runat="server" CssClass="form-control form-control-lg" />
              </div>

              <div class="mb-3">
                <label for="email" class="form-label">Email Address</label>
                <asp:TextBox ID="email" runat="server" CssClass="form-control form-control-lg" TextMode="Email" />
              </div>

              <div class="mb-3">
                <label for="phone" class="form-label">Phone Number</label>
                <asp:TextBox ID="phone" runat="server" CssClass="form-control form-control-lg" TextMode="Phone" />
              </div>

              <div class="mb-3">
                <label for="accountType" class="form-label">Account Type</label><br>
                <asp:DropDownList ID="accountType" runat="server" CssClass="form-select form-select-lg">
                  <asp:ListItem Text="-- Select Account Type --" Value="" />
                  <asp:ListItem Text="Savings Account" Value="Savings" />
                  <asp:ListItem Text="Cheque Account" Value="Cheque" />
                  <asp:ListItem Text="Fixed Account" Value="Fixed" />
                </asp:DropDownList>
              </div>

              <div class="row">
                <div class="col-md-6 mb-3">
                  <label for="password" class="form-label">Password</label>
                  <asp:TextBox ID="password" runat="server" CssClass="form-control form-control-lg" TextMode="Password" />
                  <div class="form-text">Minimum 8 characters</div>
                </div>
                <div class="col-md-6 mb-3">
                  <label for="confirmPassword" class="form-label">Confirm Password</label>
                  <asp:TextBox ID="confirmPassword" runat="server" CssClass="form-control form-control-lg" TextMode="Password" />
                </div>
              </div>

                <div class="mb-3 form-check mt-3">
                <asp:CheckBox ID="terms" runat="server"  CssClass="form-check-input" />
                <label class="form-check-label" for="terms">I agree to the
                  <a href="Terms-Conditions.aspx" class="text-decoration-none">Terms & Conditions</a>
                </label>
              </div>

              <div class="col-12">
                <asp:Button ID="Button_Submit" runat="server" CssClass="btn btn-success w-100" placeholder = "Submit"
                 BackColor="#b0c4de" ForeColor="#2b4d6e" BorderColor="#b0c4de"  OnClick="Button_Submit_Click"/>
              </div>

              

            </div>
          </div>
        </div>
      </div>
    </div>
   </main>
 </div>

</asp:Content>
