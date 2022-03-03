<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/AppleAnalysis.Master" CodeBehind="Apple_Reword.aspx.vb" Inherits="Ganges33.Apple_Reword" %>
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
         .text{
           text-transform:capitalize;
       }
         .GridPager a, .GridPager span
{
display: block;
height: 20px;
width: 20px;
font-weight: bold;
text-align: center;
text-decoration: none;
}
.GridPager a
{
background-color:#9c27b0;
color: white;
border-radius: 3px;

}
.GridPager span
{
background-color: transparent;
color: #000;
border: 1px;
}
         </style>
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
                  <h3 class="card-title ">Reward Search</h3>
                  <p class="card-category"></p>
                </div>
                <div class="card-body scrollbar" id="style-10" >
              
                
                     <div class="row ">
           <div class="col-sm-2">
               <label>Part No
               </label>
      </div>
      <div>
              <asp:TextBox ID="txtPartNo" CssClass="form-file-upload serverlbl"  runat="server"></asp:TextBox>
                    
      </div>
      </div>
     <br />
                     <div class="row ">
           <div class="col-sm-2">
<label>Labour Code
    
</label>
      </div>
      <div>
           <asp:TextBox ID="txtLabourCode" CssClass="form-file-upload serverlbl"  runat="server"></asp:TextBox>
          
                <div class="col-sm-12"><br />
                        <asp:Button ID="btnSearch" runat="server" Width="90px" height="36px" Text="Search" class="btn btn-primary text" />
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnNew" runat="server"  Width="145px" height="36px" Text="Add New Reward" class="btn btn-primary  text" />
                    </div>      
      </div>
      </div>

                    <br />
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
           

                  <asp:GridView ID="gvReword" runat="server" Width="99%" AllowPaging="true"
                PageSize="10" AutoGenerateColumns="False" EmptyDataText="No records Found" 
               Style="align-self: center" CssClass="col-sm-12"  OnPageIndexChanging="gvReword_PageIndexChanging"  EnableViewState="true" >
                       <PagerStyle HorizontalAlign = "left" CssClass = "GridPager" />
                <Columns>

                     <asp:TemplateField HeaderText="Part&nbsp;No">
                        <ItemTemplate>

                             <asp:Label ID="lblPartNo" Text='<%# Eval("PART_NO")  %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" Width="5%" />
                    </asp:TemplateField>
                    
                                             <asp:TemplateField HeaderText="Labour&nbsp;Code">
                        <ItemTemplate>

                             <asp:Label ID="lblLabourCode" Text='<%# Eval("LABOUR_CODE")  %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" Width="5%" />
                    </asp:TemplateField>



                      <asp:TemplateField HeaderText="Labour Type">
                        <ItemTemplate >
                             <asp:Label ID="lblLabourType"  Text='<%# Eval("LABOUR_TYPE") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Description">
                        <ItemTemplate >
                             <asp:Label ID="lblLabourDescription"  Text='<%# Eval("LABOUR_DESCRIPTION") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Details">
                        <ItemTemplate >
                             <asp:Label ID="lblDetails"  Text='<%# Eval("LABOUR_DETAILS") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Amount_150">
                        <ItemTemplate >
                             <asp:Label ID="lblAmount150"  Text='<%# Eval("AMOUNT_150") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" Width="5%" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Delete&nbsp;Flag">
                        <ItemTemplate >
                             <asp:Label ID="lblDeleteFlag"  Text='<%# Eval("DELFG") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" Width="5%" />
                    </asp:TemplateField>


                     <asp:HyperLinkField  Text="Edit"  DataTextField="" DataNavigateUrlFields="UNQ_NO" DataNavigateUrlFormatString="~/Apple_Reword_Create.aspx?UNQ_NO={0}"
            HeaderText="" ItemStyle-Width = "5%" />
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
   

</div>

          
                 
                     
                
                                        
                 
                </div>
              </div>
               </div>
            
     </div>
            
    </div>
        </div>
    
    
    
</asp:Content>
