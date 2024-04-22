<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TransactionHistory.aspx.cs" Inherits="FlowSagicorInsurance.TransactionHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 id="title">Your Transaction History</h2>
    <p class="lead">Here you can view your history of transactions made using this account.</p>
    
    <asp:GridView ID="TransactionHistoryGrid" runat="server" AutoGenerateColumns="False" CssClass="table" EmptyDataText="You have no transactions.">
        <Columns>
            <asp:BoundField DataField="AccountID" HeaderText="Account Number" />
            <asp:BoundField DataField="Payment" HeaderText="Amount" />
            <asp:BoundField DataField="FlowID" HeaderText="Flow Account" />
            <asp:BoundField DataField="SagicorID" HeaderText="Sagicor Account" />
        </Columns>
    </asp:GridView>
</asp:Content>
