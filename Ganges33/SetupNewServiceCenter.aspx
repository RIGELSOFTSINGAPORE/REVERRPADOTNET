
<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Analysis.Master" CodeBehind="SetupNewServiceCenter.aspx.vb" Inherits="Ganges33.SetupNewServiceCenter" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.0/jquery.min.js"></script>
    <link type="text/css" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1/themes/start/jquery-ui.css" rel="stylesheet">
     <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1/jquery-ui.min.js"></script>

   

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
    <style type="text/css">

        .container{
    -ms-overflow-style: none;
    overflow: auto;
}
        
       
   </style>
    <script>
        $(function () {
            $('[class*=duration]').durationPicker({
                onChanged: function (newVal) {
                    $('#duration-label').text(newVal);
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
   
   <div class="wrapper  col-sm-12 sidebar-wrapper position-fixed scrolbar contain" id="style-10">
   
    <div class="content" >
        <div class="container-fluid">
          <div class="row">
            <div class="col-md-12">
              <div class="card">
                <div class="card-header card-header-primary">
                  <h3 class="card-title ">Setup New Servicecenter</h3>
                  <p class="card-category"></p>
                </div>
                <div class="card-body " >
     <div runat="server" id="addfile">
                    <div class="row">
                        <div class="col-sm-2">
                          <label>Ship Name</label>  
                        </div>
                        <div>
                             <asp:TextBox ID="ShipName" runat="server" value="" Height="33px" Width="100%" class="form-file-upload  serverlbl" />
                        </div>
                        </div>

                        <div class="row">
                          <div class="col-sm-2">
                              <label>
                                Ship Info
                           </label>
                             </div>
                             <div>
                              <asp:TextBox ID="ShipInfo" runat="server" value="" Height="33px" Width="100%" class="form-file-upload  serverlbl" />
                           
                            </div>
                        </div>
                        

                        <div class="row">
                          <div class="col-sm-2">
                              <label>
                                Ship Manager
                           </label>
                             </div>
                             <div>
                              <asp:TextBox ID="ShipManager" runat="server" value="" Height="33px" Width="100%" class="form-file-upload  serverlbl" />
                           
                            </div>
                        </div>
                        <div class="row">
                             <div class="col-sm-2">
                                 <label>
                                     Ship Tel
                                 </label>
                             </div>
                            <div>
                                 <asp:TextBox ID="ShipTel" runat="server" value="" Height="33px" Width="100%" class="form-file-upload  serverlbl" />
                           
                            </div>
                        </div>
                   

                    <div class="row">
                        <div class="col-sm-2">
                            <label>
                                Ship Add1
                            </label>
                        </div>
                        <div>
                            <asp:TextBox ID="ShipAdd1" runat="server" value="" Height="33px" Width="100%" class="form-file-upload duration  serverlbl" />
                           
                        </div>
                    </div>

             <div class="row">
                        <div class="col-sm-2">
                            <label>
                                Ship Add2
                            </label>
                        </div>
                        <div>
                            <asp:TextBox ID="ShipAdd2" runat="server" value="" Height="33px" Width="100%" class="form-file-upload   serverlbl" />
                           
                        </div>
                    </div>

          <div class="row">
                        <div class="col-sm-2">
                            <label>
                                Ship Add3
                            </label>
                        </div>
                        <div>
                            <asp:TextBox ID="ShipAdd3" runat="server" value="" Height="33px" Width="100%" class="form-file-upload   serverlbl" />
                           
                        </div>
                    </div>
          <div class="row">
                        <div class="col-sm-2">
                            <label>
                                Zip
                            </label>
                        </div>
                        <div>
                            <asp:TextBox ID="Zip" runat="server" value="" Height="33px" Width="100%" class="form-file-upload   serverlbl" />
                           
                        </div>
                    </div>
            
             <div class="row">
                        <div class="col-sm-2">
                            <label>
                                Email
                            </label>
                        </div>
                        <div>
                            <asp:TextBox ID="Email" runat="server" value="" Height="33px" Width="100%" class="form-file-upload   serverlbl" />
                           
                        </div>
                    </div>


         <div class="row">
                        <div class="col-sm-2">
                            <label>
                                Ship Service
                            </label>
                        </div>
                        <div>
                            <asp:TextBox ID="ShipService" runat="server" value="" Height="33px" Width="100%" class="form-file-upload   serverlbl" />
                           
                        </div>
                    </div>



         <div class="row">
                        <div class="col-sm-2">
                            <label>
                                Open Time
                            </label>
                        </div>
                        <div>
                            <asp:TextBox ID="OpenTime" runat="server" value="" Height="33px" Width="100%" class="form-file-upload duration   serverlbl" />
                           
                        </div>
                    </div>

         <div class="row">
                        <div class="col-sm-2">
                            <label>
                                Close Time
                            </label>
                        </div>
                        <div>
                            <asp:TextBox ID="CloseTime" runat="server" value="" Height="33px" Width="100%" class="form-file-upload duration  serverlbl" />
                           
                        </div>
                    </div>

         <div class="row">
                        <div class="col-sm-2">
                            <label>
                                Opening Date
                            </label>
                        </div>
                        <div>
                            <asp:TextBox ID="OpeningDate" runat="server" value="" Height="33px" Width="100%" class="form-file-upload date  serverlbl" />
                           
                        </div>
                    </div>


         <div class="row">
                        <div class="col-sm-2">
                            <label>
                                Closing Date
                            </label>
                        </div>
                        <div>
                            <asp:TextBox ID="ClosingDate" runat="server" value="" Height="33px" Width="100%" class="form-file-upload date  serverlbl" />
                           
                        </div>
                    </div>

         <div class="row">
                        <div class="col-sm-2">
                            <label>
                                Ship Code
                            </label>
                        </div>
                        <div>
                            <asp:TextBox ID="ShipCode" runat="server" value="" Height="33px" Width="100%" class="form-file-upload   serverlbl" />
                           
                        </div>
                    </div>

         <div class="row">
                        <div class="col-sm-2">
                            <label>
                                Ship Mark
                            </label>
                        </div>
                        <div>
                            <asp:TextBox ID="ShipMark" runat="server" value="" Height="33px" Width="100%" class="form-file-upload   serverlbl" />
                           
                        </div>
                    </div>

         <div class="row">
                        <div class="col-sm-2">
                            <label>
                                Item 1
                            </label>
                        </div>
                        <div>
                            <asp:TextBox ID="Item1" runat="server" value="" Height="33px" Width="100%" class="form-file-upload   serverlbl" />
                           
                        </div>
                    </div>

         <div class="row">
                        <div class="col-sm-2">
                            <label>
                                Item 2
                            </label>
                        </div>
                        <div>
                            <asp:TextBox ID="Item2" runat="server" value="" Height="33px" Width="100%" class="form-file-upload   serverlbl" />
                           
                        </div>
                    </div>

         <div class="row">
                        <div class="col-sm-2">
                            <label>
                                Mess 1
                            </label>
                        </div>
                        <div>
                            <asp:TextBox ID="Mess1" runat="server" value="" Height="33px" Width="100%" class="form-file-upload   serverlbl" />
                           
                        </div>
                    </div>


         <div class="row">
                        <div class="col-sm-2">
                            <label>
                                Mess 2
                            </label>
                        </div>
                        <div>
                            <asp:TextBox ID="Mess2" runat="server" value="" Height="33px" Width="100%" class="form-file-upload   serverlbl" />
                           
                        </div>
                    </div>

         <div class="row">
                        <div class="col-sm-2">
                            <label>
                                Mess 3
                            </label>
                        </div>
                        <div>
                            <asp:TextBox ID="Mess3" runat="server" value="" Height="33px" Width="100%" class="form-file-upload   serverlbl" />
                           
                        </div>
                    </div>

         <div class="row">
                        <div class="col-sm-2">
                            <label>
                                Ragi Deposit
                            </label>
                        </div>
                        <div>
                            <asp:TextBox ID="RagiDeposit" runat="server" value="" Height="33px" Width="100%" class="form-file-upload   serverlbl" />
                           
                        </div>
                    </div>

         <div class="row">
                        <div class="col-sm-2">
                            <label>
                                PO No
                            </label>
                        </div>
                        <div>
                            <asp:TextBox ID="PO_NO" runat="server" value="" Height="33px" Width="100%" class="form-file-upload   serverlbl" />
                           
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-sm-2">
                            <label >
                                Delete flag
                            </label>
                        </div>
                        <div>
                            <asp:checkbox id="delfld" runat="server"></asp:checkbox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-2">
                             </div>
                   
                   
                            <div>
 <asp:Button ID="btnAddNew" runat="server" Text="Add New" class="btn btn-primary " />
                    </div>


                    </div>
                 <div>
                        <asp:Button ID="Back" runat="server" Text="Back" class="btn btn-primary pull-right" />
                    </div>     
     </div>



                    
                <div runat="server" id="data">
                  <div>
                      <asp:Button ID="Create" runat="server" Text="Create" class="btn btn-primary " />
                  </div>
                    <div>
                        <asp:GridView ID="getdata" AutoGenerateColumns="false"  DataKeyNames="SHIP_CODE" runat="server">
                             <Columns>
        <asp:BoundField DataField="SHIP_NAME" HeaderText="Ship Name" />
        <asp:BoundField DataField="SHIP_INFO" HeaderText="Ship Info" />
        <asp:BoundField DataField="SHIP_MANAGER" HeaderText="Ship Manager" />
        <asp:BoundField DataField="SHIP_SERVICE" HeaderText="Ship Service " />
        <asp:BoundField DataField="SHIP_CODE" HeaderText="Ship Code" />
        <asp:BoundField DataField="SHIP_MARK" HeaderText="ship Mark" />
        <asp:BoundField DataField="DELFG" HeaderText="Delflg" />
                                 <asp:TemplateField >
                                       <ItemTemplate>
                                           <asp:Button id="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" />
                                       </ItemTemplate>
                                   </asp:TemplateField>

                                 <asp:TemplateField >
                                       <ItemTemplate>
                                           <asp:Button id="btnView" runat="server" Text="View" OnClick="btnView_Click" />
                                       </ItemTemplate>
                                   </asp:TemplateField>

                                   
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
     
    
        <asp:Button ID="BtnCancel" runat="server" Text="Button" Style="display: none;" />
        <asp:Button ID="BtnOK" runat="server" Text="Button" Style="display: none;" />

   

    <div id="dialog" title="message" style="display: none;">
       
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>

