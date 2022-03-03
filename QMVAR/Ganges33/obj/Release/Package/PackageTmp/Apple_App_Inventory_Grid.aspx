<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/AppleAnalysis.Master" CodeBehind="Apple_App_Inventory_Grid.aspx.vb" Inherits="Ganges33.Apple_App_Inventory_Grid" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
   
    <div class="content">
        <div class="container-fluid">
          <div class="row">
            <div class="col-md-12">
              <div class="card">
                <div class="card-header  card-header-primary">
                  <h3 class="card-title">
                       <asp:Label ID="lblApplePartsEntry" runat="server" Text=""></asp:Label>
                      <asp:label id="lblAppleInventry" Text="ACC Inventry" runat="server"> </asp:label>
                  </h3>
                  <p class="card-category"></p>
                </div>
                <div class="card-body scrollbar" id="style-10">           
                   
   
                          <div class="row" style="padding:0px;padding-left: 0px">
                    <div class="col-sm-6">
                                    <asp:Button ID="btnnewparts" margin-left="120px" Width="120px" height="32px" margin-top="0px" runat="server" Text="APP Parts Entry" OnClick="btnnewparts_Click" class="btn btn-primary text" />
                                           <asp:Button ID="btnPartsStock"   runat="server" class="btn btn-primary text " OnClick="btnPartsStock_Click" Width="155px" height="32px" Text="APP Parts Management " />  
                        <asp:Button ID="btnTransView" Width="190px" class="btn btn-primary text" OnClick="btnTransView_Click"   margin-left="23px" height="30px" margin-top="0px" runat="server" Text="APP Stock Tran View" /> 
                         
                        <br/> <br/>
                                 
                                </div>
                      <div class="pull-right col-sm-12" runat="server" id="backtolist">
                         
 <asp:Button ID="btninventryhome" runat="server" Width="150px" height="32px" style="margin-right: 6px;" Text="Back to Inventry" OnClick="btnShiphome_Click" class="btn btn-primary pull-right text"  />
                                                
                        </div>
                        
                        </div>
                     <div class="row" runat="server" id="Div1">
                       
                           <div class="col-sm-12" runat="server" id="search">
                           <div class="row">

                               
                            <div class="col-sm-3" style="padding-left:0px">
                                
                       <label style="margin-top: 3px;margin-left:16px"> From (yyyy/mm/dd) : </label>
                                </div>
                            <div class="col-sm-2" style="margin-left: -85px;">
                                                               
<asp:TextBox ID="txtdatefrom"  runat="server" style="width:111px" CssClass="form-control date" ></asp:TextBox>
                                 
                                </div>
                                <div style="margin-left:-33px">
                                
                       <label style="margin-top: 4px;margin-left:7px">To (yyyy/mm/dd) :</label>
                                </div>
                               <div class="col-sm-2" >
                                                               
<asp:TextBox ID="txtdateto" runat="server" style="width:111px" CssClass="form-control date"></asp:TextBox>
                                   
                                </div>

                               <div class="col-sm-2" style="margin-top: -2px;">
                             
                             <asp:Button ID="txtSearch1" Width="80px" margin-left="23px" height="32px" margin-top="0px" runat="server" OnClick="txtSearch1_Click" Text="Search" class="btn btn-primary text" />
                         </div>
                         <%--<div style="margin-left: 16px;margin-top:-15px;">
                             <br />
                             <asp:Button ID="btnnewparts" margin-left="120px" Width="150px" height="32px" margin-top="0px" runat="server" Text="New parts entry" OnClick="btnnewparts_Click" class="btn btn-primary text" />
                         </div>--%>
                               
                                </div>
                            </div>             
                        

                        </div>

                <div class="row" runat="server" id="data">                 
                         
                     
                    
                     <div class="col-sm-12 row" runat="server" id="backtolist1">
                        <div class="col-sm-2">
                            
                         <asp:Label ID="lblinvenrtry" CssClass="serverlbl" runat="server">Inventry Date :</asp:Label>
                            </div>
                        <div class="col-sm-3">
                            
                               <asp:TextBox ID="txtinventrtdate" Width="120px" ReadOnly="true" CssClass="form-control serverlbl" runat="server"></asp:TextBox>
                            </div>
                         <div class="col-sm-3">
                         <asp:Label ID="lblInfoInvNo" CssClass="serverlbl" style="font-weight:500" runat="server" Visible="false"></asp:Label>
                             </div>
                        </div>
                        <div class="form-group col-md-12" runat="server" id="grid1">
                           
                                    <asp:GridView ID="gridship" OnPageIndexChanging="gridship_PageIndexChanging" OnRowCommand="gridship_RowCommand" runat="server" AllowPaging="true" PageSize="10"
                                        Class="form-group" HeaderStyle-BackColor="#8e24aa" Width="500px" HeaderStyle-ForeColor="White"  
                                        AutoGenerateColumns="false">
                                         <PagerStyle HorizontalAlign = "left" CssClass = "GridPager" />
                                        <EmptyDataTemplate>No Records Available</EmptyDataTemplate>
                <EmptyDataRowStyle HorizontalAlign="Center" />
            <Columns>
                
                 <asp:TemplateField HeaderText="Inventery No">
                        <ItemTemplate>
                            
                        <asp:Label ID="inv_no" runat="server"  Text='<%# Eval("INVENTORY_NO") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:TemplateField>

               <%--<asp:BoundField  DataField="INVENTORY_DATE" Convert.ToDateTime(Eval("INVENTORY_DATE")).ToString("yyyy/MM/dd")  HeaderText="Inventery Date" />--%>

                <asp:TemplateField HeaderText="Inventery Date">
                        <ItemTemplate>
                            <asp:Label ID="partno" runat="server"  Text='<%# Eval("INVENTORY_DATE") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px"></ItemStyle>
                        </asp:TemplateField>
                <asp:TemplateField HeaderText="Updated Date">
                        <ItemTemplate>
                            <asp:Label ID="updateddate" runat="server"  Text='<%# Eval("UPDDT") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px"></ItemStyle>
                        </asp:TemplateField>


                <asp:TemplateField HeaderText="Manage">
                        <ItemTemplate>
                            <asp:LinkButton ID="invedit" runat="server" CommandArgument='<%# Eval("INVENTORY_NO") %>' commandSource='<%# Eval("INVENTORY_NO") %>' CommandName="goto2" Text='Edit'></asp:LinkButton> / 
                        <asp:LinkButton ID="ship_name" runat="server" CommandArgument='<%# Eval("INVENTORY_NO") %>' commandSource='<%# Eval("INVENTORY_NO") %>' CommandName="goto1" Text='View' ></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="150px"></ItemStyle>

                    </asp:TemplateField>
                <%--<asp:BoundField DataField="CREDIT_LIMIT" HeaderText="Credit Limit" />
                <asp:BoundField DataField="PER_DAY" HeaderText=" Consumption Per Day"/>   --%>
               
            </Columns>            
        </asp:GridView>
                               
                              </div>

                                         
                            <div class="col-sm-12"  runat="server"  id="grid2" >
                                <br />
                               
                    <div class="form-group">
                        
                        <div class="table-responsive">
                        <asp:GridView ID="getdata" runat="server"  AutoGenerateColumns="false" CellPadding="10" AllowSorting="true" 
                            AllowPaging="true" PageSize="10" OnPageIndexChanging="getdata_PageIndexChanging" OnRowCommand="getdata_RowCommand1"
                Style="align-self: center" HeaderStyle-BackColor="#8e24aa" HeaderStyle-ForeColor="White" OnSorting="getdata_Sorting" 
                            Width="100%"  ShowHeaderWhenEmpty="true" EmptyDataText="No records Found">
                             <PagerStyle HorizontalAlign = "left" CssClass = "GridPager" />
                <EmptyDataTemplate>No Records Available</EmptyDataTemplate>
                <EmptyDataRowStyle HorizontalAlign="Center" />
                            <%--<PagerStyle BackColor="Purple" />--%>
                <Columns>
             
                    <asp:BoundField DataField="RowNumber" ItemStyle-HorizontalAlign="Center"  HeaderStyle-Width="15px" HeaderText="Row" />
                    <asp:TemplateField HeaderText="Part No" HeaderStyle-CssClass="sort" ItemStyle-HorizontalAlign="Right" SortExpression="PART_NO">
                        <ItemTemplate>
                            <asp:Label ID="partno" runat="server" Text='<%# Eval("PART_NO") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle ></ItemStyle>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Upc Ean" HeaderStyle-CssClass="sort" ItemStyle-HorizontalAlign="Right" SortExpression="UPC_EAN">
                        <ItemTemplate>
                            <asp:Label ID="UPC_EAN" runat="server" Text='<%# Eval("UPC_EAN") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle ></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Description" HeaderStyle-CssClass="sort" ItemStyle-HorizontalAlign="Right" SortExpression="DESCRIPTION" >
                        
                        <ItemTemplate>
                            <asp:Label ID="lblDESCRIPTION" runat="server" Text='<%# Eval("DESCRIPTION") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle ></ItemStyle>
                       
                    </asp:TemplateField>

                   <asp:TemplateField HeaderText="Purchese Price" HeaderStyle-CssClass="sort" ItemStyle-HorizontalAlign="Right" SortExpression="PURCHASE_PRICE">
                       
                        <ItemTemplate>
                            <asp:Label ID="PURCHASE_PRICE" runat="server"  Text='<%# Eval("PURCHASE_PRICE") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle ></ItemStyle>
                    </asp:TemplateField>

                      <asp:TemplateField HeaderText="In Stock" HeaderStyle-CssClass="sort" ItemStyle-HorizontalAlign="Right" SortExpression="IN_STOCK">
                        
                        <ItemTemplate>
                            <asp:Label ID="IN_STOCK" runat="server"  Text='<%# Eval("IN_STOCK") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle></ItemStyle>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Sales Price" HeaderStyle-CssClass="sort" ItemStyle-HorizontalAlign="Right" SortExpression="SALES_PRICE" >
                       
                        <ItemTemplate>
                            <asp:Label ID="SALES_PRICE" runat="server"   Text='<%# Eval("SALES_PRICE") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle ></ItemStyle>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Inventory Date" HeaderStyle-CssClass="sort" ItemStyle-HorizontalAlign="Right" SortExpression="INVENTORY_DATE" >
                       
                        <ItemTemplate>
                            <asp:Label ID="InventoryDate" runat="server"   Text='<%# Eval("INVENTORY_DATE") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle ></ItemStyle>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Part Description" HeaderStyle-CssClass="sort" ItemStyle-HorizontalAlign="Right" SortExpression="SAP_PART_DESCRIPTION" >
                       
                        <ItemTemplate>
                            <asp:Label ID="SALESPRICE" runat="server"   Text='<%# Eval("SAP_PART_DESCRIPTION") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle></ItemStyle>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Part Tax" HeaderStyle-CssClass="sort" ItemStyle-HorizontalAlign="Right" SortExpression="PART_TAX" >
                       
                        <ItemTemplate>
                            <asp:Label ID="lblPART_TAX" runat="server"   Text='<%# Eval("PART_TAX") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle></ItemStyle>
                    </asp:TemplateField>

                 <%--    <asp:TemplateField>
            <ItemTemplate>
                <asp:Button Text="Edit" runat="server" CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>" />
            </ItemTemplate>HeaderStyle-CssClass="sort"
        </asp:TemplateField>--%>
                     <%-- <asp:TemplateField HeaderText="" SortExpression="UNQ_NO">
                        <ItemTemplate>
                            <asp:LinkButton ID="UNQ_NO" runat="server" CommandArgument='<%# Eval("UNQ_NO") %>' commandSource='<%# Eval("UNQ_NO") %>' CommandName="goto" Text='Edit'></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="100px"></ItemStyle>
                    </asp:TemplateField>--%>
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
   <div id="dialog" title="Inventry" style="display: none;">
       
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </div>
 </div>  
</asp:Content>
