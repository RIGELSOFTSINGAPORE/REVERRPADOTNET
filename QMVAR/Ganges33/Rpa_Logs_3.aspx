<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Rpa_Logs_3.aspx.vb" Inherits="Ganges33.Rpa_Logs_3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            





















<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <table>
        <tr><td><asp:Label id="lblInfo" runat="server"></asp:Label></td></tr>
        <tr><td>From <asp:TextBox ID="txtDateFrom" runat="server" Width="80px" >  </asp:TextBox> To: <asp:TextBox ID="txtDateTo" runat="server"  Width="80px" ></asp:TextBox>
    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="yyyy/MM/dd" runat="server" BehaviorID="txtDateFrom" TargetControlID="txtDateFrom" PopupPosition="Left"/>
    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="yyyy/MM/dd" runat="server" BehaviorID="txtDateTo" TargetControlID="txtDateTo" PopupPosition="Left"/>
            <asp:Button  ID="btnSearch" runat="server" Text="Search"/>
            </td></tr>
        <tr><td>
     <div class="GridviewDiv">
<asp:GridView runat="server" ID="gvDetails" AllowPaging="true" PageSize="10" AutoGenerateColumns="false" Width="420px" OnPageIndexChanging="gvDetails_PageIndexChanging">
<HeaderStyle  BackColor="#F0F0F0" />
<Columns>
<asp:BoundField DataField="SCHEDULER_NAME" HeaderText="SchedulerName" />
<asp:BoundField DataField="TaskName" HeaderText="TaskName" />
<asp:TemplateField HeaderText="ProcessID">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
<ItemTemplate>
<a onclick="javascript:window.open('Rpa_LogsDetails.aspx?id=<%#DataBinder.Eval(Container.DataItem, "ProcessId")%>');" href="#" id="a6" ><%#DataBinder.Eval(Container.DataItem, "ProcessId")%></a>
</ItemTemplate>
</asp:TemplateField>


<asp:BoundField DataField="ProcessType" HeaderText="Type"  />
<asp:BoundField DataField="StartDateTime" HeaderText="StartDateTime" />
<asp:BoundField DataField="EndDateTime" HeaderText="EndDateTime" />
<asp:BoundField DataField="Status" HeaderText="Status"  Visible="false"/>
<asp:TemplateField HeaderText="Status" >  
        <ItemTemplate>  
        <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>  
         </ItemTemplate>  
        </asp:TemplateField>  
<asp:BoundField DataField="SSC" HeaderText="SSC" />
<asp:BoundField DataField="TaskCount" HeaderText="Task" ItemStyle-HorizontalAlign="Center"/>
<asp:BoundField DataField="SuccessCount" HeaderText="Success" ItemStyle-HorizontalAlign="Center"/>
<asp:BoundField DataField="ReRunCount" HeaderText="ReRun" ItemStyle-HorizontalAlign="Center"/>
<asp:BoundField DataField="FailureCount" HeaderText="Failure" ItemStyle-HorizontalAlign="Center"/>
<asp:BoundField DataField="DataFoundCount" HeaderText="DataFound" ItemStyle-HorizontalAlign="Center"/>
<asp:BoundField DataField="NoDataCount" HeaderText="NoData" ItemStyle-HorizontalAlign="Center" />
<asp:BoundField DataField="UploadSuccessCount" HeaderText="Upload Success" ItemStyle-HorizontalAlign="Center"/>
<asp:BoundField DataField="UploadFailureCount" HeaderText="Upload Failure" ItemStyle-HorizontalAlign="Center" />
<asp:TemplateField HeaderText="logview">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
<ItemTemplate>
<a onclick="javascript:window.open('Rpa_logview.aspx?id=<%#DataBinder.Eval(Container.DataItem, "logview")%>&src=<%#DataBinder.Eval(Container.DataItem, "SSC")%>');" href="#" id="a6" ><%#DataBinder.Eval(Container.DataItem, "logview")%></a>
</ItemTemplate>
</asp:TemplateField>


</Columns>
</asp:GridView></div>
        </td></tr></table>













        </div>
    </form>
</body>
</html>
