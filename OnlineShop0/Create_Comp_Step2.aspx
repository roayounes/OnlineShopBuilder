<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="true" CodeFile="Create_Comp_Step2.aspx.cs" Inherits="Create_Comp_Step2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <asp:Image ID="Image2" runat="server" AlternateText="Steps" ImageUrl="Step2.jpg" Visible="false"/>
 <br />
 <h1>  
     Please Choose a Template:
    </h1>
  <div class="row">
          <div class="col-lg-4">
            <div id="panel1" class="panel panel-primary" runat="server">
              <div class="panel-heading">
                <h3 class="panel-title">Template 1</h3>
              </div>
              <div class="panel-body">
                <asp:Image ID="Image3" runat="server" AlternateText="Steps" ImageUrl="Temp1.jpg" 
                      Height="150px" Width="322px"/>
                      <h1></h1>
                      <div style="width:100%;"> 
<div style="float:left; width:36%;">
</div>
<div style="float:right; width:64%; ">
<asp:Button ID="ViewTemp1" runat="server" Text="View Demo" class="btn btn-success" />
</div> 
</div> 
                  
                   
                   </div>
                   <asp:Button ID="Temp1" runat="server" Text="Choose" 
                    class="btn btn-primary btn-lg btn-block" onclick="Temp1_Click" />
            </div>
          </div>
            <div class="col-lg-4">
            <div id="panel2" class="panel panel-primary" runat="server">
              <div class="panel-heading">
                <h3 class="panel-title">Template 2</h3>
              </div>
              <div class="panel-body">
                <asp:Image ID="Image4" runat="server" AlternateText="Steps" ImageUrl="Temp2.jpg" 
                      Height="150px" Width="322px"/>
                      <h1></h1>
                      <div style="width:100%;"> 
<div style="float:left; width:36%;">
</div>
<div style="float:right; width:64%; ">
<asp:Button ID="ViewTemp2" runat="server" Text="View Demo" class="btn btn-success" />
</div> 
</div> 
              </div>
              <asp:Button ID="Temp2" runat="server" Text="Choose" 
                    class="btn btn-primary btn-lg btn-block" onclick="Temp2_Click" />
            </div>
            <br />
            <br />
            <asp:Button ID="Submit0" runat="server" Text="Submit" 
                    class="btn btn-primary btn-lg btn-block" onclick="Submit0_Click" />
          </div>
            <div class="col-lg-4">
            <div id="panel3" class="panel panel-primary" runat="server">
              <div class="panel-heading">
                <h3 class="panel-title">Template 3</h3>
              </div>
              <div class="panel-body">
                <asp:Image ID="Image5" runat="server" AlternateText="Steps" ImageUrl="Temp3.jpg" 
                      Height="150px" Width="322px"/>
                      <h1></h1>
                      <div style="width:100%;"> 
<div style="float:left; width:36%;">
</div>
<div style="float:right; width:64%; ">
<asp:Button ID="ViewTemp3" runat="server" Text="View Demo" class="btn btn-success" />
</div> 
</div> 
              </div>
              <asp:Button ID="Temp3" runat="server" Text="Choose" 
                    class="btn btn-primary btn-lg btn-block" onclick="Temp3_Click" />
            </div>
          </div>
          
        </div>
       
             
</asp:Content>

