<%@ Page Language="vb" AutoEventWireup="false" Title="Analysis Upload Details"  CodeBehind="Analysis_Upload_Details.aspx.vb" Inherits="Ganges33.Analysis_Upload_Details" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit"  %>



   <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.0/jquery.min.js"></script>
    <link type="text/css" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1/themes/start/jquery-ui.css" rel="stylesheet">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1/jquery-ui.min.js"></script>
   
  <!--     Fonts and icons     -->
  <link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700|Roboto+Slab:400,700|Material+Icons" />
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/latest/css/font-awesome.min.css">
  <!-- CSS Files -->
 <link href="assets/css/material-dashboard-rtl.css" rel="stylesheet" />
<link href="assets/css/material-dashboard.css" rel="stylesheet" />
<link href="assets/css/material-dashboard.min.css" rel="stylesheet" />
  <script src='https://kit.fontawesome.com/a076d05399.js'></script>
  <link href="assets/demo/demo.css" rel="stylesheet" />
   <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.0/jquery.min.js"></script>
    <link type="text/css" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1/themes/start/jquery-ui.css" rel="stylesheet">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1/jquery-ui.min.js"></script>
	 <link href="Styles/bootstrap.min.css"  rel="stylesheet" type="text/css"/>
    <script type="text/javascript" src="Scripts/bootstrap.min.js"></script>
    <link href="Styles/bootstrap-multiselect.css" rel="stylesheet" type="text/css"/>
    <script src="Scripts/bootstrap-multiselect.js" type="text/javascript"></script>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head  class="serverlbl " runat="server">
    <title></title>
    <style>
      .text{
           text-transform:capitalize;
           padding:0px ;
           font-weight:600;
       }
    </style>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
	<script type="text/javascript">
        function closeCurrentTab() {
            var conf = confirm("Are you sure, you want to close this tab?");
            if (conf == true) {
                close();
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">

            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
           <asp:UpdatePanel ID="UpdatePanel1"
                             runat="server">
                <ContentTemplate>
   <div class="wrapper  col-sm-12 sidebar-wrapper position-fixed scrolbar contain" id="style-10">
   
    <div class="content" >
        <div class="container-fluid">
          <div class="row">
            <div class="">
              <div class="card">
                <div class="card-header card-header-primary">
                 <%-- <h3 class="card-title ">Setup New Servicecenter</h3>--%>
                     <h3 class="card-title ">Upload Details</h3>
                  <p class="card-category"></p>
                </div>
                <div class="card-body scrollbar" id="style-10">
                    <br />
                    <div >
                 <table>
                          <tr>
                           
                              <td style="width:170px" >
                                  <asp:Label ID="lblLocationValue" runat="server"   ></asp:Label>
                              </td>
                              <td style="width:310px">
                                  <asp:Label ID="lblDateFrom" runat="server"  ></asp:Label>
                              </td>
                              <td style="width:290px">
                                  <asp:Label ID="lblDateTo" runat="server"  ></asp:Label>
                              </td>
                              <td style="width:160px">
                                  <asp:Label ID="lblActive" runat="server"  ></asp:Label>
                                  <asp:CheckBox  ID="chkIndividual" runat="server" Text="Current User" Enabled="false" Visible="false"/>
                              </td>
                          </tr>
                      </table>
                        </div>
                      <br />
                    <div>
                        <asp:Button ID="btnExport" Text="Export" runat="server" Width="90px" height="36px" class="btn btn-primary text" Style="margin-left: 1100px;" Visible="false"/>
                   <asp:Button ID="btnClose"  Text="Close" Width="90px" height="36px" runat="server" OnClientClick="javascript:window.close()" class="btn btn-primary text"   />
                 
                    </div>

                    <div>
                        <br />
                        <br />
                          <asp:Label ID ="lbltotal" CssClass="serverlbl" runat="server"> </asp:Label>

             
          <br />
          <b><asp:Label ID ="lblPagesize" Class="serverlbl font-weight-bold"  runat="server" Visible="false">Page Size:</asp:Label></b>;&nbsp<asp:TextBox ID="txtPageSize" runat="server" MaxLength="4" class="serverlbl" Style="Width: 40px"  AutoPostBack="true" OnTextChanged="txtPageSize_TextChanged"></asp:TextBox>
          <asp:Label ID ="lblErrorMessage" Class="serverlbl"  style="color: red;" runat="server">Please enter a valid Page Size Range betwwwn 1 to 9999</asp:Label>
            <br />
            <br />
                        <div class="table-responsive-lg">
            <asp:GridView ID="gvExportReport" runat="server" AutoGenerateColumns="false" AllowPaging="true" CellPadding="3"
            AllowSorting="true" OnSorting="OnSorting" HeaderStyle-BackColor="#8e24aa" HeaderStyle-ForeColor="White"  OnPageIndexChanging="OnPageIndexChanging"
            PageSize="10"  RowStyle-Wrap="false"  ShowHeaderWhenEmpty="true" HeaderStyle-Wrap="false">
       
                 
            <EmptyDataTemplate >No Record Available</EmptyDataTemplate> 
            <EmptyDataRowStyle HorizontalAlign="Center" />
                 <AlternatingRowStyle BackColor="#e2e2e2" ForeColor="Black"  />
            <HeaderStyle BackColor="#8e24aa" Font-Bold="True" ForeColor="white" />
            <RowStyle ForeColor="Black" BackColor="White" />
        </asp:GridView>
           </div>
                    </div>
                    <br />
                    <div>
                         <asp:Label ID="lblReccount" Class="serverlbl"  runat="server" Text="" Visible="false"></asp:Label>
                         <asp:Label ID="lblTitle" Class="serverlbl"  runat="server"  Width="700px"   ></asp:Label>
                    </div>
                    </div>
                  </div>
                
                </div>
              </div>
            </div>
        </div>
       </div>
        
        

    <div>

                    <br />
        <asp:HiddenField  runat="server" ID ="hdnStoreValue" />
        <asp:HiddenField  runat="server" ID ="hdnStoreName" />
        <asp:HiddenField  runat="server" ID ="hdnColumnName" />
        <asp:HiddenField  runat="server" ID ="hdnDateFrom" />
        <asp:HiddenField  runat="server" ID ="hdnDateTo" />
        <asp:HiddenField  runat="server" ID ="hdnActiveFlag" />
        <asp:HiddenField  runat="server" ID ="hdnCurrentUser" />
        <asp:HiddenField  runat="server" ID ="hdnUserLevel" />
        <asp:HiddenField  runat="server" ID ="hdnAdminFlag" />
        <asp:HiddenField  runat="server" ID ="hdnUserId" />
        <asp:HiddenField  runat="server" ID ="hdnSeqNo" />
        <asp:HiddenField  runat="server" ID ="hdnStoreID" />
        <asp:HiddenField  runat="server" ID ="hdnStoreIDValue" />
   </div>
      

    <div id="dialog" title="message" style="display:none;">
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </div>
   <div style="visibility:hidden">
  <asp:Label ID="lblName" runat="server" CssClass="auto-style186"></asp:Label>
                      <asp:Label ID="lblLoc" runat="server" CssClass="auto-style186"></asp:Label>
       </div>
                    </ContentTemplate>
               </asp:UpdatePanel>

        </form>
    </body>
    </html>
