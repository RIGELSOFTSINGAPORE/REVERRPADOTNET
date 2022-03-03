<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/AppleAnalysis.Master" CodeBehind="Apple_AC_Parts_Create.aspx.vb" Inherits="Ganges33.Apple_AC_Parts_Create" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
.textcenter{
    text-align:center;
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
.btnfloat{
    float:right;
}
        .left1{
            margin-left:15px;
        }
        

   </style>
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <%--<asp:ObjectDataSource ID="source_session_online" runat="server" SelectMethod="session_online" TypeName="t_session" />
            
             <asp:UpdatePanel ID="updatepnl" UpdateMode="Always" runat="server">  
        <ContentTemplate> --%>
    <div class="wrapper  col-sm-12 sidebar-wrapper position-fixed scrolbar contain" id="style-10">
   
    <div class="content">
        <div class="container-fluid">
          <div class="row">
            <div class="col-md-12">
              <div class="card">
                <div class="card-header card-header-primary">
                  <h3 class="card-title ">
                    <asp:label id="Header" Text="" runat="server" > </asp:label></h3>
                  <p class="card-category"></p>
                </div>

                   <div class="card-body scrollbar" id="style-10" >

                       <div runat="server" id="addfile">
                            <asp:Label ID="lblRequird" runat="server" style="font-size:small;font-weight:500"  ForeColor="Red" Visible="true">* Required</asp:Label><br /><br />
                    <div class="row">
                       
                        <div class="col-sm-2">

                          <label>Part No </label> 
                            <b style="color:red; font-size:large" >*</b>
                        </div>
                        <div class="col-sm-4">
                             <asp:TextBox ID="txtpartno" runat="server" value="" Height="33px" width="270px" class="form-file-upload  serverlbl" MaxLength="20" />
                        <asp:RequiredFieldValidator class="serverlbl "  ID="SName" runat="server" ControlToValidate="txtpartno" ErrorMessage="*"   
ForeColor="Red"></asp:RequiredFieldValidator> 
                     
                        </div>
                        </div>

                        <div class="row">
                          <div class="col-sm-2">
                              <br />
                              <label>
                                UPC EAN
                           </label> 
                              <%--<b style="color:red; font-size:large" >*</b>--%>
                             </div>
                             <div class="col-sm-4"> <br />
                              <asp:TextBox ID="txtUPCEAN" runat="server" value="" Height="33px" width="270px" class="form-file-upload  serverlbl" MaxLength="100" />
                          <%-- <asp:RequiredFieldValidator class="serverlbl "  ID="SInfo" runat="server" ControlToValidate="txtUPCEAN" ErrorMessage="*"   
ForeColor="Red"></asp:RequiredFieldValidator>--%> 
                            </div>
                        </div>
                        

                        <div class="row">
                          <div class="col-sm-2"> <br />
                              <label>
                                Description
                           </label> 
                              <b style="color:red; font-size:large">*</b>
                             </div>
                             <div class="col-sm-4">  <br />
                              <asp:TextBox ID="txtDescription" runat="server" value="" Height="33px" width="270px" class="form-file-upload  serverlbl" MaxLength="20" />
                           <asp:RequiredFieldValidator class="serverlbl "  ID="SManager" runat="server" ControlToValidate="txtDescription" ErrorMessage="*"   
ForeColor="Red"></asp:RequiredFieldValidator> 
                            </div>
                        </div>
                        <div class="row">
                             <div class="col-sm-2">  <br />
                                 <label>
                                     Sap Description
                                 </label> 
                                 <b style="color:red; font-size:large" >*</b>
                             </div>
                            <div class="col-sm-4">  <br />
                                 <asp:TextBox ID="txtSAPDESCRIPTION" runat="server" value="" Height="33px" width="270px" class="form-file-upload  serverlbl" MaxLength="20" />
                                 <asp:RequiredFieldValidator class="serverlbl "  ID="STel" runat="server" ControlToValidate="txtSAPDESCRIPTION" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator> 
                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Style=" margin-left: -140px;" CssClass="serverlbl " Please Enter Sap Descrption ControlToValidate="ShipTel" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>--%>
                         </div>  
                             

                               
                           
                        </div>
                   

                    <div class="row">
                        <div class="col-sm-2">  <br />
                            <label>
                                Purchese Price
                            </label> 
                            <b style="color:red; font-size:large" >*</b>
                        </div>
                        <div class="col-sm-4">  <br />
                            <asp:TextBox ID="txtPURCHASEPRICE" runat="server" value="" Height="33px" width="270px" class="form-file-upload   serverlbl" MaxLength="70" />
                           <asp:RequiredFieldValidator class="serverlbl "  ID="SAdd1" runat="server" ControlToValidate="txtPURCHASEPRICE" ErrorMessage="*"   
ForeColor="Red"></asp:RequiredFieldValidator> 
                        </div>
                    </div>

             <div class="row">
                        <div class="col-sm-2">  <br />
                            <label>
                                Sales Price
                            </label> 
                            <b style="color:red; font-size:large" >*</b>
                        </div>
                        <div class="col-sm-4">  <br />
                            <asp:TextBox ID="txtsalesPrice" runat="server" value="" Height="33px" width="270px" class="form-file-upload   serverlbl" MaxLength="70" />
                          <asp:RequiredFieldValidator class="serverlbl "  ID="txtsales" runat="server" ControlToValidate="txtsalesPrice" ErrorMessage="*"   
ForeColor="Red"></asp:RequiredFieldValidator> 
                        </div>
                    </div>
                           

                           <div class="row" runat="server" id="CurrentInStock">
                          <div class="col-sm-2">
                              <br />
                              <label>
                                Current In Stock
                           </label> 
                              <b style="color:red; font-size:large" >*</b>
                             </div>
                             <div class="col-sm-3"> <br />
                              <asp:TextBox ID="txtCURRENTINSTOCK" runat="server" value="" Height="33px" width="270px" class="form-file-upload  serverlbl" MaxLength="100" /><b style="font-size:small" >If you change the stock, please provide necessary comments.</b>
                           <asp:RequiredFieldValidator class="serverlbl "  ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCURRENTINSTOCK" ErrorMessage="*"   
ForeColor="Red"></asp:RequiredFieldValidator> 
                            </div>
                               <div class="col-sm-2">
                              <br />
                              <label style="margin-left:37px;">
                                Comments
                           </label> 
                              <%--<b style="color:red; font-size:large" >*</b>--%>
                             </div>
                             <div class="col-sm-4"> <br />
                              <asp:TextBox ID="txtComments" runat="server" value="" placeholder="Please Enter Comments" TextMode="MultiLine" Height="33px" width="270px" class="form-file-upload  serverlbl" />
                           <%--<asp:RequiredFieldValidator class="serverlbl"   ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtComments" ErrorMessage="*"   
ForeColor="Red"></asp:RequiredFieldValidator> --%>
                            </div>
                        </div>
          <div class="row" id="LastInDate" runat="server">
                        <div class="col-sm-2">  <br />
                            <label>                                Last In Date
                            </label>
                            <%--<b style="color:red; font-size:large" >*</b>--%>
                        </div>
                        <div class="col-sm-4">  <br />
                            <asp:TextBox ID="txtlastindate" runat="server" value="" Height="33px" width="270px" class="form-file-upload  serverlbl" MaxLength="70" />
                           <%--<asp:RequiredFieldValidator class="serverlbl "  ID="txtlastindate1" runat="server" ControlToValidate="txtlastindate" ErrorMessage="*"   
ForeColor="Red"></asp:RequiredFieldValidator> --%>
                        </div>
                    </div>
          <div class="row" id="LastOutDate" runat="server">
                        <div class="col-sm-2">  <br />
                            <label>
                                Last Out Date
                            </label>
                            <%--<b style="color:red; font-size:large" >*</b>--%>
                        </div>
                        <div class="col-sm-4">  <br />
                            <asp:TextBox ID="txtLASTOUTDATE" runat="server" value="" Height="33px" width="270px" class="form-file-upload  serverlbl" MaxLength="10" />
                           <%--<asp:RequiredFieldValidator class="serverlbl "  ID="RequiredtxtLASTOUTDATE" runat="server" ControlToValidate="txtLASTOUTDATE" ErrorMessage="*"   
ForeColor="Red"></asp:RequiredFieldValidator> --%>
                        </div>
                    </div>

                          
             <div class="row" runat="server">
                        <div class="col-sm-2">  <br />
                            <label>
                                Part Tax 
                            </label>
                            <b style="color:red; font-size:large" >*</b><br />
                            (Ex. 9%) = 9
                        </div>
                        <div class="col-sm-4">  <br />
                            <asp:TextBox ID="txtParttax" runat="server" value="" Height="33px" width="270px" class="form-file-upload  serverlbl"  Text="0.18" />
                           <asp:RequiredFieldValidator class="serverlbl "  ID="RequiredtxtLASTOUTDATE" runat="server" ControlToValidate="txtParttax" ErrorMessage="*"   
ForeColor="Red"></asp:RequiredFieldValidator> 
                        </div>
                    </div>
             
                    <div class="row">
                        <div class="col-sm-2">
                             </div>
                   
                   
                            <div style="margin-left: 15px;">   <br />
 <asp:Button ID="btnAddNew" runat="server" Text="Create" Width="80px" height="32px" class="btn btn-primary text" />
                                 <asp:Button ID="Edit"  Width="80px" height="32px" runat="server" Text="Save" class="btn btn-primary text" />
                                 <asp:Button ID="Back"  Width="80px" height="32px" runat="server"  CausesValidation="false" Text="Back" class="btn btn-primary pull-right text" />
                 
                    </div>


                    </div>
                 <div>   <br />
                          </div>     
     </div>

                       </div>

                       </div>
 
             </div>  </div>
            
     </div>
            
    </div>
        </div>
              

    <div style="margin-top: 500px;">

        <div id="dialog" title="Stock Inventry" style="display: none;">

            <asp:Label ID="lblMsg" style="color:black" runat="server" Text=""></asp:Label>
        </div>
    </div> 
</asp:Content>
