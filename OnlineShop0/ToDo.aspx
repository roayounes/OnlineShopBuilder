<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="true" CodeFile="ToDo.aspx.cs" Inherits="ToDo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
<div class="col-lg-12">
<div class="panel panel-danger">
<div class="panel-heading">
                <h2 class="panel-title">To Do List:</h2>
              </div>
              <div class="panel-body">
              This is the list of products wich their quantity available is less then the qantity you have specified as minimum stock
    <br />
    <br />
    <br />
    <asp:Label ID="toDo" runat="server" Text="There is no items..."></asp:Label>
    </div>
    </div>
    </div>
</asp:Content>

