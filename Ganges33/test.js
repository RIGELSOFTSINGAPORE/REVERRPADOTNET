$(function () {
    $("[id*=lnkView]").click(function () {
        var rowIndex = $(this).closest("tr")[0].innerText;   //.cells[0].innertext
        
        window.open("Popup.aspx?rowIndex=" + rowIndex, "Popup", "width=350,height=100");
    });
});