<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="true" CodeFile="UpdateProd.aspx.cs" Inherits="UpdateProd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
<h1> &nbsp;&nbsp; Update Product:</h1>
<div style="width:100%;"> 
<div style="float:left; width:70%;">
 <div style="width:100%;"> 
<div style="float:left; width:7%;">
</div>
<div style="float:right; width:93%; ">
<div style="width:100%;"> 
<div style="float:left; width:45%;">
 <div style="width:100%;"> 
<div style="float:left; width:30%;">
</div>
<div style="float:right; width:70%; ">

 <h3> Product Name:</h3>
 <h3> Product Price:</h3>
 <h3> Quantity Available:</h3>
 <h3> Minimum Stock:</h3>
 <h3> Maximum Stock:</h3>
 <h3> Description:</h3>
 <h6><br /></h6>
 <h3> Product Image:</h3>
</div> 
</div>
</div>
<div style="float:right; width:55%; ">
<div style="width:100%;"> 

<div style="float:left; width:70%;">
<h1> <asp:TextBox ID="ProdName" class="form-control" runat="server"></asp:TextBox></h1>
<h5><div class="input-group">
  <asp:TextBox ID="ProdPrice" class="form-control" runat="server"></asp:TextBox>
  <span class="input-group-addon">$</span>
</div> 
</h5>
<h5> <asp:TextBox ID="QtAvailable" class="form-control" runat="server"></asp:TextBox></h5>
<h5> <asp:TextBox ID="MinStock" class="form-control" runat="server"></asp:TextBox></h5>
<h5> <asp:TextBox ID="MaxStock" class="form-control" runat="server" ></asp:TextBox></h5>
<h5> <asp:TextBox ID="ProdDesc" class="form-control" runat="server" TextMode="multiline"></asp:TextBox></h5>
<h5><br /><br />
    <asp:FileUpload ID="ProdImg" runat="server" /></h5>
<div style="width:100%;"> 

<div style="float:left; width:30%;">

</div>
<div style="float:right; width:70%; ">
<br />
<div style="width:100%;"> 

<div style="float:left; width:30%;">

</div>
<div style="float:right; width:70%; ">
    <asp:Button ID="AddProd" runat="server" 
        class="btn btn-primary" Text="Update Product" onclick="UpdateProd_Click"   />
</div> 
</div>
    
</div> 
</div>

</div>

<div style="float:right; width:30%; ">

</div> 
</div>
</div> 
</div>
</div>
</div> 
</div>
</div>
<div style="float:right; width:30%; ">
<asp:Image ID="Image2"
runat="server"
AlternateText="Steps"
ImageUrl="Add_Prod.jpg"/>
</div> 
</asp:Content>

