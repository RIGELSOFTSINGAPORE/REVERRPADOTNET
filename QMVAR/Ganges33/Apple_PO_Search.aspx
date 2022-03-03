<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/AppleAnalysis.Master" CodeBehind="Apple_PO_Search.aspx.vb" Inherits="Ganges33.Apple_PO_Search" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     
   
   <%-- <script  src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.0/jquery.min.js"></script>
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
    <style type="text/css">

        .container{
    -ms-overflow-style: none;
    overflow: auto;
}
        .text{
           text-transform:capitalize;
       }
       
   </style>

   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
     <script>
        $(function () {

            $('[class*=date]').datepicker({
                changeMonth: true,
                changeYear: true,                
                yearRange: "0000:9999",
                maxDate: new Date(),
                dateFormat: 'yyyy/mm/dd'

            });
        //});
    </script>
  
   <div class="wrapper  col-sm-12 sidebar-wrapper position-fixed scrolbar contain" id="style-10">
   
    <div class="content" >
        <div class="container-fluid">
          <div class="row">
            <div class="col-md-12">
              <div class="card">
                <div class="card-header card-header-primary">
                  <h3 class="card-title ">PO/G NO Search</h3>
                  <p class="card-category"></p>
                </div>
                <div class="card-body scrollbar" id="style-10" >
                      
                   
                     
                    <br />
                     <div class="row col-sm-12" style="height:40px">
      <div>
          <label>
              From
          </label>
      </div>
      <div  class="col-sm-2">
           <asp:TextBox ID="txtFrom" CssClass="form-file-upload date serverlbl"  style="margin-left: 34px;" runat="server"  autocomplete="off"></asp:TextBox>

      </div>
                         <div  class="col-sm-" >
                             <label style="margin-left: 34px;">
                                 To
                             </label>
                         </div>
                         <div  class="col-sm-2">
                             <asp:TextBox ID="txtTo" CssClass="form-file-upload date serverlbl" Style="margin-left: 42px; "  runat="server"   autocomplete="off"  ></asp:TextBox>
                     
                   
                             </div>
                         
                            <div >
               <label style="    margin-left: 43px;">
                   Customer Name
               </label>
      </div>
      <div  class="col-sm-2">
              <asp:TextBox ID="txtCustomerName" CssClass="form-file-upload serverlbl"  runat="server"></asp:TextBox>
                    
      </div>
                              
 <div>
     
               <label>
                   Mobile
               </label>
      </div>
      <div  class="col-sm-2">
            
           <asp:TextBox ID="txtPhoneNo" CssClass="form-file-upload serverlbl" Style="" runat="server"></asp:TextBox>
                  
      </div>
                          <br />.
      </div>


                     <br />



                 
                     <div class="row col-sm-12" style="height:40px">
                          <br />
                          <div >
               <label >
                       
                   Status
               </label>
      </div>
      <div  class="col-sm-2">
         
           <asp:DropDownList ID="drpStatus" CssClass="form-control serverlbl" style="height: 33px;margin-left: 24px; width: 135px;"  runat="server">
                              <asp:ListItem Text="All" Value="0" Selected="True"></asp:ListItem>    
                             <asp:ListItem Text="Complete" Value="1"></asp:ListItem>
                              <asp:ListItem Text="Reception only" Value="2"></asp:ListItem>
                              <asp:ListItem Text="Incomplete" Value="3"></asp:ListItem>
                             <asp:ListItem Text="Handed over" Value="4"></asp:ListItem>
                             
                              
                        </asp:DropDownList>
      </div>
   
                                    <div>
<label style="margin-left: 25px;">
          
    Product
</label>
      </div>
      <div  class="col-sm-2">
                 
           <asp:TextBox ID="txtProduct" CssClass="form-file-upload serverlbl"  runat="server"></asp:TextBox>
                   
      </div>
                           <div >
               <label>
                        
                   Parts No
               </label>
      </div>
      <div class="col-sm-2">
                
          <asp:TextBox ID="txtPartsNo" CssClass="form-file-upload serverlbl" Style="margin-left:57px" runat="server"></asp:TextBox>
                   
      </div>
                                         <div >
               <label style="margin-left:57px">
                         
                   Serial
               </label>
      </div>
      <div class="col-sm-2">       
           <asp:TextBox ID="txtSerialNo" CssClass="form-file-upload serverlbl" Style="margin-left:8px"  runat="server"></asp:TextBox>
                  
      </div>
      </div>
                   
                    
                   
                    <div class="">
                           <br />
                        <asp:Button ID="btnSearch" runat="server" Width="90px" height="36px" Text="Search" class="btn btn-primary text" />

                       <asp:ImageButton ID="btnImgExcel" runat="server" src="icon/excel.png"  CssClass="pull-right" Style="width:40px;margin-right: 10px; height:40px" /> 
                    </div>


                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <br />
                      <asp:GridView ID="gvPOInfo" runat="server" Width="99%" AllowPaging="true"
                PageSize="10" AutoGenerateColumns="False" EmptyDataText="No records Found" 
               Style="align-self: center" CssClass="col-sm-12"  OnPageIndexChanging="gvPOInfo_PageIndexChanging" OnSorting="OnSorting"  AllowSorting="true"  EnableViewState="true" >
                <Columns>
                      <asp:HyperLinkField DataTextField="PO_No" SortExpression="PO_No"  DataNavigateUrlFields="PO_No" DataNavigateUrlFormatString="~/Apple_Customer_Information.aspx?PoNo={0}"
            HeaderText="PO No" ItemStyle-Width = "150" />
                      <asp:TemplateField HeaderText="G No"  SortExpression="G_No">
                        <ItemTemplate >
                             <asp:Label ID="lblGNo"  Text='<%# Eval("G_NO") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Customer Name">
                        <ItemTemplate >
                             <asp:Label ID="lblCustName"  Text='<%# Eval("CUSTOMER_NAME") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" Width="20%" />
                    </asp:TemplateField>

                       
                     <asp:TemplateField HeaderText="Serial">
                         
                        <ItemTemplate>
                             <asp:Label ID="lblSerialNo"  Text='<% # Eval("SERIAL_NO")  %>'  runat="server"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="20%" />
                    </asp:TemplateField>
                           <asp:TemplateField HeaderText="Product">
                        <ItemTemplate>
                             <asp:Label ID="lblProductName"  Text='<%# Eval("PRODUCT_NAME")  %>'  runat="server"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="30%" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Status"  SortExpression="STATUS" >
                        <ItemTemplate>

                             <asp:Label ID="lblCompStatus" Text='<%# Eval("COMP_STATUS")  %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="Delivery&nbsp;Date">
                        <ItemTemplate>

                             <asp:Label ID="lblDeliveryDate" Text='<%# Eval("DELIVERY_DATE")  %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="PO Date">
                        <ItemTemplate>

                             <asp:Label ID="lblPoDate" Text='<%# Eval("PO_DATE")  %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                    </asp:TemplateField>
                    
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
 
</div>

                </div>
              </div>
               </div>
            
     </div>
            
    </div>
        </div>
    
    
    
  
     

</asp:Content>