<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="true" CodeFile="Settings.aspx.cs" Inherits="Settings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
<div class="col-lg-12">
<div class="panel panel-default">
<div class="panel-heading">
                <h3 class="panel-title">Settings...</h3>
              </div>
              <div class="panel-body">
                  <div style="width:100%;"> 

<div style="float:left; width:50%;">
<table>
<tr><td><h4><b>Store Name:</b></h4></td><td><asp:Label ID="sn" runat="server" Text="Store Name"></asp:Label> </td></tr>
<tr><td><h4><b>Email:</b></h4></td><td><asp:Label ID="Email" runat="server" Text="Email"></asp:Label> </td></tr>
<tr><td><h4><b>Password:</b></h4></td><td><asp:Label ID="pass" runat="server" Text="*****"></asp:Label> </td></tr>
<tr><td><h4><b>Store Phone Number:</b></h4></td><td><asp:Label ID="sp" runat="server" Text="Store Phone Number"></asp:Label> </td></tr>
<tr><td><h4><b>Store Description:</b></h4></td><td><asp:Label ID="sd" runat="server" Text="Store desc"></asp:Label> </td></tr>
</table>
</div>
<div style="float:right; width:50%; ">
<table>
<tr><td><h4><b>Manager Name:</b></h4></td><td><asp:Label ID="mn" runat="server" Text="Manager Name"></asp:Label> </td></tr>
<tr><td><h4><b>Manager Phone Number:</b></h4></td><td><asp:Label ID="mp" runat="server" Text="Manager Phone Number"></asp:Label> </td></tr>
<tr><td><h4><b>Country:</b></h4></td><td><asp:Label ID="sc" runat="server" Text="Country"></asp:Label> </td></tr>
<tr><td><h4><b>Website:</b></h4></td><td><asp:Label ID="sw" runat="server" Text="www"></asp:Label> </td></tr>
<tr><td><h4><b>Facebook Page:</b></h4></td><td><asp:Label ID="fp" runat="server" Text="Facebook Page"></asp:Label> </td></tr>
</table>
</div>
</div>
<br />
<button type="button" class="btn btn-default btn-lg btn-block">Update Info</button>
              </div>
</div>
</div>
</asp:Content>

