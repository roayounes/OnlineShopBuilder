<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="true" CodeFile="CompleteTemplate.aspx.cs" Inherits="CompleteTemplate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:Image ID="Image1"
runat="server"
AlternateText="Steps"
ImageUrl="Step2.jpg"/>
 <div style="width:100%;"> 
 
<h1> &nbsp; Choose the 3 Cover Photos for Your Template:</h1>
<div style="float:left; width:65%;">
 <div style="width:100%;"> 
<div style="float:left; width:10%;">
</div>
<div style="float:right; width:90%; ">
<div ID="FormatError" class="alert alert-danger" visible="false" runat="server">One or more of photos has invalide formate!</div>
<h2> First Photo:</h2>
    <asp:FileUpload ID="Pic1" runat="server" />
<h2> Second Photo:</h2>
    <asp:FileUpload ID="Pic2" runat="server" />
<h2> Third Photo:</h2>
    <asp:FileUpload ID="Pic3" runat="server" />
    <h1></h1>
    <table class="table">
    <tr> <td align="center">
  <asp:Button ID="SubmitPix" runat="server" class="btn btn-primary btn-lg" Text="Submit" 
        onclick="SubmitPix_Click"   /> </td>
        </tr>
        </table>
</div> 
</div>

</div>
<div style="float:right; width:35%; ">
<asp:Image ID="Image2"
runat="server"
AlternateText="Steps"
ImageUrl="paint-splash.jpg" Height="376px" Width="340px"/>
</div> 
</div>
</asp:Content>

