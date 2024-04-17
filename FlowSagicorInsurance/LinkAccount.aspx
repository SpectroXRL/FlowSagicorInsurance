<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LinkAccount.aspx.cs" Inherits="FlowSagicorInsurance.LinkAccount" Async="true" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Text="Flow" Value="Flow"></asp:ListItem>
            <asp:ListItem Text="Sagicor" Value="Sagicor"></asp:ListItem>
        </asp:DropDownList>

        <label for="txtAccountID">Enter Account ID:</label>
        <asp:TextBox ID="txtAccountID" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnLinkAccount" runat="server" Text="Link Account" OnClick="btnLinkAccount_Click" />
        <br />
        <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>

