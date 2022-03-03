Imports System.IO
Imports System.Text
Imports System.Globalization
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Imports System.Reflection
Imports Microsoft.VisualBasic.FileIO
'Imports System.Threading

Public Class Apple_Analysis_Upload
    Inherits System.Web.UI.Page

    Dim _ShipBaseControl As ShipBaseControl = New ShipBaseControl()


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then

            '***セッションなしログインユーザの対応***
            Dim userid As String = Session("user_id")
            If userid = "" Then
                Response.Redirect("Login.aspx")
            End If

            '***ログインユーザ情報表示***
            Dim setShipname As String = Session("ship_Name")
            Dim userName As String = Session("user_Name")
            Dim userLevel As String = Session("user_level")
            Dim adminFlg As Boolean = Session("admin_Flg")

            lblLoc.Text = setShipname
            lblName.Text = userName

            InitDropDownList()

            lblHint.Text = ""


        End If


    End Sub

    Protected Sub OnSelectedIndexChanged(sender As Object, e As EventArgs)
        If drpTaskUpload.SelectedValue = "201" Then
            lblHint.Text = " AIRPODS PRO(PRODUCT_NAME),606-00202(PARTS_NO)," & Chr(34) & "SVC,PKG,AIRPODS PRO,RECOVERY KIT,CHANNEL" & Chr(34) & "(PARTS_DETAIL),0.18(PART_TAX_PERCENTAGE),163.8 ( PRICE_COST / SALES_PRICE),196.56(SALES_PRICE)=>Optional"
        Else
            lblHint.Text = ""
        End If
    End Sub

    Protected Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click

        If DropListLocation.SelectedItem.Text = "Select Branch" Then
            Call showMsg("Status:  Select Branch ", "")
            Exit Sub
        End If

        If drpTaskUpload.SelectedItem.Value = "-1" Then
            Call showMsg("Status:  Select Task Name ", "")
            Exit Sub
        End If


        If drpPriceOption.SelectedItem.Value = "0" Then
            Call showMsg("Status:  Select PRICE_OPTION ", "")
            Exit Sub
        End If



        If drpPriceType.SelectedItem.Value = "0" Then
            Call showMsg("Status:  Select PRICE TYPE ", "")
            Exit Sub
        End If

        If Not FileUploadAnalysis.HasFile Then
            Call showMsg("Status:  File Not Uploaded!!! ", "")
            'lblStatusText.Text = "<br><br>Execution Result: <br> <font color=red>File Not Uploaded!!!</font>"
            Exit Sub
        End If



        Dim ShipName As String = Session("ship_Name")
        Dim shipCode As String = Session("ship_code")
        Dim userName As String = Session("user_Name")
        Dim userid As String = Session("user_id")
        'Dim uploadShipname As String = DropListLocation.SelectedItem.Text
        'Dim kindCsv As Integer

        If drpTaskUpload.SelectedItem.Value = "201" Then
            Dim colsData() As String

            Dim textLines As New List(Of String())
            Dim strArr()() As String
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
                If drpPriceType.SelectedItem.Value = "3" Then
                    If columnData.Length < 6 Then
                        Call showMsg("Status:  Required Columns (6) Not Provided In CSV File!!! Column1: " & columnData(0) & "  Column2: " & columnData(1) & "  Column3: " & columnData(2), "")
                        'lblStatusText.Text = "<br><br>Execution Result: <br> <font color=red>File Not Uploaded!!!</font>"
                        Exit Sub

                    End If
                Else
                    If columnData.Length < 5 Then
                        Call showMsg("Status:  Required Columns (5) Not Provided In CSV File!!! Column1: " & columnData(0) & "  Column2: " & columnData(1) & "  Column3: " & columnData(2), "")
                        'lblStatusText.Text = "<br><br>Execution Result: <br> <font color=red>File Not Uploaded!!!</font>"
                        Exit Sub

                    End If
                End If
                    textLines.Add(columnData)
            End While
            strArr = textLines.ToArray

            Dim _ApplePriceModel As ApplePriceModel = New ApplePriceModel()
            Dim _ApplePriceControl As ApplePriceControl = New ApplePriceControl()
            _ApplePriceModel.UPDPG = "ApplePartPrice.aspx"
            _ApplePriceModel.FileName = strFileName
            _ApplePriceModel.SrcFileName = fileName
            _ApplePriceModel.UserId = userid
            _ApplePriceModel.UserName = userName
            _ApplePriceModel.ShipToBranchCode = shipCode '"999999999"
            _ApplePriceModel.ShipToBranch = ShipName  'ASP1
            _ApplePriceModel.PriceOption = drpPriceOption.SelectedItem.Text
            _ApplePriceModel.PriceType = drpPriceType.SelectedItem.Text


            Dim blStatus As String = _ApplePriceControl.AddModifyPriceUpdate(strArr, _ApplePriceModel)

            If Left(blStatus, 1) = 0 Then
                Call showMsg("Status: Upload Success  The file has been uploaded. " & blStatus, "")
                Exit Sub
            Else
                Call showMsg("Status:  Upload Failed   Please check the content of file " & blStatus, "")
                Exit Sub
            End If

            ''If Error Raised then show the errors
            'If Not blStatus Then
            '    Call showMsg("Status:  Upload Failed   Please check the content of file ", "")
            '    'lblStatusText.Text = "Status: <font color=red> Upload Failed   Please check the content of file </font> "
            '    Exit Sub
            'Else
            '    Call showMsg("Status: Upload Success  The file has been uploaded", "")
            '    'lblStatusText.Text = "Status: <font color=green>Upload Success  The file has been uploaded</font>"
            'End If

        End If


    End Sub
    Protected Overrides Sub InitializeCulture()
        'Dim ci As CultureInfo = New CultureInfo("en-IN")
        'ci.NumberFormat.CurrencySymbol = "₹"
        'Thread.CurrentThread.CurrentCulture = ci
        'MyBase.InitializeCulture()
    End Sub

    Protected Sub showMsg(ByVal Msg As String, ByVal msgChk As String)

        lblMsg.Text = Msg
        Dim sScript As String

        If msgChk = "CancelMsg" Then
            'OKとキャンセルボタン
            sScript = "$(function () {$(""#dialog"" ).dialog({width: 400,buttons:{""OK"": function () {$(this).dialog('close');$('[id$=""BtnOK""]').click();},""CANCEL"": function () {$(this).dialog('close');$('[id$=""BtnCancel""]').click();}}});});"
        Else
            'OKボタンのみ
            sScript = "$(function () { $( ""#dialog"" ).dialog({width: 400, buttons: {""OK"": function () {$(this).dialog('close');}}});});"
        End If

        'JavaScriptの埋め込み
        ClientScript.RegisterStartupScript(Me.GetType(), "startup", sScript, True)

    End Sub

    ''' <summary>
    ''' Loading All branches
    ''' </summary>
    Private Sub InitDropDownList()
        Log4NetControl.ComInfoLogWrite(Session("UserName"))
        Dim userName As String = Session("user_id") 'Session("user_Name")
        'Clear the branch location
        DropListLocation.Items.Clear()
        'For store the branch codes in array
        Dim shipCodeAll() As String
        'Verify entered user and password correct or not with the database
        Dim _UserInfoModel As UserInfoModel = New UserInfoModel()
        Dim _UserInfoControl As UserInfoControl = New UserInfoControl()
        _UserInfoModel.UserId = userName
        '_UserInfoModel.Password = TextPass.Text.ToString().Trim()
        Dim UserInfoList As List(Of UserInfoModel) = _UserInfoControl.SelectUserInfo(_UserInfoModel)
        'User Doesn't exist
        If UserInfoList Is Nothing OrElse UserInfoList.Count = 0 Then
            Call showMsg("The username / password incorrect. Please try again", "")
            Exit Sub
        End If
        'Loading All Branch Codes and stored in a array for the session
        Dim _ShipBaseControl As ShipBaseControl = New ShipBaseControl()
        Dim dt As DataTable = _ShipBaseControl.SelectBranchCode()
        ReDim shipCodeAll(dt.Rows.Count - 1)
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            If dr("ship_code") IsNot DBNull.Value Then
                shipCodeAll(i) = dr("ship_code")
            End If
            i = i + 1
        Next
        Log4NetControl.ComInfoLogWrite(Session("UserName"))
        Dim codeMasterControl As CodeMasterControl = New CodeMasterControl()
        'QryFlag 
        'QryFlag 1 - # Specific Filter
        'QryFlag 2 - # All records
        Dim QryFlag As Integer = 1 'Specific Records
        If (UserInfoList(0).UserLevel = CommonConst.UserLevel0) Or
                        (UserInfoList(0).UserLevel = CommonConst.UserLevel1) Or
                        (UserInfoList(0).UserLevel = CommonConst.UserLevel2) Or
                (UserInfoList(0).AdminFlg = True) Then
            QryFlag = 2
        End If
        Dim codeMasterList As List(Of CodeMasterModel) = codeMasterControl.SelectBranchMasterApple(QryFlag, "'" & UserInfoList(0).Ship1.Replace(",", "','") & "'")

        ' Dim codeMasterControl As CodeMasterControl = New CodeMasterControl()
        'Loading branch name and code in the dropdown list
        '  Dim codeMasterList As List(Of CodeMasterModel) = codeMasterControl.SelectBranchMaster()
        Dim codeMaster1 As CodeMasterModel = New CodeMasterModel()
        codeMaster1.CodeValue = "Select Branch"
        codeMaster1.CodeDispValue = "Select Branch"
        codeMasterList.Insert(0, codeMaster1)
        Dim codeMaster2 As CodeMasterModel = New CodeMasterModel()
        '''''codeMaster2.CodeValue = "ALL"
        '''''codeMaster2.CodeDispValue = "ALL"
        '''''codeMasterList.Insert(1, codeMaster2)

        Me.DropListLocation.DataSource = codeMasterList
        Me.DropListLocation.DataTextField = "CodeDispValue"
        Me.DropListLocation.DataValueField = "CodeValue"
        Me.DropListLocation.DataBind()
    End Sub



End Class