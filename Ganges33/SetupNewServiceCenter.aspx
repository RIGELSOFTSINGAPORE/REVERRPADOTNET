
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

    <%--<script>
         //   $(document).on("click", "[id*=lnkView]", (function () {
                 $(function () {
                 $("[id*=lnkView]").click(function () {
                var gridviewrow = $(this).closest("tr")[0].rowindex;
                window.open("Popup.aspx ? rowindex=" + gridviewrow, 'Popup', 'height=450,width=500,left=500,top=300,resizable=no,scrollbars=yes,toolbar=yes,menu=no');
            
            });
                 }

    </script>--%>

                    

   
                      
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

                          <label>Ship Name</label>  
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
                                Ship Info
                           </label>
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
                                Ship Manager
                           </label>
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
                                     Ship Tel
                                 </label>
                             </div>
                            <div>  <br />
                                 <asp:TextBox ID="ShipTel" runat="server" value="" Height="33px" width="270px" class="form-file-upload  serverlbl" MaxLength="20" />
                           <asp:RequiredFieldValidator class="serverlbl "  ID="STel" runat="server" ControlToValidate="ShipTel" ErrorMessage="Please enter a shipTel"   
ForeColor="Red"></asp:RequiredFieldValidator> 
                            </div>
                        </div>
                   

                    <div class="row">
                        <div class="col-sm-2">  <br />
                            <label>
                                Ship Add1
                            </label>
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
                                Ship Add2
                            </label>
                        </div>
                        <div>  <br />
                            <asp:TextBox ID="ShipAdd2" runat="server" value="" Height="33px" width="270px" class="form-file-upload   serverlbl" MaxLength="70" />
                          
                        </div>
                    </div>

          <div class="row">
                        <div class="col-sm-2">  <br />
                            <label>
                                Ship Add3
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
                            </label>
                        </div>
                        <div>  <br />
                            <asp:TextBox ID="Email" runat="server" value="" Height="33px" width="270px" class="form-file-upload   serverlbl" MaxLength="30" />
                            <asp:RequiredFieldValidator class="serverlbl "  ID="mail" runat="server" ControlToValidate="Email" ErrorMessage="Please enter a Email"   
ForeColor="Red"></asp:RequiredFieldValidator> 
                        </div>
                    </div>


         <div class="row">
                        <div class="col-sm-2">  <br />
                            <label>
                                Ship Service
                            </label>
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
                            </label>
                        </div>
                        <div>  <br />
                            <asp:TextBox ID="OpenTime" runat="server" value="" Height="33px" width="270px" class="form-file-upload duration   serverlbl" MaxLength="5" />
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
                            <asp:TextBox ID="CloseTime" runat="server" value="" Height="33px" width="270px" class="form-file-upload duration  serverlbl" MaxLength="5" />
                           
                        </div>
                    </div>

         <div class="row">
                        <div class="col-sm-2">  <br />
                            <label>
                                Opening Date
                            </label>
                        </div>
                        <div>  <br />
                            <asp:TextBox ID="OpeningDate" runat="server" value="" Height="33px" width="270px" class="form-file-upload date  serverlbl" />
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

         <div class="row">
                        <div class="col-sm-2">  <br />
                            <label id="lblshipcode" runat="server">
                                Ship Code
                            </label>
                        </div>
                        <div>  <br />
                            <asp:TextBox ID="ShipCode1" runat="server" value="" Height="33px" width="270px" class="form-file-upload   serverlbl" MaxLength="50" />
                           <asp:RequiredFieldValidator class="serverlbl "  ID="SCode" runat="server" ControlToValidate="ShipCode1" ErrorMessage="Please enter a ShipCode"   
ForeColor="Red"></asp:RequiredFieldValidator> 
                        </div>
                    </div>

         <div class="row">
                        <div class="col-sm-2"> 
                            <label>
                                Ship Mark
                            </label>
                        </div>
                        <div> 
                            <asp:TextBox ID="ShipMark" runat="server" value="" Height="33px" width="270px" class="form-file-upload   serverlbl" MaxLength="3" />
                           <asp:RequiredFieldValidator class="serverlbl "  ID="SMark" runat="server" ControlToValidate="ShipMark" ErrorMessage="Please enter a ShipMark"   
ForeColor="Red"></asp:RequiredFieldValidator> 
                        </div>
                    </div>

         <div class="row">
                        <div class="col-sm-2">  <br />
                            <label>
                                Item 1
                            </label>
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
                            </label>
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
                            </label>
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
                            </label>
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
                            </label>
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
                            </label>
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
                    </div>


                    </div>
                 <div>   <br />
                        <asp:Button ID="Back" runat="server"  CausesValidation="false" Text="Back" class="btn btn-primary pull-right" />
                    </div>     
     </div>



                    
                <div runat="server" id="data">
                  <div>
                      <asp:Button ID="Create" runat="server" Text="Create" class="btn btn-primary " />
                  </div>
                    <div>
                        <%--<asp:GridView ID="getdata" AutoGenerateColumns="false"  DataKeyNames="SHIP_CODE" runat="server">--%>
                        <br />
                            <asp:GridView ID="getdata" runat="server" AutoGenerateColumns="false" CellPadding="10"   AllowPaging="true" PageSize="10" OnPageIndexChanging="getdata_PageIndexChanging" OnRowCommand="getdata_RowCommand1"
                Style="align-self: center" HeaderStyle-BackColor="#8e24aa" HeaderStyle-ForeColor="White"  CssClass="col-sm-12" ShowHeaderWhenEmpty="true" EmptyDataText="No records Found">
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


                                   <asp:TemplateField HeaderText="SHIP_CODE" ItemStyle-Width="150" >
                        <ItemTemplate>
                            <asp:Label ID="SHIP_CODE1" runat="server" Text='<%# Eval("SHIP_CODE") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:TemplateField>





                                 <asp:TemplateField HeaderText="SHIP_NAME" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="SHIP_NAME" runat="server" Text='<%# Eval("SHIP_NAME") %>'></asp:Label>
                        </ItemTemplate>
                        <%--<ItemTemplate>
                            <asp:Label ID="SHIP_NAME" runat="server" Text='<%# Eval("SHIP_NAME") %>'></asp:Label>
                        </ItemTemplate>--%>
                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:TemplateField>


                                  <asp:TemplateField HeaderText="SHIP_INFO" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="SHIP_INFO" runat="server" Text='<%# Eval("SHIP_INFO") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:TemplateField>

                                  <asp:TemplateField HeaderText="SHIP_MANAGER" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="SHIP_MANAGER" runat="server" Text='<%# Eval("SHIP_MANAGER") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:TemplateField>

                                 <asp:TemplateField HeaderText="SHIP_SERVICE" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="SHIP_SERVICE" runat="server" Text='<%# Eval("SHIP_SERVICE") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:TemplateField>





                                 <asp:TemplateField HeaderText="SHIP_MARK" ItemStyle-Width="150" >
                        <ItemTemplate>
                            <asp:Label ID="SHIP_MARK" runat="server" Text='<%# Eval("SHIP_MARK") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:TemplateField>


                                  <%--<asp:TemplateField HeaderText="SHIP_TEL" ItemStyle-Width="150" visible="false">
                        <ItemTemplate>
                            <asp:Label ID="SHIP_TEL" runat="server" Text='<%# Eval("SHIP_TEL") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:TemplateField>--%>




                                 <asp:TemplateField HeaderText="DELFG" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="DELFG" runat="server" Text='<%# Eval("DELFG") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:TemplateField>

                  <%--<asp:TemplateField HeaderText="EDIT" ItemStyle-Width="150">--%>
                      <asp:TemplateField  ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:LinkButton ID="SHIP_CODE" runat="server" CommandArgument='<%# Bind("SHIP_CODE") %>' CommandName="goto" Text="Edit"></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="150px"></ItemStyle>
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

   

    <div id="dialog" title="message" style="display: none;">
       
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </div>


</asp:Content>

