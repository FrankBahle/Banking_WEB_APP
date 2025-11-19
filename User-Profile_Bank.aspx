<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="User-Profile_Bank.aspx.cs" Inherits="Banking_WEB.User_Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <section class="py-5 mt-5 mb-5" style="background-color: #e6f0fa; min-height: 100vh;">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-md-8">
                    <div class="card shadow-lg">
                        <div class="card-body">

                            <div class="text-center mb-4">
                                <img src="img/User-Profile.jpg" alt="User Profile Image" class="rounded-circle border border-3" style="width: 120px; height: 120px; border-color: #b0c4de;">
                                <p class="text-muted mt-2 mb-0">
                                    Active Status -
                                <asp:Label runat="server" ID="Active_Status" CssClass="badge bg-success" Text="Active"></asp:Label>
                                </p>
                            </div>

                            <div class="card-header bg-white border-0 pt-3">
                                <h3 class="text-center" style="color: #2b4d6e;">User Profile</h3>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <hr>
                                </div>
                            </div>

                            <div class="input-group mb-3">
                                <label for="id" class="form-label">ID/Passport Number:&nbsp;&nbsp</label>
                                <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Search customers using ID..."></asp:TextBox>
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
                                        <asp:ListItem Text="Active" Value="Active" />
                                        <asp:ListItem Text="Inactive" Value="Inactive" />
                                    </asp:DropDownList>
                                </div>
                            </div>


                            <div class="row">

                                <div class="col-md-6 mb-3">
                                    <label for="password" class="form-label">Old Password</label>
                                    <asp:TextBox class="form-control form-control-lg" ID="password" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>



                                <div class="col-md-6 mb-3">
                                    <label for="password" class="form-label">New Password</label>
                                    <asp:TextBox runat="server" ID="NewPassword" TextMode="Password" CssClass="form-control form-control-lg" />
                                </div>


                            </div>

                            <div class="text-center mt-4">
                                <asp:Button
                                    runat="server"
                                    ID="Button_Update_Profile"
                                    Text="Update Profile"
                                    CssClass="btn btn-primary px-5"
                                    Style="background-color: #b0c4de; border-color: #b0c4de; color: #2b4d6e;" OnClick="Button_Update_Profile_Click" />
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>



</asp:Content>
