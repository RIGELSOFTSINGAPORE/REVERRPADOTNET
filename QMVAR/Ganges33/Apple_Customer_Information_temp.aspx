<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/AppleAnalysis.Master" CodeBehind="Apple_Customer_Information_temp.aspx.vb" Inherits="Ganges33.Apple_Customer_Information_temp" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.0/jquery.min.js"></script>
    <link type="text/css" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1/themes/start/jquery-ui.css" rel="stylesheet">
     <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1/jquery-ui.min.js"></script>

   

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
  <link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700|Roboto+Slab:400,700|Material+Icons" />
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/latest/css/font-awesome.min.css">
  <!-- CSS Files -->
   <link href="assets/css/material-dashboard.css" rel="stylesheet" /> 
  <!-- CSS Just for demo purpose, don't include it in your project -->
  <link href="assets/demo/demo.css" rel="stylesheet" />
    <style type="text/css">

        .container{
    -ms-overflow-style: none;
    overflow: auto;
}
        td {
      font-size: 17px;
    line-height: 1.42857;
    color: #171717;
    font-weight: 500;
}
       
   </style>

    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 187px;
        }
        .auto-style3 {
            width: 170px;
        }
        .auto-style4 {
            width: 187px;
            height: 21px;
        }
        .auto-style5 {
            width: 170px;
            height: 21px;
        }
        .auto-style6 {
            height: 21px;
        }
        .auto-style7 {
            width: 187px;
            height: 20px;
        }
        .auto-style8 {
            width: 170px;
            height: 20px;
        }
        .auto-style9 {
            height: 20px;
        }
        .auto-style10 {
            margin-left: 80px;
        }
        .auto-style11 {
            width: 187px;
            height: 26px;
        }
        .auto-style12 {
            width: 170px;
            height: 26px;
        }
        .auto-style13 {
            height: 26px;
        }

       
        .ServiceTypeDef
        {
             background:#e2efda;
             border-radius: 3px;
    margin-top: -20px;
    padding: 15px;
        }
        .InWarranty
        {
            background:#a9c09e;
           margin-top: -20px;
    padding: 10px;
    margin-left: 17px;
    margin-right: 16px;
     border-radius: 3px;

        }
          .OutWarranty
        {
           
            background:#fc261c;
             border-radius: 3px;
          margin-top: -20px;
    padding: 10px;
    margin-left: 17px;
    margin-right: 16px;
        }
          .ApplecareProtechtion
        {

               background:#1578f7;             
    border-radius: 3px;
    margin-top: -20px;
    padding: 10px;
    margin-left: 17px;
    margin-right: 16px;


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

                <%-- Blue  --> #1578f7
                     red   --> #fc261c
                     Green --> #e2efda  --%>

              <div class="card" runat="server" id="divcard" style="" >

                <div class="card-header card-header-primary" id="divCustomer" runat="server"><div  style="width:100%" >
                  <h3 class="card-title " style="color:white">Customer Information<asp:Button ID="save" runat="server" CssClass="btn btn-primary pull-right" style="width: 135px;height: 32px; border:1px solid white;  font-size: 14px;" Text="Save" /></h3>
                   
                  <p class="card-category"></p>
                    </div>
                </div>
                <div class="card-body scrollbar" id="style-10" >
<br /><br />
                     <div class="row">
      <div class="col-sm-2">
          <label>
              PO No
          </label>
      </div>
      <div>
           <asp:TextBox class="form-file-upload serverlbl" ID="txtPoNo" width="235px" runat="server"></asp:TextBox>
      </div>
                          <div class="col-sm-1">
          <label>
              G NO
          </label>
      </div>
      <div>
           <asp:TextBox class="form-file-upload serverlbl" ID="txtGNo" width="235px" runat="server"></asp:TextBox>
      </div>
      </div>


                     <br />
                      <div class="row">
      <div class="col-sm-2">
          <label>Service Type</label>
      </div>
      <div>
          <asp:DropDownList CssClass="form-control" style="width: 235px; background:white;  height: 33px;" ID="drpServiceType" runat="server" AutoPostBack="">
                <asp:ListItem Text="Select..." Value="0"></asp:ListItem>
                             <asp:ListItem Text="IW-In Warranty" Value="1"></asp:ListItem>
                             <asp:ListItem Text="OOW-Out Of Warranty" Value="2"></asp:ListItem>
                              <asp:ListItem Text="AC+-AppleCareProtectionPlan" Value="3"></asp:ListItem>
                    </asp:DropDownList>
      </div>
      </div>
                  
<br />

    <div class="row">
      <div class="col-sm-2">
          <label>Note</label>
      </div>
      <div>
           <asp:TextBox class="form-file-upload serverlbl" width="235px" ID="txtInvoiceNote" runat="server"></asp:TextBox>
      </div>
                         <div class="col-sm-1">
          <label>GSX&nbsp;Note</label>
      </div>
      <div>
           &nbsp;&nbsp; <asp:TextBox class="form-file-upload serverlbl" width="235px" ID="txtGsxNote" runat="server"></asp:TextBox>
      </div>
      </div>


                    <br />
                     <div class="row">
      <div class="col-sm-2">
          <label>Customer Name</label>
      </div>
      <div>
            <asp:TextBox class="form-file-upload serverlbl" ID="txtCustomerName" runat="server" width="235px"></asp:TextBox>
      </div>
      </div>
                    <br />
                 
                     <div class="row">
      <div class="col-sm-2">
          <label>Address Line1</label>
      </div>
      <div>
           <asp:TextBox class="form-file-upload serverlbl"  ID="txtAddressLine1" runat="server" width="235px"></asp:TextBox>
                
      </div>
      </div>
                    <br />
                     <div class="row">
      <div class="col-sm-2">
          <label>Address Line 2</label>
      </div>
      <div>
             <asp:TextBox class="form-file-upload serverlbl" ID="txtAddressLine2" runat="server" width="235px"></asp:TextBox>
      </div>
      </div>
                    <br />
                     <div class="row">
      <div class="col-sm-2">
          <label>City</label>
      </div>
      <div>
  <asp:TextBox class="form-file-upload serverlbl" ID="txtCity" runat="server" width="235px"></asp:TextBox>
      </div>
      </div>
                    <br />
                     <div class="row">
      <div class="col-sm-2">
          <label>State</label>
      </div>
      <div>
 <asp:TextBox class="form-file-upload serverlbl" ID="txtState" runat="server" width="235px"></asp:TextBox>
                
      </div>
      </div>

                    <br />
                        <div class="row">
      <div class="col-sm-2">
          <label>Postal Code</label>
      </div>
      <div>
           <asp:TextBox class="form-file-upload serverlbl" width="235px" ID="txtZip" runat="server"></asp:TextBox>
      </div>
                         <div class="col-sm-1">
          <label></label>
      </div>
      <div>
          
      </div>
      </div>
                    <br />

                   
                    <div class="row">
      <div class="col-sm-2">
          <label>Email</label>
      </div>
      <div>
           <asp:TextBox class="form-file-upload serverlbl" ID="txtEmail" runat="server" Width="235px"></asp:TextBox>
      </div>
      </div>
     <br />
                    <div class="row">
      <div class="col-sm-2">
          <label>Telephone</label>
      </div>
      <div>
	   <asp:TextBox class="form-file-upload serverlbl" width="235px" ID="txtTelephone" runat="server"></asp:TextBox>
           
      </div>
                         <div class="col-sm-1">
          <label>Mobile</label>
      </div>
      <div>
            <asp:TextBox class="form-file-upload serverlbl" width="235px" ID="txtMobile" runat="server"></asp:TextBox>
      </div>
      </div>












                 <br />
                    <div class="row">
      <div class="col-sm-2">
          <label>GSTIN</label>
      </div>
      <div>
            <asp:TextBox class="form-file-upload serverlbl" ID="txtGstin" runat="server" width="235px"></asp:TextBox>
              
      </div>
      </div>
               <br />
                    <div class="row">
      <div class="col-sm-2">
          <label>Product</label>
      </div>
      <div>
           <asp:TextBox class="form-file-upload serverlbl" ID="txtProduct" runat="server" width="235px"></asp:TextBox>
      </div>
      </div>

                    <br />
                       <div class="row">
      <div class="col-sm-2">
          <label>Model</label>
      </div>
      <div>
           <asp:TextBox class="form-file-upload serverlbl" ID="txtModel" runat="server" width="235px"></asp:TextBox>
      </div>
      </div>


                    <br />
                    <div class="row">
      <div class="col-sm-2">
          <label>Serial No</label>
      </div>
      <div>
           <asp:TextBox class="form-file-upload serverlbl" ID="txtSerialNo" runat="server" width="235px"></asp:TextBox>
      </div>
      </div>
                    <br />
                    <div class="row">
      <div class="col-sm-2">
          <label>IMEI 1</label>
      </div>
      <div>
            <asp:TextBox class="form-file-upload serverlbl" ID="txtImei1" width="235px" runat="server"></asp:TextBox>
      </div>
                        <div class="col-sm-1">
                            <label>IMEI 2</label>
                        </div>
                        <div>  <asp:TextBox class="form-file-upload serverlbl" width="235px" ID="txtImei2" runat="server"></asp:TextBox></div>
      </div>
                   <br />
                    <div class="row">
      <div class="col-sm-2">
          <label>Date of Purchase</label>
      </div>
      <div>
           <asp:TextBox class="form-file-upload serverlbl date" ID="txtDateOfPurchase" width="235px" runat="server"></asp:TextBox>
      </div>
      </div>
                  <br />
                  
                    <div class="row">
      <div class="col-sm-2">
          <label>Comp TIA</label>
      </div>
      <div>
            <asp:TextBox class="form-file-upload serverlbl" ID="txtCompTia" runat="server" Width="235px"></asp:TextBox>
      </div>
      </div>
                   <br />
                    <div class="row">
      <div class="col-sm-2">
          <label>Comp TIA Modifier</label>
      </div>
      <div>
           <asp:TextBox class="form-file-upload serverlbl" ID="txtCompTiaModifier" runat="server" width="235px"></asp:TextBox>
      </div>
      </div>
                    <br />
                    <div class="row">
      <div class="col-sm-2">
          <label></label>
      </div>
      <div>

      </div>
      </div>
                    
                    <table class="auto-style1">
            
       
        
         
            
         
          
        
           
           
            <tr>
                <td class="auto-style2">  <asp:Button ID="btnCalculation" runat="server" CssClass="btn btn-primary" style="width: 135px;height: 32px;font-size: 14px;" Text="Calculation"  enabled="false"/>
         </td>
                <td style="text-align:center;" class="auto-style3">Parts No</td>
                <td style="text-align:center;">Qty</td>
                <td>St</td>
                <td style="text-align:center;">Parts Details</td>
                <td style="text-align:center;">HSN/SAC</td>
                <td style="text-align:center;">Cost</td>
                <td style="text-align:center;">Discount</td>
                <td style="text-align:center;">Sales Price</td>
                <td style="text-align:center;">SGST</td>
                <td style="text-align:center;">CGST</td>
                <td style="text-align:center;">IGST</td>
                <td style="text-align:center;">Total</td>
                <td style="text-align:center;">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">1)Labour Amount</td>
                <td class="auto-style8" >
                    <asp:DropDownList ID="drpLabourAmount"  Visible="false"  CssClass="form-control" style=" background:white; " runat="server" Height="33px" >
                    </asp:DropDownList>
                    <asp:TextBox class="form-file-upload serverlbl" ID="txtLabourAmount" runat="server"   Width="135px"  ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtLabourAmountTemp" runat="server"    Width="135px" Enabled="false"></asp:TextBox>
                     

                </td>
            
                    <td style="text-align:center"> </td>
                <td class="auto-style9">
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtLabourDetail" runat="server"    Width="135px"></asp:TextBox>
                </td>
                <td class="auto-style9">
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtLabourHsnSacCode" runat="server" Width="82px"   ></asp:TextBox>
                </td>
                <td class="auto-style9">
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtLabourCost" runat="server" Width="135px" Style="text-align: right"  ></asp:TextBox>
                </td>
                  <td class="auto-style9">
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtLabourDiscount" runat="server" Width="135px" Style="text-align: right" ></asp:TextBox>
                </td>
                <td class="auto-style9">
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtLabourSales" runat="server" Width="135px"   Style="text-align: right" ></asp:TextBox>
                </td>
                <td class="auto-style9">
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtLabourSGST" runat="server" Width="135px"   Style="text-align: right"></asp:TextBox>
                </td>
                <td class="auto-style9">
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtLabourCGST" runat="server" Width="135px"    Style="text-align: right"></asp:TextBox>
                </td>
                <td class="auto-style9">
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtLabourIGST" runat="server"  Width="135px"   Style="text-align: right"></asp:TextBox>
                </td>
                <td class="auto-style9">
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtLabourTotal" runat="server" Width="135px"   Style="text-align: right"></asp:TextBox>
                </td>
                <td class="auto-style9"></td>
            </tr>
            <tr>
                <td class="auto-style2">Parts1</td>
                <td class="auto-style3">
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtPartNo1" runat="server"></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtQty1" runat="server" Style="text-align: center"></asp:TextBox>
                </td>
                 <td style="text-align:center"> <asp:checkbox runat="server" ID="chkst1" /></td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtPartDetails1" runat="server" Width="135px"   ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtHsnSac1" runat="server" Width="82px"    ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtCost1" runat="server" Width="135px" Style="text-align: right"     ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtDiscount1" runat="server" Width="135px" Style="text-align: right"    ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtSalesPrice1" runat="server" Width="135px" Style="text-align: right"   ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtSGST1" runat="server" Width="135px" Style="text-align: right"   ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtCGST1" runat="server"  Width="135px" Style="text-align: right"   ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtIGST1" runat="server" Width="135px" Style="text-align: right"   ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtTotal1" runat="server" Width="135px" Style="text-align: right"   ></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">Parts2</td>
                <td class="auto-style3">
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtPartNo2" runat="server"></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtQty2" runat="server" Width="135px" Style="text-align: center"></asp:TextBox>
                </td>
                 <td style="text-align:center"> <asp:checkbox runat="server" ID="chkst2" /></td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtPartDetails2" runat="server" Width="135px"    ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtHsnSac2" runat="server" Width="82px"  ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtCost2" runat="server" Width="135px"  Style="text-align: right"    ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtDiscount2" runat="server" Width="135px"  Style="text-align: right"   ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtSalesPrice2" runat="server" Width="135px"  Style="text-align: right"   ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtSGST2" runat="server" Width="135px"  Style="text-align: right"   ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtCGST2" runat="server" Width="135px"  Style="text-align: right"   ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtIGST2" runat="server" Width="135px"  Style="text-align: right"   ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtTotal2" runat="server" Width="135px"  Style="text-align: right"   ></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">Parts3</td>
                <td class="auto-style3">
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtPartNo3" runat="server"></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtQty3" runat="server" Style="text-align: center"></asp:TextBox>
                </td>
                 <td style="text-align:center"> <asp:checkbox runat="server" ID="chkst3" /></td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtPartDetails3" runat="server" Width="135px"  Style="text-align: right"    ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtHsnSac3" runat="server" Width="82px"    ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtCost3" runat="server" Width="135px"  Style="text-align: right"   ></asp:TextBox>
                </td>
                     <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtDiscount3" runat="server" Width="135px"  Style="text-align: right" ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtSalesPrice3" runat="server" Width="135px"  Style="text-align: right"   ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtSGST3" runat="server" Width="135px"  Style="text-align: right"   ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtCGST3" runat="server" Width="135px"  Style="text-align: right"   ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtIGST3" runat="server" Width="135px"  Style="text-align: right"    ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtTotal3" runat="server" Width="135px"  Style="text-align: right"    ></asp:TextBox>
                </td>
                <td>
                         </td>
            </tr>
            <tr>
                <td class="auto-style2">Parts4</td>
                <td class="auto-style3">
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtPartNo4" runat="server"></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtQty4" runat="server" Style="text-align: center"></asp:TextBox>
                </td>
                 <td style="text-align:center"> <asp:checkbox runat="server" ID="chkst4" /></td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtPartDetails4" runat="server" Width="135px"     ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtHsnSac4" runat="server" Width="82px"   ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtCost4" runat="server" Width="135px"  Style="text-align: right"  ></asp:TextBox>
                </td>
                 <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtDiscount4" runat="server" Width="135px"  Style="text-align: right" ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtSalesPrice4" runat="server" Width="135px"  Style="text-align: right"  ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtSGST4" runat="server" Width="135px"  Style="text-align: right"  ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtCGST4" runat="server" Width="135px"  Style="text-align: right"  ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtIGST4" runat="server" Width="135px"  Style="text-align: right"  ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtTotal4" runat="server" Width="135px"  Style="text-align: right; "   ></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                
                
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">2) Parts Amount</td>
                <td class="auto-style3">&nbsp;</td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtPartQtyAmount" runat="server" Width="135px" Style="text-align: center"  ></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtPartCostAmount" runat="server" Visible="false" ></asp:TextBox>
                </td>
                 <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtPartDiscountAmount" runat="server"  Width="135px" Style="text-align: right"    ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtPartSalesAmount" runat="server"  Width="135px" Style="text-align: right"     ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtPartSGSTAmount" runat="server" Width="135px" Style="text-align: right"    ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtPartCGSTAmount" runat="server" Width="135px" Style="text-align: right"    ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtPartIGSTAmount" runat="server" Width="135px" Style="text-align: right"    ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtPartTotal" runat="server" Width="135px" Style="text-align: right"    ></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">3) Other Amount</td>
                <td class="auto-style3">
                    &nbsp;</td>
                
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtOtherQtyAmount" runat="server" Style="text-align: center" ></asp:TextBox></td>
                <td>&nbsp;</td>
                    <td colspan="2">
                    
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtOtherDetail" runat="server" Width="220px"></asp:TextBox></td>
              
               
                
                <td class="auto-style10">
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtOtherCost" runat="server" Style="text-align: right" ></asp:TextBox>
                </td>
                 <td class="auto-style10">
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtOtherDiscount" runat="server" Style="text-align: right" ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtOtherSales" runat="server"  Width="135px" Style="text-align: right"    ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtOtherSGST" runat="server"  Width="135px" Style="text-align: right"    ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtOtherCGST" runat="server"  Width="135px" Style="text-align: right"     ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtOtherIGST" runat="server"  Width="135px" Style="text-align: right"     ></asp:TextBox>
                </td>
                 <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtOtherTotal" runat="server"  Width="135px" Style="text-align: right"    ></asp:TextBox>
                     </td>
            </tr>
            <tr>
                <td class="auto-style2">4) Total Amount</td>
                <td class="auto-style3">
                    &nbsp;</td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtTotalQty" runat="server"  Width="135px" Style="text-align: center"    ></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtTotalCostAmount" runat="server" Width="135px" Style="text-align: right"    ></asp:TextBox>
                </td>
                  <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtDiscountAmount" runat="server" Width="135px" Style="text-align: right"    ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtTotalSalesAmount" runat="server" Width="135px" Style="text-align: right"    ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtTotalSGSTAmount" runat="server" Width="135px" Style="text-align: right"    ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtTotalCGSTAmount" runat="server" Width="135px" Style="text-align: right"    ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtTotalIGSTAmount" runat="server" Width="135px" Style="text-align: right"    ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtTotalAmount" runat="server" Width="135px" Style="text-align: right;background:#00b050"    ></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
                        <tr>
                            <td class="auto-style2">5)Advance Amount </td>
                <td class="auto-style3">  <asp:TextBox class="form-file-upload serverlbl" ID="txtAdvance" runat="server" Width="135px" Style="text-align: center" ></asp:TextBox>
           </td>
                
                <td>Balance Amount</td>
                <td colspan="2">  <asp:TextBox class="form-file-upload serverlbl" ID="txtBalance" runat="server" Width="135px" Style="text-align: center"  ></asp:TextBox>
           </td>
                        </tr>
            <tr>
                <td class="auto-style2">Delivery Date</td>
                <td class="auto-style3">Complete</td>
                <td>Last Update</td>
                <td>&nbsp;</td>
                <td>Payment Method</td>
                <td>&nbsp;</td>
                 <td>Last User</td>
                <td>&nbsp;</td>
                <td>Estimated Date</td>
                <td>GSX Close Date</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style11">
                     <asp:TextBox class="form-file-upload serverlbl date" Width="150px" ID="txtDeliveryDate" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style12">
                    <asp:DropDownList CssClass="form-control" Height="33px" style=" background:white; " ID="drpCompStatus" runat="server">
                         <asp:ListItem Text="Select..." Value="0"></asp:ListItem>
                             <asp:ListItem Text="Complete" Value="1"></asp:ListItem>
                             <asp:ListItem Text="Reception only" Value="2"></asp:ListItem>
                         </asp:DropDownList>
                </td>
                <td class="auto-style13">
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtCompDate" runat="server"   Width="135px" Visible="false" ></asp:TextBox>
                    <asp:TextBox class="form-file-upload serverlbl" ID="txtLastUpdate" runat="server"     Width="135px" ></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td class="auto-style13">
                     <%--<asp:TextBox class="form-file-upload serverlbl" ID="txtDenomination" runat="server" Visible="false"></asp:TextBox>--%>
                                    <asp:DropDownList CssClass="form-control" Height="33px" style=" background:white; " ID="drpDenomination" runat="server">
                         <asp:ListItem Text="Select..." Value="0"></asp:ListItem>
                             <asp:ListItem Text="Card" Value="1"></asp:ListItem>
                             <asp:ListItem Text="Cash" Value="2"></asp:ListItem>
                         </asp:DropDownList>
                </td>
                <td class="auto-style13">
                    </td>
                <td class="auto-style13">
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtLastUser" runat="server"     Width="135px"   ></asp:TextBox>
                </td>
                 <td class="auto-style13"></td>
                <td class="auto-style13">
                     <asp:TextBox class="form-file-upload serverlbl" ID="txtEstimatedDate" runat="server"    Width="135px"  ></asp:TextBox>
                </td>
                <td class="auto-style13">
                     <asp:TextBox class="form-file-upload serverlbl date" ID="txtGSXCloseDate" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style13"></td>
                <td class="auto-style13"></td>
                <td class="auto-style13"></td>
                <td class="auto-style13"></td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="btnDelivered" runat="server" style="width: 146px;height: 32px;font-size: 14px;" CssClass="btn btn-primary" Text="Delivered" />
                </td>
                <td class="auto-style3">
                    <asp:Button ID="btnComplete" runat="server" style="width: 135px;height: 32px;font-size: 14px;" CssClass="btn btn-primary" Text="Complete" />
                </td>
                <td>   <asp:Button ID="save2" runat="server" style="width: 135px;height: 32px;font-size: 14px;" CssClass="btn btn-primary" Text="Save" />
               </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td><asp:Button ID="Btninvoice" CssClass="btn btn-primary" style="width: 135px;height: 32px;font-size: 14px;" runat="server" Text="Invoice" /></td>
                <td><asp:Button ID="btnEstimate" CssClass="btn btn-primary" style="width: 135px;height: 32px;font-size: 14px;" runat="server" Text="Estimate" /></td>
                 <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="Btndiagonis" CssClass="btn btn-primary" style="width: 135px;height: 32px;font-size: 14px;" runat="server" Text="Diagnosis"   />
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
           
        </table>
                    

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
     

</asp:Content>