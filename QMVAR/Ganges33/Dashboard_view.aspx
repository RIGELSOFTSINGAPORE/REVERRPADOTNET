<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Analysis.Master" CodeBehind="Dashboard_view.aspx.vb" Inherits="Ganges33.Dashboard_view" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <%--<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.0/jquery.min.js"></script>
    <link type="text/css"  href="http://ajax.googleapis.com/ajax/libs/jqueryui/1/themes/start/jquery-ui.css" rel="stylesheet">
     <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1/jquery-ui.min.js"></script>--%>
    <script type="text/javascript" src="ExternalStyles/Jquery/jquery.min.js"></script>
    <script type="text/javascript" src="ExternalStyles/Jquery/jquery-ui.min.js"></script>
   

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

    <link href="ExternalStyles/Css/css.css" rel="stylesheet" />  
    <link href="ExternalStyles/Css/font-awesome.min.css" rel="stylesheet" />  
    <link href="ExternalStyles/Css/jquery-ui.css" rel="stylesheet" />  

  <!-- CSS Files -->
   <link href="assets/css/material-dashboard.css" rel="stylesheet" /> 
  <!-- CSS Just for demo purpose, don't include it in your project -->
  <link href="assets/demo/demo.css" rel="stylesheet" />
    <style type="text/css">
 
        </style>
    <script>
        $(function () {
            $('[class*=date]').datepicker({
                changeMonth: true,
                changeYear: true,
                format: "DD/MM/YYYY",
                language: "tr"

            });
        });
    </script>
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
                  <h3 class="card-title ">Dashboard</h3>
                  <p class="card-category"></p>
                </div>
  <div  class="card-body scrollbar " id="style-10">
      
                     
          <div>
              <div>
                  <div class="row " style="margin-left: 20px; margin-top: 10px;">
                         <div>
                             <label class="bmd-label-floating " runat="server" id="servicecenter"  style="font-size:medium;font-weight:bold; margin-top:4px">
                                 Service center
                             </label>
                         </div>
                  <div class="col-sm-2">
                      <asp:DropDownList ID="DropdownList1" runat="server" height="33px" Width="100px" Class=" form-control" >
                            </asp:DropDownList> 
                  </div>
                                 
                                   
                
                        <div >
                               
                                    
                             <%--<asp:Label ID="Label1"  Text="Month" runat="server"  class="bmd-label-floating " style="font-size:medium;font-weight:bold"></asp:Label>--%>
                            <label class="bmd-label-floating " runat="server" id="Label1"  style="font-size:medium;font-weight:bold; margin-top:4px">
                                 Month
                             </label>
                        </div>
                            <div class="col-sm-2">

                                
				  <asp:DropDownList ID="DropDownMonth" runat="server" CssClass="form-control dropdown-toggle" AutoPostBack="false" style="width: 100%; height:33px" >
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
                         </div> <br /><br /><br />
					 
                        
                          <div class="col-sm-2">
                                
					<asp:DropDownList ID="DropDownYear" runat="server" CssClass="form-control dropdown-toggle" AutoPostBack="false"  style=" height:33px" >
                            <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                              <asp:ListItem Text="2020" Value="2020" ></asp:ListItem>
                              <asp:ListItem Text="2021" Value="2021"  Selected="True"></asp:ListItem>
                             <asp:ListItem Text="2022" Value="2022"></asp:ListItem>
                              <asp:ListItem Text="2023" Value="2023"></asp:ListItem>
                               <asp:ListItem Text="2024" Value="2024"></asp:ListItem>
                             <asp:ListItem Text="2025" Value="2025"></asp:ListItem>
                         
                      </asp:DropDownList>

                        </div><br /><br /><br />
                     <div class="col-sm-2" style="margin-top:-4px">
                         
<asp:Button ID="btnSend" runat="server" class="btn btn-primary " width="82px" height="33px"  text="Search"/>
                         </div>
</div>
              </div>
                   <div class="row">
                              
                       
                     
                             <div class="col-sm-6">
                             <div  class="text-center" >  
                                 <br />
                                     <br />
                                  <asp:Label ID="CustomerVisit"  Text="Customer Visit" runat="server" style="font-size: large;font-weight:bold" class="bmd-label-floating "></asp:Label>
                               </div>
                               <div class="title-nav">
               
                            <asp:Chart ID="Chart2" runat="server" Width="320px" Height="276px" >

            <series>

                <asp:Series Name="Series1" XValueMember="0" YValueMembers="1" BackGradientStyle="Center" BackImageTransparentColor="White" BackSecondaryColor="White" BorderColor="White" Color="White">

                </asp:Series>

            </series>

            <chartareas>

                <asp:ChartArea Name="ChartArea1" BackColor="Orange" BackSecondaryColor ="Yellow">

                </asp:ChartArea>

            </chartareas>

        </asp:Chart>
                                   </div>
                               </div>
                            
                            <div class="col-sm-6">
                            <div class="text-center">    
                                <br />
                                     <br />
                                <asp:Label ID="CallRegisterd"  Text="Call Registerd&nbsp;" runat="server" style="font-size: large;font-weight:bold" class="bmd-label-floating "></asp:Label>
                                </div>
                           <div class="title-nav">
                           
                                         <asp:Chart ID="Chart3" runat="server" Width="320px" Height="276px" Palette="SeaGreen">

            <series>

              <asp:Series Name="Series1" XValueMember="0" YValueMembers="2" BackGradientStyle="Center" BackImageTransparentColor="White" BackSecondaryColor="White" BorderColor="White" Color="White">

                </asp:Series>


                <%--<asp:Series  Name="Series2" XValueMember="0" YValueMembers="1" ChartArea="ChartArea1" ChartType="Point" BackImageTransparentColor="White" BorderColor="white" LabelForeColor="White" MarkerBorderColor="White" YValuesPerPoint="2">
                </asp:Series>--%>

                

            </series>

            <chartareas>

                <asp:ChartArea Name="ChartArea1"  BackColor="Red" BackSecondaryColor ="Yellow" ShadowColor="White">

                </asp:ChartArea>

            </chartareas>

        </asp:Chart>
                               </div>
                                   </div>   
                       </div>
              
                       <div class="row">
                              
                                <div class="col-sm-6">
                                       <div class="text-center" >
                                       <br />
                                     <br />
                                            <asp:Label ID="Repaircompleted"  Text="&nbsp;&nbsp;Repair completed" runat="server" style="font-size: large;font-weight:bold" class="bmd-label-floating "></asp:Label>
                                       </div>
                                <div class="title-nav">
                                    <asp:Chart ID="Chart4" runat="server" Width="320px" Height="276px">

            <series>

               <asp:Series Name="Series1" XValueMember="0" YValueMembers="3" BackGradientStyle="Center" BackImageTransparentColor="White" BackSecondaryColor="White" BorderColor="White" Color="White">

                </asp:Series>

            </series>

            <chartareas>

                <asp:ChartArea Name="ChartArea1"  BackColor="green" BackSecondaryColor ="Yellow" ShadowColor="White">

                </asp:ChartArea>

            </chartareas>

        </asp:Chart>
                                       </div>
                                   </div>

                                  
             <div class="col-sm-6">
                            <div class="text-center">    
                                <%--<label class="bmd-label-floating" style="font-weight:bold">
                                    Goods Delivered
                                </label>--%>
                                <asp:Label ID="GoodsDelivered"  Text="Goods Delivered" runat="server" style="font-size: large;font-weight:bold" class="bmd-label-floating "></asp:Label>
                                </div>
                           <div class="title-nav">
                           
                            <asp:Chart ID="Chart5" runat="server" Width="320px" Height="276px">

            <series>

             <asp:Series Name="Series1" XValueMember="0" YValueMembers="4" BackGradientStyle="Center" BackImageTransparentColor="White" BackSecondaryColor="White" BorderColor="White" Color="White">

                </asp:Series>


               <%-- <asp:Series  Name="Series2" XValueMember="0" YValueMembers="1" ChartArea="ChartArea1" ChartType="Point" BackImageTransparentColor="0, 192, 0" BorderColor="white" LabelForeColor="White" MarkerBorderColor="White">
                </asp:Series>--%>
            </series>

            <chartareas>

                <asp:ChartArea Name="ChartArea1"  BackColor="Blue" BackSecondaryColor ="Yellow" ShadowColor="White">

                </asp:ChartArea>

            </chartareas>

        </asp:Chart>
                             </div>
                                  
                                   </div>
                              
                               
                                    
                               
                         </div>
                              
                           <br /><br />
                            

              

 
       <div class="row ">
            <div class="col-sm-6">
                                       <div class="text-center">
                                           <%--<label class="bmd-label-floating" style="font-weight:bold">
                                               Pending Calls
                                           </label>--%>
                                             <asp:Label ID="PendingCalls"  Text="Pending Calls&nbsp;&nbsp;" runat="server" style="font-size: large;font-weight:bold" class="bmd-label-floating "></asp:Label>
                                       </div>
                                        <div class="title-nav">
 <asp:Chart ID="Chart6" runat="server" Width="320px" Height="276px">

            <series>

                 <asp:Series Name="Series1" XValueMember="0" YValueMembers="5" BackGradientStyle="Center" BackImageTransparentColor="White" BackSecondaryColor="White" BorderColor="White" Color="White">

                </asp:Series>

            </series>

            <chartareas>

                <asp:ChartArea Name="ChartArea1"  BackColor="#EE00EE" BackSecondaryColor ="Yellow" ShadowColor="White">

                </asp:ChartArea>

            </chartareas>

        </asp:Chart>
                              </div>
                                  </div>

           <div class="col-sm-6">
                            <div class="text-center">    
                                <%--<label class="bmd-label-floating"  style="font-weight:bold">
                                    Cancelled Calls
                                </label>--%>
                                <asp:Label ID="CancelledCalls"  Text="Cancelled Calls" runat="server" style="font-size: large;font-weight:bold" class="bmd-label-floating "></asp:Label>
                                </div>
                           <div class="title-nav">
                            <asp:Chart ID="Chart7" runat="server" Width="320px" Height="276px">

            <series>
<asp:Series Name="Series1" XValueMember="0" YValueMembers="6" BackGradientStyle="Center" BackImageTransparentColor="White" BackSecondaryColor="White" BorderColor="White" Color="White">

                </asp:Series>


<%--                <asp:Series  Name="Series2" XValueMember="0" YValueMembers="1" ChartArea="ChartArea1" ChartType="Point" BackImageTransparentColor="0, 192, 0" BorderColor="white" LabelForeColor="White" MarkerBorderColor="White">
                </asp:Series>--%>
            </series>

            <chartareas>
 <asp:ChartArea Name="ChartArea1"  BackColor="#420042" BackSecondaryColor ="Yellow" ShadowColor="White">

                </asp:ChartArea>

            </chartareas>

        </asp:Chart>
                               </div>
                                </div>


                              <div class="col-sm-8">
                                  
                          
              <div class="col-sm-6" style="display:none">
                            <div class=" bg-white">    
                                <label class="bmd-label-floating" style="color:white">
                                   .
                                </label>
                                </div>
                           <div class="col-sm-8">
                           <asp:Chart ID="Chart1" runat="server"  Width="320px" Height="276px" BackColor="Transparent" Palette="None" BackImageTransparentColor="White" BackSecondaryColor="White" TextAntiAliasingQuality="Normal" >

            <series>

                <asp:Series Name="Series1" XValueMember="0" YValueMembers="1" ChartType="FastLine" BackImageTransparentColor="0, 192, 0" BorderColor="white" LabelForeColor="White" MarkerBorderColor="White">

                </asp:Series>

                <asp:Series  Name="Series2" XValueMember="0" YValueMembers="1" ChartArea="ChartArea1" ChartType="Point" BackImageTransparentColor="0, 192, 0" BorderColor="white" LabelForeColor="White" MarkerBorderColor="White">
                </asp:Series>

            </series>

            <chartareas>

                <asp:ChartArea Name="ChartArea1" BackColor="Green" BackSecondaryColor="yellow" BorderColor="White" ShadowColor="MintCream">

                </asp:ChartArea>

            </chartareas>

                               <BorderSkin BackColor="White" BorderColor="White" />

        </asp:Chart>
                     </div>       
                  </div> 
                              </div>

                            
                          
            </div>
              <div class="row leftalign">
                  <div class="col-sm-8">
                             <div  style="width:45px;" class="leftalign1">  
                                   <%--<label class="bmd-label-floating " style="font-weight:bold">
                                       Customer Visit
                                   </label>--%>
                                 
                                  <asp:Label ID="Sales"  Text="Sales" runat="server" style="font-size: large;font-weight:bold" class="bmd-label-floating "></asp:Label>
                               </div>
                               <div  style="margin-left:306px" >
               
                            <asp:Chart ID="Chart18" runat="server"  Width="530px" Height="276px">

            <series>

                <asp:Series Name="Series1" XValueMember="0" YValueMembers="1" BackGradientStyle="Center" BackImageTransparentColor="White" BackSecondaryColor="White" BorderColor="White" Color="White">

                </asp:Series>

            </series>

            <chartareas>

                <asp:ChartArea Name="ChartArea1" BackColor="YellowGreen" BackSecondaryColor ="Yellow">

                </asp:ChartArea>

            </chartareas>

        </asp:Chart>
                                   </div>
                               </div>

              </div>
      
                           <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
                           </div>
                  
                  <div class="form-group">
            <asp:Label ID="lblInfo" Class="bmd-label-floating" runat="server"></asp:Label>
        </div>
      
    
      
      </div>
         
                </div>
                    
                    </div>

            </div>
        </div>
        </div>
       </div>
    

    
    

     <div id="dialog" title="message" style="display:none;"> >
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </div>

</asp:Content>
