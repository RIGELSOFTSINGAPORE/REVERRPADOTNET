Public Class Form3_sub2
    Inherits System.Windows.Forms.Form

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, DG_DsList1 As New DataSet
    Dim DtView1 As DataView

    Dim strSQL, Err_F, CHG_F As String
    Dim i, r As Integer

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
    Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
    Friend WithEvents Label048 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Number1 As GrapeCity.Win.Input.Number
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents Label046 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label042 As System.Windows.Forms.Label
    Friend WithEvents Label043 As System.Windows.Forms.Label
    Friend WithEvents Label044 As System.Windows.Forms.Label
    Friend WithEvents Label045 As System.Windows.Forms.Label
    Friend WithEvents Label041 As System.Windows.Forms.Label
    Friend WithEvents Label040 As System.Windows.Forms.Label
    Friend WithEvents Label039 As System.Windows.Forms.Label
    Friend WithEvents Label038 As System.Windows.Forms.Label
    Friend WithEvents Label037 As System.Windows.Forms.Label
    Friend WithEvents Label036 As System.Windows.Forms.Label
    Friend WithEvents Label035 As System.Windows.Forms.Label
    Friend WithEvents Label034 As System.Windows.Forms.Label
    Friend WithEvents Label033 As System.Windows.Forms.Label
    Friend WithEvents Label032 As System.Windows.Forms.Label
    Friend WithEvents Label031 As System.Windows.Forms.Label
    Friend WithEvents Label030 As System.Windows.Forms.Label
    Friend WithEvents Label029 As System.Windows.Forms.Label
    Friend WithEvents Label028 As System.Windows.Forms.Label
    Friend WithEvents Label027 As System.Windows.Forms.Label
    Friend WithEvents Label026 As System.Windows.Forms.Label
    Friend WithEvents Label025 As System.Windows.Forms.Label
    Friend WithEvents Label024 As System.Windows.Forms.Label
    Friend WithEvents Label023 As System.Windows.Forms.Label
    Friend WithEvents Label022 As System.Windows.Forms.Label
    Friend WithEvents Label021 As System.Windows.Forms.Label
    Friend WithEvents Label020 As System.Windows.Forms.Label
    Friend WithEvents Label019 As System.Windows.Forms.Label
    Friend WithEvents Label018 As System.Windows.Forms.Label
    Friend WithEvents Label017 As System.Windows.Forms.Label
    Friend WithEvents Label016 As System.Windows.Forms.Label
    Friend WithEvents Label015 As System.Windows.Forms.Label
    Friend WithEvents Label014 As System.Windows.Forms.Label
    Friend WithEvents Label013 As System.Windows.Forms.Label
    Friend WithEvents Label012 As System.Windows.Forms.Label
    Friend WithEvents Label011 As System.Windows.Forms.Label
    Friend WithEvents Label010 As System.Windows.Forms.Label
    Friend WithEvents Label009 As System.Windows.Forms.Label
    Friend WithEvents Label008 As System.Windows.Forms.Label
    Friend WithEvents Label007 As System.Windows.Forms.Label
    Friend WithEvents Label006 As System.Windows.Forms.Label
    Friend WithEvents Label005 As System.Windows.Forms.Label
    Friend WithEvents Label004 As System.Windows.Forms.Label
    Friend WithEvents Label003 As System.Windows.Forms.Label
    Friend WithEvents Label002 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn9 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn10 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn11 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn12 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn13 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn14 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn15 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn16 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridEx1 As MrMax_Import.DataGridEx
    Friend WithEvents DataGridBoolColumn1 As System.Windows.Forms.DataGridBoolColumn
    Friend WithEvents DataGridTextBoxColumn17 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label001 As System.Windows.Forms.Label
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents Edit1 As GrapeCity.Win.Input.Edit
    Friend WithEvents Number2 As GrapeCity.Win.Input.Number
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Date1 As GrapeCity.Win.Input.Date
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form3_sub2))
        Me.RadioButton5 = New System.Windows.Forms.RadioButton
        Me.Label048 = New System.Windows.Forms.Label
        Me.Label45 = New System.Windows.Forms.Label
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.Number1 = New GrapeCity.Win.Input.Number
        Me.RadioButton4 = New System.Windows.Forms.RadioButton
        Me.Label046 = New System.Windows.Forms.Label
        Me.Label42 = New System.Windows.Forms.Label
        Me.Label042 = New System.Windows.Forms.Label
        Me.Label043 = New System.Windows.Forms.Label
        Me.Label044 = New System.Windows.Forms.Label
        Me.Label045 = New System.Windows.Forms.Label
        Me.Label041 = New System.Windows.Forms.Label
        Me.Label040 = New System.Windows.Forms.Label
        Me.Label039 = New System.Windows.Forms.Label
        Me.Label038 = New System.Windows.Forms.Label
        Me.Label037 = New System.Windows.Forms.Label
        Me.Label036 = New System.Windows.Forms.Label
        Me.Label035 = New System.Windows.Forms.Label
        Me.Label034 = New System.Windows.Forms.Label
        Me.Label033 = New System.Windows.Forms.Label
        Me.Label032 = New System.Windows.Forms.Label
        Me.Label031 = New System.Windows.Forms.Label
        Me.Label030 = New System.Windows.Forms.Label
        Me.Label029 = New System.Windows.Forms.Label
        Me.Label028 = New System.Windows.Forms.Label
        Me.Label027 = New System.Windows.Forms.Label
        Me.Label026 = New System.Windows.Forms.Label
        Me.Label025 = New System.Windows.Forms.Label
        Me.Label024 = New System.Windows.Forms.Label
        Me.Label023 = New System.Windows.Forms.Label
        Me.Label022 = New System.Windows.Forms.Label
        Me.Label021 = New System.Windows.Forms.Label
        Me.Label020 = New System.Windows.Forms.Label
        Me.Label019 = New System.Windows.Forms.Label
        Me.Label018 = New System.Windows.Forms.Label
        Me.Label017 = New System.Windows.Forms.Label
        Me.Label016 = New System.Windows.Forms.Label
        Me.Label015 = New System.Windows.Forms.Label
        Me.Label014 = New System.Windows.Forms.Label
        Me.Label013 = New System.Windows.Forms.Label
        Me.Label012 = New System.Windows.Forms.Label
        Me.Label011 = New System.Windows.Forms.Label
        Me.Label010 = New System.Windows.Forms.Label
        Me.Label009 = New System.Windows.Forms.Label
        Me.Label008 = New System.Windows.Forms.Label
        Me.Label007 = New System.Windows.Forms.Label
        Me.Label006 = New System.Windows.Forms.Label
        Me.Label005 = New System.Windows.Forms.Label
        Me.Label004 = New System.Windows.Forms.Label
        Me.Label003 = New System.Windows.Forms.Label
        Me.Label002 = New System.Windows.Forms.Label
        Me.Label40 = New System.Windows.Forms.Label
        Me.Label41 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.Label39 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridEx1 = New MrMax_Import.DataGridEx
        Me.DataGridBoolColumn1 = New System.Windows.Forms.DataGridBoolColumn
        Me.DataGridTextBoxColumn17 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn9 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn10 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn11 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn12 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn13 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn14 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn15 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn16 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label001 = New System.Windows.Forms.Label
        Me.msg = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button99 = New System.Windows.Forms.Button
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton3 = New System.Windows.Forms.RadioButton
        Me.Edit1 = New GrapeCity.Win.Input.Edit
        Me.Number2 = New GrapeCity.Win.Input.Number
        Me.Label43 = New System.Windows.Forms.Label
        Me.Label44 = New System.Windows.Forms.Label
        Me.Label46 = New System.Windows.Forms.Label
        Me.Label47 = New System.Windows.Forms.Label
        Me.Date1 = New GrapeCity.Win.Input.Date
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        CType(Me.Number1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RadioButton5
        '
        Me.RadioButton5.Location = New System.Drawing.Point(712, 244)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(120, 24)
        Me.RadioButton5.TabIndex = 1368
        Me.RadioButton5.Text = "エアコン保証へ修正"
        '
        'Label048
        '
        Me.Label048.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label048.Location = New System.Drawing.Point(612, 280)
        Me.Label048.Name = "Label048"
        Me.Label048.Size = New System.Drawing.Size(68, 20)
        Me.Label048.TabIndex = 1463
        Me.Label048.Text = "Label048"
        Me.Label048.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label45
        '
        Me.Label45.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(64, Byte), CType(0, Byte))
        Me.Label45.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label45.ForeColor = System.Drawing.Color.White
        Me.Label45.Location = New System.Drawing.Point(500, 280)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(112, 20)
        Me.Label45.TabIndex = 1462
        Me.Label45.Text = "選択した保証料合計"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckBox2
        '
        Me.CheckBox2.Location = New System.Drawing.Point(1019, 8)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(24, 16)
        Me.CheckBox2.TabIndex = 1461
        Me.CheckBox2.Visible = False
        '
        'CheckBox1
        '
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(1047, 8)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(24, 16)
        Me.CheckBox1.TabIndex = 1460
        Me.CheckBox1.Visible = False
        '
        'Number1
        '
        Me.Number1.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "0")
        Me.Number1.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number1.DropDownCalculator.Size = New System.Drawing.Size(192, 179)
        Me.Number1.Format = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number1.Location = New System.Drawing.Point(960, 248)
        Me.Number1.MaxValue = New Decimal(New Integer() {1410065407, 2, 0, 131072})
        Me.Number1.MinValue = New Decimal(New Integer() {1410065407, 2, 0, -2147352576})
        Me.Number1.Name = "Number1"
        Me.Number1.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number1.Size = New System.Drawing.Size(68, 20)
        Me.Number1.TabIndex = 1364
        Me.Number1.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number1.Value = Nothing
        '
        'RadioButton4
        '
        Me.RadioButton4.Checked = True
        Me.RadioButton4.Location = New System.Drawing.Point(852, 244)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(108, 24)
        Me.RadioButton4.TabIndex = 1363
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Text = "保証料修正"
        '
        'Label046
        '
        Me.Label046.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label046.Location = New System.Drawing.Point(875, 172)
        Me.Label046.Name = "Label046"
        Me.Label046.Size = New System.Drawing.Size(68, 20)
        Me.Label046.TabIndex = 1459
        Me.Label046.Text = "Label046"
        Me.Label046.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.Color.Navy
        Me.Label42.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label42.ForeColor = System.Drawing.Color.White
        Me.Label42.Location = New System.Drawing.Point(639, 112)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(84, 20)
        Me.Label42.TabIndex = 1458
        Me.Label42.Text = "税区分"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label042
        '
        Me.Label042.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label042.Location = New System.Drawing.Point(875, 92)
        Me.Label042.Name = "Label042"
        Me.Label042.Size = New System.Drawing.Size(68, 20)
        Me.Label042.TabIndex = 1457
        Me.Label042.Text = "Label042"
        Me.Label042.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label043
        '
        Me.Label043.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label043.Location = New System.Drawing.Point(875, 112)
        Me.Label043.Name = "Label043"
        Me.Label043.Size = New System.Drawing.Size(68, 20)
        Me.Label043.TabIndex = 1456
        Me.Label043.Text = "Label043"
        Me.Label043.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label044
        '
        Me.Label044.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label044.Location = New System.Drawing.Point(875, 132)
        Me.Label044.Name = "Label044"
        Me.Label044.Size = New System.Drawing.Size(68, 20)
        Me.Label044.TabIndex = 1455
        Me.Label044.Text = "Label044"
        Me.Label044.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label045
        '
        Me.Label045.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label045.Location = New System.Drawing.Point(875, 152)
        Me.Label045.Name = "Label045"
        Me.Label045.Size = New System.Drawing.Size(68, 20)
        Me.Label045.TabIndex = 1454
        Me.Label045.Text = "Label045"
        Me.Label045.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label041
        '
        Me.Label041.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label041.Location = New System.Drawing.Point(875, 72)
        Me.Label041.Name = "Label041"
        Me.Label041.Size = New System.Drawing.Size(68, 20)
        Me.Label041.TabIndex = 1453
        Me.Label041.Text = "Label041"
        Me.Label041.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label040
        '
        Me.Label040.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label040.Location = New System.Drawing.Point(875, 52)
        Me.Label040.Name = "Label040"
        Me.Label040.Size = New System.Drawing.Size(68, 20)
        Me.Label040.TabIndex = 1452
        Me.Label040.Text = "Label040"
        Me.Label040.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label039
        '
        Me.Label039.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label039.Location = New System.Drawing.Point(723, 212)
        Me.Label039.Name = "Label039"
        Me.Label039.Size = New System.Drawing.Size(68, 20)
        Me.Label039.TabIndex = 1451
        Me.Label039.Text = "Label039"
        Me.Label039.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label038
        '
        Me.Label038.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label038.Location = New System.Drawing.Point(955, 192)
        Me.Label038.Name = "Label038"
        Me.Label038.Size = New System.Drawing.Size(68, 20)
        Me.Label038.TabIndex = 1450
        Me.Label038.Text = "Label038"
        Me.Label038.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label038.Visible = False
        '
        'Label037
        '
        Me.Label037.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label037.Location = New System.Drawing.Point(723, 192)
        Me.Label037.Name = "Label037"
        Me.Label037.Size = New System.Drawing.Size(68, 20)
        Me.Label037.TabIndex = 1449
        Me.Label037.Text = "Label037"
        Me.Label037.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label036
        '
        Me.Label036.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label036.Location = New System.Drawing.Point(723, 172)
        Me.Label036.Name = "Label036"
        Me.Label036.Size = New System.Drawing.Size(68, 20)
        Me.Label036.TabIndex = 1448
        Me.Label036.Text = "Label036"
        Me.Label036.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label035
        '
        Me.Label035.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label035.Location = New System.Drawing.Point(723, 152)
        Me.Label035.Name = "Label035"
        Me.Label035.Size = New System.Drawing.Size(68, 20)
        Me.Label035.TabIndex = 1447
        Me.Label035.Text = "Label035"
        Me.Label035.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label034
        '
        Me.Label034.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label034.Location = New System.Drawing.Point(723, 132)
        Me.Label034.Name = "Label034"
        Me.Label034.Size = New System.Drawing.Size(68, 20)
        Me.Label034.TabIndex = 1446
        Me.Label034.Text = "Label034"
        Me.Label034.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label033
        '
        Me.Label033.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label033.Location = New System.Drawing.Point(723, 112)
        Me.Label033.Name = "Label033"
        Me.Label033.Size = New System.Drawing.Size(68, 20)
        Me.Label033.TabIndex = 1445
        Me.Label033.Text = "Label033"
        Me.Label033.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label032
        '
        Me.Label032.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label032.Location = New System.Drawing.Point(955, 212)
        Me.Label032.Name = "Label032"
        Me.Label032.Size = New System.Drawing.Size(68, 20)
        Me.Label032.TabIndex = 1444
        Me.Label032.Text = "Label032"
        Me.Label032.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label032.Visible = False
        '
        'Label031
        '
        Me.Label031.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label031.Location = New System.Drawing.Point(723, 92)
        Me.Label031.Name = "Label031"
        Me.Label031.Size = New System.Drawing.Size(68, 20)
        Me.Label031.TabIndex = 1443
        Me.Label031.Text = "Label031"
        Me.Label031.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label030
        '
        Me.Label030.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label030.Location = New System.Drawing.Point(723, 72)
        Me.Label030.Name = "Label030"
        Me.Label030.Size = New System.Drawing.Size(68, 20)
        Me.Label030.TabIndex = 1442
        Me.Label030.Text = "Label030"
        Me.Label030.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label029
        '
        Me.Label029.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label029.Location = New System.Drawing.Point(495, 152)
        Me.Label029.Name = "Label029"
        Me.Label029.Size = New System.Drawing.Size(144, 20)
        Me.Label029.TabIndex = 1441
        Me.Label029.Text = "Label029"
        Me.Label029.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label028
        '
        Me.Label028.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label028.Location = New System.Drawing.Point(495, 132)
        Me.Label028.Name = "Label028"
        Me.Label028.Size = New System.Drawing.Size(144, 20)
        Me.Label028.TabIndex = 1440
        Me.Label028.Text = "Label028"
        Me.Label028.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label027
        '
        Me.Label027.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label027.Location = New System.Drawing.Point(495, 92)
        Me.Label027.Name = "Label027"
        Me.Label027.Size = New System.Drawing.Size(144, 20)
        Me.Label027.TabIndex = 1439
        Me.Label027.Text = "Label027"
        Me.Label027.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label026
        '
        Me.Label026.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label026.Location = New System.Drawing.Point(495, 52)
        Me.Label026.Name = "Label026"
        Me.Label026.Size = New System.Drawing.Size(144, 20)
        Me.Label026.TabIndex = 1438
        Me.Label026.Text = "Label026"
        Me.Label026.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label025
        '
        Me.Label025.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label025.Location = New System.Drawing.Point(495, 212)
        Me.Label025.Name = "Label025"
        Me.Label025.Size = New System.Drawing.Size(144, 20)
        Me.Label025.TabIndex = 1437
        Me.Label025.Text = "Label025"
        Me.Label025.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label024
        '
        Me.Label024.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label024.Location = New System.Drawing.Point(495, 192)
        Me.Label024.Name = "Label024"
        Me.Label024.Size = New System.Drawing.Size(144, 20)
        Me.Label024.TabIndex = 1436
        Me.Label024.Text = "Label024"
        Me.Label024.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label023
        '
        Me.Label023.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label023.Location = New System.Drawing.Point(495, 172)
        Me.Label023.Name = "Label023"
        Me.Label023.Size = New System.Drawing.Size(144, 20)
        Me.Label023.TabIndex = 1435
        Me.Label023.Text = "Label023"
        Me.Label023.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label022
        '
        Me.Label022.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label022.Location = New System.Drawing.Point(495, 112)
        Me.Label022.Name = "Label022"
        Me.Label022.Size = New System.Drawing.Size(144, 20)
        Me.Label022.TabIndex = 1434
        Me.Label022.Text = "Label022"
        Me.Label022.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label021
        '
        Me.Label021.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label021.Location = New System.Drawing.Point(495, 72)
        Me.Label021.Name = "Label021"
        Me.Label021.Size = New System.Drawing.Size(144, 20)
        Me.Label021.TabIndex = 1433
        Me.Label021.Text = "Label021"
        Me.Label021.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label020
        '
        Me.Label020.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label020.Location = New System.Drawing.Point(495, 32)
        Me.Label020.Name = "Label020"
        Me.Label020.Size = New System.Drawing.Size(144, 20)
        Me.Label020.TabIndex = 1432
        Me.Label020.Text = "Label020"
        Me.Label020.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label019
        '
        Me.Label019.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label019.Location = New System.Drawing.Point(295, 92)
        Me.Label019.Name = "Label019"
        Me.Label019.Size = New System.Drawing.Size(116, 20)
        Me.Label019.TabIndex = 1431
        Me.Label019.Text = "Label019"
        Me.Label019.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label018
        '
        Me.Label018.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label018.Location = New System.Drawing.Point(95, 32)
        Me.Label018.Name = "Label018"
        Me.Label018.Size = New System.Drawing.Size(116, 20)
        Me.Label018.TabIndex = 1430
        Me.Label018.Text = "Label018"
        Me.Label018.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label017
        '
        Me.Label017.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label017.Location = New System.Drawing.Point(723, 52)
        Me.Label017.Name = "Label017"
        Me.Label017.Size = New System.Drawing.Size(68, 20)
        Me.Label017.TabIndex = 1429
        Me.Label017.Text = "Label017"
        Me.Label017.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label016
        '
        Me.Label016.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label016.Location = New System.Drawing.Point(723, 32)
        Me.Label016.Name = "Label016"
        Me.Label016.Size = New System.Drawing.Size(68, 20)
        Me.Label016.TabIndex = 1428
        Me.Label016.Text = "Label016"
        Me.Label016.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label015
        '
        Me.Label015.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label015.Location = New System.Drawing.Point(295, 112)
        Me.Label015.Name = "Label015"
        Me.Label015.Size = New System.Drawing.Size(116, 20)
        Me.Label015.TabIndex = 1427
        Me.Label015.Text = "Label015"
        Me.Label015.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label014
        '
        Me.Label014.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label014.Location = New System.Drawing.Point(95, 212)
        Me.Label014.Name = "Label014"
        Me.Label014.Size = New System.Drawing.Size(316, 20)
        Me.Label014.TabIndex = 1426
        Me.Label014.Text = "Label014"
        Me.Label014.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label013
        '
        Me.Label013.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label013.Location = New System.Drawing.Point(95, 192)
        Me.Label013.Name = "Label013"
        Me.Label013.Size = New System.Drawing.Size(316, 20)
        Me.Label013.TabIndex = 1425
        Me.Label013.Text = "Label013"
        Me.Label013.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label012
        '
        Me.Label012.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label012.Location = New System.Drawing.Point(95, 172)
        Me.Label012.Name = "Label012"
        Me.Label012.Size = New System.Drawing.Size(316, 20)
        Me.Label012.TabIndex = 1424
        Me.Label012.Text = "Label012"
        Me.Label012.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label011
        '
        Me.Label011.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label011.Location = New System.Drawing.Point(95, 152)
        Me.Label011.Name = "Label011"
        Me.Label011.Size = New System.Drawing.Size(316, 20)
        Me.Label011.TabIndex = 1423
        Me.Label011.Text = "Label011"
        Me.Label011.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label010
        '
        Me.Label010.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label010.Location = New System.Drawing.Point(95, 132)
        Me.Label010.Name = "Label010"
        Me.Label010.Size = New System.Drawing.Size(316, 20)
        Me.Label010.TabIndex = 1422
        Me.Label010.Text = "Label010"
        Me.Label010.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label009
        '
        Me.Label009.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label009.Location = New System.Drawing.Point(95, 112)
        Me.Label009.Name = "Label009"
        Me.Label009.Size = New System.Drawing.Size(116, 20)
        Me.Label009.TabIndex = 1421
        Me.Label009.Text = "Label009"
        Me.Label009.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label008
        '
        Me.Label008.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label008.Location = New System.Drawing.Point(95, 92)
        Me.Label008.Name = "Label008"
        Me.Label008.Size = New System.Drawing.Size(116, 20)
        Me.Label008.TabIndex = 1420
        Me.Label008.Text = "Label008"
        Me.Label008.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label007
        '
        Me.Label007.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label007.Location = New System.Drawing.Point(95, 72)
        Me.Label007.Name = "Label007"
        Me.Label007.Size = New System.Drawing.Size(116, 20)
        Me.Label007.TabIndex = 1419
        Me.Label007.Text = "Label007"
        Me.Label007.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label006
        '
        Me.Label006.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label006.Location = New System.Drawing.Point(95, 52)
        Me.Label006.Name = "Label006"
        Me.Label006.Size = New System.Drawing.Size(116, 20)
        Me.Label006.TabIndex = 1418
        Me.Label006.Text = "Label006"
        Me.Label006.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label005
        '
        Me.Label005.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label005.Location = New System.Drawing.Point(295, 72)
        Me.Label005.Name = "Label005"
        Me.Label005.Size = New System.Drawing.Size(116, 20)
        Me.Label005.TabIndex = 1417
        Me.Label005.Text = "Label005"
        Me.Label005.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label004
        '
        Me.Label004.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label004.Location = New System.Drawing.Point(295, 52)
        Me.Label004.Name = "Label004"
        Me.Label004.Size = New System.Drawing.Size(116, 20)
        Me.Label004.TabIndex = 1416
        Me.Label004.Text = "Label004"
        Me.Label004.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label003
        '
        Me.Label003.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label003.Location = New System.Drawing.Point(295, 32)
        Me.Label003.Name = "Label003"
        Me.Label003.Size = New System.Drawing.Size(116, 20)
        Me.Label003.TabIndex = 1415
        Me.Label003.Text = "Label003"
        Me.Label003.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label002
        '
        Me.Label002.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label002.Location = New System.Drawing.Point(95, 12)
        Me.Label002.Name = "Label002"
        Me.Label002.Size = New System.Drawing.Size(116, 20)
        Me.Label002.TabIndex = 1414
        Me.Label002.Text = "Label002"
        Me.Label002.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label40
        '
        Me.Label40.BackColor = System.Drawing.Color.Navy
        Me.Label40.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label40.ForeColor = System.Drawing.Color.White
        Me.Label40.Location = New System.Drawing.Point(791, 152)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(84, 20)
        Me.Label40.TabIndex = 1413
        Me.Label40.Text = "ERR_F"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label41
        '
        Me.Label41.BackColor = System.Drawing.Color.Navy
        Me.Label41.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label41.ForeColor = System.Drawing.Color.White
        Me.Label41.Location = New System.Drawing.Point(791, 172)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(84, 20)
        Me.Label41.TabIndex = 1412
        Me.Label41.Text = "法人"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label37
        '
        Me.Label37.BackColor = System.Drawing.Color.Navy
        Me.Label37.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label37.ForeColor = System.Drawing.Color.White
        Me.Label37.Location = New System.Drawing.Point(791, 92)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(84, 20)
        Me.Label37.TabIndex = 1411
        Me.Label37.Text = "sprice"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label38
        '
        Me.Label38.BackColor = System.Drawing.Color.Navy
        Me.Label38.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label38.ForeColor = System.Drawing.Color.White
        Me.Label38.Location = New System.Drawing.Point(791, 112)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(84, 20)
        Me.Label38.TabIndex = 1410
        Me.Label38.Text = "WSEQ1"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.Color.Navy
        Me.Label39.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label39.ForeColor = System.Drawing.Color.White
        Me.Label39.Location = New System.Drawing.Point(791, 132)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(84, 20)
        Me.Label39.TabIndex = 1409
        Me.Label39.Text = "WSEQ2"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.Color.Navy
        Me.Label34.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label34.ForeColor = System.Drawing.Color.White
        Me.Label34.Location = New System.Drawing.Point(639, 212)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(84, 20)
        Me.Label34.TabIndex = 1408
        Me.Label34.Text = "分割数量"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.Navy
        Me.Label35.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label35.ForeColor = System.Drawing.Color.White
        Me.Label35.Location = New System.Drawing.Point(791, 52)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(84, 20)
        Me.Label35.TabIndex = 1407
        Me.Label35.Text = "分割元SEQ"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label36
        '
        Me.Label36.BackColor = System.Drawing.Color.Navy
        Me.Label36.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label36.ForeColor = System.Drawing.Color.White
        Me.Label36.Location = New System.Drawing.Point(791, 72)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(84, 20)
        Me.Label36.TabIndex = 1406
        Me.Label36.Text = "赤黒SEQ"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.Color.Navy
        Me.Label31.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label31.ForeColor = System.Drawing.Color.White
        Me.Label31.Location = New System.Drawing.Point(639, 172)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(84, 20)
        Me.Label31.TabIndex = 1405
        Me.Label31.Text = "値引額"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.Color.Navy
        Me.Label32.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label32.ForeColor = System.Drawing.Color.White
        Me.Label32.Location = New System.Drawing.Point(639, 192)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(84, 20)
        Me.Label32.TabIndex = 1404
        Me.Label32.Text = "単価2"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.Navy
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label33.ForeColor = System.Drawing.Color.White
        Me.Label33.Location = New System.Drawing.Point(871, 192)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(84, 20)
        Me.Label33.TabIndex = 1403
        Me.Label33.Text = "処理日"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label33.Visible = False
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.Navy
        Me.Label30.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label30.ForeColor = System.Drawing.Color.White
        Me.Label30.Location = New System.Drawing.Point(639, 152)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(84, 20)
        Me.Label30.TabIndex = 1402
        Me.Label30.Text = "割引率"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.Navy
        Me.Label29.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label29.ForeColor = System.Drawing.Color.White
        Me.Label29.Location = New System.Drawing.Point(639, 132)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(84, 20)
        Me.Label29.TabIndex = 1401
        Me.Label29.Text = "値引割引区分"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Navy
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(411, 212)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(84, 20)
        Me.Label21.TabIndex = 1400
        Me.Label21.Text = "ﾚｼｰﾄ"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Navy
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(411, 52)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(84, 20)
        Me.Label22.TabIndex = 1399
        Me.Label22.Text = "品名漢字"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Navy
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(411, 92)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(84, 20)
        Me.Label23.TabIndex = 1398
        Me.Label23.Text = "型番漢字"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Navy
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(411, 132)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(84, 20)
        Me.Label24.TabIndex = 1397
        Me.Label24.Text = "分類ｺｰﾄﾞ"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.Navy
        Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(411, 152)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(84, 20)
        Me.Label25.TabIndex = 1396
        Me.Label25.Text = "品種ｺｰﾄﾞ"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.Navy
        Me.Label26.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label26.ForeColor = System.Drawing.Color.White
        Me.Label26.Location = New System.Drawing.Point(639, 72)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(84, 20)
        Me.Label26.TabIndex = 1395
        Me.Label26.Text = "売上数"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.Navy
        Me.Label27.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label27.ForeColor = System.Drawing.Color.White
        Me.Label27.Location = New System.Drawing.Point(639, 92)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(84, 20)
        Me.Label27.TabIndex = 1394
        Me.Label27.Text = "ﾏｽﾀ単価"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.Navy
        Me.Label28.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label28.ForeColor = System.Drawing.Color.White
        Me.Label28.Location = New System.Drawing.Point(871, 212)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(84, 20)
        Me.Label28.TabIndex = 1393
        Me.Label28.Text = "単価"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label28.Visible = False
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Navy
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(411, 192)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(84, 20)
        Me.Label20.TabIndex = 1392
        Me.Label20.Text = "ｻｲｽﾞ"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Navy
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(411, 172)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(84, 20)
        Me.Label19.TabIndex = 1391
        Me.Label19.Text = "ｶﾗｰ"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Navy
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(411, 112)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(84, 20)
        Me.Label18.TabIndex = 1390
        Me.Label18.Text = "型番ｶﾅ"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Navy
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(411, 72)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(84, 20)
        Me.Label17.TabIndex = 1389
        Me.Label17.Text = "品名ｶﾅ"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Navy
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(411, 32)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(84, 20)
        Me.Label16.TabIndex = 1388
        Me.Label16.Text = "商品ｺｰﾄﾞ"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Navy
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(211, 92)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(84, 20)
        Me.Label15.TabIndex = 1387
        Me.Label15.Text = "行区分"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Navy
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(11, 32)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(84, 20)
        Me.Label14.TabIndex = 1386
        Me.Label14.Text = "行番号"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Navy
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(639, 52)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(84, 20)
        Me.Label13.TabIndex = 1385
        Me.Label13.Text = "削除ﾌﾗｸﾞ"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Navy
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(211, 112)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 20)
        Me.Label11.TabIndex = 1383
        Me.Label11.Text = "販売者ｺｰﾄﾞ"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGridEx1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridBoolColumn1, Me.DataGridTextBoxColumn17, Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8, Me.DataGridTextBoxColumn9, Me.DataGridTextBoxColumn10, Me.DataGridTextBoxColumn11, Me.DataGridTextBoxColumn12, Me.DataGridTextBoxColumn13, Me.DataGridTextBoxColumn14, Me.DataGridTextBoxColumn15, Me.DataGridTextBoxColumn16})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "02_売上データ_sub"
        '
        'DataGridEx1
        '
        Me.DataGridEx1.DataMember = ""
        Me.DataGridEx1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridEx1.Location = New System.Drawing.Point(7, 304)
        Me.DataGridEx1.Name = "DataGridEx1"
        Me.DataGridEx1.ReadOnly = True
        Me.DataGridEx1.RowHeaderWidth = 10
        Me.DataGridEx1.Size = New System.Drawing.Size(1068, 244)
        Me.DataGridEx1.TabIndex = 1362
        Me.DataGridEx1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridBoolColumn1
        '
        Me.DataGridBoolColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridBoolColumn1.FalseValue = False
        Me.DataGridBoolColumn1.HeaderText = "選択"
        Me.DataGridBoolColumn1.MappingName = "slc"
        Me.DataGridBoolColumn1.NullValue = CType(resources.GetObject("DataGridBoolColumn1.NullValue"), Object)
        Me.DataGridBoolColumn1.TrueValue = True
        Me.DataGridBoolColumn1.Width = 40
        '
        'DataGridTextBoxColumn17
        '
        Me.DataGridTextBoxColumn17.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn17.Format = ""
        Me.DataGridTextBoxColumn17.FormatInfo = Nothing
        Me.DataGridTextBoxColumn17.HeaderText = "伝票NO"
        Me.DataGridTextBoxColumn17.MappingName = "伝票NO"
        Me.DataGridTextBoxColumn17.Width = 90
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "行"
        Me.DataGridTextBoxColumn1.MappingName = "行番号"
        Me.DataGridTextBoxColumn1.ReadOnly = True
        Me.DataGridTextBoxColumn1.Width = 40
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "氏名"
        Me.DataGridTextBoxColumn2.MappingName = "氏名"
        Me.DataGridTextBoxColumn2.ReadOnly = True
        Me.DataGridTextBoxColumn2.Width = 75
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "商品ｺｰﾄﾞ"
        Me.DataGridTextBoxColumn3.MappingName = "商品ｺｰﾄﾞ"
        Me.DataGridTextBoxColumn3.ReadOnly = True
        Me.DataGridTextBoxColumn3.Width = 75
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "品名"
        Me.DataGridTextBoxColumn4.MappingName = "品名漢字"
        Me.DataGridTextBoxColumn4.ReadOnly = True
        Me.DataGridTextBoxColumn4.Width = 75
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "型番"
        Me.DataGridTextBoxColumn5.MappingName = "型番漢字"
        Me.DataGridTextBoxColumn5.ReadOnly = True
        Me.DataGridTextBoxColumn5.Width = 75
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "分類"
        Me.DataGridTextBoxColumn6.MappingName = "分類ｺｰﾄﾞ"
        Me.DataGridTextBoxColumn6.ReadOnly = True
        Me.DataGridTextBoxColumn6.Width = 40
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "品種"
        Me.DataGridTextBoxColumn7.MappingName = "品種ｺｰﾄﾞ"
        Me.DataGridTextBoxColumn7.ReadOnly = True
        Me.DataGridTextBoxColumn7.Width = 50
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn8.Format = "##,##0"
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "単価"
        Me.DataGridTextBoxColumn8.MappingName = "単価2"
        Me.DataGridTextBoxColumn8.ReadOnly = True
        Me.DataGridTextBoxColumn8.Width = 50
        '
        'DataGridTextBoxColumn9
        '
        Me.DataGridTextBoxColumn9.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn9.Format = ""
        Me.DataGridTextBoxColumn9.FormatInfo = Nothing
        Me.DataGridTextBoxColumn9.HeaderText = "SEQ"
        Me.DataGridTextBoxColumn9.MappingName = "SEQ"
        Me.DataGridTextBoxColumn9.ReadOnly = True
        Me.DataGridTextBoxColumn9.Width = 50
        '
        'DataGridTextBoxColumn10
        '
        Me.DataGridTextBoxColumn10.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn10.Format = ""
        Me.DataGridTextBoxColumn10.FormatInfo = Nothing
        Me.DataGridTextBoxColumn10.HeaderText = "数量"
        Me.DataGridTextBoxColumn10.MappingName = "分割数量"
        Me.DataGridTextBoxColumn10.ReadOnly = True
        Me.DataGridTextBoxColumn10.Width = 40
        '
        'DataGridTextBoxColumn11
        '
        Me.DataGridTextBoxColumn11.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn11.Format = ""
        Me.DataGridTextBoxColumn11.FormatInfo = Nothing
        Me.DataGridTextBoxColumn11.HeaderText = "分割元SEQ"
        Me.DataGridTextBoxColumn11.MappingName = "分割元SEQ"
        Me.DataGridTextBoxColumn11.ReadOnly = True
        Me.DataGridTextBoxColumn11.Width = 50
        '
        'DataGridTextBoxColumn12
        '
        Me.DataGridTextBoxColumn12.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn12.Format = ""
        Me.DataGridTextBoxColumn12.FormatInfo = Nothing
        Me.DataGridTextBoxColumn12.HeaderText = "赤黒SEQ"
        Me.DataGridTextBoxColumn12.MappingName = "赤黒SEQ"
        Me.DataGridTextBoxColumn12.ReadOnly = True
        Me.DataGridTextBoxColumn12.Width = 50
        '
        'DataGridTextBoxColumn13
        '
        Me.DataGridTextBoxColumn13.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn13.Format = "##,##0"
        Me.DataGridTextBoxColumn13.FormatInfo = Nothing
        Me.DataGridTextBoxColumn13.HeaderText = "sprice"
        Me.DataGridTextBoxColumn13.MappingName = "sprice"
        Me.DataGridTextBoxColumn13.Width = 50
        '
        'DataGridTextBoxColumn14
        '
        Me.DataGridTextBoxColumn14.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn14.Format = ""
        Me.DataGridTextBoxColumn14.FormatInfo = Nothing
        Me.DataGridTextBoxColumn14.HeaderText = "WSEQ1"
        Me.DataGridTextBoxColumn14.MappingName = "WSEQ1"
        Me.DataGridTextBoxColumn14.ReadOnly = True
        Me.DataGridTextBoxColumn14.Width = 50
        '
        'DataGridTextBoxColumn15
        '
        Me.DataGridTextBoxColumn15.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn15.Format = ""
        Me.DataGridTextBoxColumn15.FormatInfo = Nothing
        Me.DataGridTextBoxColumn15.HeaderText = "WSEQ2"
        Me.DataGridTextBoxColumn15.MappingName = "WSEQ2"
        Me.DataGridTextBoxColumn15.ReadOnly = True
        Me.DataGridTextBoxColumn15.Width = 50
        '
        'DataGridTextBoxColumn16
        '
        Me.DataGridTextBoxColumn16.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn16.Format = ""
        Me.DataGridTextBoxColumn16.FormatInfo = Nothing
        Me.DataGridTextBoxColumn16.HeaderText = "ERR_F"
        Me.DataGridTextBoxColumn16.MappingName = "ERR_F"
        Me.DataGridTextBoxColumn16.ReadOnly = True
        Me.DataGridTextBoxColumn16.Width = 40
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Navy
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(639, 32)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(84, 20)
        Me.Label12.TabIndex = 1384
        Me.Label12.Text = "完了日"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Navy
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(11, 132)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(84, 100)
        Me.Label10.TabIndex = 1382
        Me.Label10.Text = "住所"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Navy
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(11, 112)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 20)
        Me.Label9.TabIndex = 1381
        Me.Label9.Text = "郵便番号"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Navy
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(11, 92)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 20)
        Me.Label8.TabIndex = 1380
        Me.Label8.Text = "TEL2"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Navy
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(11, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 20)
        Me.Label7.TabIndex = 1379
        Me.Label7.Text = "TEL1"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Navy
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(11, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 20)
        Me.Label6.TabIndex = 1378
        Me.Label6.Text = "氏名"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Navy
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(211, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 20)
        Me.Label5.TabIndex = 1377
        Me.Label5.Text = "一般売掛区分"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Navy
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(211, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 20)
        Me.Label4.TabIndex = 1376
        Me.Label4.Text = "配送店ｺｰﾄﾞ"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Navy
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(211, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 20)
        Me.Label3.TabIndex = 1375
        Me.Label3.Text = "発行日"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Navy
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(11, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 20)
        Me.Label2.TabIndex = 1374
        Me.Label2.Text = "伝票NO"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(791, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 20)
        Me.Label1.TabIndex = 1373
        Me.Label1.Text = "SEQ"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label001
        '
        Me.Label001.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label001.Location = New System.Drawing.Point(875, 32)
        Me.Label001.Name = "Label001"
        Me.Label001.Size = New System.Drawing.Size(68, 20)
        Me.Label001.TabIndex = 1372
        Me.Label001.Text = "Label001"
        Me.Label001.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(80, 560)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(920, 16)
        Me.msg.TabIndex = 1371
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(8, 552)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(64, 32)
        Me.Button1.TabIndex = 1369
        Me.Button1.Text = "更　新"
        '
        'Button99
        '
        Me.Button99.BackColor = System.Drawing.SystemColors.Control
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.Location = New System.Drawing.Point(1004, 552)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(64, 32)
        Me.Button99.TabIndex = 1370
        Me.Button99.Text = "戻　る"
        '
        'RadioButton1
        '
        Me.RadioButton1.Location = New System.Drawing.Point(16, 240)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(120, 24)
        Me.RadioButton1.TabIndex = 1365
        Me.RadioButton1.Text = "赤黒照合"
        '
        'RadioButton2
        '
        Me.RadioButton2.Location = New System.Drawing.Point(140, 240)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(120, 24)
        Me.RadioButton2.TabIndex = 1366
        Me.RadioButton2.Text = "過去分修正"
        '
        'RadioButton3
        '
        Me.RadioButton3.Location = New System.Drawing.Point(848, 272)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(120, 24)
        Me.RadioButton3.TabIndex = 1367
        Me.RadioButton3.Text = "冷蔵庫保証へ修正"
        '
        'Edit1
        '
        Me.Edit1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Edit1.Location = New System.Drawing.Point(172, 280)
        Me.Edit1.Name = "Edit1"
        Me.Edit1.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit1.Size = New System.Drawing.Size(112, 20)
        Me.Edit1.TabIndex = 1464
        '
        'Number2
        '
        Me.Number2.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Number2.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("########0", "", "", "-", "", "", "0")
        Me.Number2.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number2.DropDownCalculator.Size = New System.Drawing.Size(192, 179)
        Me.Number2.Format = New GrapeCity.Win.Input.NumberFormat("########0", "", "", "-", "", "", "")
        Me.Number2.Location = New System.Drawing.Point(364, 280)
        Me.Number2.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number2.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number2.Name = "Number2"
        Me.Number2.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number2.Size = New System.Drawing.Size(68, 20)
        Me.Number2.TabIndex = 1465
        Me.Number2.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number2.Value = Nothing
        '
        'Label43
        '
        Me.Label43.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(0, Byte), CType(0, Byte))
        Me.Label43.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label43.ForeColor = System.Drawing.Color.White
        Me.Label43.Location = New System.Drawing.Point(96, 280)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(76, 20)
        Me.Label43.TabIndex = 1466
        Me.Label43.Text = "伝票NO"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label44
        '
        Me.Label44.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(0, Byte), CType(0, Byte))
        Me.Label44.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label44.ForeColor = System.Drawing.Color.White
        Me.Label44.Location = New System.Drawing.Point(288, 280)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(76, 20)
        Me.Label44.TabIndex = 1467
        Me.Label44.Text = "SEQ"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label46
        '
        Me.Label46.BackColor = System.Drawing.Color.Navy
        Me.Label46.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label46.ForeColor = System.Drawing.Color.White
        Me.Label46.Location = New System.Drawing.Point(12, 280)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(76, 20)
        Me.Label46.TabIndex = 1468
        Me.Label46.Text = "絞込み条件"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label47
        '
        Me.Label47.BackColor = System.Drawing.Color.Navy
        Me.Label47.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label47.ForeColor = System.Drawing.Color.White
        Me.Label47.Location = New System.Drawing.Point(260, 240)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(76, 24)
        Me.Label47.TabIndex = 1470
        Me.Label47.Text = "計上年月"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date1
        '
        Me.Date1.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyy/MM", "", "")
        Me.Date1.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date1.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date1.Format = New GrapeCity.Win.Input.DateFormat("yyy/MM", "", "")
        Me.Date1.Location = New System.Drawing.Point(336, 240)
        Me.Date1.Name = "Date1"
        Me.Date1.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date1.Size = New System.Drawing.Size(72, 24)
        Me.Date1.TabIndex = 1469
        Me.Date1.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date1.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Date1.Value = New GrapeCity.Win.Input.DateTimeEx(New Date(2010, 2, 8, 12, 17, 22, 0))
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.Control
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button2.Location = New System.Drawing.Point(412, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(104, 20)
        Me.Button2.TabIndex = 1471
        Me.Button2.Text = "TV保証へ修正"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.Control
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button3.Location = New System.Drawing.Point(520, 0)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(104, 20)
        Me.Button3.TabIndex = 1472
        Me.Button3.Text = "洗濯機保証へ修正"
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.Control
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button4.Location = New System.Drawing.Point(628, 0)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(104, 20)
        Me.Button4.TabIndex = 1473
        Me.Button4.Text = "冷蔵庫保証へ修正"
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.SystemColors.Control
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button5.Location = New System.Drawing.Point(736, 0)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(104, 20)
        Me.Button5.TabIndex = 1474
        Me.Button5.Text = "エアコン保証へ修正"
        '
        'Form3_sub2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(1082, 588)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label47)
        Me.Controls.Add(Me.Date1)
        Me.Controls.Add(Me.Label46)
        Me.Controls.Add(Me.Label44)
        Me.Controls.Add(Me.Label43)
        Me.Controls.Add(Me.Number2)
        Me.Controls.Add(Me.Edit1)
        Me.Controls.Add(Me.RadioButton5)
        Me.Controls.Add(Me.Label048)
        Me.Controls.Add(Me.Label45)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Number1)
        Me.Controls.Add(Me.RadioButton4)
        Me.Controls.Add(Me.Label046)
        Me.Controls.Add(Me.Label42)
        Me.Controls.Add(Me.Label042)
        Me.Controls.Add(Me.Label043)
        Me.Controls.Add(Me.Label044)
        Me.Controls.Add(Me.Label045)
        Me.Controls.Add(Me.Label041)
        Me.Controls.Add(Me.Label040)
        Me.Controls.Add(Me.Label039)
        Me.Controls.Add(Me.Label038)
        Me.Controls.Add(Me.Label037)
        Me.Controls.Add(Me.Label036)
        Me.Controls.Add(Me.Label035)
        Me.Controls.Add(Me.Label034)
        Me.Controls.Add(Me.Label033)
        Me.Controls.Add(Me.Label032)
        Me.Controls.Add(Me.Label031)
        Me.Controls.Add(Me.Label030)
        Me.Controls.Add(Me.Label029)
        Me.Controls.Add(Me.Label028)
        Me.Controls.Add(Me.Label027)
        Me.Controls.Add(Me.Label026)
        Me.Controls.Add(Me.Label025)
        Me.Controls.Add(Me.Label024)
        Me.Controls.Add(Me.Label023)
        Me.Controls.Add(Me.Label022)
        Me.Controls.Add(Me.Label021)
        Me.Controls.Add(Me.Label020)
        Me.Controls.Add(Me.Label019)
        Me.Controls.Add(Me.Label018)
        Me.Controls.Add(Me.Label017)
        Me.Controls.Add(Me.Label016)
        Me.Controls.Add(Me.Label015)
        Me.Controls.Add(Me.Label014)
        Me.Controls.Add(Me.Label013)
        Me.Controls.Add(Me.Label012)
        Me.Controls.Add(Me.Label011)
        Me.Controls.Add(Me.Label010)
        Me.Controls.Add(Me.Label009)
        Me.Controls.Add(Me.Label008)
        Me.Controls.Add(Me.Label007)
        Me.Controls.Add(Me.Label006)
        Me.Controls.Add(Me.Label005)
        Me.Controls.Add(Me.Label004)
        Me.Controls.Add(Me.Label003)
        Me.Controls.Add(Me.Label002)
        Me.Controls.Add(Me.Label40)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.DataGridEx1)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label001)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button99)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Form3_sub2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "エラー修正(ｲﾚｷﾞｭﾗｰ)"
        CType(Me.Number1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub Form3_sub2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        msg.Text = Nothing
        Label001.Text = P_SEQ
        dsp_set()
    End Sub

    Sub dsp_set()

        DsList1.Clear()
        strSQL = "SELECT * FROM [02_売上データ] WHERE (SEQ = " & P_SEQ & ")"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(DsList1, "02_売上データ")
        DB_CLOSE()
        DtView1 = New DataView(DsList1.Tables("02_売上データ"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Label002.Text = DtView1(0)("伝票NO")
            Label003.Text = DtView1(0)("発行日")
            Label004.Text = DtView1(0)("配送店ｺｰﾄﾞ")
            Label005.Text = DtView1(0)("一般売掛区分")
            Label006.Text = DtView1(0)("氏名")
            Label007.Text = DtView1(0)("TEL1")
            Label008.Text = DtView1(0)("TEL2")
            Label009.Text = DtView1(0)("郵便番号")
            Label010.Text = DtView1(0)("住所1")
            Label011.Text = DtView1(0)("住所2")
            Label012.Text = DtView1(0)("住所3")
            Label013.Text = DtView1(0)("住所4")
            Label014.Text = DtView1(0)("住所5")
            Label015.Text = DtView1(0)("販売者ｺｰﾄﾞ")
            Label016.Text = DtView1(0)("完了日")
            Label017.Text = DtView1(0)("削除ﾌﾗｸﾞ")
            Label018.Text = DtView1(0)("行番号")
            Label019.Text = DtView1(0)("行区分")
            Label020.Text = DtView1(0)("商品ｺｰﾄﾞ")
            Label021.Text = DtView1(0)("品名ｶﾅ")
            Label022.Text = DtView1(0)("型番ｶﾅ")
            Label023.Text = DtView1(0)("ｶﾗｰ")
            Label024.Text = DtView1(0)("ｻｲｽﾞ")
            Label025.Text = DtView1(0)("ﾚｼｰﾄ")
            Label026.Text = DtView1(0)("品名漢字")
            Label027.Text = DtView1(0)("型番漢字")
            Label028.Text = DtView1(0)("分類ｺｰﾄﾞ")
            Label029.Text = DtView1(0)("品種ｺｰﾄﾞ")
            Label030.Text = DtView1(0)("売上数")
            Label031.Text = DtView1(0)("ﾏｽﾀ単価")
            Label032.Text = DtView1(0)("単価")
            Label033.Text = DtView1(0)("税区分")
            Label034.Text = DtView1(0)("値引割引区分")
            Label035.Text = DtView1(0)("割引率")
            Label036.Text = DtView1(0)("値引額")
            Label037.Text = DtView1(0)("単価2")
            Label038.Text = DtView1(0)("処理日")
            Label039.Text = DtView1(0)("分割数量")
            Label040.Text = DtView1(0)("分割元SEQ")
            Label041.Text = DtView1(0)("赤黒SEQ")
            Label042.Text = DtView1(0)("sprice")
            Label043.Text = DtView1(0)("WSEQ1")
            Label044.Text = DtView1(0)("WSEQ2")
            Label045.Text = DtView1(0)("ERR_F")
            Label046.Text = DtView1(0)("法人")

            Label048.Text = "0"
            CHG_F = "0"
            Number1.Value = DtView1(0)("単価2")
            CHG_F = "1"
        End If

        DtGrd_set()

        Dim tbl As New DataTable
        tbl = DG_DsList1.Tables("02_売上データ_sub")
        DataGridEx1.DataSource = tbl

        '新しい行の追加を禁止する
        Dim cm As CurrencyManager
        cm = CType(Me.BindingContext(DataGridEx1.DataSource), CurrencyManager)
        Dim dv As DataView = CType(cm.List, DataView)
        dv.AllowNew = False

    End Sub

    Sub DtGrd_set()
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        DG_DsList1.Clear()
        strSQL = "SELECT [02_売上データ].法人 AS slc, [02_売上データ].*"
        strSQL += ", [02_売上データ].単価2 * 0.05 AS wrn_fee, M08_KBN_CAT.ITEM_NAME AS 品種名"
        strSQL += " FROM [02_売上データ] LEFT OUTER JOIN M08_KBN_CAT ON [02_売上データ].[品種ｺｰﾄﾞ] = M08_KBN_CAT.CAT_CODE"
        strSQL += " WHERE ([02_売上データ].SEQ <> 0)"
        If Edit1.Text <> Nothing Then strSQL += " AND ([02_売上データ].伝票NO LIKE '" & Edit1.Text & "%')"
        If Number2.Value <> 0 Then strSQL += " AND ([02_売上データ].SEQ = " & Number2.Value & ")"

        If RadioButton1.Checked = True Then '赤黒照合
            strSQL += " AND ([02_売上データ].[分類ｺｰﾄﾞ] = '" & Label028.Text & "')"
            strSQL += " AND ([02_売上データ].単価2 = " & CInt(Label037.Text) & ")"
        End If

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        r = DaList1.Fill(DG_DsList1, "02_売上データ_sub")
        DB_CLOSE()

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub


    '********************************************************************
    '**  RadioButton Click
    '********************************************************************
    Private Sub RadioButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton1.Click
        DtGrd_set()
    End Sub


    '********************************************************************
    '**  TextChanged
    '********************************************************************
    Private Sub Edit1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit1.TextChanged
        DtGrd_set()
    End Sub

    Private Sub Number2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number2.TextChanged
        DtGrd_set()
    End Sub

    Private Sub DataGridEx1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DataGridEx1.Paint
        If DataGridEx1.CurrentRowIndex >= 0 Then
            DataGridEx1.Select(DataGridEx1.CurrentRowIndex)
        End If
    End Sub

    Private Sub DataGridEx1_CmdKeyEvent(ByVal keyData As System.Windows.Forms.Keys, ByRef Cancel As Boolean) Handles DataGridEx1.CmdKeyEvent
        If DataGridEx1.CurrentRowIndex <= r - 1 Then
            Select Case keyData
                Case Is = Keys.Return
                Case Is = Keys.Space
                    If DataGridEx1(DataGridEx1.CurrentRowIndex, 0) = "False" Then
                        DataGridEx1(DataGridEx1.CurrentRowIndex, 0) = CheckBox1.Checked
                        Label048.Text = Format(CInt(Label048.Text) + Fix(DataGridEx1(DataGridEx1.CurrentRowIndex, 9) * 0.05), "##,##0")
                    Else
                        DataGridEx1(DataGridEx1.CurrentRowIndex, 0) = CheckBox2.Checked
                        Label048.Text = Format(CInt(Label048.Text) - Fix(DataGridEx1(DataGridEx1.CurrentRowIndex, 9) * 0.05), "##,##0")
                        If CInt(Label048.Text) < 0 Then Label048.Text = "0"
                    End If
                Case Is = Keys.Delete
                Case Is = Keys.Right
                Case Is = Keys.Left
            End Select
        End If
    End Sub

    Private Sub DataGridEx1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridEx1.MouseUp
        Dim hitinfo As DataGrid.HitTestInfo

        Try
            hitinfo = (CType(sender, DataGrid).HitTest(e.X, e.Y))

            If hitinfo.Column = 0 Then  'ﾁｪｯｸﾎﾞｯｸｽ ｸﾘｯｸ
                If DataGridEx1.CurrentRowIndex <= r - 1 Then
                    If DataGridEx1(DataGridEx1.CurrentRowIndex, 0) = "False" Then
                        DataGridEx1(DataGridEx1.CurrentRowIndex, 0) = CheckBox1.Checked
                        Label048.Text = Format(CInt(Label048.Text) + Fix(DataGridEx1(DataGridEx1.CurrentRowIndex, 9) * 0.05), "##,##0")
                    Else
                        DataGridEx1(DataGridEx1.CurrentRowIndex, 0) = CheckBox2.Checked
                        Label048.Text = Format(CInt(Label048.Text) - Fix(DataGridEx1(DataGridEx1.CurrentRowIndex, 9) * 0.05), "##,##0")
                        If CInt(Label048.Text) < 0 Then Label048.Text = "0"
                    End If
                End If
            End If
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '********************************************************************
    '**  更新
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        F_chk()
        If Err_F = "0" Then

            If RadioButton1.Checked = True Then  '赤黒照合
                UPD_01()
            End If
            If RadioButton2.Checked = True Then '過去分修正
                UPD_02()
            End If

            dsp_set()
            msg.Text = "修正しました。"
            Button1.Enabled = False
            P_rtn = "1"
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Sub F_chk()
        Err_F = "0"

        If RadioButton1.Checked = True Then '赤黒照合
            strSQL = "slc = 1"
            DtView1 = New DataView(DG_DsList1.Tables("02_売上データ_sub"), strSQL, "", DataViewRowState.CurrentRows)
            Select Case DtView1.Count
                Case Is = 0
                    msg.Text = "選択なし"
                    Err_F = "1" : Exit Sub
                Case Is = 1

                Case Else
                    msg.Text = "複数選択不可"
                    Err_F = "1" : Exit Sub
            End Select
        End If

        If RadioButton2.Checked = True Then '過去分修正
            If Date1.Number = 0 Then
                msg.Text = "計上年月を入力してください。"
                Err_F = "1" : Exit Sub
            End If
        End If

        'If CInt(Label048.Text) > Number1.Value + 1 Or CInt(Label048.Text) < Number1.Value - 1 Then
        '    msg.Text = "データアンマッチ(金額)"
        '    Err_F = "1" : Exit Sub
        'End If

        'strSQL = "slc = 1"
        'DtView1 = New DataView(DsList1.Tables("02_売上データ_sub"), strSQL, "", DataViewRowState.CurrentRows)
        'For i = 0 To DtView1.Count - 1
        '    If DtView1(0)("商品ｺｰﾄﾞ03") <> Label020.Text Then
        '        msg.Text = "データアンマッチ(商品ｺｰﾄﾞ)"
        '        Err_F = "1" : Exit Sub
        '    End If
        'Next

    End Sub

    Sub UPD_01() '赤黒照合
        DB_OPEN()

        strSQL = "slc = 1"
        DtView1 = New DataView(DG_DsList1.Tables("02_売上データ_sub"), strSQL, "SEQ", DataViewRowState.CurrentRows)

        '選択したデータが処理済みなら繋がりを切る
        If DtView1(0)("WSEQ1") <> 0 Or DtView1(0)("WSEQ2") <> 0 Or DtView1(0)("赤黒SEQ") <> 0 Then
            strSQL = "UPDATE [02_売上データ]"
            strSQL += " SET 赤黒SEQ = 0"
            strSQL += ", wSEQ1 = 0"
            strSQL += ", wSEQ2 = 0"
            strSQL += " WHERE (SEQ = " & DtView1(0)("SEQ") & ")"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.ExecuteNonQuery()

            If DtView1(0)("WSEQ1") <> 0 Then
                strSQL = "UPDATE [02_売上データ]"
                strSQL += " SET 赤黒SEQ = 0"
                strSQL += ", wSEQ1 = 0"
                strSQL += ", wSEQ2 = 0"
                strSQL += " WHERE (SEQ = " & DtView1(0)("WSEQ1") & ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.ExecuteNonQuery()
            End If

            If DtView1(0)("WSEQ2") <> 0 Then
                strSQL = "UPDATE [02_売上データ]"
                strSQL += " SET 赤黒SEQ = 0"
                strSQL += ", wSEQ1 = 0"
                strSQL += ", wSEQ2 = 0"
                strSQL += " WHERE (SEQ = " & DtView1(0)("WSEQ2") & ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.ExecuteNonQuery()
            End If

            If DtView1(0)("赤黒SEQ") <> 0 Then
                strSQL = "UPDATE [02_売上データ]"
                strSQL += " SET 赤黒SEQ = 0"
                strSQL += ", wSEQ1 = 0"
                strSQL += ", wSEQ2 = 0"
                strSQL += " WHERE (SEQ = " & DtView1(0)("赤黒SEQ") & ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.ExecuteNonQuery()
            End If
        End If

        strSQL = "UPDATE [02_売上データ]"
        strSQL += " SET 赤黒SEQ = " & Label001.Text & ""
        strSQL += ", ERR_F = '0'"
        strSQL += " WHERE (SEQ = " & DtView1(0)("SEQ") & ")"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.ExecuteNonQuery()

        strSQL = "UPDATE [02_売上データ]"
        strSQL += " SET 商品ｺｰﾄﾞ = '" & Label020.Text & "'"
        strSQL += ", 品名ｶﾅ = '" & Label021.Text & "'"
        strSQL += ", 品名漢字 = '" & Label026.Text & "'"
        strSQL += ", 赤黒SEQ = " & DtView1(0)("SEQ") & ""
        strSQL += ", ERR_F = '0'"
        strSQL += " WHERE (SEQ = " & Label001.Text & ")"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
    End Sub

    Sub UPD_02() '過去分修正
        DB_OPEN()

        strSQL = "UPDATE [02_売上データ]"
        strSQL += " SET 商品ｺｰﾄﾞ = '" & Label020.Text & "'"
        strSQL += ", 品名ｶﾅ = '" & Label021.Text & "'"
        strSQL += ", 品名漢字 = '" & Label026.Text & "'"
        strSQL += ", 処理日2 = CONVERT(DATETIME, '" & Date1.Text & "/01', 102)"
        strSQL += ", ERR_F = '0'"
        strSQL += " WHERE (SEQ = " & Label001.Text & ")"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
    End Sub

    Sub mach()
    End Sub

    '********************************************************************
    '**  戻る
    '********************************************************************
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        DG_DsList1.Clear()
        DsList1.Clear()
        Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Label020.Text = "0400000069814"
        Label021.Text = "ﾃﾚﾋﾞｱﾝｼﾝ5ﾈﾝﾎｼｮｳ"
        Label026.Text = "ＴＶ安心５年保証"

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Label020.Text = "0400000069852"
        Label021.Text = "ｾﾝﾀｸｷｱﾝｼﾝ5ﾈﾝﾎｼｮｳ"
        Label026.Text = "洗濯機安心５年保証"

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Label020.Text = "0400000069838"
        Label021.Text = "ﾚｲｿﾞｳｺｱﾝｼﾝ5ﾈﾝﾎｼｮｳ"
        Label026.Text = "冷蔵庫安心５年保証"

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Label020.Text = "0400000069869"
        Label021.Text = "ｴｱｺﾝｱﾝｼﾝ5ﾈﾝﾎｼｮｳ"
        Label026.Text = "ＡＣ安心５年保証"

    End Sub
End Class
