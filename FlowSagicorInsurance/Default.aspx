<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FlowSagicorInsurance._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
       <section class="hero-section">
           <div class="row">
               <div class="text-center">
                   <h1>Welcome to NCB Online Bill Payment</h1>
                   <p class="lead">Manage your FLOW/SAGICOR LIFE accounts and make payments easily.</p>
               </div>
               <div class="col-12">
                   <img src="Images/ncb.jpeg" alt="Online Bill Payment" class="img-fluid mb-5 d-block mx-auto" style="width:750px; height:600px;">
               </div>
           </div>
        </section>
        <section class="features-section">
            <div class="container">
                <div class="row">
                    <div class="col-md-4">
                        <div class="feature">
                            <i class="fas fa-wallet"></i>
                            <h3>Convenient Payments</h3>
                            <p>Make payments to your FLOW or SAGICOR LIFE accounts hassle-free from anywhere.</p>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="feature">
                            <i class="fas fa-shield-alt"></i>
                            <h3>Secure Transactions</h3>
                            <p>Rest assured knowing that your transactions are encrypted and secure.</p>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="feature">
                            <i class="fas fa-clock"></i>
                            <h3>24/7 Access</h3>
                            <p>Access your accounts and make payments anytime, anywhere, at your convenience.</p>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </main>
</asp:Content>
