<%@ Page Language="vb" Title="QMVAR-Analysis Data" AutoEventWireup="false" MasterPageFile="~/Analysis.Master" CodeBehind="Analysis_Store_Management.aspx.vb" Inherits="Ganges33.Analysis_Store_Management" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.0/jquery.min.js"></script>
    <link type="text/css" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1/themes/start/jquery-ui.css" rel="stylesheet">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1/jquery-ui.min.js"></script>

    <%--<link href="ExternalStyles/Css/css.css" rel="stylesheet"/>
    <link href="ExternalStyles/Css/font-awesome.min.css" rel="stylesheet" />
    <link href="ExternalStyles/Css/jquery-ui.css" rel="stylesheet" />
    <script src="ExternalStyles/Jquery/jquery-ui.min.js"></script>
    <script src="ExternalStyles/Jquery/jquery.min.js"></script>--%>
    <link href="ExternalStyles/Css/jquery-ui.css" rel="stylesheet" />

    <link href="assets/jquery-ui_theme.css" rel="stylesheet" />
    <link href="assets/jquery-ui.css" rel="stylesheet" />
    <script type="text/javascript" src="assets/jquery-ui.min_lips.js"></script>


    <link href="assets/css/material-dashboard.css" rel="stylesheet" />
    <link href="assets/css/material-dashboard-rtl.css" rel="stylesheet" />
    <link href="assets/css/material-dashboard.min.css" rel="stylesheet" />
    <meta charset="utf-8" />
    <link rel="apple-touch-icon" sizes="76x76" href="../assets/img/apple-icon.png">
    <link rel="icon" type="image/png" href="../assets/img/favicon.png">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />

    <meta content='width=device-width, initial-scale=1.0, shrink-to-fit=no' name='viewport' />
    <!--     Fonts and icons     -->
    <link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700|Roboto+Slab:400,700|Material+Icons" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/latest/css/font-awesome.min.css">
    <!-- CSS Files -->
    <link href="assets/css/material-dashboard.css" rel="stylesheet" />
    <!-- CSS Just for demo purpose, don't include it in your project -->
    <link href="assets/demo/demo.css" rel="stylesheet" />
    <style type="text/css">
        .text {
            text-transform: capitalize;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>



    <div class="wrapper  col-sm-12 sidebar-wrapper position-fixed scrolbar contain" id="style-10">

        <div class="content">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-md-12">
                        <div class="card">
                            <div class="card-header card-header-primary">


                                <h3 class="card-title ">
                                    <asp:Label ID="Label32" runat="server">Analysis Data</asp:Label>
                                    <asp:Label ID="Label3" runat="server">Store Management</asp:Label>
                                    <asp:Label ID="Label43" runat="server" Text="Credit Info Management"></asp:Label>
                                    <asp:Label ID="Label40" runat="server" Text="General Info "></asp:Label>
                                    <asp:Label ID="Label104" runat="server" Text="Count DRS"></asp:Label>
                                    <asp:Label ID="Label91" runat="server" Text="Payment Value"></asp:Label>
                                    <asp:Label ID="Label200" runat="server" Text="Collection"></asp:Label>
                                    <asp:Label ID="lblmontlytaget" runat="server" Text="Monthly Target"></asp:Label>

                                </h3>
                                <p class="card-category"></p>
                            </div>

                            <br />
                            <br />
                            <div class="card-body scrollbar" id="style-10">
                                <div>
                                    <div class="col-sm-12 row">
                                        <div class="col-sm-2" style="padding: 0px">


                                            <label class="bmd-label-floating">Process Model</label>

                                        </div>
                                        <div class=" ">
                                            <asp:DropDownList ID="drpManagementFunc" runat="server" AutoPostBack="true" Class="form-control" Width="220px" Style="height: 33px;">
                                                <asp:ListItem Text="Select" Value="00"></asp:ListItem>
                                                <asp:ListItem Text="Store Management" Value="01"></asp:ListItem>
                                                <asp:ListItem Text=" Credit Info Management" Value="02"></asp:ListItem>
                                                <asp:ListItem Text=" General Info " Value="03"></asp:ListItem>
                                                <asp:ListItem Text="Count DRS" Value="04"></asp:ListItem>
                                                <asp:ListItem Text="Payment Value" Value="05"></asp:ListItem>
                                                <asp:ListItem Text="Collection" Value="06"></asp:ListItem>
                                                <asp:ListItem Text="Monthly target" Value="07"></asp:ListItem>
                                                <asp:ListItem Text="Weekly Revenue" Value="08"></asp:ListItem>
                                                <asp:ListItem Text="Call Load" Value="09"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                                <%--startdiv--%>

                                <%--************  Stored Management **************--%>
                                <div class="" runat="server" id="Stored">
                                    <div class="row col-12">
                                        <div class="col-sm-2" style="padding: 0px">
                                            <br />
                                            <%--<div class="form-group droplistlocation">--%>
                                            <label class="bmd-label-floating">Download Type</label>
                                            <%-- </div>--%>
                                        </div>

                                        <div>
                                            <br />
                                            <asp:DropDownList ID="DrpDownloadExcel" runat="server" CssClass="Form-Control" Height="33px" Width="220px">
                                                <asp:ListItem Text="CSV" Value="01"></asp:ListItem>
                                                <asp:ListItem Text="Excel" Value="02"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <%--<div class="row col-md-12">
                                  <div class="col-sm-3">
                                    <div class="form-group droplistlocation">
                                <label class="bmd-label-floating"> Download Type</label>
                                  </div>
                                   </div>
                              <div class="form-group droplistlocation">
                                    <asp:DropDownList ID="DrpDownloadExcel" runat="server" CssClass="Form-Control" Height="33px" Width="220px">
                            <asp:ListItem Text="CSV" Value="01"></asp:ListItem>
                            <asp:ListItem Text="Excel" Value="02"></asp:ListItem>
                              </asp:DropDownList>
                              </div>
                          </div>--%>

                                    <div class="row col-12">
                                        <div class="col-sm-2" style="padding: 0px">
                                            <br />
                                            <%--<div class="form-group droplistlocation">--%>
                                            <label class="bmd-label-floating">Target Store</label>
                                            <%--</div>--%>
                                        </div>

                                        <div>
                                            <br />
                                            <asp:DropDownList ID="DropListLocation" runat="server" CssClass="Form-control" Height="33px" Width="220px">
                                            </asp:DropDownList>
                                        </div>
                                    </div>


                                    <div class="row col-12">
                                        <div class="col-sm-2" style="padding: 0px">
                                            <br />
                                            <%--<div class="form-group droplistlocation">--%>
                                            <label class="bmd-label-floating">Select Type</label>
                                            <%-- </div>--%>
                                        </div>
                                        <div>
                                            <br />
                                            <asp:DropDownList ID="DrpType" runat="server" Class="Form-control" Height="33px" Width="220px" AutoPostBack="true">
                                                <asp:ListItem Text="Select..." Value="0"></asp:ListItem>
                                                <asp:ListItem Text="4week" Value="01"></asp:ListItem>
                                                <asp:ListItem Text="Monthly" Value="02"></asp:ListItem>
                                                <asp:ListItem Text="Specified period" Value="03"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>

                                    </div>


                                    <div class="row col-12">
                                        <div class="col-sm-2" style="padding: 0px">
                                            <br />
                                            <%--<div class="form-group droplistlocation">--%>
                                            <label class="bmd-label-floating">GM</label>
                                            <%-- </div>--%>
                                        </div>
                                        <div>

                                            <br />
                                            <asp:TextBox ID="txtGM" class="Form-control" runat="server" Width="220px" Text="0.88"></asp:TextBox>

                                        </div>

                                    </div>


                                    <div class="row col-md-12">
                                        <div class="col-sm-2" style="padding: 0px">

                                            <label id="lblMonth" runat="server" visible="false" class="bmd-label-floating">Month</label>
                                            <label id="lblDateFrom" runat="server" cssclass="bmd-label-floating" visible="false">Date From (yyyy/mm/dd)</label>


                                        </div>
                                        <div class=" ">
                                            <asp:DropDownList ID="DropDownMonth" runat="server" CssClass="Form-control" Height="33px" Width="100%" Visible="false">
                                                <asp:ListItem Text="Select..." Value="0"></asp:ListItem>
                                                <asp:ListItem Text="January" Value="01"></asp:ListItem>
                                                <asp:ListItem Text="February" Value="02"></asp:ListItem>
                                                <asp:ListItem Text="March" Value="03"></asp:ListItem>
                                                <asp:ListItem Text="April" Value="04"></asp:ListItem>
                                                <asp:ListItem Text="May" Value="05"></asp:ListItem>
                                                <asp:ListItem Text="June" Value="06"></asp:ListItem>
                                                <asp:ListItem Text="July" Value="07"></asp:ListItem>
                                                <asp:ListItem Text="August" Value="08"></asp:ListItem>
                                                <asp:ListItem Text="September" Value="09"></asp:ListItem>
                                                <asp:ListItem Text="October" Value="10"></asp:ListItem>
                                                <asp:ListItem Text="November" Value="11"></asp:ListItem>
                                                <asp:ListItem Text="December" Value="12"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class=" ">
                                            <asp:DropDownList ID="DropDownYear" runat="server" CssClass="Form-control" Height="33px" Width="100%" Visible="false">
                                                <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                                                <asp:ListItem Text="2020" Value="2020"></asp:ListItem>
                                                <asp:ListItem Text="2021" Value="2021"></asp:ListItem>
                                                <asp:ListItem Text="2022" Value="2022"></asp:ListItem>
                                                <asp:ListItem Text="2023" Value="2023"></asp:ListItem>
                                                <asp:ListItem Text="2024" Value="2024"></asp:ListItem>
                                                <asp:ListItem Text="2025" Value="2025"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>



                                        <div id="lblDateTo" runat="server" class="form-group row">

                                            <div class="col-sm-4" style="padding-left: 0px">
                                                <div>
                                                    <label class="bmd-label-floating">From</label>
                                                </div>

                                                <div>
                                                    <asp:TextBox ID="TextDateFrom" runat="server" CssClass="serverlbl date form-control" AutoCompleteType="Disabled" Visible="false" Width="100%"></asp:TextBox>&nbsp;
                      <%--<ajaxToolkit:CalendarExtender ID="TextDateFrom_CalendarExtender" runat="server" BehaviorID="TextDateFrom_CalendarExtender" TargetControlID="TextDateFrom" PopupPosition="Left" Format="yyyy/MM/dd"></ajaxToolkit:CalendarExtender>--%>
                                                </div>
                                            </div>
                                            <div class="col-sm-4">
                                                <div>
                                                    <label class="bmd-label-floating" visible="false">To</label>
                                                </div>
                                                <div>
                                                    <asp:TextBox ID="TextDateTo" runat="server" CssClass="serverlbl date form-control" AutoCompleteType="Disabled" Visible="false" Width="100%"></asp:TextBox>
                                                    <%--<ajaxToolkit:CalendarExtender ID="TextDateTo_CalendarExtender" runat="server" BehaviorID="TextDateTo_CalendarExtender" TargetControlID="TextDateTo" PopupPosition="right" Format="yyyy/MM/dd"></ajaxToolkit:CalendarExtender>--%>
                                                </div>
                                            </div>
                                        </div>

                                    </div>



                                    <div class="col-sm-12">
                                        <asp:Button ID="btnSend" runat="server" Width="90px" Height="36px" Text="Send" CssClass="btn btn-primary pull-right text" />
                                    </div>
                                </div>

                                <%--************End Stored Management **************--%>

                                <%--************Start Creditinfo management **************--%>

                                <div runat="server" id="Credit">
                                    <div class=" ">
                                        <div class="form-group col-md-12" style="padding-left: 0px">
                                            <asp:GridView ID="CreitInfo" runat="server" Class="form-group" HeaderStyle-BackColor="#8e24aa" CssClass="col-sm-6" HeaderStyle-ForeColor="White" AutoGenerateColumns="false">
                                                <Columns>
                                                    <asp:BoundField DataField="BRANCH_NO" HeaderText="Service center" />
                                                    <asp:BoundField DataField="CREDIT_LIMIT" HeaderText="Credit Limit" />
                                                    <asp:BoundField DataField="PER_DAY" HeaderText=" Consumption Per Day" />
                                                </Columns>
                                            </asp:GridView>
                                        </div>

                                        <div class="col-sm-12" style="padding-left: 0px">
                                            <br />
                                            <label style="font-weight: bold" id="LblINFO" class="bmd-label-floating" runat="server">CREDIT VALUE CHANGE</label>
                                            <br />
                                        </div>
                                        <div class="row col-sm-6 ">
                                            <div class="col-sm-5" style="padding-left: 0px">
                                                <label id="Label9" class="bmd-label-floating" runat="server">Select Service Center</label>
                                            </div>
                                            <div>
                                                <asp:DropDownList ID="DropdownList1" AutoPostBack="true" runat="server" Class="Form-control" Height="33px" Width="173px">
                                                </asp:DropDownList>
                                            </div>

                                        </div>




                                        <%--<div class="row col-sm-12">
                            <div class=" col-sm-6" style="padding-left:0px">
                                       <Label ID="Label33" Class="bmd-label-floating" runat="server" style="font-weight:bold" >CREDIT LIMIT</Label>
                                  </div>
                         <div >
                                       <Label ID="Label51" Class="bmd-label-floating" runat="server" style="font-weight:bold" >CONSUMPTION PER DAY</Label>
                                  </div>
                     </div >

                    <div class="row col-sm-6">
                        <div class="col-sm-5">
                        <Label ID="Label11" Class="bmd-label-floating" runat="server" >Current Value</Label>
                       </div>
                        <div >
                                <asp:TextBox ID="TextBox5" ReadOnly="true" class="form-control" style="width: 92%;" runat="server"></asp:TextBox>
                         </div>
                    </div>
                    
                    <div class="row col-sm-6">
                        <div class="col-sm-5">
                                <Label ID="Label15" Class="bmd-label-floating" runat="server" >Current Value</Label>
                         </div>
                        <div >
                                <asp:TextBox ID="TextBox6" Class="Form-control" style="width: 92%;" ReadOnly="true" runat="server"></asp:TextBox>
                    </div>
                        </div>
              
               
  <div class="row col-sm-6">
                        <div class="col-sm-5 ">
                            <br />
                        <Label ID="Label12" Class="bmd-label-floating" runat="server" >New Value</Label>
                        </div>
                         <div  >
                             <br />
                                <asp:TextBox ID="TextBox3" Class="form-control" style="width: 92%;" runat="server"></asp:TextBox>
                        </div>
                    </div>
  
                    <div class="row col-sm-6">
                         <div class="col-sm-5">
                               <br />
                                <Label ID="Label16" Class="bmd-label-floating" runat="server" >New Value</Label>
                       </div>
                        <div>
                           
                             <br />
                                <asp:TextBox ID="TextBox4" style="width: 92%;" Class="form-control" runat="server"></asp:TextBox>
                                </div>
                        </div>--%>


                                        <div class="row col-sm-12">
                                            <div class=" col-sm-6" style="padding-left: 0px">
                                                <div>
                                                    <label id="Label33" class="bmd-label-floating" runat="server" style="font-weight: bold">CREDIT LIMIT</label>
                                                </div>

                                                <div class="row col-sm-12">
                                                    <div class="col-sm-5" style="padding-left: 0px">
                                                        <label id="Label11" class="bmd-label-floating" runat="server">Current Value</label>
                                                    </div>
                                                    <div>
                                                        <asp:TextBox ID="TextBox5" ReadOnly="true" class="form-control" Style="width: 100%;" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="row col-sm-12">
                                                    <div class="col-sm-5 " style="padding-left: 0px">
                                                        <br />
                                                        <label id="Label12" class="bmd-label-floating" runat="server">New Value</label>
                                                    </div>
                                                    <div>
                                                        <br />
                                                        <asp:TextBox ID="TextBox3" Class="form-control" Style="width: 100%;" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>


                                            <div class=" col-sm-6" style="padding-left: 0px;">
                                                <div>
                                                    <label id="Label51" class="bmd-label-floating" runat="server" style="font-weight: bold">CONSUMPTION PER DAY</label>
                                                </div>
                                                <div class="row col-sm-12">
                                                    <div class="col-sm-5" style="padding-left: 0px">
                                                        <label id="Label15" class="bmd-label-floating" runat="server">Current Value</label>
                                                    </div>
                                                    <div>
                                                        <asp:TextBox ID="TextBox6" Class="Form-control" Style="width: 100%;" ReadOnly="true" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="row col-sm-12">
                                                    <div class="col-sm-5" style="padding-left: 0px">
                                                        <br />
                                                        <label id="Label16" class="bmd-label-floating" runat="server">New Value</label>
                                                    </div>
                                                    <div>

                                                        <br />
                                                        <asp:TextBox ID="TextBox4" Style="width: 100%;" Class="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>

                                            </div>

                                        </div>


                                        <div class="col-sm-12">
                                            <asp:Button ID="ImageButton2" runat="server" Width="90px" Height="36px" Text="Send" OnClick="ImageButton2_Click" Class="btn btn-primary pull-right text" />
                                            <br />
                                            <br />
                                        </div>
                                    </div>

                                </div>

                                <%--************End Creditinfo management **************--%>


                                <%--************Start General Info management**************--%>

                                <div runat="server" id="Div1">
                                    <div>

                                        <div id="Table1" class="form-group col-sm-12" style="padding-left: 0px" runat="server">


                                            <div>
                                                <asp:GridView ID="GridView2" runat="server" HeaderStyle-BackColor="#8e24aa" HeaderStyle-ForeColor="White" CssClass="col-sm-6" AutoGenerateColumns="false">
                                                    <Columns>
                                                        <asp:BoundField DataField="ship_Name" HeaderText="Service center" />
                                                        <asp:BoundField DataField="GSTIN" HeaderText="GSTIN" />
                                                    </Columns>
                                                </asp:GridView>
                                            </div>



                                        </div>




                                        <div class="col-sm-12" style="padding-left: 0px">
                                            <label class="bmd-label-floating" style="font-weight: bold;" id="P1" runat="server">GSTIN VALUE CHANGE</label>
                                        </div>
                                        <div id="Table2" runat="server">

                                            <div class="row col-sm-12 ">
                                                <div class="col-sm-3" style="padding-left: 0px">
                                                    <label id="Label41" class="bmd-label-floating" runat="server">Select Service Center</label>
                                                </div>
                                                <div class="">
                                                    <asp:DropDownList ID="DropDownList2" AutoPostBack="true" CssClass="form-control" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" Height="33px" Width="190px">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                            <div class="col-sm-12" style="padding-left: 0px">

                                                <div class="col-s-12" style="padding-left: 0px">
                                                    <label id="Label42" runat="server" class="bmd-label-floating" style="font-weight: bold">GSTIN</label>
                                                </div>


                                            </div>
                                            <div class="col-sm-12 row ">

                                                <div class="col-sm-3 " style="padding-left: 0px">
                                                    <label id="Label63" class="bmd-label-floating" runat="server">Current Value</label>
                                                </div>
                                                <div>
                                                    <asp:TextBox ID="TextBox1" CssClass="form-control" Width="100%" ReadOnly="true" runat="server"></asp:TextBox>
                                                </div>

                                            </div>

                                            <div class="col-sm-12 row">

                                                <div class="col-sm-3" style="padding-left: 0px">
                                                    <br />
                                                    <label id="Label65" class="bmd-label-floating" runat="server">New Value</label>
                                                </div>
                                                <div>
                                                    <br />
                                                    <asp:TextBox ID="TextBox7" CssClass="form-control" Width="100%" runat="server"></asp:TextBox>

                                                </div>
                                            </div>

                                            <div class="col-sm-12">

                                                <div class="col-sm-12">
                                                    <asp:Button ID="ImageButton3" runat="server" Text="Send" Width="90px" Height="36px" OnClick="ImageButton3_Click" Class="btn btn-primary pull-right text" />

                                                </div>

                                            </div>

                                        </div>
                                    </div>
                                </div>


                                <%--************End General Info management**************--%>

                                <%--************Start Payment Value**************--%>
                                <div id="Table6" runat="server">
                                    <div class=" ">
                                        <div>


                                            <div class="row col-12">
                                                <div class="col-sm-2" style="padding-left: 0px">
                                                    <br />
                                                    <label id="Label88" runat="server" class="bmd-label-floating">Select SSC</label>
                                                </div>
                                                <div>
                                                    <br />
                                                    <asp:DropDownList ID="DropdownList5" runat="server" Height="33px" Width="220px" Class="form-control">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                            <div class="row col-12">
                                                <div class="col-sm-2" style="padding-left: 0px">
                                                    <br />
                                                    <label id="Label89" runat="server" class="bmd-label-floating">Payment Amount</label>
                                                </div>
                                                <div>
                                                    <br />
                                                    <asp:TextBox ID="txtPaymentAmount" class="Form-control" Height="33px" Width="220px" runat="server"></asp:TextBox>

                                                </div>
                                            </div>

                                            <div class="row col-12">
                                                <div class="col-sm-2" style="padding-left: 0px">
                                                    <br />
                                                    <label id="Label90" runat="server" class="bmd-label-floating">Target Date</label>
                                                </div>
                                                <div>
                                                    <br />
                                                    <asp:TextBox ID="txtTargetDate" runat="server" Height="33px" Width="220px" AutoCompleteType="Disabled" Class="form-control date"></asp:TextBox>

                                                    <%--<ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" BehaviorID="TextDateFrom_CalendarExtender" TargetControlID="txtTargetDate" PopupPosition="Left"></ajaxToolkit:CalendarExtender>--%>
                                                </div>
                                            </div>

                                            <div class="col-m-12">
                                                <asp:Button ID="ImageButton1" runat="server" Text="send" OnClick="ImageButton1_Click" Class="btn btn-primary pull-right1 text" />
                                            </div>



                                        </div>
                                        <div>
                                            <br />
                                            <br />
                                            <div id="tblPaymentGrid" runat="server" class="col-sm-12" style="padding-left: 0px">
                                                <b>
                                                    <br />
                                                    <br />
                                                    <br />

                                                    <asp:Label ID="lbltotal" Class="bmd-label-floating serverlbl" Style="font-weight: bold" runat="server"> </asp:Label>
                                                </b>

                                                <b>
                                                    <br />
                                                    <label id="lblPagesize" class="bmd-label-floating " runat="server">Page Size:</label></b><asp:TextBox ID="txtPageSize" runat="server" CssClass="serverlbl" MaxLength="4" Style="width: 40px" AutoPostBack="true" OnTextChanged="txtPageSize_TextChanged"></asp:TextBox>
                                                <asp:Label ID="lblErrorMessage" Style="color: red;" CssClass="bmd-label-floating" runat="server">Please enter a valid Page Size Range betwwwn 1 to 9999</asp:Label>
                                                <div class="table-responsive">
                                                    <asp:GridView ID="gvDisplayPaymentValue" runat="server" AutoGenerateColumns="false" AllowPaging="true" HeaderStyle-Font-Bold="true"
                                                        AllowSorting="true" OnSorting="OnSorting" OnPageIndexChanging="OnPageIndexChanging" HeaderStyle-BackColor="#8e24aa" HeaderStyle-ForeColor="White" CssClass="col-sm-6"
                                                        PageSize="10" RowStyle-Wrap="false" ShowHeaderWhenEmpty="true"
                                                        DataKeyNames="unq_no" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" OnRowUpdating="OnRowUpdating">

                                                        <Columns>
                                                            <asp:TemplateField HeaderText="unq_no" ItemStyle-Width="150" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblunq_no1" runat="server" Text='<%# Eval("unq_no") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtunq_no1" runat="server" Text='<%# Eval("unq_no") %>' Width="140"></asp:TextBox>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Created Date" ItemStyle-Width="150" SortExpression="CREATED_DATE">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblcreateddate1" runat="server" Enabled="false" Text='<%# Eval("CREATED_DATE") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtcreateddate1" runat="server" Enabled="false" Text='<%# Eval("CREATED_DATE") %>' Width="140"></asp:TextBox>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Target SSC" ItemStyle-Width="150" SortExpression="TargetSSC">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbltargetssc1" runat="server" Text='<%# Eval("TargetSSC") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <%--<asp:TextBox ID="txttargetssc1" runat="server"  Text='<%# Eval("TargetSSC") %>' Width="140"></asp:TextBox>--%>
                                                                    <asp:HiddenField ID="HiddenField1" runat="server"
                                                                        Value='<%# Eval("TargetSSC") %>' />
                                                                    <asp:DropDownList ID="drpdowntargetssc" runat="server">
                                                                    </asp:DropDownList>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>


                                                            <asp:TemplateField HeaderText="Payment Amount" ItemStyle-Width="150" SortExpression="PaymentAmount">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblpaymentamount1" runat="server" Text='<%# Eval("PaymentAmount") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtpaymentamount1" runat="server" Text='<%# Eval("PaymentAmount") %>' Width="140"></asp:TextBox>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Target Date" ItemStyle-Width="150" SortExpression="Target_Date">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbltargetdate1" runat="server" Text='<%# Eval("Target_Date") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txttargetdate1" runat="server" Text='<%# Eval("Target_Date") %>' Width="140" CssClass="date" ClientIDMode="AutoID"></asp:TextBox>
                                                                    <%--  <ajaxToolkit:CalendarExtender ID="CalendarExtendertxttargetdate1" runat="server" BehaviorID="txttargetdate1_CalendarExtender"  style="display:none" TargetControlID="txttargetdate1" Format="yyyy/MM/dd"></ajaxToolkit:CalendarExtender>
                                                                    --%>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:CommandField ButtonType="Link" ShowEditButton="true"
                                                                ItemStyle-Width="150" />
                                                        </Columns>




                                                        <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                                        <EmptyDataRowStyle HorizontalAlign="Center" />



                                                    </asp:GridView>
                                                </div>
                                                <br />
                                                <br />
                                                <br />

                                            </div>
                                        </div>


                                    </div>

                                    <div class="col-sm-12">
                                    </div>
                                </div>

                                <%--************End Payment Value**************--%>

                                <%--************start Table Collection**************--%>
                                <div id="TableCollections" runat="server" class="">

                                    <div class="">


                                        <div class="row col-sm-12">
                                            <div class="col-sm-2" style="padding-left: 0px">
                                                <br />
                                                <label id="Label13" runat="server" class="bmd-label-floating">Select SSC</label>
                                            </div>
                                            <div>
                                                <br />
                                                <asp:DropDownList ID="DropdownList6" runat="server" Height="33px" Width="220px" Class="Form-control">
                                                </asp:DropDownList>
                                            </div>
                                        </div>



                                        <div class="row col-sm-12">
                                            <div class="col-sm-2" style="padding-left: 0px">
                                                <br />
                                                <label id="Label18" runat="server" class="bmd-label-floating">Target Date</label>
                                            </div>
                                            <div>
                                                <br />
                                                <asp:TextBox ID="TextBoxTargetDate" runat="server" Height="33px" Width="220px" AutoCompleteType="Disabled" Class="Form-control date"></asp:TextBox>

                                                <%--<ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" BehaviorID="TextDateFrom_CalendarExtender" TargetControlID="TextBoxTargetDate" PopupPosition="Left"></ajaxToolkit:CalendarExtender>--%>
                                            </div>
                                        </div>



                                        <div class="row col-sm-12">
                                            <div class="col-sm-2" style="padding-left: 0px">
                                                <br />
                                                <label id="Label17" runat="server" class="bmd-label-floating">Daily Deposit</label>
                                            </div>
                                            <div>
                                                <br />
                                                <asp:TextBox ID="TextBoxDeposit" Class="Form-control" Height="33px" Width="220px" runat="server"></asp:TextBox>
                                            </div>
                                        </div>


                                        <div class="row col-sm-12">
                                            <div class="col-sm-2" style="padding-left: 0px">
                                                <br />
                                                <label id="Label19" runat="server" class="bmd-label-floating">Credit Sales</label>
                                            </div>
                                            <div>
                                                <br />
                                                <asp:TextBox ID="TextBoxCreditSales" Height="33px" Width="220px" Class="Form-control" runat="server"></asp:TextBox>
                                            </div>

                                        </div>
                                        <div class="col-sm-12 " style="padding-left: 0px">
                                            <br />
                                            <asp:Button ID="ImageButton5" runat="server" Text="Send" OnClick="ImageButton5_Click" Class="btn btn-primary pull-right text" />
                                        </div>
                                    </div>
                                </div>

                                <%--************End Table Collection**************--%>

                                <%--************Start count DRS**************--%>
                                <p style="font-weight: bold" id="P2" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; COUNT DRS</p>

                                <div runat="server" class="" id="Table3">

                                    <div class="row col-sm-12">
                                        <div class="col-sm-2" style="padding-left: 0px">
                                            <br />
                                            <label id="Label105" runat="server" class="bmd-label-floating">Target Store</label>
                                        </div>
                                        <div>
                                            <br />
                                            <asp:DropDownList ID="DropdownList3" runat="server" Height="33px" Width="220px" Class=" form-control">
                                            </asp:DropDownList>

                                        </div>


                                    </div>

                                    <div class="row col-sm-12">
                                        <div class="col-sm-2" style="padding-left: 0px">
                                            <br />
                                            <label class="bmd-label-floating">
                                                Date From
                                            </label>
                                        </div>
                                        <%-- <div >
                                 <br />
                                  <label Class="bmd-label-floating"> From
                                      </label>
                            </div>--%>
                                        <div class="col-sm-2" style="padding-left: 0px">
                                            <br />
                                            <asp:TextBox ID="TextFromDate" runat="server" Class="form-control date" AutoCompleteType="Disabled" Style="height: 33px; width: 100%"></asp:TextBox>
                                            <%--<ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" BehaviorID="TextDateFrom_CalendarExtender" TargetControlID="TextFromDate" PopupPosition="Left"></ajaxToolkit:CalendarExtender>--%>
                                        </div>
                                        <div>
                                            <br />
                                            <label class="bmd-label-floating">To </label>
                                        </div>
                                        <div class="col-sm-2" style="padding-left: 0px">
                                            <br />

                                            <asp:TextBox ID="TextToDate" runat="server" CssClass="form-control date" AutoCompleteType="Disabled" Style="width: 100%; height: 33px; margin-left: 10px"></asp:TextBox>
                                            <%--<ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" BehaviorID="TextDateTo_CalendarExtender" TargetControlID="TextToDate" PopupPosition="Right"></ajaxToolkit:CalendarExtender>--%>
                                        </div>
                                        <div class="col-sm-2" style="padding-left: 0px">
                                            <br />
                                            <label class="bmd-label-floating">Previous day: </label>



                                            <asp:CheckBox ID="CheckBox1" runat="server" Style="margin-left: 10px" AutoPostBack="true" OnCheckedChanged="CheckBox1_CheckedChanged" />
                                        </div>
                                        <div class="col-sm-2" style="padding-left: 0px">
                                            <br />
                                            <label class="bmd-label-floating">Cancellation: </label>

                                            <asp:CheckBox ID="chkCancellation" Style="margin-left: 10px" runat="server" AutoPostBack="true" />
                                        </div>
                                    </div>


                                    <div class="col-sm-12 row">

                                        <div class="col-sm-2" style="padding-left: 0px">

                                            <br />
                                            <label id="Label106" class="bmd-label-floating" runat="server">Type</label>

                                        </div>
                                        <div>
                                            <br />
                                            <asp:DropDownList ID="DropDownList4" runat="server" Height="33px" Width="220px" Class="form-control">

                                                <asp:ListItem Text="Select" Value="00"></asp:ListItem>
                                                <asp:ListItem Text="CSV" Value="01"></asp:ListItem>
                                                <asp:ListItem Text="Output" Value="02"></asp:ListItem>
                                                <asp:ListItem Text="Excel" Value="03"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="col-sm-12">
                                        <br />
                                        <asp:Button ID="ImageButton4" runat="server" Width="90px" Height="36px" OnClick="ImageButton4_Click" Text="Send" Class="btn btn-primary pull-right text" />
                                    </div>

                                    <div class="table-responsive col-sm-12" runat="server" id="Table5">

                                        <asp:GridView ID="GridView1" HeaderStyle-BackColor="#9AD6ED" HeaderStyle-ForeColor="#636363"
                                            runat="server" AutoGenerateColumns="false" OnDataBound="OnDataBound">
                                            <Columns>
                                                <asp:BoundField DataField="CustomerName" HeaderText="Name" ItemStyle-Width="150" />
                                                <asp:BoundField DataField="CustomerCountry" HeaderText="Country" ItemStyle-Width="150" />
                                                <asp:BoundField DataField="EmployeeName" HeaderText="Name" ItemStyle-Width="150" />
                                                <asp:BoundField DataField="EmployeeCountry" HeaderText="Country" ItemStyle-Width="150" />
                                            </Columns>
                                        </asp:GridView>


                                        <table class="table">
                                            <thead class=" text-primary">

                                                <tr>

                                                    <th colspan="2">
                                                        <asp:Label ID="Label44" runat="server" Text="SSC1"></asp:Label>
                                                    </th>
                                                    <th colspan="2">
                                                        <asp:Label ID="Label64" runat="server" Text="SSC2"></asp:Label>
                                                    </th>
                                                    <th colspan="2">
                                                        <asp:Label ID="Label66" runat="server" Text="SSC3"></asp:Label>
                                                    </th>
                                                    <th colspan="2">
                                                        <asp:Label ID="Label67" runat="server" Text="SSC4"></asp:Label>
                                                    </th>
                                                    <th colspan="2">
                                                        <asp:Label ID="Label68" runat="server" Text="SSC5"></asp:Label>
                                                    </th>
                                                    <th colspan="2">
                                                        <asp:Label ID="Label69" runat="server" Text="SSC6"></asp:Label>
                                                    </th>
                                                    <th colspan="2">
                                                        <asp:Label ID="Label70" runat="server" Text="SSC7"></asp:Label>
                                                    </th>
                                                    <th colspan="2">
                                                        <asp:Label ID="Label71" runat="server" Text="SSC8"></asp:Label>
                                                    </th>
                                                    <th colspan="2">
                                                        <asp:Label ID="Label92" runat="server" Text="SSC9"></asp:Label>
                                                    </th>
                                                    <th colspan="2">
                                                        <asp:Label ID="Label20" runat="server" Text="SSC10"></asp:Label>
                                                    </th>
                                                    <th colspan="2">
                                                        <asp:Label ID="Label31" runat="server" Text="SSC11"></asp:Label>
                                                    </th>

                                                </tr>

                                            </thead>
                                            <tbody>
                                                <tr>

                                                    <td>
                                                        <asp:Label ID="Label72" runat="server" Text="IW"></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="Label80" runat="server" Text="OW"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label1" runat="server" Text="IW"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label2" runat="server" Text="OW"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label4" runat="server" Text="IW"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label5" runat="server" Text="OW"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label6" runat="server" Text="IW"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label7" runat="server" Text="OW"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label8" runat="server" Text="IW"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label10" runat="server" Text="OW"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label14" runat="server" Text="IW"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label35" runat="server" Text="OW"></asp:Label>
                                                    </td>

                                                    <td>
                                                        <asp:Label ID="Label36" runat="server" Text="IW"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label37" runat="server" Text="OW"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label38" runat="server" Text="IW"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label39" runat="server" Text="OW"></asp:Label>

                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label45" runat="server" Text="IW"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label46" runat="server" Text="OW"></asp:Label>

                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label47" runat="server" Text="IW"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label48" runat="server" Text="OW"></asp:Label>

                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label49" runat="server" Text="IW"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label50" runat="server" Text="OW"></asp:Label>

                                                    </td>
                                                </tr>
                                                <tr>

                                                    <td>
                                                        <asp:Label ID="lblSSC1IW" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblSSC1OW" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblSSC2IW" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblSSC2OW" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblSSC3IW" runat="server" Text=""></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lblSSC3OW" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblSSC4IW" runat="server" Text=""></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lblSSC4OW" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblSSC5IW" runat="server" Text=""></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lblSSC5OW" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblSSC6IW" runat="server" Text=""></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lblSSC6OW" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblSSC7IW" runat="server" Text=""></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lblSSC7OW" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblSSC8IW" runat="server" Text=""></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lblSSC8OW" runat="server" Text=""></asp:Label>
                                                    </td>

                                                    <td>
                                                        <asp:Label ID="lblSSC9IW" runat="server" Text=""></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lblSSC9OW" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblSSC10IW" runat="server" Text=""></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lblSSC10OW" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblSSC11IW" runat="server" Text=""></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lblSSC11OW" runat="server" Text=""></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>

                                                    <td colspan="2">
                                                        <asp:Label ID="lblIO1" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:Label ID="lblIO2" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:Label ID="lblIO3" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:Label ID="lblIO4" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:Label ID="lblIO5" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:Label ID="lblIO6" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:Label ID="lblIO7" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:Label ID="lblIO8" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:Label ID="lblIO9" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:Label ID="lblI10" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:Label ID="lblI11" runat="server" Text=""></asp:Label>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                    <div class="table-responsive col-sm-12" runat="server" id="Table7">

                                        <table class="table">
                                            <thead class=" text-primary">
                                                <tr>


                                                    <th runat="server" id="td1">
                                                        <asp:Label ID="Label21" runat="server" Text="SSC1"></asp:Label>
                                                    </th>
                                                    <th runat="server" id="td2">
                                                        <asp:Label ID="Label22" runat="server" Text="SSC2"></asp:Label>
                                                    </th>
                                                    <th runat="server" id="td3">
                                                        <asp:Label ID="Label23" runat="server" Text="SSC3"></asp:Label>
                                                    </th>
                                                    <th runat="server" id="td4">
                                                        <asp:Label ID="Label24" runat="server" Text="SSC4"></asp:Label>
                                                    </th>
                                                    <th runat="server" id="td5">
                                                        <asp:Label ID="Label25" runat="server" Text="SSC5"></asp:Label>
                                                    </th>
                                                    <th runat="server" id="td6">
                                                        <asp:Label ID="Label26" runat="server" Text="SSC6"></asp:Label>
                                                    </th>
                                                    <th runat="server" id="td7">
                                                        <asp:Label ID="Label27" runat="server" Text="SSC7"></asp:Label>
                                                    </th>
                                                    <th runat="server" id="td8">
                                                        <asp:Label ID="Label28" runat="server" Text="SSC8"></asp:Label>
                                                    </th>
                                                    <th runat="server" id="td9">
                                                        <asp:Label ID="Label29" runat="server" Text="SSC9"></asp:Label>
                                                    </th>
                                                    <th runat="server" id="td10">
                                                        <asp:Label ID="Label30" runat="server" Text="SSC10"></asp:Label>
                                                    </th>
                                                    <th runat="server" id="td12">
                                                        <asp:Label ID="Label34" runat="server" Text="SSC11"></asp:Label>
                                                    </th>
                                                </tr>
                                                <tr>

                                                    <td>
                                                        <asp:Label ID="lblRWTSSC1" Class="bmd-label-floating" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblRWTSSC2" Class="bmd-label-floating" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblRWTSSC3" Class="bmd-label-floating" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblRWTSSC4" Class="bmd-label-floating" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblRWTSSC5" Class="bmd-label-floating" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblRWTSSC6" Class="bmd-label-floating" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblRWTSSC7" Class="bmd-label-floating" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblRWTSSC8" Class="bmd-label-floating" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblRWTSSC9" Class="bmd-label-floating" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblRWTSSC10" Class="bmd-label-floating" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblRWTSSC11" Class="bmd-label-floating" runat="server" Text=""></asp:Label>
                                                    </td>
                                                </tr>
                                        </table>
                                    </div>
                                    <br />

                                    <div runat="server" id="table9" class="table-responsive">


                                        <table>
                                            <tr>
                                                <td colspan="12"></td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td colspan="11">SAW Discount
                                                </td>
                                            </tr>
                                            <tr>

                                                <td class="auto-style369"></td>
                                                <td class="td_Credit1" style="background-color: yellow; text-align: center;" runat="server" id="td13">
                                                    <asp:Label ID="Label52" runat="server" Text="SSC1"></asp:Label>
                                                </td>
                                                <td class="td_Credit1" style="background-color: yellow; text-align: center;" runat="server" id="td14">
                                                    <asp:Label ID="Label53" runat="server" Text="SSC2"></asp:Label>
                                                </td>
                                                <td class="td_Credit1" style="background-color: yellow; text-align: center;" runat="server" id="td15">
                                                    <asp:Label ID="Label54" runat="server" Text="SSC3"></asp:Label>
                                                </td>
                                                <td class="td_Credit1" style="background-color: yellow; text-align: center;" runat="server" id="td16">
                                                    <asp:Label ID="Label55" runat="server" Text="SSC4"></asp:Label>
                                                </td>
                                                <td class="td_Credit1" style="background-color: yellow; text-align: center;" runat="server" id="td17">
                                                    <asp:Label ID="Label56" runat="server" Text="SSC5"></asp:Label>
                                                </td>
                                                <td class="td_Credit1" style="background-color: yellow; text-align: center;" runat="server" id="td18">
                                                    <asp:Label ID="Label57" runat="server" Text="SSC6"></asp:Label>
                                                </td>
                                                <td class="td_Credit1" style="background-color: yellow; text-align: center;" runat="server" id="td19">
                                                    <asp:Label ID="Label58" runat="server" Text="SSC7"></asp:Label>
                                                </td>
                                                <td class="td_Credit1" style="background-color: yellow; text-align: center;" runat="server" id="td20">
                                                    <asp:Label ID="Label59" runat="server" Text="SSC8"></asp:Label>
                                                </td>
                                                <td class="td_Credit1" style="background-color: yellow; text-align: center;" runat="server" id="td21">
                                                    <asp:Label ID="Label60" runat="server" Text="SSC9"></asp:Label>
                                                </td>
                                                <td class="td_Credit1" style="background-color: yellow; text-align: center;" runat="server" id="td22">
                                                    <asp:Label ID="Label61" runat="server" Text="SSC10"></asp:Label>
                                                </td>
                                                <td class="td_Credit1" style="background-color: yellow; text-align: center;" runat="server" id="td23">
                                                    <asp:Label ID="Label62" runat="server" Text="SSC11"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style388"></td>
                                                <td class="td_Credit1" style="background-color: lightgray; text-align: center">
                                                    <asp:Label ID="Label73" runat="server" Text="Labour"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; |&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                          <asp:Label ID="Label74" runat="server" Text="Parts"></asp:Label>
                                                </td>
                                                <td class="td_Credit1" style="background-color: lightgray; text-align: center">
                                                    <asp:Label ID="Label75" runat="server" Text="Labour"></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                          <asp:Label ID="Label76" runat="server" Text="Parts"></asp:Label>
                                                </td>
                                                <td class="td_Credit1" style="background-color: lightgray; text-align: center">
                                                    <asp:Label ID="Label77" runat="server" Text="Labour"></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;
                          <asp:Label ID="Label78" runat="server" Text="Parts"></asp:Label>
                                                </td>
                                                <td class="td_Credit1" style="background-color: lightgray; text-align: center">
                                                    <asp:Label ID="Label79" runat="server" Text="Labour"></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;
                          <asp:Label ID="Label81" runat="server" Text="Parts"></asp:Label>
                                                </td>
                                                <td class="td_Credit1" style="background-color: lightgray; text-align: center">
                                                    <asp:Label ID="Label82" runat="server" Text="Labour"></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;&nbsp; |&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label83" runat="server" Text="OW"></asp:Label>
                                                </td>
                                                <td class="td_Credit1" style="background-color: lightgray; text-align: center">
                                                    <asp:Label ID="Label84" runat="server" Text="Labour"></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;&nbsp; |&nbsp;&nbsp;&nbsp;&nbsp;
                          <asp:Label ID="Label85" runat="server" Text="Parts"></asp:Label>
                                                </td>
                                                <td class="td_Credit1" style="background-color: lightgray; text-align: center">
                                                    <asp:Label ID="Label95" runat="server" Text="Labour"></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;
                          <asp:Label ID="Label96" runat="server" Text="Parts"></asp:Label>
                                                </td>
                                                <td class="td_Credit1" style="background-color: lightgray; text-align: center">
                                                    <asp:Label ID="Label97" runat="server" Text="Labour"></asp:Label>
                                                    &nbsp; &nbsp;&nbsp; |&nbsp;&nbsp;&nbsp;
                          <asp:Label ID="Label98" runat="server" Text="Parts"></asp:Label>
                                                </td>
                                                <td class="td_Credit1" style="background-color: lightgray; text-align: center">
                                                    <asp:Label ID="Label99" runat="server" Text="Labour"></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;&nbsp; |&nbsp;&nbsp;&nbsp;
                          <asp:Label ID="Label100" runat="server" Text="Parts"></asp:Label>
                                                </td>
                                                <td class="td_Credit1" style="background-color: lightgray; text-align: center">
                                                    <asp:Label ID="Label101" runat="server" Text="Labour"></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;&nbsp; |&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                          <asp:Label ID="Label102" runat="server" Text="Parts"></asp:Label>
                                                </td>
                                                <td class="td_Credit1" style="background-color: lightgray; text-align: center">
                                                    <asp:Label ID="Label103" runat="server" Text="Labour"></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;&nbsp; |&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                          <asp:Label ID="Label107" runat="server" Text="Parts"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style369"></td>
                                                <td class="td_Credit1" style="text-align: center">
                                                    <asp:Label ID="lblSDSSC1L" runat="server" Text=""></asp:Label>
                                                    |&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                             <asp:Label ID="lblSDSSC1P" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td class="td_Credit1" style="text-align: center">
                                                    <asp:Label ID="lblSDSSC2L" runat="server" Text=""></asp:Label>
                                                    |&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                             <asp:Label ID="lblSDSSC2P" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td class="td_Credit1" style="text-align: center">
                                                    <asp:Label ID="lblSDSSC3L" runat="server" Text=""></asp:Label>|
                             <asp:Label ID="lblSDSSC3P" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td class="td_Credit1" style="text-align: center">
                                                    <asp:Label ID="lblSDSSC4L" runat="server" Text=""></asp:Label>|
                             <asp:Label ID="lblSDSSC4P" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td class="td_Credit1" style="text-align: center">
                                                    <asp:Label ID="lblSDSSC5L" runat="server" Text=""></asp:Label>|
                             <asp:Label ID="lblSDSSC5P" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td class="td_Credit1" style="text-align: center">
                                                    <asp:Label ID="lblSDSSC6L" runat="server" Text=""></asp:Label>|
                             <asp:Label ID="lblSDSSC6P" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td class="td_Credit1" style="text-align: center">
                                                    <asp:Label ID="lblSDSSC7L" runat="server" Text=""></asp:Label>|
                             <asp:Label ID="lblSDSSC7P" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td class="td_Credit1" style="text-align: center">
                                                    <asp:Label ID="lblSDSSC8L" runat="server" Text=""></asp:Label>|
                             <asp:Label ID="lblSDSSC8P" runat="server" Text=""></asp:Label>
                                                </td>

                                                <td class="td_Credit1" style="text-align: center">
                                                    <asp:Label ID="lblSDSSC9L" runat="server" Text=""></asp:Label>|
                             <asp:Label ID="lblSDSSC9P" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td class="td_Credit1" style="text-align: center">
                                                    <asp:Label ID="lblSDSSC10L" runat="server" Text=""></asp:Label>|
                             <asp:Label ID="lblSDSSC10P" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td class="td_Credit1" style="text-align: center">
                                                    <asp:Label ID="lblSDSSC11L" runat="server" Text=""></asp:Label>|
                             <asp:Label ID="lblSDSSC11P" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style370">&nbsp;</td>
                                                <td class="auto-style389" style="text-align: center;">
                                                    <asp:Label ID="lblSDSSC1T" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td class="auto-style492" style="text-align: center;">
                                                    <asp:Label ID="lblSDSSC2T" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td class="auto-style392" style="text-align: center;">
                                                    <asp:Label ID="lblSDSSC3T" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td class="auto-style397" style="text-align: center;">
                                                    <asp:Label ID="lblSDSSC4T" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td class="auto-style401" style="text-align: center;">
                                                    <asp:Label ID="lblSDSSC5T" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td class="auto-style370" style="text-align: center;">
                                                    <asp:Label ID="lblSDSSC6T" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td class="auto-style370" style="text-align: center;">
                                                    <asp:Label ID="lblSDSSC7T" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td class="auto-style370" style="text-align: center;">
                                                    <asp:Label ID="lblSDSSC8T" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td class="auto-style370" style="text-align: center;">
                                                    <asp:Label ID="lblSDSSC9T" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td class="auto-style370" style="text-align: center;">
                                                    <asp:Label ID="lblSDSSC10T" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td class="auto-style370" style="text-align: center;">
                                                    <asp:Label ID="lblSDSSC11T" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div id="tblSingle" runat="server" class="row col-sm-12">

                                        <div class="">
                                            <table class="table table-size" style="text-align: center">
                                                <thead class=" text-primary">
                                                    <tr>

                                                        <th colspan="2" style="text-align: center">
                                                            <asp:Label runat="server" ID="lblBranchname"></asp:Label>
                                                        </th>
                                                    </tr>

                                                    <tr>
                                                        <td style="width: 200px">
                                                            <label class="bmd-label-floating">IW</label>
                                                        </td>
                                                        <td style="width: 200px">
                                                            <label class="bmd-label-floating">OW</label></td>



                                                    </tr>
                                                    <tr>

                                                        <td>
                                                            <asp:Label ID="lblSSCSIW" Class="bmd-label-floating" runat="server" Text=""></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblSSCSOW" Class="bmd-label-floating" runat="server"></asp:Label>
                                                        </td>


                                                    </tr>
                                                    <tr>

                                                        <td style="width: 200px">
                                                            <label>TotalCounts </label>
                                                        </td>
                                                        <td style="width: 200px">
                                                            <asp:Label runat="server" Class="bmd-label-floating" ID="lblTotalSingle"></asp:Label>
                                                        </td>

                                                    </tr>
                                            </table>

                                        </div>
                                    </div>
                                    <br />
                                    <div id="tblSingleRWT" runat="server" class="row col-sm-12">


                                        <div class="">
                                            <table class="table table-size">
                                                <thead class=" text-primary">
                                                    <tr>

                                                        <th style="text-align: center;">
                                                            <asp:Label runat="server" CssClass="" Text="" ID="lblSSCName"></asp:Label>
                                                        </th>
                                                    </tr>

                                                </thead>
                                                <tbody>
                                                    <tr>

                                                        <td style="text-align: center;">
                                                            <asp:Label CssClass="bmd-label-floating" runat="server" ID="lblSSCNameRWT"></asp:Label>
                                                            &nbsp;</td>

                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                    <table id="tblSingleSDT" runat="server" class="auto-style423">

                                        <tr>
                                            <td class="auto-style484"></td>
                                            <td class="auto-style483" style="background-color: yellow; text-align: center; border: groove; font-weight: 600">
                                                <asp:Label runat="server" ID="lblSDSSCName"></asp:Label>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="auto-style477" style="text-align: center; border: 5px; font-weight: 600;"></td>
                                            <td class="auto-style485" style="border: groove;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Labour&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; |&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Parts</td>
                                            <td class="auto-style465"></td>
                                            <td class="auto-style465"></td>
                                            <td class="auto-style462"></td>
                                            <td class="auto-style465"></td>
                                            <td class="auto-style464">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>


                                            <td class="auto-style465"></td>


                                        </tr>
                                        <tr>
                                            <td class="auto-style478">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </td>
                                            <td class="auto-style456" style="text-align: center; border: groove;">
                                                <asp:Label ID="lblSDSSCLabour" runat="server" Text="" Style="text-align: center"></asp:Label>
                                                &nbsp;&nbsp;&nbsp;&nbsp; &nbsp; |&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                            <asp:Label ID="lblSDSSCPart" runat="server" Text=""></asp:Label>
                                                &nbsp;</td>
                                            <td class="auto-style459"></td>
                                            <td class="auto-style458">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                                     
                                            </td>


                                        </tr>
                                        <tr>
                                            <td class="auto-style481">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                                            </td>
                                            <td class="auto-style407" style="text-align: center; border: groove;">&nbsp;&nbsp;&nbsp;TotalAmount :<asp:Label runat="server" ID="lblSDSSCLabourPartTotal"></asp:Label>
                                                &nbsp;</td>
                                            <td class="auto-style314"></td>
                                            <td class="auto-style408">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                            </td>
                                            <td class="auto-style411"></td>
                                        </tr>
                                    </table>
                                </div>

                                <%--************End count DRS**************--%>

                                <div id="Monthytarget" runat="server" class="col-sm-12">

                                    <div class="row">
                                        <div class="col-sm-2" style="padding-left: 0px">
                                            <br />
                                            <label id="Label108" runat="server" cssclass="bmd-label-floating" text="">Select SSC</label>

                                        </div>

                                        <div>
                                            <br />
                                            <asp:DropDownList ID="DropdownList7" runat="server" Style="margin-left: -4px" CssClass="form-control" Height="33px" Width="220px">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <br />

                                    <div class="row">
                                        <div class="col-sm-2" style="padding-left: 0px">
                                            <label id="Label109" runat="server" cssclass="bmd-label-floating">Month</label>


                                        </div>
                                        <div>
                                            <asp:DropDownList ID="DropDownMonth2" Style="margin-left: -4px" runat="server" CssClass="form-control" Height="33px" Width="220px">
                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="January" Value="01"></asp:ListItem>
                                                <asp:ListItem Text="February" Value="02"></asp:ListItem>
                                                <asp:ListItem Text="March" Value="03"></asp:ListItem>
                                                <asp:ListItem Text="April" Value="04"></asp:ListItem>
                                                <asp:ListItem Text="May" Value="05"></asp:ListItem>
                                                <asp:ListItem Text="June" Value="06"></asp:ListItem>
                                                <asp:ListItem Text="July" Value="07"></asp:ListItem>
                                                <asp:ListItem Text="August" Value="08"></asp:ListItem>
                                                <asp:ListItem Text="September" Value="09"></asp:ListItem>
                                                <asp:ListItem Text="October" Value="10"></asp:ListItem>
                                                <asp:ListItem Text="November" Value="11"></asp:ListItem>
                                                <asp:ListItem Text="December" Value="12"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <br />

                                    <div class="row">
                                        <div class="col-sm-2" style="padding-left: 0px">
                                            <label id="Label110" runat="server" cssclass="bmd-label-floating">Year</label>
                                        </div>
                                        <div>
                                            <asp:DropDownList ID="DropDownYear2" runat="server" Style="margin-left: -4px" CssClass="form-control" Height="33px" Width="220px">
                                                <asp:ListItem Text="Select" Value="0" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                                                <asp:ListItem Text="2020" Value="2020"></asp:ListItem>
                                                <asp:ListItem Text="2021" Value="2021"></asp:ListItem>
                                                <asp:ListItem Text="2022" Value="2022"></asp:ListItem>
                                                <asp:ListItem Text="2023" Value="2023"></asp:ListItem>
                                                <asp:ListItem Text="2024" Value="2024"></asp:ListItem>
                                                <asp:ListItem Text="2025" Value="2025"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-sm-2" style="padding-left: 0px">
                                            <label id="Label111" runat="server" cssclass="bmd-label-floating">Target Amount</label>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="targetamtbox" CssClass="form-file-upload" Style="margin-left: -4px;" Font-Size="Medium" Height="33px" Width="220px" runat="server"></asp:TextBox></div>
                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
         ControlToValidate  ="targetamtbox"
      ErrorMessage ="Only numeric allowed." ForeColor="Red"
     ValidationExpression="^[0-9]*$" ValidationGroup="NumericValidate">*
                                          </asp:RegularExpressionValidator>--%>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Style="margin-left: 3px;" CssClass="serverlbl " ControlToValidate="targetamtbox" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-sm-2" style="padding-left: 0px">
                                            <label id="Label93" runat="server" cssclass="bmd-label-floating">Target Call Load</label>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="targetcallload" CssClass="form-file-upload" Style="margin-left: -4px;" Font-Size="Medium" Height="33px" Width="220px" runat="server"></asp:TextBox></div>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Style="margin-left: 3px;" Height="33px" CssClass="serverlbl " ControlToValidate="targetcallload" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                    </div>

                                    <div class="col-sm-11">
                                        <%--<asp:Button ID="ImageButton6" runat="server"  Text="Send"  Width="81px" CssClass="btn btn-primary pull-right text" />--%>
                                        <asp:Button ID="ImageButton6" runat="server" OnClick="ImageButton6_Click" Text="Send" Width="81px" CssClass="btn btn-primary pull-right text" />
                                        <%-- Added for Weekly Revenue Report --%>
                                    </div>
                                    <div class="col-sm-14">
                                        <!-- Added for Monthly Target Screen !-->
                                        <asp:Button ID="Search" runat="server" OnClick="Search_Click" Text="Search" Width="81px" CssClass="btn btn-primary pull-right text" />
                                    </div>
                                    <br />
                                    <br />
                                    <br />


                                    <div style="padding-left: 0px;">
                                        <div class="col-md-14" id="indata" runat="server">
                                            <asp:Label ID="lblPagesize1" CssClass="serverlbl " runat="server">Page Size:</asp:Label><b></b><asp:TextBox ID="txtPageSize1" Font-Size="Medium" runat="server" MaxLength="4" class="form-file-upload" Style="width: 40px" AutoPostBack="true" OnTextChanged="txtPageSize1_TextChanged"></asp:TextBox>
                                            <asp:Label ID="lblErrorMessage1" CssClass="serverlbl" Style="color: red;" runat="server">Please enter a valid Page Size Range betwwwn 1 to 9999</asp:Label>
                                            <div class="table-responsive">
                                            <asp:GridView ID="gvMonthlytarget" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                                                AllowSorting="true" OnSorting="gvMonthlytarget_Sorting" OnPageIndexChanging="gvMonthlytarget_PageIndexChanging"
                                                PageSize="10" RowStyle-Wrap="false" ShowHeaderWhenEmpty="true" HeaderStyle-Wrap="false" HeaderStyle-BackColor="#8e24aa" HeaderStyle-ForeColor="White"
                                                DataKeyNames="unq_no" OnRowEditing="gvMonthlytarget_RowEditing" OnRowCancelingEdit="gvMonthlytarget_RowCancelingEdit" OnRowUpdating="gvMonthlytarget_RowUpdating" CssClass="auto-style494" Width="768px" Height="10px" Style="margin-top: 0px">
                                                <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                                <EmptyDataRowStyle HorizontalAlign="Center" />
                                                <Columns>

                                                    <asp:TemplateField HeaderText="unq_no" ItemStyle-Width="150" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblunq_no1" runat="server" Value='<%# Eval("unq_no") %>' Text='<%# Eval("unq_no") %>'></asp:Label>
                                                        </ItemTemplate>

                                                        <EditItemTemplate>
                                                            <%--<asp:HiddenField ID="HiddenField4" runat="server"  Value='<%# Eval("unq_no") %>' />--%>
                                                            <asp:TextBox ID="txtunq_no1" runat="server" Text='<%# Eval("unq_no") %>' Width="140"></asp:TextBox>
                                                        </EditItemTemplate>

                                                    </asp:TemplateField>



                                                    <asp:TemplateField HeaderText="Created Date" ItemStyle-Width="150" SortExpression="CREATED_DATE">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblcreateddate1" runat="server" Enabled="false" Text='<%# Eval("CREATED_DATE") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtcreateddate1" runat="server" Enabled="false" Text='<%# Eval("CREATED_DATE") %>' Width="140"></asp:TextBox>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>


                                                    <asp:TemplateField HeaderText="Target SSC" ItemStyle-Width="150" SortExpression="TargetSSC">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbltargetssc1" runat="server" Text='<%# Eval("TargetSSC") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>

                                                            <asp:HiddenField ID="HiddenField1" runat="server"
                                                                Value='<%# Eval("TargetSSC") %>' />
                                                            <asp:DropDownList ID="drpdowntargetssc" runat="server">
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>


                                                    <asp:TemplateField HeaderText="Target Month" ItemStyle-Width="150" SortExpression="TARGET_MONTH">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTargetMonth" runat="server" Text='<%# Eval("TARGET_MONTH") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:HiddenField ID="HiddenField2" runat="server"
                                                                Value='<%# Eval("TARGET_MONTH") %>' />
                                                            <asp:DropDownList ID="DropDownMonth3" runat="server" CssClass="auto-style186">
                                                                <asp:ListItem Text="Select..." Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="January" Value="01"></asp:ListItem>
                                                                <asp:ListItem Text="February" Value="02"></asp:ListItem>
                                                                <asp:ListItem Text="March" Value="03"></asp:ListItem>
                                                                <asp:ListItem Text="April" Value="04"></asp:ListItem>
                                                                <asp:ListItem Text="May" Value="05"></asp:ListItem>
                                                                <asp:ListItem Text="June" Value="06"></asp:ListItem>
                                                                <asp:ListItem Text="July" Value="07"></asp:ListItem>
                                                                <asp:ListItem Text="August" Value="08"></asp:ListItem>
                                                                <asp:ListItem Text="September" Value="09"></asp:ListItem>
                                                                <asp:ListItem Text="October" Value="10"></asp:ListItem>
                                                                <asp:ListItem Text="November" Value="11"></asp:ListItem>
                                                                <asp:ListItem Text="December" Value="12"></asp:ListItem>
                                                            </asp:DropDownList>

                                                        </EditItemTemplate>
                                                    </asp:TemplateField>


                                                    <asp:TemplateField HeaderText="Target Year" ItemStyle-Width="150" SortExpression="TARGET_YEAR">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTargetYear" runat="server" Text='<%# Eval("TARGET_YEAR") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:HiddenField ID="HiddenField3" runat="server"
                                                                Value='<%# Eval("TARGET_YEAR") %>' />
                                                            <asp:DropDownList ID="DropDownYear3" runat="server" CssClass="auto-style186" Height="24px" Width="60px">

                                                                <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                                                                <asp:ListItem Text="2020" Value="2020"></asp:ListItem>
                                                                <asp:ListItem Text="2021" Value="2021"></asp:ListItem>
                                                                <asp:ListItem Text="2022" Value="2022"></asp:ListItem>
                                                                <asp:ListItem Text="2023" Value="2023"></asp:ListItem>
                                                                <asp:ListItem Text="2024" Value="2024"></asp:ListItem>
                                                                <asp:ListItem Text="2025" Value="2025"></asp:ListItem>
                                                            </asp:DropDownList>

                                                        </EditItemTemplate>
                                                    </asp:TemplateField>


                                                    <asp:TemplateField HeaderText="Target Month Amount" ItemStyle-Width="150" SortExpression="TARGET_MONTH_AMOUNT">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTargetMonthAmount" runat="server" Text='<%# Eval("TARGET_MONTH_AMOUNT") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtTargetMonthAmount" runat="server" Text='<%# Eval("TARGET_MONTH_AMOUNT") %>' Width="140"></asp:TextBox>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>


                                                    <asp:TemplateField HeaderText="Target CallLoad Count" ItemStyle-Width="150" SortExpression="TARGET_CALLLOAD_COUNT">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTargetCallloadCount" runat="server" Text='<%# Eval("TARGET_CALLLOAD_COUNT") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtTargetCallloadCount" runat="server" Text='<%# Eval("TARGET_CALLLOAD_COUNT") %>' Width="140"></asp:TextBox>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>








                                                    <asp:CommandField ButtonType="Link" ShowEditButton="true"
                                                        ItemStyle-Width="150" />
                                                </Columns>




                                                <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                                <EmptyDataRowStyle HorizontalAlign="Center" />
                                                <AlternatingRowStyle />
                                                <HeaderStyle Font-Bold="True" />
                                                <RowStyle />
                                            </asp:GridView>
                                           </div>
                                        </div>
                                        <div class="" id="nodata" runat="server">
                                            <label class="bmd-label-floating">No records found</label>
                                        </div>
                                    </div>

                                </div>



                                <div id="WeeklyRevenue" runat="server" class="col-sm-12" visible="false">
                                    <div class="row">
                                        <div class="col-sm-2" style="padding-left: 0px">

                                            <br />
                                            <label id="Label113" runat="server" cssclass="bmd-label-floating">Month</label>
                                        </div>
                                        <div>

                                            <br />
                                            <asp:DropDownList ID="DropDownList9" runat="server" class="form-control" Style="margin-left: -4px;" Height="33px" Width="220px">
                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="January" Value="01"></asp:ListItem>
                                                <asp:ListItem Text="February" Value="02"></asp:ListItem>
                                                <asp:ListItem Text="March" Value="03"></asp:ListItem>
                                                <asp:ListItem Text="April" Value="04"></asp:ListItem>
                                                <asp:ListItem Text="May" Value="05"></asp:ListItem>
                                                <asp:ListItem Text="June" Value="06"></asp:ListItem>
                                                <asp:ListItem Text="July" Value="07"></asp:ListItem>
                                                <asp:ListItem Text="August" Value="08"></asp:ListItem>
                                                <asp:ListItem Text="September" Value="09"></asp:ListItem>
                                                <asp:ListItem Text="October" Value="10"></asp:ListItem>
                                                <asp:ListItem Text="November" Value="11"></asp:ListItem>
                                                <asp:ListItem Text="December" Value="12"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-sm-2" style="padding-left: 0px">
                                            <label id="Label114" runat="server" cssclass="bmd-label-floating">Year</label>

                                        </div>
                                        <div>
                                            <asp:DropDownList ID="DropDownList10" runat="server" Style="margin-left: -4px;" Height="33px" Width="220px" CssClass="form-control serverlbl">
                                                <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                                                <asp:ListItem Text="2020" Value="2020"></asp:ListItem>
                                                <asp:ListItem Text="2021" Selected="True" Value="2021"></asp:ListItem>
                                                <asp:ListItem Text="2022" Value="2022"></asp:ListItem>
                                                <asp:ListItem Text="2023" Value="2023"></asp:ListItem>
                                                <asp:ListItem Text="2024" Value="2024"></asp:ListItem>
                                                <asp:ListItem Text="2025" Value="2025"></asp:ListItem>
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                    <div>
                                        <asp:Button ID="ImageButton7" Text="send" runat="server" Width="90px" Height="36px" CssClass="btn btn-primary pull-right text" />
                                    </div>


                                </div>

                                <%--************Start Call Load**************--%>


                                <div id="CallLoad" runat="server" class="col-sm-12" visible="false">
                                    <div class="row">
                                        <div class="col-sm-2" style="padding-left: 0px">

                                            <br />
                                            <label id="Label86" runat="server" cssclass="bmd-label-floating">Month</label>
                                        </div>
                                        <div>

                                            <br />
                                            <asp:DropDownList ID="DropDownList8" runat="server" class="form-control" Style="margin-left: -4px;" Height="33px" Width="220px">
                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="January" Value="01"></asp:ListItem>
                                                <asp:ListItem Text="February" Value="02"></asp:ListItem>
                                                <asp:ListItem Text="March" Value="03"></asp:ListItem>
                                                <asp:ListItem Text="April" Value="04"></asp:ListItem>
                                                <asp:ListItem Text="May" Value="05"></asp:ListItem>
                                                <asp:ListItem Text="June" Value="06"></asp:ListItem>
                                                <asp:ListItem Text="July" Value="07"></asp:ListItem>
                                                <asp:ListItem Text="August" Value="08"></asp:ListItem>
                                                <asp:ListItem Text="September" Value="09"></asp:ListItem>
                                                <asp:ListItem Text="October" Value="10"></asp:ListItem>
                                                <asp:ListItem Text="November" Value="11"></asp:ListItem>
                                                <asp:ListItem Text="December" Value="12"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-sm-2" style="padding-left: 0px">
                                            <label id="Label87" runat="server" cssclass="bmd-label-floating">Year</label>

                                        </div>
                                        <div>
                                            <asp:DropDownList ID="DropDownList11" runat="server" Style="margin-left: -4px;" Height="33px" Width="220px" CssClass="form-control serverlbl">
                                                <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                                                <asp:ListItem Text="2020" Value="2020"></asp:ListItem>
                                                <asp:ListItem Text="2021" Selected="True" Value="2021"></asp:ListItem>
                                                <asp:ListItem Text="2022" Value="2022"></asp:ListItem>
                                                <asp:ListItem Text="2023" Value="2023"></asp:ListItem>
                                                <asp:ListItem Text="2024" Value="2024"></asp:ListItem>
                                                <asp:ListItem Text="2025" Value="2025"></asp:ListItem>
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                    <div>
                                        <asp:Button ID="ImageButton8" Text="send" runat="server" Width="90px" Height="36px" CssClass="btn btn-primary pull-right text" />
                                    </div>


                                </div>





                                <%--************End Call Load**************--%>






                                <%--Enddiv--%>
                            </div>
                        </div>

                        <div>
                        </div>
                    </div>

                </div>



                <div>
                </div>

            </div>
        </div>


    </div>

    <div>
    </div>








    <asp:Button ID="BtnCancel" runat="server" Text="Button" Style="display: none;" />
    <asp:Button ID="BtnOK" runat="server" Text="Button" Style="display: none;" />
    <asp:Button ID="Btn2OK" runat="server" Text="Button" Style="display: none;" />
    <%-- Added for Weekly Revenue Report --%>
    <asp:Button ID="Btn3OK" runat="server" Text="Button" Style="display: none;" />
    <%-- Added for Call Load Report --%>




    <table id="Getdta" runat="server" autopostback="true">
        <tr>
            <td></td>
        </tr>
    </table>


    <div style="visibility: hidden" class="col-sm-12">

        <div class="form-group row">
            <div class="col-sm-2">
                <label class="bmd-label-floating">Current Location</label>
            </div>
            <div>
                <label>:</label>
                <asp:Label ID="lblLoc" class="bmd-label-floating  serverlbl" runat="server"></asp:Label>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-2">
                <label class="bmd-label-floating">Current Username</label>
            </div>
            <div>
                <label>:</label>
                <asp:Label class="bmd-label-floating serverlbl" ID="lblName" runat="server"> </asp:Label>
            </div>
        </div>

    </div>


    <div style="margin-top: 500px;">

        <div id="dialog" title="Stored Management" style="display: none;">

            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
