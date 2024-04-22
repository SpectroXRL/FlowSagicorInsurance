<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FlowSagicorInsurance.Account.Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %></h2>
        <p class="text-muted text-center">Use a local account to log in</p>
        <hr />
        <div class="row justify-content-center">
            <div class="offset-md-3 col-md-6">
                <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                    <p class="text-danger">
                        <asp:Literal runat="server" ID="FailureText" />
                    </p>
                </asp:PlaceHolder>
                <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-4 col-form-label text-right"></asp:Label>
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" Placeholder="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="The email field is required." />
                <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-4 col-form-label text-right"></asp:Label>
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" Placeholder="Password" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
                <div class="checkbox">
                    <asp:CheckBox runat="server" ID="RememberMe" />
                    <asp:Label runat="server" CssClass="text-muted" AssociatedControlID="RememberMe">Remember me?</asp:Label>
                </div>
                <asp:Button runat="server" OnClick="LogIn" Text="Log in" CssClass="btn btn-outline-dark mb-3 mt-3" Style="width: 67%;" />
                <p>
                    <asp:HyperLink runat="server" ID="RegisterHyperLink" CssClass="text-muted" ViewStateMode="Disabled">Register as a new user</asp:HyperLink>
                </p>

            </div>

            <!-- <section id="socialLoginForm">
    <uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" />
</section> -->
        </div>
    </main>
</asp:Content>
