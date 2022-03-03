<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/AppleAnalysis.Master" CodeBehind="Apple_App_Stock_Transaction.aspx.vb" Inherits="Ganges33.Apple_App_Stock_Transaction" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
  <!--     Fonts and icons    -->
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
    
    <div class="wrapper  col-sm-12 sidebar-wrapper position-fixed scrolbar contain" id="style-10">
   
    <div class="content">
        <div class="container-fluid">
          <div class="row">
            <div class="col-md-12">
              <div class="card">
                <div class="card-header card-header-primary">
                  <h3 class="card-title ">
                    ACC Parts Transaction</h3>
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
                                     <asp:ListItem Text="CRTDT" Value="01"></asp:ListItem>
                                      <asp:ListItem Text="UPDDT" Value="02"></asp:ListItem>
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
    <asp:Button ID="btnback" Width="139px" margin-left="23px" height="30px" margin-top="0px" runat="server"  Text="Back to inventry" OnClick="btnback_Click" class="btn btn-primary text" />
 </div>
      <div  class="col-sm-1" style="margin-left:-12px;margin-top: -3px;">  
                  
      </div>

                          .<br /><br />
      </div>

                       <br /><br /><br /><br />

                       <div class="row col-sm-12" style="height:40px" runat="server">
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
                                             <asp:ListItem Text="Description" Value="02"></asp:ListItem>
                                            <asp:ListItem Text="Quantity" Value="03"></asp:ListItem>
                                            <asp:ListItem Text="Stock In(1)" Value="04"></asp:ListItem>
                                             <asp:ListItem Text="Stock Out(2)" Value="05"></asp:ListItem>

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
      <div class="col-sm-2" style="margin-left:auto">       
          
                  <%--<asp:ImageButton ID="btnImgExcel" runat="server" src="icon/excel.png" CssClass="pull-right"  Style="width:37px;margin-right: 10px; height:36px" /> 
          <br /><br />--%>
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

                      <%-- <div class="row col-sm-12" style="height:40px" runat="server">
                                                

                       <div >
               <label>
                        Rows as Per Page 
                   
               </label>
      </div>
      <div class="col-sm" style="margin-left:auto">       
          
                  <asp:DropDownList ID="dropdownPage" runat="server"  Class="form-control" Width="100px" AutoPostBack="true" Style="height: 30px;">
                                             <asp:ListItem Text="20" Value="20"></asp:ListItem>     
        
        <asp:ListItem Text="50" Selected="True" Value="0"></asp:ListItem>
            <asp:ListItem Text="100" Value="100"></asp:ListItem>
<asp:ListItem Text="500" Value="500"></asp:ListItem>
<asp:ListItem Text="1000" Value="1000"></asp:ListItem>

                                            

                                </asp:DropDownList>
          
      </div>

                     </div>--%>  







                       <div class="col-sm-12" runat="server" style="margin-left:-11px">

                    <div class="form-group">
     
         <div class="table-responsive">
        <%--<asp:Label ID="lblMessage" style="color:black" runat="server" ForeColor="Green" />--%>
            <asp:ObjectDataSource ID="source_session_online" runat="server" SelectMethod="session_online" TypeName="t_session" />
            
             <asp:UpdatePanel ID="updatepnl" UpdateMode="Conditional" runat="server">  
        <ContentTemplate> 
            
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
                      <asp:TemplateField HeaderText="CRTDT" HeaderStyle-CssClass="sort" ItemStyle-HorizontalAlign="Right" SortExpression="CRTDT" >
                      
                     <ItemTemplate>
                         
                        <asp:Label ID="lblcrtdt" runat="server"  Text='<%# Eval("CRTDT") %>'></asp:Label>
                         
                    </ItemTemplate>
                     
                    <EditItemTemplate>
</EditItemTemplate>
<ControlStyle ></ControlStyle>
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="UPDDT" HeaderStyle-CssClass="sort" ItemStyle-HorizontalAlign="Right" SortExpression="UPDDT" >
                      
                     <ItemTemplate>
                         
                        <asp:Label ID="lblupddt" runat="server"  Text='<%# Eval("UPDDT") %>'></asp:Label>
                         
                    </ItemTemplate>
                     
                    <EditItemTemplate>
</EditItemTemplate>
<ControlStyle ></ControlStyle>
                </asp:TemplateField>
                
                 <asp:TemplateField HeaderText="Part No" HeaderStyle-CssClass="sort" ItemStyle-HorizontalAlign="Right" SortExpression="PART_NO" >
                      
                     <ItemTemplate>
                         
                        <asp:Label ID="lblpartno" runat="server"  Text='<%# Eval("PART_NO") %>'></asp:Label>
                         
                    </ItemTemplate>
                     
                    <EditItemTemplate>
</EditItemTemplate>
<ControlStyle ></ControlStyle>
                </asp:TemplateField>
                 <asp:TemplateField   HeaderText="DESCRIPTION" HeaderStyle-CssClass="sort" ItemStyle-HorizontalAlign="Right" SortExpression="DESCRIPTION" >
                   <ItemTemplate >
                        <asp:Label ID="lblDESCRIPTION" runat="server"  Text='<%# Eval("DESCRIPTION") %>'></asp:Label>
                    </ItemTemplate>
                  
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="QUANTITY" HeaderStyle-CssClass="sort" ItemStyle-HorizontalAlign="Right" SortExpression="QUANTITY" >
                    
                    <ItemTemplate>
                       
                        
                        <asp:Label ID="lblQUANTITY" runat="server"  Text='<%# Eval("QUANTITY") %>'></asp:Label>
                        <ItemStyle ></ItemStyle>
                    </ItemTemplate>
                     
                    <EditItemTemplate>
</EditItemTemplate>
<ControlStyle ></ControlStyle>
                    
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TRAN TYPE" HeaderStyle-CssClass="sort" ItemStyle-HorizontalAlign="Right" SortExpression="TRAN_TYPE" >
                    
                    <ItemTemplate>
                       
                        <asp:Label ID="lblTRAN_TYPE" runat="server"  Text='<%# Eval("TRAN_TYPE") %>'></asp:Label>
                     
                    </ItemTemplate>
                      <ItemStyle ></ItemStyle>
                    <EditItemTemplate>
</EditItemTemplate>
<ControlStyle ></ControlStyle>
                   
                </asp:TemplateField>
                <asp:TemplateField   HeaderText="TRAN REF" HeaderStyle-CssClass="sort" ItemStyle-HorizontalAlign="Right" SortExpression="TRAN_REF" >
                   <ItemTemplate>
                        <asp:Label ID="lblTRANREF" runat="server"  Text='<%# Eval("TRAN_REF") %>'></asp:Label>
                    </ItemTemplate>
                  
                </asp:TemplateField>              
                
            </Columns>
        </asp:gridview> 
              </ContentTemplate> 
                  
  </asp:UpdatePanel>
             
             
          
                        </div>
                        
                       <%--<asp:Button ID="btnCommit"  HeaderStyle-Width="25px" runat="server" class="btn btn-primary text left1"  height="32px" Width="130px" OnClick="Button1_Click" Text="Save&Commit" />--%>

         </div>
        
                        </div>



                       </div>

                       </div>
 
             </div>  </div>
            
     </div>
            
    </div>
        </div>
              

    <div style="margin-top: 500px;">

        <div id="dialog" title="Stock Inventry" style="display: none;">

            <asp:Label ID="lblMsg" style="color:black" runat="server" Text=""></asp:Label>
        </div>
    </div> 
           
</asp:Content>
