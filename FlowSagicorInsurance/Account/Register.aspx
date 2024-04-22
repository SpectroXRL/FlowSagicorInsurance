<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="FlowSagicorInsurance.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %></h2>
        <p class="text-danger">
            <asp:Literal runat="server" ID="ErrorMessage" />
        </p>
        <p class="text-center text-muted">Create a new account</p>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="row justify-content-center">
            <div class="offset-md-3 col-md-6">
                <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-4 col-form-label text-right"></asp:Label>
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" Placeholder="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row justify-content-center">
            <div class="offset-md-3 col-md-6">
                <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-4 col-form-label text-right"></asp:Label>
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" Placeholder="Password" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger"  Display="Dynamic" ErrorMessage="The password field is required." />
            </div>
        </div>
        <div class="row justify-content-center">
            <div class="offset-md-3 col-md-6">
                <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-4 col-form-label text-right"></asp:Label>
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control mb-3" Placeholder="Confirm Password" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
            </div>
        </div>
        <div class="row justify-content-center">
            <div class="offset-md-3 col-md-6">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-outline-dark" Style="width: 67%;" />
            </div>
        </div>
    </main>
</asp:Content>

