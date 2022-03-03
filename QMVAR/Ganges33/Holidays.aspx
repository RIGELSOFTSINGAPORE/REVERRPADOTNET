<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Analysis.Master" CodeBehind="Holidays.aspx.vb" Inherits="Ganges33.Holidays" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
 <%--    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.0/jquery.min.js"></script>
    <link type="text/css" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1/themes/start/jquery-ui.css" rel="stylesheet">
     <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1/jquery-ui.min.js"></script>--%>
    	<%--<script src="//code.jquery.com/jquery-1.11.3.min.js"></script>--%>


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
<!--  <link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700|Roboto+Slab:400,700|Material+Icons" />
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/latest/css/font-awesome.min.css">
    <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
    <script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js" type="text/javascript"></script>-->
  
  <!-- CSS Files -->
   <link href="assets/css/material-dashboard.css" rel="stylesheet" /> 
  <!-- CSS Just for demo purpose, don't include it in your project -->
  <link href="assets/demo/demo.css" rel="stylesheet" />
 <%-- <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js"></script>
    <link href="https://www.jqueryscript.net/css/jquerysctipttop.css" rel="stylesheet" type="text/css">--%>

	<%--<link href="assets/css/timepicker.css" rel="stylesheet" />--%>

    <script src="assets/timepicker.js"></script>
     <script type="text/javascript">
         $(document).ready(function () {
             $(".simpleExample").timepicker();


         });
    </script>
    <style>
        .tme{
            border-color: blanchedalmond;
        border: 1px solid #d2d2d2;
    width: 188px;
    border-radius: 4px;
    margin-left:0px
        }

        .textbox{
            cursor:not-allowed;
        }
.my-timepicker-div .ampm-button{
  width: 4rem;
  height: 3rem;
}
.text{
    text-transform:capitalize;
}
.margin{
    margin-left:15px
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
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
   <div class="wrapper  col-sm-12 sidebar-wrapper position-fixed scrolbar contain" id="style-10">
   
    <div class="content" >
        <div class="container-fluid">
          <div class="row">
            <div class="col-md-12">
              <div class="card">
                <div class="card-header  card-header-primary">
                  <h3 class="card-title " >
                       <asp:Label ID="Label2" runat="server" Text="" Style="display:none "></asp:Label>
                      <asp:label id="Header" Text="" runat="server" > </asp:label>
                  </h3>
                  <p class="card-category"></p>
                </div>
                <div class="card-body scrollbar" id="style-10" >
              
                   
   
                          <div runat="server" id="addfile">
                    <div class="row">
                        <asp:Label ID="id" runat="server" Text="" Style="display:none "></asp:Label>
                        <div class="col-sm-2">
                            <br />
                          <label>Festival / Event</label>  
                        </div>
                        <div class="col-sm-2">
                              <br />
                             <asp:TextBox ID="txtHoliday" AutoComplete="off" runat="server"  Height="33px" Width="100%" class="form-file-upload  serverlbl" />
                        </div>
                        </div>
                        <%--<div class="row">
                            <div class="col-sm-2">
                                  <br />
                           <label>

                                Holiday Date
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
                        </div>--%>
                        <div class="row">
                          <div class="col-sm-2">
                                <br />
                              <label>
                                Date
                           </label>
                             </div>
                             <div class="col-sm-2">
                                   <br />
                              <asp:TextBox ID="txtdate" runat="server" value="" AutoCompleteType="Disabled"  Height="33px" Width="100%" class="form-file-upload date serverlbl" />
                           
                            </div>
                        </div>

                       <div class="row">
                        <asp:Label ID="Label1" runat="server" Text="" Style="display:none "></asp:Label>
                        <div class="col-sm-2">
                            <br />
                          <label>Branch Name</label>  
                        </div>
                        <div class="col-sm-2">
                              <br />
                             
     <asp:DropDownList ID="DropdownList1" runat="server" height="33px" Width="190px" Class="form-control"  >
         
                            </asp:DropDownList> 
                             <asp:TextBox ID="TextBox1" runat="server" ReadOnly="true"  Height="33px" Width="100%" class="form-file-upload textbox serverlbl" />
                        </div>
                        </div>
                   

                   <%-- <div class="row">
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
                    </div>--%>

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
                                Delete Flag
                            </label>
                        </div>
                        <div class="col-sm-2">
                              <br />
                            <asp:checkbox id="delfld" runat="server"></asp:checkbox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-2">
                             </div>
                   
                   
                            <div style="margin-left:13px;">
                                <br />
                                <asp:Button ID="btnUpload" runat="server" Width="80px" height="32px"  Text="Create" class="btn btn-primary text" />
                                
                                <asp:Button ID="Edit" runat="server" Text="Save" Width="80px" height="32px"  class="btn btn-primary text" />
                                 <asp:Button ID="Back" runat="server" Text="Back" Width="80px" height="32px"   class="btn btn-primary margin pull-right text text1" />
                    </div>


                    </div>
                    
               </div>
                    
                <div class="row" runat="server" id="data">



                    <div class="col-sm-12" runat="server" id="search">
                           <div class="row col-sm-12">
                            <div >
                                
                       <label style="margin-top: 3px;"> From : </label>
                                </div>
                            <div class="col-sm-2">
                                                               
<asp:TextBox ID="txtSearch" runat="server" CssClass="form-control date" ></asp:TextBox>
                                 <%--<ajaxToolkit:CalendarExtender ID="txtSearchDOB" Format="yyyy/MM/dd" runat="server" BehaviorID="txtSearch" TargetControlID="txtSearch"　PopupPosition="left">
                    </ajaxToolkit:CalendarExtender>--%>
                                </div>
                                <div>
                                
                       <label style="margin-top: 4px;margin-left:7px">To :</label>
                                </div>
                               <div class="col-sm-2">
                                                               
<asp:TextBox ID="txtSearch2" runat="server" CssClass="form-control date" ></asp:TextBox>
                                   <%-- <ajaxToolkit:CalendarExtender ID="txtSearchTo" runat="server" Format="yyyy/MM/dd" BehaviorID="txtSearch2" TargetControlID="txtSearch2"　PopupPosition="left">
                    </ajaxToolkit:CalendarExtender>--%>
                                </div>

                               <div class="col-sm-2">
                             
                             <asp:Button ID="txtSearch1" Width="80px" margin-left="23px" height="32px" margin-top="0px" runat="server" OnClick="txtSearch1_Click1" Text="Search" class="btn btn-primary text" />
                         </div>
                         <div style="margin-left: 16px;margin-top:-3px;">
                             <br />
                             <%--<asp:Button ID="Clear" margin-left="120px" Width="87px" height="32px" margin-top="0px" runat="server" Text="Cancle" OnClick="Clear_Click" class="btn btn-primary text" />--%>
                         </div>

   
                                </div>
                            </div>
                           <%-- <div style="margin-left: 16px; margin-top:4px;">
                  
    <asp:Button ID="Create" runat="server" Width="161px" Text="Create New Holiday" class="btn btn-primary text" />

                                <div style="margin-left: 768px; margin-top:-40px;">
                    <asp:Button ID="btnShiphome" runat="server" Width="200px" Text="Back To Branch List" class="btn btn-primary text" />
                      </div>
                    </div>--%>
                     




                    <div class="row ">
                         <div class="col-sm-1">
                            <%--<asp:Label id="Label1" runat="server"  CssClass="bmd-label-floating serverlbl"  style=" margin-top:4px" Text="From"></asp:Label>--%>
                              <asp:Button ID="Create" runat="server" Width="161px" style="margin-left:20px" Text="Create New Holiday" class="btn btn-primary text" />
                         </div>

                  <div class="col-sm-2">
                    
                 <%-- <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="yyyy/MM/dd" runat="server" BehaviorID="txtDateFrom" TargetControlID="txtDateFrom" PopupPosition="TopRight">
                      </ajaxToolkit:CalendarExtender>--%>
                      </div>

                       <div  class="col-sm-1">
                               
                                    
                             <%--<asp:Label ID="Label1"  Text="Month" runat="server"  class="bmd-label-floating " style="font-size:medium;font-weight:bold"></asp:Label>--%>
                          <%-- <asp:Label id="lblTo" runat="server" class="serverlbl  "  style=" margin-top:4px" Text="To"></asp:Label>&nbsp;&nbsp;&nbsp;--%>
                           
                        </div>
                            <div class="col-sm-2">

                                
                                <%--<ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="yyyy/MM/dd" runat="server" BehaviorID="txtDateTo" TargetControlID="txtDateTo" PopupPosition="TopRight">
                      </ajaxToolkit:CalendarExtender>--%>
				 <br /> <br />
                         </div>

                       <div class="col-sm-2" >
                         
 <asp:Button ID="btnShiphome" runat="server" Width="200px" style="margin-left:20px" Text="Back To Branch List" class="btn btn-primary text" />
                         </div>

                      </div>




                        <%--</div>--%>





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
                        

                    
                        <div class="form-group col-md-12" runat="server" id="grid1">
                           
                                    <asp:GridView ID="gridship" OnRowCommand="gridship_RowCommand" runat="server" AllowPaging="true" PageSize="10"
                                        Class="form-group" HeaderStyle-BackColor="#8e24aa" Width="500px" HeaderStyle-ForeColor="White"  
                                        AutoGenerateColumns="false"   >
                                         <PagerStyle HorizontalAlign = "left" CssClass = "GridPager" />
            <Columns>
               <asp:BoundField  DataField="ship_name" HeaderText="Branch Name" />

                <%--<asp:BoundField DataField="CREDIT_LIMIT" HeaderText="Credit Limit" />
                <asp:BoundField DataField="PER_DAY" HeaderText=" Consumption Per Day"/>   --%>
                <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:LinkButton ID="ship_name" runat="server" CommandArgument='<%# Eval("ship_name") %>' commandSource='<%# Eval("ship_name") %>' CommandName="goto1" Text='Manage Holidays'></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle ></ItemStyle>
                    </asp:TemplateField>
            </Columns>            
        </asp:GridView>
                               
                              </div>

                    
                        
                            <div class="col-md-12"  runat="server"  id="grid2">
                    <div class="form-group">
                        <%--<asp:GridView ID="getdata" runat="server"  AutoGenerateColumns="false" CellPadding="10" AllowSorting="true"  
                            AllowPaging="true" PageSize="10" OnPageIndexChanging="getdata_PageIndexChanging" OnRowCommand="getdata_RowCommand1"
                Style="align-self: center" HeaderStyle-BackColor="#8e24aa" HeaderStyle-ForeColor="White" OnSorting="getdata_Sorting" 
                            CssClass="col-sm-12" ShowHeaderWhenEmpty="true" EmptyDataText="No records Found">
                <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                <EmptyDataRowStyle HorizontalAlign="Center" />
                            
                <Columns>
             

                    <asp:TemplateField HeaderText="Holiday" HeaderStyle-CssClass="sort" SortExpression="HOLIDAY_TEXT" >
                        <ItemTemplate>
                            <asp:Label ID="Holiday" runat="server" Text='<%# Eval("HOLIDAY_TEXT") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px"></ItemStyle>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Holiday Date" HeaderStyle-CssClass="sort" SortExpression="HOLIDAY_DATE" >
                        <ItemTemplate>
                            <asp:Label ID="HolidayDate" runat="server" format="yyyy/mm/dd" Text='<%# Eval("HOLIDAY_DATE") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:TemplateField>
                   

                   <asp:TemplateField HeaderText="DELFG" HeaderStyle-CssClass="sort" SortExpression="DELFG" >
                       
                        <ItemTemplate>
                            <asp:Label ID="delflg" runat="server"  Text='<%# Eval("DELFG") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:TemplateField>

                    
                      <asp:TemplateField HeaderText="" SortExpression="UNQ_NO">
                        <ItemTemplate>
                            <asp:LinkButton ID="UNQ_NO" runat="server" CommandArgument='<%# Eval("UNQ_NO") %>' commandSource='<%# Eval("UNQ_NO") %>' CommandName="goto" Text='Edit'></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="100px"></ItemStyle>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>--%>
                        <div class="table-responsive">
                        <asp:GridView ID="getdata" runat="server"  AutoGenerateColumns="false" CellPadding="10" AllowSorting="true" 
                            AllowPaging="true" PageSize="10" OnPageIndexChanging="getdata_PageIndexChanging" OnRowCommand="getdata_RowCommand1"
                Style="align-self: center" HeaderStyle-BackColor="#8e24aa" HeaderStyle-ForeColor="White" OnSorting="getdata_Sorting" 
                            Width="900px"  ShowHeaderWhenEmpty="true" EmptyDataText="No records Found">
                             <PagerStyle HorizontalAlign = "left" CssClass = "GridPager" />
                <EmptyDataTemplate>No Records Available</EmptyDataTemplate>
                <EmptyDataRowStyle HorizontalAlign="Center" />
                            <%--<PagerStyle BackColor="Purple" />--%>
                <Columns>
             

                    <asp:TemplateField HeaderText="Festival / Event" >
                        <ItemTemplate>
                            <asp:Label ID="Holiday" runat="server" Text='<%# Eval("HOLIDAY_TEXT") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px"></ItemStyle>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date" HeaderStyle-CssClass="sort" SortExpression="HOLIDAY_DATE">
                        <ItemTemplate>
                            <asp:Label ID="HolidayDate" runat="server" format="yyyy/mm/dd" Text='<%# Eval("HOLIDAY_DATE") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="100px"></ItemStyle>
                    </asp:TemplateField>
                   <%-- <asp:TemplateField HeaderText="Ship Name" HeaderStyle-CssClass="sort" SortExpression="SHIP_NAME" >
                        
                        <ItemTemplate>
                            <asp:Label ID="Ship_Name" runat="server" Text='<%# Eval("SHIP_NAME") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px"></ItemStyle>
                       SortExpression="DELFG"
                    </asp:TemplateField>--%>

                   <asp:TemplateField HeaderText="DELFG" >
                       
                        <ItemTemplate>
                            <asp:Label ID="delflg" runat="server"  Text='<%# Eval("DELFG") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="100px"></ItemStyle>
                    </asp:TemplateField>

                     <%-- <asp:TemplateField HeaderText="Date" HeaderStyle-CssClass="sort" SortExpression="TEST_STATUS" >
                        
                        <ItemTemplate>
                            <asp:Label ID="TEST_STATUS" runat="server"  Text='<%# Eval("TEST_STATUS") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="STATUS" HeaderStyle-CssClass="sort" SortExpression="STATUS">
                       
                        <ItemTemplate>
                            <asp:Label ID="STATUS   " runat="server"   Text='<%# Eval("STATUS") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:TemplateField>--%>
                 <%--    <asp:TemplateField>
            <ItemTemplate>
                <asp:Button Text="Edit" runat="server" CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>" />
            </ItemTemplate>
        </asp:TemplateField>--%>
                      <asp:TemplateField HeaderText="" SortExpression="UNQ_NO">
                        <ItemTemplate>
                            <asp:LinkButton ID="UNQ_NO" runat="server" CommandArgument='<%# Eval("UNQ_NO") %>' commandSource='<%# Eval("UNQ_NO") %>' CommandName="goto" Text='Edit'></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="100px"></ItemStyle>
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
       </div>
     
        <asp:Button ID="BtnCancel" runat="server" Text="Button" Style="display: none;" />
        <asp:Button ID="BtnOK" runat="server" Text="Button" Style="display: none;" />

   <div style="margin-top:500px;">        
   <div id="dialog" title="Holidays" style="display: none;">
       
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </div>
 </div>   

</asp:Content>
