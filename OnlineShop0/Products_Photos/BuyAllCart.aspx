<%@ Page Title="" Language="C#" MasterPageFile="~/TemplateFree.master" AutoEventWireup="true" CodeFile="BuyAllCart.aspx.cs" Inherits="BuyAllCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="alert alert-danger" runat="server" id="RougeAlert" visible="false">.</div>
<div class="alert alert-info" runat="server" id="BleuAlert" visible="false">.</div>
<div class="panel panel-default">
  <div class="panel-heading">
    <h3 id="ProdName" class="panel-title" runat="server">Buy All Products In Your Cart</h3>
  </div>
  <div class="panel-body">
  <table class="table">
  <tr>
    <td>
      <asp:Label ID="YourCart" runat="server" Text="Label"></asp:Label>
    </td>
    <td>
    <h3>Please Specify Payment Method:</h3>
    <h2 class="text-primary" style="float: right; width:100px">  <asp:Label ID="TotPrice" runat="server" Text="Label"></asp:Label></h2> <br />
        <h4>Total Price:</h4>
    <table class="table">
<tr><td align="center"> <asp:Image ID="wu" runat="server" Width="150px" ImageUrl="~/westernunion.jpg" /></td>
 <td align="center"> <asp:Image ID="Image1" runat="server" Width="150px" ImageUrl="~/paypal.jpg" /></td>
</tr>
    </table>
        <asp:Button ID="BuyProds" runat="server" Text="Buy All Products" 
            class="btn btn-primary btn-lg btn-block" onclick="BuyProds_Click"/>
    </td>
  </tr>
  </table>
  </div>
  </div>
</asp:Content>

