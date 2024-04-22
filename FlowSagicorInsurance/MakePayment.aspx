<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MakePayment.aspx.cs" Inherits="FlowSagicorInsurance.MakePayment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div>
     <asp:DropDownList ID="DropDownList1" runat="server">
         <asp:ListItem Text="Flow" Value="Flow"></asp:ListItem>
         <asp:ListItem Text="Sagicor" Value="Sagicor"></asp:ListItem>
     </asp:DropDownList>
     <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="Go" OnClick="Button1_Click"/>
     <br />
     <label for="DropDownList2">Select Account ID:</label>
     <asp:DropDownList ID="DropDownList2" runat="server">
     </asp:DropDownList>
     <br />
     <label for="txtPayment">Enter Amount:</label>
     <asp:TextBox ID="txtPayment" runat="server"></asp:TextBox>
     <br />
     <asp:Button ID="btnPaymentAccount" runat="server" Text="Make Payment" OnClick="btnPaymentAccount_Click"/>
     <br />
     <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
 </div>
</asp:Content>
