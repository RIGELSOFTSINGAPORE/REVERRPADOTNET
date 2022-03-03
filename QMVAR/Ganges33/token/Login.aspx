<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Login.aspx.vb" Inherits="Ganges33.Login1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.0/jquery.min.js"></script>
    <link type="text/css" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1/themes/start/jquery-ui.css" rel="stylesheet">
     <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1/jquery-ui.min.js"></script>

   

    <link href="../assets/jquery-ui_theme.css" rel="stylesheet" />
    <link href="../assets/jquery-ui.css" rel="stylesheet" />
    <script type="text/javascript"  src="../assets/jquery-ui.min_lips.js"></script>


  

     <link href="../CSS/Common/Login.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/login.css" rel="stylesheet" />

    <link href="../CSS/Common/Login.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/login.css" rel="stylesheet" />


    <meta charset="utf-8" />
  <link rel="apple-touch-icon" sizes="76x76" href="../assets/img/apple-icon.png">
  <link rel="icon" type="image/png" href="../assets/img/favicon.png">
  <meta http-equiv="X-UA-Compatible" name="msapplication-tap-highlight" content="IE=edge,chrome=1" />
  
  <meta content='width=device-width, initial-scale=1.0, shrink-to-fit=no' name='viewport' />

<title>Login - QMVAR</title>
<meta content="" name="descriptison">
<meta content="" name="keywords">
<!-- Favicons 
<link href="assets/img/faviconn.png" rel="icon">
<link href="assets/img/apple-touch-iconn.png" rel="apple-touch-iconn">-->

<!-- Google Fonts -->
<link href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i|Roboto:300,300i,400,400i,500,500i,600,600i,700,700i|Poppins:300,300i,400,400i,500,500i,600,600i,700,700i" rel="stylesheet">

<!-- Vendor CSS Files -->
<link href="../assets/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
<link href="../assets/vendor/icofont/icofont.min.css" rel="stylesheet">
<link href="../assets/vendor/boxicons/css/boxicons.min.css" rel="stylesheet">
<link href="../assets/vendor/animate.css/animate.min.css" rel="stylesheet">
<link href="../assets/vendor/venobox/venobox.css" rel="stylesheet">
<link href="../assets/vendor/owl.carousel/assets/owl.carousel.min.css" rel="stylesheet">
<link href="../assets/vendor/aos/aos.css" rel="stylesheet">
<link href="../assets/vendor/remixicon/remixicon.css" rel="stylesheet">

<!-- Template Main CSS File -->
<link href="../assets/css/login.css" rel="stylesheet">


    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class="workSpace">
        
        
            <div class="avatar">
                
                    <img style="width: 70px;margin-top: 24px;margin-left: 29px; " src="../assets/image/user.png">
                              <div id="infinity"></div>
            </div>
                
                
                <div class="left">
                    <img src="../assets/image/gss-logo.png" alt="responsive" style="height: 53px;width: 222px;">
                
                
            </div>   
                        
            <div class="right">
                    <h1>QMVAR- <asp:Label ID="lblServer" runat="server" Text=" " ></asp:Label> </h1>
                       <asp:TextBox ID="TextId" placeholder="User ID" class="input" runat="server"></asp:TextBox>
                    <asp:TextBox ID="TextPass" runat="server" class="input" placeholder="Password" autocomplete = "OFF" TextMode="Password" Visible="false" ></asp:TextBox>
                        
                        <span class="checkmark"></span>
                        
                          <asp:Button ID="BtnSubmit" runat="server" text="Log In" class="button"/>
      
                  <asp:DropDownList ID="DropListLocation" placeholder="Location" class="input dropdwn" style=" width: 224px;  height: 30px;" runat="server" visible="false" >
            </asp:DropDownList>
                      
                     <asp:Button ID="BtnLogin" runat="server" text="Log In1" class="button" visible="false" />
      
				<br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
                        
     

                
            </div> 
       
        </div>
    <asp:Button ID="BtnCancel" runat="server" Text="Button" Style="display: none;" />
        <asp:Button ID="BtnOK" runat="server" Text="Button" Style="display: none;" />

   
   
      <div id="dialog" title="message" style="display: none;">
       
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </div>
 </asp:Content>
<%--<asp:Button ID="Button1" runat="server" Text="Button" style="display:none;" />
      
        <p align = "right">
            <asp:Label ID="Label1" runat="server" Text="QMVAR-" CssClass="lbl-QMVAR-UserID-Password-Location"></asp:Label>
            <asp:Label ID="" runat="server" Text=" " CssClass="lbl-QMVAR-UserID-Password-Location"></asp:Label>
        <br />
            <asp:Label ID="Label2" runat="server" Text="UserID" CssClass="lbl-QMVAR-UserID-Password-Location"></asp:Label>
      
        <br />
            <asp:Label ID="Label3" runat="server" Text="Password" CssClass="lbl-QMVAR-UserID-Password-Location"></asp:Label>
            
        <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Location" CssClass="lbl-QMVAR-UserID-Password-Location"></asp:Label>
            
        <br />
             </p>--%>

