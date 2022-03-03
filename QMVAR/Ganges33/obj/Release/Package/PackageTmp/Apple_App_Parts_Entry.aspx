<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/AppleAnalysis.Master" CodeBehind="Apple_App_Parts_Entry.aspx.vb" Inherits="Ganges33.Apple_App_Parts_Entry" %>
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



   </style>
  
       
<script type="text/javascript">
//$(function () {
//        $("[id*=btnAdd]").click(function () {
//            //Reference the GridView.
//            var gridView = $("[id*=gvCustomers]");

//            //Reference the first row.
//            var row = gridView.find("tr").eq(1);

//            //Check if row is dummy, if yes then remove.
//            if ($.trim(row.find("td").eq(0).html()) == "") {
//                row.remove();
//            }

//            //Clone the reference first row.
//            row = row.clone(true);

//            //Add the Name value to first cell.
//            var txtName = $("[id*=txtName]");
//            SetValue(row, 0, "name", txtName);

//            //Add the Country value to second cell.
//            var txtCountry = $("[id*=txtCountry]");
//            SetValue(row, 1, "country", txtCountry);

//            //Add the row to the GridView.
//            gridView.append(row);

//            return false;
//        });
   
        //$(function () {
        //    var gridView = $("[id*=Gridview1]");
        //var row = gridView.find("tr").eq(1).clone();
        //    $("[id*=ButtonAdd]").click(function () {
        //   // Reference the first row.
        //    var preindex = $(this).parent().parent().prev().find("td").eq(0).html();

        //    $("<tr>" + row.html() + "</tr>").insertBefore(gridView.find("tr:last"));
        //    $(this).parent().parent().prev().find("td").eq(0).html((parseInt(preindex)+1))
        //    return false;
        //});
        //});

    




    //$(function () {
    //    $("[id*=Gridview1] [id*=ButtonAdd]").click(function () {
            
    //        var preindex = $(this).parent().parent().prev().find("td").eq(0).html();

    //       $("<tr>" + row.html() + "</tr>").remove(gridView.find("tr:last"));
    //      $(this).parent().parent().prev().find("td").eq(0).html((parseInt(preindex) - 1))
    //      return false;
    //    })
    //});

    //$(function () {
    //    var gridView = $("[id*=Gridview1]");
    //    var row = gridView.find("tr").eq(1).clone();
    //    $("[id*=LinkButton2]").click(function () {
    //        //Reference the first row.
    //         
    //    });
    //}); 
    
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="true" runat="server"></asp:ScriptManager>
    
    
   
   <div class="wrapper  col-sm-12 sidebar-wrapper position-fixed scrolbar contain" id="style-10">
   
    <div class="content" >
        <div class="container-fluid">
          <div class="row">
            <div class="col-md-12">
              <div class="card">
                <div class="card-header card-header-primary">
                  <h3 class="card-title ">ACC Parts Entry</h3>
                  <p class="card-category"></p>
                </div>
                
                  <asp:Label ID="lblInventoryNo" runat="server" Visible="false" Text=""></asp:Label>






                   <div class="card-body scrollbar" id="style-10" >
                       
                      <%-- <div class="row" style="padding:0px;padding-left: 11px">
                    <div class="col-sm-2">
                        <br />
                           <label id="" class="fontFamily bmd-label-floating">Enter User:</label>
                      
                    </div>
                 
                    <div class="col-sm-2" style="margin-top: 12px;margin-left: -74px">
                         <label id="ibluser" class="fontFamily bmd-label-floating">asp1</label>
                    </div>
                   </div>--%>
                  
                        <div class="row" style="padding:0px;padding-left: 11px">
                    <div class="col-sm-5" >
                    
                            <label id="" class="fontFamily bmd-label-floating">Date (yyyy/mm/dd) :</label>
                      <asp:TextBox ID="txtDate" runat="server" class="form-file-upload date serverlbl" style="width: 120px;margin-left:16px" > </asp:TextBox>

                        <label id="lblStockType" class="fontFamily bmd-label-floating">Stock Type :</label>
                          <asp:DropDownList ID="drpStockType" CssClass="form-control serverlbl" style="height: 33px;margin-left: 24px; width: 135px;"  runat="server">
                              <asp:ListItem Text="Select" Value="0" Selected="True"></asp:ListItem>    
                             <asp:ListItem Text="Consignment" Value="1"></asp:ListItem>
                              <asp:ListItem Text="Stock" Value="2"></asp:ListItem>
                                   </asp:DropDownList>
                    </div>
                 
                   <%-- <div class="col-sm-2">
                        
                       


                        <br>
                        
                    </div>--%>
                            <div class="col-sm-7">
                               
                            <asp:Button ID="lblViewpart" style="float:right;margin-right: 20px;"  class="btn btn-primary text pull right" Height="32px" Width="150px" CausesValidation="false"  OnClick="Button1_Click" runat="server" Text="Back to Inventry" />
                                 
                  
                                <asp:Button ID="BtnSave" style="float:right;margin-right: 8px;" Width="100px"   class="btn btn-primary pull right text" height="32px" runat="server" Text="Save"  OnClick="BtnSave_Click" />

                               

                                <br />
                                 <label id="" class="fontFamily bmd-label-floating">
                         <asp:Label ID="lblInfoInvNo" runat="server" Visible="false"></asp:Label></label>
                            </div>
                                </div>
                   
			 <div class="row" style="padding:0px;padding-left: 11px">
                    <div class="col-sm-2">
                       
                           
                      
                    </div>
                 
                    <div class="col-sm-2" style="margin-left: -17px">
                        
                     
                    </div>
                   </div>

                        
                       

              <br />

                       
            <div class="col-sm-12">
                    <div class="form-group">
     
         <div class="table-responsive">
        <asp:Label ID="lblMessage" runat="server" ForeColor="Green" />
             <asp:Label ID="lblRequird" runat="server" style="font-size:small;font-weight:500"  ForeColor="Red" Visible="true">* Required</asp:Label>
             <asp:ObjectDataSource ID="source_session_online" runat="server" SelectMethod="session_online" TypeName="t_session" />
            
             <asp:UpdatePanel ID="updatepnl" UpdateMode="Conditional" runat="server">  
        <ContentTemplate> 

        <asp:gridview ID="Gridview1" Width="100%" runat="server" 
                             AutoGenerateColumns="false"
                             OnRowCreated="Gridview1_RowCreated" CssClass="col-sm-12" Style="align-self: center" HeaderStyle-BackColor="#8e24aa" HeaderStyle-ForeColor="White"
           Class="form-group">
                                         <PagerStyle HorizontalAlign = "left" CssClass = "GridPager" />
                                        <EmptyDataTemplate>No Records Available</EmptyDataTemplate>
                <EmptyDataRowStyle HorizontalAlign="Center" />
            <Columns>
                <asp:BoundField DataField="RowNumber" ItemStyle-HorizontalAlign="Center"  HeaderStyle-Width="15px" HeaderText="Row" />
                

                <asp:TemplateField HeaderText="Part Number">
                      

                    <ItemTemplate>
                        <div class="row" style="margin-left:0px"> 
                             <div style="width:85%">
                        
                        <asp:TextBox ID="TextBox1" ViewStateMode="Enabled" AutoPostBack="true" CssClass="form-control" OnTextChanged="TextBox1_TextChanged" Text='<%# Eval("PARTS_NO") %>'  runat="server"></asp:TextBox>
                        </div>
                             <div style="width:5%">
                                 <asp:RequiredFieldValidator ID="rfvQuantity" ControlToValidate="TextBox1" runat="server"
                    ErrorMessage="*" Font-Size="Smaller" ForeColor="Red"
                    ></asp:RequiredFieldValidator></div>  </div>  
                        <ItemStyle ></ItemStyle>

                    </ItemTemplate>
                  
                    <EditItemTemplate>

</EditItemTemplate>

<ControlStyle></ControlStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PARTS_NAME">
                    
                     <ItemTemplate>
                       <div class="row" style="margin-left:0px"> 
                             <div style="width:85%">
                        <asp:TextBox ID="TextBox2" CssClass="form-control" Enabled="false" runat="server" Text='<%# Eval("PARTS_NAME") %>'></asp:TextBox>
                                 </div>
                             <div style="width:5%">
                                 <br />
                                 </div>  </div>  
                        <ItemStyle></ItemStyle>
                    </ItemTemplate>
                    
                    <EditItemTemplate>
</EditItemTemplate>
<ControlStyle ></ControlStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PARTS_DESCRIPTION">
                      
                     <ItemTemplate>
                        <div class="row" style="margin-left:0px"> 
                             <div style="width:85%">
                        <asp:TextBox ID="TextBox3"  CssClass="form-control"  Enabled="false" runat="server" Text='<%# Eval("PARTS_DESCRIPTION") %>'></asp:TextBox>
                                 </div>
                             <div style="width:5%">
                                 <asp:RequiredFieldValidator ID="DESCRIPTION" ControlToValidate="TextBox3" runat="server"
                    ErrorMessage="*" Font-Size="Smaller"  ForeColor="Red"
                    ></asp:RequiredFieldValidator> </div>  </div> 
                        <ItemStyle Width="50px"></ItemStyle>
                    </ItemTemplate>
                   
                    <EditItemTemplate>
</EditItemTemplate>
<ControlStyle ></ControlStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PARTS_TYPE">
                      

                    <ItemTemplate>
                         <div class="row" style="margin-left:0px"> 
                             <div style="width:85%">
                        <asp:TextBox ID="TextBox4" CssClass="form-control"  runat="server" Text='<%# Eval("PARTS_TYPE") %>'></asp:TextBox>
                                 </div>
                             <div style="width:5%">
                        <asp:RequiredFieldValidator ID="SAP_PART_DESCRIPTION" ControlToValidate="TextBox4" runat="server"
                    ErrorMessage="*" Font-Size="Smaller" ForeColor="Red"
                    ></asp:RequiredFieldValidator></div>  </div>  
                        <ItemStyle Width="50px"></ItemStyle>
                    </ItemTemplate>
                   
                    <EditItemTemplate>
</EditItemTemplate>
<ControlStyle ></ControlStyle>

                </asp:TemplateField>
                 <asp:TemplateField HeaderText="PARTS_COST">
                      
                     <ItemTemplate>
                          <div class="row" style="margin-left:0px"> 
                             <div style="width:85%">
                        <asp:TextBox ID="TextBox5" CssClass="form-control" Enabled="false" runat="server" Text='<%# Eval("PARTS_COST") %>'></asp:TextBox>
                                 </div>
                             <div style="width:5%">
                         <asp:RequiredFieldValidator ID="PARTS_COST" ControlToValidate="TextBox5" runat="server"
                    ErrorMessage="*" Font-Size="Smaller" ForeColor="Red"
                    ></asp:RequiredFieldValidator></div>  </div>  
                        <ItemStyle Width="50px"></ItemStyle>
                    </ItemTemplate>
                     
                    <EditItemTemplate>
</EditItemTemplate>
<ControlStyle ></ControlStyle>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="TIER">
                    
                    <ItemTemplate>
                        
                         <div class="row" style="margin-left:0px"> 
                             <div style="width:85%">
                        <asp:TextBox ID="TextBox6" CssClass="form-control" Enabled="false"  runat="server" Text='<%# Eval("TIER") %>'></asp:TextBox>
                                 </div>
                             <div style="width:5%">
                        <asp:RequiredFieldValidator ID="TIER" ControlToValidate="TextBox6" runat="server"
                    ErrorMessage="*" Font-Size="Smaller" ForeColor="Red"
                    ></asp:RequiredFieldValidator> </div>  </div> 
                        <ItemStyle Width="50px"></ItemStyle>
                    </ItemTemplate>
                     
                    <EditItemTemplate>
</EditItemTemplate>
<ControlStyle></ControlStyle>
                    
                </asp:TemplateField>
                <asp:TemplateField HeaderText="EEE_EEEE">                   
                       
                    <ItemTemplate>
                         <div class="row" style="margin-left:0px"> 
                             <div style="width:85%">
                       <asp:TextBox ID="TextBox7" CssClass="form-control" Enabled="false" runat="server" Text='<%# Eval("EEE_EEEE") %>'></asp:TextBox>
                        </div>
                             <div style="width:5%">
                                       <asp:RequiredFieldValidator ID="EEE_EEEE" CssClass="" ControlToValidate="TextBox7" runat="server"
                    ErrorMessage="*" Font-Size="Smaller" ForeColor="Red"
                    ></asp:RequiredFieldValidator>   </div>  </div>       
                        <ItemStyle Width="20%"></ItemStyle>
                        
                    </ItemTemplate>                    
                    
<ControlStyle ></ControlStyle>                    
                </asp:TemplateField>

                <asp:TemplateField HeaderText="SERIAL">                   
                       
                    <ItemTemplate>
                         <div class="row" style="margin-left:0px"> 
                             <div style="width:85%">
                       <asp:TextBox ID="TextBox8" CssClass="form-control" Enabled="false" runat="server" Text='<%# Eval("SERIAL") %>'></asp:TextBox>
                        </div>
                             <div style="width:5%">
                                       <asp:RequiredFieldValidator ID="SERIAL" CssClass="" ControlToValidate="TextBox8" runat="server"
                    ErrorMessage="*" Font-Size="Smaller" ForeColor="Red"
                    ></asp:RequiredFieldValidator>   </div>  </div>       
                        <ItemStyle Width="20%"></ItemStyle>
                        
                    </ItemTemplate>                    
                    
<ControlStyle ></ControlStyle>                    
                </asp:TemplateField>










                <asp:TemplateField HeaderText="SERIAL_NO">                   
                       
                    <ItemTemplate>
                         <div class="row" style="margin-left:0px"> 
                             <div style="width:85%">
                       <asp:TextBox ID="TextBox9" CssClass="form-control" Enabled="false" runat="server" Text='<%# Eval("SERIAL_NO") %>'></asp:TextBox>
                        </div>
                             <div style="width:5%">
                                       <asp:RequiredFieldValidator ID="SERIAL_NO" CssClass="" ControlToValidate="TextBox9" runat="server"
                    ErrorMessage="*" Font-Size="Smaller" ForeColor="Red"
                    ></asp:RequiredFieldValidator>   </div>  </div>       
                        <ItemStyle Width="20%"></ItemStyle>
                        
                    </ItemTemplate>                    
                    
<ControlStyle ></ControlStyle>                    
                </asp:TemplateField>



                  <asp:TemplateField HeaderText="IN_STOCK">                   
                       
                    <ItemTemplate>
                         <div class="row" style="margin-left:0px"> 
                             <div style="width:85%">
                       <asp:TextBox ID="TextBox10" CssClass="form-control" Enabled="false" runat="server" Text='<%# Eval("IN_STOCK") %>'></asp:TextBox>
                        </div>
                             <div style="width:5%">
                                       <asp:RequiredFieldValidator ID="IN_STOCK" CssClass="" ControlToValidate="TextBox10" runat="server"
                    ErrorMessage="*" Font-Size="Smaller" ForeColor="Red"
                    ></asp:RequiredFieldValidator>   </div>  </div>       
                        <ItemStyle Width="20%"></ItemStyle>
                        
                    </ItemTemplate>                    
                    
<ControlStyle ></ControlStyle>                    
                </asp:TemplateField>


                 <asp:TemplateField HeaderText="BALANCE">                   
                       
                    <ItemTemplate>
                         <div class="row" style="margin-left:0px"> 
                             <div style="width:85%">
                       <asp:TextBox ID="TextBox11" CssClass="form-control" Enabled="false" runat="server" Text='<%# Eval("BALANCE") %>'></asp:TextBox>
                        </div>
                             <div style="width:5%">
                                       <asp:RequiredFieldValidator ID="BALANCE" CssClass="" ControlToValidate="TextBox11" runat="server"
                    ErrorMessage="*" Font-Size="Smaller" ForeColor="Red"
                    ></asp:RequiredFieldValidator>   </div>  </div>       
                        <ItemStyle Width="20%"></ItemStyle>
                        
                    </ItemTemplate>                    
                    
<ControlStyle ></ControlStyle>                    
                </asp:TemplateField>





                 








                 <asp:TemplateField HeaderStyle-Width="25px">
                   <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" CausesValidation="false"  runat="server" 
                                        onclick="LinkButton1_Click">Remove</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton2" runat="server">Remove</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>--%> 
            </Columns>
        </asp:gridview> 
             <br />
             <asp:Button ID="ButtonAdd" class="btn btn-primary pull-right text" CausesValidation="false" height="32px" Width="120px" runat="server" 
                                     Text="Add New Row" 
                                     onclick="ButtonAdd_Click" />

            <div style="">

        <div id="dialog" title="Stock Inventry" style="display: none;">

            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        </div>
    </div> 
             </ContentTemplate>
  
                  
  </asp:UpdatePanel>
          
                        </div>
                       
                          <asp:Button ID="btncommit" Width="150px"  margin-left="23px" class="btn btn-primary text" height="32px" OnClick="btncommit_Click1" runat="server" Text="Save & Complete"  />
                        
         </div>
                        </div>
    
   
        </div>
 
             </div>  </div>
            
     </div>
            
    </div>
        </div>
              </div>

           
                   
                            
                   

           

               
    
     

</asp:Content>