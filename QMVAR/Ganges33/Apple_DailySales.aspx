<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/AppleAnalysis.Master" CodeBehind="Apple_DailySales.aspx.vb" Inherits="Ganges33.Apple_DailySales" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <%--<script  src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.0/jquery.min.js"></script>
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
 <%-- <link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700|Roboto+Slab:400,700|Material+Icons" />
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/latest/css/font-awesome.min.css">--%>
  <!-- CSS Files -->
   <link href="assets/css/material-dashboard.css" rel="stylesheet" /> 
  <!-- CSS Just for demo purpose, don't include it in your project -->
  <link href="assets/demo/demo.css" rel="stylesheet" />
    <style type="text/css">
        .text{
           text-transform:capitalize;
       }
        .container{
    -ms-overflow-style: none;
    overflow: auto;
}      


#table1 {  
   border-collapse: collapse;
   border: 1px solid black;
  padding: 4px;  
}
th{
    border: 1px solid black;
  padding: 4px;  
    height: 28px;
    width: 141px;
    border: 1px solid black;
    background-color: #a953c2;
    text-align: left;
	color:white;
	font-weight: 400;
	text-align:center;
	
}
.td1{
    border: 1px solid black;
  padding: 4px;  
background-color: #a953c2;
color:white;	
font-weight: 400;
}

.td2{
    border: 1px solid black;
  padding: 4px;  
text-align:right;
font-weight: 400;
}
.td3{
    text-align:center; 
    color:white;
    font-weight: 400;
    border: 1px solid black;
}



   </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    

   
   <div class="wrapper  col-sm-12 sidebar-wrapper position-fixed scrolbar contain" id="style-10">
   
    <div class="content" >
        <div class="container-fluid">
          <div class="row">
            <div class="col-md-12">
              <div class="card">
                <div class="card-header card-header-primary">
                  <h3 class="card-title ">Apple-Dashboard</h3>
                  <p class="card-category"></p>
                </div>
                <div class="card-body"  id="style-10">
<br />

                    <div class="row col-sm-12">
                        <div class=" col-sm-7">
                            <div class="row">
                            <div class="col-sm-1">
                             <label class="bmd-label-floating">From</label>
                                </div>
                         <%--   <div class="col-sm-3">
                                </div>--%>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtFrom" CssClass="form-file-upload date serverlbl" Width="111px"  runat="server"  autocomplete="off"></asp:TextBox>

                                </div>
                      <div class="col-sm-1" style="margin-left: -24px;">
                   
                         
                  <label class=" bmd-label-floating">To</label>
                          </div>
                                
                            <div>
                       <asp:TextBox ID="txtTo" CssClass="form-file-upload date serverlbl" Width="111px" runat="server"   autocomplete="off"  ></asp:TextBox>
                      </div>
                                <div style="margin-left:17px;margin-top:-5px;">
                   <asp:Button ID="btnSearch" runat="server" Width="90px" height="34px" Text="Search" class="btn btn-primary text" />
                                   
                              </div>
                    </div>

                           
                            
                        </div>
                      
                        <%-- <div>--%>

                           
                             <%--<div class="row">
                                 <div>
                                   <%--<label id="g" class=" bmd-label-floating">Month &amp; Year &nbsp;&nbsp;</label>
                                     </div>--%>
                                <%-- <div >
                        <asp:DropDownList ID="DropDownMonth" runat="server"  style=" height:33px;" CssClass=" form-control" >
                      </asp:DropDownList>
                                     </div>--%>
                    
                        
                          
                             
                        
                                 <div>
                                     <%--<asp:Imagebutton  ID="btnImgExcel"  runat="server" ImageUrl="icon/csv.png" ID="btnOpen" Width="33px" class="pull-right"></asp:Imagebutton>--%>
 
                                 </div>
                             </div>
                          
                             <div class="col-sm-12">
                                 <br />
              <br />

                                 <table id="table1">
  <tr>
    <th></th>
    <th>Generate PO</th>
    <th>New</th>
	<th>Pickup</th>
	<th>Total</th>
  </tr>
  <tr>
    <td class="td1">Token</td>
   <td class="td2"><asp:Label ID="lblGeneratePo" runat="server">0.00</asp:Label></td>
    <td class="td2"><asp:Label ID="lblNewToken" runat="server">0.00</asp:Label></td>
	 <td class="td2"><asp:Label ID="lblPickupToken" runat="server">0.00</asp:Label></td>
	  <td class="td2"><asp:Label ID="lblTotalToken" runat="server" >0.00</asp:Label></td>
  </tr>
  
  
</table>
<br/>
<br/>

<table id="table1">
  <tr>
    <th></th>
    <th>IW</th>
    <th>OOW</th>
	<th>AC+</th>
      <th>Total</th>
	<th>Sales</th>
	<th>Net</th>
  </tr>
  <tr>
    <td class="td1">UnderRepair</td>
   <td class="td2"><asp:Label ID="lblUnderRepairIW" runat="server">0.00</asp:Label></td>
    <td class="td2"><asp:Label ID="lblUnderRepairOOW" runat="server">0.00</asp:Label></td>
	 <td class="td2"><asp:Label ID="lblUnderRepairAC" runat="server">0.00</asp:Label></td>
       
	  <td class="td2"><asp:Label ID="lblUnderRepairTotal" runat="server">0.00</asp:Label></td>
	  <td class="td2" rowspan="4" style="text-align:center"><asp:Label ID="lblSalesCount" runat="server">0</asp:Label></td>
	  <td class="td2" rowspan="4" style="text-align:center"><asp:Label ID="lblNetCount" runat="server">0</asp:Label></td>
  </tr>
  <tr>
    <td class="td1">Custoday</td>
   <td class="td2"><asp:Label ID="lblCustodyIW" runat="server">0.00</asp:Label></td>
    <td class="td2"><asp:Label ID="lblCustodyOOW" runat="server">0.00</asp:Label></td>
	 <td class="td2"><asp:Label ID="lblCustodyAC" runat="server">0.00</asp:Label></td>
	  <td class="td2"><asp:Label ID="lblCustodyTotal" runat="server">0.00</asp:Label></td>
  </tr>
  <tr>
    <td class="td1">GSX Comp</td>
   <td class="td2"><asp:Label ID="lblGSXCompIW" runat="server">0.00</asp:Label></td>
    <td class="td2"><asp:Label ID="lblGSXCompOOW" runat="server">0.00</asp:Label></td>
	 <td class="td2"><asp:Label ID="lblGSXCompAC" runat="server">0.00</asp:Label></td>
	  <td class="td2"><asp:Label ID="lblGSXCompTotal" runat="server">0.00</asp:Label></td>
  </tr>
  <tr>
    <td class="td1">Deliverd</td>
   <td class="td2"><asp:Label ID="lblDeliveredIW" runat="server">0.00</asp:Label></td>
    <td class="td2"><asp:Label ID="lblDeliveredOOW" runat="server">0.00</asp:Label></td>
	 <td class="td2"><asp:Label ID="lblDeliveredAC" runat="server">0.00</asp:Label></td>
	  <td class="td2"><asp:Label ID="lblDeliveredTotal" runat="server">0.00</asp:Label></td>
  </tr>
  
  
  
</table>

<br/>
<br/>

<table id="table1">	
  <tr>
    <th></th>
	<th colspan="2" rowspan="2">IW</th>
    <th colspan="2">OOW</th>
    <th colspan="2">AC+</th>
	<th colspan="2">Sales</th>
	<th colspan="2">Total</th>
	<th colspan="2" rowspan="2">Net</th>
  </tr>
  <tr class="td1">
  <td style="height: 20px;"></td>
    
    <td  class="td3">Cash</td>
	 <td class="td3">Card</td>
	  <td class="td3">Cash</td>
	  <td class="td3">Card</td>
	  <td class="td3">Cash</td>
	  <td class="td3">Card</td>
	  
	  <td class="td3">Cash</td>
	  <td class="td3">Card</td>
	  
  </tr>
  <tr>
    <td class="td1">Labour (Amount)</td>
   <td class="td2" colspan="2"><asp:Label ID="lblLabourIW" runat="server">0.00</asp:Label></td>
    
	 <td class="td2"><asp:Label ID="lblLabourOOWCash" runat="server">0.00</asp:Label></td>
	  <td class="td2"><asp:Label ID="lblLabourOOWCard" runat="server">0.00</asp:Label></td>
	  <td class="td2"><asp:Label ID="lblLabourACCash" runat="server">0.00</asp:Label></td>
	  <td class="td2"><asp:Label ID="lblLabourACCard" runat="server">0.00</asp:Label></td>
	  <td class="td2"><asp:Label ID="lblLabourSalesCash" runat="server">0.00</asp:Label></td>
	  <td class="td2"><asp:Label ID="lblLabourSalesCard" runat="server">0.00</asp:Label></td>
	  <td class="td2"><asp:Label ID="lblLabourTotalCash" runat="server">0.00</asp:Label></td>
	  <td class="td2"><asp:Label ID="lblLabourTotalCard" runat="server">0.00</asp:Label></td>
	  <td class="td2"><asp:Label ID="lblLabourNet" runat="server">0.00</asp:Label></td>
  </tr>
  <tr>
    <td class="td1">Parts (Amount)</td>
   <td class="td2" colspan="2"><asp:Label ID="lblPartsIW" runat="server">0.00</asp:Label></td>
    
	 <td class="td2"><asp:Label ID="lblPartsOOWCash" runat="server">0.00</asp:Label></td>
	  <td class="td2"><asp:Label ID="lblPartsOOWCard" runat="server">0.00</asp:Label></td>
	  <td class="td2"><asp:Label ID="lblPartsACCash" runat="server">0.00</asp:Label></td>
	  <td class="td2"><asp:Label ID="lblPartsACCard" runat="server">0.00</asp:Label></td>
	  <td class="td2"><asp:Label ID="lblPartsSalesCash" runat="server">0.00</asp:Label></td>
	  <td class="td2"><asp:Label ID="lblPartsSalesCard" runat="server">0.00</asp:Label></td>
	  <td class="td2"><asp:Label ID="lblPartsTotalCash" runat="server">0.00</asp:Label></td>
	  <td class="td2"><asp:Label ID="lblPartsTotalCard" runat="server">0.00</asp:Label></td>
	  <td class="td2"><asp:Label ID="lblPartsNet" runat="server">0.00</asp:Label></td>
  </tr>
  <tr>
    <td class="td1">Total</td>
   <td class="td2" colspan="2"><asp:Label ID="lblTotalIW" runat="server">0.00</asp:Label></td>
    
	<td class="td2"><asp:Label ID="lblTotalOOWCash" runat="server">0.00</asp:Label></td>
	 <td class="td2"><asp:Label ID="lblTotalOOWCard" runat="server">0.00</asp:Label></td>
	  <td class="td2"><asp:Label ID="lblTotalACCash" runat="server">0.00</asp:Label></td>
	  <td class="td2"><asp:Label ID="lblTotalACCard" runat="server">0.00</asp:Label></td>
	  <td class="td2"><asp:Label ID="lblTotalSalesCash" runat="server">0.00</asp:Label></td>
	  <td class="td2"><asp:Label ID="lblTotalSalesCard" runat="server">0.00</asp:Label></td>
	  <td class="td2"><asp:Label ID="lblTotalTotalCash" runat="server">0.00</asp:Label></td>
	  <td class="td2"><asp:Label ID="lblTotalTotalCard" runat="server">0.00</asp:Label></td>
	  <td class="td2"><asp:Label ID="lblTotalTotal" runat="server">0.00</asp:Label></td>
  </tr>
  
  <tr>
    <td class="td1">Net</td>
   <td colspan="2" class="td2"><asp:Label ID="lblNetIW" runat="server">0.00</asp:Label></td>
   <td colspan="2" class="td2"><asp:Label ID="lblNetOOW" runat="server">0.00</asp:Label></td>
	<td colspan="2" class="td2"><asp:Label ID="lblNetAC" runat="server">0.00</asp:Label></td>
	  <td colspan="2" class="td2"><asp:Label ID="lblNetSales" runat="server">0.00</asp:Label></td>
	  <td class="td2"colspan="2"><asp:Label ID="lblNetTotal" runat="server">0.00</asp:Label></td>
	  <td colspan="2" class="td2"><asp:Label ID="lblNet" runat="server">0.00</asp:Label></td>
  </tr>
  
  
  
  
</table>
                             </div>

                       <%-- </div>--%>

                      
                    </div>

  <%--<div class="row col-sm-12">

         


       <br />
                     <div class="row col-sm-12" style="height:40px">
      <div>
          <label>
              From
          </label>
      </div>
      <div  class="col-sm-2">
           <asp:TextBox ID="txtFrom" CssClass="form-file-upload date serverlbl"  style="margin-left: 34px;" runat="server"  autocomplete="off"></asp:TextBox>

      </div>
                         <div  class="col-sm-" >
                             <label style="margin-left: 34px;">
                                 To
                             </label>
                         </div>
                         <div  class="col-sm-2">
                             <asp:TextBox ID="txtTo" CssClass="form-file-upload date serverlbl" Style="margin-left: 42px; "  runat="server"   autocomplete="off"  ></asp:TextBox>
                     
                   
                             </div>
                   
                          <br />.
      </div>


                     <br />

                   
                    <div class="">
                           <br />
                        <asp:Button ID="btnSearch" runat="server" Width="90px" height="36px" Text="Search" class="btn btn-primary text" />

                       <asp:ImageButton ID="btnImgExcel" runat="server" src="icon/excel.png"  CssClass="pull-right" Style="width:40px;margin-right: 10px; height:40px" /> 
                    </div>





      <br />
      <br />
      <br />
      <br />



                   
    	
      
                    
                
              </div>--%>
               </div>
            
     </div>
            
    </div>
        </div>
              </div>

           
                   
                            
                   

           

                 
     
    
  
     

</asp:Content>