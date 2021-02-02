<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Analysis.Master" CodeBehind="Analysis_User.aspx.vb" Inherits="Ganges33.Analysis_User" %>
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
  <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
    <script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js" type="text/javascript"></script>
    <!-- CSS Files -->
   <link href="assets/css/material-dashboard.css" rel="stylesheet" /> 
  <!-- CSS Just for demo purpose, don't include it in your project -->
  <link href="assets/demo/demo.css" rel="stylesheet" />
    <style type="text/css">

        .container{
    -ms-overflow-style: none;
    overflow: auto;
}
        .Required{
            font-size: small;
        }
       
   </style>
    <script type="text/javascript">
        $(function () {
            $("[id*=View_userid]").click(function () {
                //alert("hi");
                var rowIndex = $(this)[0].getAttribute("data-commandargument");
                ////alert(rowIndex);
                window.open("Analysis_Servicecenter_popup.aspx?rowindex=" + rowIndex , 'Popup', 'height=500,width=800,left=100,top=100,resizable=yes,scrollbars=yes,toolbar=yes,menu=no');

            });
        });
        
           
   
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
                 
                      <h3 class="card-title " >
                      <asp:label id="Header" Text="" runat="server" >                      </asp:label>
                  
                  </h3>
                  <p class="card-category"></p>
                </div>
                 <div  class="card-body   scrollbar">
                 
                  <div>
                  <asp:Button  ID="btnAdd" runat="server" class="btn pull-right btn-primary" OnClick="btnAdd_Click" Text="Add User"/>
                      </div>
                <%-- <br />--%>
                       <div class="row">
                           <asp:Label ID="id" runat="server" Text="" Style="display:none "></asp:Label>
                      <div class="col-md-12">
                    <div class="form-group">
                    <%--<asp:GridView ID="GridSetupUser" runat="server" ForeColor="#333333" PageSize="10" AutoGenerateColumns="false" OnRowCommand="GridSetupUser_RowCommand" OnPageIndexChanging="GridSetupUser_PageIndexChanging" AllowPaging="True">
                        <AlternatingRowStyle BackColor="White" />
                        <HeaderStyle  BackColor="#800080"/>
                        <Columns>                           
                            <asp:BoundField DataField="DELFG" HeaderText="DELFG" />
                            <asp:BoundField DataField="user_id" HeaderText="User Id" />
                            <asp:BoundField DataField="password" HeaderText="Password" />
                            <asp:BoundField DataField="admin_flg" HeaderText="Admin flage" />
                            <asp:BoundField DataField="user_level" HeaderText="User level" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>--%>

                        <asp:GridView ID="GridSetupUser" runat="server"  PageSize="10" AutoGenerateColumns="false" 
                            OnRowCommand="GridSetupUser_RowCommand" OnPageIndexChanging="GridSetupUser_PageIndexChanging" AllowPaging="True" Style="align-self: center" HeaderStyle-BackColor="#8e24aa" HeaderStyle-ForeColor="White"  CssClass="col-sm-12" ShowHeaderWhenEmpty="true" EmptyDataText="No records Found">
                        
                       <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                <EmptyDataRowStyle HorizontalAlign="Center" />
                       <%-- <Columns>                           
                            <asp:BoundField DataField="DELFG" HeaderText="DELFG" />
                            <asp:BoundField DataField="user_id" HeaderText="User Id" />
                            <asp:BoundField DataField="password" HeaderText="Password" />
                            <asp:BoundField DataField="admin_flg" HeaderText="Admin flage" />
                            <asp:BoundField DataField="user_level" HeaderText="User level" />
                        </Columns>--%>

                            <Columns>
             

                    
                    <asp:TemplateField HeaderText="User Id" ItemStyle-Width="150">
                        
                        <ItemTemplate>
                            <asp:Label ID="UserId" runat="server" Text='<%# Eval("user_id") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Password" ItemStyle-Width="150">
                       
                        <ItemTemplate>
                            <asp:Label ID="Password" runat="server" Text='<%# Eval("password") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:TemplateField>
                                <asp:TemplateField HeaderText="DELFG" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="DELFG" runat="server" Text='<%# Eval("DELFG") %>'></asp:Label>
                        </ItemTemplate>
                        <%--<ItemTemplate>
                            <asp:Label ID="DELFG" runat="server" Text='<%# Eval("DELFG") %>'></asp:Label>
                        </ItemTemplate>--%>
                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Admin flage" ItemStyle-Width="150">
                        
                        <ItemTemplate>
                            <asp:Label ID="Adminflage" runat="server" Text='<%# Eval("admin_flg") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="User level" ItemStyle-Width="150">
                       
                        <ItemTemplate>
                            <asp:Label ID="Userlevel" runat="server" Text='<%# Eval("user_level") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:TemplateField>

                      <asp:TemplateField HeaderText="EDIT" ItemStyle-Width="150">
                        <ItemTemplate>
                             
                            <%--<asp:Button ID="btnEdit" runat="server" Width="60" OnClick="btnEdit_Click1"  
                                PostBackUrl='<%# "~/Analysis_User.aspx?User_id=" + Eval("user_id") %>' text="Edit"  />  --%>
                      
                            <asp:LinkButton ID="linkEdit" runat="server" CommandArgument='<%# Bind("user_id") %>' CommandName="goto" Text="Edit"></asp:LinkButton>
                      
                            <%--<asp:LinkButton ID="user_id" runat="server" CommandArgument='<%# Bind("user_id") %>' CommandName="goto" Text="Edit"></asp:LinkButton>--%>
                        </ItemTemplate>
                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:TemplateField>
                                <asp:TemplateField HeaderText="View" ItemStyle-Width="150">
                        <ItemTemplate>
                           <%-- <asp:LinkButton ID="View_userid" runat="server" CommandArgument='<%# Bind("user_id") %>' Text="View"></asp:LinkButton>--%>
                           
                             <asp:LinkButton ID="View_userid" runat="server" data-CommandArgument='<%# Eval("user_id") %>'  Text="View"></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:TemplateField>
                </Columns>

                        
                    </asp:GridView>
                         

                    </div>
                          </div>
                           </div>



                      <div class="row" runat="server" id="AddUser">
                        <div class="col-sm-6">
                      <div class="col-md-12 row" >
                          <div>
                          <div class="row">
                         <div class="form-group col-sm-4">
                             
                             <Label runat="server" id="lblUsername" CssClass="bmd-label-floating">User Name :</Label>
                             </div>
                          <div Class="form-group">
                      <%--<asp:DropDownList ID="DropListLocation" runat="server" CssClass="form-control " style="width: 270px; height:33px;">
                      </asp:DropDownList>--%>
                              <asp:TextBox ID="txtUserId" runat="server" CssClass="form-control" style="width: 270px; height:33px;" autocomplete="off"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" CssClass="Required" ControlToValidate="txtUserId"
                            ForeColor="Red" ErrorMessage="UserName is Required"></asp:RequiredFieldValidator>    
                          </div>


                          </div>

                          <div class="row">
                           <div class="form-group col-sm-4 ">
                          <Label  runat="server"  CssClass="bmd-label-floating">Password :</Label>
                               </div>
                              <div>
                     <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" style="width: 270px; height:33px;" autocomplete="off"></asp:TextBox><b style="color:red; font-size:large" >*</b>
                       
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="Required" runat="server" ControlToValidate="txtPassword"
                            ForeColor="Red" ErrorMessage="Password is Required"></asp:RequiredFieldValidator> 

                    
                  </div>
                   </div>

                          <div class="row">
                           <div class="form-group col-sm-4 ">
                          <Label  runat="server"  CssClass="bmd-label-floating">Engineer ID :</Label>
                               </div>
                              <div>
                     <asp:TextBox ID="txtEnggId" runat="server" CssClass="form-control " style="width: 270px; height:33px;" autocomplete="off"></asp:TextBox><b style="color:red; font-size:large" >*</b>
                       
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="Required" runat="server" ControlToValidate="txtEnggId"
                            ForeColor="Red" ErrorMessage="Engineer ID is Required"></asp:RequiredFieldValidator> 
                       

                    
                  </div>
                   </div>
                          <div class="row">
                           <div class="form-group col-sm-4 ">
                          <Label  runat="server"  CssClass="bmd-label-floating">User Leve1 :</Label>
                               </div>
                              <div>
                     <asp:TextBox ID="txtUserlvl" runat="server" CssClass="form-control " style="width: 270px; height:33px;" autocomplete="off"></asp:TextBox><b style="color:red; font-size:large" >*</b>
                       
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="Required" runat="server" ControlToValidate="txtUserlvl"
                            ForeColor="Red" ErrorMessage="User Leve1 required"></asp:RequiredFieldValidator> 
                                  

                    
                  </div>
                   </div>
                          <div class="row">
                           <div class="form-group col-sm-4 ">
                          <Label  runat="server"  CssClass="bmd-label-floating">Branch Code1 :</Label>
                               </div>
                              <div>
                     <asp:TextBox ID="txtBranchCode1" runat="server" CssClass="form-control" style="width: 270px; height:33px;" autocomplete="off"></asp:TextBox><b style="color:red; font-size:large" >*</b>
                       <asp:ListBox ID="test" runat="server" Width="100px" SelectionMode="Multiple" ></asp:ListBox>
                           <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="Required" runat="server" ControlToValidate="txtBranchCode1"
                            ForeColor="Red" ErrorMessage="Branch Code is required"></asp:RequiredFieldValidator> --%>
                       
<asp:ListBox ID="listShipBranch" runat="server"  Height="133px" Width="100px"  class="multiselect-ui form-control" multiple="multiple"  SelectionMode="Multiple">

                      </asp:ListBox>
                    
                  </div>
                   </div>
                          <div class="row">
                           <div class="form-group col-sm-4 ">
                          <Label  runat="server"  CssClass="bmd-label-floating">Branch Code2 :</Label>
                               </div>
                              <div>
                     <asp:TextBox ID="txtBranchCode2" runat="server" CssClass="form-control " style="width: 270px; height:33px;" autocomplete="off"></asp:TextBox>
                       

                    
                  </div>
                   </div>
                          <div class="row">
                           <div class="form-group col-sm-4 ">
                          <Label  runat="server"  CssClass="bmd-label-floating">Branch Code3 :</Label>
                               </div>
                              <div>
                     <asp:TextBox ID="txtBranchCode3" runat="server" CssClass="form-control " style="width: 270px; height:33px;" autocomplete="off"></asp:TextBox>
                       

                    
                  </div>
                   </div>
                          <div class="row">
                           <div class="form-group col-sm-4 ">
                          <Label  runat="server"  CssClass="bmd-label-floating">Branch Code4 :</Label>
                               </div>
                              <div>
                     <asp:TextBox ID="txtBranchCode4" runat="server" CssClass="form-control " style="width: 270px; height:33px;" autocomplete="off"></asp:TextBox>
                       

                    
                  </div>
                   </div>
                          <div class="row">
                           <div class="form-group col-sm-4 ">
                          <Label  runat="server"  CssClass="bmd-label-floating">Branch Code5 :</Label>
                               </div>
                              <div>
                     <asp:TextBox ID="txtBranchCode5" runat="server" CssClass="form-control " style="width: 270px; height:33px;" autocomplete="off"></asp:TextBox>
                       

                    </div>
                  </div>
                              <div class="row">
                           <div class="form-group col-sm-4 ">
                          <Label  runat="server"  CssClass="bmd-label-floating">Surname :</Label>
                               </div>
                              <div>
                     <asp:TextBox ID="txtSurname" runat="server" CssClass="form-control " style="width: 270px; height:33px;" autocomplete="off"></asp:TextBox><b style="color:red; font-size:large" >*</b>
                       
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="Required" runat="server" ControlToValidate="txtSurname"
                            ForeColor="Red" ErrorMessage="Surname is required"></asp:RequiredFieldValidator> 
                       

                    
                  </div>
                   </div>
                              <div class="row">
                           <div class="form-group col-sm-4 ">
                          <Label  runat="server"  CssClass="bmd-label-floating">Name :</Label>
                               </div>
                              <div>
                     <asp:TextBox ID="txtName" runat="server" CssClass="form-control " style="width: 270px; height:33px;" autocomplete="off"></asp:TextBox><b style="color:red; font-size:large" >*</b>
                       
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator6" CssClass="Required" runat="server" ControlToValidate="txtName"
                            ForeColor="Red" ErrorMessage="Name is required"></asp:RequiredFieldValidator> 
                       

                    
                  </div>
                   </div>
                              <div class="row">
                           <div class="form-group col-sm-4 ">
                          <Label  runat="server"  CssClass="bmd-label-floating">Middle Name :</Label>
                               </div>
                              <div>
                     <asp:TextBox ID="txtMiddleName" runat="server" CssClass="form-control " style="width: 270px; height:33px;" autocomplete="off"></asp:TextBox>
                       

                    
                  </div>
                   </div>
                              <div class="row">
                           <div class="form-group col-sm-4 ">
                          <Label  runat="server"  CssClass="bmd-label-floating">DOB :</Label>
                               </div>
                              <div>
                     <asp:TextBox ID="txtdob" runat="server" CssClass="form-control date" style="width: 270px; height:33px;" autocomplete="off"></asp:TextBox><b style="color:red; font-size:large" >*</b>
                       
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator7" CssClass="Required" runat="server" ControlToValidate="txtdob"
                            ForeColor="Red" ErrorMessage="DOB is required"></asp:RequiredFieldValidator> 
                       

                    
                  </div>
                   </div>
</div>

<div>



<%--<div class="col-md-8">--%>


                              <div class="row">
                           <div class="form-group col-sm-4 ">
                          <Label  runat="server"  CssClass="bmd-label-floating">Sex :</Label>
                               </div>
                              <div>
                     <%--<asp:TextBox ID="txtsex" runat="server" CssClass="form-control " style="width: 270px; height:33px;" autocomplete="off"></asp:TextBox>--%>
                       
                                 <asp:RadioButtonList ID="radionGender" runat="server">
                                <asp:ListItem Text="Male" Value="1" />
                                <asp:ListItem Text="Female" Value="0" />
                            </asp:RadioButtonList><b style="color:red; font-size:large" >*</b>
                                  
                       
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator8" CssClass="Required" runat="server" ControlToValidate="radionGender"
                            ForeColor="Red" ErrorMessage="Gender is required"></asp:RequiredFieldValidator> 
                    
                  </div>
                   </div>
                              <div class="row">
                           <div class="form-group col-sm-4 ">
                          <Label  runat="server"  CssClass="bmd-label-floating">Superior :</Label>
                               </div>
                              <div>
                     <asp:TextBox ID="txtSuperior" runat="server" CssClass="form-control " style="width: 270px; height:33px;" autocomplete="off"></asp:TextBox><b style="color:red; font-size:large" >*</b>
                                  
                       
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator9" CssClass="Required" runat="server" ControlToValidate="txtSuperior"
                            ForeColor="Red" ErrorMessage="Superior is Required"></asp:RequiredFieldValidator> 
                       

                    
                  </div>
                   </div>
                              <div class="row">
                           <div class="form-group col-sm-4 ">
                          <Label  runat="server"  CssClass="bmd-label-floating">Address Line 1 :</Label>
                               </div>
                              <div>
                     <asp:TextBox ID="txtAddressLine1" runat="server" TextMode="MultiLine" CssClass="form-control " style="width: 270px; height:33px;" autocomplete="off"></asp:TextBox><b style="color:red; font-size:large" >*</b>
                                  
                       
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator11" CssClass="Required" runat="server" ControlToValidate="txtAddressLine1"
                            ForeColor="Red" ErrorMessage="Address is required"></asp:RequiredFieldValidator> 
                       

                    
                  </div>
                   </div>
                              <div class="row">
                           <div class="form-group col-sm-4 ">
                          <Label  runat="server"  CssClass="bmd-label-floating">Address Line 2 :</Label>
                               </div>
                              <div>
                     <asp:TextBox ID="txtAddressLine2" runat="server" CssClass="form-control" TextMode="MultiLine"  style="width: 270px; height:33px;" autocomplete="off"></asp:TextBox>
                       

                    
                  </div>
                   </div>
                              <div class="row">
                           <div class="form-group col-sm-4 ">
                          <Label  runat="server"  CssClass="bmd-label-floating">Address Line 3 :</Label>
                               </div>
                              <div>
                     <asp:TextBox ID="txtAddressLine3" runat="server" CssClass="form-control " TextMode="MultiLine"   style="width: 270px; height:33px;" autocomplete="off"></asp:TextBox>
                       

                    
                  </div>
                   </div>

                              <div class="row">
                           <div class="form-group col-sm-4 ">
                          <Label  runat="server"  CssClass="bmd-label-floating">Zip Code :</Label>
                               </div>
                              <div>
                     <asp:TextBox ID="txtZipCode" runat="server" CssClass="form-control " style="width: 270px; height:33px;" autocomplete="off"></asp:TextBox>
                       

                    
                  </div>
                   </div>
                              <div class="row">
                           <div class="form-group col-sm-4 ">
                          <Label  runat="server"  CssClass="bmd-label-floating">Telephone No1:</Label>
                               </div>
                              <div>
                     <asp:TextBox ID="txtTelephone" runat="server" CssClass="form-control " style="width: 270px; height:33px;" autocomplete="off"></asp:TextBox>
                       

                    
                  </div>
                   </div>
                              <div class="row">
                           <div class="form-group col-sm-4 ">
                          <Label  runat="server"  CssClass="bmd-label-floating">Mobile No:</Label>
                               </div>
                              <div>
                     <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control " style="width: 270px; height:33px;" autocomplete="off"></asp:TextBox><b style="color:red; font-size:large" >*</b>
                                  
                       
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator12" CssClass="Required" runat="server" ControlToValidate="txtMobile"
                            ForeColor="Red" ErrorMessage="Mobile No required"></asp:RequiredFieldValidator> 
                       

                    
                  </div>

                   </div>
                              <div class="row">
                           <div class="form-group col-sm-4 ">
                          <Label  runat="server"  CssClass="bmd-label-floating">Email ID :</Label>
                               </div>
                              <div>
                     <asp:TextBox ID="txtEmailId" runat="server" CssClass="form-control " style="width: 270px; height:33px;" autocomplete="off"></asp:TextBox><b style="color:red; font-size:large" >*</b>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" CssClass="Required" ControlToValidate="txtEmailId"
                            ForeColor="Red" ErrorMessage="Email ID is required"></asp:RequiredFieldValidator>
                                  <asp:RegularExpressionValidator ID="validateEmail" runat="server" ErrorMessage="Invalid email." ControlToValidate="txtEmailId" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" />
 
                    
                  </div>

                   </div>
                              <div class="row">
                           <div class="form-group col-sm-4 ">
                          <Label  runat="server"  CssClass="bmd-label-floating">Telephone No2 :</Label>
                               </div>
                              <div>
                     <asp:TextBox ID="txtTelephone1" runat="server" CssClass="form-control " style="width: 270px; height:33px;" autocomplete="off"></asp:TextBox><b style="color:red; font-size:large" >*</b>
                                  
                       
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator13" CssClass="Required" runat="server" ControlToValidate="txtTelephone1"
                            ForeColor="Red" ErrorMessage="Telephone No is Required"></asp:RequiredFieldValidator> 
                       

                    
                  </div>

                   </div>
                              <div class="row">
                           <div class="form-group col-sm-4 ">
                          <Label  runat="server"  CssClass="bmd-label-floating">Delete flag :</Label>
                               </div>
                              <div>
                     <%--<asp:TextBox ID="txtDeleteflag" runat="server" CssClass="form-control " style="width: 270px; height:33px;" autocomplete="off"></asp:TextBox>
                     --%>  
                                  <asp:checkbox id="delflag" runat="server"></asp:checkbox>

                    
                  </div>

                   </div>
                               <div class="row">
                           <div class="form-group col-sm-4 ">
                          <Label  runat="server"  CssClass="bmd-label-floating">Admin Flag :</Label>
                               </div>
                              <div>
                     <%--<asp:TextBox ID="txtAdminFlag" runat="server" CssClass="form-control " style="width: 270px; height:33px;" autocomplete="off"></asp:TextBox>--%>
                       <asp:checkbox id="admindelflg" runat="server"></asp:checkbox>

                    
                  </div>

                   </div>
     <div>
                       
           <asp:Button ID="btnback" runat="server" CausesValidation="false" Text="Back" OnClick="btnback_Click" class="btn btn-primary " />
                      </div> 
    <div>
 <%--<asp:Button ID="btnUpload" runat="server" Text="Create" class="btn btn-primary " />--%>
                          <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" class="btn btn-primary pull-right" text="Save"/>    
                    </div>
     <div>
 <%--<asp:Button ID="btnUpload" runat="server" Text="Create" class="btn btn-primary " />--%>
                                <asp:Button ID="Edit" runat="server" Text="Save" class="btn btn-primary " />
                    </div>

                         

<%--</div>--%></div>
                   </div>
                        
                     </div>

                        </div>


                          <%--<div class="col-md-6">
                              <div class="row">
                        <div class="form-group col-sm-4">
                             <Label  runat="server" CssClass="bmd-label-floating" >Target Data</Label>
                            </div>
                    <div>
                             <asp:DropDownList ID="DropDownTargetData" runat="server" class="form-control " style="width: 270px; height:33px">
                      </asp:DropDownList>
                    
                  </div>
             </div>

                              <div class="row">
                  <div class="form-group col-sm-4">

                        <Label ID="Label7" runat="server" CssClass="bmd-label-floating">Date:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp From</Label>
                      </div>
                                  <div>
                      <asp:TextBox ID="TextDateFrom" runat="server" class="form-file-upload serverlbl  date" AutoCompleteType="Disabled" style="width: 120px; height:33px;"></asp:TextBox>
                      <%--<ajaxToolkit:CalendarExtender ID="TextDateFrom_CalendarExtender" runat="server" BehaviorID="TextDateFrom_CalendarExtender" TargetControlID="TextDateFrom" PopupPosition="Left">
                      </ajaxToolkit:CalendarExtender>--%>
                                   <%-- &nbsp;&nbsp;
                      <asp:Label ID="Label8" runat="server" class="bmd-label-floating serverlbl" Text="To"></asp:Label>&nbsp;&nbsp;
                      <asp:TextBox ID="TextDateTo" runat="server" class="form-file-upload serverlbl date" AutoCompleteType="Disabled" style="width: 120px; height:33px"></asp:TextBox>--%>
                     <%-- <ajaxToolkit:CalendarExtender ID="TextDateTo_CalendarExtender" runat="server" BehaviorID="TextDateTo_CalendarExtender" TargetControlID="TextDateTo" PopupPosition="right">
                      </ajaxToolkit:CalendarExtender>--%>

</div>
                  </div>
                  </div>                      </div>





                    <%-- cardidscroolbar div--%>
                     </div>
                  </div>
                </div>
             <%-- </div>--%>
           <%-- </div>
        </div>
       </div>--%>
    <asp:Button ID="BtnCancel" runat="server" Text="Button" Style="display: none;" />
        <asp:Button ID="BtnOK" runat="server" Text="Button" Style="display: none;" />

   

    <div id="dialog" title="message" style="display: none;">
       
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
