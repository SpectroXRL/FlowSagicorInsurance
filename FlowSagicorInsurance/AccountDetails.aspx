<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AccountDetails.aspx.cs" Inherits="FlowSagicorInsurance.AccountDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<main aria-labelledby="title">
        <h2 id="title">Your Account Details</h2>
        <p class="lead">Here you can view your existing accounts and their current balances.</p>
        
        <asp:GridView ID="AccountDetailsGrid" runat="server" AutoGenerateColumns="False" CssClass="table">
            <Columns>
                <asp:BoundField DataField="AccountNumber" HeaderText="Account Number" />
                <asp:BoundField DataField="AccountType" HeaderText="Account Type" />
                <asp:BoundField DataField="Balance" HeaderText="Current Balance" />
            </Columns>
        </asp:GridView>
    </main>
</asp:Content>
