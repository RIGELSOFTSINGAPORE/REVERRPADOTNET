<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Popup.aspx.vb" Inherits="Ganges33.Popup" %>
<meta content='width=device-width, initial-scale=1.0, shrink-to-fit=no' name='viewport' />
    <%--<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.0/jquery.min.js"></script>
    <link type="text/css" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1/themes/start/jquery-ui.css" rel="stylesheet">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1/jquery-ui.min.js"></script>--%>
   
  <!--     Fonts and icons     -->
  <%--<link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700|Roboto+Slab:400,700|Material+Icons" />
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/latest/css/font-awesome.min.css">--%>

<script type="text/javascript" src="ExternalStyles/Jquery/a076d05399.js"></script>
<script type="text/javascript" src="ExternalStyles/Jquery/jquery.min.js"></script>
    <script type="text/javascript" src="ExternalStyles/Jquery/jquery-ui.min.js"></script>
    <script type="text/javascript" src="ExternalStyles/Jquery/ajaxlibs.js"></script>



    <link href="ExternalStyles/Css/css.css" rel="stylesheet" />  
    <link href="ExternalStyles/Css/font-awesome.min.css" rel="stylesheet" />  
    <link href="ExternalStyles/Css/jquery-ui.css" rel="stylesheet" />  

  <!-- CSS Files -->
 <link href="assets/css/material-dashboard-rtl.css" rel="stylesheet" />
<link href="assets/css/material-dashboard.css" rel="stylesheet" />
<link href="assets/css/material-dashboard.min.css" rel="stylesheet" />
  <%--<script src='https://kit.fontawesome.com/a076d05399.js'></script>--%>
  <link href="assets/demo/demo.css" rel="stylesheet" />
   <%--<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.0/jquery.min.js"></script>
    <link type="text/css" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1/themes/start/jquery-ui.css" rel="stylesheet">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1/jquery-ui.min.js"></script>--%>
	 <link href="Styles/bootstrap.min.css"  rel="stylesheet" type="text/css"/>
    <script type="text/javascript" src="Scripts/bootstrap.min.js"></script>
    <link href="Styles/bootstrap-multiselect.css" rel="stylesheet" type="text/css"/>
    <script src="Scripts/bootstrap-multiselect.js" type="text/javascript"></script>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head  class="serverlbl " runat="server">
    <title></title>
    <!--<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>-->
   <%-- <script>
        $(function () {
            if (window.open != null) {
                var rowIndex = window.location.href.split("?")[1].split("=")[1];
                var parent = $(window.opener.document).contents();
                var row = parent.find("[id*=getdata]").find("tr").eq(rowIndex);
                $("#shop_code").html(row.find("td").eq(0).html());
                $("#CRTDT").html(row.find("td").eq(1).html());
                $("#CRTCD").html(row.find("td").eq(2).html());
                $("#UPDDT").html(row.find("td").eq(3).html());
                $("#UPDCD").html(row.find("td").eq(4).html());
                $("#UPDPG").html(row.find("td").eq(5).html());
                $("#DELFG").html(row.find("td").eq(6).html());
                $("#ship_name").html(row.find("td").eq(7).html());


            }

        }); 

    </script>--%>
    <style>
      
    </style>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <style type="text/css">
  .btnalign{
            padding: 0px;
    width: 96px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">


         
   <div class="wrapper  col-sm-12 sidebar-wrapper position-fixed scrolbar contain" id="style-10">
   
    <div class="content" >
        <div class="container-fluid">
          <div class="row">
            <div class="col-md-12">
              <div class="card">
                <div class="card-header card-header-primary">
                 <%-- <h3 class="card-title ">Setup New Servicecenter</h3>--%>
                    <h3 class="card-title " >
                    View - Service Center
                  </h3>
                 
                </div>
                <div class="card-body " >

                     <asp:Button ID="btnback" runat="server" CausesValidation="false" Text="Close" OnClientClick="javascript:window.close()"  class="btn pull-right btn-primary btnalign" />
           
<table>


<tr>
<td  class="serverlbl" style="font-weight:bold">CRTDT:</td>
<td>
<asp:Label ID="lblCRTDT1" class="serverlbl " runat="server"></asp:Label></td>
</tr>
<tr >
<td class="serverlbl" style="font-weight:bold">CRTCD:</td>
<td>
<asp:Label ID="lblCRTCD1"  class="serverlbl " runat="server"></asp:Label></td>
</tr>

<tr>
<td class="serverlbl" style="font-weight:bold">UPDDT:</td>
<td>
<asp:Label ID="lblUPDDT1"  class="serverlbl " runat="server"></asp:Label></td>
</tr>

<tr>
<td class="serverlbl" style="font-weight:bold">UPDCD:</td>
<td>
<asp:Label ID="lblUPDCD1"  class="serverlbl " runat="server"></asp:Label></td>
</tr>


<tr >
<td class="serverlbl" style="font-weight:bold">UPDPG:</td>
<td>
<asp:Label ID="lblUPDPG1"  class="serverlbl " runat="server"></asp:Label></td>
</tr>

<tr>
<td class="serverlbl" style="font-weight:bold">DELFG:</td>
<td>
<asp:Label ID="lblDELFG1"  class="serverlbl " runat="server"></asp:Label></td>
</tr>


<tr>
<td class="serverlbl" style="font-weight:bold">Branch_Name:</td>
<td>
<asp:Label ID="lblship_name1"  class="serverlbl " runat="server"></asp:Label></td>
</tr>


<tr>
<td class="serverlbl" style="font-weight:bold">Branch_Info:</td>
<td>
<asp:Label ID="lblship_info1"  class="serverlbl " runat="server"></asp:Label></td>
</tr>


<tr>
<td class="serverlbl" style="font-weight:bold">Branch_Manager:</td>
<td>
<asp:Label ID="lblship_manager1"  class="serverlbl " runat="server"></asp:Label></td>
</tr>


<tr>
<td class="serverlbl" style="font-weight:bold">Branch_Tel:</td>
<td>
<asp:Label ID="lblship_tel1"  class="serverlbl " runat="server"></asp:Label></td>
</tr>

<tr>
<td class="serverlbl" style="font-weight:bold">Branch_Add1:</td>
<td>
<asp:Label ID="lblship_add11"  class="serverlbl " runat="server"></asp:Label></td>
</tr>

<tr>
<td class="serverlbl" style="font-weight:bold">Branch_Add2:</td>
<td>
<asp:Label ID="lblship_add21"  class="serverlbl " runat="server"></asp:Label></td>
</tr>

<tr>
<td class="serverlbl" style="font-weight:bold">Branch_Add3:</td>
<td>
<asp:Label ID="lblship_add31"  class="serverlbl " runat="server"></asp:Label></td>
</tr>

<tr>
<td class="serverlbl" style="font-weight:bold">zip:</td>
<td>
<asp:Label ID="lblzip1"  class="serverlbl " runat="server"></asp:Label></td>
</tr>

<tr>
<td class="serverlbl" style="font-weight:bold">E_Mail:</td>
<td>
<asp:Label ID="lble_mail1"  class="serverlbl " runat="server"></asp:Label></td>
</tr>

<tr>
<td class="serverlbl" style="font-weight:bold">Branch_Service:</td>
<td>
<asp:Label ID="lblship_service1"  class="serverlbl " runat="server"></asp:Label></td>
</tr>


<tr>
<td class="serverlbl" style="font-weight:bold">Open_Time:</td>
<td>
<asp:Label ID="lblopen_time1"  class="serverlbl " runat="server"></asp:Label></td>
</tr>


<tr>
<td class="serverlbl" style="font-weight:bold">Close_Time:</td>
<td>
<asp:Label ID="lblclose_time1"  class="serverlbl " runat="server"></asp:Label></td>
</tr>

<tr>
<td class="serverlbl" style="font-weight:bold">Opening_Date:</td>
<td>
<asp:Label ID="lblopening_date1"  class="serverlbl " runat="server"></asp:Label></td>
</tr>

<tr>
<td class="serverlbl" style="font-weight:bold">Closing_Date:</td>
<td>
<asp:Label ID="lblclosing_date1"  class="serverlbl " runat="server"></asp:Label></td>
</tr>

<tr>
<td class="serverlbl" style="font-weight:bold">Branch_Code:</td>
<td>
<asp:Label ID="lblship_code1"  class="serverlbl " runat="server"></asp:Label></td>
</tr>


<tr>
<td class="serverlbl" style="font-weight:bold">Branch_Mark:</td>
<td>
<asp:Label ID="lblship_mark1"  class="serverlbl " runat="server"></asp:Label></td>
</tr>


<tr>
<td class="serverlbl" style="font-weight:bold">Item_1:</td>
<td>
<asp:Label ID="lblitem_11"  class="serverlbl " runat="server"></asp:Label></td>
</tr>


<tr>
<td class="serverlbl" style="font-weight:bold">Item_2:</td>
<td>
<asp:Label ID="lblitem_21"  class="serverlbl " runat="server"></asp:Label></td>
</tr>


<tr>
<td class="serverlbl" style="font-weight:bold">Mess_1:</td>
<td>
<asp:Label ID="lblmess_11"  class="serverlbl " runat="server"></asp:Label></td>
</tr>

<tr>
<td class="serverlbl" style="font-weight:bold">Mess_2:</td>
<td>
<asp:Label ID="lblmess_21"  class="serverlbl " runat="server"></asp:Label></td>
</tr>

    <tr>
<td class="serverlbl" style="font-weight:bold">Mess_3:</td>
<td>
<asp:Label ID="lblmess_31"  class="serverlbl " runat="server"></asp:Label></td>
</tr>

<tr>
<td class="serverlbl" style="font-weight:bold">Regi_Deposit:</td>
<td>
<asp:Label ID="lblregi_deposit1"  class="serverlbl " runat="server"></asp:Label></td>
</tr>

<tr>
<td class="serverlbl" style="font-weight:bold">PO_No:</td>
<td>
<asp:Label ID="lblPO_no1"  class="serverlbl " runat="server"></asp:Label></td>
</tr>

<%--<tr>
<td class="serverlbl" style="font-weight:bold">Inspection1_Start:</td>
<td>
<asp:Label ID="lblinspection1_start1"  class="serverlbl " runat="server"></asp:Label></td>
</tr>

<tr>
<td class="serverlbl" style="font-weight:bold">Inspection1_End:</td>
<td>
<asp:Label ID="lblinspection1_end1"  class="serverlbl " runat="server"></asp:Label></td>
</tr>

<tr>
<td class="serverlbl" style="font-weight:bold">Inspection2_Start:</td>
<td>
<asp:Label ID="lblinspection2_start1"  class="serverlbl " runat="server"></asp:Label></td>
</tr>

<tr>
<td class="serverlbl" style="font-weight:bold">Inspection2_End:</td>
<td>
<asp:Label ID="lblinspection2_end1"  class="serverlbl " runat="server"></asp:Label></td>
</tr>

<tr>
<td class="serverlbl" style="font-weight:bold">Inspection3_Start:</td>
<td>
<asp:Label ID="lblinspection3_start1"  class="serverlbl " runat="server"></asp:Label></td>
</tr>

<tr>
<td class="serverlbl" style="font-weight:bold">Inspection3_End:</td>
<td>
<asp:Label ID="lblinspection3_end1"  class="serverlbl " runat="server"></asp:Label></td>
</tr>


<tr>
<td class="serverlbl" style="font-weight:bold">Open_Start:</td>
<td>
<asp:Label ID="lblopen_start1"  class="serverlbl " runat="server"></asp:Label></td>
</tr>

<tr>
<td class="serverlbl" style="font-weight:bold">Open_End:</td>
<td>
<asp:Label ID="lblopen_end1"  class="serverlbl " runat="server"></asp:Label></td>
</tr>

<tr>
<td class="serverlbl" style="font-weight:bold">Close_Start:</td>
<td>
<asp:Label ID="lblclose_start1"  class="serverlbl " runat="server"></asp:Label></td>
</tr>

<tr>
<td class="serverlbl" style="font-weight:bold">Close_End:</td>
<td>
<asp:Label ID="lblclose_end1"  class="serverlbl " runat="server"></asp:Label></td>
</tr>

<tr>
<td class="serverlbl" style="font-weight:bold">GSTIN:</td>
<td>
<asp:Label ID="lblGSTIN1"  class="serverlbl " runat="server"></asp:Label></td>
</tr>

<tr>
<td class="serverlbl" style="font-weight:bold">Parent_Ship_Name:</td>
<td>
<asp:Label ID="lblParent_Ship_Name1"  class="serverlbl " runat="server"></asp:Label></td>
</tr>

<tr>
<td class="serverlbl" style="font-weight:bold">IsChildShip:</td>
<td>
<asp:Label ID="lblIsChildShip1"  class="serverlbl " runat="server"></asp:Label></td>
</tr>

<tr>
<td class="serverlbl" style="font-weight:bold">RpaClientUserId:</td>
<td>
<asp:Label ID="lblRpaClientUserId1"  class="serverlbl " runat="server"></asp:Label></td>
</tr>

<tr>
<td class="serverlbl" style="font-weight:bold">RpaClientPwd:</td>
<td>
<asp:Label ID="lblRpaClientPwd1"  class="serverlbl " runat="server"></asp:Label></td>
</tr>

<tr>
<td class="serverlbl" style="font-weight:bold">PwdUpdatedDate:</td>
<td>
<asp:Label ID="lblpwdupdateddate1"  class="serverlbl " runat="server"></asp:Label></td>
</tr>

<tr>
<td class="serverlbl" style="font-weight:bold">IsShipCodeChanged:</td>
<td>
<asp:Label ID="lblIsShipCodeChanged1"  class="serverlbl " runat="server"></asp:Label></td>
</tr>--%>

    </table>

                    </div>
                  </div>
                
                </div>
              </div>
            </div>
        </div>
       </div>
        






         <div>
<h1></h1>
        <%--<div>
       
                <%--<div class="popupwin">
            <h1>Service Center Details</h1>

            
            <table border = "1">
         <tr>
            <th>CRTDT</th>
            <th>CRTCD</th>
             <th>UPDDT</th>
             <th>UPDCD</th>
             <th>UPDPG</th>
             <th>DELFG</th>
             <th>ship_name</th>
             <th>ship_info</th>
             <th>ship_manager</th>
             <th>ship_tel</th>
             <th>ship_add1</th>
             <th>ship_add2</th>
             <th>ship_add3</th>
             <th>zip</th>
             <th>e_mail</th>
             <th>ship_service</th>
             <th>open_time</th>
             <th>close_time</th>
             <th>opening_date</th>
             <th>closing_date</th>
             <th>ship_code</th>
             <th>ship_mark</th>
             <th>item_1</th>
             <th>item_2</th>
             <th>mess_1</th>
             <th>mess_2</th>
             <th>mess_3</th>
             <th>regi_deposit</th>
             <th>PO_no</th>
             <th>inspection1_start</th>
             <th>inspection1_end</th>
             <th>inspection2_start</th>
             <th>inspection2_end</th>
             <th>inspection3_start</th>
             <th>inspection3_end</th>
             <th>open_start</th>
             <th>open_end</th>
             <th>close_start</th>
             <th>close_end</th>
             <th>GSTIN</th>
             <th>Parent_Ship_Name</th>
             <th>IsChildShip</th>
             <th>RpaClientUserId</th>
             <th>RpaClientPwd</th>
             <th>pwdupdateddate</th>
             <th>IsShipCodeChanged</th>
            

         </tr>
         <tr>
            <td>
             <label id="lblCRTDT" runat="server" ></label>
            </td>
            <td><label id="lblCRTCD" runat="server" ></label></td>
             <td><label id="lblUPDDT" runat="server" ></label></td>
             <td><label id="lblUPDCD" runat="server" ></label></td>
             <td><label id="lblUPDPG" runat="server" ></label></td>
             <td><label id="lblDELFG" runat="server" ></label></td>
             <td><label id="lblship_name" runat="server" ></label></td>
             <td><label id="lblship_info" runat="server" ></label></td>
             <td><label id="lblship_manager" runat="server" ></label></td>
             <td><label id="lblship_tel" runat="server" ></label></td>
             <td><label id="lblship_add1" runat="server" ></label></td>
             <td><label id="lblship_add2" runat="server" ></label></td>
             <td><label id="lblship_add3" runat="server" ></label></td>
             <td><label id="lblzip" runat="server" ></label></td>
             <td><label id="lble_mail" runat="server" ></label></td>
             <td><label id="lblship_service" runat="server" ></label></td>
             <td><label id="lblopen_time" runat="server" ></label></td>
             <td><label id="lblclose_time" runat="server" ></label></td>
             <td><label id="lblopening_date" runat="server" ></label></td>
             <td><label id="lblclosing_date" runat="server" ></label></td>
             <td><label id="lblship_code" runat="server" ></label></td>
             <td><label id="lblship_mark" runat="server" ></label></td>
             <td><label id="lblitem_1" runat="server" ></label></td>
             <td><label id="lblitem_2" runat="server" ></label></td>
             <td><label id="lblmess_1" runat="server" ></label></td>
             <td><label id="lblmess_2" runat="server" ></label></td>
             <td><label id="lblmess_3" runat="server" ></label></td>
             <td><label id="lblregi_deposit" runat="server" ></label></td>
             <td><label id="lblPO_no" runat="server" ></label></td>
             <td><label id="lblinspection1_start" runat="server" ></label></td>
             <td><label id="lblinspection1_end" runat="server" ></label></td>
             <td><label id="lblinspection2_start" runat="server" ></label></td>
             <td><label id="lblinspection2_end" runat="server" ></label></td>
             <td><label id="lblinspection3_start" runat="server" ></label></td>
             <td><label id="lblinspection3_end" runat="server" ></label></td>
             <td><label id="lblopen_start" runat="server" ></label></td>
             <td><label id="lblopen_end" runat="server" ></label></td>
             <td><label id="lblclose_start" runat="server" ></label></td>
             <td><label id="lblclose_end" runat="server" ></label></td>
             <td><label id="lblGSTIN" runat="server" ></label></td>
             <td><label id="lblParent_Ship_Name" runat="server" ></label></td>
             <td><label id="lblIsChildShip" runat="server" ></label></td>
             <td><label id="lblRpaClientUserId" runat="server" ></label></td>
             <td><label id="lblRpaClientPwd" runat="server" ></label></td>
             <td><label id="lblpwdupdateddate" runat="server" ></label></td>
             <td><label id="lblIsShipCodeChanged" runat="server" ></label></td>



         </tr>
         
         
      </table>--%>



  


























       <%-- <br />--%>
        <%--<br />



        <b>CRTDT :</b> <span id="CRTDT" runat="server" ></span>
                    <label id="lblCRTDT" runat="server" ></label>
                    
        <br />
        


        <b>CRTCD:</b> <span id="CRTCD"></span>
                     <label id="lblCRTCD" runat="server" ></label>

        <br />
        <b>UPDDT:</b> <span id="UPDDT"></span>
                     <label id="lblUPDDT" runat="server" ></label>
            <br />
        <b>UPDCD:</b> <span id="UPDCD"></span>
                     <label id="lblUPDCD" runat="server" ></label>
            <br />
        <b>UPDPG:</b> <span id="UPDPG"></span>
                     <label id="lblUPDPG" runat="server" ></label>
            <br />
        <b>DELFG:</b> <span id="DELFG"></span>
                     <label id="lblDELFG" runat="server" ></label>
            <br />
        <b>Ship Name:</b> <span id="ship_name"></span>
                     <label id="lblship_name" runat="server" ></label>
            <br />
        <b>Ship Info:</b> <span id="ship_info"></span>
                     <label id="lblship_info" runat="server" ></label>
            <br />
        <b>Ship Manager:</b> <span id="ship_manager"></span>
                    <label id="lblship_manager" runat="server" ></label>
            <br />
        <b>Ship Tel:</b> <span id="ship_tel"></span>
                    <label id="lblship_tel" runat="server" ></label>
            <br />
        <b>Ship Add1:</b> <span id="ship_add1"></span>
                    <label id="lblship_add1" runat="server" ></label>
            <br />
        <b>Ship Add2:</b> <span id="ship_add2"></span>
                    <label id="lblship_add2" runat="server" ></label>
            <br />
        <b>Ship Add3:</b> <span id="ship_add3"></span>
                    <label id="lblship_add3" runat="server" ></label>
            <br />
        <b>zip:</b> <span id="zip"></span>
                    <label id="lblzip" runat="server" ></label>
            <br />
        <b>Email:</b> <span id="e_mail"></span>
                    <label id="lble_mail" runat="server" ></label>
            <br />
        <b>Ship Service:</b> <span id="ship_service"></span>
                    <label id="lblship_service" runat="server" ></label>
            <br />
            <b>Open Time:</b> <span id="open_time"></span>
                    <label id="lblopen_time" runat="server" ></label>
            <br />
            <b>Close Time:</b> <span id="close_time"></span>
                    <label id="lblclose_time" runat="server" ></label>
            <br />
            <b>Opening Date:</b> <span id="opening_date"></span>
                    <label id="lblopening_date" runat="server" ></label>
            <br />
            <b>Closing Date:</b> <span id="closing_date"></span>
                    <label id="lblclosing_date" runat="server" ></label>
            <br />
            <b>Ship Code:</b> <span id="ship_code"></span>
                    <label id="lblship_code" runat="server" ></label>
            <br />
            <b>Ship Mark:</b> <span id="ship_mark"></span>
                    <label id="lblship_mark" runat="server" ></label>
            <br />
            <b>Item 1:</b> <span id="item_1"></span>
                    <label id="lblitem_1" runat="server" ></label>
            <br />
            <b>Item 2:</b> <span id="item_2"></span>
                    <label id="lblitem_2" runat="server" ></label>
            <br />
            <b>Mess 1:</b> <span id="mess_1"></span>
                    <label id="lblmess_1" runat="server" ></label>
            <br />
            <b>Mess 2:</b> <span id="mess_2"></span>
                    <label id="lblmess_2" runat="server" ></label>
            <br />
            <b>Mess 3:</b> <span id="mess_3"></span>
                    <label id="lblmess_3" runat="server" ></label>
            <br />
            <b>Regi Deposit:</b> <span id="regi_deposit"></span>
                    <label id="lblregi_deposit" runat="server" ></label>
            <br />
            <b>PO no:</b> <span id="PO_no"></span>
                    <label id="lblPO_no" runat="server" ></label>
            <br />
            <b>Inspection1 Start:</b> <span id="inspection1_start"></span>
                    <label id="lblinspection1_start" runat="server" ></label>
            <br />
            <b>Inspection1 End:</b> <span id="inspection1_end"></span>
                    <label id="lblinspection1_end" runat="server" ></label>
            <br />
            <b>Inspection2 Start:</b> <span id="inspection2_start"></span>
                    <label id="lblinspection2_start" runat="server" ></label>
            <br />
            <b>Inspection2 End:</b> <span id="inspection2_end"></span>
                    <label id="lblinspection2_end" runat="server" ></label>
            <br />
            <b>Inspection3 Start:</b> <span id="inspection3_start"></span>
                    <label id="lblinspection3_start" runat="server" ></label>
            <br />
            <b>Inspection3 End:</b> <span id="inspection3_end"></span>
                    <label id="lblinspection3_end" runat="server" ></label>
            <br />
            <b>Open Start:</b> <span id="open_start"></span>
                    <label id="lblopen_start" runat="server" ></label>
            <br />
            <b>Open End:</b> <span id="open_end"></span>
                    <label id="lblopen_end" runat="server" ></label>
            <br />
            <b>Close Start:</b> <span id="close_start"></span>
                    <label id="lblclose_start" runat="server" ></label>
            <br />
            <b>Close End:</b> <span id="close_end"></span>
                    <label id="lblclose_end" runat="server" ></label>
            <br />
            <b>GSTIN:</b> <span id="GSTIN"></span>
                    <label id="lblGSTIN" runat="server" ></label>
            <br />
            <b>Parent Ship Name:</b> <span id="Parent_Ship_Name"></span>
                    <label id="lblParent_Ship_Name" runat="server" ></label>
            <br />
            <b>IsChildShip:</b> <span id="IsChildShip"></span>
                    <label id="lblIsChildShip" runat="server" ></label>
            <br />
            <b>RpaClientUserId:</b> <span id="RpaClientUserId"></span>
                    <label id="lblRpaClientUserId" runat="server" ></label>
            <br />
            <b>RpaClientPwd:</b> <span id="RpaClientPwd"></span>
                    <label id="lblRpaClientPwd" runat="server" ></label>
            <br />
            <b>PwdUpdatedDate:</b> <span id="pwdupdateddate"></span>
                    <label id="lblpwdupdateddate" runat="server" ></label>
            <br />
             <b>IsShipCodeChanged:</b> <span id="IsShipCodeChanged"></span>
                    <label id="lblIsShipCodeChanged" runat="server" ></label>
            <br />
        --%>     <%--</div>--%>
           

            
     <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
        <%--<script type="text/javascript">
            $(function () {
                if (window.opener != null && !window.opener.closed) {
                    var rowIndex = window.location.href.split("?")[1].split("=")[1];
                    var parent = $(window.opener.document).contents();
                    var row = parent.find("[id*=getdata]").find("tr").eq(rowIndex);
                    $("#CRTDT").html(row.find("td").eq(0).html());
                    $("#CRTCD").html(row.find("td").eq(1).html());
                    $("#UPDDT").html(row.find("td").eq(2).html());
                    $("#UPDCD").html(row.find("td").eq(3).html());
                    $("#UPDPG").html(row.find("td").eq(4).html());
                    $("#DELFG").html(row.find("td").eq(5).html());
                    $("#ship_name").html(row.find("td").eq(6).html());
                    $("#ship_info").html(row.find("td").eq(7).html());
                    $("#ship_manager").html(row.find("td").eq(8).html());
                    $("#ship_tel").html(row.find("td").eq(9).html());
                    $("#ship_add1").html(row.find("td").eq(10).html());
                    $("#ship_add2").html(row.find("td").eq(11).html());
                    $("#ship_add3").html(row.find("td").eq(12).html());
                    $("#zip").html(row.find("td").eq(13).html());
                    $("#e_mail").html(row.find("td").eq(14).html());
                    $("#ship_service").html(row.find("td").eq(15).html());
                    $("#open_time").html(row.find("td").eq(16).html());
                    $("#close_time").html(row.find("td").eq(17).html());
                    $("#opening_date").html(row.find("td").eq(18).html());
                    $("#closing_date").html(row.find("td").eq(19).html());
                    $("#ship_code").html(row.find("td").eq(20).html());
                    $("#ship_mark").html(row.find("td").eq(21).html());
                    $("#item_1").html(row.find("td").eq(22).html());
                    $("#item_2").html(row.find("td").eq(23).html());
                    $("#mess_1").html(row.find("td").eq(24).html());
                    $("#mess_2").html(row.find("td").eq(25).html());
                    $("#mess_3").html(row.find("td").eq(26).html());
                    $("#regi_deposit").html(row.find("td").eq(27).html());
                    $("#PO_no").html(row.find("td").eq(28).html());
                    $("#inspection1_start").html(row.find("td").eq(29).html());
                    $("#inspection1_end").html(row.find("td").eq(30).html());
                    $("#inspection2_start").html(row.find("td").eq(31).html());
                    $("#inspection2_end").html(row.find("td").eq(32).html());
                    $("#inspection3_start").html(row.find("td").eq(33).html());
                    $("#inspection3_end").html(row.find("td").eq(34).html());
                    $("#open_start").html(row.find("td").eq(35).html());
                    $("#open_end").html(row.find("td").eq(36).html());
                    $("#close_start").html(row.find("td").eq(37).html());
                    $("#close_end").html(row.find("td").eq(38).html());
                    $("#GSTIN").html(row.find("td").eq(39).html());
                    $("#Parent_Ship_Name").html(row.find("td").eq(40).html());
                    $("#IsChildShip").html(row.find("td").eq(41).html());
                    $("#RpaClientUserId").html(row.find("td").eq(42).html());
                    $("#RpaClientPwd").html(row.find("td").eq(43).html());
                    $("#pwdupdateddate").html(row.find("td").eq(44).html());
                    $("#IsShipCodeChanged").html(row.find("td").eq(45).html());
                }
            });
        </script>--%>



        </div>
      
    </form>
</body>
</html>
