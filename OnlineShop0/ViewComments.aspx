<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="true" CodeFile="ViewComments.aspx.cs" Inherits="ViewComments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
<div class="col-lg-12">
<div class="panel panel-info">
<div class="panel-heading">
                <h3 class="panel-title">Comments...</h3>
              </div>
              <div class="panel-body">
                  <asp:Label ID="Comments" runat="server" Text="There is No Comments.."></asp:Label>
              </div>
</div>
</div>
</asp:Content>

