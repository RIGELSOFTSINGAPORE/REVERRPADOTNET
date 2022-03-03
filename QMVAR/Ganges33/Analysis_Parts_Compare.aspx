﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Analysis.Master" CodeBehind="Analysis_Parts_Compare.aspx.vb" Inherits="Ganges33.Analysis_Parts_Compare" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <%--<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.0/jquery.min.js"></script>
    <link type="text/css" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1/themes/start/jquery-ui.css" rel="stylesheet">
     <script type="text/javascript"  src="http://ajax.googleapis.com/ajax/libs/jqueryui/1/jquery-ui.min.js"></script>--%>
    <script src="ExternalStyles/Jquery/jquery.min.js"></script>
   <script src="ExternalStyles/Jquery/jquery-ui.min.js"></script>
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
  <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
  
  <meta content='width=device-width, initial-scale=1.0, shrink-to-fit=no' name='viewport' />
  <!--     Fonts and icons     -->
  <link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700|Roboto+Slab:400,700|Material+Icons" />
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/latest/css/font-awesome.min.css">
  <!-- CSS Files -->
   <link href="assets/css/material-dashboard.css" rel="stylesheet" /> 
  <!-- CSS Just for demo purpose, don't include it in your project -->
  <link href="assets/demo/demo.css" rel="stylesheet" />
    <style type="text/css">
 .text{
           text-transform:capitalize;
       }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
    

   
   <div class="wrapper  col-sm-12 sidebar-wrapper position-fixed scrolbar contain" id="style-10">
   
    <div class="content" >
        <div class="container-fluid">
          <div class="row">
            <div class="col-md-12">
              <div class="card">
                        <div class="card-header card-header-primary">
                  <h3 class="card-title ">Parts Compare</h3>
                  <p class="card-category"></p>
                </div>
                   <div class="card-body scrollbar" id="style-10">          
                          <br />
            <div class="col-sm-12 row">
                <div class="col-sm-2">
                  <Label ID="Label4" runat="server" class="bmd-label-floating" > Target Store</Label>
                </div>
                <div class="col-sm-2">
                      <asp:DropDownList ID="DropListLocation" runat="server" CssClass="form-control" Height="33px" Width="100%" >
                   
                          </asp:DropDownList>
                       </div>
                <div class="col-sm-1">
                      <Label ID="Label6" runat="server" Text="" CssClass="bmd-label-floating">Month</Label>   
                   
                </div>
                <div class="col-sm-2">
                      <asp:DropDownList ID="DropDownMonth" runat="server" CssClass="form-control" Height="33px" Width="100%" >
                        		     <asp:ListItem Text="Select..." Value="0"></asp:ListItem>
                             <asp:ListItem Text="January" Value="01"></asp:ListItem>
                              <asp:ListItem Text="February" Value="02"></asp:ListItem>
                              <asp:ListItem Text="March" Value="03"></asp:ListItem>
                             <asp:ListItem Text="April" Value="04"></asp:ListItem>
                              <asp:ListItem Text="May" Value="05"></asp:ListItem>
                               <asp:ListItem Text="June" Value="06"></asp:ListItem>
                             <asp:ListItem Text="July" Value="07"></asp:ListItem>
                              <asp:ListItem Text="August" Value="08"></asp:ListItem>
                              <asp:ListItem Text="September" Value="09"></asp:ListItem>
                              <asp:ListItem Text="October" Value="10"></asp:ListItem>
                              <asp:ListItem Text="November" Value="11"></asp:ListItem>
                              <asp:ListItem Text="December" Value="12"></asp:ListItem>
                      </asp:DropDownList> 
                    </div><br /><br /><br />
                <div class="col-sm-2" >
                      <asp:DropDownList ID="DropDownYear" runat="server" CssClass="form-control" Height="33px" >
                            <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                              <asp:ListItem Text="2020" Value="2020"></asp:ListItem>
                              <asp:ListItem Text="2021" Value="2021"></asp:ListItem>
                             <asp:ListItem Text="2022" Value="2022"></asp:ListItem>
                              <asp:ListItem Text="2023" Value="2023"></asp:ListItem>
                               <asp:ListItem Text="2024" Value="2024"></asp:ListItem>
                             <asp:ListItem Text="2025" Value="2025"></asp:ListItem>
                         
                      </asp:DropDownList>
                    </div><br /><br /><br />
                
               
                          
                <div class="col-sm-12" >
                      <asp:Button ID="btnSend" runat="server" Width="90px" height="36px"  Text="Send" CssClass="btn btn-primary pull-right text"  />
                      <asp:Button ID="btnExport" runat="server" Width="90px" height="36px"   Text="Export" CssClass="btn btn-primary pull-right text" />
                     </div>
                <div class="col-sm-12">
                        
                </div>
                    </div>
                
            
                       <div id="tblPartsCompare" class="col-sm-12" runat="server" visible="false">
                        <div class="col-sm-12 row">
                         
			<div class="serverlbl font-weight-bold col-sm-3" " style="padding-left:0px"> <br /> Result : <asp:Label ID="lblResultMont"  class="serverlbl " runat="server"></asp:Label></div>

			
                            <br />
			<div class="serverlbl font-weight-bold col-sm-3" style="padding-left:0px"> <br /> Last Updated User: <asp:Label ID="lblLastUpdatedUser"  class="serverlbl " runat="server"></asp:Label></div>

	
                            <br />
				<div class="serverlbl font-weight-bold col-sm-3" style="padding-left:0px"> <br /> Last update date : <asp:Label ID="lblUpdatedDate" class="serverlbl " runat="server"></asp:Label></div>

			
				                          
          </div>
                           <div class="row col-sm-12">
                          <br />
                         <table style="margin-top:10px;padding-left:10px">
                             <tr>
                                 <td>
                                     <label class="serverlbl font-weight-bold" >Total count record</label>
                                 </td>
                                 <td>
                                     <asp:Label ID="lblTotalRecords" class="serverlbl" runat="server"></asp:Label>
                                 </td>
                             </tr>
                              <tr>
                                 <td>
                                     <label class="serverlbl font-weight-bold" > Total count parts</label>
                                 </td>
                                 <td>
                                     <asp:Label ID="lblTotalCountParts" class="serverlbl"  runat="server"></asp:Label>
                                 </td>
                             </tr>
                              <tr>
                                 <td>
                                     <label class="serverlbl font-weight-bold">Stockoverview number(GSPN)</label>
                                 </td>
                                 <td>
                                     <asp:Label ID="lblStockOverView" class="serverlbl" runat="server"></asp:Label>
                                 </td>
                             </tr>
                             <tr>
                                 <td>
                                      <label class="serverlbl font-weight-bold" style="font-weight:bold">Match parts record</label>
                                 </td>
                                 <td>
                                     <asp:Label ID="lblMatchPartsRecord" class="serverlbl"   runat="server"></asp:Label>
                                 </td>
                             </tr>
                             <tr>
                                 <td>
<label class="serverlbl font-weight-bold" >Unmatch parts record</label>
                                 </td>
                                 <td>
                                     <asp:Label ID="lblUnmatchPartsRecord" class="serverlbl"  runat="server"></asp:Label>
                                 </td>
                             </tr>
                             <tr>
                                 <td>
                                     <label class="serverlbl font-weight-bold" >Different record +</label>
                                 </td>
                                 <td>
                                     <asp:Label ID="lblPositiveRecord" class="serverlbl" runat="server"></asp:Label>
                                 </td>
                             </tr>
                             <tr>
                                 <td>
                                     <label class="serverlbl font-weight-bold"> Different number +</label> 
                                 </td>
                                 <td>
                                     <asp:Label ID="lblPositiveRecordSum"  CssClass="serverlbl" runat="server"></asp:Label>
                                 </td>
                             </tr>
                             <tr>
                                 <td>
                                     <label class=" font-weight-bold serverlbl" >Different record- </label> 
                                 </td>
                                 <td>
                                     <asp:Label ID="lblNegativeRecord" CssClass="serverlbl" runat="server"></asp:Label>
                                 </td>
                             </tr>
                              <tr>
                                 <td>
                                     <label class="serverlbl font-weight-bold"> Different number -</label> 
                                 </td>
                                 <td>
                                     <asp:Label ID="lblNegativeRecordSum" CssClass="serverlbl" runat="server"></asp:Label>
                                 </td>
                             </tr>
                         </table>
			
                       </div>
                           </div>
          </div>
          <br />
          <br />
          </div>
                        
     </div>
          </div>   
        </div>
                    
        <asp:Button ID="BtnCancel" runat="server" Text="Button" style="display:none;"/>
        <asp:Button ID="BtnOK" runat="server" Text="Button" style="display:none;" />


    
        
     
       <div style="visibility:hidden">
                        <div class="form-group row">
                            <div class="col-sm-2">
                          <label class="bmd-label-floating">Current Location</label> 
                                </div>
                            <div>
                                <label>:</label>
                                <asp:Label ID="lblLoc" class="bmd-label-floating  serverlbl" runat="server"></asp:Label>
                       </div>
                        </div>
               
                              <div class="form-group row">
                            <div class="col-sm-2">
                           <label class="bmd-label-floating">Current Username</label>
                                </div>
                            <div>
                                <label>:</label>
                          <asp:label class="bmd-label-floating serverlbl" ID="lblName"  runat="server"> </asp:label>
                          </div>
                        </div>
 </div>
        </div>
       </div>
       <div style="margin-top:500px;">        

    <div id="dialog" title="Parts compare" style="display:none;"> >
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </div>
    </div>
</asp:Content>
