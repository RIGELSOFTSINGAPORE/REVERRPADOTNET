
<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Analysis.Master" CodeBehind="SetupNewServiceCenter.aspx.vb" Inherits="Ganges33.SetupNewServiceCenter" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.0/jquery.min.js"></script>
    <link type="text/css" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1/themes/start/jquery-ui.css" rel="stylesheet">
     <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1/jquery-ui.min.js"></script>
    <!--<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>-->

   <script type="text/javascript" src="ServiceCenter.js"></script>

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
     <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js"></script>
    <link href="https://www.jqueryscript.net/css/jquerysctipttop.css" rel="stylesheet" type="text/css">

	<link href="assets/css/timepicker.css" rel="stylesheet" />

    <script src="assets/timepicker.js"></script>
     <script type="text/javascript">
         $(document).ready(function () {
             $(".simpleExample").timepicker();


         });
    </script>
    <style type="text/css">

        .container{
    -ms-overflow-style: none;
    overflow: auto;
}
        
              
   </style>
    <script>
        function my_module_field_widget_time_range_form_alter(&$element, FormStateInterface $form_state, $context) {
            $element['value']['#attributes']['step'] = 60;
            $element['end_value']['#attributes']['step'] = 60;
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
                 <%-- <h3 class="card-title ">Setup New Servicecenter</h3>--%>
                    <h3 class="card-title " >
                      <asp:label id="Header" Text="" runat="server" > </asp:label>
                  </h3>
                  <p class="card-category"></p>
                </div>
                <div class="card-body " >
     <div runat="server" id="addfile">
                    <div class="row">
                        <div class="col-sm-2">

                          <label>Branch Name </label>  <b style="color:red; font-size:large" >*</b>
                        </div>
                        <div>
                             <asp:TextBox ID="ShipName" runat="server" value="" Height="33px" width="270px" class="form-file-upload  serverlbl" MaxLength="20" />
                        <asp:RequiredFieldValidator class="serverlbl "  ID="SName" runat="server" ControlToValidate="ShipName" ErrorMessage="Please enter a shipname"   
ForeColor="Red"></asp:RequiredFieldValidator> 
                     
                        </div>
                        </div>

                        <div class="row">
                          <div class="col-sm-2">
                              <br />
                              <label>
                                Branch Info
                           </label> <b style="color:red; font-size:large" >*</b>
                             </div>
                             <div> <br />
                              <asp:TextBox ID="ShipInfo" runat="server" value="" Height="33px" width="270px" class="form-file-upload  serverlbl" MaxLength="100" />
                           <asp:RequiredFieldValidator class="serverlbl "  ID="SInfo" runat="server" ControlToValidate="ShipInfo" ErrorMessage="Please enter a shipinfo"   
ForeColor="Red"></asp:RequiredFieldValidator> 
                            </div>
                        </div>
                        

                        <div class="row">
                          <div class="col-sm-2"> <br />
                              <label>
                                Branch Manager
                           </label> <b style="color:red; font-size:large" >*</b>
                             </div>
                             <div>  <br />
                              <asp:TextBox ID="ShipManager" runat="server" value="" Height="33px" width="270px" class="form-file-upload  serverlbl" MaxLength="20" />
                           <asp:RequiredFieldValidator class="serverlbl "  ID="SManager" runat="server" ControlToValidate="ShipManager" ErrorMessage="Please enter a shipManager"   
ForeColor="Red"></asp:RequiredFieldValidator> 
                            </div>
                        </div>
                        <div class="row">
                             <div class="col-sm-2">  <br />
                                 <label>
                                     Branch Tel
                                 </label> <b style="color:red; font-size:large" >*</b>
                             </div>
                            <div>  <br />
                                 <asp:TextBox ID="ShipTel" runat="server" value="" Height="33px" width="270px" class="form-file-upload  serverlbl" MaxLength="20" />
                         </div>  <div>
                             <br />
                             <br />

                                <asp:RequiredFieldValidator class="serverlbl "  ID="STel" runat="server" ControlToValidate="ShipTel" ErrorMessage="Please enter a shipTel" ForeColor="Red"></asp:RequiredFieldValidator> 
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Style=" margin-left: -140px;" CssClass="serverlbl " ControlToValidate="ShipTel" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                   

                    <div class="row">
                        <div class="col-sm-2">  <br />
                            <label>
                                Branch Add1
                            </label> <b style="color:red; font-size:large" >*</b>
                        </div>
                        <div>  <br />
                            <asp:TextBox ID="ShipAdd1" runat="server" value="" Height="33px" width="270px" class="form-file-upload   serverlbl" MaxLength="70" />
                           <asp:RequiredFieldValidator class="serverlbl "  ID="SAdd1" runat="server" ControlToValidate="ShipAdd1" ErrorMessage="Please enter a shipAdd1"   
ForeColor="Red"></asp:RequiredFieldValidator> 
                        </div>
                    </div>

             <div class="row">
                        <div class="col-sm-2">  <br />
                            <label>
                                Branch Add2
                            </label>
                        </div>
                        <div>  <br />
                            <asp:TextBox ID="ShipAdd2" runat="server" value="" Height="33px" width="270px" class="form-file-upload   serverlbl" MaxLength="70" />
                          
                        </div>
                    </div>

          <div class="row">
                        <div class="col-sm-2">  <br />
                            <label>
                                Branch Add3
                            </label>
                        </div>
                        <div>  <br />
                            <asp:TextBox ID="ShipAdd3" runat="server" value="" Height="33px" width="270px" class="form-file-upload   serverlbl" MaxLength="70" />
                           
                        </div>
                    </div>
          <div class="row">
                        <div class="col-sm-2">  <br />
                            <label>
                                Zip
                            </label>
                        </div>
                        <div>  <br />
                            <asp:TextBox ID="Zip" runat="server" value="" Height="33px" width="270px" class="form-file-upload   serverlbl" MaxLength="10" />
                           
                        </div>
                    </div>
            
             <div class="row">
                        <div class="col-sm-2">  <br />
                            <label>
                                Email
                            </label> <b style="color:red; font-size:large" >*</b>
                        </div>
                        <div>  <br />
                            <asp:TextBox ID="Email" runat="server" value="" Height="33px" width="270px" class="form-file-upload   serverlbl" MaxLength="30" />
                            </div><div>
                                <br />
                                <br />
                            <asp:RequiredFieldValidator class="serverlbl pull-left "  ID="mail" runat="server" ControlToValidate="Email" ErrorMessage="Please enter a Email"   
ForeColor="Red"></asp:RequiredFieldValidator> 
                             <asp:RegularExpressionValidator ID="validateEmail" Style=" margin-left: -140px;" CssClass="serverlbl pull-left" runat="server" ErrorMessage="Invalid email." ForeColor="Red" ControlToValidate="Email" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" />
 
                        </div>
                    </div>


         <div class="row">
                        <div class="col-sm-2">  <br />
                            <label>
                                Branch Service
                            </label> <b style="color:red; font-size:large" >*</b>
                        </div>
                        <div>  <br />
                            <asp:TextBox ID="ShipService" runat="server" value="" Height="33px" width="270px" class="form-file-upload   serverlbl" MaxLength="2" />
                            <asp:RequiredFieldValidator class="serverlbl "  ID="SService" runat="server" ControlToValidate="ShipService" ErrorMessage="Please enter a shipservice"   
ForeColor="Red"></asp:RequiredFieldValidator> 
                        </div>
                    </div>



         <div class="row">
                        <div class="col-sm-2">  <br />
                            <label>
                                Open Time
                            </label> <b style="color:red; font-size:large" >*</b>
                        </div>
                        <div>  <br />
                           
                            <asp:TextBox ID="OpenTime" CssClass=""  ToolTip="HH:mm:ss"  runat="server" value="00:00" Height="33px" width="270px" class="form-file-upload simpleExample   serverlbl" MaxLength="4" />
                            <asp:RequiredFieldValidator class="serverlbl "  ID="OT" runat="server" ControlToValidate="OpenTime" ErrorMessage="Please enter a OpenTime"   
ForeColor="Red"></asp:RequiredFieldValidator> 
                        </div>
                    </div>

         <div class="row">
                        <div class="col-sm-2">  <br />
                            <label>
                                Close Time
                            </label>
                        </div>
                        <div>  <br />
                            <asp:TextBox ID="CloseTime" runat="server"  value="00:00" step="1" ToolTip="HH:mm:ss" Height="33px" width="270px" class="form-file-upload simpleExample  serverlbl" MaxLength="5" />
                           
                        </div>
                    </div>

         <div class="row">
                        <div class="col-sm-2">  <br />
                            <label>
                                Opening Date
                            </label> <b style="color:red; font-size:large" >*</b>
                        </div>
                        <div>  <br />
                            <asp:TextBox ID="OpeningDate" runat="server" value="" Height="33px"  AutoCompleteType="Disabled" width="270px" class="form-file-upload date  serverlbl" />
                           <asp:RequiredFieldValidator class="serverlbl "  ID="OD" runat="server" ControlToValidate="OpeningDate" ErrorMessage="Please enter a OpenDate"   
ForeColor="Red"></asp:RequiredFieldValidator> 
                        </div>
                    </div>


         <div class="row">
                        <div class="col-sm-2">  <br />
                            <label>
                                Closing Date
                            </label>
                        </div>
                        <div>  <br />
                            <asp:TextBox ID="ClosingDate" runat="server" value="" Height="33px" width="270px" class="form-file-upload date  serverlbl" />
                           
                        </div>
                    </div>

         <div class="row" id="lblshipcode" runat="server">
                        <div class="col-sm-2"  >  <br />
                            <label>
                                Branch Code
                            </label> <b style="color:red; font-size:large" >*</b>
                        </div>
                        <div>  <br />
                            <asp:TextBox ID="ShipCode1" runat="server" value="" Height="33px" width="270px" class="form-file-upload   serverlbl" MaxLength="50" />
                          </div>
                            <div>
                             <br />
                             <br />

                                <asp:RequiredFieldValidator class="serverlbl "  ID="SCode" runat="server" ControlToValidate="ShipCode1" ErrorMessage="Please enter a ShipCode"   
ForeColor="Red"></asp:RequiredFieldValidator> 
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Style=" margin-left: -140px;" CssClass="serverlbl " ControlToValidate="ShipCode1" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                            </div>
                       
                    </div>

         <div class="row">
                        <div class="col-sm-2"> 
                            <br />
                            <label>
                                Branch Mark
                            </label> <b style="color:red; font-size:large" >*</b>
                        </div>
                        <div> 
                             <br />
                            <asp:TextBox ID="ShipMark" runat="server" value="" Height="33px" width="270px" class="form-file-upload   serverlbl" MaxLength="3" />
                           <asp:RequiredFieldValidator class="serverlbl "  ID="SMark" runat="server" ControlToValidate="ShipMark" ErrorMessage="Please enter a ShipMark"   
ForeColor="Red"></asp:RequiredFieldValidator> 
                        </div>
                    </div>

         <div class="row">
                        <div class="col-sm-2">  <br />
                            <label>
                                Item 1
                            </label> <b style="color:red; font-size:large" >*</b>
                        </div>
                        <div>  <br />
                            <asp:TextBox ID="Item1" runat="server" value="" Height="33px" width="270px" class="form-file-upload   serverlbl" MaxLength="10" />
                           <asp:RequiredFieldValidator class="serverlbl "  ID="IT1" runat="server" ControlToValidate="Item1" ErrorMessage="Please enter a Item1"   
ForeColor="Red"></asp:RequiredFieldValidator> 
                        </div>
                    </div>

         <div class="row">
                        <div class="col-sm-2">  <br />
                            <label>
                                Item 2
                            </label> <b style="color:red; font-size:large" >*</b>
                        </div> 
                        <div>  <br />
                            <asp:TextBox ID="Item2" runat="server" value="" Height="33px" width="270px" class="form-file-upload   serverlbl" MaxLength="50" />
                           <asp:RequiredFieldValidator class="serverlbl "  ID="IT2" runat="server" ControlToValidate="Item2" ErrorMessage="Please enter a Item2"   
ForeColor="Red"></asp:RequiredFieldValidator> 
                        </div>
                    </div>

         <div class="row">
                        <div class="col-sm-2">  <br />
                            <label>
                                Mess 1
                            </label> <b style="color:red; font-size:large" >*</b>
                        </div>
                        <div>  <br />
                            <asp:TextBox ID="Mess1" runat="server" value="" Height="33px" width="270px" class="form-file-upload   serverlbl" MaxLength="500" />
                           <asp:RequiredFieldValidator class="serverlbl "  ID="M1" runat="server" ControlToValidate="Mess1" ErrorMessage="Please enter a Mess1"   
ForeColor="Red"></asp:RequiredFieldValidator> 
                        </div>
                    </div>


         <div class="row"> 
                        <div class="col-sm-2">   <br />
                            <label>
                                Mess 2
                            </label> <b style="color:red; font-size:large" >*</b>
                        </div>
                        <div>    <br />
                            <asp:TextBox ID="Mess2" runat="server" value="" Height="33px" width="270px" class="form-file-upload   serverlbl" MaxLength="500" />
                           <asp:RequiredFieldValidator class="serverlbl "  ID="M2" runat="server" ControlToValidate="Mess2" ErrorMessage="Please enter a Mess2"   
ForeColor="Red"></asp:RequiredFieldValidator> 
                        </div>
                    </div>

         <div class="row">
                        <div class="col-sm-2">   <br />
                            <label>
                                Mess 3
                            </label> <b style="color:red; font-size:large" >*</b>
                        </div> 
                        <div>   <br />
                            <asp:TextBox ID="Mess3" runat="server" value="" Height="33px" width="270px" class="form-file-upload   serverlbl" MaxLength="500" />
                           <asp:RequiredFieldValidator class="serverlbl "  ID="M3" runat="server" ControlToValidate="Mess3" ErrorMessage="Please enter a Mess3"   
ForeColor="Red"></asp:RequiredFieldValidator> 
                        </div>
                    </div>

         <div class="row">
                        <div class="col-sm-2">   <br />
                            <label>
                                Regi Deposit
                            </label>
                        </div>
                        <div>   <br />
                            <asp:TextBox ID="RegiDeposit" runat="server" value="" Height="33px" width="270px" class="form-file-upload   serverlbl" MaxLength="50" />
                           
                        </div>
                    </div>

         <div class="row">
                        <div class="col-sm-2">   <br />
                            <label>
                                PO No
                            </label> <b style="color:red; font-size:large" >*</b>
                        </div>
                        <div>   <br />
                            <asp:TextBox ID="PO_NO" runat="server" value="" Height="33px" width="270px" class="form-file-upload   serverlbl" MaxLength="2" />
                           <asp:RequiredFieldValidator class="serverlbl "  ID="PoNo" runat="server" ControlToValidate="PO_NO" ErrorMessage="Please enter a PO_NO"   
ForeColor="Red"></asp:RequiredFieldValidator> 
                        </div>
                    </div>

                    <div class="row" runat="server" id="del">
                        <div class="col-sm-2">   <br />
                            <label >
                                Delete flag
                            </label>
                        </div>
                        <div>   <br />
                            <asp:checkbox id="delfld" runat="server"></asp:checkbox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-2">
                             </div>
                   
                   
                            <div>   <br />
 <asp:Button ID="btnAddNew" runat="server" Text="Create" class="btn btn-primary " />
                                 <asp:Button ID="Edit" runat="server" Text="Save" class="btn btn-primary " />
                                 <asp:Button ID="Back" runat="server"  CausesValidation="false" Text="Back" class="btn btn-primary pull-right" />
                 
                    </div>


                    </div>
                 <div>   <br />
                          </div>     
     </div>



                    
                <div runat="server" id="data">
                  <div>
                      <asp:Button ID="Create" runat="server" Text="Create" class="btn btn-primary " />
                  </div>
                     <div class="row col-sm-12">
                            <div >
                                
                                <br />
                       <label> Branch NAME:</label>
                                </div>
                            <div >

                                <br />
                               
                                  <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control"  AutoPostBack="true"></asp:TextBox>
                              
                                </div>
                            </div>
                    <div>
                         <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                            <asp:GridView ID="getdata" runat="server" AutoGenerateColumns="false" CellPadding="10"   AllowPaging="true" PageSize="10" OnPageIndexChanging="getdata_PageIndexChanging" OnRowCommand="getdata_RowCommand1"
                Style="align-self: center" HeaderStyle-BackColor="#8e24aa" OnSorting="getdata_Sorting" AllowSorting="true" HeaderStyle-ForeColor="White"  CssClass="col-sm-12" ShowHeaderWhenEmpty="true" EmptyDataText="No records Found">
                <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                <EmptyDataRowStyle HorizontalAlign="Center" />


                             <Columns>
        <%--<asp:BoundField DataField="SHIP_NAME" HeaderText="Ship Name" />
        <asp:BoundField DataField="SHIP_INFO" HeaderText="Ship Info" />
        <asp:BoundField DataField="SHIP_MANAGER" HeaderText="Ship Manager" />
        <asp:BoundField DataField="SHIP_SERVICE" HeaderText="Ship Service " />
        <asp:BoundField DataField="SHIP_CODE" HeaderText="Ship Code" />
        <asp:BoundField DataField="SHIP_MARK" HeaderText="ship Mark" />
        <asp:BoundField DataField="DELFG" HeaderText="Delflg" />--%>


                                   <asp:TemplateField HeaderText="Branch CODE" HeaderStyle-CssClass="sort" SortExpression="SHIP_CODE"  >
                        <ItemTemplate>
                            <asp:Label ID="SHIP_CODE1" runat="server" Text='<%# Eval("SHIP_CODE") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle ></ItemStyle>
                    </asp:TemplateField>





                                 <asp:TemplateField HeaderText="Branch NAME" HeaderStyle-CssClass="sort" SortExpression="SHIP_NAME" >
                        <ItemTemplate>
                            <asp:Label ID="SHIP_NAME" runat="server" Text='<%# Eval("SHIP_NAME") %>'></asp:Label>
                        </ItemTemplate>
                        <%--<ItemTemplate>
                            <asp:Label ID="SHIP_NAME" runat="server" Text='<%# Eval("SHIP_NAME") %>'></asp:Label>
                        </ItemTemplate>--%>
                        <ItemStyle ></ItemStyle>
                    </asp:TemplateField>


                                  <asp:TemplateField HeaderText="Branch INFO" HeaderStyle-CssClass="sort" SortExpression="SHIP_INFO" >
                        <ItemTemplate>
                            <asp:Label ID="SHIP_INFO" runat="server" Text='<%# Eval("SHIP_INFO") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle ></ItemStyle>
                    </asp:TemplateField>

                                  <asp:TemplateField HeaderText="Branch MANAGER" HeaderStyle-CssClass="sort" SortExpression="SHIP_MANAGER" >
                        <ItemTemplate>
                            <asp:Label ID="SHIP_MANAGER" runat="server" Text='<%# Eval("SHIP_MANAGER") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle ></ItemStyle>
                    </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Branch SERVICE" HeaderStyle-CssClass="sort" SortExpression="SHIP_SERVICE">
                        <ItemTemplate>
                            <asp:Label ID="SHIP_SERVICE" runat="server" Text='<%# Eval("SHIP_SERVICE") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle ></ItemStyle>
                    </asp:TemplateField>





                                 <asp:TemplateField HeaderText="Branch MARK" HeaderStyle-CssClass="sort" SortExpression="SHIP_MARK" >
                        <ItemTemplate>
                            <asp:Label ID="SHIP_MARK" runat="server" Text='<%# Eval("SHIP_MARK") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle ></ItemStyle>
                    </asp:TemplateField>


                                  <%--<asp:TemplateField HeaderText="SHIP_TEL" ItemStyle-Width="150" visible="false">
                        <ItemTemplate>
                            <asp:Label ID="SHIP_TEL" runat="server" Text='<%# Eval("SHIP_TEL") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle ></ItemStyle>
                    </asp:TemplateField>--%>




                                 <asp:TemplateField HeaderText="DELFG" HeaderStyle-CssClass="sort" SortExpression="DELFG" >
                        <ItemTemplate>
                            <asp:Label ID="DELFG" runat="server" Text='<%# Eval("DELFG") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle></ItemStyle>
                    </asp:TemplateField>

                  <%--<asp:TemplateField HeaderText="EDIT" ItemStyle-Width="150">--%>
                      <asp:TemplateField >
                        <ItemTemplate>
                            <asp:LinkButton ID="SHIP_CODE" runat="server" CommandArgument='<%# Bind("SHIP_CODE") %>' CommandName="goto" Text="Edit"></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle ></ItemStyle>
                    </asp:TemplateField>

                                <%--<asp:TemplateField >
                                       <ItemTemplate>
                                           <asp:Button id="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" />
                                       </ItemTemplate>
                                   </asp:TemplateField>--%>

                                 <%--<asp:TemplateField >
                                       <ItemTemplate>
                                           <asp:Button id="btnView" runat="server" Text="View" onclick="btnView_Click" />
                                       </ItemTemplate>
                                   </asp:TemplateField>

                                 <asp:TemplateField>--%>
                 <asp:TemplateField>
                     <ItemTemplate>
                   <%-- <asp:HyperLink ID="lnkView"  Text="View" NavigateUrl="#" runat="server"  />--%>
                         <%--<asp:HyperLink ID="lnkView"  Text="View" NavigateUrl="#" runat="server"  OnClick='<%#Eval("ship_code", "test.js(""){0}"");")%>'/>--%>
                        <asp:LinkButton ID="lnkView" runat="server" data-CommandArgument='<%# Eval("SHIP_CODE") %>'  Text="View"></asp:LinkButton>
                   </ItemTemplate>
                </asp:TemplateField>
                  <%--<asp:TemplateField>--%>
                                   
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

   

   
      <div style="margin-top:500px;">        
   
     <div id="dialog" title="Setup new service center" style="display: none;">
       
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </div>
 </div>


</asp:Content>

