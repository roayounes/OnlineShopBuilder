<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="true" CodeFile="ViewClients.aspx.cs" Inherits="ViewClients" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
<div class="col-lg-12">
<div class="panel panel-warning">
<div class="panel-heading">
                <h2 class="panel-title">All Clients:</h2>
              </div>
              <div class="panel-body">
    <asp:Label ID="ClientTable" runat="server" Text="Label"></asp:Label>
    </div>
    </div>
    </div>

</asp:Content>
