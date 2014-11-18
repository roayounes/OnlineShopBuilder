<%@ Page Title="" Language="C#" MasterPageFile="~/TemplateFree.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1>Contact:</h1>
<ul class="list-inline">

<li>Email:</li>
<li> 
    <asp:Label ID="Email" runat="server" Text="Label"></asp:Label></li>
</ul>
<ul class="list-inline">
<li>Phone Number</li>
<li> 
    <asp:Label ID="Phone" runat="server" Text="Label"></asp:Label></li>
</ul>
<br />
<h2>Send a Message:</h2>
    <asp:TextBox ID="Msg" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
    <asp:Button ID="SendMsg" runat="server" Text="Send" class="btn btn-default" 
        onclick="SendMsg_Click"/>
    <asp:Label ID="error" runat="server" Text="Please Sign in first" Visible="false"></asp:Label>
</asp:Content>

