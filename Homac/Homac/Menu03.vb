Public Class Menu03
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim waitDlg As WaitDialog   '進行状況フォームクラス 

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1 As New DataSet
    Dim DtView1, WK_DtView1 As DataView

    Dim strSQL, Err_F, CX_F, WK_str, strDATA(31) As String
    Dim i, j, pos, len As Long

    Dim BR_Key1, BR_Key2, kome As String
    Dim sum(5), cnt, sel1(5), sel2(5), aka_p As Integer
    Dim sumA(5), sumB(5), sumC(5), sumD(5), sumE(5), sumF(5), sumG(5), sumH(5), sumI(5) As Integer

    Dim file_name, dir As String
    'Dim P_DATE As Date VJ 2020/09/09
    Dim P_DATE As String

    '2014/05/08 消費税対策 start
    Private noTaxPrchPrice As Decimal       '税抜商品価格
    '2014/05/08 消費税対策 end

    Dim WK_amt1, WK_amt2, WK_amt3 As Integer

#Region " Windows フォーム デザイナで生成されたコード "

    Public Sub New()
        MyBase.New()

        ' この呼び出しは Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。

    End Sub

    ' Form は、コンポーネント一覧に後処理を実行するために dispose をオーバーライドします。
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    ' メモ : 以下のプロシージャは、Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使って変更してください。  
    ' コード エディタを使って変更しないでください。
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Date1 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Button2 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Menu03))
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button98 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Date1 = New GrapeCity.Win.Input.Interop.Date
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.Button2 = New System.Windows.Forms.Button
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(32, 72)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(160, 44)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "総括表"
        '
        'Button98
        '
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(220, 196)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(160, 44)
        Me.Button98.TabIndex = 11
        Me.Button98.Text = "戻る"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(24, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 24)
        Me.Label1.TabIndex = 123
        Me.Label1.Text = "処理年月"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date1
        '
        Me.Date1.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyy/MM", "", "")
        Me.Date1.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date1.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date1.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyy/MM", "", "")
        Me.Date1.Location = New System.Drawing.Point(100, 20)
        Me.Date1.Name = "Date1"
        Me.Date1.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date1.Size = New System.Drawing.Size(72, 24)
        Me.Date1.TabIndex = 122
        Me.Date1.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date1.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Date1.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2010, 2, 8, 12, 17, 22, 0))
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Location = New System.Drawing.Point(32, 132)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(160, 44)
        Me.Button2.TabIndex = 124
        Me.Button2.Text = "長期安心保証データ"
        '
        'Menu03
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(418, 271)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Date1)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.Button1)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Menu03"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Homac レポート"
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    '** 起動時
    '******************************************************************
    Private Sub Menu03_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call inz()      '** 初期処理
    End Sub

    '********************************************************************
    '** 初期処理
    '********************************************************************
    Sub inz()
        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        dir = System.IO.Directory.GetCurrentDirectory

        WK_DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("SELECT close_date FROM WRN_SUB ORDER BY close_date DESC", cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(WK_DsList1, "close_date")
        DB_CLOSE()
        WK_DtView1 = New DataView(WK_DsList1.Tables("close_date"), "", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then
            Date1.Text = Format(WK_DtView1(0)("close_date"), "yyyy/MM")
        Else
            Date1.Text = Format(Now, "yyyy/MM")
        End If

    End Sub

    Sub F_chk2()
        Err_F = "0"

        If Date1.Number = 0 Then
            MsgBox("処理年月は入力必須です。", 16, "Error")    '× 1=ＯＫ
            Date1.Focus()
            Err_F = "1" : Exit Sub
        End If
        P_DATE = Date1.Text & "/01" 'VJ 2020/09/09
        'P_DATE = "01/06/2020"
        WK_DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("SELECT close_date FROM WRN_SUB WHERE (close_date = CONVERT(DATETIME, '" & P_DATE & "', 102))", cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(WK_DsList1, "sals")
        DB_CLOSE()
        WK_DtView1 = New DataView(WK_DsList1.Tables("sals"), "", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count = 0 Then
            MsgBox("処理年月は未取込みです。", 16, "Error")    '× 1=ＯＫ
            Date1.Focus()
            Err_F = "1" : Exit Sub
        End If

    End Sub

    '******************************************************************
    '** 総括表
    '******************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor

        F_chk2()
        If Err_F = "0" Then

            For i = 0 To 5
                sel1(i) = 0 : sel2(i) = 0
                sumA(i) = 0 : sumB(i) = 0 : sumC(i) = 0 : sumD(i) = 0 : sumE(i) = 0 : sumF(i) = 0 : sumG(i) = 0 : sumH(i) = 0 : sumI(i) = 0
            Next

            file_name = dir & "\Homac総括表.xls"
            If System.IO.File.Exists(file_name) = False Then
                file_name = file_name & "x"
            End If

            DB_OPEN()

            Dim oExcel As Object
            Dim oBook As Object
            Dim oSheet As Object
            oExcel = CreateObject("Excel.Application")
            oBook = oExcel.Workbooks.Open(filename:=file_name)

            '***************
            '** 総括表
            '***************
            oSheet = oBook.Worksheets(1)

            DsList1.Clear()
            SqlCmd1 = New SqlClient.SqlCommand("sp_soukatsu_list", cnsqlclient)
            SqlCmd1.CommandType = CommandType.StoredProcedure
            Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
            Pram1.Value = P_DATE
            DaList1.SelectCommand = SqlCmd1
            DaList1.Fill(DsList1, "sp_soukatsu_list")
            DtView1 = New DataView(DsList1.Tables("sp_soukatsu_list"), "", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then

                '進行状況ダイアログの初期化処理()
                waitDlg = New WaitDialog        '進行状況ダイアログ
                waitDlg.Owner = Me              'ダイアログのオーナーを設定する
                waitDlg.ProgressMax = 0         '全体の処理件数を設定
                waitDlg.ProgressMin = 0         '処理件数の最小値を設定（0件から開始）
                waitDlg.ProgressStep = 1        '何件ごとにメータを進めるかを設定
                waitDlg.ProgressValue = 0       '最初の件数を設定
                Me.Enabled = False              'オーナーのフォームを無効にする
                waitDlg.Show()                  '進行状況ダイアログを表示する
                waitDlg.MainMsg = "総括表抽出中"
                waitDlg.ProgressMax = DtView1.Count ' 全体の処理件数を設定
                Application.DoEvents()              'メッセージ処理を促して表示を更新する

                BR_Key1 = DtView1(0)("shop_code")
                BR_Key2 = DtView1(0)("item_code")
                j = 1

                For i = 0 To DtView1.Count - 1

                    waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
                    Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                    waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                    If BR_Key1 <> DtView1(i)("shop_code") _
                        Or BR_Key2 <> DtView1(i)("item_code") Then

                        j = j + 1
                        oSheet.Range("A" & j).Value = DtView1(i - 1)("shop_code")
                        oSheet.Range("B" & j).Value = DtView1(i - 1)("shop_name")
                        oSheet.Range("C" & j).Value = DtView1(i - 1)("item_name")
                        oSheet.Range("D" & j).Value = cnt
                        oSheet.Range("E" & j).Value = sum(1)
                        oSheet.Range("F" & j).Value = sum(2)
                        oSheet.Range("G" & j).Value = sum(3)
                        oSheet.Range("H" & j).Value = sum(4)
                        oSheet.Range("I" & j).Value = sum(5)
                        If kome = "1" Then
                            oSheet.Range("J" & j).Value = "*"
                        End If
                        'If DtView1(i - 1)("fee_kbn") = "A" Then
                        '    oSheet.Range("K" & j).Value = cel(27 + cal)
                        'Else
                        oSheet.Range("K" & j).Value = DtView1(i - 1)("fee_kbn")
                        'End If

                        BR_Key1 = DtView1(i)("shop_code")
                        BR_Key2 = DtView1(i)("item_code")
                        cnt = 0 : sum(1) = 0 : sum(2) = 0 : sum(3) = 0 : sum(4) = 0 : sum(5) = 0
                        kome = "0"

                    End If
                    cnt = cnt + 1
                    sum(1) = sum(1) + DtView1(i)("prch_price")
                    sum(2) = sum(2) + DtView1(i)("wrn_fee")

                    '2014/05/08 消費税対策 start
                    '税抜商品価格の取得
                    noTaxPrchPrice = GetNoTaxPrchPrice(DtView1(i)("prch_price"), DtView1(i)("input_date"))
                    '                    If DtView1(i)("prch_price") < 15750 And DtView1(i)("prch_price") > -15750 Then
                    If noTaxPrchPrice < 15000 And noTaxPrchPrice > -15000 Then
                        kome = "1"
                    End If

                    Select Case DtView1(i)("fee_kbn")
                        Case Is = "A", "B"
                            '                            Select Case DtView1(i)("prch_price")
                            '                                Case Is <= -15750
                            '税抜商品価格で各手数料を算出
                            Select Case noTaxPrchPrice
                                Case Is <= -15000

                                    If (DtView1(i)("close_date") < CDate("01/03/2021")) Then 'code added by sabeena

                                        sum(3) = sum(3) + RoundDOWN(DtView1(i)("prch_price") * 0.013, 0)
                                        sum(4) = sum(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.013, 0))
                                        sum(5) = sum(5) + RoundDOWN(DtView1(i)("prch_price") * 0.012, 0)

                                        sel1(0) = sel1(0) + 1
                                        sel1(1) = sel1(1) + DtView1(i)("prch_price")
                                        sel1(2) = sel1(2) + DtView1(i)("wrn_fee")
                                        sel1(3) = sel1(3) + RoundDOWN(DtView1(i)("prch_price") * 0.013, 0)
                                        sel1(4) = sel1(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.013, 0))
                                        sel1(5) = sel1(5) + RoundDOWN(DtView1(i)("prch_price") * 0.012, 0)


                                        sumB(0) = sumB(0) + 1
                                        sumB(1) = sumB(1) + DtView1(i)("prch_price")
                                        sumB(2) = sumB(2) + DtView1(i)("wrn_fee")
                                        sumB(3) = sumB(3) + RoundDOWN(DtView1(i)("prch_price") * 0.013, 0)
                                        sumB(4) = sumB(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.013, 0))
                                        sumB(5) = sumB(5) + RoundDOWN(DtView1(i)("prch_price") * 0.012, 0)
                                        'code added by sabeena starts
                                    Else
                                        sum(3) = sum(3) + RoundDOWN(DtView1(i)("prch_price") * 0.013, 0)
                                        sum(4) = sum(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.013, 0))
                                        sum(5) = sum(5) + RoundDOWN(DtView1(i)("prch_price") * 0.011, 0)

                                        sel1(0) = sel1(0) + 1
                                        sel1(1) = sel1(1) + DtView1(i)("prch_price")
                                        sel1(2) = sel1(2) + DtView1(i)("wrn_fee")
                                        sel1(3) = sel1(3) + RoundDOWN(DtView1(i)("prch_price") * 0.013, 0)
                                        sel1(4) = sel1(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.013, 0))
                                        sel1(5) = sel1(5) + RoundDOWN(DtView1(i)("prch_price") * 0.011, 0)


                                        sumB(0) = sumB(0) + 1
                                        sumB(1) = sumB(1) + DtView1(i)("prch_price")
                                        sumB(2) = sumB(2) + DtView1(i)("wrn_fee")
                                        sumB(3) = sumB(3) + RoundDOWN(DtView1(i)("prch_price") * 0.013, 0)
                                        sumB(4) = sumB(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.013, 0))
                                        sumB(5) = sumB(5) + RoundDOWN(DtView1(i)("prch_price") * 0.011, 0)
                                    End If
                                    'code added by sabeena ends
                                Case Is < 0
                                    If (DtView1(i)("close_date") < CDate("01/03/2021")) Then 'code added by sabeena

                                        sum(3) = sum(3) + RoundDOWN(DtView1(i)("prch_price") * 0.006, 0)
                                        sum(4) = sum(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.006, 0))
                                        sum(5) = sum(5) + RoundDOWN(DtView1(i)("prch_price") * 0.012, 0)

                                        sel1(0) = sel1(0) + 1
                                        sel1(1) = sel1(1) + DtView1(i)("prch_price")
                                        sel1(2) = sel1(2) + DtView1(i)("wrn_fee")
                                        sel1(3) = sel1(3) + RoundDOWN(DtView1(i)("prch_price") * 0.006, 0)
                                        sel1(4) = sel1(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.006, 0))
                                        sel1(5) = sel1(5) + RoundDOWN(DtView1(i)("prch_price") * 0.012, 0)


                                        sumA(0) = sumA(0) + 1
                                        sumA(1) = sumA(1) + DtView1(i)("prch_price")
                                        sumA(2) = sumA(2) + DtView1(i)("wrn_fee")
                                        sumA(3) = sumA(3) + RoundDOWN(DtView1(i)("prch_price") * 0.006, 0)
                                        sumA(4) = sumA(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.006, 0))
                                        sumA(5) = sumA(5) + RoundDOWN(DtView1(i)("prch_price") * 0.012, 0)

                                        'code added by sabeena starts '                                Case Is >= 15750
                                    Else

                                        sum(3) = sum(3) + RoundDOWN(DtView1(i)("prch_price") * 0.008, 0)
                                        sum(4) = sum(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.008, 0))
                                        sum(5) = sum(5) + RoundDOWN(DtView1(i)("prch_price") * 0.011, 0)

                                        sel1(0) = sel1(0) + 1
                                        sel1(1) = sel1(1) + DtView1(i)("prch_price")
                                        sel1(2) = sel1(2) + DtView1(i)("wrn_fee")
                                        sel1(3) = sel1(3) + RoundDOWN(DtView1(i)("prch_price") * 0.008, 0)
                                        sel1(4) = sel1(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.008, 0))
                                        sel1(5) = sel1(5) + RoundDOWN(DtView1(i)("prch_price") * 0.011, 0)


                                        sumA(0) = sumA(0) + 1
                                        sumA(1) = sumA(1) + DtView1(i)("prch_price")
                                        sumA(2) = sumA(2) + DtView1(i)("wrn_fee")
                                        sumA(3) = sumA(3) + RoundDOWN(DtView1(i)("prch_price") * 0.008, 0)
                                        sumA(4) = sumA(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.008, 0))
                                        sumA(5) = sumA(5) + RoundDOWN(DtView1(i)("prch_price") * 0.011, 0)
                                    End If
                                    'code added by sabeena ends
                                Case Is >= 15000
                                    If (DtView1(i)("close_date") < CDate("01/03/2021")) Then 'code added by sabeena
                                        sum(3) = sum(3) + RoundDOWN(DtView1(i)("prch_price") * 0.013, 0)
                                        sum(4) = sum(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.013, 0))
                                        sum(5) = sum(5) + RoundDOWN(DtView1(i)("prch_price") * 0.012, 0)


                                        sel1(0) = sel1(0) + 1
                                        sel1(1) = sel1(1) + DtView1(i)("prch_price")
                                        sel1(2) = sel1(2) + DtView1(i)("wrn_fee")
                                        sel1(3) = sel1(3) + RoundDOWN(DtView1(i)("prch_price") * 0.013, 0)
                                        sel1(4) = sel1(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.013, 0))
                                        sel1(5) = sel1(5) + RoundDOWN(DtView1(i)("prch_price") * 0.012, 0)


                                        sumB(0) = sumB(0) + 1
                                        sumB(1) = sumB(1) + DtView1(i)("prch_price")
                                        sumB(2) = sumB(2) + DtView1(i)("wrn_fee")
                                        sumB(3) = sumB(3) + RoundDOWN(DtView1(i)("prch_price") * 0.013, 0)
                                        sumB(4) = sumB(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.013, 0))
                                        sumB(5) = sumB(5) + RoundDOWN(DtView1(i)("prch_price") * 0.012, 0)
                                        'code added by sabeena starts
                                    Else
                                        sum(3) = sum(3) + RoundDOWN(DtView1(i)("prch_price") * 0.013, 0)
                                        sum(4) = sum(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.013, 0))
                                        sum(5) = sum(5) + RoundDOWN(DtView1(i)("prch_price") * 0.011, 0)


                                        sel1(0) = sel1(0) + 1
                                        sel1(1) = sel1(1) + DtView1(i)("prch_price")
                                        sel1(2) = sel1(2) + DtView1(i)("wrn_fee")
                                        sel1(3) = sel1(3) + RoundDOWN(DtView1(i)("prch_price") * 0.013, 0)
                                        sel1(4) = sel1(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.013, 0))
                                        sel1(5) = sel1(5) + RoundDOWN(DtView1(i)("prch_price") * 0.011, 0)


                                        sumB(0) = sumB(0) + 1
                                        sumB(1) = sumB(1) + DtView1(i)("prch_price")
                                        sumB(2) = sumB(2) + DtView1(i)("wrn_fee")
                                        sumB(3) = sumB(3) + RoundDOWN(DtView1(i)("prch_price") * 0.013, 0)
                                        sumB(4) = sumB(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.013, 0))
                                        sumB(5) = sumB(5) + RoundDOWN(DtView1(i)("prch_price") * 0.011, 0)
                                    End If
                                    'code added by sabeena ends
                                Case Else
                                    If (DtView1(i)("close_date") < CDate("01/03/2021")) Then 'code added by sabeena
                                        sum(3) = sum(3) + RoundDOWN(DtView1(i)("prch_price") * 0.006, 0)
                                        sum(4) = sum(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.006, 0))
                                        sum(5) = sum(5) + RoundDOWN(DtView1(i)("prch_price") * 0.012, 0)

                                        sel1(0) = sel1(0) + 1
                                        sel1(1) = sel1(1) + DtView1(i)("prch_price")
                                        sel1(2) = sel1(2) + DtView1(i)("wrn_fee")
                                        sel1(3) = sel1(3) + RoundDOWN(DtView1(i)("prch_price") * 0.006, 0)
                                        sel1(4) = sel1(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.006, 0))
                                        sel1(5) = sel1(5) + RoundDOWN(DtView1(i)("prch_price") * 0.012, 0)

                                        sumA(0) = sumA(0) + 1
                                        sumA(1) = sumA(1) + DtView1(i)("prch_price")
                                        sumA(2) = sumA(2) + DtView1(i)("wrn_fee")
                                        sumA(3) = sumA(3) + RoundDOWN(DtView1(i)("prch_price") * 0.006, 0)
                                        sumA(4) = sumA(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.006, 0))
                                        sumA(5) = sumA(5) + RoundDOWN(DtView1(i)("prch_price") * 0.012, 0)
                                        'code added by sabeena starts
                                    Else
                                        sum(3) = sum(3) + RoundDOWN(DtView1(i)("prch_price") * 0.008, 0)
                                        sum(4) = sum(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.008, 0))
                                        sum(5) = sum(5) + RoundDOWN(DtView1(i)("prch_price") * 0.011, 0)

                                        sel1(0) = sel1(0) + 1
                                        sel1(1) = sel1(1) + DtView1(i)("prch_price")
                                        sel1(2) = sel1(2) + DtView1(i)("wrn_fee")
                                        sel1(3) = sel1(3) + RoundDOWN(DtView1(i)("prch_price") * 0.008, 0)
                                        sel1(4) = sel1(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.008, 0))
                                        sel1(5) = sel1(5) + RoundDOWN(DtView1(i)("prch_price") * 0.011, 0)

                                        sumA(0) = sumA(0) + 1
                                        sumA(1) = sumA(1) + DtView1(i)("prch_price")
                                        sumA(2) = sumA(2) + DtView1(i)("wrn_fee")
                                        sumA(3) = sumA(3) + RoundDOWN(DtView1(i)("prch_price") * 0.008, 0)
                                        sumA(4) = sumA(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.008, 0))
                                        sumA(5) = sumA(5) + RoundDOWN(DtView1(i)("prch_price") * 0.011, 0)
                                    End If
                                    'code added by sabeena ends
                            End Select

                        Case Is = "C"
                            If (DtView1(i)("close_date") < CDate("01/03/2021")) Then 'code added by sabeena
                                sum(3) = sum(3) + RoundDOWN(DtView1(i)("prch_price") * 0.003, 0)
                                sum(4) = sum(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.003, 0))
                                sum(5) = sum(5) + RoundDOWN(DtView1(i)("prch_price") * 0.012, 0)

                                sel1(0) = sel1(0) + 1
                                sel1(1) = sel1(1) + DtView1(i)("prch_price")
                                sel1(2) = sel1(2) + DtView1(i)("wrn_fee")
                                sel1(3) = sel1(3) + RoundDOWN(DtView1(i)("prch_price") * 0.003, 0)
                                sel1(4) = sel1(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.003, 0))
                                sel1(5) = sel1(5) + RoundDOWN(DtView1(i)("prch_price") * 0.012, 0)

                                sumC(0) = sumC(0) + 1
                                sumC(1) = sumC(1) + DtView1(i)("prch_price")
                                sumC(2) = sumC(2) + DtView1(i)("wrn_fee")
                                sumC(3) = sumC(3) + RoundDOWN(DtView1(i)("prch_price") * 0.003, 0)
                                sumC(4) = sumC(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.003, 0))
                                sumC(5) = sumC(5) + RoundDOWN(DtView1(i)("prch_price") * 0.012, 0)
                            Else
                                'code added by sabeena starts
                                sum(3) = sum(3) + RoundDOWN(DtView1(i)("prch_price") * 0.006, 0)
                                sum(4) = sum(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.006, 0))
                                sum(5) = sum(5) + RoundDOWN(DtView1(i)("prch_price") * 0.011, 0)

                                sel1(0) = sel1(0) + 1
                                sel1(1) = sel1(1) + DtView1(i)("prch_price")
                                sel1(2) = sel1(2) + DtView1(i)("wrn_fee")
                                sel1(3) = sel1(3) + RoundDOWN(DtView1(i)("prch_price") * 0.006, 0)
                                sel1(4) = sel1(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.006, 0))
                                sel1(5) = sel1(5) + RoundDOWN(DtView1(i)("prch_price") * 0.011, 0)

                                sumC(0) = sumC(0) + 1
                                sumC(1) = sumC(1) + DtView1(i)("prch_price")
                                sumC(2) = sumC(2) + DtView1(i)("wrn_fee")
                                sumC(3) = sumC(3) + RoundDOWN(DtView1(i)("prch_price") * 0.006, 0)
                                sumC(4) = sumC(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.006, 0))
                                sumC(5) = sumC(5) + RoundDOWN(DtView1(i)("prch_price") * 0.011, 0)
                            End If
                            'code added by sabeena ends
                        Case Is = "D"
                            If (DtView1(i)("close_date") < CDate("01/03/2021")) Then 'code added by sabeena
                                sum(3) = sum(3) + RoundDOWN(DtView1(i)("prch_price") * 0.003, 0)
                                sum(4) = sum(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.003, 0))
                                sum(5) = sum(5) + RoundDOWN(DtView1(i)("prch_price") * 0.012, 0)

                                sel1(0) = sel1(0) + 1
                                sel1(1) = sel1(1) + DtView1(i)("prch_price")
                                sel1(2) = sel1(2) + DtView1(i)("wrn_fee")
                                sel1(3) = sel1(3) + RoundDOWN(DtView1(i)("prch_price") * 0.003, 0)
                                sel1(4) = sel1(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.003, 0))
                                sel1(5) = sel1(5) + RoundDOWN(DtView1(i)("prch_price") * 0.012, 0)

                                sumD(0) = sumD(0) + 1
                                sumD(1) = sumD(1) + DtView1(i)("prch_price")
                                sumD(2) = sumD(2) + DtView1(i)("wrn_fee")
                                sumD(3) = sumD(3) + RoundDOWN(DtView1(i)("prch_price") * 0.003, 0)
                                sumD(4) = sumD(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.003, 0))
                                sumD(5) = sumD(5) + RoundDOWN(DtView1(i)("prch_price") * 0.012, 0)
                                'code added by sabeena starts
                            Else
                                sum(3) = sum(3) + RoundDOWN(DtView1(i)("prch_price") * 0.006, 0)
                                sum(4) = sum(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.006, 0))
                                sum(5) = sum(5) + RoundDOWN(DtView1(i)("prch_price") * 0.011, 0)

                                sel1(0) = sel1(0) + 1
                                sel1(1) = sel1(1) + DtView1(i)("prch_price")
                                sel1(2) = sel1(2) + DtView1(i)("wrn_fee")
                                sel1(3) = sel1(3) + RoundDOWN(DtView1(i)("prch_price") * 0.006, 0)
                                sel1(4) = sel1(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.006, 0))
                                sel1(5) = sel1(5) + RoundDOWN(DtView1(i)("prch_price") * 0.011, 0)

                                sumD(0) = sumD(0) + 1
                                sumD(1) = sumD(1) + DtView1(i)("prch_price")
                                sumD(2) = sumD(2) + DtView1(i)("wrn_fee")
                                sumD(3) = sumD(3) + RoundDOWN(DtView1(i)("prch_price") * 0.006, 0)
                                sumD(4) = sumD(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.006, 0))
                                sumD(5) = sumD(5) + RoundDOWN(DtView1(i)("prch_price") * 0.011, 0)
                            End If
                            'code added by sabeena
                        Case Is = "E"
                            '                            sum(3) = sum(3) + 2300
                            '                            sum(4) = sum(4) + (DtView1(i)("wrn_fee") - 2300)
                            '                            sum(5) = sum(5) + 0
                            WK_amt1 = 2000 * 1.1
                            WK_amt2 = 800 * 1.1

                            sum(3) = sum(3) + WK_amt1
                            sum(4) = sum(4) + (DtView1(i)("wrn_fee") - WK_amt1)
                            sum(5) = sum(5) + WK_amt2

                            sel1(0) = sel1(0) + 1
                            sel1(1) = sel1(1) + DtView1(i)("prch_price")
                            sel1(2) = sel1(2) + DtView1(i)("wrn_fee")
                            '                            sel1(3) = sel1(3) + 2300
                            '                           sel1(4) = sel1(4) + (DtView1(i)("wrn_fee") - 2300)
                            '                            sel1(5) = sel1(5) + 0
                            sel1(3) = sel1(3) + WK_amt1
                            sel1(4) = sel1(4) + (DtView1(i)("wrn_fee") - WK_amt1)
                            sel1(5) = sel1(5) + WK_amt2

                            sumE(0) = sumE(0) + 1
                            sumE(1) = sumE(1) + DtView1(i)("prch_price")
                            sumE(2) = sumE(2) + DtView1(i)("wrn_fee")
                            '                            sumE(3) = sumE(3) + 2300
                            '                            sumE(4) = sumE(4) + (DtView1(i)("wrn_fee") - 2300)
                            '                            sumE(5) = sumE(5) + 0
                            sumE(3) = sumE(3) + WK_amt1
                            sumE(4) = sumE(4) + (DtView1(i)("wrn_fee") - WK_amt1)
                            sumE(5) = sumE(5) + WK_amt2

                        Case Is = "F"
                            '                            sum(3) = sum(3) + 2800
                            '                            sum(4) = sum(4) + (DtView1(i)("wrn_fee") - 2800)
                            '                            sum(5) = sum(5) + 0
                            WK_amt1 = 2500 * 1.1
                            WK_amt2 = 800 * 1.1

                            sum(3) = sum(3) + WK_amt1
                            sum(4) = sum(4) + (DtView1(i)("wrn_fee") - WK_amt1)
                            sum(5) = sum(5) + WK_amt2

                            sel1(0) = sel1(0) + 1
                            sel1(1) = sel1(1) + DtView1(i)("prch_price")
                            sel1(2) = sel1(2) + DtView1(i)("wrn_fee")
                            '                            sel1(3) = sel1(3) + 2800
                            '                            sel1(4) = sel1(4) + (DtView1(i)("wrn_fee") - 2800)
                            '                            sel1(5) = sel1(5) + 0
                            sel1(3) = sel1(3) + WK_amt1
                            sel1(4) = sel1(4) + (DtView1(i)("wrn_fee") - WK_amt1)
                            sel1(5) = sel1(5) + WK_amt2

                            sumF(0) = sumF(0) + 1
                            sumF(1) = sumF(1) + DtView1(i)("prch_price")
                            sumF(2) = sumF(2) + DtView1(i)("wrn_fee")
                            '                            sumF(3) = sumF(3) + 2800
                            '                           sumF(4) = sumF(4) + (DtView1(i)("wrn_fee") - 2800)
                            '                            sumF(5) = sumF(5) + 0
                            sumF(3) = sumF(3) + WK_amt1
                            sumF(4) = sumF(4) + (DtView1(i)("wrn_fee") - WK_amt1)
                            sumF(5) = sumF(5) + WK_amt2

                        Case Is = "G"
                            '                            sum(3) = sum(3) + 1000
                            '                            sum(4) = sum(4) + (DtView1(i)("wrn_fee") - 1000)
                            '                            sum(5) = sum(5) + 1250
                            WK_amt1 = 1000 * 1.1
                            WK_amt2 = 1310

                            sum(3) = sum(3) + WK_amt1
                            sum(4) = sum(4) + (DtView1(i)("wrn_fee") - WK_amt1)
                            sum(5) = sum(5) + WK_amt2

                            sel1(0) = sel1(0) + 1
                            sel1(1) = sel1(1) + DtView1(i)("prch_price")
                            sel1(2) = sel1(2) + DtView1(i)("wrn_fee")
                            '                            sel1(3) = sel1(3) + 1000
                            '                            sel1(4) = sel1(4) + (DtView1(i)("wrn_fee") - 1000)
                            '                            sel1(5) = sel1(5) + 1250
                            sel1(3) = sel1(3) + WK_amt1
                            sel1(4) = sel1(4) + (DtView1(i)("wrn_fee") - WK_amt1)
                            sel1(5) = sel1(5) + WK_amt2

                            sumG(0) = sumG(0) + 1
                            sumG(1) = sumG(1) + DtView1(i)("prch_price")
                            sumG(2) = sumG(2) + DtView1(i)("wrn_fee")
                            '                            sumG(3) = sumG(3) + 1000
                            '                           sumG(4) = sumG(4) + (DtView1(i)("wrn_fee") - 1000)
                            '                           sumG(5) = sumG(5) + 1250
                            sumG(3) = sumG(3) + WK_amt1
                            sumG(4) = sumG(4) + (DtView1(i)("wrn_fee") - WK_amt1)
                            sumG(5) = sumG(5) + WK_amt2

                        Case Is = "H"
                            '                            sum(3) = sum(3) + 4300
                            '                           sum(4) = sum(4) + (DtView1(i)("wrn_fee") - 4300)
                            '                          sum(5) = sum(5) + 1875
                            WK_amt1 = 4500 * 1.1
                            WK_amt2 = 1964

                            sum(3) = sum(3) + WK_amt1
                            sum(4) = sum(4) + (DtView1(i)("wrn_fee") - WK_amt1)
                            sum(5) = sum(5) + WK_amt2

                            sel1(0) = sel1(0) + 1
                            sel1(1) = sel1(1) + DtView1(i)("prch_price")
                            sel1(2) = sel1(2) + DtView1(i)("wrn_fee")
                            '                            sel1(3) = sel1(3) + 4300
                            '                           sel1(4) = sel1(4) + (DtView1(i)("wrn_fee") - 4300)
                            '                          sel1(5) = sel1(5) + 1875
                            sel1(3) = sel1(3) + WK_amt1
                            sel1(4) = sel1(4) + (DtView1(i)("wrn_fee") - WK_amt1)
                            sel1(5) = sel1(5) + WK_amt2

                            sumH(0) = sumH(0) + 1
                            sumH(1) = sumH(1) + DtView1(i)("prch_price")
                            sumH(2) = sumH(2) + DtView1(i)("wrn_fee")
                            '                            sumH(3) = sumH(3) + 4300
                            '                           sumH(4) = sumH(4) + (DtView1(i)("wrn_fee") - 4300)
                            '                          sumH(5) = sumH(5) + 1875
                            sumH(3) = sumH(3) + WK_amt1
                            sumH(4) = sumH(4) + (DtView1(i)("wrn_fee") - WK_amt1)
                            sumH(5) = sumH(5) + WK_amt2

                        Case Is = "I"
                            '                            sum(3) = sum(3) + 1800
                            '                           sum(4) = sum(4) + (DtView1(i)("wrn_fee") - 1800)
                            '                          sum(5) = sum(5) + 1875
                            WK_amt1 = 1000 * 1.1
                            WK_amt2 = 1964

                            sum(3) = sum(3) + WK_amt1
                            sum(4) = sum(4) + (DtView1(i)("wrn_fee") - WK_amt1)
                            sum(5) = sum(5) + WK_amt2

                            sel1(0) = sel1(0) + 1
                            sel1(1) = sel1(1) + DtView1(i)("prch_price")
                            sel1(2) = sel1(2) + DtView1(i)("wrn_fee")
                            '                            sel1(3) = sel1(3) + 1800
                            '                           sel1(4) = sel1(4) + (DtView1(i)("wrn_fee") - 1800)
                            '                          sel1(5) = sel1(5) + 1875
                            sel1(3) = sel1(3) + WK_amt1
                            sel1(4) = sel1(4) + (DtView1(i)("wrn_fee") - WK_amt1)
                            sel1(5) = sel1(5) + WK_amt2

                            sumI(0) = sumI(0) + 1
                            sumI(1) = sumI(1) + DtView1(i)("prch_price")
                            sumI(2) = sumI(2) + DtView1(i)("wrn_fee")
                            '                            sumI(3) = sumI(3) + 1800
                            '                           sumI(4) = sumI(4) + (DtView1(i)("wrn_fee") - 1800)
                            '                          sumI(5) = sumI(5) + 1875
                            sumI(3) = sumI(3) + WK_amt1
                            sumI(4) = sumI(4) + (DtView1(i)("wrn_fee") - WK_amt1)
                            sumI(5) = sumI(5) + WK_amt2

                    End Select

                Next

                j = j + 1
                oSheet.Range("A" & j).Value = DtView1(i - 1)("shop_code")
                oSheet.Range("B" & j).Value = DtView1(i - 1)("shop_name")
                oSheet.Range("C" & j).Value = DtView1(i - 1)("item_name")
                oSheet.Range("D" & j).Value = cnt
                oSheet.Range("E" & j).Value = sum(1)
                oSheet.Range("F" & j).Value = sum(2)
                oSheet.Range("G" & j).Value = sum(3)
                oSheet.Range("H" & j).Value = sum(4)
                oSheet.Range("I" & j).Value = sum(5)
                If kome = "1" Then
                    oSheet.Range("J" & j).Value = "*"
                End If
                oSheet.Range("K" & j).Value = DtView1(i - 1)("fee_kbn")

                j = j + 1
                oSheet.Range("D" & j) = "=SUM(D2:D" & j - 1 & ")"
                oSheet.Range("E" & j) = "=SUM(E2:E" & j - 1 & ")"
                oSheet.Range("F" & j) = "=SUM(F2:F" & j - 1 & ")"
                oSheet.Range("G" & j) = "=SUM(G2:G" & j - 1 & ")"
                oSheet.Range("H" & j) = "=SUM(H2:H" & j - 1 & ")"
                oSheet.Range("I" & j) = "=SUM(I2:I" & j - 1 & ")"
                oSheet.Range("D" & j & ":" & "I" & j).Interior.Color = RGB(0, 255, 255)

                j = j + 2
                '                oSheet.Range("C" & j) = "15,750円未満"
                oSheet.Range("C" & j) = "税抜15,000円未満"
                oSheet.Range("D" & j) = sel1(0)
                oSheet.Range("E" & j) = sel1(1)
                oSheet.Range("F" & j) = sel1(2)
                oSheet.Range("G" & j) = sel1(3)
                oSheet.Range("H" & j) = sel1(4)
                oSheet.Range("I" & j) = sel1(5)
                oSheet.Range("C" & j & ":" & "I" & j).Interior.Color = RGB(255, 255, 128)

                j = j + 1
                '                oSheet.Range("C" & j) = "15,750円以上"
                oSheet.Range("C" & j) = "税抜15,000円以上"
                oSheet.Range("D" & j) = sel2(0)
                oSheet.Range("E" & j) = sel2(1)
                oSheet.Range("F" & j) = sel2(2)
                oSheet.Range("G" & j) = sel2(3)
                oSheet.Range("H" & j) = sel2(4)
                oSheet.Range("I" & j) = sel2(5)
                oSheet.Range("C" & j & ":" & "I" & j).Interior.Color = RGB(255, 255, 128)

            End If

            '区分別合計
            j = j + 3

            oSheet.Range("A" & j) = CInt(Format(CDate(Date1.Text & "/01"), "MM")) & "月 合計"
            oSheet.Range("C" & j) = "区分"
            oSheet.Range("D" & j) = "件数"
            oSheet.Range("E" & j) = "商品価格"
            oSheet.Range("F" & j) = "保証料"
            oSheet.Range("G" & j) = "販売手数料"
            oSheet.Range("H" & j) = "RDよりご請求額"
            oSheet.Range("I" & j) = "事務委託料"
            oSheet.Range("C" & j & ":" & "I" & j).Interior.Color = RGB(192, 255, 255)

            j = j + 1
            oSheet.Range("C" & j) = "A"
            oSheet.Range("D" & j) = sumA(0)
            oSheet.Range("E" & j) = sumA(1)
            oSheet.Range("F" & j) = sumA(2)
            oSheet.Range("G" & j) = sumA(3)
            oSheet.Range("H" & j) = sumA(4)
            oSheet.Range("I" & j) = sumA(5)

            j = j + 1
            oSheet.Range("C" & j) = "B"
            oSheet.Range("D" & j) = sumB(0)
            oSheet.Range("E" & j) = sumB(1)
            oSheet.Range("F" & j) = sumB(2)
            oSheet.Range("G" & j) = sumB(3)
            oSheet.Range("H" & j) = sumB(4)
            oSheet.Range("I" & j) = sumB(5)

            j = j + 1
            oSheet.Range("C" & j) = "C"
            oSheet.Range("D" & j) = sumC(0)
            oSheet.Range("E" & j) = sumC(1)
            oSheet.Range("F" & j) = sumC(2)
            oSheet.Range("G" & j) = sumC(3)
            oSheet.Range("H" & j) = sumC(4)
            oSheet.Range("I" & j) = sumC(5)

            j = j + 1
            oSheet.Range("C" & j) = "D"
            oSheet.Range("D" & j) = sumD(0)
            oSheet.Range("E" & j) = sumD(1)
            oSheet.Range("F" & j) = sumD(2)
            oSheet.Range("G" & j) = sumD(3)
            oSheet.Range("H" & j) = sumD(4)
            oSheet.Range("I" & j) = sumD(5)

            j = j + 1
            oSheet.Range("C" & j) = "E"
            oSheet.Range("D" & j) = sumE(0)
            oSheet.Range("E" & j) = sumE(1)
            oSheet.Range("F" & j) = sumE(2)
            oSheet.Range("G" & j) = sumE(3)
            oSheet.Range("H" & j) = sumE(4)
            oSheet.Range("I" & j) = sumE(5)

            j = j + 1
            oSheet.Range("C" & j) = "F"
            oSheet.Range("D" & j) = sumF(0)
            oSheet.Range("E" & j) = sumF(1)
            oSheet.Range("F" & j) = sumF(2)
            oSheet.Range("G" & j) = sumF(3)
            oSheet.Range("H" & j) = sumF(4)
            oSheet.Range("I" & j) = sumF(5)

            j = j + 1
            oSheet.Range("C" & j) = "G"
            oSheet.Range("D" & j) = sumG(0)
            oSheet.Range("E" & j) = sumG(1)
            oSheet.Range("F" & j) = sumG(2)
            oSheet.Range("G" & j) = sumG(3)
            oSheet.Range("H" & j) = sumG(4)
            oSheet.Range("I" & j) = sumG(5)

            j = j + 1
            oSheet.Range("C" & j) = "H"
            oSheet.Range("D" & j) = sumH(0)
            oSheet.Range("E" & j) = sumH(1)
            oSheet.Range("F" & j) = sumH(2)
            oSheet.Range("G" & j) = sumH(3)
            oSheet.Range("H" & j) = sumH(4)
            oSheet.Range("I" & j) = sumH(5)

            j = j + 1
            oSheet.Range("C" & j) = "I"
            oSheet.Range("D" & j) = sumI(0)
            oSheet.Range("E" & j) = sumI(1)
            oSheet.Range("F" & j) = sumI(2)
            oSheet.Range("G" & j) = sumI(3)
            oSheet.Range("H" & j) = sumI(4)
            oSheet.Range("I" & j) = sumI(5)

            j = j + 1
            oSheet.Range("C" & j) = "合計"
            oSheet.Range("D" & j) = "=SUM(D" & j - 9 & ":D" & j - 1 & ")"
            oSheet.Range("E" & j) = "=SUM(E" & j - 9 & ":E" & j - 1 & ")"
            oSheet.Range("F" & j) = "=SUM(F" & j - 9 & ":F" & j - 1 & ")"
            oSheet.Range("G" & j) = "=SUM(G" & j - 9 & ":G" & j - 1 & ")"
            oSheet.Range("H" & j) = "=SUM(H" & j - 9 & ":H" & j - 1 & ")"
            oSheet.Range("I" & j) = "=SUM(I" & j - 9 & ":I" & j - 1 & ")"
            oSheet.Range("C" & j & ":" & "I" & j).Interior.Color = RGB(0, 255, 255)

            '@@@@@@@@@@@@
            cnt = 0 : sum(1) = 0 : sum(2) = 0 : sum(3) = 0 : sum(4) = 0 : sum(5) = 0
            sel1(0) = 0 : sel1(1) = 0 : sel1(2) = 0 : sel1(3) = 0 : sel1(4) = 0 : sel1(5) = 0
            sel2(0) = 0 : sel2(1) = 0 : sel2(2) = 0 : sel2(3) = 0 : sel2(4) = 0 : sel2(5) = 0

            j = j + 2
            oSheet.Range("A" & j) = "赤黒"

            DsList1.Clear()
            SqlCmd1 = New SqlClient.SqlCommand("sp_soukatsu_list_2", cnsqlclient)
            SqlCmd1.CommandType = CommandType.StoredProcedure
            Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
            Pram2.Value = P_DATE
            DaList1.SelectCommand = SqlCmd1
            DaList1.Fill(DsList1, "sp_soukatsu_list_2")
            DtView1 = New DataView(DsList1.Tables("sp_soukatsu_list_2"), "", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then

                'Uncomment VJ 2020/09/09
                ''進行状況ダイアログの初期化処理()
                waitDlg = New WaitDialog        '進行状況ダイアログ
                waitDlg.Owner = Me              'ダイアログのオーナーを設定する
                waitDlg.ProgressMax = 0         '全体の処理件数を設定
                waitDlg.ProgressMin = 0         '処理件数の最小値を設定（0件から開始）
                waitDlg.ProgressStep = 1        '何件ごとにメータを進めるかを設定
                waitDlg.ProgressValue = 0       '最初の件数を設定
                Me.Enabled = False              'オーナーのフォームを無効にする
                waitDlg.Show()                  '進行状況ダイアログを表示する
                waitDlg.MainMsg = "総括表抽出中(赤黒)"
                waitDlg.ProgressMax = DtView1.Count ' 全体の処理件数を設定
                Application.DoEvents()              'メッセージ処理を促して表示を更新する

                BR_Key1 = DtView1(0)("shop_code")
                BR_Key2 = DtView1(0)("item_code")
                aka_p = j + 1

                For i = 0 To DtView1.Count - 1

                    waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
                    Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                    waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                    If BR_Key1 <> DtView1(i)("shop_code") _
                        Or BR_Key2 <> DtView1(i)("item_code") Then

                        j = j + 1
                        oSheet.Range("A" & j).Value = DtView1(i - 1)("shop_code")
                        oSheet.Range("B" & j).Value = DtView1(i - 1)("shop_name")
                        oSheet.Range("C" & j).Value = DtView1(i - 1)("item_name")
                        oSheet.Range("D" & j).Value = cnt
                        oSheet.Range("E" & j).Value = sum(1)
                        oSheet.Range("F" & j).Value = sum(2)
                        oSheet.Range("G" & j).Value = sum(3)
                        oSheet.Range("H" & j).Value = sum(4)
                        oSheet.Range("I" & j).Value = sum(5)
                        If kome = "1" Then
                            oSheet.Range("J" & j).Value = "*"
                        End If

                        BR_Key1 = DtView1(i)("shop_code")
                        BR_Key2 = DtView1(i)("item_code")
                        cnt = 0 : sum(1) = 0 : sum(2) = 0 : sum(3) = 0 : sum(4) = 0 : sum(5) = 0
                        kome = "0"

                    End If
                    cnt = cnt + 1
                    sum(1) = sum(1) + DtView1(i)("prch_price")
                    sum(2) = sum(2) + DtView1(i)("wrn_fee")

                    '税抜商品価格の取得
                    noTaxPrchPrice = GetNoTaxPrchPrice(DtView1(i)("prch_price"), DtView1(i)("input_date"))
                    '                    If DtView1(i)("prch_price") < 15750 And DtView1(i)("prch_price") > -15750 Then
                    If noTaxPrchPrice < 15000 And noTaxPrchPrice > -15000 Then
                        kome = "1"
                    End If

                    Select Case DtView1(i)("fee_kbn")
                        Case Is = "A", "B"
                            '                            Select Case DtView1(i)("prch_price")
                            '                                Case Is <= -15750
                            Select Case noTaxPrchPrice
                                Case Is <= -15000
                                    If (DtView1(i)("close_date") < CDate("01/03/2021")) Then 'code added by sabeena
                                        sum(3) = sum(3) + RoundDOWN(DtView1(i)("prch_price") * 0.013, 0)
                                        sum(4) = sum(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.013, 0))
                                        sum(5) = sum(5) + RoundDOWN(DtView1(i)("prch_price") * 0.012, 0)

                                        sel1(0) = sel1(0) + 1
                                        sel1(1) = sel1(1) + DtView1(i)("prch_price")
                                        sel1(2) = sel1(2) + DtView1(i)("wrn_fee")
                                        sel1(3) = sel1(3) + RoundDOWN(DtView1(i)("prch_price") * 0.013, 0)
                                        sel1(4) = sel1(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.013, 0))
                                        sel1(5) = sel1(5) + RoundDOWN(DtView1(i)("prch_price") * 0.012, 0)
                                        'code added by sabeena starts
                                    Else
                                        sum(3) = sum(3) + RoundDOWN(DtView1(i)("prch_price") * 0.013, 0)
                                        sum(4) = sum(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.013, 0))
                                        sum(5) = sum(5) + RoundDOWN(DtView1(i)("prch_price") * 0.011, 0)

                                        sel1(0) = sel1(0) + 1
                                        sel1(1) = sel1(1) + DtView1(i)("prch_price")
                                        sel1(2) = sel1(2) + DtView1(i)("wrn_fee")
                                        sel1(3) = sel1(3) + RoundDOWN(DtView1(i)("prch_price") * 0.013, 0)
                                        sel1(4) = sel1(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.013, 0))
                                        sel1(5) = sel1(5) + RoundDOWN(DtView1(i)("prch_price") * 0.011, 0)
                                    End If
                                    'code added by sabeena ends
                                Case Is < 0
                                    If (DtView1(i)("close_date") < CDate("01/03/2021")) Then 'code added by sabeena
                                        sum(3) = sum(3) + RoundDOWN(DtView1(i)("prch_price") * 0.006, 0)
                                        sum(4) = sum(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.006, 0))
                                        sum(5) = sum(5) + RoundDOWN(DtView1(i)("prch_price") * 0.012, 0)

                                        sel1(0) = sel1(0) + 1
                                        sel1(1) = sel1(1) + DtView1(i)("prch_price")
                                        sel1(2) = sel1(2) + DtView1(i)("wrn_fee")
                                        sel1(3) = sel1(3) + RoundDOWN(DtView1(i)("prch_price") * 0.006, 0)
                                        sel1(4) = sel1(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.006, 0))
                                        sel1(5) = sel1(5) + RoundDOWN(DtView1(i)("prch_price") * 0.012, 0)
                                        'code added by sabeena starts
                                    Else
                                        sum(3) = sum(3) + RoundDOWN(DtView1(i)("prch_price") * 0.008, 0)
                                        sum(4) = sum(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.008, 0))
                                        sum(5) = sum(5) + RoundDOWN(DtView1(i)("prch_price") * 0.011, 0)

                                        sel1(0) = sel1(0) + 1
                                        sel1(1) = sel1(1) + DtView1(i)("prch_price")
                                        sel1(2) = sel1(2) + DtView1(i)("wrn_fee")
                                        sel1(3) = sel1(3) + RoundDOWN(DtView1(i)("prch_price") * 0.008, 0)
                                        sel1(4) = sel1(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.008, 0))
                                        sel1(5) = sel1(5) + RoundDOWN(DtView1(i)("prch_price") * 0.011, 0)
                                    End If
                                    'code added by sabeena ends
                                    '                                Case Is >= 15750
                                Case Is >= 15000
                                    If (DtView1(i)("close_date") < CDate("01/03/2021")) Then 'code added by sabeena
                                        sum(3) = sum(3) + RoundDOWN(DtView1(i)("prch_price") * 0.013, 0)
                                        sum(4) = sum(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.013, 0))
                                        sum(5) = sum(5) + RoundDOWN(DtView1(i)("prch_price") * 0.012, 0)

                                        sel1(0) = sel1(0) + 1
                                        sel1(1) = sel1(1) + DtView1(i)("prch_price")
                                        sel1(2) = sel1(2) + DtView1(i)("wrn_fee")
                                        sel1(3) = sel1(3) + RoundDOWN(DtView1(i)("prch_price") * 0.013, 0)
                                        sel1(4) = sel1(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.013, 0))
                                        sel1(5) = sel1(5) + RoundDOWN(DtView1(i)("prch_price") * 0.012, 0)
                                        'code added by sabeena starts
                                    Else
                                        sum(3) = sum(3) + RoundDOWN(DtView1(i)("prch_price") * 0.013, 0)
                                        sum(4) = sum(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.013, 0))
                                        sum(5) = sum(5) + RoundDOWN(DtView1(i)("prch_price") * 0.011, 0)

                                        sel1(0) = sel1(0) + 1
                                        sel1(1) = sel1(1) + DtView1(i)("prch_price")
                                        sel1(2) = sel1(2) + DtView1(i)("wrn_fee")
                                        sel1(3) = sel1(3) + RoundDOWN(DtView1(i)("prch_price") * 0.013, 0)
                                        sel1(4) = sel1(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.013, 0))
                                        sel1(5) = sel1(5) + RoundDOWN(DtView1(i)("prch_price") * 0.011, 0)
                                    End If
                                    'code added by sabeena ends
                                Case Else
                                    If (DtView1(i)("close_date") < CDate("01/03/2021")) Then 'code added by sabeena
                                        sum(3) = sum(3) + RoundDOWN(DtView1(i)("prch_price") * 0.006, 0)
                                        sum(4) = sum(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.006, 0))
                                        sum(5) = sum(5) + RoundDOWN(DtView1(i)("prch_price") * 0.012, 0)

                                        sel1(0) = sel1(0) + 1
                                        sel1(1) = sel1(1) + DtView1(i)("prch_price")
                                        sel1(2) = sel1(2) + DtView1(i)("wrn_fee")
                                        sel1(3) = sel1(3) + RoundDOWN(DtView1(i)("prch_price") * 0.006, 0)
                                        sel1(4) = sel1(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.006, 0))
                                        sel1(5) = sel1(5) + RoundDOWN(DtView1(i)("prch_price") * 0.012, 0)
                                        'code added by sabeena starts
                                    Else
                                        sum(3) = sum(3) + RoundDOWN(DtView1(i)("prch_price") * 0.008, 0)
                                        sum(4) = sum(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.008, 0))
                                        sum(5) = sum(5) + RoundDOWN(DtView1(i)("prch_price") * 0.011, 0)

                                        sel1(0) = sel1(0) + 1
                                        sel1(1) = sel1(1) + DtView1(i)("prch_price")
                                        sel1(2) = sel1(2) + DtView1(i)("wrn_fee")
                                        sel1(3) = sel1(3) + RoundDOWN(DtView1(i)("prch_price") * 0.008, 0)
                                        sel1(4) = sel1(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.008, 0))
                                        sel1(5) = sel1(5) + RoundDOWN(DtView1(i)("prch_price") * 0.011, 0)
                                    End If
                                    'code added by sabeena ends
                            End Select

                        Case Is = "C"
                            If (DtView1(i)("close_date") < CDate("01/03/2021")) Then 'code added by sabeena
                                sum(3) = sum(3) + RoundDOWN(DtView1(i)("prch_price") * 0.003, 0)
                                sum(4) = sum(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.003, 0))
                                sum(5) = sum(5) + RoundDOWN(DtView1(i)("prch_price") * 0.012, 0)

                                sel1(0) = sel1(0) + 1
                                sel1(1) = sel1(1) + DtView1(i)("prch_price")
                                sel1(2) = sel1(2) + DtView1(i)("wrn_fee")
                                sel1(3) = sel1(3) + RoundDOWN(DtView1(i)("prch_price") * 0.003, 0)
                                sel1(4) = sel1(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.003, 0))
                                sel1(5) = sel1(5) + RoundDOWN(DtView1(i)("prch_price") * 0.012, 0)
                                'code added by sabeena starts
                            Else
                                sum(3) = sum(3) + RoundDOWN(DtView1(i)("prch_price") * 0.006, 0)
                                sum(4) = sum(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.006, 0))
                                sum(5) = sum(5) + RoundDOWN(DtView1(i)("prch_price") * 0.011, 0)

                                sel1(0) = sel1(0) + 1
                                sel1(1) = sel1(1) + DtView1(i)("prch_price")
                                sel1(2) = sel1(2) + DtView1(i)("wrn_fee")
                                sel1(3) = sel1(3) + RoundDOWN(DtView1(i)("prch_price") * 0.003, 0)
                                sel1(4) = sel1(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.003, 0))
                                sel1(5) = sel1(5) + RoundDOWN(DtView1(i)("prch_price") * 0.011, 0)
                            End If
                            'code added by sabeena ends
                        Case Is = "D"
                            If (DtView1(i)("close_date") < CDate("01/03/2021")) Then 'code added by sabeena
                                sum(3) = sum(3) + RoundDOWN(DtView1(i)("prch_price") * 0.003, 0)
                                sum(4) = sum(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.003, 0))
                                sum(5) = sum(5) + RoundDOWN(DtView1(i)("prch_price") * 0.012, 0)

                                sel1(0) = sel1(0) + 1
                                sel1(1) = sel1(1) + DtView1(i)("prch_price")
                                sel1(2) = sel1(2) + DtView1(i)("wrn_fee")
                                sel1(3) = sel1(3) + RoundDOWN(DtView1(i)("prch_price") * 0.003, 0)
                                sel1(4) = sel1(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.003, 0))
                                sel1(5) = sel1(5) + RoundDOWN(DtView1(i)("prch_price") * 0.012, 0)
                                'code added by sabeena starts
                            Else
                                sum(3) = sum(3) + RoundDOWN(DtView1(i)("prch_price") * 0.006, 0)
                                sum(4) = sum(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.006, 0))
                                sum(5) = sum(5) + RoundDOWN(DtView1(i)("prch_price") * 0.011, 0)

                                sel1(0) = sel1(0) + 1
                                sel1(1) = sel1(1) + DtView1(i)("prch_price")
                                sel1(2) = sel1(2) + DtView1(i)("wrn_fee")
                                sel1(3) = sel1(3) + RoundDOWN(DtView1(i)("prch_price") * 0.006, 0)
                                sel1(4) = sel1(4) + (DtView1(i)("wrn_fee") - RoundDOWN(DtView1(i)("prch_price") * 0.006, 0))
                                sel1(5) = sel1(5) + RoundDOWN(DtView1(i)("prch_price") * 0.011, 0)
                            End If
                            'code added by sabeena ends
                        Case Is = "E"
                            '                            sum(3) = sum(3) + 2300
                            '                            sum(4) = sum(4) + (DtView1(i)("wrn_fee") - 2300)
                            '                            sum(5) = sum(5) + 0
                            WK_amt1 = 2000 * 1.1
                            WK_amt2 = 800 * 1.1

                            sum(3) = sum(3) + WK_amt1
                            sum(4) = sum(4) + (DtView1(i)("wrn_fee") - WK_amt1)
                            sum(5) = sum(5) + WK_amt2

                            sel1(0) = sel1(0) + 1
                            sel1(1) = sel1(1) + DtView1(i)("prch_price")
                            sel1(2) = sel1(2) + DtView1(i)("wrn_fee")
                            '                            sel1(3) = sel1(3) + 2300
                            '                            sel1(4) = sel1(4) + (DtView1(i)("wrn_fee") - 2300)
                            '                            sel1(5) = sel1(5) + 0
                            sel1(3) = sel1(3) + WK_amt1
                            sel1(4) = sel1(4) + (DtView1(i)("wrn_fee") - WK_amt1)
                            sel1(5) = sel1(5) + WK_amt2

                        Case Is = "F"
                            '                            sum(3) = sum(3) + 2800
                            '                            sum(4) = sum(4) + (DtView1(i)("wrn_fee") - 2800)
                            '                            sum(5) = sum(5) + 0
                            WK_amt1 = 2500 * 1.1
                            WK_amt2 = 800 * 1.1

                            sum(3) = sum(3) + WK_amt1
                            sum(4) = sum(4) + (DtView1(i)("wrn_fee") - WK_amt1)
                            sum(5) = sum(5) + WK_amt2

                            sel1(0) = sel1(0) + 1
                            sel1(1) = sel1(1) + DtView1(i)("prch_price")
                            sel1(2) = sel1(2) + DtView1(i)("wrn_fee")
                            '                            sel1(3) = sel1(3) + 2800
                            '                            sel1(4) = sel1(4) + (DtView1(i)("wrn_fee") - 2800)
                            '                            sel1(5) = sel1(5) + 0
                            sel1(3) = sel1(3) + WK_amt1
                            sel1(4) = sel1(4) + (DtView1(i)("wrn_fee") - WK_amt1)
                            sel1(5) = sel1(5) + WK_amt2

                        Case Is = "G"
                            '                            sum(3) = sum(3) + 1000
                            '                            sum(4) = sum(4) + (DtView1(i)("wrn_fee") - 1000)
                            '                           sum(5) = sum(5) + 1250
                            WK_amt1 = 1000 * 1.1
                            WK_amt2 = 1310

                            sum(3) = sum(3) + WK_amt1
                            sum(4) = sum(4) + (DtView1(i)("wrn_fee") - WK_amt1)
                            sum(5) = sum(5) + WK_amt2

                            sel1(0) = sel1(0) + 1
                            sel1(1) = sel1(1) + DtView1(i)("prch_price")
                            sel1(2) = sel1(2) + DtView1(i)("wrn_fee")
                            '                            sel1(3) = sel1(3) + 1000
                            '                            sel1(4) = sel1(4) + (DtView1(i)("wrn_fee") - 1000)
                            '                            sel1(5) = sel1(5) + 1250
                            sel1(3) = sel1(3) + WK_amt1
                            sel1(4) = sel1(4) + (DtView1(i)("wrn_fee") - WK_amt1)
                            sel1(5) = sel1(5) + WK_amt2

                        Case Is = "H"
                            '                            sum(3) = sum(3) + 4300
                            '                            sum(4) = sum(4) + (DtView1(i)("wrn_fee") - 4300)
                            '                            sum(5) = sum(5) + 1875
                            WK_amt1 = 4500 * 1.1
                            WK_amt2 = 1964

                            sum(3) = sum(3) + WK_amt1
                            sum(4) = sum(4) + (DtView1(i)("wrn_fee") - WK_amt1)
                            sum(5) = sum(5) + WK_amt2

                            sel1(0) = sel1(0) + 1
                            sel1(1) = sel1(1) + DtView1(i)("prch_price")
                            sel1(2) = sel1(2) + DtView1(i)("wrn_fee")
                            '                            sel1(3) = sel1(3) + 4300
                            '                            sel1(4) = sel1(4) + (DtView1(i)("wrn_fee") - 4300)
                            '                            sel1(5) = sel1(5) + 1875
                            sel1(3) = sel1(3) + WK_amt1
                            sel1(4) = sel1(4) + (DtView1(i)("wrn_fee") - WK_amt1)
                            sel1(5) = sel1(5) + WK_amt2

                        Case Is = "I"
                            '                            sum(3) = sum(3) + 1800
                            '                            sum(4) = sum(4) + (DtView1(i)("wrn_fee") - 1800)
                            '                            sum(5) = sum(5) + 1875
                            WK_amt1 = 1000 * 1.1
                            WK_amt2 = 1964

                            sum(3) = sum(3) + WK_amt1
                            sum(4) = sum(4) + (DtView1(i)("wrn_fee") - WK_amt1)
                            sum(5) = sum(5) + WK_amt2

                            sel1(0) = sel1(0) + 1
                            sel1(1) = sel1(1) + DtView1(i)("prch_price")
                            sel1(2) = sel1(2) + DtView1(i)("wrn_fee")
                            '                            sel1(3) = sel1(3) + 1800
                            '                            sel1(4) = sel1(4) + (DtView1(i)("wrn_fee") - 1800)
                            '                            sel1(5) = sel1(5) + 1875
                            sel1(3) = sel1(3) + WK_amt1
                            sel1(4) = sel1(4) + (DtView1(i)("wrn_fee") - WK_amt1)
                            sel1(5) = sel1(5) + WK_amt2

                    End Select

                Next

                j = j + 1
                oSheet.Range("A" & j).Value = DtView1(i - 1)("shop_code")
                oSheet.Range("B" & j).Value = DtView1(i - 1)("shop_name")
                oSheet.Range("C" & j).Value = DtView1(i - 1)("item_name")
                oSheet.Range("D" & j).Value = cnt
                oSheet.Range("E" & j).Value = sum(1)
                oSheet.Range("F" & j).Value = sum(2)
                oSheet.Range("G" & j).Value = sum(3)
                oSheet.Range("H" & j).Value = sum(4)
                oSheet.Range("I" & j).Value = sum(5)
                If kome = "1" Then
                    oSheet.Range("J" & j).Value = "*"
                End If

                j = j + 1
                oSheet.Range("D" & j) = "=SUM(D" & aka_p & ":D" & j - 1 & ")"
                oSheet.Range("E" & j) = "=SUM(E" & aka_p & ":E" & j - 1 & ")"
                oSheet.Range("F" & j) = "=SUM(F" & aka_p & ":F" & j - 1 & ")"
                oSheet.Range("G" & j) = "=SUM(G" & aka_p & ":G" & j - 1 & ")"
                oSheet.Range("H" & j) = "=SUM(H" & aka_p & ":H" & j - 1 & ")"
                oSheet.Range("I" & j) = "=SUM(I" & aka_p & ":I" & j - 1 & ")"
                oSheet.Range("D" & j & ":" & "I" & j).Interior.Color = RGB(0, 255, 255)

                j = j + 2
                '                oSheet.Range("C" & j) = "15,750円未満"
                oSheet.Range("C" & j) = "税抜15,000円未満"
                oSheet.Range("D" & j) = sel1(0)
                oSheet.Range("E" & j) = sel1(1)
                oSheet.Range("F" & j) = sel1(2)
                oSheet.Range("G" & j) = sel1(3)
                oSheet.Range("H" & j) = sel1(4)
                oSheet.Range("I" & j) = sel1(5)
                oSheet.Range("C" & j & ":" & "I" & j).Interior.Color = RGB(255, 255, 128)

                j = j + 1
                '                oSheet.Range("C" & j) = "15,750円以上"
                oSheet.Range("C" & j) = "税抜15,000円以上"
                oSheet.Range("D" & j) = sel2(0)
                oSheet.Range("E" & j) = sel2(1)
                oSheet.Range("F" & j) = sel2(2)
                oSheet.Range("G" & j) = sel2(3)
                oSheet.Range("H" & j) = sel2(4)
                oSheet.Range("I" & j) = sel2(5)
                oSheet.Range("C" & j & ":" & "I" & j).Interior.Color = RGB(255, 255, 128)

            End If

            '2014/05/08 消費税対策 end
            '@@@@@@@@@@@@

            '［名前を付けて保存］ダイアログボックスを表示
            'VJ 2020/09/09
            Dim PDATE As DateTime
            PDATE = DateTime.ParseExact(P_DATE, "yyyy/MM/dd", Nothing)
            SaveFileDialog1.FileName = "Homac総括表" & Format(PDATE, "yyyyMM") & ".xls"
            SaveFileDialog1.Filter = "Excelファイル|*.xls"
            SaveFileDialog1.OverwritePrompt = False
            If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                oBook.CheckCompatibility = False
                oBook.SaveAs(SaveFileDialog1.FileName)
                CX_F = "0"
            Else
                CX_F = "1"
            End If

            '==================  終了処理  =====================  
            oSheet = Nothing
            oBook = Nothing
            oExcel.Quit()
            oExcel = Nothing
            GC.Collect()

            If CX_F = "0" Then
                MessageBox.Show(SaveFileDialog1.FileName & " に出力しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Me.Activate()                   ' いったんオーナーをアクティブにする
            waitDlg.Close()                 ' 進行状況ダイアログを閉じる
            Me.Enabled = True

            DB_CLOSE()
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
err_prc:
        If Err.Number = 50290 Then
            MessageBox.Show("エクセル出力中に他のエクセルファイルを開く事は出来ません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Else
            MessageBox.Show(Err.Number & ":" & Err.Description, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If
        Me.Activate()                   ' いったんオーナーをアクティブにする
        waitDlg.Close()                 ' 進行状況ダイアログを閉じる
        Me.Enabled = True
        DB_CLOSE()

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub MRComObject(ByVal objXl As Object)
        'Excel 終了処理時のプロシージャ
        Try
            '提供されたランタイム呼び出し可能ラッパーの参照カウントをデクリメントします
            System.Runtime.InteropServices.Marshal.ReleaseComObject(objXl)
        Catch
        Finally
            objXl = Nothing
        End Try
    End Sub

    '******************************************************************
    '** 項目分割
    '******************************************************************
    Sub F_slct()

        WK_str = DtView1(i)("txt_data")
        pos = 1 : len = 15 : strDATA(1) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 2 : strDATA(2) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 40 : strDATA(3) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 40 : strDATA(4) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 11 : strDATA(5) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 40 : strDATA(6) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 40 : strDATA(7) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 11 : strDATA(8) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 7 : strDATA(9) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 80 : strDATA(10) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 80 : strDATA(11) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 80 : strDATA(12) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 2 : strDATA(13) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 10 : strDATA(14) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 40 : strDATA(15) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 3 : strDATA(16) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 3 : strDATA(17) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 3 : strDATA(18) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 3 : strDATA(19) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 1
        pos = pos + len : len = 13 : strDATA(20) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 9 : strDATA(21) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 30 : strDATA(22) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 30 : strDATA(23) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 13 : strDATA(24) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 8 : strDATA(25) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 2 : strDATA(26) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 6 : strDATA(27) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 4 : strDATA(28) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 10 : strDATA(29) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 60 : strDATA(30) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 8 : strDATA(31) = Trim(MidB(WK_str, pos, len))

    End Sub

    '******************************************************************
    '** 長期安心保証データ
    '******************************************************************
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim cel() As String = New String() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ"}
        Dim cal As Integer

        F_chk2()
        If Err_F = "0" Then

            If P_DATE < "2021/03/01" Then
                file_name = dir & "\Homac長期安心保証データ.xls"
            Else
                file_name = dir & "\Homac長期安心保証データ202103.xls"
            End If
            If System.IO.File.Exists(file_name) = False Then
                file_name = file_name & "x"
            End If

            DB_OPEN()

            Dim oExcel As Object
            Dim oBook As Object
            Dim oSheet As Object
            oExcel = CreateObject("Excel.Application")
            oBook = oExcel.Workbooks.Open(filename:=file_name)

            '***************
            '** 明細表
            '***************
            oSheet = oBook.Worksheets(1)

            DsList1.Clear()
            SqlCmd1 = New SqlClient.SqlCommand("sp_anshin_list", cnsqlclient)
            SqlCmd1.CommandType = CommandType.StoredProcedure
            Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
            Pram1.Value = P_DATE
            DaList1.SelectCommand = SqlCmd1
            DaList1.Fill(DsList1, "sp_anshin_list")
            DtView1 = New DataView(DsList1.Tables("sp_anshin_list"), "", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then

                '進行状況ダイアログの初期化処理()
                waitDlg = New WaitDialog        '進行状況ダイアログ
                waitDlg.Owner = Me              'ダイアログのオーナーを設定する
                waitDlg.ProgressMax = 0         '全体の処理件数を設定
                waitDlg.ProgressMin = 0         '処理件数の最小値を設定（0件から開始）
                waitDlg.ProgressStep = 1        '何件ごとにメータを進めるかを設定
                waitDlg.ProgressValue = 0       '最初の件数を設定
                Me.Enabled = False              'オーナーのフォームを無効にする
                waitDlg.Show()                  '進行状況ダイアログを表示する
                waitDlg.MainMsg = "長期安心保証データ抽出中"
                waitDlg.ProgressMax = DtView1.Count ' 全体の処理件数を設定
                Application.DoEvents()              'メッセージ処理を促して表示を更新する

                For i = 0 To DtView1.Count - 1

                    waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
                    Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                    waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                    j = i + 2
                    oSheet.Range("A" & j).Value = DtView1(i)("wrn_no")
                    If P_DATE < "2021/03/01" Then
                        cal = 0
                        If DtView1(i)("new_txt") = "1" Then
                            oSheet.Range("B" & j).Value = Mid(DtView1(i)("wrn_no"), 1, 4) & "-" & Mid(DtView1(i)("wrn_no"), 11, 5)
                        Else
                            oSheet.Range("B" & j).Value = Mid(DtView1(i)("wrn_no"), 7, 4) & "-" & Mid(DtView1(i)("wrn_no"), 11, 5)
                        End If
                    Else
                        cal = -1
                    End If
                    oSheet.Range(cel(2 + cal) & j).Value = DtView1(i)("line_no")
                    oSheet.Range(cel(3 + cal) & j).Value = DtView1(i)("user_name_KANA")
                    oSheet.Range(cel(4 + cal) & j).Value = DtView1(i)("user_name")
                    oSheet.Range(cel(5 + cal) & j).Value = DtView1(i)("user_tel_no")
                    oSheet.Range(cel(6 + cal) & j).Value = DtView1(i)("appl_name_KANA")
                    oSheet.Range(cel(7 + cal) & j).Value = DtView1(i)("appl_name")
                    oSheet.Range(cel(8 + cal) & j).Value = DtView1(i)("appl_tel_no")
                    oSheet.Range(cel(9 + cal) & j).Value = DtView1(i)("zip")
                    oSheet.Range(cel(10 + cal) & j).Value = DtView1(i)("adrs1")
                    oSheet.Range(cel(11 + cal) & j).Value = DtView1(i)("adrs2")
                    oSheet.Range(cel(12 + cal) & j).Value = DtView1(i)("adrs3")
                    oSheet.Range(cel(13 + cal) & j).Value = DtView1(i)("floor")
                    oSheet.Range(cel(14 + cal) & j).Value = DtView1(i)("room_name")
                    oSheet.Range(cel(15 + cal) & j).Value = DtView1(i)("livi_togr")
                    oSheet.Range(cel(16 + cal) & j).Value = DtView1(i)("section_code")
                    oSheet.Range(cel(17 + cal) & j).Value = DtView1(i)("line_code")
                    oSheet.Range(cel(18 + cal) & j).Value = DtView1(i)("cls_code")
                    oSheet.Range(cel(19 + cal) & j).Value = DtView1(i)("sub_cls_code")
                    oSheet.Range(cel(20 + cal) & j).Value = DtView1(i)("item_code")
                    oSheet.Range(cel(21 + cal) & j).Value = DtView1(i)("vdr_code")
                    oSheet.Range(cel(22 + cal) & j).Value = DtView1(i)("item_name")
                    oSheet.Range(cel(23 + cal) & j).Value = DtView1(i)("standard_name")
                    oSheet.Range(cel(24 + cal) & j).Value = DtView1(i)("prch_price")
                    oSheet.Range(cel(25 + cal) & j).Value = DtView1(i)("wrn_date")
                    oSheet.Range(cel(26 + cal) & j).Value = DtView1(i)("wrn_prod")
                    oSheet.Range(cel(27 + cal) & j).Value = DtView1(i)("wrn_fee")
                    oSheet.Range(cel(28 + cal) & j).Value = DtView1(i)("shop_code")
                    oSheet.Range(cel(29 + cal) & j).Value = DtView1(i)("rcpt_empl_code")
                    oSheet.Range(cel(30 + cal) & j).Value = DtView1(i)("rcpt_empl_name")
                    oSheet.Range(cel(31 + cal) & j).Value = DtView1(i)("input_date")

                    '2014/05/08 消費税対策 start
                    '税抜商品価格の取得
                    noTaxPrchPrice = GetNoTaxPrchPrice(DtView1(i)("prch_price"), DtView1(i)("input_date"))

                    Select Case DtView1(i)("fee_kbn")
                        Case Is = "A", "B"
                            '                            Select Case DtView1(i)("prch_price")
                            '                                Case Is <= -15750
                            Select Case noTaxPrchPrice
                                Case Is <= -15000
                                    If (DtView1(i)("close_date") < CDate("01/03/2021")) Then 'code added by sabeena
                                        oSheet.Range(cel(32 + cal) & j).Value = RoundDOWN(DtView1(i)("prch_price") * 0.013, 0)
                                        oSheet.Range(cel(33 + cal) & j).Value = oSheet.Range(cel(27 + cal) & j).Value - oSheet.Range(cel(32 + cal) & j).Value
                                        oSheet.Range(cel(34 + cal) & j).Value = RoundDOWN(DtView1(i)("prch_price") * 0.012, 0)
                                        oSheet.Range(cel(35 + cal) & j).Value = "B"
                                        'code added by sabeena starts
                                    Else
                                        oSheet.Range(cel(32 + cal) & j).Value = RoundDOWN(DtView1(i)("prch_price") * 0.013, 0)
                                        oSheet.Range(cel(33 + cal) & j).Value = oSheet.Range(cel(27 + cal) & j).Value - oSheet.Range(cel(32 + cal) & j).Value
                                        oSheet.Range(cel(34 + cal) & j).Value = RoundDOWN(DtView1(i)("prch_price") * 0.011, 0)
                                        oSheet.Range(cel(35 + cal) & j).Value = "B"
                                    End If
                                    'code added by sabeena ends
                                Case Is < 0
                                    If (DtView1(i)("close_date") < CDate("01/03/2021")) Then 'code added by sabeena
                                        oSheet.Range(cel(32 + cal) & j).Value = RoundDOWN(DtView1(i)("prch_price") * 0.006, 0)
                                        oSheet.Range(cel(33 + cal) & j).Value = oSheet.Range(cel(27 + cal) & j).Value - oSheet.Range(cel(32 + cal) & j).Value
                                        oSheet.Range(cel(34 + cal) & j).Value = RoundDOWN(DtView1(i)("prch_price") * 0.012, 0)
                                        oSheet.Range(cel(35 + cal) & j).Value = DtView1(i)("fee_kbn")
                                        'code added by sabeena starts
                                    Else
                                        oSheet.Range(cel(32 + cal) & j).Value = RoundDOWN(DtView1(i)("prch_price") * 0.008, 0)
                                        oSheet.Range(cel(33 + cal) & j).Value = oSheet.Range(cel(27 + cal) & j).Value - oSheet.Range(cel(32 + cal) & j).Value
                                        oSheet.Range(cel(34 + cal) & j).Value = RoundDOWN(DtView1(i)("prch_price") * 0.011, 0)
                                        oSheet.Range(cel(35 + cal) & j).Value = DtView1(i)("fee_kbn")
                                    End If
                                    '        'code added by sabeena ends                        Case Is >= 15750
                                Case Is >= 15000
                                    If (DtView1(i)("close_date") < CDate("01/03/2021")) Then 'code added by sabeena
                                        oSheet.Range(cel(32 + cal) & j).Value = RoundDOWN(DtView1(i)("prch_price") * 0.013, 0)
                                        oSheet.Range(cel(33 + cal) & j).Value = oSheet.Range(cel(27 + cal) & j).Value - oSheet.Range(cel(32 + cal) & j).Value
                                        oSheet.Range(cel(34 + cal) & j).Value = RoundDOWN(DtView1(i)("prch_price") * 0.012, 0)
                                        oSheet.Range(cel(35 + cal) & j).Value = "B"
                                        'code added by sabeena starts
                                    Else
                                        oSheet.Range(cel(32 + cal) & j).Value = RoundDOWN(DtView1(i)("prch_price") * 0.013, 0)
                                        oSheet.Range(cel(33 + cal) & j).Value = oSheet.Range(cel(27 + cal) & j).Value - oSheet.Range(cel(32 + cal) & j).Value
                                        oSheet.Range(cel(34 + cal) & j).Value = RoundDOWN(DtView1(i)("prch_price") * 0.011, 0)
                                        oSheet.Range(cel(35 + cal) & j).Value = "B"
                                    End If
                                    'code added by sabeena ends
                                Case Else
                                    If (DtView1(i)("close_date") < CDate("01/03/2021")) Then 'code added by sabeena
                                        oSheet.Range(cel(32 + cal) & j).Value = RoundDOWN(DtView1(i)("prch_price") * 0.006, 0)
                                        oSheet.Range(cel(33 + cal) & j).Value = oSheet.Range(cel(27 + cal) & j).Value - oSheet.Range(cel(32 + cal) & j).Value
                                        oSheet.Range(cel(34 + cal) & j).Value = RoundDOWN(DtView1(i)("prch_price") * 0.012, 0)
                                        oSheet.Range(cel(35 + cal) & j).Value = DtView1(i)("fee_kbn")
                                        'code added by sabeena starts
                                    Else
                                        oSheet.Range(cel(32 + cal) & j).Value = RoundDOWN(DtView1(i)("prch_price") * 0.008, 0)
                                        oSheet.Range(cel(33 + cal) & j).Value = oSheet.Range(cel(27 + cal) & j).Value - oSheet.Range(cel(32 + cal) & j).Value
                                        oSheet.Range(cel(34 + cal) & j).Value = RoundDOWN(DtView1(i)("prch_price") * 0.011, 0)
                                        oSheet.Range(cel(35 + cal) & j).Value = DtView1(i)("fee_kbn")
                                    End If
                                    'code added by sabeena ends
                            End Select

                        Case Is = "C"
                            If (DtView1(i)("close_date") < CDate("01/03/2021")) Then 'code added by sabeena
                                oSheet.Range(cel(32 + cal) & j).Value = RoundDOWN(DtView1(i)("prch_price") * 0.003, 0)
                                oSheet.Range(cel(33 + cal) & j).Value = oSheet.Range(cel(27 + cal) & j).Value - oSheet.Range(cel(32 + cal) & j).Value
                                oSheet.Range(cel(34 + cal) & j).Value = RoundDOWN(DtView1(i)("prch_price") * 0.012, 0)
                                oSheet.Range(cel(35 + cal) & j).Value = DtView1(i)("fee_kbn")
                                'code added by sabeena starts
                            Else
                                oSheet.Range(cel(32 + cal) & j).Value = RoundDOWN(DtView1(i)("prch_price") * 0.006, 0)
                                oSheet.Range(cel(33 + cal) & j).Value = oSheet.Range(cel(27 + cal) & j).Value - oSheet.Range(cel(32 + cal) & j).Value
                                oSheet.Range(cel(34 + cal) & j).Value = RoundDOWN(DtView1(i)("prch_price") * 0.011, 0)
                                oSheet.Range(cel(35 + cal) & j).Value = DtView1(i)("fee_kbn")
                            End If
                            'code added by sabeena ends

                        Case Is = "D"
                            If (DtView1(i)("close_date") < CDate("01/03/2021")) Then 'code added by sabeena
                                oSheet.Range(cel(32 + cal) & j).Value = RoundDOWN(DtView1(i)("prch_price") * 0.003, 0)
                                oSheet.Range(cel(33 + cal) & j).Value = oSheet.Range(cel(27 + cal) & j).Value - oSheet.Range(cel(32 + cal) & j).Value
                                oSheet.Range(cel(34 + cal) & j).Value = RoundDOWN(DtView1(i)("prch_price") * 0.012, 0)
                                oSheet.Range(cel(35 + cal) & j).Value = DtView1(i)("fee_kbn")
                            Else 'code added by sabeena starts
                                oSheet.Range(cel(32 + cal) & j).Value = RoundDOWN(DtView1(i)("prch_price") * 0.006, 0)
                                oSheet.Range(cel(33 + cal) & j).Value = oSheet.Range(cel(27 + cal) & j).Value - oSheet.Range(cel(32 + cal) & j).Value
                                oSheet.Range(cel(34 + cal) & j).Value = RoundDOWN(DtView1(i)("prch_price") * 0.011, 0)
                                oSheet.Range(cel(35 + cal) & j).Value = DtView1(i)("fee_kbn")
                            End If
                            'code added by sabeena ends
                        Case Is = "E"
                            '                            oSheet.Range(cel(32 + cal) & j).Value = 2300
                            WK_amt1 = 2000 * 1.1
                            WK_amt2 = 800 * 1.1

                            oSheet.Range(cel(32 + cal) & j).Value = WK_amt1
                            oSheet.Range(cel(33 + cal) & j).Value = oSheet.Range(cel(27 + cal) & j).Value - oSheet.Range(cel(32 + cal) & j).Value
                            '                            oSheet.Range(cel(34 + cal) & j).Value = 0
                            oSheet.Range(cel(34 + cal) & j).Value = WK_amt2
                            oSheet.Range(cel(35 + cal) & j).Value = DtView1(i)("fee_kbn")

                        Case Is = "F"
                            '                            oSheet.Range(cel(32 + cal) & j).Value = 2800
                            WK_amt1 = 2500 * 1.1
                            WK_amt2 = 800 * 1.1

                            oSheet.Range(cel(32 + cal) & j).Value = WK_amt1
                            oSheet.Range(cel(33 + cal) & j).Value = oSheet.Range(cel(27 + cal) & j).Value - oSheet.Range(cel(32 + cal) & j).Value
                            '                            oSheet.Range(cel(34 + cal) & j).Value = 0
                            oSheet.Range(cel(34 + cal) & j).Value = WK_amt2
                            oSheet.Range(cel(35 + cal) & j).Value = DtView1(i)("fee_kbn")

                        Case Is = "G"
                            '                            oSheet.Range(cel(32 + cal) & j).Value = 1000
                            WK_amt1 = 1000 * 1.1
                            WK_amt2 = 1310

                            oSheet.Range(cel(32 + cal) & j).Value = WK_amt1
                            oSheet.Range(cel(33 + cal) & j).Value = oSheet.Range(cel(27 + cal) & j).Value - oSheet.Range(cel(32 + cal) & j).Value
                            '                            oSheet.Range(cel(34 + cal) & j).Value = 1250
                            oSheet.Range(cel(34 + cal) & j).Value = WK_amt2
                            oSheet.Range(cel(35 + cal) & j).Value = DtView1(i)("fee_kbn")

                        Case Is = "H"
                            '                            oSheet.Range(cel(32 + cal) & j).Value = 4300
                            WK_amt1 = 4500 * 1.1
                            WK_amt2 = 1964

                            oSheet.Range(cel(32 + cal) & j).Value = WK_amt1
                            oSheet.Range(cel(33 + cal) & j).Value = oSheet.Range(cel(27 + cal) & j).Value - oSheet.Range(cel(32 + cal) & j).Value
                            '                            oSheet.Range(cel(34 + cal) & j).Value = 1875
                            oSheet.Range(cel(34 + cal) & j).Value = WK_amt2
                            oSheet.Range(cel(35 + cal) & j).Value = DtView1(i)("fee_kbn")

                        Case Is = "I"
                            '                            oSheet.Range(cel(32 + cal) & j).Value = 1800
                            WK_amt1 = 1000 * 1.1
                            WK_amt2 = 1964

                            oSheet.Range(cel(32 + cal) & j).Value = WK_amt1
                            oSheet.Range(cel(33 + cal) & j).Value = oSheet.Range(cel(27 + cal) & j).Value - oSheet.Range(cel(32 + cal) & j).Value
                            '                            oSheet.Range(cel(34 + cal) & j).Value = 1875
                            oSheet.Range(cel(34 + cal) & j).Value = WK_amt2
                            oSheet.Range(cel(35 + cal) & j).Value = DtView1(i)("fee_kbn")

                    End Select
                Next
            End If

            '***************
            '** 赤黒明細
            '***************
            oSheet = oBook.Worksheets(2)

            DsList1.Clear()
            SqlCmd1 = New SqlClient.SqlCommand("sp_anshin_list_2", cnsqlclient)
            SqlCmd1.CommandType = CommandType.StoredProcedure
            Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
            Pram2.Value = P_DATE
            DaList1.SelectCommand = SqlCmd1
            DaList1.Fill(DsList1, "sp_anshin_list_2")
            DtView1 = New DataView(DsList1.Tables("sp_anshin_list_2"), "", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then

                '進行状況ダイアログの初期化処理()
                waitDlg.MainMsg = "赤黒明細データ抽出中"
                waitDlg.ProgressValue = 0           '最初の件数を設定
                waitDlg.ProgressMax = DtView1.Count ' 全体の処理件数を設定
                Application.DoEvents()              'メッセージ処理を促して表示を更新する

                For i = 0 To DtView1.Count - 1

                    waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
                    Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                    waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                    j = i + 2
                    oSheet.Range("A" & j).Value = DtView1(i)("wrn_no")
                    If P_DATE < "2021/03/01" Then
                        cal = 0
                        If DtView1(i)("new_txt") = "1" Then
                            oSheet.Range("B" & j).Value = Mid(DtView1(i)("wrn_no"), 1, 4) & "-" & Mid(DtView1(i)("wrn_no"), 11, 5)
                        Else
                            oSheet.Range("B" & j).Value = Mid(DtView1(i)("wrn_no"), 7, 4) & "-" & Mid(DtView1(i)("wrn_no"), 11, 5)
                        End If
                    Else
                        cal = -1
                    End If
                    oSheet.Range(cel(2 + cal) & j).Value = DtView1(i)("line_no")
                    oSheet.Range(cel(3 + cal) & j).Value = DtView1(i)("user_name_KANA")
                    oSheet.Range(cel(4 + cal) & j).Value = DtView1(i)("user_name")
                    oSheet.Range(cel(5 + cal) & j).Value = DtView1(i)("user_tel_no")
                    oSheet.Range(cel(6 + cal) & j).Value = DtView1(i)("appl_name_KANA")
                    oSheet.Range(cel(7 + cal) & j).Value = DtView1(i)("appl_name")
                    oSheet.Range(cel(8 + cal) & j).Value = DtView1(i)("appl_tel_no")
                    oSheet.Range(cel(9 + cal) & j).Value = DtView1(i)("zip")
                    oSheet.Range(cel(10 + cal) & j).Value = DtView1(i)("adrs1")
                    oSheet.Range(cel(11 + cal) & j).Value = DtView1(i)("adrs2")
                    oSheet.Range(cel(12 + cal) & j).Value = DtView1(i)("adrs3")
                    oSheet.Range(cel(13 + cal) & j).Value = DtView1(i)("floor")
                    oSheet.Range(cel(14 + cal) & j).Value = DtView1(i)("room_name")
                    oSheet.Range(cel(15 + cal) & j).Value = DtView1(i)("livi_togr")
                    oSheet.Range(cel(16 + cal) & j).Value = DtView1(i)("section_code")
                    oSheet.Range(cel(17 + cal) & j).Value = DtView1(i)("line_code")
                    oSheet.Range(cel(18 + cal) & j).Value = DtView1(i)("cls_code")
                    oSheet.Range(cel(19 + cal) & j).Value = DtView1(i)("sub_cls_code")
                    oSheet.Range(cel(20 + cal) & j).Value = DtView1(i)("item_code")
                    oSheet.Range(cel(21 + cal) & j).Value = DtView1(i)("vdr_code")
                    oSheet.Range(cel(22 + cal) & j).Value = DtView1(i)("item_name")
                    oSheet.Range(cel(23 + cal) & j).Value = DtView1(i)("standard_name")
                    oSheet.Range(cel(24 + cal) & j).Value = DtView1(i)("prch_price")
                    oSheet.Range(cel(25 + cal) & j).Value = DtView1(i)("wrn_date")
                    oSheet.Range(cel(26 + cal) & j).Value = DtView1(i)("wrn_prod")
                    oSheet.Range(cel(27 + cal) & j).Value = DtView1(i)("wrn_fee")
                    oSheet.Range(cel(28 + cal) & j).Value = DtView1(i)("shop_code")
                    oSheet.Range(cel(29 + cal) & j).Value = DtView1(i)("rcpt_empl_code")
                    oSheet.Range(cel(30 + cal) & j).Value = DtView1(i)("rcpt_empl_name")
                    oSheet.Range(cel(31 + cal) & j).Value = DtView1(i)("input_date")

                    '税抜商品価格の取得
                    noTaxPrchPrice = GetNoTaxPrchPrice(DtView1(i)("prch_price"), DtView1(i)("input_date"))

                    Select Case DtView1(i)("fee_kbn")
                        Case Is = "A"
                            '                            Select Case DtView1(i)("prch_price")
                            '                                Case Is <= -15750
                            Select Case noTaxPrchPrice
                                Case Is <= -15000
                                    oSheet.Range(cel(32 + cal) & j).Value = RoundDOWN(DtView1(i)("prch_price") * 0.013, 0)
                                Case Is < 0
                                    If (DtView1(i)("close_date") < CDate("01/03/2021")) Then 'code added by sabeena
                                        oSheet.Range(cel(32 + cal) & j).Value = RoundDOWN(DtView1(i)("prch_price") * 0.006, 0)
                                        'code added by sabeena starts
                                    Else
                                        oSheet.Range(cel(32 + cal) & j).Value = RoundDOWN(DtView1(i)("prch_price") * 0.008, 0)
                                    End If
                                    '  'code added by sabeena ends                              Case Is >= 15750
                                Case Is >= 15000
                                    oSheet.Range(cel(32 + cal) & j).Value = RoundDOWN(DtView1(i)("prch_price") * 0.013, 0)
                                Case Else
                                    If (DtView1(i)("close_date") < CDate("01/03/2021")) Then 'code added by sabeena
                                        oSheet.Range(cel(32 + cal) & j).Value = RoundDOWN(DtView1(i)("prch_price") * 0.006, 0)
                                        'code added by sabeena starts
                                    Else
                                        oSheet.Range(cel(32 + cal) & j).Value = RoundDOWN(DtView1(i)("prch_price") * 0.008, 0)
                                    End If
                                    'code added by sabeena ends
                            End Select
                            oSheet.Range(cel(33 + cal) & j).Value = oSheet.Range(cel(27 + cal) & j).Value - oSheet.Range(cel(32 + cal) & j).Value
                            If (DtView1(i)("close_date") < CDate("01/03/2021")) Then 'code added by sabeena
                                oSheet.Range(cel(34 + cal) & j).Value = RoundDOWN(DtView1(i)("prch_price") * 0.012, 0)
                                'code added by sabeena starts
                            Else
                                oSheet.Range(cel(34 + cal) & j).Value = RoundDOWN(DtView1(i)("prch_price") * 0.011, 0)
                            End If
                            'code added by sabeena ends
                        Case Is = "C"
                            If (DtView1(i)("close_date") < CDate("01/03/2021")) Then 'code added by sabeena
                                oSheet.Range(cel(32 + cal) & j).Value = RoundDOWN(DtView1(i)("prch_price") * 0.003, 0)
                                oSheet.Range(cel(33 + cal) & j).Value = oSheet.Range(cel(27 + cal) & j).Value - oSheet.Range(cel(32 + cal) & j).Value
                                oSheet.Range(cel(34 + cal) & j).Value = RoundDOWN(DtView1(i)("prch_price") * 0.012, 0)
                                'code added by sabeena starts
                            Else
                                oSheet.Range(cel(32 + cal) & j).Value = RoundDOWN(DtView1(i)("prch_price") * 0.006, 0)
                                oSheet.Range(cel(33 + cal) & j).Value = oSheet.Range(cel(27 + cal) & j).Value - oSheet.Range(cel(32 + cal) & j).Value
                                oSheet.Range(cel(34 + cal) & j).Value = RoundDOWN(DtView1(i)("prch_price") * 0.011, 0)
                            End If
                            'code added by sabeena ends
                        Case Is = "D"
                            If (DtView1(i)("close_date") < CDate("01/03/2021")) Then 'code added by sabeena
                                oSheet.Range(cel(32 + cal) & j).Value = RoundDOWN(DtView1(i)("prch_price") * 0.003, 0)
                                oSheet.Range(cel(33 + cal) & j).Value = oSheet.Range(cel(27 + cal) & j).Value - oSheet.Range(cel(32 + cal) & j).Value
                                oSheet.Range(cel(34 + cal) & j).Value = RoundDOWN(DtView1(i)("prch_price") * 0.012, 0)
                                'code added by sabeena starts
                            Else
                                oSheet.Range(cel(32 + cal) & j).Value = RoundDOWN(DtView1(i)("prch_price") * 0.006, 0)
                                oSheet.Range(cel(33 + cal) & j).Value = oSheet.Range(cel(27 + cal) & j).Value - oSheet.Range(cel(32 + cal) & j).Value
                                oSheet.Range(cel(34 + cal) & j).Value = RoundDOWN(DtView1(i)("prch_price") * 0.011, 0)
                            End If
                            'code added by sabeena ends
                        Case Is = "E"
                            '                            oSheet.Range(cel(32 + cal) & j).Value = 2300
                            WK_amt1 = 2000 * 1.1
                            WK_amt2 = 800 * 1.1

                            oSheet.Range(cel(32 + cal) & j).Value = WK_amt1
                            oSheet.Range(cel(33 + cal) & j).Value = oSheet.Range(cel(27 + cal) & j).Value - oSheet.Range(cel(32 + cal) & j).Value
                            '                            oSheet.Range(cel(34 + cal) & j).Value = 0
                            oSheet.Range(cel(34 + cal) & j).Value = WK_amt2

                        Case Is = "F"
                            '                            oSheet.Range(cel(32 + cal) & j).Value = 2800
                            WK_amt1 = 2500 * 1.1
                            WK_amt2 = 800 * 1.1

                            oSheet.Range(cel(32 + cal) & j).Value = WK_amt1
                            oSheet.Range(cel(33 + cal) & j).Value = oSheet.Range(cel(27 + cal) & j).Value - oSheet.Range(cel(32 + cal) & j).Value
                            '                            oSheet.Range(cel(34 + cal) & j).Value = 0
                            oSheet.Range(cel(34 + cal) & j).Value = WK_amt2

                        Case Is = "G"
                            '                            oSheet.Range(cel(32 + cal) & j).Value = 1000
                            WK_amt1 = 1000 * 1.1
                            WK_amt2 = 1310

                            oSheet.Range(cel(32 + cal) & j).Value = WK_amt1
                            oSheet.Range(cel(33 + cal) & j).Value = oSheet.Range(cel(27 + cal) & j).Value - oSheet.Range(cel(32 + cal) & j).Value
                            '                            oSheet.Range(cel(34 + cal) & j).Value = 1250
                            oSheet.Range(cel(34 + cal) & j).Value = WK_amt2

                        Case Is = "H"
                            '                            oSheet.Range(cel(32 + cal) & j).Value = 4300
                            WK_amt1 = 4500 * 1.1
                            WK_amt2 = 1964

                            oSheet.Range(cel(32 + cal) & j).Value = WK_amt1
                            oSheet.Range(cel(33 + cal) & j).Value = oSheet.Range(cel(27 + cal) & j).Value - oSheet.Range(cel(32 + cal) & j).Value
                            '                            oSheet.Range(cel(34 + cal) & j).Value = 1875
                            oSheet.Range(cel(34 + cal) & j).Value = WK_amt2

                        Case Is = "I"
                            '                            oSheet.Range(cel(32 + cal) & j).Value = 1800
                            WK_amt1 = 1000 * 1.1
                            WK_amt2 = 1964

                            oSheet.Range(cel(32 + cal) & j).Value = WK_amt1
                            oSheet.Range(cel(33 + cal) & j).Value = oSheet.Range(cel(27 + cal) & j).Value - oSheet.Range(cel(32 + cal) & j).Value
                            '                            oSheet.Range(cel(34 + cal) & j).Value = 1875
                            oSheet.Range(cel(34 + cal) & j).Value = WK_amt2

                    End Select
                Next
            End If

            '2014/05/08 消費税対策 end


            '***************
            '** 取消明細
            '***************
            oSheet = oBook.Worksheets(3)

            DsList1.Clear()
            SqlCmd1 = New SqlClient.SqlCommand("sp_CX_list", cnsqlclient)
            SqlCmd1.CommandType = CommandType.StoredProcedure
            Dim Pram3 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
            'Pram3.Value = DateAdd(DateInterval.Month, -1, P_DATE) VJ 2020/09/09
            Dim PDATE As DateTime
            PDATE = DateTime.ParseExact(P_DATE, "yyyy/MM/dd", Nothing)
            Pram3.Value = DateAdd(DateInterval.Month, -1, PDATE)
            DaList1.SelectCommand = SqlCmd1
            DaList1.Fill(DsList1, "sp_CX_list")
            DtView1 = New DataView(DsList1.Tables("sp_CX_list"), "", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then

                '進行状況ダイアログの初期化処理()
                waitDlg.MainMsg = "取消明細データ抽出中"
                waitDlg.ProgressValue = 0           '最初の件数を設定
                waitDlg.ProgressMax = DtView1.Count ' 全体の処理件数を設定
                Application.DoEvents()              'メッセージ処理を促して表示を更新する

                For i = 0 To DtView1.Count - 1

                    waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
                    Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                    waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                    j = i + 2
                    oSheet.Range("A" & j).Value = DtView1(i)("wrn_no")
                    If P_DATE < "2021/03/01" Then
                        cal = 0
                        If DtView1(i)("new_txt") = "1" Then
                            oSheet.Range("B" & j).Value = Mid(DtView1(i)("wrn_no"), 1, 4) & "-" & Mid(DtView1(i)("wrn_no"), 11, 5)
                        Else
                            oSheet.Range("B" & j).Value = Mid(DtView1(i)("wrn_no"), 7, 4) & "-" & Mid(DtView1(i)("wrn_no"), 11, 5)
                        End If
                    Else
                        cal = -1
                    End If
                    oSheet.Range(cel(2 + cal) & j).Value = DtView1(i)("line_no")
                    oSheet.Range(cel(3 + cal) & j).Value = DtView1(i)("user_name_KANA")
                    oSheet.Range(cel(4 + cal) & j).Value = DtView1(i)("user_name")
                    oSheet.Range(cel(5 + cal) & j).Value = DtView1(i)("user_tel_no")
                    oSheet.Range(cel(6 + cal) & j).Value = DtView1(i)("appl_name_KANA")
                    oSheet.Range(cel(7 + cal) & j).Value = DtView1(i)("appl_name")
                    oSheet.Range(cel(8 + cal) & j).Value = DtView1(i)("appl_tel_no")
                    oSheet.Range(cel(9 + cal) & j).Value = DtView1(i)("zip")
                    oSheet.Range(cel(10 + cal) & j).Value = DtView1(i)("adrs1")
                    oSheet.Range(cel(11 + cal) & j).Value = DtView1(i)("adrs2")
                    oSheet.Range(cel(12 + cal) & j).Value = DtView1(i)("adrs3")
                    oSheet.Range(cel(13 + cal) & j).Value = DtView1(i)("floor")
                    oSheet.Range(cel(14 + cal) & j).Value = DtView1(i)("room_name")
                    oSheet.Range(cel(15 + cal) & j).Value = DtView1(i)("livi_togr")
                    oSheet.Range(cel(16 + cal) & j).Value = DtView1(i)("section_code")
                    oSheet.Range(cel(17 + cal) & j).Value = DtView1(i)("line_code")
                    oSheet.Range(cel(18 + cal) & j).Value = DtView1(i)("cls_code")
                    oSheet.Range(cel(19 + cal) & j).Value = DtView1(i)("sub_cls_code")
                    oSheet.Range(cel(20 + cal) & j).Value = DtView1(i)("item_code")
                    oSheet.Range(cel(21 + cal) & j).Value = DtView1(i)("vdr_code")
                    oSheet.Range(cel(22 + cal) & j).Value = DtView1(i)("item_name")
                    oSheet.Range(cel(23 + cal) & j).Value = DtView1(i)("standard_name")
                    oSheet.Range(cel(24 + cal) & j).Value = DtView1(i)("prch_price")
                    oSheet.Range(cel(25 + cal) & j).Value = DtView1(i)("wrn_date")
                    oSheet.Range(cel(26 + cal) & j).Value = DtView1(i)("wrn_prod")
                    oSheet.Range(cel(27 + cal) & j).Value = DtView1(i)("wrn_fee")
                    oSheet.Range(cel(28 + cal) & j).Value = DtView1(i)("shop_code")
                    oSheet.Range(cel(29 + cal) & j).Value = DtView1(i)("rcpt_empl_code")
                    oSheet.Range(cel(30 + cal) & j).Value = DtView1(i)("rcpt_empl_name")
                    oSheet.Range(cel(31 + cal) & j).Value = DtView1(i)("input_date")
                Next
            End If

            '***************
            '** エラー照会
            '***************
            oSheet = oBook.Worksheets(5)
            ''==================  データの入力処理  ==================  

            DsList1.Clear()
            SqlCmd1 = New SqlClient.SqlCommand("sp_err_list2", cnsqlclient)
            SqlCmd1.CommandType = CommandType.StoredProcedure
            Dim Pram4 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
            Pram4.Value = P_DATE
            DaList1.SelectCommand = SqlCmd1
            DaList1.Fill(DsList1, "sp_err_list2")
            DtView1 = New DataView(DsList1.Tables("sp_err_list2"), "", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then

                '進行状況ダイアログの初期化処理()
                waitDlg.MainMsg = "エラー照会データ抽出中"
                waitDlg.ProgressValue = 0           '最初の件数を設定
                waitDlg.ProgressMax = DtView1.Count ' 全体の処理件数を設定
                Application.DoEvents()              'メッセージ処理を促して表示を更新する

                For i = 0 To DtView1.Count - 1

                    waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
                    Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                    waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                    Call F_slct()   '** 項目分割

                    j = i + 2
                    oSheet.Range("A" & j).Value = DtView1(i)("err_msg")
                    oSheet.Range("B" & j).Value = strDATA(1)
                    If P_DATE < "2021/03/01" Then
                        cal = 0
                        If DtView1(i)("new_txt") = "1" Then
                            oSheet.Range("C" & j).Value = Mid(strDATA(1), 1, 4) & "-" & Mid(strDATA(1), 11, 5)
                        Else
                            oSheet.Range("C" & j).Value = Mid(strDATA(1), 7, 4) & "-" & Mid(strDATA(1), 11, 5)
                        End If
                    Else
                        cal = -1
                    End If
                    oSheet.Range(cel(3 + cal) & j).Value = strDATA(2)
                    oSheet.Range(cel(4 + cal) & j).Value = strDATA(3)
                    oSheet.Range(cel(5 + cal) & j).Value = strDATA(4)
                    oSheet.Range(cel(6 + cal) & j).Value = strDATA(5)
                    oSheet.Range(cel(7 + cal) & j).Value = strDATA(6)
                    oSheet.Range(cel(8 + cal) & j).Value = strDATA(7)
                    oSheet.Range(cel(9 + cal) & j).Value = strDATA(8)
                    oSheet.Range(cel(10 + cal) & j).Value = strDATA(9)
                    oSheet.Range(cel(11 + cal) & j).Value = strDATA(10)
                    oSheet.Range(cel(12 + cal) & j).Value = strDATA(11)
                    oSheet.Range(cel(13 + cal) & j).Value = strDATA(12)
                    oSheet.Range(cel(14 + cal) & j).Value = strDATA(13)
                    oSheet.Range(cel(15 + cal) & j).Value = strDATA(14)
                    oSheet.Range(cel(16 + cal) & j).Value = strDATA(15)
                    oSheet.Range(cel(17 + cal) & j).Value = strDATA(16)
                    oSheet.Range(cel(18 + cal) & j).Value = strDATA(17)
                    oSheet.Range(cel(19 + cal) & j).Value = strDATA(18)
                    oSheet.Range(cel(20 + cal) & j).Value = strDATA(19)
                    oSheet.Range(cel(21 + cal) & j).Value = strDATA(20)
                    oSheet.Range(cel(22 + cal) & j).Value = strDATA(21)
                    oSheet.Range(cel(23 + cal) & j).Value = strDATA(22)
                    oSheet.Range(cel(24 + cal) & j).Value = strDATA(23)
                    oSheet.Range(cel(25 + cal) & j).Value = strDATA(24)
                    oSheet.Range(cel(26 + cal) & j).Value = strDATA(25)
                    oSheet.Range(cel(27 + cal) & j).Value = strDATA(26)
                    oSheet.Range(cel(28 + cal) & j).Value = strDATA(27)
                    oSheet.Range(cel(29 + cal) & j).Value = strDATA(29)
                    oSheet.Range(cel(30 + cal) & j).Value = strDATA(28)
                    oSheet.Range(cel(31 + cal) & j).Value = strDATA(30)
                    oSheet.Range(cel(32 + cal) & j).Value = strDATA(31)
                Next
            End If
            DB_CLOSE()

            '［名前を付けて保存］ダイアログボックスを表示
            'VJ 2020/09/09

            SaveFileDialog1.FileName = "Homac長期安心保証データ" & Format(PDATE, "yyyyMM") & ".xls"
            SaveFileDialog1.Filter = "Excelファイル|*.xls"
            SaveFileDialog1.OverwritePrompt = False
            If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                oBook.SaveAs(SaveFileDialog1.FileName)
                CX_F = "0"
            Else
                CX_F = "1"
            End If

            '==================  終了処理  =====================  
            oSheet = Nothing
            oBook = Nothing
            oExcel.Quit()
            oExcel = Nothing
            GC.Collect()

            If CX_F = "0" Then
                MessageBox.Show(SaveFileDialog1.FileName & " に出力しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Me.Activate()                   ' いったんオーナーをアクティブにする
            waitDlg.Close()                 ' 進行状況ダイアログを閉じる
            Me.Enabled = True

        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
err_prc:
        If Err.Number = 50290 Then
            MessageBox.Show("エクセル出力中に他のエクセルファイルを開く事は出来ません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Else
            MessageBox.Show(Err.Number & ":" & Err.Description, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If
        Me.Activate()                   ' いったんオーナーをアクティブにする
        waitDlg.Close()                 ' 進行状況ダイアログを閉じる
        Me.Enabled = True
        DB_CLOSE()

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** 戻る
    '******************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        WK_DsList1.Clear()
        DsList1.Clear()
        Close()
    End Sub
End Class
