<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Analysis.Master" CodeBehind="Analysis_Servicecenter.aspx.vb" Inherits="Ganges33.Admin" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.0/jquery.min.js"></script>
    <link type="text/css" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1/themes/start/jquery-ui.css" rel="stylesheet">
     <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1/jquery-ui.min.js"></script>
    <script src="http://code.jquery.com/jquery-latest.min.js" type="text/javascript"></script>
   

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
    <script src="https://kit.fontawesome.com/b99e675b6e.js"></script>
    <style type="text/css">

        .container{
    -ms-overflow-style: none;
    overflow: auto;
}
       
   </style>
</asp:Content>
 
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
     
        
   <%--<div class="wrapper  col-sm-12 sidebar-wrapper position-fixed scrolbar contain" id="style-10">--%>
   
    <%--<div class="content" >
        <div class="container-fluid">
          <div class="row">
            <div class="col-md-12">
              <div class="card">
                <div class="card-header card-header-primary">
                  <h3 class="card-title ">User Info</h3>
                  <p class="card-category"></p>
                </div>--%>
                   <ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server">
        </ajaxToolkit:AccordionPane>
        <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
                <div style="width: 800px;">
     
                   <ajaxToolkit:Accordion ID="Accordion1" runat="server" HeaderCssClass="headerCssClass" ContentCssClass="contentCssClass" HeaderSelectedCssClass="headerSelectedCss" FadeTransitions="true" TransitionDuration="500" AutoSize="None" SelectedIndex="0">
                <Panes>
                    <ajaxToolkit:AccordionPane ID="AccordionPane2" runat="server">
                        <Content>
                         <table>

                                <tr>
                                    <td>User Name:</td>
                                    <td>
                                        <asp:Label ID="lblUseid" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Password:</td>
                                    <td>
                                        <asp:Label ID="lblPassword" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Engineer ID:</td>
                                    <td>
                                        <asp:Label ID="lblEngId" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>

                                <tr>
                                    <td>User Leve1:</td>
                                    <td>
                                        <asp:Label ID="lblUserlvl" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Branch Code1:</td>
                                    <td>
                                        <asp:Label ID="lblbranchcode1" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Branch Code2:</td>
                                    <td>
                                        <asp:Label ID="lblbranchcode2" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Branch Code3:</td>
                                    <td>
                                        <asp:Label ID="lblbranchcode3" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Branch Code4:</td>
                                    <td>
                                        <asp:Label ID="lblbranchcode4" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Branch Code5:</td>
                                    <td>
                                        <asp:Label ID="lblbranchcode5" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Surname:</td>
                                    <td>
                                        <asp:Label ID="lblSurname" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Name:</td>
                                    <td>
                                        <asp:Label ID="lblName" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Middle Name:</td>
                                    <td>
                                        <asp:Label ID="lblMiddleName" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>DOB:</td>
                                    <td>
                                        <asp:Label ID="lblDOB" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Sex:</td>
                                    <td>
                                        <asp:Label ID="lblSex" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                 <tr>
                                    <td>Superior:</td>
                                    <td>
                                        <asp:Label ID="lblSuperior" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>

                             <%-----------------------------%>

                              <tr>
                                    <td>Address Line 1:</td>
                                    <td>
                                        <asp:Label ID="lblAddressLine1" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Address Line 2:</td>
                                    <td>
                                        <asp:Label ID="lblAddressLine2" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Address Line 3:</td>
                                    <td>
                                        <asp:Label ID="lblAddressLine3" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>

                                <tr>
                                    <td>Zip Code:</td>
                                    <td>
                                        <asp:Label ID="lblZipCode" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Telephone No1:</td>
                                    <td>
                                        <asp:Label ID="lblTelephoneNo1" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Mobile No:</td>
                                    <td>
                                        <asp:Label ID="lblMobileNo" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Email ID:</td>
                                    <td>
                                        <asp:Label ID="lblEmailID" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Telephone No2:</td>
                                    <td>
                                        <asp:Label ID="lblTelephoneNo2" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Delete flag:</td>
                                    <td>
                                        <asp:Label ID="lblDeleteflag" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Admin Flag:</td>
                                    <td>
                                        <asp:Label ID="lblAdminFlag" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <%--<tr>
                                    <td>Em Surname:</td>
                                    <td>
                                        <asp:Label ID="lblemSurname" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Gua Name:</td>
                                    <td>
                                        <asp:Label ID="lblGuaName" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Gua Telephone :</td>
                                    <td>
                                        <asp:Label ID="lblgua_tel" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Gua Address Line 1:</td>
                                    <td>
                                        <asp:Label ID="lblGuaAddressLine1" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                 <tr>
                                    <td>Gua Address Line 2:</td>
                                    <td>
                                        <asp:Label ID="lblGuaAddressLine2" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>

                              <tr>
                                    <td style="width: 220px">Gua Zip Code:</td>
                                    <td>
                                        <asp:Label ID="lblGuaZipCode" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Gua Email ID:</td>
                                    <td>
                                        <asp:Label ID="GuaEmailID" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Hire Date:</td>
                                    <td>
                                        <asp:Label ID="lblHireDate" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>

                                <tr>
                                    <td>Dep Date:</td>
                                    <td>
                                        <asp:Label ID="lblDepDate" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Class:</td>
                                    <td>
                                        <asp:Label ID="lblClass" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Position:</td>
                                    <td>
                                        <asp:Label ID="lblPosition" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Work Location:</td>
                                    <td>
                                        <asp:Label ID="lblWorkLocation" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Time:</td>
                                    <td>
                                        <asp:Label ID="lblTime" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Higher Date1:</td>
                                    <td>
                                        <asp:Label ID="lblHigherDate1" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Higher Date2:</td>
                                    <td>
                                        <asp:Label ID="lblHigherDate2" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Higher Name:</td>
                                    <td>
                                        <asp:Label ID="lblHigherName" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Uni date1:</td>
                                    <td>
                                        <asp:Label ID="lblunidate1" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Uni date2:</td>
                                    <td>
                                        <asp:Label ID="lblunidate2" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Uni name:</td>
                                    <td>
                                        <asp:Label ID="lbluni_name" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                 <tr>
                                    <td>Employee h1:</td>
                                    <td>
                                        <asp:Label ID="lblEmployeeh1" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>--%>
                            </table>
                        </Content>
                    </ajaxToolkit:AccordionPane>

                     
                </Panes>
            </ajaxToolkit:Accordion>




                    </div>
                  <%--</div>
                </div>
              </div>
            </div>
        </div>
       </div>--%>
    </form>
</asp:Content>
