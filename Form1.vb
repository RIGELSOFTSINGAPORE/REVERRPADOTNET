Public Class Form1
    Inherits System.Windows.Forms.Form

    Private objMutex As System.Threading.Mutex
    Dim waitDlg As WaitDialog   ''進行状況フォームクラス  

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim WK_DsList1, WK_DsList2 As New DataSet

    Dim DsImp As New DataSet
    Dim DtView1, DtView2 As DataView
    Dim WK_DtView1, WK_DtView2 As DataView
    Dim dttable0, dttable1, dttable2 As DataTable
    Dim dtRow0, dtRow1, dtRow2 As DataRow

    Dim file_name As String
    Dim strSQL, DG_Err_F, WK_err_msg, Ans As String
    Dim i, j, k, r, CNT, SEQ, ok_cnt, err_cnt As Integer
    Dim now_date As Date
    Dim WK_date, tax_date As Date       '消費税10%対応　2019/10/18

    Dim WK_wrn_prod As Integer

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
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
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
    Friend WithEvents DataGrid2 As System.Windows.Forms.DataGrid
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents DataGridTableStyle2 As System.Windows.Forms.DataGridTableStyle
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
    Friend WithEvents DataGridTextBoxColumn48 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn49 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn50 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn51 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn52 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn53 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn54 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn55 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn56 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn57 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn58 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn59 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn60 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn61 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn62 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn63 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn64 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn65 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn66 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn67 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn68 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn69 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn70 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn71 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn72 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn73 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn74 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn75 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn76 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.Button98 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.msg = New System.Windows.Forms.Label
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
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
        Me.DataGridTextBoxColumn76 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGrid2 = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle2 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn75 = New System.Windows.Forms.DataGridTextBoxColumn
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
        Me.DataGridTextBoxColumn48 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn49 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn50 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn51 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn52 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn53 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn54 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn55 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn56 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn57 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn58 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn59 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn60 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn61 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn62 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn63 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn64 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn65 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn66 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn67 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn68 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn69 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn70 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn71 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn72 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn73 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn74 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button98
        '
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(796, 12)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(124, 40)
        Me.Button98.TabIndex = 3
        Me.Button98.Text = "終　了"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(12, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(124, 40)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "取込み"
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(8, 620)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(724, 28)
        Me.msg.TabIndex = 1348
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataGrid1
        '
        Me.DataGrid1.CaptionVisible = False
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(12, 60)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.RowHeaderWidth = 10
        Me.DataGrid1.Size = New System.Drawing.Size(912, 288)
        Me.DataGrid1.TabIndex = 4
        Me.DataGrid1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGrid1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8, Me.DataGridTextBoxColumn9, Me.DataGridTextBoxColumn10, Me.DataGridTextBoxColumn11, Me.DataGridTextBoxColumn12, Me.DataGridTextBoxColumn13, Me.DataGridTextBoxColumn14, Me.DataGridTextBoxColumn15, Me.DataGridTextBoxColumn16, Me.DataGridTextBoxColumn17, Me.DataGridTextBoxColumn18, Me.DataGridTextBoxColumn19, Me.DataGridTextBoxColumn20, Me.DataGridTextBoxColumn21, Me.DataGridTextBoxColumn22, Me.DataGridTextBoxColumn23, Me.DataGridTextBoxColumn24, Me.DataGridTextBoxColumn25, Me.DataGridTextBoxColumn26, Me.DataGridTextBoxColumn27, Me.DataGridTextBoxColumn28, Me.DataGridTextBoxColumn29, Me.DataGridTextBoxColumn30, Me.DataGridTextBoxColumn31, Me.DataGridTextBoxColumn32, Me.DataGridTextBoxColumn33, Me.DataGridTextBoxColumn34, Me.DataGridTextBoxColumn35, Me.DataGridTextBoxColumn36, Me.DataGridTextBoxColumn37, Me.DataGridTextBoxColumn76})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "imp"
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "システム区分"
        Me.DataGridTextBoxColumn1.MappingName = "システム区分"
        Me.DataGridTextBoxColumn1.Width = 75
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "伝票番号"
        Me.DataGridTextBoxColumn2.MappingName = "伝票番号"
        Me.DataGridTextBoxColumn2.Width = 95
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "受注日"
        Me.DataGridTextBoxColumn3.MappingName = "受注日"
        Me.DataGridTextBoxColumn3.Width = 80
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "完了日"
        Me.DataGridTextBoxColumn4.MappingName = "完了日"
        Me.DataGridTextBoxColumn4.Width = 80
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "キャンセル日"
        Me.DataGridTextBoxColumn5.MappingName = "キャンセル日"
        Me.DataGridTextBoxColumn5.Width = 80
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "元伝No"
        Me.DataGridTextBoxColumn6.MappingName = "元伝No"
        Me.DataGridTextBoxColumn6.Width = 95
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "赤伝No"
        Me.DataGridTextBoxColumn7.MappingName = "赤伝No"
        Me.DataGridTextBoxColumn7.Width = 95
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn8.Format = ""
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "顧客番号"
        Me.DataGridTextBoxColumn8.MappingName = "顧客番号"
        Me.DataGridTextBoxColumn8.Width = 95
        '
        'DataGridTextBoxColumn9
        '
        Me.DataGridTextBoxColumn9.Format = ""
        Me.DataGridTextBoxColumn9.FormatInfo = Nothing
        Me.DataGridTextBoxColumn9.HeaderText = "顧客名"
        Me.DataGridTextBoxColumn9.MappingName = "顧客名"
        Me.DataGridTextBoxColumn9.Width = 120
        '
        'DataGridTextBoxColumn10
        '
        Me.DataGridTextBoxColumn10.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn10.Format = ""
        Me.DataGridTextBoxColumn10.FormatInfo = Nothing
        Me.DataGridTextBoxColumn10.HeaderText = "郵便番号"
        Me.DataGridTextBoxColumn10.MappingName = "郵便番号"
        Me.DataGridTextBoxColumn10.Width = 60
        '
        'DataGridTextBoxColumn11
        '
        Me.DataGridTextBoxColumn11.Format = ""
        Me.DataGridTextBoxColumn11.FormatInfo = Nothing
        Me.DataGridTextBoxColumn11.HeaderText = "住所１"
        Me.DataGridTextBoxColumn11.MappingName = "住所１"
        Me.DataGridTextBoxColumn11.Width = 120
        '
        'DataGridTextBoxColumn12
        '
        Me.DataGridTextBoxColumn12.Format = ""
        Me.DataGridTextBoxColumn12.FormatInfo = Nothing
        Me.DataGridTextBoxColumn12.HeaderText = "住所２"
        Me.DataGridTextBoxColumn12.MappingName = "住所２"
        Me.DataGridTextBoxColumn12.Width = 75
        '
        'DataGridTextBoxColumn13
        '
        Me.DataGridTextBoxColumn13.Format = ""
        Me.DataGridTextBoxColumn13.FormatInfo = Nothing
        Me.DataGridTextBoxColumn13.HeaderText = "電話番号"
        Me.DataGridTextBoxColumn13.MappingName = "電話番号"
        Me.DataGridTextBoxColumn13.Width = 85
        '
        'DataGridTextBoxColumn14
        '
        Me.DataGridTextBoxColumn14.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn14.Format = ""
        Me.DataGridTextBoxColumn14.FormatInfo = Nothing
        Me.DataGridTextBoxColumn14.HeaderText = "行No"
        Me.DataGridTextBoxColumn14.MappingName = "対象商品行NO"
        Me.DataGridTextBoxColumn14.Width = 40
        '
        'DataGridTextBoxColumn15
        '
        Me.DataGridTextBoxColumn15.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn15.Format = ""
        Me.DataGridTextBoxColumn15.FormatInfo = Nothing
        Me.DataGridTextBoxColumn15.HeaderText = "大分類No"
        Me.DataGridTextBoxColumn15.MappingName = "大分類NO"
        Me.DataGridTextBoxColumn15.Width = 60
        '
        'DataGridTextBoxColumn16
        '
        Me.DataGridTextBoxColumn16.Format = ""
        Me.DataGridTextBoxColumn16.FormatInfo = Nothing
        Me.DataGridTextBoxColumn16.HeaderText = "大分類名"
        Me.DataGridTextBoxColumn16.MappingName = "大分類名"
        Me.DataGridTextBoxColumn16.Width = 75
        '
        'DataGridTextBoxColumn17
        '
        Me.DataGridTextBoxColumn17.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn17.Format = ""
        Me.DataGridTextBoxColumn17.FormatInfo = Nothing
        Me.DataGridTextBoxColumn17.HeaderText = "中分類No"
        Me.DataGridTextBoxColumn17.MappingName = "中分類NO"
        Me.DataGridTextBoxColumn17.Width = 60
        '
        'DataGridTextBoxColumn18
        '
        Me.DataGridTextBoxColumn18.Format = ""
        Me.DataGridTextBoxColumn18.FormatInfo = Nothing
        Me.DataGridTextBoxColumn18.HeaderText = "中分類名"
        Me.DataGridTextBoxColumn18.MappingName = "中分類名"
        Me.DataGridTextBoxColumn18.Width = 75
        '
        'DataGridTextBoxColumn19
        '
        Me.DataGridTextBoxColumn19.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn19.Format = ""
        Me.DataGridTextBoxColumn19.FormatInfo = Nothing
        Me.DataGridTextBoxColumn19.HeaderText = "小分類No"
        Me.DataGridTextBoxColumn19.MappingName = "小分類NO"
        Me.DataGridTextBoxColumn19.Width = 60
        '
        'DataGridTextBoxColumn20
        '
        Me.DataGridTextBoxColumn20.Format = ""
        Me.DataGridTextBoxColumn20.FormatInfo = Nothing
        Me.DataGridTextBoxColumn20.HeaderText = "小分類名"
        Me.DataGridTextBoxColumn20.MappingName = "小分類名"
        Me.DataGridTextBoxColumn20.Width = 75
        '
        'DataGridTextBoxColumn21
        '
        Me.DataGridTextBoxColumn21.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn21.Format = ""
        Me.DataGridTextBoxColumn21.FormatInfo = Nothing
        Me.DataGridTextBoxColumn21.HeaderText = "メーカーコード"
        Me.DataGridTextBoxColumn21.MappingName = "メーカーコード"
        Me.DataGridTextBoxColumn21.Width = 75
        '
        'DataGridTextBoxColumn22
        '
        Me.DataGridTextBoxColumn22.Format = ""
        Me.DataGridTextBoxColumn22.FormatInfo = Nothing
        Me.DataGridTextBoxColumn22.HeaderText = "メーカー名"
        Me.DataGridTextBoxColumn22.MappingName = "メーカー名"
        Me.DataGridTextBoxColumn22.Width = 75
        '
        'DataGridTextBoxColumn23
        '
        Me.DataGridTextBoxColumn23.Format = ""
        Me.DataGridTextBoxColumn23.FormatInfo = Nothing
        Me.DataGridTextBoxColumn23.HeaderText = "商品コード"
        Me.DataGridTextBoxColumn23.MappingName = "商品コード"
        Me.DataGridTextBoxColumn23.Width = 75
        '
        'DataGridTextBoxColumn24
        '
        Me.DataGridTextBoxColumn24.Format = ""
        Me.DataGridTextBoxColumn24.FormatInfo = Nothing
        Me.DataGridTextBoxColumn24.HeaderText = "型式"
        Me.DataGridTextBoxColumn24.MappingName = "型式"
        Me.DataGridTextBoxColumn24.Width = 120
        '
        'DataGridTextBoxColumn25
        '
        Me.DataGridTextBoxColumn25.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn25.Format = "##,##0"
        Me.DataGridTextBoxColumn25.FormatInfo = Nothing
        Me.DataGridTextBoxColumn25.HeaderText = "売価"
        Me.DataGridTextBoxColumn25.MappingName = "売価"
        Me.DataGridTextBoxColumn25.Width = 50
        '
        'DataGridTextBoxColumn26
        '
        Me.DataGridTextBoxColumn26.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn26.Format = "##,##0"
        Me.DataGridTextBoxColumn26.FormatInfo = Nothing
        Me.DataGridTextBoxColumn26.HeaderText = "税額"
        Me.DataGridTextBoxColumn26.MappingName = "税額"
        Me.DataGridTextBoxColumn26.Width = 50
        '
        'DataGridTextBoxColumn27
        '
        Me.DataGridTextBoxColumn27.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn27.Format = ""
        Me.DataGridTextBoxColumn27.FormatInfo = Nothing
        Me.DataGridTextBoxColumn27.HeaderText = "購入数量"
        Me.DataGridTextBoxColumn27.MappingName = "購入数量"
        Me.DataGridTextBoxColumn27.Width = 60
        '
        'DataGridTextBoxColumn28
        '
        Me.DataGridTextBoxColumn28.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn28.Format = ""
        Me.DataGridTextBoxColumn28.FormatInfo = Nothing
        Me.DataGridTextBoxColumn28.HeaderText = "店番"
        Me.DataGridTextBoxColumn28.MappingName = "店番"
        Me.DataGridTextBoxColumn28.Width = 40
        '
        'DataGridTextBoxColumn29
        '
        Me.DataGridTextBoxColumn29.Format = ""
        Me.DataGridTextBoxColumn29.FormatInfo = Nothing
        Me.DataGridTextBoxColumn29.HeaderText = "店名"
        Me.DataGridTextBoxColumn29.MappingName = "店名"
        Me.DataGridTextBoxColumn29.Width = 120
        '
        'DataGridTextBoxColumn30
        '
        Me.DataGridTextBoxColumn30.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn30.Format = ""
        Me.DataGridTextBoxColumn30.FormatInfo = Nothing
        Me.DataGridTextBoxColumn30.HeaderText = "データ処理日"
        Me.DataGridTextBoxColumn30.MappingName = "データ処理日"
        Me.DataGridTextBoxColumn30.Width = 80
        '
        'DataGridTextBoxColumn31
        '
        Me.DataGridTextBoxColumn31.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn31.Format = ""
        Me.DataGridTextBoxColumn31.FormatInfo = Nothing
        Me.DataGridTextBoxColumn31.HeaderText = "データ連番"
        Me.DataGridTextBoxColumn31.MappingName = "データ連番"
        Me.DataGridTextBoxColumn31.Width = 60
        '
        'DataGridTextBoxColumn32
        '
        Me.DataGridTextBoxColumn32.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn32.Format = ""
        Me.DataGridTextBoxColumn32.FormatInfo = Nothing
        Me.DataGridTextBoxColumn32.HeaderText = "取引種類"
        Me.DataGridTextBoxColumn32.MappingName = "取引種類"
        Me.DataGridTextBoxColumn32.Width = 60
        '
        'DataGridTextBoxColumn33
        '
        Me.DataGridTextBoxColumn33.Format = ""
        Me.DataGridTextBoxColumn33.FormatInfo = Nothing
        Me.DataGridTextBoxColumn33.HeaderText = "保証商品コード"
        Me.DataGridTextBoxColumn33.MappingName = "保証商品コード"
        Me.DataGridTextBoxColumn33.Width = 90
        '
        'DataGridTextBoxColumn34
        '
        Me.DataGridTextBoxColumn34.Format = ""
        Me.DataGridTextBoxColumn34.FormatInfo = Nothing
        Me.DataGridTextBoxColumn34.HeaderText = "保証商品型式"
        Me.DataGridTextBoxColumn34.MappingName = "保証商品型式"
        Me.DataGridTextBoxColumn34.Width = 120
        '
        'DataGridTextBoxColumn35
        '
        Me.DataGridTextBoxColumn35.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn35.Format = "##,##0"
        Me.DataGridTextBoxColumn35.FormatInfo = Nothing
        Me.DataGridTextBoxColumn35.HeaderText = "保証金額"
        Me.DataGridTextBoxColumn35.MappingName = "保証金額"
        Me.DataGridTextBoxColumn35.Width = 60
        '
        'DataGridTextBoxColumn36
        '
        Me.DataGridTextBoxColumn36.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn36.Format = ""
        Me.DataGridTextBoxColumn36.FormatInfo = Nothing
        Me.DataGridTextBoxColumn36.HeaderText = "保証期間"
        Me.DataGridTextBoxColumn36.MappingName = "保証期間"
        Me.DataGridTextBoxColumn36.Width = 60
        '
        'DataGridTextBoxColumn37
        '
        Me.DataGridTextBoxColumn37.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn37.Format = ""
        Me.DataGridTextBoxColumn37.FormatInfo = Nothing
        Me.DataGridTextBoxColumn37.HeaderText = "保証種類"
        Me.DataGridTextBoxColumn37.MappingName = "保証種類"
        Me.DataGridTextBoxColumn37.Width = 60
        '
        'DataGridTextBoxColumn76
        '
        Me.DataGridTextBoxColumn76.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn76.Format = ""
        Me.DataGridTextBoxColumn76.FormatInfo = Nothing
        Me.DataGridTextBoxColumn76.HeaderText = "SEQ"
        Me.DataGridTextBoxColumn76.MappingName = "SEQ"
        Me.DataGridTextBoxColumn76.Width = 30
        '
        'DataGrid2
        '
        Me.DataGrid2.CaptionBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me.DataGrid2.CaptionForeColor = System.Drawing.Color.Red
        Me.DataGrid2.CaptionText = " エラーリスト"
        Me.DataGrid2.DataMember = ""
        Me.DataGrid2.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid2.Location = New System.Drawing.Point(12, 352)
        Me.DataGrid2.Name = "DataGrid2"
        Me.DataGrid2.ReadOnly = True
        Me.DataGrid2.RowHeaderWidth = 10
        Me.DataGrid2.Size = New System.Drawing.Size(912, 260)
        Me.DataGrid2.TabIndex = 5
        Me.DataGrid2.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle2})
        '
        'DataGridTableStyle2
        '
        Me.DataGridTableStyle2.DataGrid = Me.DataGrid2
        Me.DataGridTableStyle2.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn75, Me.DataGridTextBoxColumn38, Me.DataGridTextBoxColumn39, Me.DataGridTextBoxColumn40, Me.DataGridTextBoxColumn41, Me.DataGridTextBoxColumn42, Me.DataGridTextBoxColumn43, Me.DataGridTextBoxColumn44, Me.DataGridTextBoxColumn45, Me.DataGridTextBoxColumn46, Me.DataGridTextBoxColumn47, Me.DataGridTextBoxColumn48, Me.DataGridTextBoxColumn49, Me.DataGridTextBoxColumn50, Me.DataGridTextBoxColumn51, Me.DataGridTextBoxColumn52, Me.DataGridTextBoxColumn53, Me.DataGridTextBoxColumn54, Me.DataGridTextBoxColumn55, Me.DataGridTextBoxColumn56, Me.DataGridTextBoxColumn57, Me.DataGridTextBoxColumn58, Me.DataGridTextBoxColumn59, Me.DataGridTextBoxColumn60, Me.DataGridTextBoxColumn61, Me.DataGridTextBoxColumn62, Me.DataGridTextBoxColumn63, Me.DataGridTextBoxColumn64, Me.DataGridTextBoxColumn65, Me.DataGridTextBoxColumn66, Me.DataGridTextBoxColumn67, Me.DataGridTextBoxColumn68, Me.DataGridTextBoxColumn69, Me.DataGridTextBoxColumn70, Me.DataGridTextBoxColumn71, Me.DataGridTextBoxColumn72, Me.DataGridTextBoxColumn73, Me.DataGridTextBoxColumn74})
        Me.DataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle2.MappingName = "err"
        '
        'DataGridTextBoxColumn75
        '
        Me.DataGridTextBoxColumn75.Format = ""
        Me.DataGridTextBoxColumn75.FormatInfo = Nothing
        Me.DataGridTextBoxColumn75.HeaderText = "エラーメッセージ"
        Me.DataGridTextBoxColumn75.MappingName = "err_msg"
        Me.DataGridTextBoxColumn75.Width = 120
        '
        'DataGridTextBoxColumn38
        '
        Me.DataGridTextBoxColumn38.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn38.Format = ""
        Me.DataGridTextBoxColumn38.FormatInfo = Nothing
        Me.DataGridTextBoxColumn38.HeaderText = "システム区分"
        Me.DataGridTextBoxColumn38.MappingName = "システム区分"
        Me.DataGridTextBoxColumn38.Width = 75
        '
        'DataGridTextBoxColumn39
        '
        Me.DataGridTextBoxColumn39.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn39.Format = ""
        Me.DataGridTextBoxColumn39.FormatInfo = Nothing
        Me.DataGridTextBoxColumn39.HeaderText = "伝票番号"
        Me.DataGridTextBoxColumn39.MappingName = "伝票番号"
        Me.DataGridTextBoxColumn39.Width = 95
        '
        'DataGridTextBoxColumn40
        '
        Me.DataGridTextBoxColumn40.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn40.Format = ""
        Me.DataGridTextBoxColumn40.FormatInfo = Nothing
        Me.DataGridTextBoxColumn40.HeaderText = "受注日"
        Me.DataGridTextBoxColumn40.MappingName = "受注日"
        Me.DataGridTextBoxColumn40.Width = 80
        '
        'DataGridTextBoxColumn41
        '
        Me.DataGridTextBoxColumn41.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn41.Format = ""
        Me.DataGridTextBoxColumn41.FormatInfo = Nothing
        Me.DataGridTextBoxColumn41.HeaderText = "完了日"
        Me.DataGridTextBoxColumn41.MappingName = "完了日"
        Me.DataGridTextBoxColumn41.Width = 80
        '
        'DataGridTextBoxColumn42
        '
        Me.DataGridTextBoxColumn42.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn42.Format = ""
        Me.DataGridTextBoxColumn42.FormatInfo = Nothing
        Me.DataGridTextBoxColumn42.HeaderText = "キャンセル日"
        Me.DataGridTextBoxColumn42.MappingName = "キャンセル日"
        Me.DataGridTextBoxColumn42.Width = 80
        '
        'DataGridTextBoxColumn43
        '
        Me.DataGridTextBoxColumn43.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn43.Format = ""
        Me.DataGridTextBoxColumn43.FormatInfo = Nothing
        Me.DataGridTextBoxColumn43.HeaderText = "元伝No"
        Me.DataGridTextBoxColumn43.MappingName = "元伝No"
        Me.DataGridTextBoxColumn43.Width = 95
        '
        'DataGridTextBoxColumn44
        '
        Me.DataGridTextBoxColumn44.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn44.Format = ""
        Me.DataGridTextBoxColumn44.FormatInfo = Nothing
        Me.DataGridTextBoxColumn44.HeaderText = "赤伝No"
        Me.DataGridTextBoxColumn44.MappingName = "赤伝No"
        Me.DataGridTextBoxColumn44.Width = 95
        '
        'DataGridTextBoxColumn45
        '
        Me.DataGridTextBoxColumn45.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn45.Format = ""
        Me.DataGridTextBoxColumn45.FormatInfo = Nothing
        Me.DataGridTextBoxColumn45.HeaderText = "顧客番号"
        Me.DataGridTextBoxColumn45.MappingName = "顧客番号"
        Me.DataGridTextBoxColumn45.Width = 95
        '
        'DataGridTextBoxColumn46
        '
        Me.DataGridTextBoxColumn46.Format = ""
        Me.DataGridTextBoxColumn46.FormatInfo = Nothing
        Me.DataGridTextBoxColumn46.HeaderText = "顧客名"
        Me.DataGridTextBoxColumn46.MappingName = "顧客名"
        Me.DataGridTextBoxColumn46.Width = 120
        '
        'DataGridTextBoxColumn47
        '
        Me.DataGridTextBoxColumn47.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn47.Format = ""
        Me.DataGridTextBoxColumn47.FormatInfo = Nothing
        Me.DataGridTextBoxColumn47.HeaderText = "郵便番号"
        Me.DataGridTextBoxColumn47.MappingName = "郵便番号"
        Me.DataGridTextBoxColumn47.Width = 60
        '
        'DataGridTextBoxColumn48
        '
        Me.DataGridTextBoxColumn48.Format = ""
        Me.DataGridTextBoxColumn48.FormatInfo = Nothing
        Me.DataGridTextBoxColumn48.HeaderText = "住所１"
        Me.DataGridTextBoxColumn48.MappingName = "住所１"
        Me.DataGridTextBoxColumn48.Width = 120
        '
        'DataGridTextBoxColumn49
        '
        Me.DataGridTextBoxColumn49.Format = ""
        Me.DataGridTextBoxColumn49.FormatInfo = Nothing
        Me.DataGridTextBoxColumn49.HeaderText = "住所２"
        Me.DataGridTextBoxColumn49.MappingName = "住所２"
        Me.DataGridTextBoxColumn49.Width = 75
        '
        'DataGridTextBoxColumn50
        '
        Me.DataGridTextBoxColumn50.Format = ""
        Me.DataGridTextBoxColumn50.FormatInfo = Nothing
        Me.DataGridTextBoxColumn50.HeaderText = "電話番号"
        Me.DataGridTextBoxColumn50.MappingName = "電話番号"
        Me.DataGridTextBoxColumn50.Width = 85
        '
        'DataGridTextBoxColumn51
        '
        Me.DataGridTextBoxColumn51.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn51.Format = ""
        Me.DataGridTextBoxColumn51.FormatInfo = Nothing
        Me.DataGridTextBoxColumn51.HeaderText = "行NO"
        Me.DataGridTextBoxColumn51.MappingName = "対象商品行NO"
        Me.DataGridTextBoxColumn51.Width = 40
        '
        'DataGridTextBoxColumn52
        '
        Me.DataGridTextBoxColumn52.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn52.Format = ""
        Me.DataGridTextBoxColumn52.FormatInfo = Nothing
        Me.DataGridTextBoxColumn52.HeaderText = "大分類No"
        Me.DataGridTextBoxColumn52.MappingName = "大分類NO"
        Me.DataGridTextBoxColumn52.Width = 60
        '
        'DataGridTextBoxColumn53
        '
        Me.DataGridTextBoxColumn53.Format = ""
        Me.DataGridTextBoxColumn53.FormatInfo = Nothing
        Me.DataGridTextBoxColumn53.HeaderText = "大分類名"
        Me.DataGridTextBoxColumn53.MappingName = "大分類名"
        Me.DataGridTextBoxColumn53.Width = 75
        '
        'DataGridTextBoxColumn54
        '
        Me.DataGridTextBoxColumn54.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn54.Format = ""
        Me.DataGridTextBoxColumn54.FormatInfo = Nothing
        Me.DataGridTextBoxColumn54.HeaderText = "中分類No"
        Me.DataGridTextBoxColumn54.MappingName = "中分類NO"
        Me.DataGridTextBoxColumn54.Width = 60
        '
        'DataGridTextBoxColumn55
        '
        Me.DataGridTextBoxColumn55.Format = ""
        Me.DataGridTextBoxColumn55.FormatInfo = Nothing
        Me.DataGridTextBoxColumn55.HeaderText = "中分類名"
        Me.DataGridTextBoxColumn55.MappingName = "中分類名"
        Me.DataGridTextBoxColumn55.Width = 75
        '
        'DataGridTextBoxColumn56
        '
        Me.DataGridTextBoxColumn56.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn56.Format = ""
        Me.DataGridTextBoxColumn56.FormatInfo = Nothing
        Me.DataGridTextBoxColumn56.HeaderText = "小分類No"
        Me.DataGridTextBoxColumn56.MappingName = "小分類NO"
        Me.DataGridTextBoxColumn56.Width = 60
        '
        'DataGridTextBoxColumn57
        '
        Me.DataGridTextBoxColumn57.Format = ""
        Me.DataGridTextBoxColumn57.FormatInfo = Nothing
        Me.DataGridTextBoxColumn57.HeaderText = "小分類名"
        Me.DataGridTextBoxColumn57.MappingName = "小分類名"
        Me.DataGridTextBoxColumn57.Width = 75
        '
        'DataGridTextBoxColumn58
        '
        Me.DataGridTextBoxColumn58.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn58.Format = ""
        Me.DataGridTextBoxColumn58.FormatInfo = Nothing
        Me.DataGridTextBoxColumn58.HeaderText = "メーカーコード"
        Me.DataGridTextBoxColumn58.MappingName = "メーカーコード"
        Me.DataGridTextBoxColumn58.Width = 75
        '
        'DataGridTextBoxColumn59
        '
        Me.DataGridTextBoxColumn59.Format = ""
        Me.DataGridTextBoxColumn59.FormatInfo = Nothing
        Me.DataGridTextBoxColumn59.HeaderText = "メーカー名"
        Me.DataGridTextBoxColumn59.MappingName = "メーカー名"
        Me.DataGridTextBoxColumn59.Width = 75
        '
        'DataGridTextBoxColumn60
        '
        Me.DataGridTextBoxColumn60.Format = ""
        Me.DataGridTextBoxColumn60.FormatInfo = Nothing
        Me.DataGridTextBoxColumn60.HeaderText = "商品コード"
        Me.DataGridTextBoxColumn60.MappingName = "商品コード"
        Me.DataGridTextBoxColumn60.Width = 75
        '
        'DataGridTextBoxColumn61
        '
        Me.DataGridTextBoxColumn61.Format = ""
        Me.DataGridTextBoxColumn61.FormatInfo = Nothing
        Me.DataGridTextBoxColumn61.HeaderText = "型式"
        Me.DataGridTextBoxColumn61.MappingName = "型式"
        Me.DataGridTextBoxColumn61.Width = 120
        '
        'DataGridTextBoxColumn62
        '
        Me.DataGridTextBoxColumn62.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn62.Format = ""
        Me.DataGridTextBoxColumn62.FormatInfo = Nothing
        Me.DataGridTextBoxColumn62.HeaderText = "売価"
        Me.DataGridTextBoxColumn62.MappingName = "売価"
        Me.DataGridTextBoxColumn62.Width = 50
        '
        'DataGridTextBoxColumn63
        '
        Me.DataGridTextBoxColumn63.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn63.Format = ""
        Me.DataGridTextBoxColumn63.FormatInfo = Nothing
        Me.DataGridTextBoxColumn63.HeaderText = "税額"
        Me.DataGridTextBoxColumn63.MappingName = "税額"
        Me.DataGridTextBoxColumn63.Width = 50
        '
        'DataGridTextBoxColumn64
        '
        Me.DataGridTextBoxColumn64.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn64.Format = ""
        Me.DataGridTextBoxColumn64.FormatInfo = Nothing
        Me.DataGridTextBoxColumn64.HeaderText = "購入数量"
        Me.DataGridTextBoxColumn64.MappingName = "購入数量"
        Me.DataGridTextBoxColumn64.Width = 60
        '
        'DataGridTextBoxColumn65
        '
        Me.DataGridTextBoxColumn65.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn65.Format = ""
        Me.DataGridTextBoxColumn65.FormatInfo = Nothing
        Me.DataGridTextBoxColumn65.HeaderText = "店番"
        Me.DataGridTextBoxColumn65.MappingName = "店番"
        Me.DataGridTextBoxColumn65.Width = 40
        '
        'DataGridTextBoxColumn66
        '
        Me.DataGridTextBoxColumn66.Format = ""
        Me.DataGridTextBoxColumn66.FormatInfo = Nothing
        Me.DataGridTextBoxColumn66.HeaderText = "店名"
        Me.DataGridTextBoxColumn66.MappingName = "店名"
        Me.DataGridTextBoxColumn66.Width = 120
        '
        'DataGridTextBoxColumn67
        '
        Me.DataGridTextBoxColumn67.Format = ""
        Me.DataGridTextBoxColumn67.FormatInfo = Nothing
        Me.DataGridTextBoxColumn67.HeaderText = "データ処理日"
        Me.DataGridTextBoxColumn67.MappingName = "データ処理日"
        Me.DataGridTextBoxColumn67.Width = 80
        '
        'DataGridTextBoxColumn68
        '
        Me.DataGridTextBoxColumn68.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn68.Format = ""
        Me.DataGridTextBoxColumn68.FormatInfo = Nothing
        Me.DataGridTextBoxColumn68.HeaderText = "データ連番"
        Me.DataGridTextBoxColumn68.MappingName = "データ連番"
        Me.DataGridTextBoxColumn68.Width = 60
        '
        'DataGridTextBoxColumn69
        '
        Me.DataGridTextBoxColumn69.Format = ""
        Me.DataGridTextBoxColumn69.FormatInfo = Nothing
        Me.DataGridTextBoxColumn69.HeaderText = "取引種類"
        Me.DataGridTextBoxColumn69.MappingName = "取引種類"
        Me.DataGridTextBoxColumn69.Width = 60
        '
        'DataGridTextBoxColumn70
        '
        Me.DataGridTextBoxColumn70.Format = ""
        Me.DataGridTextBoxColumn70.FormatInfo = Nothing
        Me.DataGridTextBoxColumn70.HeaderText = "保証商品コード"
        Me.DataGridTextBoxColumn70.MappingName = "保証商品コード"
        Me.DataGridTextBoxColumn70.Width = 90
        '
        'DataGridTextBoxColumn71
        '
        Me.DataGridTextBoxColumn71.Format = ""
        Me.DataGridTextBoxColumn71.FormatInfo = Nothing
        Me.DataGridTextBoxColumn71.HeaderText = "保証商品型式"
        Me.DataGridTextBoxColumn71.MappingName = "保証商品型式"
        Me.DataGridTextBoxColumn71.Width = 120
        '
        'DataGridTextBoxColumn72
        '
        Me.DataGridTextBoxColumn72.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn72.Format = ""
        Me.DataGridTextBoxColumn72.FormatInfo = Nothing
        Me.DataGridTextBoxColumn72.HeaderText = "保証金額"
        Me.DataGridTextBoxColumn72.MappingName = "保証金額"
        Me.DataGridTextBoxColumn72.Width = 60
        '
        'DataGridTextBoxColumn73
        '
        Me.DataGridTextBoxColumn73.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn73.Format = ""
        Me.DataGridTextBoxColumn73.FormatInfo = Nothing
        Me.DataGridTextBoxColumn73.HeaderText = "保証期間"
        Me.DataGridTextBoxColumn73.MappingName = "保証期間"
        Me.DataGridTextBoxColumn73.Width = 60
        '
        'DataGridTextBoxColumn74
        '
        Me.DataGridTextBoxColumn74.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn74.Format = ""
        Me.DataGridTextBoxColumn74.FormatInfo = Nothing
        Me.DataGridTextBoxColumn74.HeaderText = "保証種類"
        Me.DataGridTextBoxColumn74.MappingName = "保証種類"
        Me.DataGridTextBoxColumn74.Width = 60
        '
        'Button4
        '
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Location = New System.Drawing.Point(508, 12)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(124, 40)
        Me.Button4.TabIndex = 2
        Me.Button4.Text = "クリア"
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Location = New System.Drawing.Point(368, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(124, 40)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "反映"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(824, 356)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 16)
        Me.Label1.TabIndex = 1349
        Me.Label1.Text = "Label1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Location = New System.Drawing.Point(652, 12)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(124, 40)
        Me.Button3.TabIndex = 1350
        Me.Button3.Text = "エラー出力"
        Me.Button3.Visible = False
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(930, 655)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.DataGrid2)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.Button1)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "保証データ取込み Var 2.0"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '***************************************************************************
    '** 起動時
    '***************************************************************************
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        objMutex = New System.Threading.Mutex(False, "best_yamada_import")
        If objMutex.WaitOne(0, False) = False Then
            MessageBox.Show("すでに起動しています", "実行結果")
            Application.Exit()
        End If
        DB_INIT()
        Call inz()      '** 初期処理
    End Sub

    '***************************************************************************
    '** 初期処理
    '***************************************************************************
    Sub inz()

        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        strSQL = "SELECT '' AS 区分, '' AS システム区分, '' AS 伝票番号, '' AS 受注日, '' AS 完了日, '' AS キャンセル日, '' AS 元伝No, '' AS 赤伝No, '' AS 顧客番号, '' AS 顧客名"
        strSQL += ", '' AS 郵便番号, '' AS 住所１, '' AS 住所２, '' AS 電話番号, '' AS 対象商品行NO, '' AS 大分類NO, '' AS 大分類名, '' AS 中分類NO, '' AS 中分類名, '' AS 小分類NO"
        strSQL += ", '' AS 小分類名, '' AS メーカーコード, '' AS メーカー名, '' AS 商品コード, '' AS 型式, '' AS 売価, '' AS 税額, '' AS 購入数量, '' AS 店番, '' AS 店名"
        strSQL += ", '' AS データ処理日, 0 AS データ連番, '' AS 取引種類, '' AS 保証商品コード, '' AS 保証商品型式, '' AS 保証金額, '' AS 保証期間, '' AS 保証種類"
        strSQL += ", 0 AS SEQ, '' AS err_msg"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(DsImp, "imp")
        DaList1.Fill(DsImp, "ok")
        DaList1.Fill(DsImp, "err")
        DaList1.Fill(DsImp, "read")
        DB_CLOSE()

        DsImp.Clear()

        Dim tbl1 As New DataTable
        tbl1 = DsImp.Tables("imp")
        DataGrid1.DataSource = tbl1

        Dim tbl2 As New DataTable
        tbl2 = DsImp.Tables("err")
        DataGrid2.DataSource = tbl2

        Label1.Text = Nothing
        Button2.Enabled = False
        msg.Text = Nothing

        'tax_date = "2014/04/01"         '消費税8%対応　2014/04/22
        tax_date = "2019/10/01"         '消費税10%対応　2019/10/18
    End Sub

    '***************************************************************************
    '** 取込み
    '***************************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DsImp.Clear()
        Label1.Text = Nothing
        SEQ = 0

        With OpenFileDialog1
            .CheckFileExists = True     'ファイルが存在するか確認
            .RestoreDirectory = True    'ディレクトリの復元
            .ReadOnlyChecked = True
            .ShowReadOnly = True
            .Filter = "csv ﾌｧｲﾙ(*.csv)|*.csv|すべてのファイル(*.*)|*.*"
            .FilterIndex = 1            'Filterプロパティの2つ目を表示
            'ダイアログボックスを表示し、［開く]をクリックした場合
            If .ShowDialog = DialogResult.OK Then
                Cursor = System.Windows.Forms.Cursors.WaitCursor
                file_name = .FileName

                Dim srFile As New System.IO.StreamReader(file_name, System.Text.Encoding.Default)
                Dim strLine As String = srFile.ReadLine()
                Dim strTemp() As String     '戻り配列
                'Dim intCnt As Integer       '配列添え字
                While Not strLine Is Nothing

                    '行単位データをカンマ部分で分割し、配列へ格納
                    strTemp = Split(strLine, ",")

                    Select Case strTemp(0)
                        Case Is = "H"
                            CNT = CInt(strTemp(3))

                            ' 進行状況ダイアログの初期化処理
                            waitDlg = New WaitDialog        ' 進行状況ダイアログ
                            waitDlg.Owner = Me              ' ダイアログのオーナーを設定する
                            waitDlg.MainMsg = Nothing       ' 処理の概要を表示
                            waitDlg.ProgressMax = 0         ' 全体の処理件数を設定
                            waitDlg.ProgressMin = 0         ' 処理件数の最小値を設定（0件から開始）
                            waitDlg.ProgressStep = 1        ' 何件ごとにメータを進めるかを設定
                            waitDlg.ProgressValue = 0       ' 最初の件数を設定
                            'Me.Enabled = False              ' オーナーのフォームを無効にする
                            Button1.Enabled = False
                            Button4.Enabled = False
                            Button98.Enabled = False
                            waitDlg.Show()                  ' 進行状況ダイアログを表示する

                            waitDlg.MainMsg = "取込み中"    ' 進行状況ダイアログのメーターを設定
                            waitDlg.ProgressMsg = ""        ' 進行状況ダイアログのメーターを設定
                            waitDlg.ProgressMax = CNT       ' 全体の処理件数を設定
                            waitDlg.ProgressValue = 0       ' 最初の件数を設定
                            Application.DoEvents()          ' メッセージ処理を促して表示を更新する

                        Case Is = "B"
                            SEQ += 1
                            waitDlg.ProgressMsg = Fix(SEQ * 100 / CNT) & "%　（" & Format(SEQ, "##,##0") & " / " & Format(CNT, "##,##0") & " 件）"
                            waitDlg.Text = "実行中・・・" & Fix(SEQ * 100 / CNT) & "%"
                            Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                            waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                            dttable0 = DsImp.Tables("imp")
                            dtRow0 = dttable0.NewRow
                            dtRow0("区分") = strTemp(0)
                            dtRow0("システム区分") = strTemp(1)
                            dtRow0("伝票番号") = strTemp(2)
                            If strTemp(3) = "" Then dtRow0("受注日") = "" Else dtRow0("受注日") = MidB(strTemp(3), 1, 4) & "/" & MidB(strTemp(3), 5, 2) & "/" & MidB(strTemp(3), 7, 2)
                            If strTemp(4) = "" Then dtRow0("完了日") = "" Else dtRow0("完了日") = MidB(strTemp(4), 1, 4) & "/" & MidB(strTemp(4), 5, 2) & "/" & MidB(strTemp(4), 7, 2)
                            If strTemp(5) = "" Then dtRow0("キャンセル日") = "" Else dtRow0("キャンセル日") = MidB(strTemp(5), 1, 4) & "/" & MidB(strTemp(5), 5, 2) & "/" & MidB(strTemp(5), 7, 2)
                            If strTemp(6) = "0.00" Then dtRow0("元伝No") = "" Else dtRow0("元伝No") = strTemp(6)
                            If strTemp(7) = "0.00" Then dtRow0("赤伝No") = "" Else dtRow0("赤伝No") = strTemp(7)
                            If strTemp(8) = "0.00" Then dtRow0("顧客番号") = "" Else dtRow0("顧客番号") = strTemp(8)
                            dtRow0("顧客名") = strTemp(9)
                            dtRow0("郵便番号") = strTemp(10)
                            dtRow0("住所１") = strTemp(11)
                            dtRow0("住所２") = strTemp(12)
                            dtRow0("電話番号") = strTemp(13)
                            dtRow0("対象商品行NO") = Format(CInt(strTemp(14)), "00")
                            dtRow0("大分類NO") = Format(CInt(strTemp(15)), "0000")
                            dtRow0("大分類名") = strTemp(16)
                            dtRow0("中分類NO") = Format(CInt(strTemp(17)), "00")
                            dtRow0("中分類名") = strTemp(18)
                            dtRow0("小分類NO") = Format(CInt(strTemp(19)), "00")
                            dtRow0("小分類名") = strTemp(20)
                            dtRow0("メーカーコード") = Format(CInt(strTemp(21)), "00000")
                            dtRow0("メーカー名") = strTemp(22)
                            dtRow0("商品コード") = strTemp(23)
                            dtRow0("型式") = strTemp(24)
                            dtRow0("売価") = CInt(strTemp(25))
                            dtRow0("税額") = CInt(strTemp(26))
                            dtRow0("購入数量") = CInt(strTemp(27))
                            dtRow0("店番") = Format(CInt(strTemp(28)), "0000")
                            dtRow0("店名") = strTemp(29)
                            If strTemp(30) = "" Then dtRow0("データ処理日") = "" Else dtRow0("データ処理日") = MidB(strTemp(30), 1, 4) & "/" & MidB(strTemp(30), 5, 2) & "/" & MidB(strTemp(30), 7, 2)
                            dtRow0("データ連番") = CInt(strTemp(31))
                            dtRow0("取引種類") = strTemp(32)
                            dtRow0("保証商品コード") = strTemp(33)
                            dtRow0("保証商品型式") = strTemp(34)
                            dtRow0("保証金額") = CInt(strTemp(35))
                            dtRow0("保証期間") = CInt(strTemp(36))
                            dtRow0("保証種類") = strTemp(37)
                            dtRow0("SEQ") = SEQ
                            dttable0.Rows.Add(dtRow0)

                        Case Is = "E"

                    End Select

                    strLine = srFile.ReadLine()
                End While

                srFile.Close()

                Call ok_err()    '** ＯＫデータとエラーデータの振り分け

                MsgBox("終了", MsgBoxStyle.OKOnly, "取込み")
                waitDlg.Close()         '進行状況ダイアログを閉じる
                'Me.Enabled = True       'オーナーのフォームを無効にする
                Button1.Enabled = True
                Button4.Enabled = True
                Button98.Enabled = True

            End If
        End With

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** ＯＫデータとエラーデータの振り分け
    '******************************************************************
    Sub ok_err()
        ok_cnt = 0
        err_cnt = 0
        DsImp.Tables("ok").Clear()
        DsImp.Tables("err").Clear()

        DtView1 = New DataView(DsImp.Tables("imp"), "", "データ連番", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then

            waitDlg.MainMsg = "チェック中"      ' 進行状況ダイアログのメーターを設定
            waitDlg.ProgressMsg = ""            ' 進行状況ダイアログのメーターを設定
            waitDlg.ProgressMax = DtView1.Count ' 全体の処理件数を設定
            waitDlg.ProgressValue = 0           ' 最初の件数を設定
            Application.DoEvents()              ' メッセージ処理を促して表示を更新する

            For k = 0 To DtView1.Count - 1

                Call DG_chk()

                waitDlg.ProgressMsg = Fix((k + 1) * 100 / DtView1.Count) & "%　（" & Format((k + 1), "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
                waitDlg.Text = "実行中・・・" & Fix((k + 1) * 100 / DtView1.Count) & "%"
                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                If DG_Err_F = "0" Then
                    ok_cnt = ok_cnt + 1
                    dttable1 = DsImp.Tables("ok")
                    dtRow1 = dttable1.NewRow
                    dtRow1("区分") = DtView1(k)("区分")
                    dtRow1("システム区分") = DtView1(k)("システム区分")
                    dtRow1("伝票番号") = DtView1(k)("伝票番号")
                    dtRow1("受注日") = DtView1(k)("受注日")
                    dtRow1("完了日") = DtView1(k)("完了日")
                    dtRow1("キャンセル日") = DtView1(k)("キャンセル日")
                    dtRow1("元伝No") = DtView1(k)("元伝No")
                    dtRow1("赤伝No") = DtView1(k)("赤伝No")
                    dtRow1("顧客番号") = DtView1(k)("顧客番号")
                    dtRow1("顧客名") = DtView1(k)("顧客名")
                    dtRow1("郵便番号") = DtView1(k)("郵便番号")
                    dtRow1("住所１") = DtView1(k)("住所１")
                    dtRow1("住所２") = DtView1(k)("住所２")
                    dtRow1("電話番号") = DtView1(k)("電話番号")
                    dtRow1("対象商品行NO") = DtView1(k)("対象商品行NO")
                    dtRow1("大分類NO") = DtView1(k)("大分類NO")
                    dtRow1("大分類名") = DtView1(k)("大分類名")
                    dtRow1("中分類NO") = DtView1(k)("中分類NO")
                    dtRow1("中分類名") = DtView1(k)("中分類名")
                    dtRow1("小分類NO") = DtView1(k)("小分類NO")
                    dtRow1("小分類名") = DtView1(k)("小分類名")
                    dtRow1("メーカーコード") = DtView1(k)("メーカーコード")
                    dtRow1("メーカー名") = DtView1(k)("メーカー名")
                    dtRow1("商品コード") = DtView1(k)("商品コード")
                    dtRow1("型式") = DtView1(k)("型式")
                    dtRow1("売価") = DtView1(k)("売価")
                    dtRow1("税額") = DtView1(k)("税額")
                    dtRow1("購入数量") = DtView1(k)("購入数量")
                    dtRow1("店番") = DtView1(k)("店番")
                    dtRow1("店名") = DtView1(k)("店名")
                    dtRow1("データ処理日") = DtView1(k)("データ処理日")
                    dtRow1("データ連番") = DtView1(k)("データ連番")
                    dtRow1("取引種類") = DtView1(k)("取引種類")
                    dtRow1("保証商品コード") = DtView1(k)("保証商品コード")
                    dtRow1("保証商品型式") = DtView1(k)("保証商品型式")
                    dtRow1("保証金額") = DtView1(k)("保証金額")
                    dtRow1("保証期間") = DtView1(k)("保証期間")
                    dtRow1("保証種類") = DtView1(k)("保証種類")
                    dtRow1("SEQ") = DtView1(k)("SEQ")
                    dttable1.Rows.Add(dtRow1)
                Else
                    err_cnt = err_cnt + 1
                    dttable2 = DsImp.Tables("err")
                    dtRow2 = dttable2.NewRow
                    dtRow2("err_msg") = WK_err_msg
                    dtRow2("区分") = DtView1(k)("区分")
                    dtRow2("システム区分") = DtView1(k)("システム区分")
                    dtRow2("伝票番号") = DtView1(k)("伝票番号")
                    dtRow2("受注日") = DtView1(k)("受注日")
                    dtRow2("完了日") = DtView1(k)("完了日")
                    dtRow2("キャンセル日") = DtView1(k)("キャンセル日")
                    dtRow2("元伝No") = DtView1(k)("元伝No")
                    dtRow2("赤伝No") = DtView1(k)("赤伝No")
                    dtRow2("顧客番号") = DtView1(k)("顧客番号")
                    dtRow2("顧客名") = DtView1(k)("顧客名")
                    dtRow2("郵便番号") = DtView1(k)("郵便番号")
                    dtRow2("住所１") = DtView1(k)("住所１")
                    dtRow2("住所２") = DtView1(k)("住所２")
                    dtRow2("電話番号") = DtView1(k)("電話番号")
                    dtRow2("対象商品行NO") = DtView1(k)("対象商品行NO")
                    dtRow2("大分類NO") = DtView1(k)("大分類NO")
                    dtRow2("大分類名") = DtView1(k)("大分類名")
                    dtRow2("中分類NO") = DtView1(k)("中分類NO")
                    dtRow2("中分類名") = DtView1(k)("中分類名")
                    dtRow2("小分類NO") = DtView1(k)("小分類NO")
                    dtRow2("小分類名") = DtView1(k)("小分類名")
                    dtRow2("メーカーコード") = DtView1(k)("メーカーコード")
                    dtRow2("メーカー名") = DtView1(k)("メーカー名")
                    dtRow2("商品コード") = DtView1(k)("商品コード")
                    dtRow2("型式") = DtView1(k)("型式")
                    dtRow2("売価") = DtView1(k)("売価")
                    dtRow2("税額") = DtView1(k)("税額")
                    dtRow2("購入数量") = DtView1(k)("購入数量")
                    dtRow2("店番") = DtView1(k)("店番")
                    dtRow2("店名") = DtView1(k)("店名")
                    dtRow2("データ処理日") = DtView1(k)("データ処理日")
                    dtRow2("データ連番") = DtView1(k)("データ連番")
                    dtRow2("取引種類") = DtView1(k)("取引種類")
                    dtRow2("保証商品コード") = DtView1(k)("保証商品コード")
                    dtRow2("保証商品型式") = DtView1(k)("保証商品型式")
                    dtRow2("保証金額") = DtView1(k)("保証金額")
                    dtRow2("保証期間") = DtView1(k)("保証期間")
                    dtRow2("保証種類") = DtView1(k)("保証種類")
                    dtRow2("SEQ") = DtView1(k)("SEQ")
                    dttable2.Rows.Add(dtRow2)

                    DtView1(k)("err_msg") = WK_err_msg
                    Label1.Text = Format(err_cnt, "##,##0") & "件"
                End If
            Next
            Button2.Enabled = True
        Else
            Button2.Enabled = False
        End If

    End Sub

    '******************************************************************
    '** 項目チェック
    '******************************************************************
    Sub DG_chk()
        DG_Err_F = "0"

        'システム区分(B:BEST Y:YAMADA)
        Select Case DtView1(k)("システム区分")
            Case Is = Nothing, ""
                WK_err_msg = "システム区分 未入力"
                DG_Err_F = "1" : Exit Sub
            Case Is = "B", "Y"
            Case Else
                WK_err_msg = "システム区分 エラー"
                DG_Err_F = "1" : Exit Sub
        End Select

        '取引種類(1:受注 2:完了 3:キャンセル 4:完了キャンセル)
        Select Case DtView1(k)("取引種類")
            Case Is = Nothing, ""
                WK_err_msg = "取引種類 未入力"
                DG_Err_F = "1" : Exit Sub
            Case Is = "1", "2", "3", "4"
            Case Else
                WK_err_msg = "取引種類 エラー"
                DG_Err_F = "1" : Exit Sub
        End Select

        '保証種類
        If DtView1(k)("保証種類") = Nothing Then
            If DtView1(k)("取引種類") = "1" Then    '受注
                WK_err_msg = "保証種類 未入力"
                DG_Err_F = "1" : Exit Sub
            End If
        Else
            WK_DsList1.Clear()
            strSQL = "SELECT CLS_CODE FROM V_cls_016 WHERE (CLS_CODE = '" & DtView1(k)("保証種類") & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN()
            r = DaList1.Fill(WK_DsList1, "cls016")
            DB_CLOSE()
            If r = 0 Then
                WK_err_msg = "保証種類 エラー"
                DG_Err_F = "1" : Exit Sub
            End If
        End If

        '伝票番号
        If DtView1(k)("伝票番号") = Nothing Then
            WK_err_msg = "伝票番号 未入力"
            DG_Err_F = "1" : Exit Sub
        Else
            If LenB(DtView1(k)("伝票番号")) > 13 Then
                WK_err_msg = "伝票番号 桁数オーバー"
                DG_Err_F = "1" : Exit Sub
            Else
                Select Case DtView1(k)("取引種類")
                    Case Is = "1"       '受注
                    Case Is = "2", "4"  '完了 '完了キャンセル
                        WK_DsList1.Clear()
                        strSQL = "SELECT ordr_no FROM Wrn_mtr WHERE (ordr_no = '" & DtView1(k)("伝票番号") & "')"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DaList1.SelectCommand = SqlCmd1
                        DB_OPEN()
                        r = DaList1.Fill(WK_DsList1, "Wrn_mtr")
                        DB_CLOSE()
                        If r = 0 Then   'オール電化もチェックする
                            WK_DsList1.Clear()
                            strSQL = "SELECT ordr_no FROM All8_Wrn_mtr WHERE (ordr_no = '" & DtView1(k)("伝票番号") & "')"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            DaList1.SelectCommand = SqlCmd1
                            DB_OPEN()
                            r = DaList1.Fill(WK_DsList1, "Wrn_mtr")
                            DB_CLOSE()
                            If r = 0 Then   'DBに無ければ取込みデータもチェックする
                                WK_DtView1 = New DataView(DsImp.Tables("imp"), "伝票番号 = '" & DtView1(k)("伝票番号") & "' AND 取引種類 = '1' AND データ連番 < " & DtView1(k)("データ連番") & " AND err_msg IS NULL", "", DataViewRowState.CurrentRows)
                                If WK_DtView1.Count = 0 Then
                                    WK_err_msg = "該当する受注なし"
                                    DG_Err_F = "1" : Exit Sub
                                End If
                            End If
                        End If
                    Case Is = "3"       'キャンセル
                        WK_DsList1.Clear()
                        If DtView1(k)("保証種類") = "0100" Or DtView1(k)("保証種類") = "0200" Or DtView1(k)("保証種類") = "0210" Then
                            strSQL = "SELECT ordr_no FROM Wrn_mtr WHERE (ordr_no = '" & DtView1(k)("伝票番号") & "')"
                        Else
                            strSQL = "SELECT ordr_no FROM All8_Wrn_mtr WHERE (ordr_no = '" & DtView1(k)("伝票番号") & "')"
                        End If
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DaList1.SelectCommand = SqlCmd1
                        DB_OPEN()
                        r = DaList1.Fill(WK_DsList1, "Wrn_mtr")
                        DB_CLOSE()
                        If r = 0 Then   'DBに無ければ取込みデータもチェックする
                            WK_DtView1 = New DataView(DsImp.Tables("imp"), "伝票番号 = '" & DtView1(k)("伝票番号") & "' AND 取引種類 = '1' AND データ連番 < " & DtView1(k)("データ連番") & " AND err_msg IS NULL", "", DataViewRowState.CurrentRows)
                            If WK_DtView1.Count = 0 Then
                                WK_err_msg = "該当する受注なし"
                                DG_Err_F = "1" : Exit Sub
                            End If
                        End If
                End Select
            End If
        End If

        '対象商品行NO
        If DtView1(k)("対象商品行NO") = Nothing Then
            WK_err_msg = "対象商品行NO 未入力"
            DG_Err_F = "1" : Exit Sub
        Else
            If LenB(DtView1(k)("対象商品行NO")) > 2 Then
                WK_err_msg = "対象商品行NO 桁数オーバー"
                DG_Err_F = "1" : Exit Sub
            Else
                Select Case DtView1(k)("取引種類")
                    Case Is = "1"   '受注
                        WK_DsList1.Clear()
                        If DtView1(k)("保証種類") = "0100" Or DtView1(k)("保証種類") = "0200" Or DtView1(k)("保証種類") = "0210" Then
                            strSQL = "SELECT ordr_no, line_no FROM Wrn_sub WHERE (ordr_no = '" & DtView1(k)("伝票番号") & "') AND (line_no = '" & DtView1(k)("対象商品行NO") & "')"
                        Else
                            strSQL = "SELECT ordr_no, line_no FROM All8_Wrn_sub WHERE (ordr_no = '" & DtView1(k)("伝票番号") & "') AND (line_no = '" & DtView1(k)("対象商品行NO") & "')"
                        End If
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DaList1.SelectCommand = SqlCmd1
                        DB_OPEN()
                        r = DaList1.Fill(WK_DsList1, "Wrn_sub")
                        DB_CLOSE()
                        If r <> 0 Then
                            WK_err_msg = "登録済みの伝票番号・行Noです。"
                            DG_Err_F = "1" : Exit Sub
                        Else
                            WK_DtView1 = New DataView(DsImp.Tables("imp"), "伝票番号 = '" & DtView1(k)("伝票番号") & "' AND 対象商品行NO = '" & DtView1(k)("対象商品行NO") & "' AND SEQ <>" & DtView1(k)("SEQ") & " AND 取引種類 = '1'", "", DataViewRowState.CurrentRows)
                            If WK_DtView1.Count <> 0 Then
                                WK_err_msg = "重複する伝票番号・行Noがあります。"
                                DG_Err_F = "1" : Exit Sub
                            End If
                        End If
                    Case Is = "2", "4"  '完了 '完了キャンセル
                        WK_DsList1.Clear()
                        strSQL = "SELECT ordr_no, line_no FROM Wrn_sub WHERE (ordr_no = '" & DtView1(k)("伝票番号") & "') AND (line_no = '" & DtView1(k)("対象商品行NO") & "')"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DaList1.SelectCommand = SqlCmd1
                        DB_OPEN()
                        r = DaList1.Fill(WK_DsList1, "Wrn_mtr")
                        DB_CLOSE()
                        If r = 0 Then   'オール電化もチェックする
                            WK_DsList1.Clear()
                            strSQL = "SELECT ordr_no, line_no, kbn_cd FROM All8_Wrn_sub WHERE (ordr_no = '" & DtView1(k)("伝票番号") & "') AND (line_no = '" & DtView1(k)("対象商品行NO") & "')"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            DaList1.SelectCommand = SqlCmd1
                            DB_OPEN()
                            r = DaList1.Fill(WK_DsList1, "Wrn_mtr")
                            DB_CLOSE()
                            If r = 0 Then   'DBに無ければ取込みデータもチェックする
                                WK_DtView1 = New DataView(DsImp.Tables("imp"), "伝票番号 = '" & DtView1(k)("伝票番号") & "' AND 対象商品行NO = '" & DtView1(k)("対象商品行NO") & "' AND 取引種類 = '1' AND データ連番 < " & DtView1(k)("データ連番") & " AND err_msg IS NULL", "", DataViewRowState.CurrentRows)
                                If WK_DtView1.Count = 0 Then
                                    WK_err_msg = "該当する受注なし"
                                    DG_Err_F = "1" : Exit Sub
                                Else
                                    DtView1(k)("保証種類") = WK_DtView1(0)("保証種類")
                                End If
                            Else
                                WK_DtView1 = New DataView(WK_DsList1.Tables("Wrn_mtr"), "", "", DataViewRowState.CurrentRows)
                                DtView1(k)("保証種類") = WK_DtView1(0)("kbn_cd")
                            End If
                        Else
                            WK_DtView1 = New DataView(WK_DsList1.Tables("Wrn_mtr"), "", "", DataViewRowState.CurrentRows)
                            DtView1(k)("保証種類") = "0100"
                        End If
                    Case Is = "3"       'キャンセル
                        WK_DsList1.Clear()
                        If DtView1(k)("保証種類") = "0100" Or DtView1(k)("保証種類") = "0200" Or DtView1(k)("保証種類") = "0210" Then
                            strSQL = "SELECT ordr_no, line_no FROM Wrn_sub WHERE (ordr_no = '" & DtView1(k)("伝票番号") & "') AND (line_no = '" & DtView1(k)("対象商品行NO") & "')"
                        Else
                            strSQL = "SELECT ordr_no, line_no FROM All8_Wrn_sub WHERE (ordr_no = '" & DtView1(k)("伝票番号") & "') AND (line_no = '" & DtView1(k)("対象商品行NO") & "')"
                        End If
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DaList1.SelectCommand = SqlCmd1
                        DB_OPEN()
                        r = DaList1.Fill(WK_DsList1, "Wrn_mtr")
                        DB_CLOSE()
                        If r = 0 Then
                            WK_DtView1 = New DataView(DsImp.Tables("imp"), "伝票番号 = '" & DtView1(k)("伝票番号") & "' AND 対象商品行NO = '" & DtView1(k)("対象商品行NO") & "' AND 取引種類 = '1' AND データ連番 < " & DtView1(k)("データ連番") & " AND err_msg IS NULL", "", DataViewRowState.CurrentRows)
                            If WK_DtView1.Count = 0 Then
                                WK_err_msg = "該当する受注なし"
                                DG_Err_F = "1" : Exit Sub
                            End If
                        End If
                End Select
            End If
        End If

        '受注日
        Select Case DtView1(k)("取引種類")
            Case Is = "1"   '受注
                If DtView1(k)("受注日") = Nothing Then
                    WK_err_msg = "受注日 未入力"
                    DG_Err_F = "1" : Exit Sub
                Else
                    If IsDate(DtView1(k)("受注日")) = False Then
                        WK_err_msg = "受注日 エラー"
                        DG_Err_F = "1" : Exit Sub
                    End If
                End If
            Case Is = "2", "3"  '完了'キャンセル
                If DtView1(k)("受注日") = Nothing Then
                Else
                    If IsDate(DtView1(k)("受注日")) = False Then
                        WK_err_msg = "受注日 エラー"
                        DG_Err_F = "1" : Exit Sub
                    End If
                End If
        End Select

        '完了日
        Select Case DtView1(k)("取引種類")
            Case Is = "1"   '受注
                If DtView1(k)("完了日") = Nothing Then
                Else
                    If IsDate(DtView1(k)("完了日")) = False Then
                        WK_err_msg = "完了日 エラー"
                        DG_Err_F = "1" : Exit Sub
                    End If
                End If
            Case Is = "2"   '完了
                If DtView1(k)("完了日") = Nothing Then
                    WK_err_msg = "完了日 未入力"
                    DG_Err_F = "1" : Exit Sub
                Else
                    If IsDate(DtView1(k)("完了日")) = False Then
                        WK_err_msg = "完了日 エラー"
                        DG_Err_F = "1" : Exit Sub
                    End If
                End If
            Case Is = "3"   'キャンセル
                If DtView1(k)("完了日") <> Nothing Then
                    WK_err_msg = "完了日 入力エラー"
                    DG_Err_F = "1" : Exit Sub
                End If
        End Select

        'キャンセル日
        If DtView1(k)("取引種類") = "3" Then    'キャンセル
            If DtView1(k)("キャンセル日") = Nothing Then
                WK_err_msg = "キャンセル日 未入力"
                DG_Err_F = "1" : Exit Sub
            Else
                If IsDate(DtView1(k)("キャンセル日")) = False Then
                    WK_err_msg = "キャンセル日 エラー"
                    DG_Err_F = "1" : Exit Sub
                End If
            End If
        End If

        '元伝No
        If DtView1(k)("取引種類") = "1" Then
            If DtView1(k)("元伝No") = "0" Then DtView1(k)("元伝No") = ""
            If DtView1(k)("元伝No") = Nothing Then
            Else
                If LenB(DtView1(k)("元伝No")) > 13 Then
                    WK_err_msg = "元伝No 桁数オーバー"
                    DG_Err_F = "1" : Exit Sub
                End If
            End If
        End If

        '赤伝No
        If DtView1(k)("赤伝No") = "0" Then DtView1(k)("赤伝No") = ""
        If DtView1(k)("取引種類") = "3" Then    'キャンセル
            If DtView1(k)("赤伝No") = Nothing Then
                WK_err_msg = "赤伝No未入力"
                DG_Err_F = "1" : Exit Sub
            Else
                If LenB(DtView1(k)("赤伝No")) > 13 Then
                    WK_err_msg = "赤伝No 桁数オーバー"
                    DG_Err_F = "1" : Exit Sub
                End If
            End If
        Else
            If DtView1(k)("赤伝No") <> Nothing Then
                WK_err_msg = "赤伝No入力エラー"
                DG_Err_F = "1" : Exit Sub
            End If
        End If

        '顧客番号
        If DtView1(k)("取引種類") = "1" Then
            If DtView1(k)("顧客番号") = "0" Then DtView1(k)("顧客番号") = ""
            If DtView1(k)("顧客番号") = Nothing Then
            Else
                If LenB(DtView1(k)("顧客番号")) > 15 Then
                    WK_err_msg = "顧客番号 桁数オーバー"
                    DG_Err_F = "1" : Exit Sub
                End If
            End If
        End If

        '顧客名
        If DtView1(k)("取引種類") = "1" Then
            If DtView1(k)("顧客名") = Nothing Then
            Else
                If LenB(DtView1(k)("顧客名")) > 120 Then
                    WK_err_msg = "顧客名 桁数オーバー"
                    DG_Err_F = "1" : Exit Sub
                End If
            End If
        End If

        '郵便番号
        If DtView1(k)("取引種類") = "1" Then
            If DtView1(k)("郵便番号") = Nothing Then
            Else
                If LenB(DtView1(k)("郵便番号")) > 7 Then
                    WK_err_msg = "郵便番号 桁数オーバー"
                    DG_Err_F = "1" : Exit Sub
                End If
            End If
        End If

        '住所１
        If DtView1(k)("取引種類") = "1" Then
            If DtView1(k)("住所１") = Nothing Then
            Else
                If LenB(DtView1(k)("住所１")) > 120 Then
                    WK_err_msg = "住所１ 桁数オーバー"
                    DG_Err_F = "1" : Exit Sub
                End If
            End If
        End If

        '住所２
        If DtView1(k)("取引種類") = "1" Then
            If DtView1(k)("住所２") = Nothing Then
            Else
                If LenB(DtView1(k)("住所２")) > 120 Then
                    WK_err_msg = "住所２ 桁数オーバー"
                    DG_Err_F = "1" : Exit Sub
                End If
            End If
        End If

        '電話番号
        If DtView1(k)("取引種類") = "1" Then
            If DtView1(k)("電話番号") = Nothing Then
            Else
                If LenB(DtView1(k)("電話番号")) > 15 Then
                    WK_err_msg = "電話番号 桁数オーバー"
                    DG_Err_F = "1" : Exit Sub
                End If
            End If
        End If

        '大分類NO
        If DtView1(k)("取引種類") = "1" Then
            If DtView1(k)("大分類NO") = Nothing Then
                WK_err_msg = "大分類NO 未入力"
                DG_Err_F = "1" : Exit Sub
            Else
                If LenB(DtView1(k)("大分類NO")) > 4 Then
                    WK_err_msg = "大分類NO 桁数オーバー"
                    DG_Err_F = "1" : Exit Sub
                Else
                    WK_DsList1.Clear()
                    strSQL = "SELECT BY_cls, cd1 FROM Cat_mtr"
                    strSQL += " WHERE (BY_cls = '" & DtView1(k)("システム区分") & "')"
                    strSQL += " AND (cd1 = '" & DtView1(k)("大分類NO") & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN()
                    r = DaList1.Fill(WK_DsList1, "Cat_mtr")
                    DB_CLOSE()
                    If r = 0 Then
                        WK_err_msg = "大分類NO エラー"
                        DG_Err_F = "1" : Exit Sub
                    End If
                End If
            End If
        End If

        '大分類名
        If DtView1(k)("取引種類") = "1" Then
            If DtView1(k)("大分類名") = Nothing Then
            Else
                If LenB(DtView1(k)("大分類名")) > 10 Then
                    WK_err_msg = "大分類名 桁数オーバー"
                    DG_Err_F = "1" : Exit Sub
                End If
            End If
        End If

        '中分類NO
        If DtView1(k)("取引種類") = "1" Then
            If DtView1(k)("中分類NO") = Nothing Then
                WK_err_msg = "中分類NO 未入力"
                DG_Err_F = "1" : Exit Sub
            Else
                If LenB(DtView1(k)("中分類NO")) > 2 Then
                    WK_err_msg = "中分類NO 桁数オーバー"
                    DG_Err_F = "1" : Exit Sub
                Else
                    WK_DsList1.Clear()
                    strSQL = "SELECT BY_cls, cd1, cd2, cd3, avlbty, wrn_prod FROM Cat_mtr"
                    strSQL += " WHERE (BY_cls = '" & DtView1(k)("システム区分") & "')"
                    strSQL += " AND (cd1 = '" & DtView1(k)("大分類NO") & "')"
                    strSQL += " AND (cd2 = '" & DtView1(k)("中分類NO") & "')"
                    strSQL += " AND (cd3 = '00')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN()
                    r = DaList1.Fill(WK_DsList1, "Cat_mtr")
                    DB_CLOSE()
                    If r = 0 Then
                        WK_err_msg = "中分類NO エラー"
                        DG_Err_F = "1" : Exit Sub
                    Else
                        WK_DtView1 = New DataView(WK_DsList1.Tables("Cat_mtr"), "", "", DataViewRowState.CurrentRows)
                        WK_wrn_prod = WK_DtView1(0)("wrn_prod")
                        If IsDBNull(WK_DtView1(0)("avlbty")) Then
                            WK_err_msg = "対象外品種"
                            DG_Err_F = "1" : Exit Sub
                        Else
                            If WK_DtView1(0)("avlbty") <> "対象" Then
                                WK_err_msg = "対象外品種"
                                DG_Err_F = "1" : Exit Sub
                            End If
                        End If
                    End If
                End If
            End If
        End If

        '中分類名
        If DtView1(k)("取引種類") = "1" Then
            If DtView1(k)("中分類名") = Nothing Then
            Else
                If LenB(DtView1(k)("中分類名")) > 10 Then
                    WK_err_msg = "中分類名 桁数オーバー"
                    DG_Err_F = "1" : Exit Sub
                End If
            End If
        End If

        '小分類NO
        If DtView1(k)("取引種類") = "1" Then
            If DtView1(k)("小分類NO") = Nothing Then
                WK_err_msg = "小分類NO 未入力"
                DG_Err_F = "1" : Exit Sub
            Else
                If LenB(DtView1(k)("小分類NO")) > 2 Then
                    WK_err_msg = "小分類NO 桁数オーバー"
                    DG_Err_F = "1" : Exit Sub
                Else
                    '2014/3/25 Yデータ小分類チェック除外対応　
                    If DtView1(k)("システム区分") = "B" Then
                        WK_DsList1.Clear()
                        strSQL = "SELECT BY_cls, cd1 FROM Cat_mtr"
                        strSQL += " WHERE (BY_cls = '" & DtView1(k)("システム区分") & "')"
                        strSQL += " AND (cd1 = '" & DtView1(k)("大分類NO") & "')"
                        strSQL += " AND (cd2 = '" & DtView1(k)("中分類NO") & "')"
                        strSQL += " AND (cd3 = '" & DtView1(k)("小分類NO") & "')"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DaList1.SelectCommand = SqlCmd1
                        DB_OPEN()
                        r = DaList1.Fill(WK_DsList1, "Cat_mtr")
                        DB_CLOSE()
                        If r = 0 Then
                            WK_err_msg = "小分類NO エラー"
                            DG_Err_F = "1" : Exit Sub
                        End If
                    End If
                End If
            End If
        End If

        '小分類名
        If DtView1(k)("取引種類") = "1" Then
            If DtView1(k)("小分類名") = Nothing Then
            Else
                If LenB(DtView1(k)("小分類名")) > 10 Then
                    WK_err_msg = "小分類名 桁数オーバー"
                    DG_Err_F = "1" : Exit Sub
                End If
            End If
        End If

        'メーカーコード
        If DtView1(k)("取引種類") = "1" Then
            If DtView1(k)("メーカーコード") = Nothing Then
                WK_err_msg = "メーカーコード 未入力"
                DG_Err_F = "1" : Exit Sub
            Else
                If LenB(DtView1(k)("メーカーコード")) > 5 Then
                    WK_err_msg = "メーカーコード 桁数オーバー"
                    DG_Err_F = "1" : Exit Sub
                Else
                    WK_DsList1.Clear()
                    strSQL = "SELECT BY_cls, vdr_code FROM vdr_mtr"
                    strSQL += " WHERE (BY_cls = '" & DtView1(k)("システム区分") & "')"
                    strSQL += " AND (vdr_code  = '" & DtView1(k)("メーカーコード") & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN()
                    r = DaList1.Fill(WK_DsList1, "vdr_mtr")
                    DB_CLOSE()
                    If r = 0 Then
                        WK_err_msg = "メーカーコード エラー"
                        DG_Err_F = "1" : Exit Sub
                    End If
                End If
            End If
        End If

        'メーカー名
        If DtView1(k)("取引種類") = "1" Then
            If DtView1(k)("メーカー名") = Nothing Then
            Else
                If LenB(DtView1(k)("メーカー名")) > 10 Then
                    WK_err_msg = "メーカー名 桁数オーバー"
                    DG_Err_F = "1" : Exit Sub
                End If
            End If
        End If

        '商品コード
        If DtView1(k)("取引種類") = "1" Then
            If DtView1(k)("商品コード") = Nothing Then
                WK_err_msg = "商品コード 未入力"
                DG_Err_F = "1" : Exit Sub
            Else
                If LenB(DtView1(k)("商品コード")) > 10 Then
                    WK_err_msg = "商品コード 桁数オーバー"
                    DG_Err_F = "1" : Exit Sub
                End If
            End If
        End If

        '型式
        If DtView1(k)("取引種類") = "1" Then
            If DtView1(k)("型式") = Nothing Then
                WK_err_msg = "型式 未入力"
                DG_Err_F = "1" : Exit Sub
            Else
                If LenB(DtView1(k)("型式")) > 30 Then
                    WK_err_msg = "型式 桁数オーバー"
                    DG_Err_F = "1" : Exit Sub
                End If
            End If
        End If

        '売価
        If DtView1(k)("取引種類") = "1" Then
            If DtView1(k)("売価") = Nothing Then
                WK_err_msg = "売価 未入力"
                DG_Err_F = "1" : Exit Sub
            Else
                If IsNumeric(DtView1(k)("売価")) = False Then
                    WK_err_msg = "売価 数値エラー"
                    DG_Err_F = "1" : Exit Sub
                Else
                    If LenB(DtView1(k)("売価")) > 9 Then
                        WK_err_msg = "売価 桁数オーバー"
                        DG_Err_F = "1" : Exit Sub
                    End If
                End If
            End If
        End If

        '税額
        If DtView1(k)("取引種類") = "1" Then
            If DtView1(k)("税額") = Nothing Then
                WK_err_msg = "税額 未入力"
                DG_Err_F = "1" : Exit Sub
            Else
                If IsNumeric(DtView1(k)("税額")) = False Then
                    WK_err_msg = "税額 数値エラー"
                    DG_Err_F = "1" : Exit Sub
                Else
                    If LenB(DtView1(k)("税額")) > 7 Then
                        WK_err_msg = "税額 桁数オーバー"
                        DG_Err_F = "1" : Exit Sub
                    End If
                End If
            End If
        End If

        '購入数量
        If DtView1(k)("取引種類") <> "4" Then
            If DtView1(k)("購入数量") = Nothing Or DtView1(k)("購入数量") = "0" Then
                If DtView1(k)("取引種類") <> "2" Then
                    WK_err_msg = "購入数量 未入力"
                    DG_Err_F = "1" : Exit Sub
                End If
            Else
                If IsNumeric(DtView1(k)("購入数量")) = False Then
                    WK_err_msg = "購入数量 数値エラー"
                    DG_Err_F = "1" : Exit Sub
                Else
                    If LenB(DtView1(k)("購入数量")) > 4 Then
                        WK_err_msg = "購入数量 桁数オーバー"
                        DG_Err_F = "1" : Exit Sub
                    End If
                End If
            End If
        End If

        '店番
        If DtView1(k)("取引種類") = "1" Or DtView1(k)("取引種類") = "3" Then
            If DtView1(k)("店番") = Nothing Then
                WK_err_msg = "店番 未入力"
                DG_Err_F = "1" : Exit Sub
            Else
                If LenB(DtView1(k)("店番")) > 4 Then
                    WK_err_msg = "店番 桁数オーバー"
                    DG_Err_F = "1" : Exit Sub
                Else
                    WK_DsList1.Clear()
                    strSQL = "SELECT BY_cls, shop_code, close_date FROM Shop_mtr"
                    strSQL += " WHERE (BY_cls = '" & DtView1(k)("システム区分") & "')"
                    strSQL += " AND (shop_code  = N'" & DtView1(k)("店番") & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN()
                    r = DaList1.Fill(WK_DsList1, "Shop_mtr")
                    DB_CLOSE()
                    If r = 0 Then
                        WK_err_msg = "店番 エラー"
                        DG_Err_F = "1" : Exit Sub
                        'Else
                        '    WK_DtView1 = New DataView(WK_DsList1.Tables("Shop_mtr"), "", "", DataViewRowState.CurrentRows)
                        '    If WK_DtView1(0)("close_date") < DtView1(k)("データ処理日") Then
                        '        WK_err_msg = "閉鎖店舗"
                        '        DG_Err_F = "1" : Exit Sub
                        '    End If
                    End If
                End If
            End If
        End If

        '店名
        If DtView1(k)("取引種類") = "1" Then
            If DtView1(k)("店名") = Nothing Then
            Else
                If LenB(DtView1(k)("店名")) > 20 Then
                    WK_err_msg = "店名 桁数オーバー"
                    DG_Err_F = "1" : Exit Sub
                End If
            End If
        End If

        'データ処理日
        If DtView1(k)("取引種類") = "1" Then
            If DtView1(k)("データ処理日") = Nothing Then
                WK_err_msg = "データ処理日 未入力"
                DG_Err_F = "1" : Exit Sub
            Else
                If IsDate(DtView1(k)("データ処理日")) = False Then
                    WK_err_msg = "データ処理日 エラー"
                    DG_Err_F = "1" : Exit Sub
                End If
            End If
        End If

        'データ連番

        '保証商品コード
        If DtView1(k)("取引種類") = "1" Then
            If DtView1(k)("保証商品コード") = Nothing Then
            Else
                If LenB(DtView1(k)("保証商品コード")) > 10 Then
                    WK_err_msg = "保証商品コード 桁数オーバー"
                    DG_Err_F = "1" : Exit Sub
                End If
            End If
        End If

        '保証商品型式
        If DtView1(k)("取引種類") = "1" Then
            If DtView1(k)("保証商品型式") = Nothing Then
            Else
                If LenB(DtView1(k)("保証商品型式")) > 30 Then
                    WK_err_msg = "保証商品型式 桁数オーバー"
                    DG_Err_F = "1" : Exit Sub
                End If
            End If
        End If

        '保証金額
        If DtView1(k)("取引種類") = "1" Then
            If DtView1(k)("保証金額") = Nothing Then
                WK_err_msg = "保証金額 未入力"
                DG_Err_F = "1" : Exit Sub
            Else
                If IsNumeric(DtView1(k)("保証金額")) = False Then
                    WK_err_msg = "保証金額 数値エラー"
                    DG_Err_F = "1" : Exit Sub
                Else
                    If LenB(DtView1(k)("保証金額")) > 9 Then
                        WK_err_msg = "保証金額 桁数オーバー"
                        DG_Err_F = "1" : Exit Sub
                    End If
                End If
            End If
        End If

        '保証期間
        If DtView1(k)("取引種類") = "1" Then
            If DtView1(k)("保証期間") = Nothing Then
                WK_err_msg = "保証期間 未入力"
                DG_Err_F = "1" : Exit Sub
            Else
                If IsNumeric(DtView1(k)("保証期間")) = False Then
                    WK_err_msg = "保証期間 数値エラー"
                    DG_Err_F = "1" : Exit Sub
                Else
                    If LenB(DtView1(k)("保証期間")) > 3 Then
                        WK_err_msg = "保証期間 桁数オーバー"
                        DG_Err_F = "1" : Exit Sub
                    Else
                        If DtView1(k)("保証商品コード") = "085069901" Or DtView1(k)("保証商品コード") = "85069901" Then
                            If 60 <> DtView1(k)("保証期間") Then
                                WK_err_msg = "保証期間 エラー"
                                DG_Err_F = "1" : Exit Sub
                            End If
                            '2015/03/19 家電保３年保証対応 START
                        ElseIf DtView1(k)("保証商品コード") = "085118901" Or DtView1(k)("保証商品コード") = "85118901" Then
                            If 36 <> DtView1(k)("保証期間") Then
                                WK_err_msg = "保証期間 エラー"
                                DG_Err_F = "1" : Exit Sub
                            End If
                            '2015/03/19 家電保３年保証対応 END
                            '2015/08/05 家電保10年保証対応 START
                        ElseIf DtView1(k)("保証商品コード") = "085121401" Or DtView1(k)("保証商品コード") = "85121401" Then
                            If 120 <> DtView1(k)("保証期間") Then
                                WK_err_msg = "保証期間 エラー"
                                DG_Err_F = "1" : Exit Sub
                            End If
                            '2015/03/19 家電保10年保証対応 END
                        Else
                            If WK_wrn_prod <> DtView1(k)("保証期間") Then
                                WK_err_msg = "保証期間 エラー"
                                DG_Err_F = "1" : Exit Sub
                            End If
                        End If
                    End If
                End If
            End If
        End If

    End Sub

    '***************************************************************************
    '** 反映
    '***************************************************************************
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Ans = MessageBox.Show("データを反映します。", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
        If Ans = "1" Then
            Cursor = System.Windows.Forms.Cursors.WaitCursor
            now_date = Now

            'OK分
            DtView1 = New DataView(DsImp.Tables("ok"), "", "データ連番", DataViewRowState.CurrentRows)
            ' 進行状況ダイアログの初期化処理
            waitDlg = New WaitDialog        ' 進行状況ダイアログ
            waitDlg.Owner = Me              ' ダイアログのオーナーを設定する
            waitDlg.MainMsg = Nothing       ' 処理の概要を表示
            waitDlg.ProgressMax = 0         ' 全体の処理件数を設定
            waitDlg.ProgressMin = 0         ' 処理件数の最小値を設定（0件から開始）
            waitDlg.ProgressStep = 1        ' 何件ごとにメータを進めるかを設定
            waitDlg.ProgressValue = 0       ' 最初の件数を設定
            'Me.Enabled = False              ' オーナーのフォームを無効にする
            Button1.Enabled = False
            Button2.Enabled = False
            Button4.Enabled = False
            Button98.Enabled = False
            waitDlg.Show()                  ' 進行状況ダイアログを表示する

            waitDlg.MainMsg = "OK分反映中"  ' 進行状況ダイアログのメーターを設定
            waitDlg.ProgressMsg = ""        ' 進行状況ダイアログのメーターを設定
            waitDlg.ProgressMax = DtView1.Count ' 全体の処理件数を設定
            waitDlg.ProgressValue = 0       ' 最初の件数を設定
            Application.DoEvents()          ' メッセージ処理を促して表示を更新する

            If DtView1.Count <> 0 Then
                For i = 0 To DtView1.Count - 1

                    waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & Format((i + 1), "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
                    waitDlg.Text = "実行中・・・" & Fix((i + 1) * 100 / DtView1.Count) & "%"
                    Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                    waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                    If DtView1(i)("保証種類") = "0100" Or DtView1(i)("保証種類") = "0200" Or DtView1(i)("保証種類") = "0210" Then
                        upd_best_ok()   'ベストOK分更新
                    Else
                        upd_all_ok()    'オール電化OK分更新
                    End If
                Next
            End If

            'NG分
            DtView1 = New DataView(DsImp.Tables("err"), "", "", DataViewRowState.CurrentRows)

            waitDlg.MainMsg = "NG分反映中"  ' 進行状況ダイアログのメーターを設定
            waitDlg.ProgressMsg = ""        ' 進行状況ダイアログのメーターを設定
            waitDlg.ProgressMax = DtView1.Count ' 全体の処理件数を設定
            waitDlg.ProgressValue = 0       ' 最初の件数を設定
            Application.DoEvents()          ' メッセージ処理を促して表示を更新する

            If DtView1.Count <> 0 Then
                For i = 0 To DtView1.Count - 1

                    waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & Format((i + 1), "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
                    waitDlg.Text = "実行中・・・" & Fix((i + 1) * 100 / DtView1.Count) & "%"
                    Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                    waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                    'If DtView1(i)("保証種類") = "0100" Or DtView1(i)("保証種類") = "0200" Then
                    upd_best_err()  'ベストNG分更新
                    'Else
                    '    upd_all_err()   'オール電化NG分更新
                    'End If
                Next
            End If

            MsgBox("反映しました。", MsgBoxStyle.OKOnly, "確認")
            waitDlg.Close()         '進行状況ダイアログを閉じる
            DsImp.Clear()
            Label1.Text = Nothing
            Button2.Enabled = False
            Button1.Enabled = True
            Button4.Enabled = True
            Button98.Enabled = True
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '***************************************************************************
    '** ベストOK分更新
    '***************************************************************************
    Sub upd_best_ok()   'ベストOK分更新
        'Wrn_mtr
        WK_DsList1.Clear()
        strSQL = "SELECT ordr_no FROM Wrn_mtr WHERE (ordr_no = '" & DtView1(i)("伝票番号") & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(WK_DsList1, "Wrn_mtr")
        DB_CLOSE()
        WK_DtView1 = New DataView(WK_DsList1.Tables("Wrn_mtr"), "", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count = 0 Then
            strSQL = "INSERT INTO  Wrn_mtr"
            strSQL += " (ordr_no, cust_no, cust_fname, cust_lname, adrs1, adrs2, city_name, pref_code"
            strSQL += ", zip_code, srch_phn, disp_phn, cid, shop_code, empl_code, org_ordr_no, corp_flg"
            strSQL += ", entry_date, entry_flg, s_flg, old_comp_flg, b_flg, aka_ordr_no, BY_cls)"
            strSQL += " VALUES ('" & DtView1(i)("伝票番号") & "'"
            strSQL += ", '" & DtView1(i)("顧客番号") & "'"
            strSQL += ", ''"
            strSQL += ", '" & DtView1(i)("顧客名") & "'"
            strSQL += ", '" & DtView1(i)("住所１") & "'"
            strSQL += ", '" & DtView1(i)("住所２") & "'"
            strSQL += ", ''"
            strSQL += ", ''"
            strSQL += ", '" & DtView1(i)("郵便番号") & "'"
            strSQL += ", '" & DtView1(i)("電話番号") & "'"
            strSQL += ", '" & DtView1(i)("電話番号") & "'"
            strSQL += ", ''"
            strSQL += ", '" & DtView1(i)("店番") & "'"
            strSQL += ", ''"
            strSQL += ", '" & DtView1(i)("元伝No") & "'"
            strSQL += ", '0'"   '未使用
            strSQL += ", CONVERT(DATETIME, '" & now_date & "', 102)"
            strSQL += ", '0'"
            strSQL += ", 0"
            strSQL += ", 0"
            strSQL += ", 0"     '未使用
            strSQL += ", '" & DtView1(i)("赤伝No") & "'"
            strSQL += ", '" & DtView1(i)("システム区分") & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DB_OPEN()
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()
        Else
            If DtView1(i)("取引種類") = "3" Then    'キャンセル
                strSQL = "UPDATE Wrn_mtr"
                strSQL += " SET aka_ordr_no = '" & DtView1(i)("赤伝No") & "'"
                strSQL += " WHERE (ordr_no = '" & WK_DtView1(0)("ordr_no") & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DB_OPEN()
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()
            End If
        End If

        'Wrn_sub, Wrn_sub_2
        Select Case DtView1(i)("取引種類")

            Case Is = "1"  '受注

                For j = 1 To CInt(DtView1(i)("購入数量"))
                    strSQL = "INSERT INTO Wrn_sub"
                    strSQL += " (ordr_no, line_no, seq, prch_price, prch_tax, prch_date, item_cat_code, cat_name, prvd_cls"
                    strSQL += ", prch_unit, dlvr_cls, f_full, wrn_prod, wrn_part_prod, wrn_comp_prod, prm_comp_prod"
                    strSQL += ", cont_flg, bend_code, brnd_name, model_name, pos_code, ser_no, bend_wrn_prod, wrn_fee"
                    strSQL += ", op_date, total_loss_flg, corp_flg, b_flg, fin_date"
                    strSQL += ", item_cat_code1, item_cat_code1_name, item_cat_code2, item_cat_code2_name, item_cat_code3"
                    strSQL += ", item_cat_code3_name, data_seq, wrn_item_code, wrn_item_name, BY_cls)"
                    strSQL += " VALUES ('" & DtView1(i)("伝票番号") & "'"
                    strSQL += ", '" & DtView1(i)("対象商品行NO") & "'"
                    strSQL += ", " & j
                    strSQL += ", " & CInt(DtView1(i)("売価"))
                    strSQL += ", " & CInt(DtView1(i)("税額"))
                    strSQL += ", CONVERT(DATETIME, '" & DtView1(i)("受注日") & "', 102)"
                    strSQL += ", '" & DtView1(i)("大分類NO") & DtView1(i)("中分類NO") & "'"
                    strSQL += ", '" & DtView1(i)("中分類名") & "'"
                    strSQL += ", ''"
                    strSQL += ", '1'"
                    strSQL += ", ''"
                    strSQL += ", ''"
                    strSQL += ", '0'"
                    strSQL += ", '0'"
                    strSQL += ", '0'"
                    strSQL += ", '0'"
                    strSQL += ", 'A'"
                    strSQL += ", '" & DtView1(i)("メーカーコード") & "'"
                    strSQL += ", '" & DtView1(i)("メーカー名") & "'"
                    strSQL += ", '" & DtView1(i)("型式") & "'"
                    strSQL += ", '" & DtView1(i)("商品コード") & "'"
                    strSQL += ", ''"
                    strSQL += ", '0'"
                    strSQL += ", " & CInt(DtView1(i)("保証金額"))
                    strSQL += ", CONVERT(DATETIME, '" & DtView1(i)("データ処理日") & "', 102)"
                    strSQL += ", '0'"
                    Select Case DtView1(i)("保証種類")
                        Case Is = "0200"
                            strSQL += ", '1'"
                        Case Is = "0210"
                            strSQL += ", '2'"
                        Case Else
                            strSQL += ", '0'"
                    End Select
                    strSQL += ", 0"
                    If DtView1(i)("完了日") <> Nothing Then strSQL += ", CONVERT(DATETIME, '" & DtView1(i)("完了日") & "', 102)" Else strSQL += ", NULL"
                    strSQL += ", '" & DtView1(i)("大分類NO") & "'"
                    strSQL += ", '" & DtView1(i)("大分類名") & "'"
                    strSQL += ", '" & DtView1(i)("中分類NO") & "'"
                    strSQL += ", '" & DtView1(i)("中分類名") & "'"
                    strSQL += ", '" & DtView1(i)("小分類NO") & "'"
                    strSQL += ", '" & DtView1(i)("小分類名") & "'"
                    strSQL += ", " & DtView1(i)("データ連番")
                    strSQL += ", '" & DtView1(i)("保証商品コード") & "'"
                    strSQL += ", '" & DtView1(i)("保証商品型式") & "'"
                    strSQL += ", '" & DtView1(i)("システム区分") & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DB_OPEN()
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()

                    strSQL = "INSERT INTO Wrn_sub_2"
                    strSQL += " (ordr_no, line_no, seq, item_cat_code3, wrn_pos_code, ordr_no2, wrn_prod2)"
                    strSQL += " VALUES ('" & DtView1(i)("伝票番号") & "'"
                    strSQL += ", '" & DtView1(i)("対象商品行NO") & "'"
                    strSQL += ", " & j
                    strSQL += ", '" & DtView1(i)("小分類NO") & "'"
                    strSQL += ", '" & DtView1(i)("保証商品コード") & "'"
                    strSQL += ", '" & DtView1(i)("元伝No") & "'"
                    strSQL += ", '" & DtView1(i)("保証期間") & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DB_OPEN()
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()
                Next

            Case Is = "2"  '完了
                strSQL = "SELECT seq FROM Wrn_sub"
                strSQL += " WHERE (ordr_no = '" & DtView1(i)("伝票番号") & "')"
                strSQL += " AND (line_no = '" & DtView1(i)("対象商品行NO") & "')"
                strSQL += " AND (cont_flg = 'A') AND (fin_date IS NULL)"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN()
                DaList1.Fill(WK_DsList1, "Wrn_sub")
                DB_CLOSE()
                WK_DtView1 = New DataView(WK_DsList1.Tables("Wrn_sub"), "", "", DataViewRowState.CurrentRows)
                For j = 0 To WK_DtView1.Count - 1
                    strSQL = "UPDATE Wrn_sub"
                    strSQL += " SET fin_date = CONVERT(DATETIME, '" & DtView1(i)("完了日") & "', 102)"
                    strSQL += " WHERE (ordr_no = '" & DtView1(i)("伝票番号") & "')"
                    strSQL += " AND (line_no = '" & DtView1(i)("対象商品行NO") & "')"
                    strSQL += " AND (seq = " & WK_DtView1(j)("seq") & ")"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DB_OPEN()
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()
                Next

            Case Is = "3"   'キャンセル
                strSQL = "SELECT seq, close_date FROM Wrn_sub"
                strSQL += " WHERE (ordr_no = '" & DtView1(i)("伝票番号") & "')"
                strSQL += " AND (line_no = '" & DtView1(i)("対象商品行NO") & "')"
                strSQL += " AND (cont_flg = 'A')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN()
                DaList1.Fill(WK_DsList1, "Wrn_sub")
                DB_CLOSE()
                WK_DtView1 = New DataView(WK_DsList1.Tables("Wrn_sub"), "", "", DataViewRowState.CurrentRows)
                If CInt(DtView1(i)("購入数量")) > WK_DtView1.Count Then
                    CNT = WK_DtView1.Count
                Else
                    CNT = CInt(DtView1(i)("購入数量"))
                End If
                For j = 0 To CNT - 1
                    strSQL = "UPDATE Wrn_sub"
                    strSQL += " SET cxl_shop_code = '" & DtView1(i)("店番") & "'"
                    strSQL += ", cxl_date = CONVERT(DATETIME, '" & DtView1(i)("キャンセル日") & "', 102)"
                    strSQL += ", cxl_op_date = CONVERT(DATETIME, '" & DtView1(i)("データ処理日") & "', 102)"
                    strSQL += ", cont_flg = 'C'"
                    strSQL += " WHERE (ordr_no = '" & DtView1(i)("伝票番号") & "')"
                    strSQL += " AND (line_no = '" & DtView1(i)("対象商品行NO") & "')"
                    strSQL += " AND (seq = " & WK_DtView1(j)("seq") & ")"
                    strSQL += " AND (cont_flg = 'A')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DB_OPEN()
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()
                Next

            Case Is = "4"   '完了キャンセル
                strSQL = "SELECT seq FROM Wrn_sub"
                strSQL += " WHERE (ordr_no = '" & DtView1(i)("伝票番号") & "')"
                strSQL += " AND (line_no = '" & DtView1(i)("対象商品行NO") & "')"
                strSQL += " AND (cont_flg = 'A') AND (fin_date IS NOT NULL)"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN()
                DaList1.Fill(WK_DsList1, "Wrn_sub")
                DB_CLOSE()
                WK_DtView1 = New DataView(WK_DsList1.Tables("Wrn_sub"), "", "", DataViewRowState.CurrentRows)
                For j = 0 To WK_DtView1.Count - 1
                    strSQL = "UPDATE Wrn_sub"
                    strSQL += " SET fin_date = NULL"
                    strSQL += ", close_date = NULL, close_cont_flg = NULL"
                    strSQL += " WHERE (ordr_no = '" & DtView1(i)("伝票番号") & "')"
                    strSQL += " AND (line_no = '" & DtView1(i)("対象商品行NO") & "')"
                    strSQL += " AND (seq = " & WK_DtView1(j)("seq") & ")"
                    strSQL += " AND (cont_flg = 'A') AND (fin_date IS NOT NULL)"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DB_OPEN()
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()
                Next
        End Select
    End Sub

    '***************************************************************************
    '** ベストNG分更新
    '***************************************************************************
    Sub upd_best_err()  'ベストNG分更新
        strSQL = "INSERT INTO Error_data_new"
        strSQL += " (Error_seq, Error_msg, BY_cls, ordr_no, prch_date, fin_date, cxl_date, org_ordr_no, aka_ordr_no"
        strSQL += ", cust_no, cust_lname, zip_code, adrs1, adrs2, srch_phn, line_no, item_cat_code1, item_cat_code1_name"
        strSQL += ", item_cat_code2, item_cat_code2_name, item_cat_code3, item_cat_code3_name, bend_code, brnd_name"
        strSQL += ", pos_code, model_name, prch_price, prch_tax, prch_unit, shop_code, shop_name, op_date, data_seq"
        strSQL += ", cont_code, wrn_item_code, wrn_item_name, wrn_fee, wrn_prod, wrn_cls, imp_date)"
        strSQL += " VALUES (" & Count_Get("005", "エラーSEQ(BEST)")
        strSQL += ", '" & DtView1(i)("err_msg") & "'"
        strSQL += ", '" & DtView1(i)("システム区分") & "'"
        strSQL += ", '" & DtView1(i)("伝票番号") & "'"
        strSQL += ", '" & DtView1(i)("受注日") & "'"
        strSQL += ", '" & DtView1(i)("完了日") & "'"
        strSQL += ", '" & DtView1(i)("キャンセル日") & "'"
        strSQL += ", '" & DtView1(i)("元伝No") & "'"
        strSQL += ", '" & DtView1(i)("赤伝No") & "'"
        strSQL += ", '" & DtView1(i)("顧客番号") & "'"
        strSQL += ", '" & DtView1(i)("顧客名") & "'"
        strSQL += ", '" & DtView1(i)("郵便番号") & "'"
        strSQL += ", '" & DtView1(i)("住所１") & "'"
        strSQL += ", '" & DtView1(i)("住所２") & "'"
        strSQL += ", '" & DtView1(i)("電話番号") & "'"
        strSQL += ", '" & DtView1(i)("対象商品行NO") & "'"
        strSQL += ", '" & DtView1(i)("大分類NO") & "'"
        strSQL += ", '" & DtView1(i)("大分類名") & "'"
        strSQL += ", '" & DtView1(i)("中分類NO") & "'"
        strSQL += ", '" & DtView1(i)("中分類名") & "'"
        strSQL += ", '" & DtView1(i)("小分類NO") & "'"
        strSQL += ", '" & DtView1(i)("小分類名") & "'"
        strSQL += ", '" & DtView1(i)("メーカーコード") & "'"
        strSQL += ", '" & DtView1(i)("メーカー名") & "'"
        strSQL += ", '" & DtView1(i)("商品コード") & "'"
        strSQL += ", '" & DtView1(i)("型式") & "'"
        strSQL += ", '" & DtView1(i)("売価") & "'"
        strSQL += ", '" & DtView1(i)("税額") & "'"
        strSQL += ", '" & DtView1(i)("購入数量") & "'"
        strSQL += ", '" & DtView1(i)("店番") & "'"
        strSQL += ", '" & DtView1(i)("店名") & "'"
        strSQL += ", '" & DtView1(i)("データ処理日") & "'"
        strSQL += ", '" & DtView1(i)("データ連番") & "'"
        strSQL += ", '" & DtView1(i)("取引種類") & "'"
        strSQL += ", '" & DtView1(i)("保証商品コード") & "'"
        strSQL += ", '" & DtView1(i)("保証商品型式") & "'"
        strSQL += ", '" & DtView1(i)("保証金額") & "'"
        strSQL += ", '" & DtView1(i)("保証期間") & "'"
        strSQL += ", '" & DtView1(i)("保証種類") & "'"
        strSQL += ", CONVERT(DATETIME, '" & now_date & "', 102))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DB_OPEN()
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
    End Sub

    '***************************************************************************
    '** オール電化OK分更新
    '***************************************************************************
    Sub upd_all_ok()    'オール電化OK分更新
        'All8_Wrn_mtr
        WK_DsList1.Clear()
        strSQL = "SELECT ordr_no FROM All8_Wrn_mtr WHERE (ordr_no = '" & DtView1(i)("伝票番号") & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(WK_DsList1, "All8_Wrn_mtr")
        DB_CLOSE()
        WK_DtView1 = New DataView(WK_DsList1.Tables("All8_Wrn_mtr"), "", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count = 0 Then
            strSQL = "INSERT INTO All8_Wrn_mtr"
            strSQL += " (ordr_no, cust_no, cust_fname, cust_lname, city_name, pref_code, zip_code, srch_phn"
            strSQL += ", disp_phn, shop_code, target_ym, ordr_no_aka, ordr_no_moto, op_date, snd_date, adrs1"
            strSQL += ", adrs2, BY_cls)"
            strSQL += " VALUES ('" & DtView1(i)("伝票番号") & "'"
            strSQL += ", '" & DtView1(i)("顧客番号") & "'"
            strSQL += ", ''"
            strSQL += ", '" & DtView1(i)("顧客名") & "'"
            strSQL += ", ''"
            strSQL += ", ''"
            strSQL += ", '" & DtView1(i)("郵便番号") & "'"
            strSQL += ", '" & DtView1(i)("電話番号") & "'"
            strSQL += ", '" & DtView1(i)("電話番号") & "'"
            strSQL += ", '" & DtView1(i)("店番") & "'"
            strSQL += ", N'" & Format(now_date, "yyyyMM") & "'"
            strSQL += ", '" & DtView1(i)("赤伝No") & "'"
            strSQL += ", '" & DtView1(i)("元伝No") & "'"
            strSQL += ", CONVERT(DATETIME, '" & DtView1(i)("データ処理日") & "', 102)"
            strSQL += ", CONVERT(DATETIME, '" & DtView1(i)("データ処理日") & "', 102)"
            strSQL += ", '" & DtView1(i)("住所１") & "'"
            strSQL += ", '" & DtView1(i)("住所２") & "'"
            strSQL += ", '" & DtView1(i)("システム区分") & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DB_OPEN()
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()
        Else
            If DtView1(i)("取引種類") = "3" Then    'キャンセル
                strSQL = "UPDATE All8_Wrn_mtr"
                strSQL += " SET ordr_no_aka = '" & DtView1(i)("赤伝No") & "'"
                strSQL += " WHERE (ordr_no = '" & WK_DtView1(0)("ordr_no") & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DB_OPEN()
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()
            End If
        End If

        'All8_Wrn_sub
        Select Case DtView1(i)("取引種類")

            Case Is = "1"   '受注

                For j = 1 To CInt(DtView1(i)("購入数量"))
                    strSQL = "INSERT INTO All8_Wrn_sub"
                    strSQL += " (ordr_no, line_no, seq, cont_flg, item_cat_code, bend_code, pos_code, model_name, prch_unit"
                    strSQL += ", prch_price, prch_price_tax, wrn_fee, wrn_fee_tax, wrn_fee_ORG, wrn_fee_tax_ORG, prvd_cls"
                    strSQL += ", prch_date, fin_date, wrn_prod, txt_ID, kbn_cd, rcv_flg"
                    strSQL += ", item_cat_code1, item_cat_code1_name, item_cat_code2, item_cat_code2_name, item_cat_code3"
                    strSQL += ", item_cat_code3_name, data_seq, wrn_item_code, wrn_item_name, BY_cls)"
                    strSQL += " VALUES ('" & DtView1(i)("伝票番号") & "'"
                    strSQL += ", '" & DtView1(i)("対象商品行NO") & "'"
                    strSQL += ", " & j
                    strSQL += ", 'A'"
                    strSQL += ", '" & DtView1(i)("大分類NO") & DtView1(i)("中分類NO") & DtView1(i)("小分類NO") & "'"
                    strSQL += ", '" & DtView1(i)("メーカーコード") & "'"
                    strSQL += ", '" & DtView1(i)("商品コード") & "'"
                    strSQL += ", '" & DtView1(i)("型式") & "'"
                    strSQL += ", 1"
                    strSQL += ", " & CInt(DtView1(i)("売価"))
                    strSQL += ", " & CInt(DtView1(i)("売価")) + CInt(DtView1(i)("税額"))
                    strSQL += ", " & CInt(DtView1(i)("保証金額"))
                    If DtView1(i)("完了日") <> Nothing Then                                     '↓消費税10%対応　2019/10/18
                        WK_date = DtView1(i)("完了日")
                    Else
                        If DtView1(i)("受注日") <> Nothing Then
                            WK_date = DtView1(i)("受注日")
                        End If
                    End If
                    If WK_date >= tax_date Then
                        strSQL += ", " & RoundDOWN(CInt(DtView1(i)("保証金額")) * 1.1, 0)
                        strSQL += ", " & CInt(DtView1(i)("保証金額"))
                        strSQL += ", " & RoundDOWN(CInt(DtView1(i)("保証金額")) * 1.1, 0)
                    Else
                        strSQL += ", " & RoundDOWN(CInt(DtView1(i)("保証金額")) * 1.08, 0)
                        strSQL += ", " & CInt(DtView1(i)("保証金額"))
                        strSQL += ", " & RoundDOWN(CInt(DtView1(i)("保証金額")) * 1.08, 0)
                    End If                                                                      '↑消費税10%対応　2019/10/18
                    strSQL += ", ''"
                    strSQL += ", CONVERT(DATETIME, '" & DtView1(i)("受注日") & "', 102)"
                    If DtView1(i)("完了日") <> Nothing Then strSQL += ", CONVERT(DATETIME, '" & DtView1(i)("完了日") & "', 102)" Else strSQL += ", NULL"
                    strSQL += ", " & DtView1(i)("保証期間")
                    strSQL += ", 0"
                    strSQL += ", N'" & DtView1(i)("保証種類") & "'"
                    strSQL += ", '0'"
                    strSQL += ", '" & DtView1(i)("大分類NO") & "'"
                    strSQL += ", '" & DtView1(i)("大分類名") & "'"
                    strSQL += ", '" & DtView1(i)("中分類NO") & "'"
                    strSQL += ", '" & DtView1(i)("中分類名") & "'"
                    strSQL += ", '" & DtView1(i)("小分類NO") & "'"
                    strSQL += ", '" & DtView1(i)("小分類名") & "'"
                    strSQL += ", " & DtView1(i)("データ連番")
                    strSQL += ", '" & DtView1(i)("保証商品コード") & "'"
                    strSQL += ", '" & DtView1(i)("保証商品型式") & "'"
                    strSQL += ", '" & DtView1(i)("システム区分") & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DB_OPEN()
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()
                Next

            Case Is = "2"   '完了
                strSQL = "SELECT seq FROM All8_Wrn_sub"
                strSQL += " WHERE (ordr_no = '" & DtView1(i)("伝票番号") & "')"
                strSQL += " AND (line_no = '" & DtView1(i)("対象商品行NO") & "')"
                strSQL += " AND (cont_flg = 'A') AND (fin_date IS NULL)"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN()
                DaList1.Fill(WK_DsList1, "All8_Wrn_sub")
                DB_CLOSE()
                WK_DtView1 = New DataView(WK_DsList1.Tables("All8_Wrn_sub"), "", "", DataViewRowState.CurrentRows)
                For j = 0 To WK_DtView1.Count - 1
                    strSQL = "UPDATE All8_Wrn_sub"
                    strSQL += " SET fin_date = CONVERT(DATETIME, '" & DtView1(i)("完了日") & "', 102)"
                    WK_date = DtView1(i)("完了日")                                              '↓消費税10%対応　2019/10/18
                    If WK_date >= tax_date Then
                        strSQL += ", wrn_fee_tax = ROUND(wrn_fee * 1.1, 0, - 1)"
                        strSQL += ", wrn_fee_tax_ORG = ROUND(wrn_fee_ORG * 1.1, 0, - 1)"
                    Else
                        strSQL += ", wrn_fee_tax = ROUND(wrn_fee * 1.08, 0, - 1)"
                        strSQL += ", wrn_fee_tax_ORG = ROUND(wrn_fee_ORG * 1.08, 0, - 1)"
                    End If                                                                      '↑消費税10%対応　2019/10/18
                    strSQL += " WHERE (ordr_no = '" & DtView1(i)("伝票番号") & "')"
                    strSQL += " AND (line_no = '" & DtView1(i)("対象商品行NO") & "')"
                    strSQL += " AND (seq = " & WK_DtView1(j)("seq") & ")"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DB_OPEN()
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()
                Next

            Case Is = "3"   'キャンセル
                strSQL = "SELECT seq, close_date FROM All8_Wrn_sub"
                strSQL += " WHERE (ordr_no = '" & DtView1(i)("伝票番号") & "')"
                strSQL += " AND (line_no = '" & DtView1(i)("対象商品行NO") & "')"
                strSQL += " AND (cont_flg = 'A')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN()
                DaList1.Fill(WK_DsList1, "All8_Wrn_sub")
                DB_CLOSE()
                WK_DtView1 = New DataView(WK_DsList1.Tables("All8_Wrn_sub"), "", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count <> 0 Then
                    If CInt(DtView1(i)("購入数量")) > WK_DtView1.Count Then
                        CNT = WK_DtView1.Count
                    Else
                        CNT = CInt(DtView1(i)("購入数量"))
                    End If
                    For j = 0 To CNT - 1
                        strSQL = "UPDATE All8_Wrn_sub"
                        strSQL += " SET cxl_shop_code = '" & DtView1(i)("店番") & "'"
                        strSQL += ", cxl_date = CONVERT(DATETIME, '" & DtView1(i)("キャンセル日") & "', 102)"
                        strSQL += ", cont_flg = 'C'"
                        'strSQL += ", close_date = NULL, close_cont_flg = NULL"
                        strSQL += " WHERE (ordr_no = '" & DtView1(i)("伝票番号") & "')"
                        strSQL += " AND (line_no = '" & DtView1(i)("対象商品行NO") & "')"
                        strSQL += " AND (seq = " & WK_DtView1(j)("seq") & ")"
                        strSQL += " AND (cont_flg = 'A')"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DB_OPEN()
                        SqlCmd1.ExecuteNonQuery()
                        DB_CLOSE()
                    Next
                End If

            Case Is = "4"   '完了キャンセル
                strSQL = "SELECT seq FROM All8_Wrn_sub"
                strSQL += " WHERE (ordr_no = '" & DtView1(i)("伝票番号") & "')"
                strSQL += " AND (line_no = '" & DtView1(i)("対象商品行NO") & "')"
                strSQL += " AND (cont_flg = 'A') AND (fin_date IS NOT NULL)"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN()
                DaList1.Fill(WK_DsList1, "All8_Wrn_sub")
                DB_CLOSE()
                WK_DtView1 = New DataView(WK_DsList1.Tables("All8_Wrn_sub"), "", "", DataViewRowState.CurrentRows)
                For j = 0 To WK_DtView1.Count - 1
                    strSQL = "UPDATE All8_Wrn_sub"
                    strSQL += " SET fin_date = NULL"
                    strSQL += ", close_date = NULL, close_cont_flg = NULL"
                    strSQL += " WHERE (ordr_no = '" & DtView1(i)("伝票番号") & "')"
                    strSQL += " AND (line_no = '" & DtView1(i)("対象商品行NO") & "')"
                    strSQL += " AND (seq = " & WK_DtView1(j)("seq") & ")"
                    strSQL += " AND (cont_flg = 'A') AND (fin_date IS NOT NULL)"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DB_OPEN()
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()
                Next

        End Select
    End Sub

    '***************************************************************************
    '** クリア
    '***************************************************************************
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        DsImp.Clear()
        Label1.Text = Nothing
        Button2.Enabled = False
    End Sub

    '***************************************************************************
    '** エラー出力
    '***************************************************************************
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim Form2 As New Form2
        Form2.ShowDialog()
    End Sub

    '***************************************************************************
    '** 戻る
    '***************************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        Application.Exit()
    End Sub
End Class
