<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/AppleAnalysis.Master" CodeBehind="Apple_Token_List.aspx.vb" Inherits="Ganges33.Apple_Token_List" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>


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
    <style type="text/css">

        .container{
    -ms-overflow-style: none;
    overflow: auto;
}
        .textBox{  
background-image:url(/icon/calender.png);   
background-position:right;   
background-repeat:no-repeat;   
padding-left:17px;
}
        .bg-calender-icon {
  background: url(/icon/calender.png) no-repeat 100% ;
 
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
        
     </script>
  
   <div class="wrapper  col-sm-12 sidebar-wrapper position-fixed scrolbar contain" id="style-10">
   
    <div class="content" >
        <div class="container-fluid">
          <div class="row">
            <div class="col-md-12">
              <div class="card">
                <div class="card-header card-header-primary">
                  <h3 class="card-title ">Token List</h3>
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
           <asp:TextBox ID="txtFrom" CssClass="form-file-upload date serverlbl bg-calender-icon"  style="margin-left: 34px;" runat="server"  autocomplete="off"></asp:TextBox>

      </div>
                         <div  class="col-sm-" >
                             <label style="margin-left: 34px;">
                                 To
                             </label>
                         </div>
                         <div  class="col-sm-2">
                        
   <asp:TextBox ID="txtTo" CssClass="form-file-upload date serverlbl bg-calender-icon" Style="margin-left: 42px; "  runat="server"   autocomplete="off"  ></asp:TextBox>
                     
                      
                   
                             </div>
                         
                            <div >
               <label style="    margin-left: 43px;">
                   Name
               </label>
      </div>
      <div  class="col-sm-2">
              <asp:TextBox ID="txtName" CssClass="form-file-upload serverlbl"  runat="server"></asp:TextBox>
                    
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
                             <asp:ListItem Text="START" Value="START"></asp:ListItem>
                              <asp:ListItem Text="COMPLETED" Value="COMPLETED"></asp:ListItem>
                              <asp:ListItem Text="END" Value="END"></asp:ListItem>
                             <asp:ListItem Text="PAUSE" Value="PAUSE"></asp:ListItem>
                             
                              
                        </asp:DropDownList>
      </div>
   
                                    <div>
<label style="margin-left: 25px;">
          
    Model
</label>
      </div>
      <div  class="col-sm-2">
                 
           <asp:TextBox ID="txtModel" CssClass="form-file-upload serverlbl" Style="margin-left:13px"  runat="server"></asp:TextBox>
                   
      </div>
                           <div >
               <label style="margin-left:13px">
                        
                   Po No
               </label>
      </div>
      <div class="col-sm-2">
                
          <asp:TextBox ID="txtPoNo" CssClass="form-file-upload serverlbl" runat="server"></asp:TextBox>
                   
      </div>
                                         <div >
               <label style="margin-left:57px">
                         
                  <%-- Serial--%>
               </label>
      </div>
      <div class="col-sm-2">       
<%--           <asp:TextBox ID="txtSerialNo" CssClass="form-file-upload serverlbl" Style="margin-left:8px"  runat="server"></asp:TextBox>--%>
                  
      </div>
      </div>
                   
                    
                   
                    <div class="">
                           <br />
                        <asp:Button ID="btnSearch" runat="server" Width="90px" height="36px"  Text="Search" class="btn btn-primary text" />

                       <asp:ImageButton ID="btnImgExcel" visible="false" runat="server" src="icon/excel.png"  CssClass="pull-right" Style="width:40px;margin-right: 10px; height:40px" /> 
                    </div>
                    <br />
                      <label>Rows Per Page
               </label>
        <asp:DropDownList ID="drpPage" runat="server" AutoPostBack="true" Font-Size="Small">
        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
        <asp:ListItem Text="5" Value="5"></asp:ListItem>
        <asp:ListItem Text="10" Value="10"></asp:ListItem>
        <asp:ListItem Text="15" Value="15"></asp:ListItem>
        <asp:ListItem Text="20" Value="20"></asp:ListItem>
        <asp:ListItem Text="100" Value="100"></asp:ListItem>
            <asp:ListItem Text="200" Value="200"></asp:ListItem>
        </asp:DropDownList>

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <br />
                      <asp:GridView ID="gvPOInfo" runat="server" Width="99%" AllowPaging="true"
                PageSize="10" AutoGenerateColumns="False" EmptyDataText="No records Found" 
               Style="align-self: center" CssClass="col-sm-12"  OnPageIndexChanging="gvPOInfo_PageIndexChanging" OnSorting="OnSorting"  AllowSorting="true"  EnableViewState="true" >
                <Columns>
                     <%-- <asp:HyperLinkField DataTextField="PO_No" SortExpression="PO_No"  DataNavigateUrlFields="PO_No" DataNavigateUrlFormatString="~/Apple_Customer_Information.aspx?PoNo={0}"
            HeaderText="PO No" ItemStyle-Width = "150" />--%>
                        <asp:TemplateField HeaderText="Po No"  SortExpression="PO_No">
                        <ItemTemplate >
                             <asp:Label ID="lblName"  Text='<%# Eval("PO_No") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Name" SortExpression="NAME">
                        <ItemTemplate >
                             <asp:Label ID="lblName"  Text='<%# Eval("NAME") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                    </asp:TemplateField>

                       
                     <asp:TemplateField HeaderText="Mobile" SortExpression="MOBILE">
                         
                        <ItemTemplate>
                             <asp:Label ID="lblMobile"  Text='<% # Eval("MOBILE")  %>'  runat="server"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                    </asp:TemplateField>
                           <asp:TemplateField HeaderText="Model" SortExpression="Model" >
                        <ItemTemplate>
                             <asp:Label ID="lblPoNo"  Text='<%# Eval("Model")  %>'  runat="server"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="20%" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Status"  SortExpression="STATUS" >
                        <ItemTemplate>

                             <asp:Label ID="lblStatus" Text='<%# Eval("STATUS")  %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="StartDate" SortExpression="START_DATETIME">
                        <ItemTemplate>

                             <asp:Label ID="lblCRTCD" Text='<%# Eval("START_DATETIME")  %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="EndDate" SortExpression="END_DATETIIME">
                        <ItemTemplate>

                             <asp:Label ID="lblCRTCD" Text='<%# Eval("END_DATETIIME")  %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="15%" />
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
