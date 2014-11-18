<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="true" CodeFile="ProductsAdmin.aspx.cs" Inherits="Products_Photos_ProductsAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
<div class="col-lg-12">
<div class="panel panel-info">
<div class="panel-heading">
                <h3 class="panel-title">Your Products</h3>
              </div>
              <div class="panel-body">
                  <asp:Button ID="AddMore" runat="server" Text="Add More Products" 
                      class="btn btn-default btn-lg btn-block" onclick="AddMore_Click" />
                  <br />
                  <asp:Label ID="Products" runat="server" Text="There is No Products.."></asp:Label>
              </div>
</div>
</div>
</asp:Content>

