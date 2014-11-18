<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="true" CodeFile="Create_Comp_Step1.aspx.cs" Inherits="Create_Comp_Step1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Image ID="Image1"
runat="server"
AlternateText="Steps"
ImageUrl="Step1.jpg"/>
 <div style="width:100%;"> 
<div style="float:left; width:60%;">
 <div style="width:100%;"> 
 <h1> &nbsp;&nbsp;&nbsp;Complete your Store Informations: </h1>
<div style="float:left; width:45%;">
 <div style="width:100%;"> 
<div style="float:left; width:30%;">
</div>
<div style="float:right; width:70%; ">

 <h3> Store Name:</h3>
 <h3> Manager Name:</h3>
 <h3> Manager Number:</h3>
 <h3> Facebook Page:</h3>
 <h3> Twitter Page:</h3>
 <h3> Other Website:</h3>
 <h3> Store Description:</h3>
</div> 
</div>
</div>
<div style="float:right; width:55%; ">
<div style="width:100%;"> 

<div style="float:left; width:70%;">
<h1> <asp:TextBox ID="StoreName" class="form-control" AutoComplete="off" runat="server"></asp:TextBox></h1>
<h5> <asp:TextBox ID="ManagerName" class="form-control" AutoComplete="off" runat="server"></asp:TextBox></h5>
<h5> <asp:TextBox ID="ManagerPhone" class="form-control" AutoComplete="off" runat="server"></asp:TextBox></h5>
<h5> <asp:TextBox ID="FbLlink" class="form-control" AutoComplete="off" runat="server"></asp:TextBox></h5>
<h5> <asp:TextBox ID="TwitterLink" class="form-control" AutoComplete="off" runat="server"></asp:TextBox></h5>
<h5> <asp:TextBox ID="WbLink" class="form-control" AutoComplete="off" runat="server"></asp:TextBox></h5>
<h5> <asp:TextBox ID="Desc" class="form-control" AutoComplete="off" runat="server" TextMode="multiline"></asp:TextBox></h5>
<div style="width:100%;"> 

<div style="float:left; width:72%;">

</div>
<div style="float:right; width:28%; ">
    <asp:Button ID="Button1" runat="server" class="btn btn-primary" Text="Submit" 
        onclick="Button1_Click" />
    <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
</div> 
</div>

</div>

<div style="float:right; width:30%; ">

</div> 
</div>
</div> 
</div>
</div>
<div style="float:right; width:40%; ">
<asp:Image ID="Image2"
runat="server"
AlternateText="Website Under Constraction"
ImageUrl="Website_under_construction.png"/>
</div> 
</div>
</asp:Content>

