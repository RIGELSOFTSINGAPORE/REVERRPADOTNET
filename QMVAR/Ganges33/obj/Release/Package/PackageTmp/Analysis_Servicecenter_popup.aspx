<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Analysis_Servicecenter_popup.aspx.vb" Inherits="Ganges33.Analysis_Servicecenter_popup" %>
 <%--<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.0/jquery.min.js"></script>
    <link type="text/css" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1/themes/start/jquery-ui.css" rel="stylesheet">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1/jquery-ui.min.js"></script>--%>
   <link href="ExternalStyles/Css/css.css" rel="stylesheet" />
<link href="ExternalStyles/Css/font-awesome.min.css" rel="stylesheet" />
<link href="ExternalStyles/Css/jquery-ui.css" rel="stylesheet" />
<script src="ExternalStyles/Jquery/a076d05399.js"></script>
<script src="ExternalStyles/Jquery/jquery-latest.min.js"></script>
<script src="ExternalStyles/Jquery/jquery-ui.min.js"></script>
<script src="ExternalStyles/Jquery/jquery.min.js"></script>
  <!--     Fonts and icons     -->
  <%--<link rel="stylesheet"  type="text/css" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700|Roboto+Slab:400,700|Material+Icons" />
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/latest/css/font-awesome.min.css">--%>
  <!-- CSS Files -->
 <link href="assets/css/material-dashboard-rtl.css" rel="stylesheet" />
<link href="assets/css/material-dashboard.css" rel="stylesheet" />
<link href="assets/css/material-dashboard.min.css" rel="stylesheet" />
 <%-- <script src='https://kit.fontawesome.com/a076d05399.js'></script>--%>
  <link href="assets/demo/demo.css" rel="stylesheet" />
  <%-- <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.0/jquery.min.js"></script>
    <link type="text/css" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1/themes/start/jquery-ui.css" rel="stylesheet">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1/jquery-ui.min.js"></script>--%>
	 <link href="Styles/bootstrap.min.css"  rel="stylesheet" type="text/css"/>
    <script type="text/javascript" src="Scripts/bootstrap.min.js"></script>
    <link href="Styles/bootstrap-multiselect.css" rel="stylesheet" type="text/css"/>
    <script src="Scripts/bootstrap-multiselect.js" type="text/javascript"></script>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <title></title>
    <style>
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
                    User Information 
                  </h3>
                 
                </div>
                <div class="card-body " >
                     <asp:Button ID="btnback" runat="server" CausesValidation="false" Text="Close" OnClientClick="javascript:window.close()"  class="btn pull-right btn-primary btnalign" />
           
                     <table >
               
                              <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Created Date:</td>
                                    <td>
                                        <asp:Label ID="lblCRTDT" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Created User:</td>
                                    <td>
                                        <asp:Label ID="lblCRTCD" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Updated Date:</td>
                                    <td>
                                        <asp:Label ID="lblUpddt" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>

                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Updated User:</td>
                                    <td>
                                        <asp:Label ID="lblUPDCD" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>


                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">User Name:</td>
                                    <td>
                                        <asp:Label ID="lblUseid" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Password:</td>
                                    <td>
                                        <asp:Label ID="lblPassword" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Engineer ID:</td>
                                    <td>
                                        <asp:Label ID="lblEngId" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>

                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">User Leve1:</td>
                                    <td>
                                        <asp:Label ID="lblUserlvl" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Branch Code1:</td>
                                    <td>
                                        <asp:Label ID="lblbranchcode1" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Branch Code2:</td>
                                    <td>
                                        <asp:Label ID="lblbranchcode2" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Branch Code3:</td>
                                    <td>
                                        <asp:Label ID="lblbranchcode3" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Branch Code4:</td>
                                    <td>
                                        <asp:Label ID="lblbranchcode4" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Branch Code5:</td>
                                    <td>
                                        <asp:Label ID="lblbranchcode5" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Surname:</td>
                                    <td>
                                        <asp:Label ID="lblSurname" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Name:</td>
                                    <td>
                                        <asp:Label ID="lblName" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                <%--<tr>
                                    <td  class="serverlbl" style="font-weight:bold">Middle Name:</td>
                                    <td>
                                        <asp:Label ID="lblMiddleName" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>--%>
                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">DOB:</td>
                                    <td>
                                        <asp:Label ID="lblDOB" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Sex:</td>
                                    <td>
                                        <asp:Label ID="lblSex" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                 <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Superior:</td>
                                    <td>
                                        <asp:Label ID="lblSuperior" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>


                              <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Address Line 1:</td>
                                    <td>
                                        <asp:Label ID="lblAddressLine1" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Address Line 2:</td>
                                    <td>
                                        <asp:Label ID="lblAddressLine2" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Address Line 3:</td>
                                    <td>
                                        <asp:Label ID="lblAddressLine3" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>

                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Zip Code:</td>
                                    <td>
                                        <asp:Label ID="lblZipCode" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Telephone No1:</td>
                                    <td>
                                        <asp:Label ID="lblTelephoneNo1" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Mobile No:</td>
                                    <td>
                                        <asp:Label ID="lblMobileNo" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Email ID:</td>
                                    <td>
                                        <asp:Label ID="lblEmailID" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Telephone No2:</td>
                                    <td>
                                        <asp:Label ID="lblTelephoneNo2" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Delete flag:</td>
                                    <td>
                                        <asp:Label ID="lblDeleteflag" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Admin Flag:</td>
                                    <td>
                                        <asp:Label ID="lblAdminFlag" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>


                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Em Surname:</td>
                                    <td>
                                        <asp:Label ID="lblemSurname" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Gua Name:</td>
                                    <td>
                                        <asp:Label ID="lblGuaName" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Gua Telephone :</td>
                                    <td>
                                        <asp:Label ID="lblgua_tel" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Gua Address Line 1:</td>
                                    <td>
                                        <asp:Label ID="lblGuaAddressLine1" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                 <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Gua Address Line 2:</td>
                                    <td>
                                        <asp:Label ID="lblGuaAddressLine2" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>

                              <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Gua Zip Code:</td>
                                    <td>
                                        <asp:Label ID="lblGuaZipCode" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Gua Email ID:</td>
                                    <td>
                                        <asp:Label ID="lblGuaEmailID" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Hire Date:</td>
                                    <td>
                                        <asp:Label ID="lblHireDate" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>

                                <%--<tr>
                                    <td  class="serverlbl" style="font-weight:bold">Dep Date:</td>
                                    <td>
                                        <asp:Label ID="lblDepDate" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Class:</td>
                                    <td>
                                        <asp:Label ID="lblClass" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Position:</td>
                                    <td>
                                        <asp:Label ID="lblPosition" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Work Location:</td>
                                    <td>
                                        <asp:Label ID="lblWorkLocation" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Time:</td>
                                    <td>
                                        <asp:Label ID="lblTime" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Higher Date1:</td>
                                    <td>
                                        <asp:Label ID="lblHigherDate1" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Higher Date2:</td>
                                    <td>
                                        <asp:Label ID="lblHigherDate2" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Higher Name:</td>
                                    <td>
                                        <asp:Label ID="lblHigherName" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Uni date1:</td>
                                    <td>
                                        <asp:Label ID="lblunidate1" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Uni date2:</td>
                                    <td>
                                        <asp:Label ID="lblunidate2" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Uni name:</td>
                                    <td>
                                        <asp:Label ID="lbluni_name" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                 <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Employee h1:</td>
                                    <td>
                                        <asp:Label ID="lblEmployeeh1" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>



                              <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Employee h2:</td>
                                    <td>
                                        <asp:Label ID="lblEmployeeh2" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Employee Name1:</td>
                                    <td>
                                        <asp:Label ID="lblEmployeeName1" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Employee H3:</td>
                                    <td>
                                        <asp:Label ID="lblEmployeeh3" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Employee H4:</td>
                                    <td>
                                        <asp:Label ID="lblEmployeeH4" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Employee Name2:</td>
                                    <td>
                                        <asp:Label ID="lblEmployeeName2" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">QUA Name1:</td>
                                    <td>
                                        <asp:Label ID="lblQUAName1" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">QUA Date1:</td>
                                    <td>
                                        <asp:Label ID="lblDate" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">QUA Name2:</td>
                                    <td>
                                        <asp:Label ID="lblQUAName2" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td  class="serverlbl" style="font-weight:bold">QUA Date2:</td>
                                    <td>
                                        <asp:Label ID="lblQUADate2" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                 <tr>
                                    <td  class="serverlbl" style="font-weight:bold">QUA Name3:</td>
                                    <td>
                                        <asp:Label ID="lblQUAName3" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                             <tr>
                                    <td  class="serverlbl" style="font-weight:bold">QUA Date3:</td>
                                    <td>
                                        <asp:Label ID="lblQUADate3" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>

                             <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Paid H1:</td>
                                    <td>
                                        <asp:Label ID="lblPaidH1" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                                 <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Paid H2:</td>
                                    <td>
                                        <asp:Label ID="lblPaidH2" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>
                             <tr>
                                    <td  class="serverlbl" style="font-weight:bold">Work Time:</td>
                                    <td>
                                        <asp:Label ID="lblWorkTime" runat="server" class="serverlbl " ></asp:Label></td>
                                </tr>--%>
                            </table>


            </div>
                  </div>
                </div>
              </div>
            </div>
        </div>
       
         
           




            <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
        <script type="text/javascript">
            $(function () {
                if (window.opener != null && !window.opener.closed) {
                    var rowIndex = window.location.href.split("?")[1].split("=")[1];
                    var parent = $(window.opener.document).contents();
                    var row = parent.find("[id*=GridSetupUser]").find("tr").eq(rowIndex);
                    $("#CRTDT").html(row.find("td").eq(0).html());
                    //$("#CRTCD").html(row.find("td").eq(1).html());
                    //$("#UPDDT").html(row.find("td").eq(2).html());
                    //$("#UPDCD").html(row.find("td").eq(3).html());
                    //$("#UPDPG").html(row.find("td").eq(4).html());
                    //$("#DELFG").html(row.find("td").eq(5).html());
                    //$("#ship_name").html(row.find("td").eq(6).html());
                    //$("#ship_info").html(row.find("td").eq(7).html());
                    //$("#ship_manager").html(row.find("td").eq(8).html());
                    //$("#ship_tel").html(row.find("td").eq(9).html());
                    //$("#ship_add1").html(row.find("td").eq(10).html());
                    //$("#ship_add2").html(row.find("td").eq(11).html());
                    //$("#ship_add3").html(row.find("td").eq(12).html());
                    //$("#zip").html(row.find("td").eq(13).html());
                    //$("#e_mail").html(row.find("td").eq(14).html());
                    //$("#ship_service").html(row.find("td").eq(15).html());
                    //$("#open_time").html(row.find("td").eq(16).html());
                    //$("#close_time").html(row.find("td").eq(17).html());
                    //$("#opening_date").html(row.find("td").eq(18).html());
                    //$("#closing_date").html(row.find("td").eq(19).html());
                    //$("#ship_code").html(row.find("td").eq(20).html());
                    //$("#ship_mark").html(row.find("td").eq(21).html());
                    //$("#item_1").html(row.find("td").eq(22).html());
                    //$("#item_2").html(row.find("td").eq(23).html());
                    //$("#mess_1").html(row.find("td").eq(24).html());
                    //$("#mess_2").html(row.find("td").eq(25).html());
                    //$("#mess_3").html(row.find("td").eq(26).html());
                    //$("#regi_deposit").html(row.find("td").eq(27).html());
                    //$("#PO_no").html(row.find("td").eq(28).html());
                    //$("#inspection1_start").html(row.find("td").eq(29).html());
                    //$("#inspection1_end").html(row.find("td").eq(30).html());
                    //$("#inspection2_start").html(row.find("td").eq(31).html());
                    //$("#inspection2_end").html(row.find("td").eq(32).html());
                    //$("#inspection3_start").html(row.find("td").eq(33).html());
                    //$("#inspection3_end").html(row.find("td").eq(34).html());
                    //$("#open_start").html(row.find("td").eq(35).html());
                    //$("#open_end").html(row.find("td").eq(36).html());
                    //$("#close_start").html(row.find("td").eq(37).html());
                    //$("#close_end").html(row.find("td").eq(38).html());
                    //$("#GSTIN").html(row.find("td").eq(39).html());
                    //$("#Parent_Ship_Name").html(row.find("td").eq(40).html());
                    //$("#IsChildShip").html(row.find("td").eq(41).html());
                    //$("#RpaClientUserId").html(row.find("td").eq(42).html());
                    //$("#RpaClientPwd").html(row.find("td").eq(43).html());
                    //$("#pwdupdateddate").html(row.find("td").eq(44).html());
                    //$("#IsShipCodeChanged").html(row.find("td").eq(45).html());
                }
            });
        </script>
        </div>
    </form>
</body>
</html>
