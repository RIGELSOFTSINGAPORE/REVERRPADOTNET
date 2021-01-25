<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Analysis.Master" CodeBehind="RPA_Management.aspx.vb" Inherits="Ganges33.RPA_Management" %>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
   
   <div class="wrapper  col-sm-12 sidebar-wrapper position-fixed scrolbar contain" id="style-10">
   
    <div class="content" >
        <div class="container-fluid">
          <div class="row">
            <div class="col-md-12">
              <div class="card">
                <div class="card-header card-header-primary">
                  <h3 class="card-title ">User Management</h3>
                  <p class="card-category"></p>
                </div>
                <div class="card-body " >
     <div runat="server" id="addfile">
                    <div class="row">
                        <div>
                          <label>Task Name</label>  
                        </div>
                        <div>
                             <asp:TextBox ID="TaskName" runat="server" value="" Height="33px" Width="100%" class="form-file-upload  serverlbl" />
                        </div>
                        </div>
                        <div class="row">
                            <div>
                           <label>
                                File Name
                           </label>
                           </div> <div>
                             <asp:TextBox ID="filename" runat="server" value="" Height="33px" Width="100%" class="form-file-upload  serverlbl" />
                        </div>
                        </div>
                        <div class="row">
                            <div>
                                <label>
                                Source Path
                           </label>
                            </div>
                            <div>
                              <asp:TextBox ID="Source" runat="server" value="" Height="33px" Width="100%" class="form-file-upload  serverlbl" />
                           
                            </div>
                        </div>
                        <div class="row">
                          <div>
                              <label>
                                Tested Date
                           </label>
                             </div>
                             <div>
                              <asp:TextBox ID="Testeddate" runat="server" value="" Height="33px" Width="100%" class="form-file-upload date  serverlbl" />
                           
                            </div>
                        </div>
                        <div class="row">
                             <div>
                                 <label>
                                     Status
                                 </label>
                             </div>
                            <div>
                                 <asp:TextBox ID="Status" runat="server" value="" Height="33px" Width="100%" class="form-file-upload  serverlbl" />
                           
                            </div>
                        </div>
                   

                    <div class="row">
                        <div>
                            <label>
                                Run Duration
                            </label>
                        </div>
                        <div>
                            <asp:TextBox ID="Duration" runat="server" value="" Height="33px" Width="100%" class="form-file-upload  serverlbl" />
                           
                        </div>
                    </div>
                    <div class="row">
                        <div>
                            <label>
                                Delete flag
                            </label>
                        </div>
                        <div>
                            <asp:checkbox id="delfld" runat="server"></asp:checkbox>
                        </div>
                    </div>
                    <div>
                    <asp:Button ID="btnUpload" runat="server" Text="Import" class="btn btn-primary pull-right" />
                    <div>

                    </div>


                    </div>
                 <div>
                        <asp:Button ID="Back" runat="server" Text="Import" class="btn btn-primary " />
                    </div>     
     </div>
                    
                <div runat="server" id="data">
                  
                    <div>
                        <asp:GridView ID="getdata" runat="server">
                             <Columns>
        <asp:BoundField DataField="TASK_NAME" HeaderText="Task Name" />
        <asp:BoundField DataField="FILE_NAME" HeaderText="File Name" />
        <asp:BoundField DataField="Path" HeaderText="Source Path" />
        <asp:BoundField DataField="TEST_STATUS" HeaderText="Test Date " />
        <asp:BoundField DataField="STATUS" HeaderText="Status" />
        <asp:BoundField DataField="RUN_DURATION" HeaderText="Run Duration" />
        <asp:BoundField DataField="DELFG" HeaderText="Delflg" />
                                  <asp:TemplateField>
            <ItemTemplate>
                <asp:Button Text="Edit" runat="server" CommandName="Edit" CommandArgument="<%# Container.DataItemIndex %>" />
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
     
    
</asp:Content>
