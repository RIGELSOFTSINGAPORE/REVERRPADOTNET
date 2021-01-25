<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Popup.aspx.vb" Inherits="Ganges33.Popup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <u>Details</u>
        <br />
        <br />
        <b>CRTDT :</b> <span id="CRTDT" runat="server"></span>
        <br />
        <b>CRTCD:</b> <span id="CRTCD"></span>
        <br />
        <b>UPDDT:</b> <span id="UPDDT"></span>
            <br />
        <b>UPDCD:</b> <span id="UPDCD"></span>
            <br />
        <b>UPDPG:</b> <span id="UPDPG"></span>
            <br />
        <b>DELFG:</b> <span id="DELFG"></span>
            <br />
        <b>ship_name:</b> <span id="ship_name"></span>
            <br />
        <b>ship_info:</b> <span id="ship_info"></span>
            <br />
        <b>ship_manager:</b> <span id="ship_manager"></span>
            <br />
        <b>ship_tel:</b> <span id="ship_tel"></span>
            <br />
        <b>ship_add1:</b> <span id="ship_add1"></span>
            <br />
        <b>ship_add2:</b> <span id="ship_add2"></span>
            <br />
        <b>ship_add3:</b> <span id="ship_add3"></span>
            <br />
        <b>zip:</b> <span id="zip"></span>
            <br />
        <b>e_mail:</b> <span id="e_mail"></span>
            <br />
        <b>ship_service:</b> <span id="ship_service"></span>
            <br />
            <b>open_time:</b> <span id="open_time"></span>
            <br />
            <b>close_time:</b> <span id="close_time"></span>
            <br />
            <b>opening_date:</b> <span id="opening_date"></span>
            <br />
            <b>closing_date:</b> <span id="closing_date"></span>
            <br />
            <b>ship_code:</b> <span id="ship_code"></span>
            <br />
            <b>ship_mark:</b> <span id="ship_mark"></span>
            <br />
            <b>item_1:</b> <span id="item_1"></span>
            <br />
            <b>item_2:</b> <span id="item_2"></span>
            <br />
            <b>mess_1:</b> <span id="mess_1"></span>
            <br />
            <b>mess_2:</b> <span id="mess_2"></span>
            <br />
            <b>mess_3:</b> <span id="mess_3"></span>
            <br />
            <b>regi_deposit:</b> <span id="regi_deposit"></span>
            <br />
            <b>PO_no:</b> <span id="PO_no"></span>
            <br />
            <b>inspection1_start:</b> <span id="inspection1_start"></span>
            <br />
            <b>inspection1_end:</b> <span id="inspection1_end"></span>
            <br />
            <b>inspection2_start:</b> <span id="inspection2_start"></span>
            <br />
            <b>inspection2_end:</b> <span id="inspection2_end"></span>
            <br />
            <b>inspection3_start:</b> <span id="inspection3_start"></span>
            <br />
            <b>inspection3_end:</b> <span id="inspection3_end"></span>
            <br />
            <b>open_start:</b> <span id="open_start"></span>
            <br />
            <b>open_end:</b> <span id="open_end"></span>
            <br />
            <b>close_start:</b> <span id="close_start"></span>
            <br />
            <b>close_end:</b> <span id="close_end"></span>
            <br />
            <b>GSTIN:</b> <span id="GSTIN"></span>
            <br />
            <b>Parent_Ship_Name:</b> <span id="Parent_Ship_Name"></span>
            <br />
            <b>IsChildShip:</b> <span id="IsChildShip"></span>
            <br />
            <b>RpaClientUserId:</b> <span id="RpaClientUserId"></span>
            <br />
            <b>RpaClientPwd:</b> <span id="RpaClientPwd"></span>
            <br />
            <b>pwdupdateddate:</b> <span id="pwdupdateddate"></span>
            <br />
             <b>IsShipCodeChanged:</b> <span id="IsShipCodeChanged"></span>
            <br />

            
    <%-- <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
        <script type="text/javascript">
            $(function () {
                if (window.opener != null && !window.opener.closed) {
                    var rowIndex = window.location.href.split("?")[1].split("=")[1];
                    var parent = $(window.opener.document).contents();
                    var row = parent.find("[id*=getdata]").find("tr").eq(rowIndex);
                    $("#CRTDT").html(row.find("td").eq(0).html());
                    $("#CRTCD").html(row.find("td").eq(1).html());
                    $("#UPDDT").html(row.find("td").eq(2).html());
                    $("#UPDCD").html(row.find("td").eq(3).html());
                    $("#UPDPG").html(row.find("td").eq(4).html());
                    $("#DELFG").html(row.find("td").eq(5).html());
                    $("#ship_name").html(row.find("td").eq(6).html());
                    $("#ship_info").html(row.find("td").eq(7).html());
                    $("#ship_manager").html(row.find("td").eq(8).html());
                    $("#ship_tel").html(row.find("td").eq(9).html());
                    $("#ship_add1").html(row.find("td").eq(10).html());
                    $("#ship_add2").html(row.find("td").eq(11).html());
                    $("#ship_add3").html(row.find("td").eq(12).html());
                    $("#zip").html(row.find("td").eq(13).html());
                    $("#e_mail").html(row.find("td").eq(14).html());
                    $("#ship_service").html(row.find("td").eq(15).html());
                    $("#open_time").html(row.find("td").eq(16).html());
                    $("#close_time").html(row.find("td").eq(17).html());
                    $("#opening_date").html(row.find("td").eq(18).html());
                    $("#closing_date").html(row.find("td").eq(19).html());
                    $("#ship_code").html(row.find("td").eq(20).html());
                    $("#ship_mark").html(row.find("td").eq(21).html());
                    $("#item_1").html(row.find("td").eq(22).html());
                    $("#item_2").html(row.find("td").eq(23).html());
                    $("#mess_1").html(row.find("td").eq(24).html());
                    $("#mess_2").html(row.find("td").eq(25).html());
                    $("#mess_3").html(row.find("td").eq(26).html());
                    $("#regi_deposit").html(row.find("td").eq(27).html());
                    $("#PO_no").html(row.find("td").eq(28).html());
                    $("#inspection1_start").html(row.find("td").eq(29).html());
                    $("#inspection1_end").html(row.find("td").eq(30).html());
                    $("#inspection2_start").html(row.find("td").eq(31).html());
                    $("#inspection2_end").html(row.find("td").eq(32).html());
                    $("#inspection3_start").html(row.find("td").eq(33).html());
                    $("#inspection3_end").html(row.find("td").eq(34).html());
                    $("#open_start").html(row.find("td").eq(35).html());
                    $("#open_end").html(row.find("td").eq(36).html());
                    $("#close_start").html(row.find("td").eq(37).html());
                    $("#close_end").html(row.find("td").eq(38).html());
                    $("#GSTIN").html(row.find("td").eq(39).html());
                    $("#Parent_Ship_Name").html(row.find("td").eq(40).html());
                    $("#IsChildShip").html(row.find("td").eq(41).html());
                    $("#RpaClientUserId").html(row.find("td").eq(42).html());
                    $("#RpaClientPwd").html(row.find("td").eq(43).html());
                    $("#pwdupdateddate").html(row.find("td").eq(44).html());
                    $("#IsShipCodeChanged").html(row.find("td").eq(45).html());
                }
            });
        </script>--%>








        </div>
      
    </form>
</body>
</html>
