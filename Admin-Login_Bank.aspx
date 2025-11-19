<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Admin-Login_Bank.aspx.cs" Inherits="Banking_WEB.Admin_Bank" %>
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


                    <img src="img/Adim_img.png" class="card-img h-100 blurred-dark-blue" alt="Banking Image">


                    <div class="card-img-overlay d-flex justify-content-end align-items-end p-5">
                        <div class="text-end">
                            <h5 class="overlay-text">Authorized <b>Personnel Only</b> </h5>

                        </div>
                    </div>

                </div>
            </div>



            <div class="col-md-6 d-flex flex-column align-items-center justify-content-center bg-light pt-5 mt-4">


                <div class="mb-3 text-center">
                    <img src="img/Logo_TrustedWealth_Incoparations.png" alt="TrustedWealth Logo"
                        class="rounded-circle me-2"
                        style="width: 75px; height: 75px; object-fit: cover;" /><br>
                    <h1 class="fw-bold text-primary fs-4">Admin Login</h1>
                </div>

                <div class="card w-75">
                    <div class="card-body px-4 pt-2">


                        <div class="mb-3">
                            <label for="id" class="form-label">ID Number</label>
                           <asp:TextBox ID="Admin_ID" runat="server" CssClass="form-control form-control-lg" />
                        </div>
                        <div class="mb-4">
                            <label for="password" class="form-label">Password</label>
                        <asp:TextBox ID="Admin_Password" runat="server" CssClass="form-control form-control-lg" TextMode="Password" />
                        </div>
                        <div class="d-grid mb-3">
                               <asp:Button
                                ID="Button_Admin"
                                runat="server"
                                CssClass="btn btn-primary btn-lg"
                                Text="LOGIN"
                                OnClick="Button_Sign_In_Click" />
                        </div>
                        
                    </div>
                    </div>
                </div>
            </div>
          </div>


</asp:Content>
