
<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Analysis.Master" CodeBehind="SetupNewServiceCenter.aspx.vb" Inherits="Ganges33.SetupNewServiceCenter" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <script type="text/javascript" src="ExternalStyles/Jquery/jquery.min.js"></script>
    <script type="text/javascript" src="ExternalStyles/Jquery/jquery-ui.min.js"></script>
    <script type="text/javascript" src="ExternalStyles/Jquery/bootstrap-multiselect.js"></script>

    <%--<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.0/jquery.min.js"></script>
    <link type="text/css" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1/themes/start/jquery-ui.css" rel="stylesheet">
     <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1/jquery-ui.min.js"></script>--%>
    <!--<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>-->

   <script type="text/javascript" src="ServiceCenter.js"></script>

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
     <%--<script src="https://code.jquery.com/jquery-3.4.1.slim.min.js"></script>
    <link href="https://www.jqueryscript.net/css/jquerysctipttop.css" rel="stylesheet" type="text/css">--%>

	<link href="assets/css/timepicker.css" rel="stylesheet" />

    <script src="assets/timepicker.js"></script>
     <script type="text/javascript">
         $(document).ready(function () {
             $(".simpleExample").timepicker();


         });
    </script>
    <style type="text/css">

         .container{
    -ms-overflow-style: none;
    overflow: auto;
}
            .ie11.tablet input[type='radio'] {
visibility: visible;
}
        
p:hover {
  color: black;
}
   .container{
    -ms-overflow-style: none;
    overflow: auto;

}

 html, body { overflow: hidden; }
       
.nav-link[data-toggle].collapsed:before {
    content: " ▾";
    float:right;
    font-size:30px;
    margin-top:10px;
    color:red;
}

.nav-link[data-toggle]:not(.collapsed):before {
    content: " ▴";
    float:right;
    font-size:30px;
    margin-top:5px;
    color:red;
}

/* Closed submenu icon */
#sidebar-container .list-group .list-group-item[aria-expanded="false"] .submenu-icon::after {
  content: " \f0d7";
  font-family: FontAwesome;
  display: inline;
  text-align: right;
  padding-left: 10px;
}
/* Opened submenu icon */
#sidebar-container .list-group .list-group-item[aria-expanded="true"] .submenu-icon::after {
  content: " \f0da";
  font-family: FontAwesome;
  display: inline;
  text-align: right;
  padding-left: 10px;
}

.liactive
{
    background:#9c27b0;
    color:white;

}

.btn_active {
    background-color: transparent;
    border: none;
    font-size: 16px;
    font-weight: 500;
    text-align: left;
    padding-left: 0px;
    color: black;
    cursor: pointer;
}
p.btn_active:hover
{
    color:black;
}
.ui-dialog {
	overflow: hidden;
	position: absolute;
	top: 300px;
	left: 550px;
	padding: .2em;
	outline: 0;
}

        .asc:after {
    content: ' \25BC';
     
}
       .dec:after {
    content: ' \25B2';
     
}
       .sort:after {
    content: ' \21C5';
    
}
       .text{
           text-transform:capitalize;
       }






.GridPager a, .GridPager span
{
display: block;
height: 20px;
width: 20px;
font-weight: bold;
text-align: center;
text-decoration: none;
}
.GridPager a
{
background-color:#9c27b0;
color: white;
border-radius: 3px;

}
.GridPager span
{
background-color: transparent;
color: #000;
border: 1px;
} 
              
   </style>
    <script>
        $(function () {
            $("[id*=lnkView]").click(function () {
                //alert("hi");
                var rowIndex = $(this)[0].getAttribute("data-commandargument");
                ////alert(rowIndex);
                window.open("Popup.aspx?rowindex=" + rowIndex, 'Popup', 'height=500,width=800,left=100,top=100,resizable=yes,scrollbars=yes,toolbar=yes,menu=no');
            });
        });
    </script>

 

                    

   
                      
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
                 <%-- <h3 class="card-title ">Setup New Servicecenter</h3>--%>
                    <h3 class="card-title " >
                      <asp:label id="Header" Text="" runat="server" > </asp:label>
                  </h3>
                  <p class="card-category"></p>
                </div>
                <div class="card-body scrollbar" id="style-10" >
     <div runat="server" id="addfile">
                    <div class="row">
                        <div class="col-sm-2">

                          <label>Branch Name </label>  <b style="color:red; font-size:large" >*</b>
                        </div>
                        <div class="col-sm-4">
                             <asp:TextBox ID="ShipName" runat="server" value="" Height="33px" width="270px" class="form-file-upload  serverlbl" MaxLength="20" /><br />
                        <asp:RequiredFieldValidator class="serverlbl "  ID="SName" runat="server" ControlToValidate="ShipName" ErrorMessage="Please Enter a Branch Name"   
ForeColor="Red"></asp:RequiredFieldValidator> 
                     
                        </div>
                        </div>

                        <div class="row">
                          <div class="col-sm-2">
                              <br />
                              <label>
                                Branch Info
                           </label> <b style="color:red; font-size:large" >*</b>
                             </div>
                             <div class="col-sm-4"> <br />
                              <asp:TextBox ID="ShipInfo" runat="server" value="" Height="33px" width="270px" class="form-file-upload  serverlbl" MaxLength="100" /><br />
                           <asp:RequiredFieldValidator class="serverlbl "  ID="SInfo" runat="server" ControlToValidate="ShipInfo" ErrorMessage="Please Enter a Branch Info"   
ForeColor="Red"></asp:RequiredFieldValidator> 
                            </div>
                        </div>
                        

                        <div class="row">
                          <div class="col-sm-2"> <br />
                              <label>
                                Branch Manager
                           </label> <b style="color:red; font-size:large" >*</b>
                             </div>
                             <div class="col-sm-4">  <br />
                              <asp:TextBox ID="ShipManager" runat="server" value="" Height="33px" width="270px" class="form-file-upload  serverlbl" MaxLength="20" /><br />
                           <asp:RequiredFieldValidator class="serverlbl "  ID="SManager" runat="server" ControlToValidate="ShipManager" ErrorMessage="Please Enter a Branch Manager"   
ForeColor="Red"></asp:RequiredFieldValidator> 
                            </div>
                        </div>
                        <div class="row">
                             <div class="col-sm-2">  <br />
                                 <label>
                                     Branch Tel
                                 </label> <b style="color:red; font-size:large" >*</b>
                             </div>
                            <div class="col-sm-4">  <br />
                                 <asp:TextBox ID="ShipTel" runat="server" value="" Height="33px" width="270px" class="form-file-upload  serverlbl" MaxLength="20" /><br />
                                 <asp:RequiredFieldValidator class="serverlbl "  ID="STel" runat="server" ControlToValidate="ShipTel" ErrorMessage="Please Enter a Branch Tel" ForeColor="Red"></asp:RequiredFieldValidator> 
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Style=" margin-left: -140px;" CssClass="serverlbl " ControlToValidate="ShipTel" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                         </div>  
                             

                               
                           
                        </div>
                   

                    <div class="row">
                        <div class="col-sm-2">  <br />
                            <label>
                                Branch Add1
                            </label> <b style="color:red; font-size:large" >*</b>
                        </div>
                        <div class="col-sm-4">  <br />
                            <asp:TextBox ID="ShipAdd1" runat="server" value="" Height="33px" width="270px" class="form-file-upload   serverlbl" MaxLength="70" />
                          <%-- <asp:RequiredFieldValidator class="serverlbl "  ID="SAdd1" runat="server" ControlToValidate="ShipAdd1" ErrorMessage="Please Enter a Branch Add1"   
ForeColor="Red"></asp:RequiredFieldValidator> --%>
                        </div>
                    </div>

             <div class="row">
                        <div class="col-sm-2">  <br />
                            <label>
                                Branch Add2
                            </label>
                        </div>
                        <div class="col-sm-4">  <br />
                            <asp:TextBox ID="ShipAdd2" runat="server" value="" Height="33px" width="270px" class="form-file-upload   serverlbl" MaxLength="70" />
                          
                        </div>
                    </div>

          <div class="row">
                        <div class="col-sm-2">  <br />
                            <label>
                                Branch Add3
                            </label>
                        </div>
                        <div class="col-sm-4">  <br />
                            <asp:TextBox ID="ShipAdd3" runat="server" value="" Height="33px" width="270px" class="form-file-upload   serverlbl" MaxLength="70" />
                           
                        </div>
                    </div>
          <div class="row">
                        <div class="col-sm-2">  <br />
                            <label>
                                Zip
                            </label>
                        </div>
                        <div class="col-sm-4">  <br />
                            <asp:TextBox ID="Zip" runat="server" value="" Height="33px" width="270px" class="form-file-upload   serverlbl" MaxLength="10" />
                           
                        </div>
                    </div>
            
             <div class="row">
                        <div class="col-sm-2">  <br />
                            <label>
                                Email
                            </label> <b style="color:red; font-size:large" >*</b>
                        </div>
                        <div class="col-sm-4">  <br />
                            <asp:TextBox ID="Email" runat="server" value="" Height="33px" width="270px" class="form-file-upload   serverlbl" MaxLength="30" /><br />
                            <asp:RequiredFieldValidator class="serverlbl pull-left "  ID="mail" runat="server" ControlToValidate="Email" ErrorMessage="Please Enter a Email"   
ForeColor="Red"></asp:RequiredFieldValidator> 
                             <asp:RegularExpressionValidator ID="validateEmail" Style=" margin-left: -140px;" CssClass="serverlbl pull-left" runat="server" ErrorMessage="Invalid Email." ForeColor="Red" ControlToValidate="Email" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" />

                            </div>
                                
                            
 
                        
                    </div>


         <div class="row">
                        <div class="col-sm-2">  <br />
                            <label>
                                Branch Service
                            </label> <b style="color:red; font-size:large" >*</b>
                        </div>
                        <div class="col-sm-4">  <br />
                            <asp:TextBox ID="ShipService" runat="server" value="" Height="33px" width="270px" class="form-file-upload   serverlbl" MaxLength="2" /><br />
                            <asp:RequiredFieldValidator class="serverlbl "  ID="SService" runat="server" ControlToValidate="ShipService" ErrorMessage="Please Enter a Branch Service"   
ForeColor="Red"></asp:RequiredFieldValidator> 
                        </div>
                    </div>



         <div class="row">
                        <div class="col-sm-2">  <br />
                            <label>
                                Open Time
                            </label> <b style="color:red; font-size:large" >*</b>
                        </div>
                        <div class="col-sm-4">  <br />
                           
                            <asp:TextBox ID="OpenTime" CssClass=""  ToolTip="HH:mm:ss"  runat="server" value="00:00" Height="33px" width="270px" class="form-file-upload simpleExample   serverlbl" MaxLength="4" /><br />
                            <asp:RequiredFieldValidator class="serverlbl "  ID="OT" runat="server" ControlToValidate="OpenTime" ErrorMessage="Please Enter a Open Time"   
ForeColor="Red"></asp:RequiredFieldValidator> 
                        </div>
                    </div>

         <div class="row">
                        <div class="col-sm-2">  <br />
                            <label>
                                Close Time
                            </label>
                        </div>
                        <div class="col-sm-4">  <br />
                            <asp:TextBox ID="CloseTime" runat="server"  value="00:00" step="1" ToolTip="HH:mm:ss" Height="33px" width="270px" class="form-file-upload simpleExample  serverlbl" MaxLength="5" />
                           
                        </div>
                    </div>

         <div class="row">
                        <div class="col-sm-2">  <br />
                            <label>
                                Opening Date
                            </label> <b style="color:red; font-size:large" >*</b>
                        </div>
                        <div class="col-sm-4">  <br />
                            <asp:TextBox ID="OpeningDate" runat="server" value="" Height="33px"  autocomplete="off" width="270px" class="form-file-upload date  serverlbl" /><br />
                           <%--<ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" BehaviorID="OpeningDate_CalendarExtender" TargetControlID="OpeningDate" PopupPosition="TopRight"></ajaxToolkit:CalendarExtender>--%>
                        
                            <asp:RequiredFieldValidator class="serverlbl "  ID="OD" runat="server" ControlToValidate="OpeningDate" ErrorMessage="Please Enter a Opening Date"   
ForeColor="Red"></asp:RequiredFieldValidator> 
                        </div>
                    </div>


         <div class="row">
                        <div class="col-sm-2">  <br />
                            <label>
                                Closing Date
                            </label>
                        </div>
                        <div class="col-sm-4">  <br />
                            <asp:TextBox ID="ClosingDate" runat="server" value="" Height="33px" autocomplete="off" width="270px" class="form-file-upload date  serverlbl" />
                          <%-- <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" BehaviorID="ClosingDate_CalendarExtender" TargetControlID="ClosingDate" PopupPosition="Left"></ajaxToolkit:CalendarExtender>--%>
                        
                        </div>
                    </div>

         <div class="row" id="lblshipcode" runat="server">
                        <div class="col-sm-2"  >  <br />
                            <label>
                                Branch Code
                            </label> <b style="color:red; font-size:large" >*</b>
                        </div>
                        <div class="col-sm-4">  <br />
                            <asp:TextBox ID="ShipCode1" runat="server" value="" Height="33px" width="270px" class="form-file-upload   serverlbl" MaxLength="50" /><br />
                             <asp:RequiredFieldValidator class="serverlbl "  ID="SCode" runat="server" ControlToValidate="ShipCode1" ErrorMessage="Please Enter a Branch Code"   
ForeColor="Red"></asp:RequiredFieldValidator> 
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Style=" margin-left: -140px;" CssClass="serverlbl " ControlToValidate="ShipCode1" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                          </div>
                            
                             

                               
                            
                       
                    </div>

         <div class="row">
                        <div class="col-sm-2"> 
                            <br />
                            <label>
                                Branch Mark
                            </label> <b style="color:red; font-size:large" >*</b>
                        </div>
                        <div class="col-sm-4"> 
                             <br />
                            <asp:TextBox ID="ShipMark" runat="server" value="" Height="33px" width="270px" class="form-file-upload   serverlbl" MaxLength="3" /><br />
                           <asp:RequiredFieldValidator class="serverlbl "  ID="SMark" runat="server" ControlToValidate="ShipMark" ErrorMessage="Please Enter a Branch Mark"   
ForeColor="Red"></asp:RequiredFieldValidator> 
                        </div>
                    </div>

         <div class="row">
                        <div class="col-sm-2">  <br />
                            <label>
                                Item 1
                            </label> <b style="color:red; font-size:large" >*</b>
                        </div>
                        <div class="col-sm-4">  <br />
                            <asp:TextBox ID="Item1" runat="server" value="" Height="33px" width="270px" class="form-file-upload   serverlbl" MaxLength="10" /><br />
                           <asp:RequiredFieldValidator class="serverlbl "  ID="IT1" runat="server" ControlToValidate="Item1" ErrorMessage="Please Enter a Item 1"   
ForeColor="Red"></asp:RequiredFieldValidator> 
                        </div>
                    </div>

         <div class="row">
                        <div class="col-sm-2">  <br />
                            <label>
                                Item 2
                            </label> <b style="color:red; font-size:large" >*</b>
                        </div> 
                        <div class="col-sm-4">  <br />
                            <asp:TextBox ID="Item2" runat="server" value="" Height="33px" width="270px" class="form-file-upload   serverlbl" MaxLength="50" /><br />
                           <asp:RequiredFieldValidator class="serverlbl "  ID="IT2" runat="server" ControlToValidate="Item2" ErrorMessage="Please Enter a Item 2"   
ForeColor="Red"></asp:RequiredFieldValidator> 
                        </div>
                    </div>

         <div class="row">
                        <div class="col-sm-2">  <br />
                            <label>
                                Mess 1
                            </label> <b style="color:red; font-size:large" >*</b>
                        </div>
                        <div class="col-sm-4">  <br />
                            <asp:TextBox ID="Mess1" runat="server" value="" Height="33px" width="270px" class="form-file-upload   serverlbl" MaxLength="500" /><br />
                           <asp:RequiredFieldValidator class="serverlbl "  ID="M1" runat="server" ControlToValidate="Mess1" ErrorMessage="Please Enter a Mess 1"   
ForeColor="Red"></asp:RequiredFieldValidator> 
                        </div>
                    </div>


         <div class="row"> 
                        <div class="col-sm-2">   <br />
                            <label>
                                Mess 2
                            </label> <b style="color:red; font-size:large" >*</b>
                        </div>
                        <div class="col-sm-4">    <br />
                            <asp:TextBox ID="Mess2" runat="server" value="" Height="33px" width="270px" class="form-file-upload   serverlbl" MaxLength="500" /><br />
                           <asp:RequiredFieldValidator class="serverlbl "  ID="M2" runat="server" ControlToValidate="Mess2" ErrorMessage="Please Enter a Mess 2"   
ForeColor="Red"></asp:RequiredFieldValidator> 
                        </div>
                    </div>

         <div class="row">
                        <div class="col-sm-2">   <br />
                            <label>
                                Mess 3
                            </label> <b style="color:red; font-size:large" >*</b>
                        </div> 
                        <div class="col-sm-4">   <br />
                            <asp:TextBox ID="Mess3" runat="server" value="" Height="33px" width="270px" class="form-file-upload   serverlbl" MaxLength="500" /><br />
                           <asp:RequiredFieldValidator class="serverlbl "  ID="M3" runat="server" ControlToValidate="Mess3" ErrorMessage="Please Enter a Mess 3"   
ForeColor="Red"></asp:RequiredFieldValidator> 
                        </div>
                    </div>

         <div class="row">
                        <div class="col-sm-2">   <br />
                            <label>
                                Regi Deposit
                            </label>
                        </div>
                        <div class="col-sm-4">   <br />
                            <asp:TextBox ID="RegiDeposit" runat="server" value="" Height="33px" width="270px" class="form-file-upload   serverlbl" MaxLength="50" />
                           
                        </div>
                    </div>

         <div class="row">
                        <div class="col-sm-2">   <br />
                            <label>
                                PO No
                            </label> <b style="color:red; font-size:large" >*</b>
                        </div>
                        <div class="col-sm-4">   <br />
                            <asp:TextBox ID="PO_NO" runat="server" value="" Height="33px" width="270px" class="form-file-upload   serverlbl" MaxLength="2" /><br />
                           <asp:RequiredFieldValidator class="serverlbl "  ID="PoNo" runat="server" ControlToValidate="PO_NO" ErrorMessage="Please Enter a PO No"   
ForeColor="Red"></asp:RequiredFieldValidator> 
                        </div>
                    </div>

                    <div class="row" runat="server" id="del">
                        <div class="col-sm-2">   <br />
                            <label >
                                Delete flag
                            </label>
                        </div>
                        <div class="col-sm-4">   <br />
                            <asp:checkbox id="delfld" runat="server"></asp:checkbox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-2">
                             </div>
                   
                   
                            <div>   <br />
 <asp:Button ID="btnAddNew" runat="server" Text="Create" Width="80px" height="32px" class="btn btn-primary text" />
                                 <asp:Button ID="Edit"  Width="80px" height="32px" runat="server" Text="Save" class="btn btn-primary text" />
                                 <asp:Button ID="Back"  Width="80px" height="32px" runat="server"  CausesValidation="false" Text="Back" class="btn btn-primary pull-right text" />
                 
                    </div>


                    </div>
                 <div>   <br />
                          </div>     
     </div>



                    
                <div runat="server" id="data">
                     <div class="row col-sm-12">
                            <div >
                                
                                <br />
                       <%--<label> Branch Name: </label>
                                </div>
                            <div >

                                <br />
                               
                                  <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control"  AutoPostBack="true"></asp:TextBox>
                              
                                </div>
                            </div>
                    <div>--%>
                                 <label style="margin-top: 3px;"> Branch Name : </label>
                                </div>
                            <div style="margin-left: 12px;width: 178px;">

                                <br />
                               
                                  <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control"  AutoPostBack="true"></asp:TextBox>
                              
                                </div>
                         <div style="margin-top:-3px;" class="search1">
                             <br />
                             <asp:Button ID="Search" Width="80px" margin-left="23px" height="32px" margin-top="0px"  runat="server" OnClick="Search_Click1" Text="Search" class="btn btn-primary text" />
                         </div>
                         <div style="margin-left: 16px; margin-top:-3px;" >
                             <br />
                             <asp:Button ID="Clear" margin-left="120px" Width="87px" height="32px" margin-top="0px" runat="server" Text="Clear" OnClick="Clear_Click1" class="btn btn-primary text" />
                         </div>
                            </div>                   
                 <br />
                    
                    <div>
                         <br />
                        <br />
                        <br />
                         <div>
                            
                      <asp:Button ID="Create" Width="226px" runat="server" Text="Create New Service Center" class="btn btn-primary text" />
                  </div>
                        
                        <br/>
                              <div class="table-responsive">
                            <asp:GridView ID="getdata" runat="server" AutoGenerateColumns="false" CellPadding="10"   AllowPaging="true" PageSize="10" OnPageIndexChanging="getdata_PageIndexChanging" OnRowCommand="getdata_RowCommand1"
                Style="align-self: center; font-size:14px"   HeaderStyle-BackColor="#8e24aa"   OnSorting="getdata_Sorting" AllowSorting="true" HeaderStyle-ForeColor="White"  CssClass="col-sm-12" ShowHeaderWhenEmpty="true" EmptyDataText="No records Found">
                                
               <PagerStyle HorizontalAlign = "left" CssClass = "GridPager" />


                <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                
                <EmptyDataRowStyle HorizontalAlign="Center"  />
                                

                             <Columns>
        <%--<asp:BoundField DataField="SHIP_NAME" HeaderText="Ship Name" />
        <asp:BoundField DataField="SHIP_INFO" HeaderText="Ship Info" />
        <asp:BoundField DataField="SHIP_MANAGER" HeaderText="Ship Manager" />
        <asp:BoundField DataField="SHIP_SERVICE" HeaderText="Ship Service " />
        <asp:BoundField DataField="SHIP_CODE" HeaderText="Ship Code" />
        <asp:BoundField DataField="SHIP_MARK" HeaderText="ship Mark" />
        <asp:BoundField DataField="DELFG" HeaderText="Delflg" />--%>


                                   <asp:TemplateField HeaderText="Branch Code" HeaderStyle-CssClass="sort" ItemStyle-HorizontalAlign="Right" SortExpression="SHIP_CODE"  >
                        <ItemTemplate>
                            <asp:Label ID="SHIP_CODE1" runat="server" Text='<%# Eval("SHIP_CODE") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle ></ItemStyle>
                    </asp:TemplateField>





                                 <asp:TemplateField HeaderText="Branch Name" HeaderStyle-CssClass="sort" SortExpression="SHIP_NAME" >
                        <ItemTemplate>
                            <asp:Label ID="SHIP_NAME" runat="server" Text='<%# Eval("SHIP_NAME") %>'></asp:Label>
                        </ItemTemplate>
                        <%--<ItemTemplate>
                            <asp:Label ID="SHIP_NAME" runat="server" Text='<%# Eval("SHIP_NAME") %>'></asp:Label>
                        </ItemTemplate>--%>
                        <ItemStyle ></ItemStyle>
                    </asp:TemplateField>


                                  <asp:TemplateField HeaderText="Branch Info" HeaderStyle-CssClass="sort" SortExpression="SHIP_INFO" >
                        <ItemTemplate>
                            <asp:Label ID="SHIP_INFO" runat="server" Text='<%# Eval("SHIP_INFO") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle ></ItemStyle>
                    </asp:TemplateField>

                                  <asp:TemplateField HeaderText="Branch Manager" HeaderStyle-CssClass="sort" SortExpression="SHIP_MANAGER" >
                        <ItemTemplate>
                            <asp:Label ID="SHIP_MANAGER" runat="server" Text='<%# Eval("SHIP_MANAGER") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle ></ItemStyle>
                    </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Branch Service" HeaderStyle-CssClass="sort" SortExpression="SHIP_SERVICE">
                        <ItemTemplate>
                            <asp:Label ID="SHIP_SERVICE" runat="server" Text='<%# Eval("SHIP_SERVICE") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle ></ItemStyle>
                    </asp:TemplateField>





                                 <asp:TemplateField HeaderText="Branch Mark" HeaderStyle-CssClass="sort" SortExpression="SHIP_MARK" >
                        <ItemTemplate>
                            <asp:Label ID="SHIP_MARK" runat="server" Text='<%# Eval("SHIP_MARK") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle ></ItemStyle>
                    </asp:TemplateField>


                                  <%--<asp:TemplateField HeaderText="SHIP_TEL" ItemStyle-Width="150" visible="false">
                        <ItemTemplate>
                            <asp:Label ID="SHIP_TEL" runat="server" Text='<%# Eval("SHIP_TEL") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle ></ItemStyle>
                    </asp:TemplateField>--%>




                                 <asp:TemplateField HeaderText="DELFG" HeaderStyle-CssClass="sort" SortExpression="DELFG" >
                        <ItemTemplate>
                            <asp:Label ID="DELFG" runat="server" Text='<%# Eval("DELFG") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle></ItemStyle>
                    </asp:TemplateField>

                  <%--<asp:TemplateField HeaderText="EDIT" ItemStyle-Width="150">--%>
                      <asp:TemplateField >
                        <ItemTemplate>
                            <asp:LinkButton ID="SHIP_CODE" runat="server" CommandArgument='<%# Bind("SHIP_CODE") %>' CommandName="goto" Text="Edit"></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle ></ItemStyle>
                    </asp:TemplateField>

                                <%--<asp:TemplateField >
                                       <ItemTemplate>
                                           <asp:Button id="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" />
                                       </ItemTemplate>
                                   </asp:TemplateField>--%>

                                 <%--<asp:TemplateField >
                                       <ItemTemplate>
                                           <asp:Button id="btnView" runat="server" Text="View" onclick="btnView_Click" />
                                       </ItemTemplate>
                                   </asp:TemplateField>

                                 <asp:TemplateField>--%>
                 <asp:TemplateField>
                     <ItemTemplate>
                   <%-- <asp:HyperLink ID="lnkView"  Text="View" NavigateUrl="#" runat="server"  />--%>
                         <%--<asp:HyperLink ID="lnkView"  Text="View" NavigateUrl="#" runat="server"  OnClick='<%#Eval("ship_code", "test.js(""){0}"");")%>'/>--%>
                        <asp:LinkButton ID="lnkView" runat="server" data-CommandArgument='<%# Eval("SHIP_CODE") %>'  Text="View"></asp:LinkButton>
                   </ItemTemplate>
                </asp:TemplateField>
                  <%--<asp:TemplateField>--%>
                                   
    </Columns>
                        </asp:GridView>

                    </div>
                        </div>
                </div>
                
                
                </div>
                  </div>
                </div>
              </div>
            </div>
        </div>
       </div>
     
    
        <asp:Button ID="BtnCancel" runat="server" Text="Button" Style="display: none;" />
        <asp:Button ID="BtnOK" runat="server" Text="Button" Style="display: none;" />

   

   
      <div style="margin-top:500px;">        
   
     <div id="dialog" title="Setup new service center" style="display: none;">
       
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </div>
 </div>


</asp:Content>

