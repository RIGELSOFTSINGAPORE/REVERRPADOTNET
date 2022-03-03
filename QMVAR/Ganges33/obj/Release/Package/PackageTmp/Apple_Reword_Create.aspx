<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/AppleAnalysis.Master" CodeBehind="Apple_Reword_Create.aspx.vb" Inherits="Ganges33.Apple_Reword_Create" %>
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
                  <h3 class="card-title " style="color:white">Reward</h3>
                   
                  <p class="card-category"></p>
                    </div>
                </div>
                <div class="card-body scrollbar" id="style-10" >
<br /><br />




                 
                     <div class="row">
      <div class="col-sm-2">
          <label>Part No</label>
      </div>
      <div>
           <asp:TextBox class="form-file-upload serverlbl"  ID="txtPartNo" runat="server" width="235px"></asp:TextBox>
                
      </div>
      </div>
                    <br />
                     <div class="row">
      <div class="col-sm-2">
          <label>Labour Type</label>
      </div>
      <div>
             <asp:TextBox class="form-file-upload serverlbl" ID="txtLabourType" runat="server" width="235px"></asp:TextBox>
      </div>
      </div>
                    <br />
                     <div class="row">
      <div class="col-sm-2">
          <label>Labour Description</label>
      </div>
      <div>
  <asp:TextBox class="form-file-upload serverlbl" ID="txtLabourDescription" runat="server" width="235px"></asp:TextBox>
      </div>
      </div>
                    <br />
                     <div class="row">
      <div class="col-sm-2">
          <label>Labour Details</label>
      </div>
      <div>
 <asp:TextBox class="form-file-upload serverlbl" ID="txtLabourDetails" runat="server" width="235px"></asp:TextBox>
                
      </div>
      </div>

                    <br />
                        <div class="row">
      <div class="col-sm-2">
          <label>Labour Code</label>
      </div>
      <div>
           <asp:TextBox class="form-file-upload serverlbl" width="235px" ID="txtLabourCode" runat="server"></asp:TextBox>
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
          <label>Amount 100</label>
      </div>
      <div>
           <asp:TextBox class="form-file-upload serverlbl" ID="txtAmount100" runat="server" Width="235px"></asp:TextBox>
      </div>
      </div>
     <br />
                    <div class="row">
      <div class="col-sm-2">
          <label>Amount 150</label>
      </div>
      <div>
	   <asp:TextBox class="form-file-upload serverlbl" width="235px" ID="txtAmount150" runat="server"></asp:TextBox>
           
      </div>
                       
      </div>


<br />




<div class="row">
      <div class="col-sm-2">
          <label>Amount 170</label>
      </div>
      <div>
            <asp:TextBox class="form-file-upload serverlbl" width="235px" ID="txtAmount170" runat="server"></asp:TextBox>
      </div>
</div>




                 <br />
                    <div class="row">
      <div class="col-sm-2">
          <label>Amount 180 </label>
      </div>
      <div>

          <asp:TextBox class="form-file-upload serverlbl" width="235px" ID="txtAmount180" runat="server"></asp:TextBox>

            
              
      </div>
      </div>
               <br />
                    <div class="row">
      <div class="col-sm-2">
          <label>HSN SAC</label>
      </div>
      <div>
           <asp:TextBox class="form-file-upload serverlbl" ID="txtHsnSac" runat="server" width="235px"></asp:TextBox>
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
