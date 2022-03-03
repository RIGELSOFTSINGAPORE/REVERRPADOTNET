
    $(function () {
        $("[id*=lnkView]").click(function () {
           //var rowIndex = $(this).closest("tr").find('.shop').val();
            // var rowIndex = $(this).closest("tr")[0].innerText;
            var rowIndex = $(this)[0].getAttribute("data-commandargument");

           // var rowIndex = $(this).closest("tr").children('td:eq(0)').text();
           // alert(rowIndex);
           window.open("Popup.aspx?rowindex=" + rowIndex , 'Popup', 'height=500,width=750,left=100,top=100,resizable=yes,scrollbars=yes,toolbar=yes,menu=no');

       });
    });

//$(function () {

   // $("[id*=getdata]").find("[id*=lnkView]").click(function () {

       // alert("HI");
        //Reference the GridView Row.
     //   var row = $(this).closest("tr");

        ////Determine the Row Index.
      //  var rowIndex = "Row Index: " + (row[0].rowIndex - 1);
       // alert("rowIndex");

        ////Read values from Cells.
     //   message += "\CRTDT: " + row.find("td").eq(0).html();
      //  message += "\nCRTCD: " + row.find("td").eq(1).html();

        ////Reference the TextBox and read value.
       // message += "\nUPDDT: " + row.find("td").eq(2).find("input").eq(0).val();

        ////Display the data using JavaScript Alert Message Box.
       // alert(message);
       // return false;
    //      window.open("Popup.aspx?rowindex=" + rowIndex, 'Popup', 'height=500,width=3000,left=100,top=100,resizable=yes,scrollbars=yes,toolbar=yes,menu=no');
  // });
//});
//Dim str2 As String = "window.open('Analysis_Servicecenter.aspx?UserId=" & index & "','myWindow','width=800,height=500,left=100,top=100,resizable=yes')"

//<script type="text/javascript" >
  //  function ShowDetailPopup(ship_code) {
    //    popup.SetContentUrl('Popup.aspx? id=' + ship_code);
      //  popup.Show();
      
     // }
//</script>

 // alert("hi");
   // window.open('Popup.aspx?id=' + ship_code,'height=450,width=500,left=500,top=300,resizable=no,scrollbars=yes,toolbar=yes,menu=no')