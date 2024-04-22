<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LinkAccount.aspx.cs" Inherits="FlowSagicorInsurance.LinkAccount" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title">Link Your Account</h2>
        <p class="text-center text-muted">Enter your account details below to link your FLOW or SAGICOR LIFE account to your online banking profile.</p>
        <hr />
        <div class="row justify-content-center">
            <div class="offset-md-3 col-md-6">
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control mb-4 mt-4" Style="width: 67%;" ForeColor="Gray">
                    <asp:ListItem Text="Select Service" Value=""></asp:ListItem>
                    <asp:ListItem Text="Flow" Value="Flow"></asp:ListItem>
                    <asp:ListItem Text="Sagicor" Value="Sagicor"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <div class="row justify-content-center">
            <div class="offset-md-3 col-md-6">
                <asp:TextBox ID="txtAccountID" runat="server" CssClass="form-control mb-4" Placeholder="Enter Account ID" />
            </div>
        </div>
        <div class="row justify-content-center">
            <div class="offset-md-3 col-md-6">
                <asp:Button ID="btnLinkAccount" runat="server" Text="Link Account" OnClick="btnLinkAccount_Click" CssClass="btn btn-primary btn-link-account" Style="width: 67%;" />
            </div>
        </div>
        <br />
        <div class="row justify-content-center">
            <div class="offset-md-3 col-md-6">
                <asp:Label ID="lblResult" runat="server" Text="" CssClass="alert alert-info" Visible="false"></asp:Label>
            </div>
        </div>
    </main>
</asp:Content>




