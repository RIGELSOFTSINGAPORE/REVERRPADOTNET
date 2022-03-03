<%@ Page Title="Change Password" Language="vb" AutoEventWireup="false" MasterPageFile="~/Analysis.Master" CodeBehind="Changepassword.aspx.vb" Inherits="Ganges33.Changepassword" %>

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
    <style type="text/css">

        .container{
    -ms-overflow-style: none;
    overflow: auto;
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
                  <h3 class="card-title ">Change Password</h3>
                  <p class="card-category"></p>
                </div>
                <div class="card-body " >

                    <div class="row">
                        <div class="col-sm-2">
                            <br />
                        <label>
                            Old Password
                        </label>
                             </div>
                        <div class="col-sm-2">
                             <br />
                        <asp:textbox runat="server" TextMode="Password" CssClass="serverlbl form-control" id="oldpwd"></asp:textbox>
                            </div>
                    </div>
                    
                    <div class="row">
                        <div class="col-sm-2">
                             <br />
                            <label>
                                New Password
                            </label>
                        </div>
                       <div class="col-sm-2">
                            <br />
                           <asp:TextBox runat="server" TextMode="Password" CssClass="serverlbl form-control" ID="newpwd"></asp:TextBox>
                       </div>

                    </div>
                    <div class="row">
                        <div class="col-sm-2">
                             <br />
                            <label>
                                Confirm password
                            </label>
                        </div>
                        <div class="col-sm-2">
                             <br />
                            <asp:TextBox runat="server" TextMode="Password" CssClass="serverlbl form-control" ID="canpwd"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-2"></div>
                        <div class="col-sm-2">
                             <br />
                        <asp:Button ID="send" runat="server" CssClass="btn btn-primary" Text="Submit" />
                            </div>
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

