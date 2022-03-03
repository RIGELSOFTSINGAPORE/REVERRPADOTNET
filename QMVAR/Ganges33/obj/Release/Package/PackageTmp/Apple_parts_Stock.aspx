﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/AppleAnalysis.Master" CodeBehind="Apple_parts_Stock.aspx.vb" Inherits="Ganges33.Apple_parts_Stock" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script  src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.0/jquery.min.js"></script>
    <link type="text/css" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1/themes/start/jquery-ui.css" rel="stylesheet">
     <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1/jquery-ui.min.js"></script>--%>

   <script type="text/javascript" src="ExternalStyles/Jquery/jquery.min.js"></script>
     <script type="text/javascript" src="ExternalStyles/Jquery/jquery-ui.min.js"></script>
    

    <link href="ExternalStyles/Css/css.css" rel="stylesheet" />  
    <link href="ExternalStyles/Css/font-awesome.min.css" rel="stylesheet" />  
    <link href="ExternalStyles/Css/jquery-ui.css" rel="stylesheet" />

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
 <%-- <link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700|Roboto+Slab:400,700|Material+Icons" />
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/latest/css/font-awesome.min.css">--%>
  <!-- CSS Files -->
   <link href="assets/css/material-dashboard.css" rel="stylesheet" /> 
  <!-- CSS Just for demo purpose, don't include it in your project -->
  <link href="assets/demo/demo.css" rel="stylesheet" />
    <style type="text/css">
        .text{
           text-transform:capitalize;
       }
        .container{
    -ms-overflow-style: none;
    overflow: auto;
}      


#table1 {  
   border-collapse: collapse;
   border: 1px solid black;
  padding: 4px;  
}
th{
    border: 1px solid black;
  padding: 4px;  
    height: 28px;
    width: 141px;
    border: 1px solid black;
    background-color: #a953c2;
    text-align: left;
	color:white;
	font-weight: 400;
	text-align:center;
	
}
.td1{
    border: 1px solid black;
  padding: 4px;  
background-color: #a953c2;
color:white;	
font-weight: 400;
}
.textcenter{
    text-align:center;
}

.td2{
    border: 1px solid black;
  padding: 4px;  
text-align:right;
font-weight: 400;
}
.td3{
    text-align:center; 
    color:white;
    font-weight: 400;
    border: 1px solid black;
}
.btnfloat{
    float:right;
}
        .left1{
            margin-left:15px;
        }
        

   </style>
  
      
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <%--<asp:ObjectDataSource ID="source_session_online" runat="server" SelectMethod="session_online" TypeName="t_session" />
            
             <asp:UpdatePanel ID="updatepnl" UpdateMode="Always" runat="server">  
        <ContentTemplate> --%>
    <div class="wrapper  col-sm-12 sidebar-wrapper position-fixed scrolbar contain" id="style-10">
   
    <div class="content" >
        <div class="container-fluid">
          <div class="row">
            <div class="col-md-12">
              <div class="card">
                <div class="card-header card-header-primary">
                  <h3 class="card-title ">
                   ACC Parts Management</h3>
                  <p class="card-category"></p>
                </div>

                   <div class="card-body scrollbar" id="style-10" >


                      
<div class="row col-sm-12" runat="server" style="height:40px" id="search">
      <div>
          <label>
              Date
          </label>
      </div>
      <div  class="col-sm-2" style="margin-left:12px">
           <asp:DropDownList ID="DropDownList1" runat="server" Class="form-control" Width="160px" Style="height: 33px;">
                                  <asp:ListItem Text="Select Date" Value="00"></asp:ListItem>
                                     <asp:ListItem Text="LAST IN DATE" Value="01"></asp:ListItem>
                                      <asp:ListItem Text="LAST OUT DATE" Value="02"></asp:ListItem>
                                </asp:DropDownList>  

      </div>
                         <div  class="col-sm-" >
                             <label style="margin-left: 34px;">
                                 From :
                             </label>
                         </div>
                         <div  class="col-sm-2">
                        
   <asp:TextBox ID="txtFrom" CssClass="form-file-upload date serverlbl" style="width:107px" placeholder="yyyy/mm/dd" runat="server"   autocomplete="off"  ></asp:TextBox>
                     
                      
                   
                             </div>
                         
                            <div >
               <label >
                   To :
               </label>
      </div>
      <div  class="col-sm-2">
              <asp:TextBox ID="txtTodate" CssClass="form-file-upload date serverlbl" style="width:107px" placeholder="yyyy/mm/dd"  runat="server"></asp:TextBox>
                    
      </div>
                              
 <div style="margin-top: -3px;">
     
              <asp:Button ID="txtSearchGrid" Width="73px" margin-left="23px" height="30px" margin-top="0px" runat="server" OnClick="txtSearchGrid_Click"  Text="Search" class="btn btn-primary text" />
 <asp:Button ID="btnnewparts" Width="129px" margin-left="23px" height="30px" margin-top="0px" runat="server" OnClick="btnnewparts_Click"  Text="Add New Parts" class="btn btn-primary text" />     
 </div>
      <div  class="col-sm-1" style="margin-left:-12px;margin-top: -3px;">  
                  <asp:Button ID="btnback" Width="139px" margin-left="23px" height="30px" margin-top="0px" runat="server" OnClick="btnback_Click"  Text="Back to inventry" class="btn btn-primary text" />
      </div>

                          .<br /><br />
      </div>
 <br /><br /><br /><br />

                       <div class="row col-sm-12" style="height:40px" runat="server" id="Itemsearch">
                          <br />
                          <div >
               <label >
                       
                   Select
               </label>
      </div>
      <div  class="col-sm-2">
         
           <asp:DropDownList ID="DropDownList2" runat="server"  Class="form-control" Width="160px" Style="height: 33px;">
                                            <asp:ListItem Text="Select Item" Value="00"></asp:ListItem>
                                             <asp:ListItem Text="Part No" Value="01"></asp:ListItem>
                                             <asp:ListItem Text="UPC EAN" Value="02"></asp:ListItem>
                                            <asp:ListItem Text="Description" Value="03"></asp:ListItem>
                                            <asp:ListItem Text="Sap Description" Value="04"></asp:ListItem>
                                             <asp:ListItem Text="Stock In Hand" Value="05"></asp:ListItem>
               <asp:ListItem Text="Stock Zero" Value="06"></asp:ListItem>
               <asp:ListItem Text="Both(Zero and Stock In Hand)" Value="07"></asp:ListItem>

                                </asp:DropDownList>
          
      </div>
   
                                    <div>
                     
      </div>
      <div  class="col-sm-2">
                
          <asp:TextBox ID="txtSearch" placeholder="Search Item" style="margin-left:23px" CssClass="form-file-upload serverlbl" runat="server"></asp:TextBox>
          
                   
      </div>
                          <%-- <div >
               <label style="margin-left:13px">
                        
                   Po No
               </label>
      </div>--%>
      <div class="col-sm-3">
                
             <asp:DropDownList ID="DropDownList3" runat="server"  Class="form-control" Width="160px" Style="height: 33px;margin-left:11px">
                                            <asp:ListItem Text="Begin" Value="01"></asp:ListItem>
                                             <%--<asp:ListItem Text="" Value="01"></asp:ListItem>--%>
                                             <asp:ListItem Text="Contains" Value="02"></asp:ListItem>
                                            <asp:ListItem Text="End" Value="03"></asp:ListItem>
                                            <asp:ListItem Text="Exact" Value="04"></asp:ListItem>
                                            

                                </asp:DropDownList>
                   
      </div>
                                         <div class="col-sm-2">
              
                   
                <asp:Button ID="btnClear" Width="73px" margin-left="23px" height="30px" style="margin-left: 18px" OnClick="btnClear_Click" margin-top="0px" runat="server"  Text="Clear" class="btn btn-primary text" />
               
      </div>
      

                            
                           
      </div> <br />   <br />  <br />  <br />




                       <div class="row col-sm-12" style="height:40px" runat="server">
                           <div runat="server"  CssClass="pull-right" style="margin-left:auto;margin-right:10px">
                               <label >
                        Rows per page 
                   
               </label>
                               </div>  
               

<div style="margin-right:30px">     
    
          <asp:DropDownList ID="dropdownPage" runat="server"  Class="form-control" Width="100px" AutoPostBack="true" Style="height: 30px;">
                                             <asp:ListItem Text="20" Value="20"></asp:ListItem>     
        
        <asp:ListItem Text="50" Selected="True" Value="0"></asp:ListItem>
            <asp:ListItem Text="100" Value="100"></asp:ListItem>
<asp:ListItem Text="500" Value="500"></asp:ListItem>
<asp:ListItem Text="1000" Value="1000"></asp:ListItem>
                                            

                                </asp:DropDownList>
     </div>
                           <div style="margin-right:10px">
                               <asp:ImageButton ID="btnImgExcel" runat="server" src="icon/excel.png" CssClass=""  Style="width:37px;margin-right: 10px; height:36px" /> 
                           </div>
                  
          <br /><br />
     


                     
                           </div>
                       <div class="col-sm-12" runat="server" id="addnewrow" style="margin-left:-11px">

                    <div class="form-group">
     
         <div class="table-responsive">
        <%--<asp:Label ID="lblMessage" style="color:black" runat="server" ForeColor="Green" />--%>
            
            
            <br /> 
        <asp:gridview ID="Gridview1" Width="100%"  runat="server" 
                             AutoGenerateColumns="false" AllowPaging="true" PageSize="50" AllowSorting="true" OnPageIndexChanging="Gridview1_PageIndexChanging" OnSorting="Gridview1_Sorting"
                              CssClass="col-sm-12" Style="align-self: center"  HeaderStyle-BackColor="#8e24aa" HeaderStyle-ForeColor="White"
            
                                        Class="form-group"   
                                       >
                                         <PagerStyle HorizontalAlign = "left" CssClass = "GridPager" />
                                        <EmptyDataTemplate>No Records Available</EmptyDataTemplate>
                <EmptyDataRowStyle HorizontalAlign="Center" />
            <Columns>
                
                <asp:BoundField DataField="RowNumber" ItemStyle-HorizontalAlign="Center"   HeaderStyle-Width="15px" HeaderText="Row" />
                      
                
                 <asp:TemplateField HeaderText="Part No" HeaderStyle-CssClass="sort" ItemStyle-HorizontalAlign="Right" SortExpression="PART_NO" >
                      
                     <ItemTemplate>
                         
                        <asp:Label ID="lblpartno" runat="server"  Text='<%# Eval("PART_NO") %>'></asp:Label>
                         
                    </ItemTemplate>
                     
                    <EditItemTemplate>
</EditItemTemplate>
<ControlStyle ></ControlStyle>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="UPC EAN" HeaderStyle-CssClass="sort" ItemStyle-HorizontalAlign="Right" SortExpression="UPC_EAN" >
                    
                    <ItemTemplate>
                       
                        
                        <asp:Label ID="lblUPCEAN" runat="server"  Text='<%# Eval("UPC_EAN") %>'></asp:Label>
                        <ItemStyle ></ItemStyle>
                    </ItemTemplate>
                     
                    <EditItemTemplate>
</EditItemTemplate>
<ControlStyle ></ControlStyle>
                    
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description" HeaderStyle-CssClass="sort" ItemStyle-HorizontalAlign="Right" SortExpression="DESCRIPTION" >
                    
                    <ItemTemplate>
                       
                        <asp:Label ID="lblDESCRIPTION" runat="server"  Text='<%# Eval("DESCRIPTION") %>'></asp:Label>
                     
                    </ItemTemplate>
                      <ItemStyle ></ItemStyle>
                    <EditItemTemplate>
</EditItemTemplate>
<ControlStyle ></ControlStyle>
                   
                </asp:TemplateField>
                <asp:TemplateField   HeaderText="Sap Description" HeaderStyle-CssClass="sort" ItemStyle-HorizontalAlign="Right" SortExpression="SAP_PART_DESCRIPTION" >
                   <ItemTemplate >
                        <asp:Label ID="lblSAPPARTDESCRIPTION" runat="server"  Text='<%# Eval("SAP_PART_DESCRIPTION") %>'></asp:Label>
                    </ItemTemplate>
                  
                </asp:TemplateField>

                <asp:TemplateField   HeaderText="Purchase Price" HeaderStyle-CssClass="sort" ItemStyle-HorizontalAlign="Right" SortExpression="PURCHASE_PRICE" >
                   <ItemTemplate >
                        <asp:Label ID="lblPURCHASEPRICE" runat="server"  Text='<%# Eval("PURCHASE_PRICE") %>'></asp:Label>
                    </ItemTemplate>
                  
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="Sales Price" HeaderStyle-CssClass="sort" ItemStyle-HorizontalAlign="Right" SortExpression="SALES_PRICE" >
                   <ItemTemplate >
                        <asp:Label ID="lblSALESPRICE" runat="server"  Text='<%# Eval("SALES_PRICE") %>'></asp:Label>
                    </ItemTemplate>
                   
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="In Stock" HeaderStyle-CssClass="sort" ItemStyle-HorizontalAlign="Right" SortExpression="CURRENT_IN_STOCK" >
                   <ItemTemplate >
                        <asp:Label ID="lblCURRENTINSTOCK" runat="server"  Text='<%# Eval("CURRENT_IN_STOCK") %>'></asp:Label>
                    </ItemTemplate>
                  
                    
                </asp:TemplateField>
                <asp:TemplateField   HeaderText="Last Out Date" HeaderStyle-CssClass="sort" ItemStyle-HorizontalAlign="Right" SortExpression="LAST_OUT_DATE" >
                   <ItemTemplate >
                        <asp:Label ID="lblLASTOUTDATE" runat="server" Text='<%# Eval("LAST_OUT_DATE") %>'></asp:Label>
                    </ItemTemplate>
                   
                </asp:TemplateField>
                <asp:TemplateField   HeaderText="Last In Date" HeaderStyle-CssClass="sort" ItemStyle-HorizontalAlign="Right" SortExpression="LAST_IN_DATE" >
                   <ItemTemplate >
                        <asp:Label ID="lblLASTINDATE" runat="server"  Text='<%# Eval("LAST_IN_DATE") %>'></asp:Label>
                    </ItemTemplate>
                  
                </asp:TemplateField>

                 <asp:TemplateField   HeaderText="Part Tax" HeaderStyle-CssClass="sort" ItemStyle-HorizontalAlign="Right" SortExpression="PART_TAX" >
                   <ItemTemplate>
                        <asp:Label ID="lblPartStock" runat="server"  Text='<%# Eval("PART_TAX") %>'></asp:Label>
                    </ItemTemplate>

                  
                </asp:TemplateField>

                <asp:TemplateField  HeaderText="Purchesed So Far" Visible="false" HeaderStyle-CssClass="sort" ItemStyle-HorizontalAlign="Right" SortExpression="NUMBER_PURCHASED_SO_FAR" >
                   <ItemTemplate>
                        <asp:Label ID="lblPURCHASED_SO_FAR" runat="server"  Text='<%# Eval("NUMBER_PURCHASED_SO_FAR") %>'></asp:Label>
                    </ItemTemplate>

                  
                </asp:TemplateField>

                <asp:TemplateField  HeaderText="Sold_So Far" Visible="FALSE" HeaderStyle-CssClass="sort" ItemStyle-HorizontalAlign="Right" SortExpression="NUMBER_SOLD_SO_FAR" >
                   <ItemTemplate >
                        <asp:Label ID="lblNUMBER_SOLD_SO_FAR" runat="server"  Text='<%# Eval("NUMBER_SOLD_SO_FAR") %>'></asp:Label>
                    </ItemTemplate>

                  
                </asp:TemplateField>
                 
              <%-- <asp:TemplateField >
                        <ItemTemplate>
                            <asp:LinkButton ID="PART_NO" runat="server" DataNavigateUrlFields="PART_NO" DataNavigateUrlFormatString="~/Apple_AC_Parts_Create.aspx?PART_NO={0}"></asp:LinkButton> 
                        </ItemTemplate>

                        <ItemStyle ></ItemStyle>
                    </asp:TemplateField>--%>

                   <asp:HyperLinkField  Text="Edit"  DataTextField="" DataNavigateUrlFields="PART_NO" DataNavigateUrlFormatString="~/Apple_AC_Parts_Create.aspx?PART_NO={0}"
            HeaderText="" ItemStyle-Width = "20" />
            </Columns>
        </asp:gridview> 
             
             
          
                        </div>
                        
                       <%--<asp:Button ID="btnCommit"  HeaderStyle-Width="25px" runat="server" class="btn btn-primary text left1"  height="32px" Width="130px" OnClick="Button1_Click" Text="Save&Commit" />--%>

         </div>
        
                        </div>

                        </div>
 
             </div>  </div>
            
     </div>
            
    </div>
        </div>
              </div>

           
                   
                            
                   

           

                
           <%-- </ContentTemplate>
    
  </asp:UpdatePanel>--%>
    <div style="margin-top: 500px;">

        <div id="dialog" title="Stock Inventry" style="display: none;">

            <asp:Label ID="lblMsg" style="color:black" runat="server" Text=""></asp:Label>
        </div>
    </div> 
</asp:Content>
