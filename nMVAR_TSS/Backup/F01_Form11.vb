Public Class F01_Form11
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1 As DataView
    Dim dttable As DataTable
    Dim dtRow As DataRow

    Dim strSQL, WK_str As String
    Dim i, pos As Integer

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
    Friend WithEvents DataGridEx1 As nMVAR_TSS.DataGridEx
    Friend WithEvents FunctionKey1 As GrapeCity.Win.Input.FunctionKey
    Friend WithEvents f01 As System.Windows.Forms.Button
    Friend WithEvents f02 As System.Windows.Forms.Button
    Friend WithEvents f12 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
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
    Friend WithEvents DataGridTextBoxColumn17 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn18 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn19 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn20 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn21 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn22 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn23 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn24 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn25 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn26 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn27 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn28 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn29 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn30 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn31 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn32 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn33 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn34 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn35 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn36 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn37 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn38 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn39 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn40 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn41 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn42 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn43 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn44 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn45 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn46 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn47 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(F01_Form11))
        Me.DataGridEx1 = New nMVAR_TSS.DataGridEx
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
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
        Me.DataGridTextBoxColumn17 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn18 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn19 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn20 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn21 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn22 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn23 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn24 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn25 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn26 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn27 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn28 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn29 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn30 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn31 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn32 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn33 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn34 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn35 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn36 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn37 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn38 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn39 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn40 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn41 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn42 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn43 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn44 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn45 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn46 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn47 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.f01 = New System.Windows.Forms.Button
        Me.f02 = New System.Windows.Forms.Button
        Me.f12 = New System.Windows.Forms.Button
        Me.FunctionKey1 = New GrapeCity.Win.Input.FunctionKey
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridEx1
        '
        Me.DataGridEx1.CaptionVisible = False
        Me.DataGridEx1.DataMember = ""
        Me.DataGridEx1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridEx1.Location = New System.Drawing.Point(8, 48)
        Me.DataGridEx1.Name = "DataGridEx1"
        Me.DataGridEx1.ReadOnly = True
        Me.DataGridEx1.RowHeaderWidth = 10
        Me.DataGridEx1.Size = New System.Drawing.Size(988, 636)
        Me.DataGridEx1.TabIndex = 3
        Me.DataGridEx1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGridEx1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8, Me.DataGridTextBoxColumn9, Me.DataGridTextBoxColumn10, Me.DataGridTextBoxColumn11, Me.DataGridTextBoxColumn12, Me.DataGridTextBoxColumn13, Me.DataGridTextBoxColumn14, Me.DataGridTextBoxColumn15, Me.DataGridTextBoxColumn16, Me.DataGridTextBoxColumn17, Me.DataGridTextBoxColumn18, Me.DataGridTextBoxColumn19, Me.DataGridTextBoxColumn20, Me.DataGridTextBoxColumn21, Me.DataGridTextBoxColumn22, Me.DataGridTextBoxColumn23, Me.DataGridTextBoxColumn24, Me.DataGridTextBoxColumn25, Me.DataGridTextBoxColumn26, Me.DataGridTextBoxColumn27, Me.DataGridTextBoxColumn28, Me.DataGridTextBoxColumn29, Me.DataGridTextBoxColumn30, Me.DataGridTextBoxColumn31, Me.DataGridTextBoxColumn32, Me.DataGridTextBoxColumn33, Me.DataGridTextBoxColumn34, Me.DataGridTextBoxColumn35, Me.DataGridTextBoxColumn36, Me.DataGridTextBoxColumn37, Me.DataGridTextBoxColumn38, Me.DataGridTextBoxColumn39, Me.DataGridTextBoxColumn40, Me.DataGridTextBoxColumn41, Me.DataGridTextBoxColumn42, Me.DataGridTextBoxColumn43, Me.DataGridTextBoxColumn44, Me.DataGridTextBoxColumn45, Me.DataGridTextBoxColumn46, Me.DataGridTextBoxColumn47})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "inpt"
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "区分"
        Me.DataGridTextBoxColumn1.MappingName = "F1"
        Me.DataGridTextBoxColumn1.Width = 40
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "ﾚｺｰﾄﾞ区分"
        Me.DataGridTextBoxColumn2.MappingName = "F2"
        Me.DataGridTextBoxColumn2.NullText = ""
        Me.DataGridTextBoxColumn2.Width = 75
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "ﾃﾞｰﾀ送信日"
        Me.DataGridTextBoxColumn3.MappingName = "F3"
        Me.DataGridTextBoxColumn3.NullText = ""
        Me.DataGridTextBoxColumn3.Width = 90
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "ｶﾙﾃ番号"
        Me.DataGridTextBoxColumn4.MappingName = "F4"
        Me.DataGridTextBoxColumn4.NullText = ""
        Me.DataGridTextBoxColumn4.Width = 120
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "会社ID"
        Me.DataGridTextBoxColumn5.MappingName = "F5"
        Me.DataGridTextBoxColumn5.NullText = ""
        Me.DataGridTextBoxColumn5.Width = 60
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "対応種別"
        Me.DataGridTextBoxColumn6.MappingName = "F6"
        Me.DataGridTextBoxColumn6.NullText = ""
        Me.DataGridTextBoxColumn6.Width = 75
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "受付日"
        Me.DataGridTextBoxColumn7.MappingName = "F7"
        Me.DataGridTextBoxColumn7.NullText = ""
        Me.DataGridTextBoxColumn7.Width = 80
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Format = ""
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "受付店舗ｺｰﾄﾞ"
        Me.DataGridTextBoxColumn8.MappingName = "Ｆ8"
        Me.DataGridTextBoxColumn8.NullText = ""
        Me.DataGridTextBoxColumn8.Width = 75
        '
        'DataGridTextBoxColumn9
        '
        Me.DataGridTextBoxColumn9.Format = ""
        Me.DataGridTextBoxColumn9.FormatInfo = Nothing
        Me.DataGridTextBoxColumn9.HeaderText = "受付店舗名"
        Me.DataGridTextBoxColumn9.MappingName = "F9"
        Me.DataGridTextBoxColumn9.NullText = ""
        Me.DataGridTextBoxColumn9.Width = 75
        '
        'DataGridTextBoxColumn10
        '
        Me.DataGridTextBoxColumn10.Format = ""
        Me.DataGridTextBoxColumn10.FormatInfo = Nothing
        Me.DataGridTextBoxColumn10.HeaderText = "追加案件"
        Me.DataGridTextBoxColumn10.MappingName = "F10"
        Me.DataGridTextBoxColumn10.NullText = ""
        Me.DataGridTextBoxColumn10.Width = 75
        '
        'DataGridTextBoxColumn11
        '
        Me.DataGridTextBoxColumn11.Format = ""
        Me.DataGridTextBoxColumn11.FormatInfo = Nothing
        Me.DataGridTextBoxColumn11.HeaderText = "顧客申告内容"
        Me.DataGridTextBoxColumn11.MappingName = "F11"
        Me.DataGridTextBoxColumn11.NullText = ""
        Me.DataGridTextBoxColumn11.Width = 75
        '
        'DataGridTextBoxColumn12
        '
        Me.DataGridTextBoxColumn12.Format = ""
        Me.DataGridTextBoxColumn12.FormatInfo = Nothing
        Me.DataGridTextBoxColumn12.HeaderText = "発生頻度"
        Me.DataGridTextBoxColumn12.MappingName = "F12"
        Me.DataGridTextBoxColumn12.NullText = ""
        Me.DataGridTextBoxColumn12.Width = 75
        '
        'DataGridTextBoxColumn13
        '
        Me.DataGridTextBoxColumn13.Format = ""
        Me.DataGridTextBoxColumn13.FormatInfo = Nothing
        Me.DataGridTextBoxColumn13.HeaderText = "商品名"
        Me.DataGridTextBoxColumn13.MappingName = "F13"
        Me.DataGridTextBoxColumn13.NullText = ""
        Me.DataGridTextBoxColumn13.Width = 75
        '
        'DataGridTextBoxColumn14
        '
        Me.DataGridTextBoxColumn14.Format = ""
        Me.DataGridTextBoxColumn14.FormatInfo = Nothing
        Me.DataGridTextBoxColumn14.HeaderText = "メーカー名"
        Me.DataGridTextBoxColumn14.MappingName = "F14"
        Me.DataGridTextBoxColumn14.NullText = ""
        Me.DataGridTextBoxColumn14.Width = 75
        '
        'DataGridTextBoxColumn15
        '
        Me.DataGridTextBoxColumn15.Format = ""
        Me.DataGridTextBoxColumn15.FormatInfo = Nothing
        Me.DataGridTextBoxColumn15.HeaderText = "部門名"
        Me.DataGridTextBoxColumn15.MappingName = "F15"
        Me.DataGridTextBoxColumn15.NullText = ""
        Me.DataGridTextBoxColumn15.Width = 75
        '
        'DataGridTextBoxColumn16
        '
        Me.DataGridTextBoxColumn16.Format = ""
        Me.DataGridTextBoxColumn16.FormatInfo = Nothing
        Me.DataGridTextBoxColumn16.HeaderText = "製造番号"
        Me.DataGridTextBoxColumn16.MappingName = "F16"
        Me.DataGridTextBoxColumn16.NullText = ""
        Me.DataGridTextBoxColumn16.Width = 75
        '
        'DataGridTextBoxColumn17
        '
        Me.DataGridTextBoxColumn17.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn17.Format = ""
        Me.DataGridTextBoxColumn17.FormatInfo = Nothing
        Me.DataGridTextBoxColumn17.HeaderText = "購入日"
        Me.DataGridTextBoxColumn17.MappingName = "F17"
        Me.DataGridTextBoxColumn17.NullText = ""
        Me.DataGridTextBoxColumn17.Width = 80
        '
        'DataGridTextBoxColumn18
        '
        Me.DataGridTextBoxColumn18.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn18.Format = ""
        Me.DataGridTextBoxColumn18.FormatInfo = Nothing
        Me.DataGridTextBoxColumn18.HeaderText = "見積限度額"
        Me.DataGridTextBoxColumn18.MappingName = "F18"
        Me.DataGridTextBoxColumn18.NullText = ""
        Me.DataGridTextBoxColumn18.Width = 75
        '
        'DataGridTextBoxColumn19
        '
        Me.DataGridTextBoxColumn19.Format = ""
        Me.DataGridTextBoxColumn19.FormatInfo = Nothing
        Me.DataGridTextBoxColumn19.HeaderText = "保証情報"
        Me.DataGridTextBoxColumn19.MappingName = "F19"
        Me.DataGridTextBoxColumn19.NullText = ""
        Me.DataGridTextBoxColumn19.Width = 75
        '
        'DataGridTextBoxColumn20
        '
        Me.DataGridTextBoxColumn20.Format = ""
        Me.DataGridTextBoxColumn20.FormatInfo = Nothing
        Me.DataGridTextBoxColumn20.HeaderText = "パスワード"
        Me.DataGridTextBoxColumn20.MappingName = "F20"
        Me.DataGridTextBoxColumn20.NullText = ""
        Me.DataGridTextBoxColumn20.Width = 75
        '
        'DataGridTextBoxColumn21
        '
        Me.DataGridTextBoxColumn21.Format = ""
        Me.DataGridTextBoxColumn21.FormatInfo = Nothing
        Me.DataGridTextBoxColumn21.HeaderText = "付属品"
        Me.DataGridTextBoxColumn21.MappingName = "F21"
        Me.DataGridTextBoxColumn21.NullText = ""
        Me.DataGridTextBoxColumn21.Width = 75
        '
        'DataGridTextBoxColumn22
        '
        Me.DataGridTextBoxColumn22.Format = ""
        Me.DataGridTextBoxColumn22.FormatInfo = Nothing
        Me.DataGridTextBoxColumn22.HeaderText = "出荷元センター"
        Me.DataGridTextBoxColumn22.MappingName = "F22"
        Me.DataGridTextBoxColumn22.NullText = ""
        Me.DataGridTextBoxColumn22.Width = 75
        '
        'DataGridTextBoxColumn23
        '
        Me.DataGridTextBoxColumn23.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn23.Format = ""
        Me.DataGridTextBoxColumn23.FormatInfo = Nothing
        Me.DataGridTextBoxColumn23.HeaderText = "保証限度額"
        Me.DataGridTextBoxColumn23.MappingName = "F23"
        Me.DataGridTextBoxColumn23.NullText = ""
        Me.DataGridTextBoxColumn23.Width = 75
        '
        'DataGridTextBoxColumn24
        '
        Me.DataGridTextBoxColumn24.Format = ""
        Me.DataGridTextBoxColumn24.FormatInfo = Nothing
        Me.DataGridTextBoxColumn24.HeaderText = "デバイス区分"
        Me.DataGridTextBoxColumn24.MappingName = "F24"
        Me.DataGridTextBoxColumn24.NullText = ""
        Me.DataGridTextBoxColumn24.Width = 75
        '
        'DataGridTextBoxColumn25
        '
        Me.DataGridTextBoxColumn25.Format = ""
        Me.DataGridTextBoxColumn25.FormatInfo = Nothing
        Me.DataGridTextBoxColumn25.HeaderText = "ディーラー保証期間"
        Me.DataGridTextBoxColumn25.MappingName = "F25"
        Me.DataGridTextBoxColumn25.NullText = ""
        Me.DataGridTextBoxColumn25.Width = 75
        '
        'DataGridTextBoxColumn26
        '
        Me.DataGridTextBoxColumn26.Format = ""
        Me.DataGridTextBoxColumn26.FormatInfo = Nothing
        Me.DataGridTextBoxColumn26.HeaderText = "バックアップ確認"
        Me.DataGridTextBoxColumn26.MappingName = "F26"
        Me.DataGridTextBoxColumn26.NullText = ""
        Me.DataGridTextBoxColumn26.Width = 75
        '
        'DataGridTextBoxColumn27
        '
        Me.DataGridTextBoxColumn27.Format = ""
        Me.DataGridTextBoxColumn27.FormatInfo = Nothing
        Me.DataGridTextBoxColumn27.HeaderText = "見積書_要否"
        Me.DataGridTextBoxColumn27.MappingName = "F27"
        Me.DataGridTextBoxColumn27.NullText = ""
        Me.DataGridTextBoxColumn27.Width = 75
        '
        'DataGridTextBoxColumn28
        '
        Me.DataGridTextBoxColumn28.Format = ""
        Me.DataGridTextBoxColumn28.FormatInfo = Nothing
        Me.DataGridTextBoxColumn28.HeaderText = "再受付区分"
        Me.DataGridTextBoxColumn28.MappingName = "F28"
        Me.DataGridTextBoxColumn28.NullText = ""
        Me.DataGridTextBoxColumn28.Width = 75
        '
        'DataGridTextBoxColumn29
        '
        Me.DataGridTextBoxColumn29.Format = ""
        Me.DataGridTextBoxColumn29.FormatInfo = Nothing
        Me.DataGridTextBoxColumn29.HeaderText = "元受付番号"
        Me.DataGridTextBoxColumn29.MappingName = "F29"
        Me.DataGridTextBoxColumn29.NullText = ""
        Me.DataGridTextBoxColumn29.Width = 75
        '
        'DataGridTextBoxColumn30
        '
        Me.DataGridTextBoxColumn30.Format = ""
        Me.DataGridTextBoxColumn30.FormatInfo = Nothing
        Me.DataGridTextBoxColumn30.HeaderText = "顧客名_姓"
        Me.DataGridTextBoxColumn30.MappingName = "F30"
        Me.DataGridTextBoxColumn30.NullText = ""
        Me.DataGridTextBoxColumn30.Width = 75
        '
        'DataGridTextBoxColumn31
        '
        Me.DataGridTextBoxColumn31.Format = ""
        Me.DataGridTextBoxColumn31.FormatInfo = Nothing
        Me.DataGridTextBoxColumn31.HeaderText = "顧客名_名"
        Me.DataGridTextBoxColumn31.MappingName = "F31"
        Me.DataGridTextBoxColumn31.NullText = ""
        Me.DataGridTextBoxColumn31.Width = 75
        '
        'DataGridTextBoxColumn32
        '
        Me.DataGridTextBoxColumn32.Format = ""
        Me.DataGridTextBoxColumn32.FormatInfo = Nothing
        Me.DataGridTextBoxColumn32.HeaderText = "顧客名_姓ｶﾅ"
        Me.DataGridTextBoxColumn32.MappingName = "F32"
        Me.DataGridTextBoxColumn32.NullText = ""
        Me.DataGridTextBoxColumn32.Width = 75
        '
        'DataGridTextBoxColumn33
        '
        Me.DataGridTextBoxColumn33.Format = ""
        Me.DataGridTextBoxColumn33.FormatInfo = Nothing
        Me.DataGridTextBoxColumn33.HeaderText = "顧客名_名ｶﾅ"
        Me.DataGridTextBoxColumn33.MappingName = "F33"
        Me.DataGridTextBoxColumn33.NullText = ""
        Me.DataGridTextBoxColumn33.Width = 75
        '
        'DataGridTextBoxColumn34
        '
        Me.DataGridTextBoxColumn34.Format = ""
        Me.DataGridTextBoxColumn34.FormatInfo = Nothing
        Me.DataGridTextBoxColumn34.HeaderText = "email_1"
        Me.DataGridTextBoxColumn34.MappingName = "F34"
        Me.DataGridTextBoxColumn34.NullText = ""
        Me.DataGridTextBoxColumn34.Width = 75
        '
        'DataGridTextBoxColumn35
        '
        Me.DataGridTextBoxColumn35.Format = ""
        Me.DataGridTextBoxColumn35.FormatInfo = Nothing
        Me.DataGridTextBoxColumn35.HeaderText = "連絡先電話番号"
        Me.DataGridTextBoxColumn35.MappingName = "F35"
        Me.DataGridTextBoxColumn35.NullText = ""
        Me.DataGridTextBoxColumn35.Width = 75
        '
        'DataGridTextBoxColumn36
        '
        Me.DataGridTextBoxColumn36.Format = ""
        Me.DataGridTextBoxColumn36.FormatInfo = Nothing
        Me.DataGridTextBoxColumn36.HeaderText = "電話番号"
        Me.DataGridTextBoxColumn36.MappingName = "F36"
        Me.DataGridTextBoxColumn36.NullText = ""
        Me.DataGridTextBoxColumn36.Width = 75
        '
        'DataGridTextBoxColumn37
        '
        Me.DataGridTextBoxColumn37.Format = ""
        Me.DataGridTextBoxColumn37.FormatInfo = Nothing
        Me.DataGridTextBoxColumn37.HeaderText = "携帯番号"
        Me.DataGridTextBoxColumn37.MappingName = "F37"
        Me.DataGridTextBoxColumn37.NullText = ""
        Me.DataGridTextBoxColumn37.Width = 75
        '
        'DataGridTextBoxColumn38
        '
        Me.DataGridTextBoxColumn38.Format = ""
        Me.DataGridTextBoxColumn38.FormatInfo = Nothing
        Me.DataGridTextBoxColumn38.HeaderText = "優先順位_連絡先"
        Me.DataGridTextBoxColumn38.MappingName = "F38"
        Me.DataGridTextBoxColumn38.NullText = ""
        Me.DataGridTextBoxColumn38.Width = 75
        '
        'DataGridTextBoxColumn39
        '
        Me.DataGridTextBoxColumn39.Format = ""
        Me.DataGridTextBoxColumn39.FormatInfo = Nothing
        Me.DataGridTextBoxColumn39.HeaderText = "優先順位_電話"
        Me.DataGridTextBoxColumn39.MappingName = "F39"
        Me.DataGridTextBoxColumn39.NullText = ""
        Me.DataGridTextBoxColumn39.Width = 75
        '
        'DataGridTextBoxColumn40
        '
        Me.DataGridTextBoxColumn40.Format = ""
        Me.DataGridTextBoxColumn40.FormatInfo = Nothing
        Me.DataGridTextBoxColumn40.HeaderText = "優先順位_携帯"
        Me.DataGridTextBoxColumn40.MappingName = "F40"
        Me.DataGridTextBoxColumn40.NullText = ""
        Me.DataGridTextBoxColumn40.Width = 75
        '
        'DataGridTextBoxColumn41
        '
        Me.DataGridTextBoxColumn41.Format = ""
        Me.DataGridTextBoxColumn41.FormatInfo = Nothing
        Me.DataGridTextBoxColumn41.HeaderText = "FAX番号"
        Me.DataGridTextBoxColumn41.MappingName = "F41"
        Me.DataGridTextBoxColumn41.NullText = ""
        Me.DataGridTextBoxColumn41.Width = 75
        '
        'DataGridTextBoxColumn42
        '
        Me.DataGridTextBoxColumn42.Format = ""
        Me.DataGridTextBoxColumn42.FormatInfo = Nothing
        Me.DataGridTextBoxColumn42.HeaderText = "郵便番号"
        Me.DataGridTextBoxColumn42.MappingName = "F42"
        Me.DataGridTextBoxColumn42.NullText = ""
        Me.DataGridTextBoxColumn42.Width = 75
        '
        'DataGridTextBoxColumn43
        '
        Me.DataGridTextBoxColumn43.Format = ""
        Me.DataGridTextBoxColumn43.FormatInfo = Nothing
        Me.DataGridTextBoxColumn43.HeaderText = "都道府県"
        Me.DataGridTextBoxColumn43.MappingName = "F73"
        Me.DataGridTextBoxColumn43.NullText = ""
        Me.DataGridTextBoxColumn43.Width = 75
        '
        'DataGridTextBoxColumn44
        '
        Me.DataGridTextBoxColumn44.Format = ""
        Me.DataGridTextBoxColumn44.FormatInfo = Nothing
        Me.DataGridTextBoxColumn44.HeaderText = "市区町村"
        Me.DataGridTextBoxColumn44.MappingName = "F44"
        Me.DataGridTextBoxColumn44.NullText = ""
        Me.DataGridTextBoxColumn44.Width = 75
        '
        'DataGridTextBoxColumn45
        '
        Me.DataGridTextBoxColumn45.Format = ""
        Me.DataGridTextBoxColumn45.FormatInfo = Nothing
        Me.DataGridTextBoxColumn45.HeaderText = "町名番地"
        Me.DataGridTextBoxColumn45.MappingName = "F45"
        Me.DataGridTextBoxColumn45.NullText = ""
        Me.DataGridTextBoxColumn45.Width = 75
        '
        'DataGridTextBoxColumn46
        '
        Me.DataGridTextBoxColumn46.Format = ""
        Me.DataGridTextBoxColumn46.FormatInfo = Nothing
        Me.DataGridTextBoxColumn46.HeaderText = "ビル号名"
        Me.DataGridTextBoxColumn46.MappingName = "F46"
        Me.DataGridTextBoxColumn46.NullText = ""
        Me.DataGridTextBoxColumn46.Width = 75
        '
        'DataGridTextBoxColumn47
        '
        Me.DataGridTextBoxColumn47.Format = ""
        Me.DataGridTextBoxColumn47.FormatInfo = Nothing
        Me.DataGridTextBoxColumn47.HeaderText = "備考"
        Me.DataGridTextBoxColumn47.MappingName = "F47"
        Me.DataGridTextBoxColumn47.NullText = ""
        Me.DataGridTextBoxColumn47.Width = 75
        '
        'f01
        '
        Me.f01.Cursor = System.Windows.Forms.Cursors.Hand
        Me.f01.Location = New System.Drawing.Point(672, 8)
        Me.f01.Name = "f01"
        Me.f01.Size = New System.Drawing.Size(96, 32)
        Me.f01.TabIndex = 0
        Me.f01.Text = "F1:取込み"
        '
        'f02
        '
        Me.f02.Cursor = System.Windows.Forms.Cursors.Hand
        Me.f02.Enabled = False
        Me.f02.Location = New System.Drawing.Point(784, 8)
        Me.f02.Name = "f02"
        Me.f02.Size = New System.Drawing.Size(96, 32)
        Me.f02.TabIndex = 1
        Me.f02.Text = "F2:登録"
        '
        'f12
        '
        Me.f12.Cursor = System.Windows.Forms.Cursors.Hand
        Me.f12.Location = New System.Drawing.Point(896, 8)
        Me.f12.Name = "f12"
        Me.f12.Size = New System.Drawing.Size(96, 32)
        Me.f12.TabIndex = 2
        Me.f12.Text = "F12:閉じる"
        '
        'FunctionKey1
        '
        Me.FunctionKey1.ActiveKeySet = "Default"
        Me.FunctionKey1.Location = New System.Drawing.Point(0, 688)
        Me.FunctionKey1.Name = "FunctionKey1"
        Me.FunctionKey1.Size = New System.Drawing.Size(1002, 0)
        Me.FunctionKey1.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(304, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(312, 36)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "修理品情報取込み"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'F01_Form11
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 15)
        Me.ClientSize = New System.Drawing.Size(1002, 688)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.FunctionKey1)
        Me.Controls.Add(Me.f12)
        Me.Controls.Add(Me.f02)
        Me.Controls.Add(Me.f01)
        Me.Controls.Add(Me.DataGridEx1)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "F01_Form11"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "修理品情報取込み"
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F01_Form11_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()   '**  初期処理
    End Sub

    '********************************************************************
    '**  初期処理
    '********************************************************************
    Sub inz()

        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Me.Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        'ﾃﾞｰﾀｸﾞﾘｯﾄﾞ設定
        DsList1.Clear()
        strSQL = "SELECT '' AS F1, '' AS F2, '' AS F3, '' AS F4, '' AS F5, '' AS F6, '' AS F7, '' AS F8, '' AS F9, '' AS F10"
        strSQL = strSQL & ", '' AS F11, '' AS F12, '' AS F13, '' AS F14, '' AS F15, '' AS F16, '' AS F17, '' AS F18, '' AS F19, '' AS F20"
        strSQL = strSQL & ", '' AS F21, '' AS F22, '' AS F23, '' AS F24, '' AS F25, '' AS F26, '' AS F27, '' AS F28, '' AS F29, '' AS F30"
        strSQL = strSQL & ", '' AS F31, '' AS F32, '' AS F33, '' AS F34, '' AS F35, '' AS F36, '' AS F37, '' AS F38, '' AS F39, '' AS F40"
        strSQL = strSQL & ", '' AS F41, '' AS F42, '' AS F43, '' AS F44, '' AS F45, '' AS F46, '' AS F47"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsList1, "inpt")
        DB_CLOSE()

        Dim tbl As New DataTable
        tbl = DsList1.Tables("inpt")
        DataGridEx1.DataSource = tbl
        DsList1.Clear()

    End Sub

    '********************************************************************
    '**  取込みボタン
    '********************************************************************
    Private Sub f01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles f01.Click

        With OpenFileDialog1
            .CheckFileExists = True     'ファイルが存在するか確認
            .RestoreDirectory = True    'ディレクトリの復元
            .ReadOnlyChecked = True
            .ShowReadOnly = True
            .Filter = "CSV ﾌｧｲﾙ(*.csv)|*.csv"
            .FilterIndex = 0
            'ダイアログボックスを表示し、［開く]をクリックした場合
            If .ShowDialog = DialogResult.OK Then
                Cursor = System.Windows.Forms.Cursors.WaitCursor
                Dim srFile As New System.IO.StreamReader(.FileName, System.Text.Encoding.Default)
                Dim strLine As String = srFile.ReadLine()
                DsList1.Clear()

                While Not strLine Is Nothing
                    WK_str = strLine
                    WK_str = WK_str.Replace(" / ", System.Environment.NewLine)      '/を改行
                    WK_str = WK_str.Replace(Chr(34) & Chr(34) & Chr(34), Chr(34))   '"""を"
                    WK_str = WK_str.Replace(" ", "")                                'スペースを除く
                    WK_str = WK_str.Replace("　", "")                               'スペースを除く
                    WK_str = StrConv(WK_str, VbStrConv.Narrow)                      '全角を半角に変換

                    dttable = DsList1.Tables("inpt")
                    dtRow = dttable.NewRow

                    dtRow("F1") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F2") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F3") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F4") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F5") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F6") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F7") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F8") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F9") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F10") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F11") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F12") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F13") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F14") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F15") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F16") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F17") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F18") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F19") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F20") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F21") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F22") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F23") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F24") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F25") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F26") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F27") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F28") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F29") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F30") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F31") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F32") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F33") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F34") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F35") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F36") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F37") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F38") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F39") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F40") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F41") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F42") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F43") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F44") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F45") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F46") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F47") = Mid(WK_str, 2, WK_str.LastIndexOf(Chr(34)) - 1)

                    dttable.Rows.Add(dtRow)

                    strLine = srFile.ReadLine()
                End While

                f02.Enabled = True
                Cursor = System.Windows.Forms.Cursors.Default
            End If
        End With

    End Sub

    '********************************************************************
    '**  登録ボタン
    '********************************************************************
    Private Sub f02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles f02.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor

        DtView1 = New DataView(DsList1.Tables("inpt"), "", "", DataViewRowState.CurrentRows)
        For i = 0 To DtView1.Count - 1

            strSQL = "INSERT INTO TSS_REP_INF"
            strSQL = strSQL & " (cls, rcd_cls, snd_date, cust_repr_no, cmpy_id, rep_cls, accp_date, cust_code, cust_name"
            strSQL = strSQL & ", add_item, cust_rept, frequency, model_name, vndr_name, cat_name, body_no, prch_date, limt_amnt"
            strSQL = strSQL & ", wrn_inf, pswd, atch_item, ship_cntr, wrn_limt_amnt, device_cls, dlr_wrn_prid, bkup_conf, etmt_yn"
            strSQL = strSQL & ", re_rept_cls, moto_rcpt_no, user_l_name, user_f_name, user_l_name_kana, user_f_name_kana, email"
            strSQL = strSQL & ", tel1, tel2, tel3, Priority1, Priority2, Priority3, fax, zip_code, pref_name, city_name, town_name"
            strSQL = strSQL & ", buil_name, remarks, delt_flg)"
            strSQL = strSQL & " VALUES ('" & DtView1(i)("F1") & "'"
            strSQL = strSQL & ", '" & DtView1(i)("F2") & "'"

            If DtView1(i)("F3") = Nothing Or DtView1(i)("F3") = 0 Then
                strSQL = strSQL & ", NULL"
            Else
                strSQL = strSQL & ", CONVERT(DATETIME, '" & Mid(DtView1(i)("F3"), 1, 4) & "/" & Mid(DtView1(i)("F3"), 5, 2) & "/" & Mid(DtView1(i)("F3"), 7, 2) & "', 102)"
            End If

            strSQL = strSQL & ", '" & DtView1(i)("F4") & "'"
            strSQL = strSQL & ", '" & DtView1(i)("F5") & "'"
            strSQL = strSQL & ", '" & MidB(DtView1(i)("F6"), 1, 20) & "'"

            If DtView1(i)("F7") = Nothing Or DtView1(i)("F7") = 0 Then
                strSQL = strSQL & ", NULL"
            Else
                strSQL = strSQL & ", CONVERT(DATETIME, '" & Mid(DtView1(i)("F7"), 1, 4) & "/" & Mid(DtView1(i)("F7"), 5, 2) & "/" & Mid(DtView1(i)("F7"), 7, 2) & "', 102)"
            End If

            strSQL = strSQL & ", '" & DtView1(i)("F8") & "'"
            strSQL = strSQL & ", '" & MidB(DtView1(i)("F9"), 1, 100) & "'"
            strSQL = strSQL & ", '" & MidB(DtView1(i)("F10"), 1, 500) & "'"
            strSQL = strSQL & ", '" & MidB(DtView1(i)("F11"), 1, 500) & "'"
            strSQL = strSQL & ", '" & MidB(DtView1(i)("F12"), 1, 500) & "'"
            strSQL = strSQL & ", '" & MidB(DtView1(i)("F13"), 1, 100) & "'"
            strSQL = strSQL & ", '" & MidB(DtView1(i)("F14"), 1, 100) & "'"
            strSQL = strSQL & ", '" & MidB(DtView1(i)("F15"), 1, 100) & "'"
            strSQL = strSQL & ", '" & MidB(DtView1(i)("F16"), 1, 20) & "'"

            If DtView1(i)("F17") = Nothing Then
                strSQL = strSQL & ", NULL"
            Else
                If DtView1(i)("F17") = 0 Then
                    strSQL = strSQL & ", NULL"
                Else
                    strSQL = strSQL & ", CONVERT(DATETIME, '" & Mid(DtView1(i)("F17"), 1, 4) & "/" & Mid(DtView1(i)("F17"), 5, 2) & "/" & Mid(DtView1(i)("F17"), 7, 2) & "', 102)"
                End If
            End If

            If DtView1(i)("F18") = Nothing Then
                strSQL = strSQL & ", 0"
            Else
                strSQL = strSQL & ", " & DtView1(i)("F18") & ""
            End If

            strSQL = strSQL & ", '" & MidB(DtView1(i)("F19"), 1, 100) & "'"
            strSQL = strSQL & ", '" & MidB(DtView1(i)("F20"), 1, 100) & "'"
            strSQL = strSQL & ", '" & MidB(DtView1(i)("F21"), 1, 500) & "'"
            strSQL = strSQL & ", '" & DtView1(i)("F22") & "'"

            If DtView1(i)("F23") = Nothing Then
                strSQL = strSQL & ", 0"
            Else
                strSQL = strSQL & ", " & DtView1(i)("F23") & ""
            End If

            strSQL = strSQL & ", '" & DtView1(i)("F24") & "'"
            strSQL = strSQL & ", '" & MidB(DtView1(i)("F25"), 1, 20) & "'"
            strSQL = strSQL & ", '" & MidB(DtView1(i)("F26"), 1, 20) & "'"
            strSQL = strSQL & ", '" & DtView1(i)("F27") & "'"
            strSQL = strSQL & ", '" & DtView1(i)("F28") & "'"
            strSQL = strSQL & ", '" & MidB(DtView1(i)("F29"), 1, 30) & "'"
            strSQL = strSQL & ", '" & MidB(DtView1(i)("F30"), 1, 30) & "'"
            strSQL = strSQL & ", '" & MidB(DtView1(i)("F31"), 1, 30) & "'"
            strSQL = strSQL & ", '" & MidB(DtView1(i)("F32"), 1, 30) & "'"
            strSQL = strSQL & ", '" & MidB(DtView1(i)("F33"), 1, 30) & "'"
            strSQL = strSQL & ", '" & MidB(DtView1(i)("F34"), 1, 50) & "'"
            strSQL = strSQL & ", '" & MidB(DtView1(i)("F35"), 1, 20) & "'"
            strSQL = strSQL & ", '" & MidB(DtView1(i)("F36"), 1, 20) & "'"
            strSQL = strSQL & ", '" & MidB(DtView1(i)("F37"), 1, 20) & "'"

            If DtView1(i)("F38") = Nothing Then
                strSQL = strSQL & ", 0"
            Else
                If numeric_check(DtView1(i)("F38")) = "NG" Then
                    strSQL = strSQL & ", 0"
                Else
                    strSQL = strSQL & ", " & DtView1(i)("F38") & ""
                End If
            End If
            If DtView1(i)("F39") = Nothing Then
                strSQL = strSQL & ", 0"
            Else
                If numeric_check(DtView1(i)("F39")) = "NG" Then
                    strSQL = strSQL & ", 0"
                Else
                    strSQL = strSQL & ", " & DtView1(i)("F39") & ""
                End If
            End If
            If DtView1(i)("F40") = Nothing Then
                strSQL = strSQL & ", 0"
            Else
                If numeric_check(DtView1(i)("F40")) = "NG" Then
                    strSQL = strSQL & ", 0"
                Else
                    strSQL = strSQL & ", " & DtView1(i)("F40") & ""
                End If
            End If

            strSQL = strSQL & ", '" & MidB(DtView1(i)("F41"), 1, 20) & "'"
            strSQL = strSQL & ", '" & MidB(DtView1(i)("F42"), 1, 7) & "'"
            strSQL = strSQL & ", '" & MidB(DtView1(i)("F43"), 1, 10) & "'"
            strSQL = strSQL & ", '" & MidB(DtView1(i)("F44"), 1, 100) & "'"
            strSQL = strSQL & ", '" & MidB(DtView1(i)("F45"), 1, 100) & "'"
            strSQL = strSQL & ", '" & MidB(DtView1(i)("F46"), 1, 100) & "'"
            strSQL = strSQL & ", '" & MidB(DtView1(i)("F47"), 1, 500) & "'"
            strSQL = strSQL & ", 0)"
            DB_OPEN("nMVAR")
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()

        Next

        MessageBox.Show("登録しました。", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        f02.Enabled = False
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  閉じる・終了ボタン
    '********************************************************************
    Private Sub f12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles f12.Click
        DsList1.Clear()
        Me.Close()
    End Sub

    '********************************************************************
    '**  ファンクションキー
    '********************************************************************
    Private Sub functionKey1_FunctionKeyPress(ByVal sender As System.Object, ByVal e As GrapeCity.Win.Input.FunctionKeyPressEventArgs) Handles FunctionKey1.FunctionKeyPress

        e.Handled = True        'ファンクションキーに割り付けられた設定を無効にします。
        Select Case e.KeyIndex  'ファンクションキーが押下された場合の処理を行います。
            Case 0  'F1
                If f01.Enabled = True Then f01.Focus() : f01_Click(sender, e)
            Case 1  'F2
                If f02.Enabled = True Then f02.Focus() : f02_Click(sender, e)
            Case 2  'F3
            Case 3  'F4
            Case 4  'F5
            Case 5  'F6
            Case 6  'F7
            Case 7  'F8
            Case 8  'F9
            Case 9  'F10
            Case 10 'F11
            Case 11 'F12
                f12_Click(sender, e)
        End Select
    End Sub

    '********************************************************************
    '**  GotFocus 
    '********************************************************************
    Private Sub f01_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles f01.GotFocus
        f01.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
    End Sub
    Private Sub f02_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles f02.GotFocus
        f02.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
    End Sub
    Private Sub f12_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles f12.GotFocus
        f12.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub f01_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles f01.LostFocus
        f01.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub f02_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles f02.LostFocus
        f02.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub f12_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles f12.LostFocus
        f12.BackColor = System.Drawing.SystemColors.Control
    End Sub
End Class
