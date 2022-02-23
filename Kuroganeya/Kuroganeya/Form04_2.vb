Public Class Form04_2
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim WK_DsList1 As New DataSet
    Dim DtView1 As DataView
    Dim WK_DtView1, cls_DtView1 As DataView

    Dim strSQL, Err_F As String

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
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Edit001 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit002 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label001 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Number1 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Number2 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number3 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number4 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number5 As GrapeCity.Win.Input.Interop.Number
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form04_2))
        Me.msg = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button98 = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Edit001 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit002 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label001 = New System.Windows.Forms.Label
        Me.Label51 = New System.Windows.Forms.Label
        Me.Number1 = New GrapeCity.Win.Input.Interop.Number
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Number2 = New GrapeCity.Win.Input.Interop.Number
        Me.Number3 = New GrapeCity.Win.Input.Interop.Number
        Me.Number4 = New GrapeCity.Win.Input.Interop.Number
        Me.Number5 = New GrapeCity.Win.Input.Interop.Number
        CType(Me.Edit001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(12, 264)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(500, 24)
        Me.msg.TabIndex = 1308
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(12, 296)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 32)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "更新"
        '
        'Button98
        '
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(444, 296)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 32)
        Me.Button98.TabIndex = 9
        Me.Button98.Text = "戻る"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Navy
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(12, 68)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(132, 24)
        Me.Label6.TabIndex = 1304
        Me.Label6.Text = "商品ｶﾃｺﾞﾘｰ名"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Navy
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(12, 36)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(132, 24)
        Me.Label11.TabIndex = 1303
        Me.Label11.Text = "商品ｶﾃｺﾞﾘｰｺｰﾄﾞ"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit001
        '
        Me.Edit001.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit001.Format = "9"
        Me.Edit001.HighlightText = True
        Me.Edit001.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit001.LengthAsByte = True
        Me.Edit001.Location = New System.Drawing.Point(144, 36)
        Me.Edit001.MaxLength = 6
        Me.Edit001.Name = "Edit001"
        Me.Edit001.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit001.Size = New System.Drawing.Size(92, 24)
        Me.Edit001.TabIndex = 0
        Me.Edit001.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit002
        '
        Me.Edit002.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit002.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit002.HighlightText = True
        Me.Edit002.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit002.LengthAsByte = True
        Me.Edit002.Location = New System.Drawing.Point(144, 68)
        Me.Edit002.MaxLength = 50
        Me.Edit002.Name = "Edit002"
        Me.Edit002.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit002.Size = New System.Drawing.Size(372, 24)
        Me.Edit002.TabIndex = 1
        Me.Edit002.Text = "ああああああああああ"
        Me.Edit002.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label001
        '
        Me.Label001.Location = New System.Drawing.Point(412, 8)
        Me.Label001.Name = "Label001"
        Me.Label001.Size = New System.Drawing.Size(104, 24)
        Me.Label001.TabIndex = 1312
        Me.Label001.Text = "Label001"
        Me.Label001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label51
        '
        Me.Label51.BackColor = System.Drawing.Color.Navy
        Me.Label51.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label51.ForeColor = System.Drawing.Color.White
        Me.Label51.Location = New System.Drawing.Point(324, 8)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(88, 24)
        Me.Label51.TabIndex = 1311
        Me.Label51.Text = "登録日"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number1
        '
        Me.Number1.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#0", "", "", "-", "", "", "Null")
        Me.Number1.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number1.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number1.DropDownCalculator.Size = New System.Drawing.Size(228, 207)
        Me.Number1.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#0", "", "", "-", "", "", "")
        Me.Number1.Location = New System.Drawing.Point(144, 100)
        Me.Number1.MaxValue = New Decimal(New Integer() {10, 0, 0, 0})
        Me.Number1.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number1.Name = "Number1"
        Me.Number1.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number1.Size = New System.Drawing.Size(92, 24)
        Me.Number1.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, False, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number1.TabIndex = 2
        Me.Number1.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Navy
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(12, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(132, 24)
        Me.Label2.TabIndex = 1314
        Me.Label2.Text = "保証期間"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Navy
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(12, 132)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(132, 24)
        Me.Label3.TabIndex = 1315
        Me.Label3.Text = "販売価格"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Navy
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(12, 164)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(132, 24)
        Me.Label4.TabIndex = 1316
        Me.Label4.Text = "販売手数料"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Navy
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(12, 196)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(132, 24)
        Me.Label5.TabIndex = 1317
        Me.Label5.Text = "卸価格"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Navy
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(12, 228)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(132, 24)
        Me.Label7.TabIndex = 1318
        Me.Label7.Text = "事務手数料"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number2
        '
        Me.Number2.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("##,##0", "", "", "-", "", "", "Null")
        Me.Number2.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number2.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number2.DropDownCalculator.Size = New System.Drawing.Size(228, 207)
        Me.Number2.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("##,##0", "", "", "-", "", "", "")
        Me.Number2.Location = New System.Drawing.Point(144, 132)
        Me.Number2.MaxValue = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.Number2.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number2.Name = "Number2"
        Me.Number2.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number2.Size = New System.Drawing.Size(92, 24)
        Me.Number2.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, False, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number2.TabIndex = 3
        Me.Number2.Value = Nothing
        '
        'Number3
        '
        Me.Number3.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("##,##0", "", "", "-", "", "", "Null")
        Me.Number3.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number3.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number3.DropDownCalculator.Size = New System.Drawing.Size(228, 207)
        Me.Number3.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("##,##0", "", "", "-", "", "", "")
        Me.Number3.Location = New System.Drawing.Point(144, 164)
        Me.Number3.MaxValue = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.Number3.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number3.Name = "Number3"
        Me.Number3.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number3.Size = New System.Drawing.Size(92, 24)
        Me.Number3.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, False, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number3.TabIndex = 4
        Me.Number3.Value = Nothing
        '
        'Number4
        '
        Me.Number4.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("##,##0", "", "", "-", "", "", "Null")
        Me.Number4.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number4.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number4.DropDownCalculator.Size = New System.Drawing.Size(228, 207)
        Me.Number4.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("##,##0", "", "", "-", "", "", "")
        Me.Number4.Location = New System.Drawing.Point(144, 196)
        Me.Number4.MaxValue = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.Number4.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number4.Name = "Number4"
        Me.Number4.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number4.Size = New System.Drawing.Size(92, 24)
        Me.Number4.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, False, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number4.TabIndex = 5
        Me.Number4.Value = Nothing
        '
        'Number5
        '
        Me.Number5.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("##,##0", "", "", "-", "", "", "Null")
        Me.Number5.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number5.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number5.DropDownCalculator.Size = New System.Drawing.Size(228, 207)
        Me.Number5.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("##,##0", "", "", "-", "", "", "")
        Me.Number5.Location = New System.Drawing.Point(144, 228)
        Me.Number5.MaxValue = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.Number5.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number5.Name = "Number5"
        Me.Number5.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number5.Size = New System.Drawing.Size(92, 24)
        Me.Number5.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, False, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number5.TabIndex = 6
        Me.Number5.Value = Nothing
        '
        'Form04_2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(530, 335)
        Me.Controls.Add(Me.Number5)
        Me.Controls.Add(Me.Number4)
        Me.Controls.Add(Me.Number3)
        Me.Controls.Add(Me.Number2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Number1)
        Me.Controls.Add(Me.Label001)
        Me.Controls.Add(Me.Label51)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Edit001)
        Me.Controls.Add(Me.Edit002)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "Form04_2"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "商品ｶﾃｺﾞﾘｰ"
        CType(Me.Edit001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub Form04_2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()       '**  初期処理
        DspSet()    '**  画面セット
    End Sub

    '********************************************************************
    '**  初期処理
    '********************************************************************
    Sub inz()
        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        P_RTN = "0"
        msg.Text = Nothing
    End Sub

    '********************************************************************
    '**  画面セット
    '********************************************************************
    Sub DspSet()
        DsList1.Clear()

        If P_PRAM1 = Nothing Then   '新規
            Button1.Text = "登録"
            Edit001.Enabled = True

            Edit001.Text = Nothing
            Edit002.Text = Nothing
            Number1.Value = 0
            Number2.Value = 0
            Number3.Value = 0
            Number4.Value = 0
            Number5.Value = 0
            Label001.Text = Nothing

        Else                        '修正
            Button1.Text = "更新"
            Edit001.Enabled = False

            'M_category
            strSQL = "SELECT * FROM M_category"
            strSQL += " WHERE (CAT_CODE = '" & P_PRAM1 & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN()
            DaList1.Fill(DsList1, "M_category")
            DB_CLOSE()

            DtView1 = New DataView(DsList1.Tables("M_category"), "", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                Edit001.Text = P_PRAM1
                Edit002.Text = Trim(DtView1(0)("CAT_NAME"))
                Number1.Value = DtView1(0)("WRN_YEAR")
                Number2.Value = DtView1(0)("WRN_PRICE")
                Number3.Value = DtView1(0)("tesuryo")
                Number4.Value = DtView1(0)("oroshi")
                Number5.Value = DtView1(0)("jimu")
                Label001.Text = Format(DtView1(0)("CRT_DATE"), "yyyy/MM/dd")
            End If
        End If
    End Sub

    '********************************************************************
    '**  項目チェック
    '********************************************************************
    Sub CHK_Edit001()   '商品ｺｰﾄﾞ
        msg.Text = Nothing

        Edit001.Text = Trim(Edit001.Text)
        If Edit001.Text = Nothing Then
            Edit001.BackColor = System.Drawing.Color.Red
            msg.Text = "商品ｺｰﾄﾞが入力されていません。"
            Exit Sub
        Else
            WK_DsList1.Clear()
            strSQL = "SELECT * FROM M_category"
            strSQL += " WHERE (CAT_CODE = '" & Edit001.Text & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN()
            DaList1.Fill(WK_DsList1, "M_category")
            DB_CLOSE()
            WK_DtView1 = New DataView(WK_DsList1.Tables("M_category"), "", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count <> 0 Then
                Edit001.BackColor = System.Drawing.Color.Red
                msg.Text = "商品ｺｰﾄﾞが既に登録されています。"
                Exit Sub
            End If
        End If
        Edit001.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Sub CHK_Edit002()   '商品名
        msg.Text = Nothing

        Edit002.Text = Trim(Edit002.Text)
        If Edit002.Text = Nothing Then
            Edit002.BackColor = System.Drawing.Color.Red
            msg.Text = "商品名が入力されていません。"
            Exit Sub
        End If
        Edit002.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Sub CHK_Number1()   '保証期間
        msg.Text = Nothing

        If Number1.Value = 0 Then
            Number1.BackColor = System.Drawing.Color.Red
            msg.Text = "保証期間が入力されていません。"
            Exit Sub
        End If
        Number1.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Sub CHK_Number2()   '販売価格
        msg.Text = Nothing

        If Number2.Value = 0 Then
            Number2.BackColor = System.Drawing.Color.Red
            msg.Text = "販売価格が入力されていません。"
            Exit Sub
        End If
        Number2.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Sub CHK_Number3()   '販売手数料
        msg.Text = Nothing

        If Number3.Value = 0 Then
            Number3.BackColor = System.Drawing.Color.Red
            msg.Text = "販売手数料が入力されていません。"
            Exit Sub
        End If
        Number3.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Sub CHK_Number4()   '卸価格
        msg.Text = Nothing

        If Number4.Value = 0 Then
            Number4.BackColor = System.Drawing.Color.Red
            msg.Text = "卸価格が入力されていません。"
            Exit Sub
        End If
        Number4.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Sub CHK_Number5()   '事務手数料
        msg.Text = Nothing

        If Number5.Value = 0 Then
            Number5.BackColor = System.Drawing.Color.Red
            msg.Text = "事務手数料が入力されていません。"
            Exit Sub
        End If
        Number5.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Sub F_Check()
        Err_F = "0"

        If P_PRAM1 = Nothing Then   '新規
            CHK_Edit001() '品種ｺｰﾄﾞ
            If msg.Text <> Nothing Then Err_F = "1" : Edit001.Focus() : Exit Sub
        End If

        CHK_Edit002()   '品種名
        If msg.Text <> Nothing Then Err_F = "1" : Edit002.Focus() : Exit Sub

        CHK_Number1()   '保証期間
        If msg.Text <> Nothing Then Err_F = "1" : Number1.Focus() : Exit Sub

        CHK_Number2()   '販売価格
        If msg.Text <> Nothing Then Err_F = "1" : Number2.Focus() : Exit Sub

        CHK_Number3()   '販売手数料
        If msg.Text <> Nothing Then Err_F = "1" : Number3.Focus() : Exit Sub

        CHK_Number4()   '卸価格
        If msg.Text <> Nothing Then Err_F = "1" : Number4.Focus() : Exit Sub

        CHK_Number5()   '事務手数料
        If msg.Text <> Nothing Then Err_F = "1" : Number5.Focus() : Exit Sub

    End Sub

    '********************************************************************
    '**  GotFocus
    '********************************************************************
    Private Sub Edit001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit001.GotFocus
        Edit001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit002_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit002.GotFocus
        Edit002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number1.GotFocus
        Number1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number2.GotFocus
        Number2.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number3.GotFocus
        Number3.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number4_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number4.GotFocus
        Number4.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number5_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number5.GotFocus
        Number5.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub Edit001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit001.LostFocus
        CHK_Edit001()   '品種ｺｰﾄﾞ
    End Sub
    Private Sub Edit002_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit002.LostFocus
        CHK_Edit002()   '品種名
    End Sub
    Private Sub Number1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number1.LostFocus
        CHK_Number1()   '保証期間
    End Sub
    Private Sub Number2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number2.LostFocus
        CHK_Number2()   '販売価格
    End Sub
    Private Sub Number3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number3.LostFocus
        CHK_Number3()   '販売手数料
    End Sub
    Private Sub Number4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number4.LostFocus
        CHK_Number4()   '卸価格
    End Sub
    Private Sub Number5_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number5.LostFocus
        CHK_Number5()   '事務手数料
    End Sub

    '********************************************************************
    '**  更新
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        F_Check()   '**  項目チェック
        If Err_F = "0" Then
            If P_PRAM1 = Nothing Then   '新規
                Label001.Text = Now.Date

                strSQL = "INSERT INTO M_category"
                strSQL += " (CAT_CODE, CAT_NAME, WRN_YEAR, WRN_PRICE, tesuryo, oroshi, jimu, CRT_DATE)"
                strSQL += " VALUES ('" & Edit001.Text & "'"
                strSQL += ", '" & Edit002.Text & "'"
                strSQL += ", " & Number1.Value
                strSQL += ", " & Number2.Value
                strSQL += ", " & Number3.Value
                strSQL += ", " & Number4.Value
                strSQL += ", " & Number5.Value
                strSQL += ", CONVERT(DATETIME, '" & Now & "', 102))"
                DB_OPEN()
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                msg.Text = "登録しました。"
                P_RTN = "1"
                P_PRAM1 = Edit001.Text
                DspSet()    '**  画面セット
            Else                        '修正

                strSQL = "UPDATE M_category"
                strSQL += " SET CAT_NAME = '" & Edit002.Text & "'"
                strSQL += ", WRN_YEAR = " & Number1.Value
                strSQL += ", WRN_PRICE = " & Number2.Value
                strSQL += ", tesuryo = " & Number3.Value
                strSQL += ", oroshi = " & Number4.Value
                strSQL += ", jimu = " & Number5.Value
                strSQL += ", UPD_DATE = CONVERT(DATETIME, '" & Now & "', 102)"
                strSQL += " WHERE (CAT_CODE = '" & P_PRAM1 & "')"
                DB_OPEN()
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                msg.Text = "更新しました。"
                DspSet()    '**  画面セット
                P_RTN = "1"
            End If
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  戻る
    '********************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        DsList1.Clear()
        WK_DsList1.Clear()
        Close()
    End Sub
End Class
