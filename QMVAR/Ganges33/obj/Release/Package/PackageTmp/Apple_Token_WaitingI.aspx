<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/AppleToken.Master" CodeBehind="Apple_Token_WaitingI.aspx.vb" Inherits="Ganges33.Apple_Token_WaitingI" %>
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
  <%--<link rel="icon" type="image/png" href="../assets/img/favicon.png">--%>
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
                  <h3 class="card-title ">Waiting List</h3>
                  <p class="card-category"></p>
                </div>
                <div class="card-body " >
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">


        <ContentTemplate>
            <br />
           
              <div class="row ">
           <div class="col-sm-2">
               <label>
                   <table><tr>
                       <td  style="font-size:40px">Wait&nbsp;Count:&nbsp;&nbsp;&nbsp;</td>
                       <td>
                           <asp:Label ID="lblCount" CssClass="form-file-upload serverlbl" style="font-size:100px" runat="server"></asp:Label>
                       </td>

                          </tr></table>
                    
               </label>
      </div>
      <div>
              
                    
      </div>
      </div>
                  <asp:GridView ID="gvPart" runat="server" Width="99%" AllowPaging="true" OnRowCommand="gvPart_RowCommand"
                PageSize="10" AutoGenerateColumns="False" EmptyDataText="No Token Waiting..." 
               Style="align-self: center" CssClass="col-sm-12"  OnPageIndexChanging="gvPart_PageIndexChanging"  EnableViewState="true" >
                <Columns>

                    <asp:TemplateField HeaderText="SNo" HeaderStyle-Width="10px">
        <ItemTemplate>
             <%#Container.DataItemIndex+1 %>
        </ItemTemplate>
                        
    </asp:TemplateField>

                      <asp:TemplateField HeaderText="DateTime">
                        <ItemTemplate >
                             <asp:Label ID="lblCRTDT"  Text='<%# Eval("CRTDT") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" Width="25%" />
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Token&nbsp;/&nbsp;PO&nbsp;No">
                        <ItemTemplate>
                            <asp:Label ID="lblUNQ_NO" Text='<%# Eval("UNQ_NO")  %>' runat="server" Visible="false"></asp:Label>
                             <asp:Label ID="lblPoNo" Text='<%# Eval("PO_NO")  %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </asp:TemplateField>
                    

                     <asp:TemplateField ShowHeader="False" Visible="false">
                        <ItemTemplate>
                        <asp:Button Text="Select" id="btnAction" Width="100px" runat="server" CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>" />
                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("STATUS")  %>' Visible="false"></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>

                      <asp:TemplateField ShowHeader="False" Visible="false">
                        <ItemTemplate>
                        <asp:Label ID="lblTokenType" runat="server" Text='<%# Eval("TOKEN_TYPE")  %>' Visible="false"></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>
                    


                      <asp:TemplateField HeaderText="Name">
                        <ItemTemplate >
                             <asp:Label ID="lblPartsDetail"  Text='<%# Eval("NAME") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" Width="25%" />
                    </asp:TemplateField>


                                          <asp:TemplateField HeaderText="Mobile" >
                        <ItemTemplate >
                             <asp:Label ID="lblMobile"  Text='<%# Eval("MOBILE") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left"  Width="150px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Model">
                        <ItemTemplate >
                             <asp:Label ID="lblPartsType"  Text='<%# Eval("MODEL") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" Width="30%" />
                    </asp:TemplateField>
                     
                    
                     <asp:TemplateField ShowHeader="False" >
                        <ItemTemplate>
                        <asp:ImageButton Text="Select" id="btnClose" Width="30px" runat="server" CommandName="Close" CommandArgument="<%# Container.DataItemIndex %>"  ImageUrl="~/icon/close.jpg"  OnClientClick="return confirm('Are you sure you want to delete?');"/>
                       
                    </ItemTemplate>
                    </asp:TemplateField>


                     <asp:HyperLinkField  Text="Edit"  DataTextField="" DataNavigateUrlFields="UNQ_NO" DataNavigateUrlFormatString="~/Apple_Parts_Create.aspx?UNQ_NO={0}"
            HeaderText="" ItemStyle-Width = "20"  Visible="false"/>
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
    
    <div id="dialog" title="message" style="display:none;">
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </div>
    
</asp:Content>