<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ApplePartPriceUpdate.aspx.vb" Inherits="Ganges33.ApplePartPriceUpdate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                <table>
	<tr>
	<td valign=top>Details</td>
	<td>&nbsp;</td>
	</tr>
	<tr>
	 <td colspan="2">PRICE_OPTION: 
          <asp:DropDownList style="width: 235px; background:white;  height: 33px;" ID="drpPriceOption" runat="server">
                <asp:ListItem Text="Select..." Value="0"></asp:ListItem>
                             
              
              <asp:ListItem Text="Exchange Price" Value="1"></asp:ListItem>
                          <asp:ListItem Text="Stock Price" Value="2"></asp:ListItem>
                         <asp:ListItem Text="Battery Only Price" Value="3"></asp:ListItem>
                          <asp:ListItem Text="Display" Value="4"></asp:ListItem>
                         <asp:ListItem Text="ADH" Value="5"></asp:ListItem>
                          <asp:ListItem Text="Cable Replacement" Value="6"></asp:ListItem>



                    </asp:DropDownList>
                   PRICE TYPE: 
                    <asp:DropDownList style="width: 235px; background:white;  height: 33px;" ID="drpPriceType" runat="server">
                             <asp:ListItem Text="Select..." Value="0"></asp:ListItem>
                             <asp:ListItem Text="PRICE_COST" Value="1"></asp:ListItem>
                             <asp:ListItem Text="SALES_PRICE" Value="2"></asp:ListItem>
                    </asp:DropDownList>
         
         
	</tr>
	<tr>
	 <td colspan="2">
       AIRPODS PRO,606-00202,"SVC,PKG,AIRPODS PRO,RECOVERY KIT,CHANNEL",0.18,163.8 ( PRODUCT_NAME, PARTS_NO, PARTS_DETAIL, PART_TAX_PERCENTAGE, PRICE_COST)

	 </td>
	</tr>
    <tr>
        <td colspan="2">
            <asp:FileUpload ID="FileUploadAnalysis" runat="server" Class="serverlbl1" />
        </td>
    </tr>
	<tr>
	 <td colspan="2">
          <asp:Button id="btnUpdate3" runat="server" Text="Sample3 Master Price Update" OnClick="btnUpdate3_Click"></asp:Button>


	 </td>
	</tr>
	<tr>
	 <td colspan="2"><asp:Label ID="lblStatusText" runat="server" Text=""></asp:Label></td>
	</tr>
					
	</table>
        </div>

    </form>
</body>
</html>
