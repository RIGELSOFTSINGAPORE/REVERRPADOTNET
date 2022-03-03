<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/RpaDemo.Master" CodeBehind="RPA_Management_Demo.aspx.vb" Inherits="Ganges33.RPA_Management_Demo" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <%--<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.0/jquery.min.js"></script>
    <link type="text/css" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1/themes/start/jquery-ui.css" rel="stylesheet">
     <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1/jquery-ui.min.js"></script>
    	<script src="//code.jquery.com/jquery-1.11.3.min.js"></script>--%>
   <script type="text/javascript" src="ExternalStyles/Jquery/jquery.min.js"></script>
    <script type="text/javascript" src="ExternalStyles/Jquery/jquery-ui.min.js"></script>
    <script type="text/javascript" src="ExternalStyles/Jquery/bootstrap-multiselect.js"></script>

    <link href="ExternalStyles/Css/css.css" rel="stylesheet" />  
    <link href="ExternalStyles/Css/font-awesome.min.css" rel="stylesheet" />  
    <link href="ExternalStyles/Css/jquery-ui.css" rel="stylesheet" />  
    <link href="ExternalStyles/Css/bootstrap-multiselect.css" rel="stylesheet" />  


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
  
    <%--<script src="http://code.jquery.com/jquery-1.12.4.min.js"></script>--%>

  <meta content='width=device-width, initial-scale=1.0, shrink-to-fit=no' name='viewport' />
  <!--     Fonts and icons     -->
 <%-- <link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700|Roboto+Slab:400,700|Material+Icons" />
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/latest/css/font-awesome.min.css">--%>
  <!-- CSS Files -->
   <link href="assets/css/material-dashboard.css" rel="stylesheet" /> 
  <!-- CSS Just for demo purpose, don't include it in your project -->
  <link href="assets/demo/demo.css" rel="stylesheet" />
  <%--<script src="https://code.jquery.com/jquery-3.4.1.slim.min.js"></script>
    <link href="https://www.jqueryscript.net/css/jquerysctipttop.css" rel="stylesheet" type="text/css">--%>

	<link href="assets/css/timepicker.css" rel="stylesheet" />

    <script src="assets/timepicker.js"></script>
     <%--<script type="text/javascript">
         $(document).ready(function () {
             $(".simpleExample").timepicker();


         });
    </script>--%>
    <style>
        .tme{
            border-color: blanchedalmond;
        border: 1px solid #d2d2d2;
    width: 188px;
    border-radius: 4px;
    margin-left:0px
        }

        
.my-timepicker-div .ampm-button{
  width: 4rem;
  height: 3rem;
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

   </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
 
   <div class="wrapper  col-sm-12 sidebar-wrapper position-fixed scrolbar contain" id="style-10">
   
    <div class="content" >
        <div class="container-fluid">
          <div class="row">
            <div class="col-md-12">
              <div class="card">
                <div class="card-header  card-header-primary">
                  <h3 class="card-title " >
                      <asp:label id="Header" Text="" runat="server" >                      </asp:label>
                  </h3>
                  <p class="card-category"></p>
                </div>
                <div class="card-body scrollbar" id="style-10">
              
                   
   
                          <div runat="server" id="addfile">
                    <div class="row">
                        <asp:Label ID="id" runat="server" Text="" Style="display:none "></asp:Label>
                        <div class="col-sm-2">
                            <br />
                          <label>Task Name</label>  
                        </div>
                        <div>
                              <br />
                             <asp:TextBox ID="TaskName" runat="server"  Height="33px" Width="100%" class="form-file-upload  serverlbl" />
                        </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-2">
                                  <br />
                           <label>

                                File Name
                           </label>
                           </div> <div>
                                 <br />
                               <asp:FileUpload ID="filename" Class="serverlbl" accept=".py"  runat="server" AllowMultiple="True" />
                               
                             <asp:TextBox ID="Textfilename" runat="server" value="" Height="33px" Width="100%" ReadOnly="true" class="form-control  serverlbl" />
                        </div>
                        </div>
                        <div class="row" runat="server" id="sourcepath">
                            <div class="col-sm-2">
                                  <br />
                                <label>
                                Source Path
                           </label>
                            </div>
                            <div>
                                  <br />
                              <asp:TextBox ID="Source" runat="server" ReadOnly="true" Height="33px" Width="100%" class="form-control serverlbl" />
                           
                            </div>
                        </div>
                        <div class="row">
                          <div class="col-sm-2">
                                <br />
                              <label>
                                Tested Date
                           </label>
                             </div>
                             <div>
                                   <br />
                              <asp:TextBox ID="Testeddate" runat="server" value="" AutoCompleteType="Disabled"  Height="33px" Width="100%" class="form-file-upload date serverlbl" />
                           
                            </div>
                        </div>
                        <div class="row">
                             <div class="col-sm-2">
                                   <br />
                                 <label>
                                     Status
                                 </label>
                             </div>
                            <div>
                                  <br />
                            <asp:DropDownList ID="Status" runat="server"   width="188px" Height="33px" class="form-control  serverlbl">
                                <asp:ListItem Text="Select..." Value="0"></asp:ListItem>
                                <asp:ListItem Text="Active" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Inactive" Value="2"></asp:ListItem>
                           </asp:DropDownList>
                            </div>
                        </div>
                   

                    <div class="row">
                        <div class="col-sm-2">
                              <br />
                            <label>
                                Run Duration
                            </label>
                        </div>
                        <div >
                            
                              <br />
                            <asp:TextBox runat="server" class="simpleExample form-control" value="00:00" ID="Duration"></asp:TextBox>
                          
                              <br />
                           
                        

                        </div>
                    </div>

           <%--  <div class="row">
                        <div class="col-sm-2">
                              <br />
                            <label>
                                IP Adress
                            </label>
                        </div>
                        <div>
                            <asp:TextBox ID="Ipaddress" runat="server" value="" Height="33px" Width="100%" class="form-file-upload   serverlbl" />
                           
                        </div>
                    </div>--%>
                    <div class="row" runat="server" id="del">
                        <div class="col-sm-2">
                              <br />
                            <label >
                                Delete flag
                            </label>
                        </div>
                        <div>
                              <br />
                            <asp:checkbox id="delfld" runat="server"></asp:checkbox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-2">
                             </div>
                   
                   
                            <div>
                                <br />
                                <asp:Button ID="btnUpload" runat="server" Width="90px" height="36px"  Text="Create" class="btn btn-primary text" />
                                <asp:Button ID="Edit" runat="server" Width="90px" height="36px"  Text="Save" class="btn btn-primary text" />
                                 <asp:Button ID="Back" runat="server" Width="90px" height="36px"  Text="Back" class="btn btn-primary pull-right text" />
                    </div>


                    </div>
                    
               </div>
                    
               <div class="row" runat="server" id="data">



                    <div class="col-sm-12">
                           <div class="row col-sm-12">
                            <div >
                                <br />
                       <label style="margin-top: 3px;"> Task name : </label>
                                </div>
                            <div style="margin-left: 12px;width: 178px;">
                                                                <br />
<asp:TextBox ID="txtSearch" runat="server" CssClass="form-control"  AutoPostBack="true"></asp:TextBox>
                                </div>

                               <div style="margin-left: 15px;margin-top:-3px;">
                             <br />
                             <asp:Button ID="txtSearch1" Width="80px" margin-left="23px" height="32px" margin-top="0px" runat="server" OnClick="txtSearch1_Click1" Text="Search" class="btn btn-primary text" />
                         </div>
                         <div style="margin-left: 16px;margin-top:-3px;">
                             <br />
                             <asp:Button ID="Clear" margin-left="120px" Width="87px" height="32px" margin-top="0px" runat="server" Text="Clear" OnClick="Clear_Click1" class="btn btn-primary text" />
                         </div>

   
                                </div>
                         <div style="margin-left: 1px; margin-top:4px;">
                  <%--<asp:Button  ID="btnAdd" runat="server" Width="145px" class="btn  btn-primary text" OnClick="btnAdd_Click" Text="Create New User"/>--%>
    <asp:Button ID="Create" runat="server" Width="145px" Text="Create" class="btn btn-primary text" />
                            </div>
                           
                      </div>







                  <%--<div>
                      <asp:Button ID="Create" runat="server" Text="Create" class="btn btn-primary " />
                  </div>--%>
                    
                       <%-- <div class="row col-sm-12">

                            <div  >
                                <br />
                       <label> Task name:</label>
                                </div>
                            
                             
                            <div>
                                  <br />

                                </div>

                            </div>  --%>                    
                         <br />
                         <br />
                   <br />
                        <br />
                    
                        
                            <div class="col-md-12">
                    <div class="form-group">
                        <asp:GridView ID="getdata" runat="server"  AutoGenerateColumns="false" CellPadding="10" AllowSorting="true"   AllowPaging="true" PageSize="10" OnPageIndexChanging="getdata_PageIndexChanging" OnRowCommand="getdata_RowCommand"
                Style="align-self: center" HeaderStyle-BackColor="#8e24aa" HeaderStyle-ForeColor="White" OnSorting="getdata_Sorting"  CssClass="col-sm-12" ShowHeaderWhenEmpty="true" EmptyDataText="No records Found">
                            <PagerStyle HorizontalAlign = "left" CssClass = "GridPager" />
                <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                <EmptyDataRowStyle HorizontalAlign="Center" />
                            <%--<PagerStyle BackColor="Purple" />--%>
                <Columns>
             

                    <asp:TemplateField HeaderText="TASK NAME" HeaderStyle-CssClass="sort" SortExpression="TASK_NAME" >
                        <ItemTemplate>
                            <asp:Label ID="TASK_NAME" runat="server" Text='<%# Eval("TASK_NAME") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="TASK_NAME" runat="server" Text='<%# Eval("TASK_NAME") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="FILE NAME" HeaderStyle-CssClass="sort" SortExpression="FILE_NAME" >
                        
                        <ItemTemplate>
                            <asp:Label ID="FILE_NAME" runat="server" Text='<%# Eval("FILE_NAME") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="PATH" >
                       
                        <ItemTemplate>
                            <asp:Label ID="Path" runat="server"  Text='<%# Eval("Path") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="DATE" HeaderStyle-CssClass="sort" SortExpression="TEST_STATUS" >
                        
                        <ItemTemplate>
                            <asp:Label ID="TEST_STATUS" runat="server"  Text='<%# Eval("TEST_STATUS") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="STATUS" HeaderStyle-CssClass="sort" SortExpression="STATUS">
                       
                        <ItemTemplate>
                            <asp:Label ID="STATUS" runat="server"   Text='<%# Eval("STATUS") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:TemplateField>
                 <%--    <asp:TemplateField>
            <ItemTemplate>
                <asp:Button Text="Edit" runat="server" CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>" />
            </ItemTemplate>
        </asp:TemplateField>--%>
                      <asp:TemplateField HeaderText="" SortExpression="TASKID">
                        <ItemTemplate>
                            <asp:LinkButton ID="TASKID" runat="server" CommandArgument='<%# Eval("TASKID") %>' commandSource='<%# Eval("TASKID") %>' CommandName="goto" Text='Edit'></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="150px"></ItemStyle>
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
       </div>
     
    
        <asp:Button ID="BtnCancel" runat="server" Text="Button" Style="display: none;" />
        <asp:Button ID="BtnOK" runat="server" Text="Button" Style="display: none;" />

   <div style="margin-top:500px;">        
   <div id="dialog" title="RPA Management" style="display: none;">
       
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </div>
 </div>   

</asp:Content>
