<%@ Page Title="" Language="C#" MasterPageFile="~/TemplateFree.master" AutoEventWireup="true" CodeFile="TemplateFreeMyCart.aspx.cs" Inherits="Products_Photos_TemplateFreeMyCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1> Your Cart :</h1>
<table class="table" runat="server" id="carttotal" visible="false">
<tr><td>
    <h3>Total Price :</h></td>
    <td><h2><asp:Label ID="TotalPrice" runat="server" Text="Label"></asp:Label></h2></td>
    <td><br />
        <asp:Button ID="BuyAllCart" class="btn btn-primary btn-lg" runat="server" 
            Text="Buy All Products in The Cart" onclick="BuyAllCart_Click" /> </td>
    </tr>
</table>
    <asp:Label ID="YourCart" runat="server" Text="No Products was added to cart!!"></asp:Label>
</asp:Content>

