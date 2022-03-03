<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/AppleAnalysis.Master" CodeBehind="Apple_parts_create.aspx.vb" Inherits="Ganges33.Apple_parts_create" %>
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
                  <h3 class="card-title " style="color:white">Parts</h3>
                   
                  <p class="card-category"></p>
                    </div>
                </div>
                <div class="card-body scrollbar" id="style-10" >
<br /><br />




                 
                     <div class="row">
      <div class="col-sm-2">
          <label>PO NO</label>
      </div>
      <div>
           <asp:TextBox class="form-file-upload serverlbl"  ID="txtPONO" runat="server" width="235px"></asp:TextBox>
                
      </div>
      </div>
                    <br />
                     <div class="row">
      <div class="col-sm-2">
          <label>Status</label>
      </div>
      <div>
             <asp:TextBox class="form-file-upload serverlbl" ID="txtStatus" runat="server" width="235px"></asp:TextBox>
      </div>
      </div>
                    <br />
                     <div class="row">
      <div class="col-sm-2">
          <label>Product Name</label>
      </div>
      <div>
  <asp:TextBox class="form-file-upload serverlbl" ID="txtProductName" runat="server" width="235px"></asp:TextBox>
      </div>
      </div>
                    <br />
                     <div class="row">
      <div class="col-sm-2">
          <label>Parts No</label>
      </div>
      <div>
 <asp:TextBox class="form-file-upload serverlbl" ID="txtPartNo" runat="server" width="235px"></asp:TextBox>
                
      </div>
      </div>

                    <br />
                        <div class="row">
      <div class="col-sm-2">
          <label>Parts Detail</label>
      </div>
      <div>
           <asp:TextBox class="form-file-upload serverlbl" width="235px" ID="txtPartsDetail" runat="server"></asp:TextBox>
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
          <label>Parts type</label>
      </div>
      <div>
           <asp:TextBox class="form-file-upload serverlbl" ID="txtPartstype" runat="server" Width="235px"></asp:TextBox>
      </div>
      </div>
     <br />
                    <div class="row">
      <div class="col-sm-2">
          <label>Tier</label>
      </div>
      <div>
	   <asp:TextBox class="form-file-upload serverlbl" width="235px" ID="txtTier" runat="server"></asp:TextBox>
           
      </div>
                       
      </div>







<div class="row">
      <div class="col-sm-2">
          <label>Currency</label>
      </div>
      <div>
            <asp:TextBox class="form-file-upload serverlbl" width="235px" ID="txtCurrency" runat="server"></asp:TextBox>
      </div>
</div>




                 <br />
                    <div class="row">
      <div class="col-sm-2">
          <label>Price option </label>
      </div>
      <div>

           <asp:DropDownList CssClass="form-control" style="width: 235px; background:white;  height: 33px;" ID="drpPriceoption" runat="server" >
                          <asp:ListItem Text="Exchange Price" Value="Exchange Price"></asp:ListItem>
                          <asp:ListItem Text="Stock Price" Value="Stock Price"></asp:ListItem>
                         <asp:ListItem Text="Battery Only Price" Value="Battery Only Price"></asp:ListItem>
                          <asp:ListItem Text="Display" Value="Display"></asp:ListItem>
                         <asp:ListItem Text="ADH" Value="ADH"></asp:ListItem>
                          <asp:ListItem Text="Cable Replacement" Value="Cable Replacement"></asp:ListItem>

                              
                    </asp:DropDownList>

            
              
      </div>
      </div>
               <br />
                    <div class="row">
      <div class="col-sm-2">
          <label>Price cost</label>
      </div>
      <div>
           <asp:TextBox class="form-file-upload serverlbl" ID="txtPricecost" runat="server" width="235px"></asp:TextBox>
      </div>
      </div>
                    <br />
                    <div class="row">
      <div class="col-sm-2">
          <label>EEE EEEE</label>
      </div>
      <div>
           <asp:TextBox class="form-file-upload serverlbl" ID="txtE" runat="server" width="235px"></asp:TextBox>
      </div>
      </div>
                           <br />
                    <div class="row">
      <div class="col-sm-2">
          <label>Alt Native Parts</label>
      </div>
      <div>
            <asp:TextBox class="form-file-upload serverlbl" ID="TxtAltNativeParts" width="235px" runat="server"></asp:TextBox>
      </div>
                         </div>
                
                                 <br />
                    <div class="row">
      <div class="col-sm-2">
          <label>Component Group</label>
      </div>
      <div>
            <asp:TextBox class="form-file-upload serverlbl" ID="txtComponentGroup" width="235px" runat="server"></asp:TextBox>
      </div>
                         </div>
                
                                 <br />
                    <div class="row">
      <div class="col-sm-2">
          <label>Serial No</label>
      </div>
      <div>
            <asp:TextBox class="form-file-upload serverlbl" ID="txtSerialNo" width="235px" runat="server"></asp:TextBox>
      </div>
                         </div>
                
                                 <br />
                    <div class="row">
      <div class="col-sm-2">
          <label>Diag Req </label>
      </div>
      <div>
            <asp:TextBox class="form-file-upload serverlbl" ID="txtDiagReq" width="235px" runat="server"></asp:TextBox>
      </div>
                         </div>
                
                        
      <br />
                    <div class="row">
      <div class="col-sm-2">
          <label>Sales price</label>
      </div>
      <div>
            <asp:TextBox class="form-file-upload serverlbl" ID="txtSalesprice" width="235px" runat="server"></asp:TextBox>
      </div>
                         </div>
                
      <br />
                    <div class="row">
      <div class="col-sm-2">
          <label>HSN SAC</label>
      </div>
      <div>
            <asp:TextBox class="form-file-upload serverlbl" ID="txtHSNSAC" width="235px" runat="server"></asp:TextBox>
      </div>
                         </div>
                
      <br />
    
               
                       <div class="row">
      <div class="col-sm-2">
        
      </div>
      <div><br />
           <asp:Button runat="server" Text="save" ID="create" CssClass="btn btn-primary " /> 
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Button runat="server" Text="Back" ID="BAck" CssClass="btn btn-primary " />
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
     
</asp:Content>
