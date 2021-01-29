
    $(function () {
        $("[id*=lnkView]").click(function () {
            //var rowIndex = $(this).closest("tr").find('.shop').val();
            var rowIndex = $(this).closest("tr")[0].innerText;
           // var rowIndex = $(this).closest("tr").children('td:eq(0)').text();
            //alert(rowIndex);
            window.open("Popup.aspx?rowindex=" + rowIndex , 'Popup', 'height=500,width=3000,left=100,top=100,resizable=yes,scrollbars=yes,toolbar=yes,menu=no');

        });
    });
//Dim str2 As String = "window.open('Analysis_Servicecenter.aspx?UserId=" & index & "','myWindow','width=800,height=500,left=100,top=100,resizable=yes')"

//<script type="text/javascript" >
  //  function ShowDetailPopup(ship_code) {
    //    popup.SetContentUrl('Popup.aspx? id=' + ship_code);
      //  popup.Show();
      
     // }
//</script>

 // alert("hi");
   // window.open('Popup.aspx?id=' + ship_code,'height=450,width=500,left=500,top=300,resizable=no,scrollbars=yes,toolbar=yes,menu=no')