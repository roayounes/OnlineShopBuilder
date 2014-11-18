<%@ Page Title="" Language="C#" MasterPageFile="~/TemplateFree.master" AutoEventWireup="true" CodeFile="SearchResult.aspx.cs" Inherits="SearchResult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<ul class="list-inline">
  <li><h1>You Searched For:</h1></li>
  <li><h2 class="text-primary"><asp:Label ID="SearchWords" runat="server" Text="Label"></asp:Label></h2></li>
</ul> 
    <br />
    <asp:Label ID="SearchResults" runat="server" Text="Label"></asp:Label>
</asp:Content>

