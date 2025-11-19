<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="User-Account.aspx.cs" Inherits="Banking_WEB.User_Account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .card:hover {
            transform: scale(1.02);
            box-shadow: 0 8px 20px rgba(0, 0, 0, 0.15);
            transition: transform 0.2s ease-in-out;
        }
    </style>

    <main class="py-5">
        <div class="container" style="margin-top: 5rem;">

            <div class="row">
                
                <div class="col-md-4 mb-4">
                    <asp:HyperLink ID="hlProfileCard" runat="server" NavigateUrl="User-Profile_Bank.aspx" CssClass="text-decoration-none d-block h-100">
                        <div class="card shadow-lg border-0 rounded-4 h-100">
                            <div class="card-body px-4 py-1">
                               
                                <div class="text-center mb-4">
                                    <br>
                                    <img src="img/User-Profile.jpg" alt="User Profile Image"
                                         class="rounded-circle border border-3"
                                         style="width: 120px; height: 120px; border-color: #b0c4de;">
                                    <p class="text-muted mt-2 mb-0">
                                        <i class="fas fa-user-check me-1 text-success"></i>
                                        <strong>Status:</strong>
                                        <span class="badge bg-success"><%= Session["Status"] %></span>
                                    </p>
                                </div>

                              
                                <div class="card-header bg-white border-0 pt-3">
                                    <h3 class="text-center" style="color: #2b4d6e;">
                                        Welcome Back<br>
                                        <strong><i class="fas fa-user-circle me-1"></i>Mr <%= Session["username"] %></strong>
                                    </h3>
                                </div>

                               
                                <div class="mt-4 text-start px-2 small">
                                    <p class="mb-3">
                                        <i class="fas fa-envelope text-primary me-2"></i>
                                        <strong>Email:</strong>
                                        <span class="text-dark"><%= Session["Email"] %></span>
                                    </p>
                                    <p class="mb-3">
                                        <i class="fas fa-phone-alt text-primary me-2"></i>
                                        <strong>Phone:</strong>
                                        <span class="text-dark"><%= Session["Phone_Number"] %></span>
                                    </p>
                                    <p class="mb-3">
                                        <i class="fas fa-credit-card text-primary me-2"></i>
                                        <strong>Account Type:</strong>
                                        <span class="text-dark"><%= Session["Account_Type"] %></span>
                                    </p>
                                    <p class="mb-1">
                                        <i class="fas fa-shield-alt text-primary me-2"></i>
                                        <strong>Account Status:</strong>
                                        <span class="text-dark"><%= Session["Status"] %></span>
                                    </p>
                                </div>
                            </div>
                        </div>
                    </asp:HyperLink>
                </div>


                <div class="col-md-8">
                    <asp:HyperLink ID="hlCheque" runat="server" NavigateUrl="Cheque-Account.aspx" CssClass="text-decoration-none d-block">
                        <div class="card mb-4 border-0 shadow-lg rounded-3" style="background-color: #dbe9f4;">
                            <div class="card-body d-flex align-items-center px-4 py-4">
                                <i class="fas fa-money-check-alt fa-3x text-primary me-4"></i>
                                <div class="flex-grow-1">
                                    <h5 class="mb-1">Cheque Account</h5>
                                    <p class="mb-2 text-muted">Account Type: Cheque</p>
                                    <h4 class="fw-bold mb-2">R <%= Session["Current_Amount_Cheque"] %></h4>
                                    <p class="mb-0 text-muted">Account Number: <%= Session["Account_Number_Cheque"] %></p>
                                    <p class="mb-0 text-muted">Account Created: <%= Session["Account_Created_At_Cheque"] %></p>
                                    
                                </div>
                            </div>
                        </div>
                    </asp:HyperLink>

                    <asp:HyperLink ID="hlSavings" runat="server" NavigateUrl="Savings-Account.aspx" CssClass="text-decoration-none d-block">
                        <div class="card mb-4 border-0 shadow-lg rounded-3" style="background-color: #c7dff3;">
                            <div class="card-body d-flex align-items-center px-4 py-4">
                                <i class="fas fa-piggy-bank fa-3x text-primary me-4"></i>
                                <div class="flex-grow-1">
                                    <h5 class="mb-1">Savings Account</h5>
                                    <p class="mb-2 text-muted">Account Type: Savings</p>
                                   <h4 class="fw-bold mb-2">R <%= Session["Current_Amount_Savings"] %></h4>
                                    <p class="mb-0 text-muted">Account Number: <%= Session["Account_Number_Savings"] %></p>
                                    <p class="mb-0 text-muted">Account Created: <%= Session["Account_Created_At_Savings"] %></p>
                                </div>
                            </div>
                        </div>
                    </asp:HyperLink>

                    <asp:HyperLink ID="hlFixed" runat="server" NavigateUrl="Fixed-Account.aspx" CssClass="text-decoration-none d-block">
                        <div class="card mb-4 border-0 shadow-lg rounded-3" style="background-color: #b0cde8;">
                            <div class="card-body d-flex align-items-center px-4 py-4">
                                <i class="fas fa-lock fa-3x text-primary me-4"></i>
                                <div class="flex-grow-1">
                                    <h5 class="mb-1">Fixed Deposit</h5>
                                    <p class="mb-2 text-muted">Account Type: Fixed Account</p>
                                    <h4 class="fw-bold mb-2">R <%= Session["Current_Amount_Fixed"] %></h4>
                                    <p class="mb-0 text-muted">Account Number: <%= Session["Account_Number_Fixed"] %></p>
                                    <p class="mb-0 text-muted">Account Created: <%= Session["Account_Created_At_Fixed"] %></p>
                                    
                                </div>
                            </div>
                        </div>
                    </asp:HyperLink>

                    <asp:HyperLink ID="hlAddNew" runat="server" NavigateUrl="User-Profile_Bank.aspx" CssClass="text-decoration-none d-block">
                        <div class="card mb-4 border-0 shadow-lg rounded-3 text-center" style="background-color: #e0ebf5;">
                            <div class="card-body px-4 py-5 d-flex align-items-center justify-content-center">
                                <div>
                                    <i class="fas fa-plus-circle fa-2x text-primary mb-2"></i>
                                    <h6 class="text-primary mb-0 fw-semibold">Add New Account</h6>
                                </div>
                            </div>
                        </div>
                    </asp:HyperLink>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
