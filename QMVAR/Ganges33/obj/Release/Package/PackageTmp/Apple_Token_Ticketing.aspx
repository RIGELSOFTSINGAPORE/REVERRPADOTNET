﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/AppleToken.Master" CodeBehind="Apple_Token_Ticketing.aspx.vb" Inherits="Ganges33.Apple_Token_Ticketing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<%--<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.0/jquery.min.js"></script>
    <link type="text/css" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1/themes/start/jquery-ui.css" rel="stylesheet">
     <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1/jquery-ui.min.js"></script>--%>

   <script type="text/javascript" src="ExternalStyles/Jquery/jquery.min.js"></script>
     <script type="text/javascript" src="ExternalStyles/Jquery/jquery-ui.min.js"></script>
    

    <link href="ExternalStyles/Css/css.css" rel="stylesheet" />  
    <link href="ExternalStyles/Css/font-awesome.min.css" rel="stylesheet" />  
    <link href="ExternalStyles/Css/jquery-ui.css" rel="stylesheet" />

    <link href="assets/jquery-ui_theme.css" rel="stylesheet" />
    <link href="assets/jquery-ui.css" rel="stylesheet" />
    <script type="text/javascript"  src="assets/jquery-ui.min_lips.js"></script>


    <link href="assets/css/material-dashboard.css" rel="stylesheet" />  
    <link href="assets/css/material-dashboard-rtl.css" rel="stylesheet" />
    <link href="assets/css/material-dashboard.min.css" rel="stylesheet" />
    <meta charset="utf-8" />
  <link rel="apple-touch-icon" sizes="76x76" href="../assets/img/apple-icon.png">
  <link rel="icon" type="image/png" href="../assets/img/favicon.png">
  <meta http-equiv="X-UA-Compatible" name="msapplication-tap-highlight" content="IE=edge,chrome=1" />
  
  <meta content='width=device-width, initial-scale=1.0, shrink-to-fit=no' name='viewport' />
  <!--     Fonts and icons     -->
  <%--<link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700|Roboto+Slab:400,700|Material+Icons" />
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/latest/css/font-awesome.min.css">--%>
  <!-- CSS Files -->
   <link href="assets/css/material-dashboard.css" rel="stylesheet" /> 
  <!-- CSS Just for demo purpose, don't include it in your project -->
  <link href="assets/demo/demo.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="wrapper  col-sm-12 sidebar-wrapper position-fixed scrolbar contain" id="style-10">
   
    <div class="content" >
        <div class="container-fluid">
          <div class="row">
            <div class="col-md-12">

                <%-- Blue  --> #1578f7
                     red   --> #fc261c
                     Green --> #e2efda  --%>

              <div class="card" runat="server" id="divcard" style="" >

                <div class="card-header card-header-primary" id="divCustomer" runat="server"><div  style="width:100%" >
                  <h3 class="card-title " style="color:white">Token / PO</h3>
                   
                  <p class="card-category"></p>
                    </div>
                </div>
                <div class="card-body scrollbar" id="style-10" >
<br />




                 
                     <div class="row">
      <div class="col-sm-2">
          <label>Name</label>
      </div>
      <div>
           <asp:TextBox class="form-file-upload serverlbl"  ID="txtName" runat="server" width="235px"></asp:TextBox>
                
      </div>
      </div>
                    <br />

 <div class="row">
      <div class="col-sm-2">
          <label>Mobile</label>
      </div>
      <div>
           <asp:TextBox class="form-file-upload serverlbl"  ID="txtMobile" runat="server" width="235px"></asp:TextBox>
                
      </div>
      </div>
                    <br />


                     <div class="row">
      <div class="col-sm-2">
          <label>Model</label>
      </div>
      <div>
             <asp:DropDownList CssClass="form-control" style="width: 235px; background:white;  height: 33px;" ID="drpType" runat="server" AutoPostBack="true" >
                    </asp:DropDownList>
                     
           <asp:DropDownList CssClass="form-control" style="width: 235px; background:white;  height: 33px;" ID="drpModel" runat="server" >
                    </asp:DropDownList>

          <asp:DropDownList CssClass="form-control" style="width: 235px; background:white;  height: 33px;" ID="drpStatus" runat="server" >
               <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                             <asp:ListItem Text="New" Value="1"></asp:ListItem>
                             <asp:ListItem Text="Pick up" Value="2"></asp:ListItem>
  
                    </asp:DropDownList>
      </div>
      </div>
                    <br />
                     <div class="row">
      <div class="col-sm-2">
          <label>Po No</label>
      </div>
      <div>
  <asp:TextBox class="form-file-upload serverlbl" ID="txtPoNo" runat="server" width="235px"></asp:TextBox>
      </div>
      </div>
               
                       <div class="row">
      <div class="col-sm-2">
        
      </div>
      <div><br />
           <asp:Button runat="server" Text="Reception" ID="create" CssClass="btn btn-primary " /> 
          
      </div>
                         </div>
</div>
                   
                    
    <div>
       
    </div>

</div>

                </div>
              </div>
               </div>
            
     </div>
            
    </div>

        </div>
       
 
  
    <div id="dialog" title="message" style="display:none;">
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </div>
      </asp:UpdatePanel>
</asp:Content>
