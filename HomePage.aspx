<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Banking_WEB.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<section>
<div class="card text-bg-dark card-fullscreen">
    <img src="img/Home_Img.jpg" class="card-img" alt="Home Background">
    <div class="card-img-overlay">
        <div class="container content-container">
            <div class="row w-100">
             
                <div class="col-md-6 d-flex flex-column justify-content-center align-items-start pe-md-5">
                    <h5 class="card-title display-4">Welcome to <b> TrustedWealth </b></h5>
                    <p class="card-text lead">Secure, smart banking designed around your success.</p>
                </div>

        
                <div class="col-md-1 d-none d-md-flex justify-content-center">
                    <div class="vertical-line"></div>
                </div>

               
                <div class="col-md-5 d-flex flex-column justify-content-center align-items-start ps-md-5">
                    <p class="text-warning sizep">Create your account and start your journey to secure banking.</p>
                    <asp:LinkButton ID="LinkButtonRegister" runat="server" CssClass="btn btn-outline-light mt-2 center-button" OnClick="LinkButton1_Click" >
                        Create Account
                    </asp:LinkButton>

                    <asp:LinkButton ID="LinkButtonSignUp" runat="server" CssClass="btn btn-outline-light mt-2 center-button" OnClick="LinkButton2_Click" >
                        Sign In
                    </asp:LinkButton>

                </div>
            </div>
        </div>
    </div>
</div>
 </section>




<!-- About Us Section for TrustedWealth Incorporations -->
<section class="py-5 bg-light" style="background-color: #e6f0fa;" id="About">
  <div class="container-fluid">
    <div class="row">

      <!-- Left Side: Image with inspirational text overlay -->
      <div class="col-md-6 p-0">
        <div class="card text-bg-dark h-100 position-relative overflow-hidden border-0 shadow-none">
          <img src="img/About2.jpg" class="card-img h-100" style="filter: blur(3px) brightness(0.6); object-fit: cover;" alt="About TrustedWealth">
          <div class="card-img-overlay d-flex justify-content-end align-items-end p-5">
            <div class="text-end">
              <h5 class="overlay-text text-light fw-bold" style="color: #b0c4de; font-size: 3rem; text-shadow: 1px 1px 2px rgba(0,0,0,0.6); font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;">
                Empowering <br> Generations.<br>
                Building <br> Financial Futures.<br>
                Trusted. Secure. <br>Innovative.
              </h5>
            </div>
          </div>
        </div>  
      </div>

      <!-- Right Side: About content with timeline -->
      <div class="col-md-6 p-5">
        <h2 class="mb-4 text-primary fw-bold" style="color: #2b4d6e; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;">About TrustedWealth</h2>

        <p class="text-secondary" style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;">
          <strong>TrustedWealth Incorporations</strong> is a modern banking institution built on the principles of trust, transparency, and financial empowerment. Since our inception, we’ve aimed to redefine what it means to bank with confidence — blending cutting-edge digital technology with personalised service. Headquartered in the heart of the financial district, we serve a growing community of individuals, entrepreneurs, and organisations across the country.
        </p>
        <p class="text-secondary" style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;">
          We offer a wide range of financial services, including personal banking, high-interest savings accounts, business lending, investment advisory, and digital wallet integration. Whether you're looking to secure your first loan, grow your savings, or scale your startup, our dedicated advisors and innovative tools are here to guide you every step of the way. Our secure online platform gives you 24/7 access to your finances, supported by a responsive customer care team.
        </p>
        <p class="text-secondary" style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;">
          At TrustedWealth, we understand that banking is more than transactions — it’s about building futures. That’s why we invest in community programs, financial literacy workshops, and sustainable initiatives that reflect our core values. We're not just a place to store money; we're a partner in your long-term success.
        </p>
        <p class="text-secondary" style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;">
          Looking forward, our aspirations include expanding into global digital banking markets, introducing AI-powered financial planning tools, and becoming a leading voice in ethical fintech. We envision a world where everyone — regardless of background — has access to reliable, intelligent, and empowering financial services.
        </p>

        <div class="timeline position-relative ps-4 border-start border-3" style="border-color: rgba(43, 77, 110, 0.3);">
          <div class="mb-4 ms-3">
            <h5 class="fw-semibold" style="color: #2b4d6e; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;">2015 – Foundation</h5>
            <p class="text-secondary" style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;">Started as a small advisory firm dedicated to ethical financial guidance for low-income communities.</p>
          </div>
          <div class="mb-4 ms-3">
            <h5 class="fw-semibold" style="color: #2b4d6e; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;">2018 – Expansion</h5>
            <p class="text-secondary" style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;">Launched personal banking services with digital-first accounts and user-friendly mobile platforms.</p>
          </div>
          <div class="mb-4 ms-3">
            <h5 class="fw-semibold" style="color: #2b4d6e; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;">2021 – Business Solutions</h5>
            <p class="text-secondary" style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;">Expanded services to SMEs with tailored loans, merchant solutions, and investment services.</p>
          </div>
          <div class="mb-4 ms-3">
            <h5 class="fw-semibold" style="color: #2b4d6e; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;">2024 and Beyond</h5>
            <p class="text-secondary" style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;">Driving toward a global presence through ethical fintech, AI-powered planning, and green banking innovation.</p>
          </div>
        </div>

        <p class="text-secondary mt-4" style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;">
          Today, TrustedWealth stands as a beacon of financial empowerment. We are proud to offer a wide range of services — from personal accounts and savings to business funding, investment strategy, and digital banking tools — all crafted with care and cutting-edge tech.
        </p>

        <a href="#Contact" class="btn btn-outline-primary mt-3" style="background-color: #b3cde0; color: #2b4d6e; border-color: #b3cde0; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;">
          Get in Touch
        </a>
      </div>

    </div>
  </div>
</section>



</asp:Content>
