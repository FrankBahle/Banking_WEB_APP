<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Sign_In_Bank.aspx.cs" Inherits="Banking_WEB.Sign_Up_Bank" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="row vh-100">

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

            <div class="col-md-6 p-0">
                <div class="card text-bg-dark h-100 position-relative overflow-hidden">
                    <img src="img/Register_Detials_Image.jpg" class="card-img h-100 blurred-dark-blue" alt="Banking Image" />
                    <div class="card-img-overlay d-flex justify-content-end align-items-end p-5">
                        <div class="text-end">
                            <h5 class="overlay-text">Welcome back to <b>TrustedWealth</b>
                                <br />
                                — sign in to continue
                                <br />
                                your journey.</h5>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-6 d-flex flex-column align-items-center justify-content-center bg-light pt-5 mt-4">
                <div class="mb-3 text-center">
                    <img src="img/Logo_TrustedWealth_Incoparations.png" alt="TrustedWealth Logo"
                        class="rounded-circle me-2"
                        style="width: 75px; height: 75px; object-fit: cover;" /><br />
                    <h1 class="fw-bold text-primary fs-4">TrustedWealth Incorporations</h1>
                </div>

                <div class="card w-75">
                    <div class="card-body px-4 pt-2">

                        <div class="mb-3">
                            <asp:Label ID="Label_IDNumber" runat="server" CssClass="form-label" AssociatedControlID="TextBox_IDNumber" Text="ID Number"></asp:Label>
                            <asp:TextBox ID="TextBox_IDNumber" runat="server" CssClass="form-control form-control-lg" placeholder="Enter your ID Number"></asp:TextBox>
                        </div>

                        <div class="mb-4">
                            <asp:Label ID="Label_Password" runat="server" CssClass="form-label" AssociatedControlID="TextBox_Password" Text="Password"></asp:Label>
                            <asp:TextBox ID="TextBox_Password" runat="server" CssClass="form-control form-control-lg" TextMode="Password" placeholder="Enter your password"></asp:TextBox>
                        </div>

                        <div class="d-grid mb-3">
                            <asp:Button
                                ID="Button_Sign_In"
                                runat="server"
                                CssClass="btn btn-primary btn-lg"
                                Text="LOGIN"
                                OnClick="Button_Sign_In_Click" />
                        </div>

                        <div class="text-center">
                            <p class="mb-0">
                                Don't have an account?
                                <a href="Registration_Bank.aspx" class="text-decoration-none">Register here</a>
                            </p>
                        </div>

                    </div>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
