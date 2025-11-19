<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Admin-Savings-Accounts.aspx.cs" Inherits="Banking_WEB.Admin_Savings_Accounts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container-fluid" style="margin-top: 5rem;">
        <div class="row">
            <div class="col-md-5 mb-4">
                <div class="card shadow-lg border-0">
                    <div class="card-body px-4 py-5">
                        <div class="text-center mb-4">
                            <img src="img/Account-Management-img.jpg"
                                alt="Admin Profile"
                                class="rounded-circle border border-3"
                                style="width: 125px; height: 125px; border-color: #b0c4de;">
                        </div>

                        <div class="card-header bg-white border-0 pt-3 text-center">
                            <h3 class="fw-bold" style="color: #2b4d6e;">Savings Account Management</h3>
                            <p class="text-muted small">Admin tools for managing Savings account details</p>
                        </div>

                        <div class="input-group mb-3">
                            <label for="id" class="form-label">ID/Passport Number:&nbsp;&nbsp</label>
                            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Search customers using ID..."></asp:TextBox>
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-outline-primary" OnClick="btnSearch_Click" />
                        </div>

                        <div class="mb-3">
                            <label for="savingsAccountID" class="form-label">Savings Account ID</label>
                            <asp:TextBox ID="txtSavingsAccountID" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                        </div>

                        <div class="mb-3">
                            <label for="currentAmount" class="form-label">Current Amount</label>
                            <asp:TextBox ID="txtCurrentAmount" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="mb-3">
                            <label for="registerClientID" class="form-label">Register Client ID/Passport</label>
                            <asp:TextBox ID="txtRegisterClientID" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="mb-3">
                            <label for="accountCreatedAt" class="form-label">Account Created At</label>
                            <asp:TextBox ID="txtAccountCreatedAt" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                    </div>
                </div>
            </div>

            <div class="col-md-7 mb-4">
                <div class="card shadow-lg border-0 h-100">
                    <div class="card-body">
                        <h4 class="fw-bold text-primary text-center mb-0">Savings Account History</h4>
                        <hr>
                        <div class="card-body px-4 py-3">
                            <div style="overflow-x: auto;">
                                <asp:GridView runat="server" AutoGenerateColumns="False" 
                                    DataSourceID="SqlDataSource1" CssClass="table table-striped table-bordered">
                                    <Columns>
                                        <asp:BoundField DataField="Account_Number" HeaderText="Account_Number" SortExpression="Account_Number" />
                                        <asp:BoundField DataField="Register_Client_ID_Passport" HeaderText="Register_Client_ID_Passport" SortExpression="Register_Client_ID_Passport" />
                                        <asp:BoundField DataField="Current_Amount" HeaderText="Current_Amount" SortExpression="Current_Amount" />
                                        <asp:BoundField DataField="Account_Created_At" HeaderText="Account_Created_At" SortExpression="Account_Created_At" />
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Banking_AppConnectionString7 %>" SelectCommand="SELECT * FROM [Savings_Account]"></asp:SqlDataSource>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
         <div class="text-center mt-4">
    <a href="Savings_Transaction_Management.aspx"  runat="server" >-   Savings Transactions    -</a>
    <a href="Cheque_Transaction_Management.aspx"  runat="server" >-   Cheque Transactions    -</a>
    <a href="Fixed_Transaction_Management.aspx"  runat="server" >-   Fixed Transactions     -</a>
    <a href="Admin-Fixed-Accounts.aspx" runat="server">-    Fixed Accounts     -</a>
    <a href="Admin-Cheque-Accounts.aspx"  runat="server">-     Cheque Accounts     -</a>
    <a href="Admin-Savings-Accounts.aspx"  runat="server" >-     Savings Accounts     -</a>

</div>
</asp:Content>
