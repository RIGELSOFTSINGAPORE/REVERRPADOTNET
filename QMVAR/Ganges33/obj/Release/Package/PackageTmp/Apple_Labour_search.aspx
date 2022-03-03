<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/AppleAnalysis.Master" CodeBehind="Apple_Labour_search.aspx.vb" Inherits="Ganges33.Apple_Labour_search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     
    <%--<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.0/jquery.min.js"></script>
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
  <%--<link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700|Roboto+Slab:400,700|Material+Icons" />
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/latest/css/font-awesome.min.css">--%>
  <!-- CSS Files -->
   <link href="assets/css/material-dashboard.css" rel="stylesheet" /> 
  <!-- CSS Just for demo purpose, don't include it in your project -->
  <link href="assets/demo/demo.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    

  
   <div class="wrapper  col-sm-12 sidebar-wrapper position-fixed scrolbar contain" id="style-10">
   
    <div class="content" >
        <div class="container-fluid">
          <div class="row">
            <div class="col-md-12">
              <div class="card">
                <div class="card-header card-header-primary">
                  <h3 class="card-title ">Labour Search</h3>
                  <p class="card-category"></p>
                </div>
                <div class="card-body " >
              
                
                     <div class="row ">
           <div class="col-sm-2">
               <label>
                   Labour type
               </label>
      </div>
      <div>
              <%--<asp:TextBox ID="labourtype" CssClass="form-file-upload serverlbl"  runat="server"></asp:TextBox>--%>
               <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="true" Font-Size="large">
        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
        <asp:ListItem Text="Mac" Value="Mac"></asp:ListItem>
        <asp:ListItem Text="iPad" Value="iPad"></asp:ListItem>
        <asp:ListItem Text="iPhone" Value="iPhone"></asp:ListItem>
        <%--<asp:ListItem Text="20" Value="20"></asp:ListItem>--%>
        </asp:DropDownList>     
      </div>
      </div>
     <br />
                     <div class="row ">
           <div class="col-sm-2">
<label>
    Labour code
</label>
      </div>
      <div>
           <asp:TextBox ID="Labourcode" CssClass="form-file-upload serverlbl"  runat="server"></asp:TextBox>
               <div class="col-sm-12">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn btn-primary pull-right" />
                  
                    &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnNew" runat="server" Text="Add New Part" class="btn btn-primary pull-right" />
                    </div>     
      </div>
      </div>

                    <br />
                    <br />

                  
                     <asp:Label ID="Label1" runat="server" Text="Page Count" Font-Bold="True"
            ForeColor="#CC3300" Font-Size="Large"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" Font-Size="Small">
        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
        <asp:ListItem Text="5" Value="5"></asp:ListItem>
        <asp:ListItem Text="10" Value="10"></asp:ListItem>
        <asp:ListItem Text="15" Value="15"></asp:ListItem>
        <asp:ListItem Text="20" Value="20"></asp:ListItem>
        </asp:DropDownList>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <br />
           

                      <asp:GridView ID="gvCashTrack" runat="server" Width="99%" AllowPaging="true"
                PageSize="10" AutoGenerateColumns="False" EmptyDataText="No records Found" 
               Style="align-self: center" CssClass="col-sm-12"  OnPageIndexChanging="grvCashTracking_PageIndexChanging"  EnableViewState="true" >
                <Columns>
                     
                      
                         <asp:TemplateField HeaderText="Labour Code">
                        <ItemTemplate>

                             <asp:Label ID="lblGoodsDelivered" Text='<%# Eval("labour_code")  %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="labour Description">
                        <ItemTemplate >
                             <asp:Label ID="lblEngineer"  Text='<%# Eval("LABOUR_DESCRIPTION") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" Width="50%" />
                    </asp:TemplateField>
                     <asp:HyperLinkField  Text="Edit"  DataTextField="" DataNavigateUrlFields="UNQ_NO" DataNavigateUrlFormatString="~/Apple_Labour_Create.aspx?UNQ_NO={0}"
            HeaderText="" ItemStyle-Width = "20" />
                     <%--<asp:TemplateField HeaderText="Serial">
                         
                        <ItemTemplate>
                             <asp:Label ID="lblCollectAmt"  Text='<% # Eval("SERIAL_NO")  %>'  runat="server"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" Width="10%" />
                    </asp:TemplateField>
                           <asp:TemplateField HeaderText="Product">
                        <ItemTemplate>
                             <asp:Label ID="lblCollectAmt"  Text='<%# Eval("PRODUCT_NAME")  %>'  runat="server"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Width="30%" />
                    </asp:TemplateField>--%>

                  
                    
                </Columns>
               <PagerSettings FirstPageText="" LastPageText="" NextPageText="" 
            PreviousPageText="" Position="Top" >
          </PagerSettings>
                <HeaderStyle BackColor="#8e24aa" Font-Bold="True" ForeColor="white" />
                <PagerStyle HorizontalAlign="Left" />
            </asp:GridView>
              </ContentTemplate>

    </asp:UpdatePanel><br />
                      &nbsp;  &nbsp;  &nbsp;  &nbsp;&nbsp;  &nbsp;  &nbsp;  &nbsp;
                       &nbsp;  &nbsp;  &nbsp;  &nbsp;&nbsp;  &nbsp;  &nbsp;  &nbsp;
                       &nbsp;  &nbsp;  &nbsp;  &nbsp;&nbsp;  &nbsp;  &nbsp;  &nbsp;
                       &nbsp;  &nbsp;  &nbsp;  &nbsp;&nbsp;  &nbsp;  &nbsp;  &nbsp;
                      &nbsp;  &nbsp;  &nbsp;  &nbsp;&nbsp;  &nbsp;  &nbsp;  &nbsp;
                      &nbsp;  &nbsp;  &nbsp;  &nbsp;&nbsp;  
                      
                     
                      <asp:Label ID="lblTotalCount"  runat="server"></asp:Label> 
                      &nbsp;  &nbsp;  &nbsp;  &nbsp;
                      <asp:Label ID="lblInvoiceAmt" runat="server"></asp:Label>
      <%-- <table class="auto-style1">
                <tr>
                    <td class="auto-style2">From</td>
                    <td class="auto-style3">
                       &nbsp; To&nbsp;&nbsp;
                         </td>
                </tr>
                <tr>
                    <td class="auto-style2">Status</td>
                    <td class="auto-style3">
                       
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Customer Name</td>
                    <td class="auto-style3">
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Phone No</td>
                    <td class="auto-style3">
                         </td>
                </tr>
                <tr>
                    <td class="auto-style2">Serial No</td>
                    <td class="auto-style3">
                         </td>
                </tr>
                <tr>
                    <td class="auto-style2">Product</td>
                    <td class="auto-style3">
                        </td>
                </tr>
                <tr>
                    <td class="auto-style2">Parts No</td>
                    <td class="auto-style3">
                         </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">
                          </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
            </table>--%>

</div>

          
                 
                     
                
                                        
                 
                </div>
              </div>
               </div>
            
     </div>
            
    </div>
        </div>
    
    
    
</asp:Content>
