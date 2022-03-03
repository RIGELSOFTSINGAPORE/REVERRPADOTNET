﻿<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/SonyAnalysis.Master" CodeBehind="SonyAnalysis_Report.aspx.vb" Inherits="Ganges33.SonyAnalysis_Report" %>
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
  <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
  
  <meta content='width=device-width, initial-scale=1.0, shrink-to-fit=no' name='viewport' />
  <!--     Fonts and icons     -->
  <%--<link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700|Roboto+Slab:400,700|Material+Icons" />
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/latest/css/font-awesome.min.css">--%>
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
   <%-- <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
    

  <<div class="wrapper  col-sm-12 sidebar-wrapper position-fixed scrolbar contain" id="style-10">
   
    <div class="content" >
        <div class="container-fluid">
          <div class="row">
            <div class="col-md-12">
              
              <div class="card">
                <div class="card-header card-header-primary">
                  <h3 class="card-title ">Analysis Activity Report</h3>
                  <p class="card-category"></p>
                </div>
               <div class="card-body scrollbar" id="style-10">
                  
                  
                    <br />

                    <div class="row col-sm-12">
                        <div class=" col-sm-7">
                            <div class="row">
                            <div class="col-sm-3">
                             <label class=" bmd-label-floating">Active Month</label>
                                </div>
                            <div>
                         <asp:Label ID="lblMonNow" runat="server" CssClass=" bmd-label-floating"></asp:Label>
                                </div>
                            <div class="col-sm-3">
                      <asp:DropDownList ID="DropDownActiveMonth"  runat="server" CssClass="Form-control " style=" height:33px;"  AutoPostBack="True">
                      </asp:DropDownList>
                                </div>
                      <div class="col-sm-1">
                   
                         
                  <label class=" bmd-label-floating">Year</label>
                          </div>
                                &nbsp;&nbsp;&nbsp;&nbsp;
                            <div>
                      <asp:DropDownList ID="ddlActiveYear" OnSelectedIndexChanged="ddlActiveYear_SelectedIndexChanged" runat="server" style="height:33px;" AutoPostBack="True" CssClass=" form-control">
                      </asp:DropDownList>
                      </div>
                    </div>

                            <div>
                                <div class="row ">
                                    <div class="col-sm-3">
                                        <br />
                                 <label class="bmd-label-floating"  >Select Day</label>
                                        </div>
                                    <div class="col-sm-1">
                                        <br />
                          <asp:DropDownList ID="DropDownDay" runat="server" style=" height:33px; width:50px" OnSelectedIndexChanged="DropDownDay_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control">
                      </asp:DropDownList>
                                         <br />
                                        </div>
                                    </div>
                                </div>
                            
                        </div>
                      
                         <div>

                           
                             <div class="row">
                                 <div>
                                   <label id="g" class=" bmd-label-floating">Month &amp; Year &nbsp;&nbsp;</label>
                                     </div>
                                 <div >
                        <asp:DropDownList ID="DropDownMonth" runat="server"  style=" height:33px;" CssClass=" form-control" >
                      </asp:DropDownList>
                                     </div>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                        
                          <div>
                   <asp:DropDownList ID="DropDownYear" runat="server" style="height:33px;" CssClass=" form-control">
                      </asp:DropDownList>
                              </div>
                             &nbsp;&nbsp;&nbsp;&nbsp;
                        
                                 <div>
                                     <asp:Imagebutton runat="server" ImageUrl="icon/csv.png" ID="btnOpen" Width="33px" class=" pull-right"></asp:Imagebutton>
 
                                 </div>
                             </div>
                          
                             <div class="col-sm-12">
                                 <br />
              <br />
                             </div>

                        </div>

                      
                    </div>

                     <div class="col-sm-12">
                         <asp:Button ID="Button1" runat="server" Width="90px" height="36px" Text="Fill Zero"  class="btn btn-primary serverlbl pull-right text" />
                        </div>

                    <div >
                       
                         <div >
                        
                       <table class="table">
                        
                          <thead class=" text-primary">
                            
                            <tr>
                              <th class="" style="background: transparent;border: none;"></th><th>
                              Customer Visit
                            </th>s
                            <th class="Serverlbl">
                              Call Registered
                            </th>
                            <th class="Serverlbl">
                              Repair Complete
                            </th>
                            <th class="Serverlbl">
                              Goods Delivered
                            </th>
                            <th class="Serverlbl">
                              Pending Calls
                            </th>
                            <th class="Serverlbl">
                              Cancelled Calls
                            </th>
                                <th class="Serverlbl">
                              Reservation
                            </th>
                          </tr>

                          </thead>
            
             
              <tr>
           
                      <td  class="" style="background: transparent;border: none;">
                   <asp:Label ID="Label23" runat="server" Text="Service" ></asp:Label><br /><br />
                    <asp:Label ID="Label1344" runat="server" Text="D&I" ></asp:Label>
                  </td>

                  <td class="">
                      <asp:TextBox ID="TextCustomer_Visit_S" runat="server" CssClass="form-control serverlbl"></asp:TextBox>
                      <asp:TextBox ID="TextCustomer_Visit_D" runat="server" CssClass="form-control serverlbl"></asp:TextBox>
                  </td>

                  <td class="">
                      <asp:TextBox ID="TextCall_Registerd_S" runat="server" CssClass="form-control serverlbl"></asp:TextBox>
                      <asp:TextBox ID="TextCall_Registerd_D" runat="server" CssClass="form-control serverlbl"></asp:TextBox>
                  </td>
                  <td class="">
                      <asp:TextBox ID="TextRepair_Completed_S" runat="server" CssClass="form-control serverlbl"></asp:TextBox>
                 <asp:TextBox ID="TextRepair_Completed_D" runat="server" CssClass="form-control serverlbl"></asp:TextBox>
                      </td>
                  <td class="">
                      <asp:TextBox ID="TextGoods_Delivered_S" runat="server" CssClass="form-control serverlbl"></asp:TextBox>
                  <asp:TextBox ID="TextGoods_Delivered_D" runat="server" CssClass="form-control serverlbl"></asp:TextBox>
                  </td>
                  <td class="">
                      <asp:TextBox ID="TextPending_Calls_S" runat="server" CssClass="form-control serverlbl"></asp:TextBox>
                  <asp:TextBox ID="TextPending_Calls_D" runat="server" CssClass="form-control serverlbl"></asp:TextBox>
                  </td>
                  <td class="">
                      <asp:TextBox ID="TextCancelled_Calls_S" runat="server" CssClass="form-control serverlbl"></asp:TextBox>
                  <asp:TextBox ID="TextCancelled_Calls_D" runat="server" CssClass="form-control serverlbl"></asp:TextBox>
                  </td>
                  <td class="">
                      <asp:TextBox ID="TextReservation_S" runat="server" CssClass="form-control serverlbl"></asp:TextBox>
                  <asp:TextBox ID="TextReservation_D" runat="server" CssClass="form-control serverlbl"></asp:TextBox>
                  </td>
              </tr>
              </table>

        
                      </div>


                        <div class="col-sm-12">
                            <div>
                                <label class="bmd-label-floating">
                                    Note
                                </label>
                            </div>
                            <div>
                            <asp:TextBox ID="TextNote" runat="server" CssClass=" form-control serverlbl"  TextMode="MultiLine"></asp:TextBox>
                        </div>
                            </div>


                    </div>



                    <div class="col-sm-12">
                        <br />
                         <asp:button ID="btnSend" runat="server" Text="Submit" Width="90px" height="36px" class="btn btn-primary serverlbl pull-right text"></asp:button>
                    </div>
                    <br />
                    <div class="col-sm-12">
                        <div>
                        <label id="bmd-label-floating">Message</label>
                            </div>
                        <div class="form-group bmd-form-group">
                           <asp:ListBox ID="ListMsg" runat="server" class="form-control" rows="5" style="height: 135px;"></asp:ListBox>
                         </div>
                    </div>

                    

                         
                        </div>

                
                   
                      
              <asp:Button ID="BtnCancel" runat="server" Text="Button" style="display:none;"/>
        <asp:Button ID="BtnOK" runat="server" Text="Button" style="display:none;" />
                
              </div>
            </div>
            </div>
          </div>
        </div>
       </div>
    <div id="dialog" title="message" style="display:none;"> >
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </div>


    <div style="visibility:hidden">
        
                        <div class="form-group row">
                            <div class="col-sm-2">
                          <label class="bmd-label-floating ">Current Location</label> 
                                </div>
                            <div class="col-sm-5">
                                <label>:</label>
                                <asp:Label ID="lblLoc" class="bmd-label-floating Serverlbl" runat="server"></asp:Label>
                       </div>
                        </div>
                 
                      
                      
                     
                        <div class="form-group row">
                            <div class="col-sm-2">
                           <label class="bmd-label-floating">Current Username</label>
                                </div>
                            <div class="col-sm-5">
                                <label>:</label>
                          <asp:label class="bmd-label-floating Serverlbl" ID="lblName"  runat="server"> </asp:label>
                          </div>
                        </div>
    </div>
</asp:Content>
