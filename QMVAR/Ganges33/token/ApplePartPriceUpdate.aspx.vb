Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml
Imports System
Imports System.Web.Security
Imports System.Collections.Generic
Imports Ganges33.Ganges33.dao
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Imports System.Web.Configuration
Imports Microsoft.VisualBasic.FileIO

Partial Class ApplePartPriceUpdate
    Inherits System.Web.UI.Page
    Dim strConn As String = WebConfigurationManager.ConnectionStrings("cnstr").ToString()


    Dim con As New SqlConnection(strConn)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            '***セッションなしログインユーザの対応***
            Dim userid As String = Session("user_id")
            If userid = "" Then
                Response.Redirect("~/Login.aspx")
            End If
        End If

    End Sub

    'Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

    '    lblStatusText.Text = ""
    '    If drpPriceOption.SelectedItem.Value = "0" Then
    '        lblStatusText.Text = "<br><br>Execution Result: <br> <font color=red>Please select Price Option</font>"
    '        Exit Sub
    '    End If

    '    If drpPriceType.SelectedItem.Value = "0" Then
    '        lblStatusText.Text = "<br><br>Execution Result: <br> <font color=red>Please select Price Type</font>"
    '        Exit Sub
    '    End If

    '    If Len(txtDetailsCsv.Text) < 7 Then
    '        lblStatusText.Text = "<br><br>Execution Result: <br> <font color=red>Provide Valid Part No and Price</font>"
    '        Exit Sub
    '    End If




    '    Dim txt As String = txtDetailsCsv.Text
    '    Dim lst As String() = txt.Split(New String() {Environment.NewLine},
    '                                   StringSplitOptions.None)
    '    Dim colsData() As String
    '    lblStatusText.Text = "<br><br>Execution Result: <br>"
    '    Dim strPartNo As String = ""
    '    Dim strPrice As Decimal = 0.00

    '    Dim strStatusText As String = ""
    '    Dim strPriceOptions As String = ""
    '    Dim Sno As Integer = 0

    '    Dim strStatusAll As String = ""

    '    Dim strPriceType As String = ""

    '    strPriceOptions = drpPriceOption.SelectedItem.Text
    '    strPriceType = drpPriceType.SelectedItem.Text

    '    For i = 0 To lst.Length - 1
    '        colsData = Split(lst(i), ",")
    '        'colsData = lst(i).Split(New String() {Environment.NewLine},            StringSplitOptions.RemoveEmptyEntries)
    '        strPartNo = colsData(0)
    '        strPrice = 0.00

    '        If strPartNo <> "" Then


    '            If Decimal.TryParse(colsData(1), strPrice) Then
    '            Else
    '                strStatusAll = strStatusAll & "<br> Part No=> " & strPartNo & "   <font color=red>===>Decimal Error...Not Updated</font>"
    '                Continue For
    '            End If


    '            If Len(strPartNo) > 5 Then
    '                If Len(strPrice) > 2 Then

    '                    strStatusText = PartPriceUpdate(strPartNo, strPrice, strPriceOptions, strPriceType)

    '                    If strStatusText = "0" Then

    '                        strStatusAll = strStatusAll & "<br> Part No=> " & strPartNo & "   <font color=green>===>Done</font>"

    '                    Else
    '                        strStatusAll = strStatusAll & "<br> Part No=> " & strPartNo & "   <font color=red>===>DB Error...Not Updated</font>"
    '                    End If
    '                End If
    '            End If

    '        End If

    '    Next i

    '    lblStatusText.Text = lblStatusText.Text & strStatusAll
    'End Sub


    Protected Function PartPriceUpdate(PartNo As String, PartPrice As String, PriceOptions As String, PriceType As String) As String
        Dim Status As String = ""
        Dim cmd As New SqlCommand
        Try
            con.Open()
            Dim qry As String = ""
            qry = "update AP_PARTS SET " & PriceType & "='" & PartPrice & "' where PARTS_NO='" & PartNo & "' AND PRICE_OPTION='" & PriceOptions & "' "
            cmd = New SqlCommand(qry, con)
            cmd.ExecuteNonQuery()
            Status = "0"
        Catch dbExec As Exception
            Status = "1"
        Finally
            con.Close()
        End Try
        Return Status
    End Function


    'Protected Sub btnUpdate2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate2.Click

    '    lblStatusText.Text = ""
    '    If drpPriceOption.SelectedItem.Value = "0" Then
    '        lblStatusText.Text = "<br><br>Execution Result: <br> <font color=red>Please select Price Option</font>"
    '        Exit Sub
    '    End If

    '    If drpPriceType.SelectedItem.Value = "0" Then
    '        lblStatusText.Text = "<br><br>Execution Result: <br> <font color=red>Please select Price Type</font>"
    '        Exit Sub
    '    End If

    '    If Len(txtDetailsCsv.Text) < 7 Then
    '        lblStatusText.Text = "<br><br>Execution Result: <br> <font color=red>Provide Valid Part No and Price</font>"
    '        Exit Sub
    '    End If


    '    Dim txt As String = txtDetailsCsv.Text
    '    Dim lst As String() = txt.Split(New String() {Environment.NewLine},
    '                                   StringSplitOptions.None)
    '    Dim colsData() As String
    '    lblStatusText.Text = "<br><br>Execution Result: <br>"
    '    Dim strPartNo As String = ""
    '    Dim strPrice As Decimal = 0.00

    '    Dim strPartTaxPercentage As Decimal = 0.00

    '    Dim strStatusText As String = ""
    '    Dim strPriceOptions As String = ""
    '    Dim Sno As Integer = 0

    '    Dim strStatusAll As String = ""

    '    Dim strPriceType As String = ""

    '    strPriceOptions = drpPriceOption.SelectedItem.Text
    '    strPriceType = drpPriceType.SelectedItem.Text

    '    Dim cntInput As Int16 = 0

    '    For i = 0 To lst.Length - 1
    '        colsData = Split(lst(i), ",")
    '        'colsData = lst(i).Split(New String() {Environment.NewLine},            StringSplitOptions.RemoveEmptyEntries)
    '        strPartNo = colsData(0)
    '        strPrice = 0.00
    '        strPartTaxPercentage = 0.00

    '        cntInput = colsData.Count

    '        If (cntInput < 3) Then
    '            strStatusAll = strStatusAll & "<br> Part No=> " & strPartNo & "   <font color=red>===>Data provided not enough...Not Updated</font>"
    '            Continue For
    '        End If

    '        If strPartNo <> "" Then


    '            If Decimal.TryParse(colsData(1), strPrice) Then
    '            Else
    '                strStatusAll = strStatusAll & "<br> Part No=> " & strPartNo & "   <font color=red>===>Price Decimal Error...Not Updated</font>"
    '                Continue For
    '            End If

    '            If Decimal.TryParse(colsData(2), strPartTaxPercentage) Then
    '            Else
    '                strStatusAll = strStatusAll & "<br> Part No=> " & strPartNo & "   <font color=red>===>Tax Percentage Decimal Error...Not Updated</font>"
    '                Continue For
    '            End If


    '            If Len(strPartNo) > 5 Then
    '                If Len(strPrice) > 2 Then
    '                    If Len(strPartTaxPercentage) > 2 Then

    '                        strStatusText = PartPriceUpdateTax(strPartNo, strPrice, strPriceOptions, strPriceType, strPartTaxPercentage)

    '                        If strStatusText = "0" Then

    '                            strStatusAll = strStatusAll & "<br> Part No=> " & strPartNo & "   <font color=green>===>Done</font>"

    '                        Else
    '                            strStatusAll = strStatusAll & "<br> Part No=> " & strPartNo & "   <font color=red>===>DB Error...Not Updated</font>"
    '                        End If
    '                    End If
    '                End If
    '            End If

    '        End If

    '    Next i

    '    lblStatusText.Text = lblStatusText.Text & strStatusAll
    'End Sub

    Protected Function PartPriceUpdateTax(PartNo As String, PartPrice As String, PriceOptions As String, PriceType As String, PartTaxPercentage As String) As String
        Dim Status As String = ""
        Dim cmd As New SqlCommand
        Try
            con.Open()
            Dim qry As String = ""
            qry = "update AP_PARTS SET " & PriceType & "='" & PartPrice & "',PART_TAX_PERCENTAGE='" & PartTaxPercentage & "' where PARTS_NO='" & PartNo & "' AND PRICE_OPTION='" & PriceOptions & "' "
            cmd = New SqlCommand(qry, con)
            cmd.ExecuteNonQuery()
            Status = "0"
        Catch dbExec As Exception
            Status = "1"
        Finally
            con.Close()
        End Try
        Return Status
    End Function



    Protected Sub btnUpdate3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate3.Click

        lblStatusText.Text = ""
        'If chkMaster.Checked = False Then
        '    lblStatusText.Text = "<br><br>Execution Result: <br> <font color=red>Please Click Master Price update</font>"
        '    Exit Sub
        'End If

        If Not FileUploadAnalysis.HasFile Then
            lblStatusText.Text = "<br><br>Execution Result: <br> <font color=red>File Not Uploaded!!!</font>"
            Exit Sub
        End If


        'Dim txt As String = txtDetailsCsv.Text
        ' Dim lst As String() = txt.Split(New String() {Environment.NewLine},
        ' StringSplitOptions.None)
        Dim colsData() As String

        Dim textLines As New List(Of String())
        Dim strArr()() As String


        'For i = 0 To lst.Length - 1
        '    colsData = Split(lst(i), ",")
        '    textLines.Add(colsData)
        'Next
        Dim strExtension As String = System.IO.Path.GetExtension(FileUploadAnalysis.FileName)
        Dim strFileName As String = System.IO.Path.GetFileNameWithoutExtension(FileUploadAnalysis.FileName)
        Dim strSrcFileName As String = System.IO.Path.GetFileName(FileUploadAnalysis.FileName)
        'Move the file to temporary folder
        If Not Directory.Exists(ConfigurationManager.AppSettings("RootDir") & "\ASP1\umekita4\upload") Then
            Directory.CreateDirectory(ConfigurationManager.AppSettings("RootDir") & "\ASP1\umekita4\upload")
        End If
        'Assign File Name
        Dim dirPath As String = ConfigurationManager.AppSettings("RootDir") & "\ASP1\umekita4\upload"
        Dim fileName As String = strFileName & "_" & DateTime.Now.ToString("yyyyMMddHHmmssfff") & strExtension
        Dim filenameFullPath As String = dirPath & "\" & fileName
        'Save the file in temporary folder
        FileUploadAnalysis.SaveAs(filenameFullPath)



        Dim fileReader As New TextFieldParser(filenameFullPath)
        fileReader.TextFieldType = FieldType.Delimited
        fileReader.SetDelimiters(",")
        fileReader.HasFieldsEnclosedInQuotes = True

        While fileReader.EndOfData = False
            Dim columnData() As String = fileReader.ReadFields

            ' Processing of field data
            textLines.Add(columnData)
        End While




        strArr = textLines.ToArray





        'strPriceOptions = drpPriceOption.SelectedItem.Text
        'strPriceType = drpPriceType.SelectedItem.Text







        Dim _ApplePriceModel As ApplePriceModel = New ApplePriceModel()
        Dim _ApplePriceControl As ApplePriceControl = New ApplePriceControl()
        _ApplePriceModel.UPDPG = "ApplePartPrice.aspx"
        _ApplePriceModel.FileName = ""
        _ApplePriceModel.SrcFileName = ""
        _ApplePriceModel.UserId = "umekita4"
        _ApplePriceModel.UserName = "umekita4"
        _ApplePriceModel.ShipToBranchCode = "999999999"
        _ApplePriceModel.ShipToBranch = "ASP1"
        _ApplePriceModel.PriceType = drpPriceType.SelectedItem.Text
        _ApplePriceModel.PriceOption = drpPriceOption.SelectedItem.Text




        Dim blStatus As Boolean = _ApplePriceControl.AddModifyPriceUpdate(strArr, _ApplePriceModel)
        'If Error Raised then show the errors
        If Not blStatus Then
            ' Call showMsg("Status: Upload Failed   Please check the content of file ", "")
            lblStatusText.Text = "Status: <font color=red> Upload Failed   Please check the content of file </font> "
            Exit Sub
        Else
            ' Call showMsg("Status: Upload Success  The file has been uploaded", "")
            lblStatusText.Text = "Status: <font color=green>Upload Success  The file has been uploaded</font>"
        End If


        'Dim strArr()() As String
        'strArr = textLines.ToArray


        'Dim txt As String = txtDetailsCsv.Text
        'Dim lst As String() = txt.Split(New String() {Environment.NewLine},
        '                               StringSplitOptions.None)
        'Dim colsData() As String
        'lblStatusText.Text = "<br><br>Execution Result: <br>"
        'Dim strPartNo As String = ""
        'Dim strPrice As Decimal = 0.00

        'Dim strPartTaxPercentage As Decimal = 0.00

        'Dim strStatusText As String = ""
        'Dim strPriceOptions As String = ""
        'Dim Sno As Integer = 0

        'Dim strStatusAll As String = ""

        'Dim strPriceType As String = ""

        'strPriceOptions = drpPriceOption.SelectedItem.Text
        'strPriceType = drpPriceType.SelectedItem.Text

        'Dim cntInput As Int16 = 0

        'For i = 0 To lst.Length - 1
        '    colsData = Split(lst(i), ",")
        '    'colsData = lst(i).Split(New String() {Environment.NewLine},            StringSplitOptions.RemoveEmptyEntries)
        '    strPartNo = colsData(0)
        '    strPrice = 0.00
        '    strPartTaxPercentage = 0.00

        '    cntInput = colsData.Count

        '    If (cntInput < 3) Then
        '        strStatusAll = strStatusAll & "<br> Part No=> " & strPartNo & "   <font color=red>===>Data provided not enough...Not Updated</font>"
        '        Continue For
        '    End If

        '    If strPartNo <> "" Then


        '        If Decimal.TryParse(colsData(1), strPrice) Then
        '        Else
        '            strStatusAll = strStatusAll & "<br> Part No=> " & strPartNo & "   <font color=red>===>Price Decimal Error...Not Updated</font>"
        '            Continue For
        '        End If

        '        If Decimal.TryParse(colsData(2), strPartTaxPercentage) Then
        '        Else
        '            strStatusAll = strStatusAll & "<br> Part No=> " & strPartNo & "   <font color=red>===>Tax Percentage Decimal Error...Not Updated</font>"
        '            Continue For
        '        End If


        '        If Len(strPartNo) > 5 Then
        '            If Len(strPrice) > 2 Then
        '                If Len(strPartTaxPercentage) > 2 Then

        '                    strStatusText = PartPriceUpdateTax(strPartNo, strPrice, strPriceOptions, strPriceType, strPartTaxPercentage)

        '                    If strStatusText = "0" Then

        '                        strStatusAll = strStatusAll & "<br> Part No=> " & strPartNo & "   <font color=green>===>Done</font>"

        '                    Else
        '                        strStatusAll = strStatusAll & "<br> Part No=> " & strPartNo & "   <font color=red>===>DB Error...Not Updated</font>"
        '                    End If
        '                End If
        '            End If
        '        End If

        '    End If

        'Next i

        'lblStatusText.Text = lblStatusText.Text & strStatusAll
    End Sub


End Class
