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
                window.open("Analysis_Servicecenter_popup.aspx?rowindex=" + rowIndex, 'Popup', 'height=500,width=800,left=100,top=100,resizable=yes,scrollbars=yes,toolbar=yes,menu=no');
            });
        });

        $(function () {
            $('[id*=listShipBranch]').multiselect({

                includeSelectAllOption: true,
                maxHeight: 300,


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
                  <asp:Button  ID="btnAdd" runat="server" class="btn  btn-primary" OnClick="btnAdd_Click" Text="Add User"/>
                      </div>
              
                       <div class="row" runat="server" id="search">
                           <asp:Label ID="id" runat="server" Text="" Style="display:none "></asp:Label>
                          <div class="col-sm-12">
                           <div class="row col-sm-12">
                            <div >
                                <br />
                       <label> User Id:</label>
                                </div>
                            <div >
                                                                <br />
<asp:TextBox ID="txtSearch" runat="server" CssClass="form-control"  AutoPostBack="true"></asp:TextBox>
                                </div>
   
                                </div>
                            </div>
                      <div class="col-md-12">
                    <div class="form-group">
                   
                        <br />
                        <br />
                        <asp:GridView ID="GridSetupUser" runat="server" CellPadding="10"  PageSize="10" AutoGenerateColumns="false" 
                            OnRowCommand="GridSetupUser_RowCommand" AllowSorting="true" OnSorting="GridSetupUser_Sorting" OnPageIndexChanging="GridSetupUser_PageIndexChanging" AllowPaging="True" Style="align-self: center" HeaderStyle-BackColor="#8e24aa" HeaderStyle-ForeColor="White"  CssClass="col-sm-12" ShowHeaderWhenEmpty="true" EmptyDataText="No records Found">
                        
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
             

                    
                    <asp:TemplateField HeaderText="User Id" SortExpression="user_id" HeaderStyle-CssClass="sort" ItemStyle-Width="150">
                        
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
                                <asp:TemplateField HeaderText="DELFG" HeaderStyle-CssClass="sort"  SortExpression="DELFG" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="DELFG" runat="server" Text='<%# Eval("DELFG") %>'></asp:Label>
                        </ItemTemplate>
                        <%--<ItemTemplate>
                            <asp:Label ID="DELFG" runat="server" Text='<%# Eval("DELFG") %>'></asp:Label>
                        </ItemTemplate>--%>
                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Admin flag" HeaderStyle-CssClass="sort"  SortExpression="admin_flg" ItemStyle-Width="150">
                        
                        <ItemTemplate>
                            <asp:Label ID="Adminflage" runat="server" Text='<%# Eval("admin_flg") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="User level" SortExpression="user_level" HeaderStyle-CssClass="sort"  ItemStyle-Width="150">
                       
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
                    
                         
                          <div class="row">
                         <div class="form-group col-sm-4"  runat="server" id="lblUsername">
                             
                             <Label Class="bmd-label-floating">User Name :</Label> <b style="color:red; font-size:large" >*</b>
                             </div>
                          <div Class="form-group">
                      <%--<asp:DropDownList ID="DropListLocation" runat="server" CssClass="form-control " style="width: 270px; height:33px;">
                      </asp:DropDownList>--%>
                              <asp:TextBox ID="txtUserId" runat="server" CssClass="form-control" style="width: 270px; height:33px;" autocomplete="off"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" class="serverlbl "  ControlToValidate="txtUserId"
                            ForeColor="Red" ErrorMessage="UserName is Required"></asp:RequiredFieldValidator>    
                          </div>


                          </div>

                          <div class="row">
                           <div class="form-group col-sm-4 ">
                          <Label  runat="server"  CssClass="bmd-label-floating">Password :</Label> <b style="color:red; font-size:large" >*</b>
                               </div>
                              <div>
                     <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" style="width: 270px; height:33px;" autocomplete="off"></asp:TextBox>
                       
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" class="serverlbl "  runat="server" ControlToValidate="txtPassword"
                            ForeColor="Red" ErrorMessage="Password is Required"></asp:RequiredFieldValidator> 

                    
                  </div>
                   </div>

                          <div class="row">
                           <div class="form-group col-sm-4 ">
                          <Label  runat="server"  CssClass="bmd-label-floating">Engineer ID :</Label><b style="color:red; font-size:large" >*</b>
                               </div>
                              <div>
                     <asp:TextBox ID="txtEnggId" runat="server" CssClass="form-control " style="width: 270px; height:33px;" autocomplete="off"></asp:TextBox>
                       
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator2" class="serverlbl "  runat="server" ControlToValidate="txtEnggId"
                            ForeColor="Red" ErrorMessage="Engineer ID is Required"></asp:RequiredFieldValidator> 
                       

                    
                  </div>
                   </div>
                          <div class="row">
                           <div class="form-group col-sm-4 ">
                          <Label  runat="server"  CssClass="bmd-label-floating">User Level :</Label><b style="color:red; font-size:large" >*</b>
                               </div>
                              <div>
                     <asp:DropDownList ID="txtUserlvl" runat="server" CssClass="form-control " style="width: 270px; height:33px;" autocomplete="off">
                       <asp:ListItem  Text="Select..." Value="-1"></asp:ListItem>
                         <asp:ListItem Text="0" Value="0"></asp:ListItem> 
                         <asp:ListItem Text="1" Value="1"></asp:ListItem>
                          <asp:ListItem Text="2" Value="2"></asp:ListItem>
                          <asp:ListItem Text="3" Value="3"></asp:ListItem>
                          <asp:ListItem Text="4" Value="4"></asp:ListItem>
                          <asp:ListItem Text="5" Value="5"></asp:ListItem>
                          <asp:ListItem Text="6" Value="6"></asp:ListItem>
                          <asp:ListItem Text="7" Value="7"></asp:ListItem>
                          <asp:ListItem Text="8" Value="8"></asp:ListItem>
                          <asp:ListItem Text="9" Value="9"></asp:ListItem>
                          
                         </asp:DropDownList>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator3" class="serverlbl "  runat="server" ControlToValidate="txtUserlvl"
                            ForeColor="Red" ErrorMessage="Select the user level" InitialValue="-1"></asp:RequiredFieldValidator> 
                                  

                    
                  </div>
                   </div>
                          <div class="row">
                           <div class="form-group col-sm-4 ">
                          <Label  runat="server"  CssClass="bmd-label-floating">Branch Code1 :</Label><b style="color:red; font-size:large" >*</b>
                               </div>
                              <div>
                     <asp:TextBox ID="txtBranchCode1" runat="server" TextMode ="MultiLine" CssClass="form-control" style="width: 270px; height:33px;" autocomplete="off"></asp:TextBox><%--<b style="color:red; font-size:large" >*</b>--%>
                       <asp:ListBox ID="listShipBranch"  Width="100px"  class="multiselect-ui form-control" runat="server" SelectionMode="Multiple" multiple="multiple"></asp:ListBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator4" class="serverlbl "  runat="server" ControlToValidate="txtBranchCode1"
                            ForeColor="Red" ErrorMessage="Branch Code is required"></asp:RequiredFieldValidator> 
                       

                    
                  </div>
                   </div>
                          <div class="row">
                           <div class="form-group col-sm-4 ">
                               <br />
                          <Label  runat="server"  CssClass="bmd-label-floating">Branch Code2 :</Label>
                               </div>
                              <div>
                                      <br />
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
                          <Label  runat="server"  CssClass="bmd-label-floating">Surname :</Label><b style="color:red; font-size:large" >*</b>
                               </div>
                              <div>
                     <asp:TextBox ID="txtSurname" runat="server" CssClass="form-control " style="width: 270px; height:33px;" autocomplete="off"></asp:TextBox>
                       
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator5" class="serverlbl "  runat="server" ControlToValidate="txtSurname"
                            ForeColor="Red" ErrorMessage="Surname is required"></asp:RequiredFieldValidator> 
                       

                    
                  </div>
                   </div>
                              <div class="row">
                           <div class="form-group col-sm-4 ">
                          <Label  runat="server"  CssClass="bmd-label-floating">Name :</Label><b style="color:red; font-size:large" >*</b>
                               </div>
                              <div>
                     <asp:TextBox ID="txtName" runat="server" CssClass="form-control " style="width: 270px; height:33px;" autocomplete="off"></asp:TextBox>
                       
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator6" class="serverlbl "  runat="server" ControlToValidate="txtName"
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
                          <Label  runat="server"  CssClass="bmd-label-floating">DOB :</Label><b style="color:red; font-size:large" >*</b>
                               </div>
                              <div>
                     <asp:TextBox ID="txtdob" runat="server" CssClass="form-control date" style="width: 270px; height:33px;" autocomplete="off"></asp:TextBox>
                       
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator7" class="serverlbl "  runat="server" ControlToValidate="txtdob"
                            ForeColor="Red" ErrorMessage="DOB is required"></asp:RequiredFieldValidator> 
                       

                    
                  </div>
                   </div>
                             

</div>

<div class="col-sm-6">





                              <div class="row">
                           <div class="form-group col-sm-4 ">
                          <Label  runat="server"  CssClass="bmd-label-floating">Sex :</Label><b style="color:red; font-size:large" >*</b>
                               </div>
                              <div>
                     <%--<asp:TextBox ID="txtsex" runat="server" CssClass="form-control " style="width: 270px; height:33px;" autocomplete="off"></asp:TextBox>--%>
                       
                                 <asp:RadioButtonList ID="radionGender" runat="server">
                                <asp:ListItem Text="Male" Value="1" />
                                <asp:ListItem Text="Female" Value="0" />
                            </asp:RadioButtonList>
                                  
                       
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator8" class="serverlbl "  runat="server" ControlToValidate="radionGender"
                            ForeColor="Red" ErrorMessage="Gender is required"></asp:RequiredFieldValidator> 
                    
                  </div>
                   </div>
                              <div class="row">
                           <div class="form-group col-sm-4 ">
                          <Label  runat="server"  CssClass="bmd-label-floating">Superior :</Label><b style="color:red; font-size:large" >*</b>
                               </div>
                              <div>
                     <asp:TextBox ID="txtSuperior" runat="server" CssClass="form-control " style="width: 270px; height:33px;" autocomplete="off"></asp:TextBox>
                                  
                       
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator9" class="serverlbl "  runat="server" ControlToValidate="txtSuperior"
                            ForeColor="Red" ErrorMessage="Superior is Required"></asp:RequiredFieldValidator> 
                       

                    
                  </div>
                   </div>
                              <div class="row">
                           <div class="form-group col-sm-4 ">
                          <Label  runat="server"  CssClass="bmd-label-floating">Address Line 1 :</Label><b style="color:red; font-size:large" >*</b>
                                  
                               </div>
                              <div>
                     <asp:TextBox ID="txtAddressLine1" runat="server" TextMode="MultiLine" CssClass="form-control " style="width: 270px; height:33px;" autocomplete="off"></asp:TextBox>
                       
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator11" class="serverlbl "  runat="server" ControlToValidate="txtAddressLine1"
                            ForeColor="Red" ErrorMessage="Address is required"></asp:RequiredFieldValidator> 
                       

                    
                  </div>
                   </div>
                              <div class="row">
                           <div class="form-group col-sm-4 ">
                               <br />
                          <Label  runat="server"  CssClass="bmd-label-floating">Address Line 2 :</Label>
                               </div>
                              <div>
                                  <br />
                     <asp:TextBox ID="txtAddressLine2" runat="server" CssClass="form-control" TextMode="MultiLine"  style="width: 270px; height:33px;" autocomplete="off"></asp:TextBox>
                       

                    
                  </div>
                   </div>
                              <div class="row">
                           <div class="form-group col-sm-4 ">
                               <br />
                          <Label  runat="server"  CssClass="bmd-label-floating">Address Line 3 :</Label>
                               </div>
                              <div>
                                   <br />
                     <asp:TextBox ID="txtAddressLine3" runat="server" CssClass="form-control " TextMode="MultiLine"   style="width: 270px; height:33px;" autocomplete="off"></asp:TextBox>
                       

                    
                  </div>
                   </div>

                              <div class="row">
                           <div class="form-group col-sm-4 ">
                                <br />
                          <Label  runat="server"  CssClass="bmd-label-floating">Zip Code :</Label>
                               </div>
                              <div>
                                   <br />
                     <asp:TextBox ID="txtZipCode" runat="server" CssClass="form-control " style="width: 270px; height:33px;" autocomplete="off"></asp:TextBox>
                       

                    
                  </div>
                   </div>
                              <div class="row">
                           <div class="form-group col-sm-4 ">
                          <Label  runat="server"  CssClass="bmd-label-floating">Telephone No1:</Label><b style="color:red; font-size:large" >*</b>
                               </div>
                              <div>
                       <asp:TextBox ID="txtTelephone1" runat="server" CssClass="form-control " style="width: 270px; height:33px;" autocomplete="off"></asp:TextBox>
                                  
                     
     <asp:RequiredFieldValidator ID="RequiredFieldValidator13" class="serverlbl "  runat="server" ControlToValidate="txtTelephone1"
                            ForeColor="Red" ErrorMessage="Telephone No is Required"></asp:RequiredFieldValidator> 
                    
                  </div>
                   </div>
                              <div class="row">
                           <div class="form-group col-sm-4 ">
                          <Label  runat="server"  CssClass="bmd-label-floating">Mobile No:</Label><b style="color:red; font-size:large" >*</b>
                               </div>
                              <div>
                     <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control " style="width: 270px; height:33px;" autocomplete="off"></asp:TextBox>
                                  
                       
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator12" class="serverlbl "  runat="server" ControlToValidate="txtMobile"
                            ForeColor="Red" ErrorMessage="Mobile No required"></asp:RequiredFieldValidator> 
                       

                    
                  </div>

                   </div>
                              <div class="row">
                           <div class="form-group col-sm-4 ">
                          <Label  runat="server"  CssClass="bmd-label-floating">Email ID :</Label><b style="color:red; font-size:large" >*</b>
                               </div>
                              <div>
                     <asp:TextBox ID="txtEmailId" runat="server" CssClass="form-control " style="width: 270px; height:33px;" autocomplete="off"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" class="serverlbl "  ControlToValidate="txtEmailId"
                            ForeColor="Red" ErrorMessage="Email ID is required"></asp:RequiredFieldValidator>
                                  <asp:RegularExpressionValidator ID="validateEmail" runat="server"  Style=" margin-left: -112px;" CssClass="serverlbl " ErrorMessage="Invalid email." ForeColor="Red" ControlToValidate="txtEmailId" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" />
 
                    
                  </div>

                   </div>
                              <div class="row">
                           <div class="form-group col-sm-4 ">
                          <Label  runat="server"  CssClass="bmd-label-floating">Telephone No2 :</Label>
                               </div>
                              <div>
                      
                       <asp:TextBox ID="txtTelephone" runat="server" CssClass="form-control " style="width: 270px; height:33px;" autocomplete="off"></asp:TextBox>
                     
                       

                    
                  </div>

                   </div>
                              <div class="row" runat="server" id="del">
                           <div class="form-group col-sm-4 ">
                          <Label  runat="server"  CssClass="bmd-label-floating">Delete flag :</Label>
                               </div>
                              <div>
                     <%--<asp:TextBox ID="txtDeleteflag" runat="server" CssClass="form-control " style="width: 270px; height:33px;" autocomplete="off"></asp:TextBox>
                     --%>  <br />
                                  <asp:checkbox id="delflag" runat="server"></asp:checkbox>

                    
                  </div>

                   </div>
                               <div class="row">
                           <div class="form-group col-sm-4 ">
                          <Label  runat="server"  CssClass="bmd-label-floating">Admin Flag :</Label>
                               </div>
                              <div>
                                  <br />
                     <%--<asp:TextBox ID="txtAdminFlag" runat="server" CssClass="form-control " style="width: 270px; height:33px;" autocomplete="off"></asp:TextBox>--%>
                       <asp:checkbox id="admindelflg" runat="server"></asp:checkbox>

                    
                  </div>

                   </div>
 
    <div>
        <div class="row">
            <div class="col-sm-4"></div>
            <div>

                          <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" class="btn btn-primary " text="Save"/>    
    <asp:Button ID="Edit" runat="server" Text="Save" class="btn btn-primary " />   
                  <asp:Button ID="btnback" runat="server" CausesValidation="false" Text="Back" OnClick="btnback_Click" class="btn pull-right btn-primary " />
           
               
     
    
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
       </div>


    
        <asp:Button ID="BtnCancel" runat="server" Text="Button" Style="display: none;" />
        <asp:Button ID="BtnOK" runat="server" Text="Button" Style="display: none;" />

   

   
      <div style="margin-top:500px;">        
   
     <div id="dialog" title="User Management" style="display: none;">
       
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </div>
 </div>
 
</asp:Content>
