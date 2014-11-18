<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="true" CodeFile="LaunchStore.aspx.cs" Inherits="LaunchStore" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:Image ID="Image2"
runat="server"
AlternateText="Steps"
ImageUrl="Step4.jpg"/>
<br />
<h1> &nbsp; Your Online Store is ready..</h1>
<div style="width:100%;"> 
<div style="float:left; width:25%;">
</div>
<div style="float:right; width:75%;">
<asp:Image ID="Image1"
runat="server"
AlternateText="Now Open"
ImageUrl="open-sign.jpg" Height="358px" Width="462px"/>
</div>
</div>
<br />
<br />
<div style="width:100%;"> 
<div style="float:left; width:35%;">
</div>
<div style="float:right; width:65%;">
<div style="width:100%;"> 
<div style="float:left; width:40%;">

<asp:Button ID="ViewWebsite" runat="server" Text="View Website" 
        class="btn btn-success btn-lg btn-block" onclick="ViewWebsite_Click"/>
</div>
<div style="float:right; width:60%;">
</div>
</div>
</div>
</asp:Content>

