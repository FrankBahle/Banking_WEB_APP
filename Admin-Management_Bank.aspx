<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Admin-Management_Bank.aspx.cs" Inherits="Banking_WEB.Admin_Management_Bank" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid " style="margin-top: 5rem;">
        <div class="row">

            <!-- Existing content remains unchanged -->
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
                            <h3 class="fw-bold" style="color: #2b4d6e;">Account Management</h3>
                            <p class="text-muted small">Admin tools for managing user accounts</p>
                        </div>

                        <div class="input-group mb-3">
                            <label for="id" class="form-label">ID/Passport Number:&nbsp;&nbsp</label>
                            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Search customers using ID..."></asp:TextBox>
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-outline-primary" OnClick="btnSearch_Click" />
                        </div>

                        <div class="row">
                            <div class="col-md-6 mb-3">
                                <label for="firstName" class="form-label">First Name</label>
                                <asp:TextBox class="form-control form-control-lg" ID="firstName" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-6 mb-3">
                                <label for="lastName" class="form-label">Last Name</label>
                                <asp:TextBox class="form-control form-control-lg" ID="lastName" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="mb-3">
                            <label for="email" class="form-label">Email Address</label>
                            <asp:TextBox class="form-control form-control-lg" ID="email" runat="server"></asp:TextBox>
                        </div>

                        <div class="mb-3">
                            <label for="phone" class="form-label">Phone Number</label>
                            <asp:TextBox class="form-control form-control-lg" ID="phoneNumber" runat="server"></asp:TextBox>
                        </div>

                        <div class="row mb-3">
                            <div class="col-md-6">
                                <label for="accountType" class="form-label">Select Account Type</label>
                                <div class="form-group">
                                    <asp:ListBox CssClass="form-control" ID="accountType" runat="server" SelectionMode="Multiple">
                                        <asp:ListItem Value="Savings">Savings</asp:ListItem>
                                        <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                                        <asp:ListItem Value="Fixed">Fixed</asp:ListItem>
                                    </asp:ListBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <label for="accountType2" class="form-label">Display account types</label>
                                <asp:TextBox CssClass="form-control form-control-lg" ID="accountType2" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="mb-3">
                            <label for="accountStatus" class="form-label" display="block">Account Status</label>
                            <div class="form-group">
                                <asp:DropDownList class="form-control" ID="accountStatus" runat="server">
                                    <asp:ListItem Text="Pending" Value="Pending" Selected="True" />
                                    <asp:ListItem Text="Active" Value="Active"  />
                                    <asp:ListItem Text="Inactive" Value="Inactive" />
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="row mt-2">
                            <div class="col-md-4">
                                <asp:Button ID="btnAdd" runat="server" Text="Add Customer" CssClass="btn btn-success w-100" OnClick="btnAdd_Click" />
                            </div>
                            <div class="col-md-4">
                                <asp:Button ID="btnUpdate" runat="server" Text="Update Customer" CssClass="btn btn-success w-100" OnClick="btnUpdate_Click" />
                            </div>
                            <div class="col-md-4">
                                <asp:Button ID="btnDelete" runat="server" Text="Delete Customer" CssClass="btn btn-success w-100" OnClick="btnDelete_Click" />
                            </div>
                        </div>

                    </div>
                </div>
            </div>

            <div class="col-md-7 mb-4">
                <div class="card shadow-lg border-0 h-100">
                    <div class="card-body">

                        <h4 class="fw-bold text-primary text-center mb-0">Registered Bank Accounts</h4>
                        <hr>
                        <div class="card-body px-4 py-3">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Banking_AppConnectionString2 %>" SelectCommand="SELECT * FROM [Register_Client]"></asp:SqlDataSource>
                            <div style="overflow-x: auto;">
                                <asp:GridView ID="GridViewAccounts" runat="server"
                                    CssClass="table table-striped table-bordered"
                                    EmptyDataText="No accounts found." DataSourceID="SqlDataSource1" AutoGenerateColumns="False" DataKeyNames="Register_Client_ID_Passport" OnSelectedIndexChanged="GridViewAccounts_SelectedIndexChanged">
                                    <Columns>
                                        <asp:BoundField DataField="Register_Client_ID_Passport" HeaderText="Register_Client_ID_Passport" ReadOnly="True" SortExpression="Register_Client_ID_Passport" />
                                        <asp:BoundField DataField="Register_Client_Name" HeaderText="Register_Client_Name" SortExpression="Register_Client_Name" />
                                        <asp:BoundField DataField="Register_Client_Surname" HeaderText="Register_Client_Surname" SortExpression="Register_Client_Surname" />
                                        <asp:BoundField DataField="Register_Client_Email" HeaderText="Register_Client_Email" SortExpression="Register_Client_Email" />
                                        <asp:BoundField DataField="Register_Client_Phone_Number" HeaderText="Register_Client_Phone_Number" SortExpression="Register_Client_Phone_Number" />
                                        <asp:BoundField DataField="Register_Client_Account_Type" HeaderText="Register_Client_Account_Type" SortExpression="Register_Client_Account_Type" />
                                        <asp:BoundField DataField="Register_Client_Status" HeaderText="Register_Client_Status" SortExpression="Register_Client_Status" />
                                    </Columns>
                                </asp:GridView>
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
