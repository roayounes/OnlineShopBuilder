<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="true" CodeFile="Create_Comp_Step3.aspx.cs" Inherits="Create_Comp_Step3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:Image ID="Image1"
runat="server"
AlternateText="Steps"
ImageUrl="Step3.jpg" Visible="false" />
<br />
<h1> &nbsp;&nbsp; Add Products:</h1>
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
 <h3> Key Words:</h3>
 <h5><small>They should be seperated by a ","</small></h5>
 <h6><br /></h6>
 <h3> Product Image:</h3>
</div> 
</div>
</div>
<div style="float:right; width:55%; ">
<div style="width:100%;"> 

<div style="float:left; width:70%;">
<h1> <asp:TextBox ID="ProdName" AutoComplete="off" class="form-control" runat="server"></asp:TextBox></h1>
<h5><div class="input-group">
  <asp:TextBox ID="ProdPrice" AutoComplete="off" class="form-control" runat="server"></asp:TextBox>
  <span class="input-group-addon">$</span>
</div> 
</h5>
<h5> <asp:TextBox ID="QtAvailable" AutoComplete="off" class="form-control" runat="server"></asp:TextBox></h5>
<h5> <asp:TextBox ID="MinStock" AutoComplete="off" class="form-control" runat="server"></asp:TextBox></h5>
<h5> <asp:TextBox ID="MaxStock" AutoComplete="off" class="form-control" runat="server" ></asp:TextBox></h5>
<h5> <asp:TextBox ID="ProdDesc" AutoComplete="off" class="form-control" runat="server" TextMode="multiline"></asp:TextBox></h5>
<h5> <asp:TextBox ID="KeyWords" AutoComplete="off" class="form-control" runat="server" TextMode="multiline"></asp:TextBox></h5>

<h5><br />
    <asp:FileUpload ID="ProdImg" runat="server" /></h5>
<div style="width:100%;"> 

<div style="float:left; width:30%;">

</div>
<div style="float:right; width:70%; ">
<div style="width:100%;"> 

<div style="float:left; width:30%;">
<ul class="pager">
  <li class="next"><a runat="server" onserverclick="Add_More" href="#">Add More Products  &rarr;</a>
  </li>
</ul>
</div>
<div style="float:right; width:70%; ">
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   or&nbsp;&nbsp;&nbsp; 
    <asp:Button ID="AddProd" runat="server" 
        class="btn btn-primary" Text="Submit" onclick="AddProd_Click"   />
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

