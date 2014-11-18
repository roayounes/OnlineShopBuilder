<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="true" CodeFile="Create_Comp_Step4.aspx.cs" Inherits="Create_Comp_Step4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:Image ID="Image1"
runat="server"
AlternateText="Steps"
ImageUrl="Step4.jpg"/>
<h1> &nbsp;&nbsp; Pick a Plan for your Store:</h1>
<div style="width:100%;"> 
<div style="float:left; width:55%;">
  <div class="row">
  <div style="width:100%;"> 
<div style="float:left; width:30%;">
</div>
<div style="float:right; width:70%; ">
          <div class="col-lg-4">
            <div id="panel1" class="panel panel-primary" runat="server">
              <div class="panel-heading">
                <h3 class="panel-title">Plan 1</h3>
              </div>
              <div class="panel-body">
                <asp:Image ID="Image3" runat="server" AlternateText="Plan 1" ImageUrl="Plan1.jpg" 
                      Height="150px" Width="96px"/>
                      <h1></h1>
                   </div>
                   <asp:Button ID="Temp1" runat="server" Text="Choose" 
                    class="btn btn-primary btn-lg btn-block"  />
            </div>
          </div>
            <div class="col-lg-4">
            <div id="panel2" class="panel panel-primary" runat="server">
              <div class="panel-heading">
                <h3 class="panel-title">Plan 2</h3>
              </div>
              <div class="panel-body">
                <asp:Image ID="Image4" runat="server" AlternateText="Plan 2" ImageUrl="Plan2.jpg" 
                      Height="150px" Width="96px"/>
                      <h1></h1>
       
              </div>
              <asp:Button ID="Temp2" runat="server" Text="Choose" 
                    class="btn btn-primary btn-lg btn-block" />
            </div>
            <br />
            <br />
          </div>
           
          
        </div>

</div>
</div>

            <asp:Button ID="Submit0" runat="server" Text="Submit" 
                    class="btn btn-primary btn-lg btn-block" 
        onclick="Submit0_Click" />
</div>

<div style="float:right; width:45%; ">
<asp:Image ID="Image2"
runat="server"
AlternateText="Steps"
ImageUrl="Website-Launch.jpg"/>
</div> 
</div> 
</asp:Content>

