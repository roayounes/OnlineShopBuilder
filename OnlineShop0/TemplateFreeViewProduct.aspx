<%@ Page Title="" Language="C#" MasterPageFile="~/TemplateFree.master" AutoEventWireup="true" CodeFile="TemplateFreeViewProduct.aspx.cs" Inherits="TemplateFreeViewProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 412px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="alert alert-danger" runat="server" id="psi" visible="false">Please Sign in First!</div>
<div class="alert alert-info" runat="server" id="atcs" visible="false">Your Product Was Successfully Added To Cart</div>
<div class="panel panel-default">
  <div class="panel-heading">
    <h3 id="ProdName" class="panel-title" runat="server">Panel title</h3>
  </div>
  <div class="panel-body">
       <table class="table">
    <tr><td>
    <asp:Image ID="ImgProd" runat="server" Width="500px" /></td>
    <td>
    <h3><asp:Label ID="ProdPrice" runat="server" Text="Price"></asp:Label></h3>
    <h6><br /></h6>
    <h4><asp:Label ID="Desc" runat="server" Text="Description"></asp:Label></h4>
    <h6><br /></h6>
    <asp:Label ID="qt" runat="server" Text="Quantity Available"></asp:Label>
    <t6><br /></t6>
    <asp:Label ID="ProdDate" runat="server" Text="Date"></asp:Label>
    </td></tr></table>
<div runat="server" id="BP" visible="false">
<h4>Please Choose Your Payment Method:</h4>
<table class="table" width="20%">
<tr><td align="center"> <asp:Image ID="wu" runat="server" Width="200px" ImageUrl="~/westernunion.jpg" /></td>
 <td align="center"> <asp:Image ID="Image1" runat="server" Width="200px" ImageUrl="~/paypal.jpg" /></td>
</tr>
    </table>
</div>


<div runat="server" id="ac" visible="false">
<table class="table" width="20%">
<tr><td class="style1"><h4>Please specify Quantity:</h4>
<asp:TextBox ID="qtp" runat="server" class="form-control"></asp:TextBox></td>
 <td> <br /> <br />  <asp:Button ID="atc" runat="server" Text="Submit" 
         class="btn btn-primary" onclick="atc_Click" /></td>
         <td></td><td><br /><br />
    <asp:Button ID="BuyProds" runat="server" Text="Submit" 
         class="btn btn-primary btn-lg" Visible="false" onclick="BuyProds_Click" /></td>
</tr></table></div>
<div style="width:100%;"> 
<div style="float:left; width:33%;">
</div>
<div style="float:right; width:67%; ">
        <button type="button" id="BuyProd" runat="server" onserverclick="Buy_Prod" class="btn btn-info btn-lg">
  <span class="glyphicon glyphicon-tag"></span> Buy Product
</button>
    <button type="button" id="addCart" runat="server" onserverclick="AddTocart" class="btn btn-default btn-lg">
  <span class="glyphicon glyphicon-shopping-cart"></span> Add To Cart
</button>
    
    </div>
    </div>
  </div>
</div>
    <div class="panel panel-default">
  <div class="panel-heading">
    <h3 id="H1" class="panel-title" runat="server">Add a comment...</h3>
  </div>
    <div class="panel-body">
  <div style="width:100%;"> 
<div style="float:left; width:85%;">
    <asp:TextBox ID="AddComText" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
</div>
<div style="float:right; width:15%; ">

&nbsp;&nbsp;<button type="button" runat="server" onserverclick="addComment" class="btn btn-default btn-lg">Add</button>
  </div>
  </div>
  </div>
  </div>
    <asp:Label ID="Comments" runat="server" Text="Label"></asp:Label>
  

</asp:Content>

