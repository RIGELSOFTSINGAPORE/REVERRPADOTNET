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
    Dim DsList1, DsList12, DsList13, WK_DsList1, WK_DsList2 As New DataSet

    Dim DsImp As New DataSet
    Dim DtView1, DtView2, DtView3 As DataView
    Dim WK_DtView1, WK_DtView2 As DataView
    Dim dttable0, dttable1, dttable2 As DataTable
    Dim dtRow0, dtRow1, dtRow2 As DataRow

    Dim file_name As String
    Dim strSQL, DG_Err_F, WK_err_msg, WK_err_code, Ans As String
    Dim i, j, k, L, r, CNT, No, ok_cnt, err_cnt As Integer
    Dim now_date As Date

    Dim S_flg, b_flg As String
    Dim WK_kbn_No As String
    Dim WK_entry_date, WK_date21 As Date
    Dim Wk_close_date As Date
    'Dim WK_ordr_no, WK_line_no As String
    Dim WK_Limit_money, WK_nen As Integer

    Dim WK_事故日, WK_修理受付日, WK_修理完了日, WK_データ処理日 As Date
    Dim WK_DD As String

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
    Friend WithEvents DataGrid2 As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTableStyle2 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn40 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn41 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn42 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn43 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn44 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn45 As System.Windows.Forms.DataGridTextBoxColumn
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
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
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
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
    Friend WithEvents DataGridTextBoxColumn37 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn38 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn39 As System.Windows.Forms.DataGridTextBoxColumn
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
    Friend WithEvents DataGridTextBoxColumn75 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DataGridTextBoxColumn36 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Friend WithEvents DataGridTextBoxColumn76 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn77 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn78 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn79 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn80 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn81 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn82 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn83 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn84 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents Date6 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Date1 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DataGridTextBoxColumn85 As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn9 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn10 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn11 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn12 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn13 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn14 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGrid2 = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle2 = New System.Windows.Forms.DataGridTableStyle()
        Me.DataGridTextBoxColumn40 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn41 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn42 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn43 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn44 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn45 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn57 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn58 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn60 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn61 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn59 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn62 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn63 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn64 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn65 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn66 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn67 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn68 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn69 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn70 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn71 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn72 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn73 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn83 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn84 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn74 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.DataGridTextBoxColumn15 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn16 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn17 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn18 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn19 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn20 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn21 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn22 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn23 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn24 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn25 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGrid1 = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.DataGridTextBoxColumn26 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn27 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn28 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn29 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn30 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn31 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn32 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn33 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn34 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn35 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn37 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn38 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn39 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn46 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn47 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn48 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn49 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn50 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn51 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn52 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn53 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn54 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn55 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn56 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn75 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn85 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn36 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn76 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn77 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn78 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn79 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn80 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn81 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn82 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.msg = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Button98 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.Date6 = New GrapeCity.Win.Input.Interop.[Date]()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Date1 = New GrapeCity.Win.Input.Interop.[Date]()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "エラーメッセージ"
        ' Me.DataGridTextBoxColumn1.HeaderText = "Error message"
        Me.DataGridTextBoxColumn1.MappingName = "err_msg"
        Me.DataGridTextBoxColumn1.Width = 120
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "システム区分"
        ' Me.DataGridTextBoxColumn2.HeaderText = "System category"
        Me.DataGridTextBoxColumn2.MappingName = "システム区分"
        Me.DataGridTextBoxColumn2.Width = 75
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "請求番号"
        'Me.DataGridTextBoxColumn3.HeaderText = "Billing number"
        Me.DataGridTextBoxColumn3.MappingName = "請求番号"
        Me.DataGridTextBoxColumn3.Width = 70
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "事故状況フラグ"
        ' Me.DataGridTextBoxColumn4.HeaderText = "Accident status flag"
        Me.DataGridTextBoxColumn4.MappingName = "事故状況フラグ"
        Me.DataGridTextBoxColumn4.Width = 90
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "項目有無フラグ"
        ' Me.DataGridTextBoxColumn5.HeaderText = "Item presence flag"
        Me.DataGridTextBoxColumn5.MappingName = "項目有無フラグ"
        Me.DataGridTextBoxColumn5.Width = 90
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "全損フラグ"
        'Me.DataGridTextBoxColumn6.HeaderText = "Total loss flag"
        Me.DataGridTextBoxColumn6.MappingName = "全損フラグ"
        Me.DataGridTextBoxColumn6.Width = 70
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "修理購入店コード体系"
        ' Me.DataGridTextBoxColumn7.HeaderText = "Repair shop code system"
        Me.DataGridTextBoxColumn7.MappingName = "修理購入店コード体系"
        Me.DataGridTextBoxColumn7.Width = 60
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn8.Format = ""
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "修理品購入店"
        ' Me.DataGridTextBoxColumn8.HeaderText = "Repair shop"
        Me.DataGridTextBoxColumn8.MappingName = "修理品購入店"
        Me.DataGridTextBoxColumn8.Width = 85
        '
        'DataGridTextBoxColumn9
        '
        Me.DataGridTextBoxColumn9.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn9.Format = ""
        Me.DataGridTextBoxColumn9.FormatInfo = Nothing
        Me.DataGridTextBoxColumn9.HeaderText = "修理受付店コード体系"
        'Me.DataGridTextBoxColumn9.HeaderText = "Repair shop code system"
        Me.DataGridTextBoxColumn9.MappingName = "修理受付店コード体系"
        Me.DataGridTextBoxColumn9.Width = 60
        '
        'DataGridTextBoxColumn10
        '
        Me.DataGridTextBoxColumn10.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn10.Format = ""
        Me.DataGridTextBoxColumn10.FormatInfo = Nothing
        Me.DataGridTextBoxColumn10.HeaderText = "修理受付店"
        '  Me.DataGridTextBoxColumn10.HeaderText = "Repair shop"
        Me.DataGridTextBoxColumn10.MappingName = "修理受付店"
        Me.DataGridTextBoxColumn10.Width = 85
        '
        'DataGridTextBoxColumn11
        '
        Me.DataGridTextBoxColumn11.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn11.Format = ""
        Me.DataGridTextBoxColumn11.FormatInfo = Nothing
        'Me.DataGridTextBoxColumn11.HeaderText = "修理完了店コード体系"
        ' Me.DataGridTextBoxColumn11.HeaderText = "Repair completion store code system"
        Me.DataGridTextBoxColumn11.MappingName = "修理完了店コード体系"
        Me.DataGridTextBoxColumn11.Width = 60
        '
        'DataGridTextBoxColumn12
        '
        Me.DataGridTextBoxColumn12.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn12.Format = ""
        Me.DataGridTextBoxColumn12.FormatInfo = Nothing
        Me.DataGridTextBoxColumn12.HeaderText = "修理完了店"
        ' Me.DataGridTextBoxColumn12.HeaderText = "Repair completed shop"
        Me.DataGridTextBoxColumn12.MappingName = "修理完了店"
        Me.DataGridTextBoxColumn12.Width = 85
        '
        'DataGridTextBoxColumn13
        '
        Me.DataGridTextBoxColumn13.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn13.Format = ""
        Me.DataGridTextBoxColumn13.FormatInfo = Nothing
        Me.DataGridTextBoxColumn13.HeaderText = "伝票区分"
        ' Me.DataGridTextBoxColumn13.HeaderText = "voucher class"
        Me.DataGridTextBoxColumn13.MappingName = "伝票区分"
        Me.DataGridTextBoxColumn13.Width = 60
        '
        'DataGridTextBoxColumn14
        '
        Me.DataGridTextBoxColumn14.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn14.Format = ""
        Me.DataGridTextBoxColumn14.FormatInfo = Nothing
        Me.DataGridTextBoxColumn14.HeaderText = "修理伝票番号"
        'Me.DataGridTextBoxColumn14.HeaderText = "Repair slip number"
        Me.DataGridTextBoxColumn14.MappingName = "修理伝票番号"
        Me.DataGridTextBoxColumn14.Width = 90
        '
        'DataGrid2
        '
        Me.DataGrid2.CaptionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DataGrid2.CaptionForeColor = System.Drawing.Color.Red
        Me.DataGrid2.CaptionText = " エラーリスト"
        ' Me.DataGrid2.CaptionText = " Error list"
        Me.DataGrid2.DataMember = ""
        Me.DataGrid2.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid2.Location = New System.Drawing.Point(11, 349)
        Me.DataGrid2.Name = "DataGrid2"
        Me.DataGrid2.ReadOnly = True
        Me.DataGrid2.RowHeaderWidth = 10
        Me.DataGrid2.Size = New System.Drawing.Size(912, 260)
        Me.DataGrid2.TabIndex = 1356
        Me.DataGrid2.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle2})
        '
        'DataGridTableStyle2
        '
        Me.DataGridTableStyle2.DataGrid = Me.DataGrid2
        Me.DataGridTableStyle2.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn40, Me.DataGridTextBoxColumn41, Me.DataGridTextBoxColumn42, Me.DataGridTextBoxColumn43, Me.DataGridTextBoxColumn44, Me.DataGridTextBoxColumn45, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8, Me.DataGridTextBoxColumn9, Me.DataGridTextBoxColumn10, Me.DataGridTextBoxColumn11, Me.DataGridTextBoxColumn12, Me.DataGridTextBoxColumn13, Me.DataGridTextBoxColumn14, Me.DataGridTextBoxColumn57, Me.DataGridTextBoxColumn58, Me.DataGridTextBoxColumn60, Me.DataGridTextBoxColumn61, Me.DataGridTextBoxColumn59, Me.DataGridTextBoxColumn62, Me.DataGridTextBoxColumn63, Me.DataGridTextBoxColumn64, Me.DataGridTextBoxColumn65, Me.DataGridTextBoxColumn66, Me.DataGridTextBoxColumn67, Me.DataGridTextBoxColumn68, Me.DataGridTextBoxColumn69, Me.DataGridTextBoxColumn70, Me.DataGridTextBoxColumn71, Me.DataGridTextBoxColumn72, Me.DataGridTextBoxColumn73, Me.DataGridTextBoxColumn83, Me.DataGridTextBoxColumn84, Me.DataGridTextBoxColumn74})
        Me.DataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle2.MappingName = "err"
        '
        'DataGridTextBoxColumn40
        '
        Me.DataGridTextBoxColumn40.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn40.Format = ""
        Me.DataGridTextBoxColumn40.FormatInfo = Nothing
        Me.DataGridTextBoxColumn40.HeaderText = "処理日"
        ' Me.DataGridTextBoxColumn40.HeaderText = "a disposal day"
        Me.DataGridTextBoxColumn40.MappingName = "処理日"
        Me.DataGridTextBoxColumn40.Width = 80
        '
        'DataGridTextBoxColumn41
        '
        Me.DataGridTextBoxColumn41.Format = ""
        Me.DataGridTextBoxColumn41.FormatInfo = Nothing
        Me.DataGridTextBoxColumn41.HeaderText = "伝票番号"
        'Me.DataGridTextBoxColumn41.HeaderText = "Slip number"
        Me.DataGridTextBoxColumn41.MappingName = "伝票番号"
        Me.DataGridTextBoxColumn41.Width = 95
        '
        'DataGridTextBoxColumn42
        '
        Me.DataGridTextBoxColumn42.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn42.Format = ""
        Me.DataGridTextBoxColumn42.FormatInfo = Nothing
        Me.DataGridTextBoxColumn42.HeaderText = "手書き区分"
        'Me.DataGridTextBoxColumn42.HeaderText = "Handwriting classification"
        Me.DataGridTextBoxColumn42.MappingName = "手書き区分"
        Me.DataGridTextBoxColumn42.Width = 75
        '
        'DataGridTextBoxColumn43
        '
        Me.DataGridTextBoxColumn43.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn43.Format = ""
        Me.DataGridTextBoxColumn43.FormatInfo = Nothing
        Me.DataGridTextBoxColumn43.HeaderText = "承認番号"
        'Me.DataGridTextBoxColumn43.HeaderText = "Approval number"
        Me.DataGridTextBoxColumn43.MappingName = "承認番号"
        Me.DataGridTextBoxColumn43.Width = 60
        '
        'DataGridTextBoxColumn44
        '
        Me.DataGridTextBoxColumn44.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn44.Format = ""
        Me.DataGridTextBoxColumn44.FormatInfo = Nothing
        Me.DataGridTextBoxColumn44.HeaderText = "事故日"
        ' Me.DataGridTextBoxColumn44.HeaderText = "Accident day"
        Me.DataGridTextBoxColumn44.MappingName = "事故日"
        Me.DataGridTextBoxColumn44.Width = 80
        '
        'DataGridTextBoxColumn45
        '
        Me.DataGridTextBoxColumn45.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn45.Format = ""
        Me.DataGridTextBoxColumn45.FormatInfo = Nothing
        Me.DataGridTextBoxColumn45.HeaderText = "事故所"
        ' Me.DataGridTextBoxColumn45.HeaderText = "Accident"
        Me.DataGridTextBoxColumn45.MappingName = "事故所"
        Me.DataGridTextBoxColumn45.Width = 50
        '
        'DataGridTextBoxColumn57
        '
        Me.DataGridTextBoxColumn57.Format = ""
        Me.DataGridTextBoxColumn57.FormatInfo = Nothing
        Me.DataGridTextBoxColumn57.HeaderText = "顧客名"
        ' Me.DataGridTextBoxColumn57.HeaderText = "Customer name"
        Me.DataGridTextBoxColumn57.MappingName = "顧客名"
        Me.DataGridTextBoxColumn57.Width = 120
        '
        'DataGridTextBoxColumn58
        '
        Me.DataGridTextBoxColumn58.Format = ""
        Me.DataGridTextBoxColumn58.FormatInfo = Nothing
        Me.DataGridTextBoxColumn58.HeaderText = "電話番号"
        ' Me.DataGridTextBoxColumn58.HeaderText = "phone number"
        Me.DataGridTextBoxColumn58.MappingName = "電話番号"
        Me.DataGridTextBoxColumn58.Width = 85
        '
        'DataGridTextBoxColumn60
        '
        Me.DataGridTextBoxColumn60.Format = ""
        Me.DataGridTextBoxColumn60.FormatInfo = Nothing
        Me.DataGridTextBoxColumn60.HeaderText = "商品コード"
        'Me.DataGridTextBoxColumn60.HeaderText = "Product code"
        Me.DataGridTextBoxColumn60.MappingName = "商品コード"
        Me.DataGridTextBoxColumn60.Width = 85
        '
        'DataGridTextBoxColumn61
        '
        Me.DataGridTextBoxColumn61.Format = ""
        Me.DataGridTextBoxColumn61.FormatInfo = Nothing
        Me.DataGridTextBoxColumn61.HeaderText = "型式"
        'Me.DataGridTextBoxColumn61.HeaderText = "Model"
        Me.DataGridTextBoxColumn61.MappingName = "型式"
        Me.DataGridTextBoxColumn61.Width = 120
        '
        'DataGridTextBoxColumn59
        '
        Me.DataGridTextBoxColumn59.Format = ""
        Me.DataGridTextBoxColumn59.FormatInfo = Nothing
        Me.DataGridTextBoxColumn59.HeaderText = "修理品製造番号"
        'Me.DataGridTextBoxColumn59.HeaderText = "Repair product serial number"
        Me.DataGridTextBoxColumn59.MappingName = "修理品製造番号"
        Me.DataGridTextBoxColumn59.Width = 90
        '
        'DataGridTextBoxColumn62
        '
        Me.DataGridTextBoxColumn62.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn62.Format = ""
        Me.DataGridTextBoxColumn62.FormatInfo = Nothing
        Me.DataGridTextBoxColumn62.HeaderText = "修理受付日"
        'Me.DataGridTextBoxColumn62.HeaderText = "Repair acceptance date"
        Me.DataGridTextBoxColumn62.MappingName = "修理受付日"
        Me.DataGridTextBoxColumn62.Width = 80
        '
        'DataGridTextBoxColumn63
        '
        Me.DataGridTextBoxColumn63.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn63.Format = ""
        Me.DataGridTextBoxColumn63.FormatInfo = Nothing
        Me.DataGridTextBoxColumn63.HeaderText = "修理完了日"
        'Me.DataGridTextBoxColumn63.HeaderText = "Repair completion date"
        Me.DataGridTextBoxColumn63.MappingName = "修理完了日"
        Me.DataGridTextBoxColumn63.Width = 80
        '
        'DataGridTextBoxColumn64
        '
        Me.DataGridTextBoxColumn64.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn64.Format = "##,##0"
        Me.DataGridTextBoxColumn64.FormatInfo = Nothing
        Me.DataGridTextBoxColumn64.HeaderText = "出張料"
        ' Me.DataGridTextBoxColumn64.HeaderText = "Business trip charges"
        Me.DataGridTextBoxColumn64.MappingName = "出張料"
        Me.DataGridTextBoxColumn64.Width = 50
        '
        'DataGridTextBoxColumn65
        '
        Me.DataGridTextBoxColumn65.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn65.Format = "##,##0"
        Me.DataGridTextBoxColumn65.FormatInfo = Nothing
        Me.DataGridTextBoxColumn65.HeaderText = "作業料"
        '  Me.DataGridTextBoxColumn65.HeaderText = "Work fee"
        Me.DataGridTextBoxColumn65.MappingName = "作業料"
        Me.DataGridTextBoxColumn65.Width = 50
        '
        'DataGridTextBoxColumn66
        '
        Me.DataGridTextBoxColumn66.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn66.Format = "##,##0"
        Me.DataGridTextBoxColumn66.FormatInfo = Nothing
        Me.DataGridTextBoxColumn66.HeaderText = "部品料計"
        '   Me.DataGridTextBoxColumn66.HeaderText = "Parts fee total"
        Me.DataGridTextBoxColumn66.MappingName = "部品料計"
        Me.DataGridTextBoxColumn66.Width = 60
        '
        'DataGridTextBoxColumn67
        '
        Me.DataGridTextBoxColumn67.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn67.Format = "##,##0"
        Me.DataGridTextBoxColumn67.FormatInfo = Nothing
        Me.DataGridTextBoxColumn67.HeaderText = "値引き額"
        'Me.DataGridTextBoxColumn67.HeaderText = "Discount"
        Me.DataGridTextBoxColumn67.MappingName = "値引き額"
        Me.DataGridTextBoxColumn67.Width = 60
        '
        'DataGridTextBoxColumn68
        '
        Me.DataGridTextBoxColumn68.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn68.Format = "##,##0"
        Me.DataGridTextBoxColumn68.FormatInfo = Nothing
        Me.DataGridTextBoxColumn68.HeaderText = "請求除外金額"
        'Me.DataGridTextBoxColumn68.HeaderText = "Exclude billing amount"
        Me.DataGridTextBoxColumn68.MappingName = "請求除外金額"
        Me.DataGridTextBoxColumn68.Width = 80
        '
        'DataGridTextBoxColumn69
        '
        Me.DataGridTextBoxColumn69.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn69.Format = "##,##0"
        Me.DataGridTextBoxColumn69.FormatInfo = Nothing
        Me.DataGridTextBoxColumn69.HeaderText = "請求額"
        'Me.DataGridTextBoxColumn69.HeaderText = "Billing amount"
        Me.DataGridTextBoxColumn69.MappingName = "請求額"
        Me.DataGridTextBoxColumn69.Width = 50
        '
        'DataGridTextBoxColumn70
        '
        Me.DataGridTextBoxColumn70.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn70.Format = "##,##0"
        Me.DataGridTextBoxColumn70.FormatInfo = Nothing
        Me.DataGridTextBoxColumn70.HeaderText = "見積額"
        'Me.DataGridTextBoxColumn70.HeaderText = "Estimated amount"
        Me.DataGridTextBoxColumn70.MappingName = "見積額"
        Me.DataGridTextBoxColumn70.Width = 50
        '
        'DataGridTextBoxColumn71
        '
        Me.DataGridTextBoxColumn71.Format = ""
        Me.DataGridTextBoxColumn71.FormatInfo = Nothing
        Me.DataGridTextBoxColumn71.HeaderText = "修理番号"
        'Me.DataGridTextBoxColumn71.HeaderText = "Repair number"
        Me.DataGridTextBoxColumn71.MappingName = "修理番号"
        Me.DataGridTextBoxColumn71.Width = 90
        '
        'DataGridTextBoxColumn72
        '
        Me.DataGridTextBoxColumn72.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn72.Format = ""
        Me.DataGridTextBoxColumn72.FormatInfo = Nothing
        Me.DataGridTextBoxColumn72.HeaderText = "データ処理日"
        'Me.DataGridTextBoxColumn72.HeaderText = "Data processing date"
        Me.DataGridTextBoxColumn72.MappingName = "データ処理日"
        Me.DataGridTextBoxColumn72.Width = 80
        '
        'DataGridTextBoxColumn73
        '
        Me.DataGridTextBoxColumn73.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn73.Format = ""
        Me.DataGridTextBoxColumn73.FormatInfo = Nothing
        Me.DataGridTextBoxColumn73.HeaderText = "請求区分"
        'Me.DataGridTextBoxColumn73.HeaderText = "Billing category"
        Me.DataGridTextBoxColumn73.MappingName = "請求区分"
        Me.DataGridTextBoxColumn73.Width = 60
        '
        'DataGridTextBoxColumn83
        '
        Me.DataGridTextBoxColumn83.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn83.Format = ""
        Me.DataGridTextBoxColumn83.FormatInfo = Nothing
        Me.DataGridTextBoxColumn83.HeaderText = "err_code"
        Me.DataGridTextBoxColumn83.MappingName = "err_code"
        Me.DataGridTextBoxColumn83.Width = 40
        '
        'DataGridTextBoxColumn84
        '
        Me.DataGridTextBoxColumn84.Format = ""
        Me.DataGridTextBoxColumn84.FormatInfo = Nothing
        Me.DataGridTextBoxColumn84.HeaderText = "line_no"
        Me.DataGridTextBoxColumn84.MappingName = "line_no"
        Me.DataGridTextBoxColumn84.Width = 30
        '
        'DataGridTextBoxColumn74
        '
        Me.DataGridTextBoxColumn74.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn74.Format = ""
        Me.DataGridTextBoxColumn74.FormatInfo = Nothing
        Me.DataGridTextBoxColumn74.HeaderText = "SEQ"
        Me.DataGridTextBoxColumn74.MappingName = "SEQ"
        Me.DataGridTextBoxColumn74.Width = 30
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(823, 353)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 16)
        Me.Label1.TabIndex = 1358
        Me.Label1.Text = "Label1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button4
        '
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Location = New System.Drawing.Point(656, 8)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(124, 40)
        Me.Button4.TabIndex = 4
        Me.Button4.Text = "クリア"
        'Me.Button4.Text = "clear"
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Location = New System.Drawing.Point(516, 8)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(124, 40)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "反映"
        'Me.Button2.Text = "Reflection"
        '
        'DataGridTextBoxColumn15
        '
        Me.DataGridTextBoxColumn15.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn15.Format = ""
        Me.DataGridTextBoxColumn15.FormatInfo = Nothing
        Me.DataGridTextBoxColumn15.HeaderText = "承認番号"
        Me.DataGridTextBoxColumn15.MappingName = "承認番号"
        Me.DataGridTextBoxColumn15.Width = 60
        '
        'DataGridTextBoxColumn16
        '
        Me.DataGridTextBoxColumn16.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn16.Format = ""
        Me.DataGridTextBoxColumn16.FormatInfo = Nothing
        Me.DataGridTextBoxColumn16.HeaderText = "事故日"
        Me.DataGridTextBoxColumn16.MappingName = "事故日"
        Me.DataGridTextBoxColumn16.Width = 80
        '
        'DataGridTextBoxColumn17
        '
        Me.DataGridTextBoxColumn17.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn17.Format = ""
        Me.DataGridTextBoxColumn17.FormatInfo = Nothing
        Me.DataGridTextBoxColumn17.HeaderText = "事故所"
        Me.DataGridTextBoxColumn17.MappingName = "事故所"
        Me.DataGridTextBoxColumn17.Width = 50
        '
        'DataGridTextBoxColumn18
        '
        Me.DataGridTextBoxColumn18.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn18.Format = ""
        Me.DataGridTextBoxColumn18.FormatInfo = Nothing
        Me.DataGridTextBoxColumn18.HeaderText = "事故状況フラグ"
        Me.DataGridTextBoxColumn18.MappingName = "事故状況フラグ"
        Me.DataGridTextBoxColumn18.Width = 90
        '
        'DataGridTextBoxColumn19
        '
        Me.DataGridTextBoxColumn19.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn19.Format = ""
        Me.DataGridTextBoxColumn19.FormatInfo = Nothing
        Me.DataGridTextBoxColumn19.HeaderText = "項目有無フラグ"
        Me.DataGridTextBoxColumn19.MappingName = "項目有無フラグ"
        Me.DataGridTextBoxColumn19.Width = 90
        '
        'DataGridTextBoxColumn20
        '
        Me.DataGridTextBoxColumn20.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn20.Format = ""
        Me.DataGridTextBoxColumn20.FormatInfo = Nothing
        Me.DataGridTextBoxColumn20.HeaderText = "全損フラグ"
        Me.DataGridTextBoxColumn20.MappingName = "全損フラグ"
        Me.DataGridTextBoxColumn20.Width = 70
        '
        'DataGridTextBoxColumn21
        '
        Me.DataGridTextBoxColumn21.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn21.Format = ""
        Me.DataGridTextBoxColumn21.FormatInfo = Nothing
        Me.DataGridTextBoxColumn21.HeaderText = "修理購入店コード体系"
        Me.DataGridTextBoxColumn21.MappingName = "修理購入店コード体系"
        Me.DataGridTextBoxColumn21.Width = 60
        '
        'DataGridTextBoxColumn22
        '
        Me.DataGridTextBoxColumn22.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn22.Format = ""
        Me.DataGridTextBoxColumn22.FormatInfo = Nothing
        Me.DataGridTextBoxColumn22.HeaderText = "修理品購入店"
        Me.DataGridTextBoxColumn22.MappingName = "修理品購入店"
        Me.DataGridTextBoxColumn22.Width = 85
        '
        'DataGridTextBoxColumn23
        '
        Me.DataGridTextBoxColumn23.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn23.Format = ""
        Me.DataGridTextBoxColumn23.FormatInfo = Nothing
        Me.DataGridTextBoxColumn23.HeaderText = "修理受付店コード体系"
        Me.DataGridTextBoxColumn23.MappingName = "修理受付店コード体系"
        Me.DataGridTextBoxColumn23.Width = 60
        '
        'DataGridTextBoxColumn24
        '
        Me.DataGridTextBoxColumn24.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn24.Format = ""
        Me.DataGridTextBoxColumn24.FormatInfo = Nothing
        Me.DataGridTextBoxColumn24.HeaderText = "修理受付店"
        Me.DataGridTextBoxColumn24.MappingName = "修理受付店"
        Me.DataGridTextBoxColumn24.Width = 85
        '
        'DataGridTextBoxColumn25
        '
        Me.DataGridTextBoxColumn25.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn25.Format = ""
        Me.DataGridTextBoxColumn25.FormatInfo = Nothing
        Me.DataGridTextBoxColumn25.HeaderText = "修理完了店コード体系"
        Me.DataGridTextBoxColumn25.MappingName = "修理完了店コード体系"
        Me.DataGridTextBoxColumn25.Width = 60
        '
        'DataGrid1
        '
        Me.DataGrid1.CaptionVisible = False
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(11, 57)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.RowHeaderWidth = 10
        Me.DataGrid1.Size = New System.Drawing.Size(912, 288)
        Me.DataGrid1.TabIndex = 1355
        Me.DataGrid1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGrid1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn26, Me.DataGridTextBoxColumn27, Me.DataGridTextBoxColumn28, Me.DataGridTextBoxColumn29, Me.DataGridTextBoxColumn30, Me.DataGridTextBoxColumn15, Me.DataGridTextBoxColumn16, Me.DataGridTextBoxColumn17, Me.DataGridTextBoxColumn18, Me.DataGridTextBoxColumn19, Me.DataGridTextBoxColumn20, Me.DataGridTextBoxColumn21, Me.DataGridTextBoxColumn22, Me.DataGridTextBoxColumn23, Me.DataGridTextBoxColumn24, Me.DataGridTextBoxColumn25, Me.DataGridTextBoxColumn31, Me.DataGridTextBoxColumn32, Me.DataGridTextBoxColumn33, Me.DataGridTextBoxColumn34, Me.DataGridTextBoxColumn35, Me.DataGridTextBoxColumn37, Me.DataGridTextBoxColumn38, Me.DataGridTextBoxColumn39, Me.DataGridTextBoxColumn46, Me.DataGridTextBoxColumn47, Me.DataGridTextBoxColumn48, Me.DataGridTextBoxColumn49, Me.DataGridTextBoxColumn50, Me.DataGridTextBoxColumn51, Me.DataGridTextBoxColumn52, Me.DataGridTextBoxColumn53, Me.DataGridTextBoxColumn54, Me.DataGridTextBoxColumn55, Me.DataGridTextBoxColumn56, Me.DataGridTextBoxColumn75, Me.DataGridTextBoxColumn85, Me.DataGridTextBoxColumn36, Me.DataGridTextBoxColumn76, Me.DataGridTextBoxColumn77, Me.DataGridTextBoxColumn78, Me.DataGridTextBoxColumn79, Me.DataGridTextBoxColumn80, Me.DataGridTextBoxColumn81, Me.DataGridTextBoxColumn82})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "imp"
        '
        'DataGridTextBoxColumn26
        '
        Me.DataGridTextBoxColumn26.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn26.Format = ""
        Me.DataGridTextBoxColumn26.FormatInfo = Nothing
        Me.DataGridTextBoxColumn26.HeaderText = "システム区分"
        Me.DataGridTextBoxColumn26.MappingName = "システム区分"
        Me.DataGridTextBoxColumn26.Width = 75
        '
        'DataGridTextBoxColumn27
        '
        Me.DataGridTextBoxColumn27.Format = ""
        Me.DataGridTextBoxColumn27.FormatInfo = Nothing
        Me.DataGridTextBoxColumn27.HeaderText = "請求番号"
        Me.DataGridTextBoxColumn27.MappingName = "請求番号"
        Me.DataGridTextBoxColumn27.Width = 70
        '
        'DataGridTextBoxColumn28
        '
        Me.DataGridTextBoxColumn28.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn28.Format = ""
        Me.DataGridTextBoxColumn28.FormatInfo = Nothing
        Me.DataGridTextBoxColumn28.HeaderText = "処理日"
        Me.DataGridTextBoxColumn28.MappingName = "処理日"
        Me.DataGridTextBoxColumn28.Width = 80
        '
        'DataGridTextBoxColumn29
        '
        Me.DataGridTextBoxColumn29.Format = ""
        Me.DataGridTextBoxColumn29.FormatInfo = Nothing
        Me.DataGridTextBoxColumn29.HeaderText = "伝票番号"
        Me.DataGridTextBoxColumn29.MappingName = "伝票番号"
        Me.DataGridTextBoxColumn29.Width = 95
        '
        'DataGridTextBoxColumn30
        '
        Me.DataGridTextBoxColumn30.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn30.Format = ""
        Me.DataGridTextBoxColumn30.FormatInfo = Nothing
        Me.DataGridTextBoxColumn30.HeaderText = "手書き区分"
        Me.DataGridTextBoxColumn30.MappingName = "手書き区分"
        Me.DataGridTextBoxColumn30.Width = 75
        '
        'DataGridTextBoxColumn31
        '
        Me.DataGridTextBoxColumn31.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn31.Format = ""
        Me.DataGridTextBoxColumn31.FormatInfo = Nothing
        Me.DataGridTextBoxColumn31.HeaderText = "修理完了店"
        Me.DataGridTextBoxColumn31.MappingName = "修理完了店"
        Me.DataGridTextBoxColumn31.Width = 85
        '
        'DataGridTextBoxColumn32
        '
        Me.DataGridTextBoxColumn32.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn32.Format = ""
        Me.DataGridTextBoxColumn32.FormatInfo = Nothing
        Me.DataGridTextBoxColumn32.HeaderText = "伝票区分"
        Me.DataGridTextBoxColumn32.MappingName = "伝票区分"
        Me.DataGridTextBoxColumn32.Width = 60
        '
        'DataGridTextBoxColumn33
        '
        Me.DataGridTextBoxColumn33.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn33.Format = ""
        Me.DataGridTextBoxColumn33.FormatInfo = Nothing
        Me.DataGridTextBoxColumn33.HeaderText = "修理伝票番号"
        Me.DataGridTextBoxColumn33.MappingName = "修理伝票番号"
        Me.DataGridTextBoxColumn33.Width = 90
        '
        'DataGridTextBoxColumn34
        '
        Me.DataGridTextBoxColumn34.Format = ""
        Me.DataGridTextBoxColumn34.FormatInfo = Nothing
        Me.DataGridTextBoxColumn34.HeaderText = "顧客名"
        Me.DataGridTextBoxColumn34.MappingName = "顧客名"
        Me.DataGridTextBoxColumn34.Width = 120
        '
        'DataGridTextBoxColumn35
        '
        Me.DataGridTextBoxColumn35.Format = ""
        Me.DataGridTextBoxColumn35.FormatInfo = Nothing
        Me.DataGridTextBoxColumn35.HeaderText = "電話番号"
        Me.DataGridTextBoxColumn35.MappingName = "電話番号"
        Me.DataGridTextBoxColumn35.Width = 85
        '
        'DataGridTextBoxColumn37
        '
        Me.DataGridTextBoxColumn37.Format = ""
        Me.DataGridTextBoxColumn37.FormatInfo = Nothing
        Me.DataGridTextBoxColumn37.HeaderText = "商品コード"
        Me.DataGridTextBoxColumn37.MappingName = "商品コード"
        Me.DataGridTextBoxColumn37.Width = 85
        '
        'DataGridTextBoxColumn38
        '
        Me.DataGridTextBoxColumn38.Format = ""
        Me.DataGridTextBoxColumn38.FormatInfo = Nothing
        Me.DataGridTextBoxColumn38.HeaderText = "型式"
        Me.DataGridTextBoxColumn38.MappingName = "型式"
        Me.DataGridTextBoxColumn38.Width = 120
        '
        'DataGridTextBoxColumn39
        '
        Me.DataGridTextBoxColumn39.Format = ""
        Me.DataGridTextBoxColumn39.FormatInfo = Nothing
        Me.DataGridTextBoxColumn39.HeaderText = "修理品製造番号"
        Me.DataGridTextBoxColumn39.MappingName = "修理品製造番号"
        Me.DataGridTextBoxColumn39.Width = 90
        '
        'DataGridTextBoxColumn46
        '
        Me.DataGridTextBoxColumn46.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn46.Format = ""
        Me.DataGridTextBoxColumn46.FormatInfo = Nothing
        Me.DataGridTextBoxColumn46.HeaderText = "修理受付日"
        Me.DataGridTextBoxColumn46.MappingName = "修理受付日"
        Me.DataGridTextBoxColumn46.Width = 80
        '
        'DataGridTextBoxColumn47
        '
        Me.DataGridTextBoxColumn47.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn47.Format = ""
        Me.DataGridTextBoxColumn47.FormatInfo = Nothing
        Me.DataGridTextBoxColumn47.HeaderText = "修理完了日"
        Me.DataGridTextBoxColumn47.MappingName = "修理完了日"
        Me.DataGridTextBoxColumn47.Width = 80
        '
        'DataGridTextBoxColumn48
        '
        Me.DataGridTextBoxColumn48.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn48.Format = "##,##0"
        Me.DataGridTextBoxColumn48.FormatInfo = Nothing
        Me.DataGridTextBoxColumn48.HeaderText = "出張料"
        Me.DataGridTextBoxColumn48.MappingName = "出張料"
        Me.DataGridTextBoxColumn48.Width = 50
        '
        'DataGridTextBoxColumn49
        '
        Me.DataGridTextBoxColumn49.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn49.Format = "##,##0"
        Me.DataGridTextBoxColumn49.FormatInfo = Nothing
        Me.DataGridTextBoxColumn49.HeaderText = "作業料"
        Me.DataGridTextBoxColumn49.MappingName = "作業料"
        Me.DataGridTextBoxColumn49.Width = 50
        '
        'DataGridTextBoxColumn50
        '
        Me.DataGridTextBoxColumn50.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn50.Format = "##,##0"
        Me.DataGridTextBoxColumn50.FormatInfo = Nothing
        Me.DataGridTextBoxColumn50.HeaderText = "部品料計"
        Me.DataGridTextBoxColumn50.MappingName = "部品料計"
        Me.DataGridTextBoxColumn50.Width = 60
        '
        'DataGridTextBoxColumn51
        '
        Me.DataGridTextBoxColumn51.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn51.Format = "##,##0"
        Me.DataGridTextBoxColumn51.FormatInfo = Nothing
        Me.DataGridTextBoxColumn51.HeaderText = "値引き額"
        Me.DataGridTextBoxColumn51.MappingName = "値引き額"
        Me.DataGridTextBoxColumn51.Width = 60
        '
        'DataGridTextBoxColumn52
        '
        Me.DataGridTextBoxColumn52.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn52.Format = "##,##0"
        Me.DataGridTextBoxColumn52.FormatInfo = Nothing
        Me.DataGridTextBoxColumn52.HeaderText = "請求除外金額"
        Me.DataGridTextBoxColumn52.MappingName = "請求除外金額"
        Me.DataGridTextBoxColumn52.Width = 80
        '
        'DataGridTextBoxColumn53
        '
        Me.DataGridTextBoxColumn53.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn53.Format = "##,##0"
        Me.DataGridTextBoxColumn53.FormatInfo = Nothing
        Me.DataGridTextBoxColumn53.HeaderText = "請求額"
        Me.DataGridTextBoxColumn53.MappingName = "請求額"
        Me.DataGridTextBoxColumn53.Width = 50
        '
        'DataGridTextBoxColumn54
        '
        Me.DataGridTextBoxColumn54.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn54.Format = "##,##0"
        Me.DataGridTextBoxColumn54.FormatInfo = Nothing
        Me.DataGridTextBoxColumn54.HeaderText = "見積額"
        Me.DataGridTextBoxColumn54.MappingName = "見積額"
        Me.DataGridTextBoxColumn54.Width = 50
        '
        'DataGridTextBoxColumn55
        '
        Me.DataGridTextBoxColumn55.Format = ""
        Me.DataGridTextBoxColumn55.FormatInfo = Nothing
        Me.DataGridTextBoxColumn55.HeaderText = "修理番号"
        Me.DataGridTextBoxColumn55.MappingName = "修理番号"
        Me.DataGridTextBoxColumn55.Width = 90
        '
        'DataGridTextBoxColumn56
        '
        Me.DataGridTextBoxColumn56.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn56.Format = ""
        Me.DataGridTextBoxColumn56.FormatInfo = Nothing
        Me.DataGridTextBoxColumn56.HeaderText = "データ処理日"
        Me.DataGridTextBoxColumn56.MappingName = "データ処理日"
        Me.DataGridTextBoxColumn56.Width = 80
        '
        'DataGridTextBoxColumn75
        '
        Me.DataGridTextBoxColumn75.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn75.Format = ""
        Me.DataGridTextBoxColumn75.FormatInfo = Nothing
        Me.DataGridTextBoxColumn75.HeaderText = "請求区分"
        Me.DataGridTextBoxColumn75.MappingName = "請求区分"
        Me.DataGridTextBoxColumn75.Width = 60
        '
        'DataGridTextBoxColumn85
        '
        Me.DataGridTextBoxColumn85.Format = ""
        Me.DataGridTextBoxColumn85.FormatInfo = Nothing
        Me.DataGridTextBoxColumn85.HeaderText = "掛種コード"
        Me.DataGridTextBoxColumn85.MappingName = "掛種コード"
        Me.DataGridTextBoxColumn85.Width = 75
        '
        'DataGridTextBoxColumn36
        '
        Me.DataGridTextBoxColumn36.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn36.Format = ""
        Me.DataGridTextBoxColumn36.FormatInfo = Nothing
        Me.DataGridTextBoxColumn36.HeaderText = "no"
        Me.DataGridTextBoxColumn36.MappingName = "No"
        Me.DataGridTextBoxColumn36.Width = 40
        '
        'DataGridTextBoxColumn76
        '
        Me.DataGridTextBoxColumn76.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn76.Format = ""
        Me.DataGridTextBoxColumn76.FormatInfo = Nothing
        Me.DataGridTextBoxColumn76.HeaderText = "ON_cls"
        Me.DataGridTextBoxColumn76.MappingName = "ON_cls"
        Me.DataGridTextBoxColumn76.Width = 30
        '
        'DataGridTextBoxColumn77
        '
        Me.DataGridTextBoxColumn77.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn77.Format = ""
        Me.DataGridTextBoxColumn77.FormatInfo = Nothing
        Me.DataGridTextBoxColumn77.HeaderText = "line_no"
        Me.DataGridTextBoxColumn77.MappingName = "line_no"
        Me.DataGridTextBoxColumn77.Width = 30
        '
        'DataGridTextBoxColumn78
        '
        Me.DataGridTextBoxColumn78.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn78.Format = ""
        Me.DataGridTextBoxColumn78.FormatInfo = Nothing
        Me.DataGridTextBoxColumn78.HeaderText = "seq"
        Me.DataGridTextBoxColumn78.MappingName = "seq"
        Me.DataGridTextBoxColumn78.Width = 30
        '
        'DataGridTextBoxColumn79
        '
        Me.DataGridTextBoxColumn79.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn79.Format = ""
        Me.DataGridTextBoxColumn79.FormatInfo = Nothing
        Me.DataGridTextBoxColumn79.HeaderText = "kbn_No"
        Me.DataGridTextBoxColumn79.MappingName = "kbn_No"
        Me.DataGridTextBoxColumn79.Width = 30
        '
        'DataGridTextBoxColumn80
        '
        Me.DataGridTextBoxColumn80.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn80.Format = ""
        Me.DataGridTextBoxColumn80.FormatInfo = Nothing
        Me.DataGridTextBoxColumn80.HeaderText = "Limit_money"
        Me.DataGridTextBoxColumn80.MappingName = "Limit_money"
        Me.DataGridTextBoxColumn80.Width = 50
        '
        'DataGridTextBoxColumn81
        '
        Me.DataGridTextBoxColumn81.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn81.Format = ""
        Me.DataGridTextBoxColumn81.FormatInfo = Nothing
        Me.DataGridTextBoxColumn81.HeaderText = "item_cat_code"
        Me.DataGridTextBoxColumn81.MappingName = "item_cat_code"
        Me.DataGridTextBoxColumn81.Width = 30
        '
        'DataGridTextBoxColumn82
        '
        Me.DataGridTextBoxColumn82.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn82.Format = ""
        Me.DataGridTextBoxColumn82.FormatInfo = Nothing
        Me.DataGridTextBoxColumn82.HeaderText = "bend_code"
        Me.DataGridTextBoxColumn82.MappingName = "bend_code"
        Me.DataGridTextBoxColumn82.Width = 40
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(7, 617)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(724, 28)
        Me.msg.TabIndex = 1357
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button98
        '
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(795, 9)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(124, 40)
        Me.Button98.TabIndex = 5
        Me.Button98.Text = "終　了"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(11, 9)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(124, 40)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "取込み"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(776, 608)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(144, 20)
        Me.Label2.TabIndex = 1359
        Me.Label2.Text = "Label2"
        Me.Label2.Visible = False
        '
        'Label72
        '
        Me.Label72.Font = New System.Drawing.Font("MS PGothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label72.Location = New System.Drawing.Point(236, 16)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(56, 24)
        Me.Label72.TabIndex = 1361
        Me.Label72.Text = "月度"
        Me.Label72.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Date6
        '
        Me.Date6.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Date6.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date6.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy.MM", "", "")
        Me.Date6.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date6.DropDownCalendar.Font = New System.Drawing.Font("MS PGothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Date6.DropDownCalendar.Size = New System.Drawing.Size(228, 237)
        Me.Date6.Font = New System.Drawing.Font("MS PGothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Date6.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy.MM", "", "")
        Me.Date6.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date6.Location = New System.Drawing.Point(140, 16)
        Me.Date6.Name = "Date6"
        Me.Date6.ReadOnly = True
        Me.Date6.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date6.Size = New System.Drawing.Size(96, 24)
        Me.Date6.TabIndex = 0
        Me.Date6.TabStop = False
        Me.Date6.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date6.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Date6.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2005, 6, 24, 11, 17, 5, 0))
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(776, 632)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(144, 20)
        Me.Label3.TabIndex = 1362
        Me.Label3.Text = "Label3"
        Me.Label3.Visible = False
        '
        'Date1
        '
        Me.Date1.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Date1.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date1.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyy/M/d ", "", "")
        Me.Date1.DropDownCalendar.Size = New System.Drawing.Size(158, 173)
        Me.Date1.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Date1.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date1.Location = New System.Drawing.Point(308, 16)
        Me.Date1.Name = "Date1"
        Me.Date1.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date1.Size = New System.Drawing.Size(108, 24)
        Me.Date1.TabIndex = 1
        Me.Date1.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date1.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2013, 9, 10, 16, 51, 14, 0))
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(416, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 24)
        Me.Label4.TabIndex = 1363
        Me.Label4.Text = "処理分"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(930, 655)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Date1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label72)
        Me.Controls.Add(Me.Date6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGrid2)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "請求データ取込み Var 2.0"
        CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '***************************************************************************
    '** 起動時
    '***************************************************************************
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        objMutex = New System.Threading.Mutex(False, "best_ivc_import")
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

        DsList1.Clear()
        WK_DsList1.Clear()

        strSQL = "SELECT CLS_CODE_NAME FROM CLS_CODE WHERE (CLS_NO = '999') AND (CLS_CODE = '0')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        DaList1.Fill(WK_DsList1, "close_date")
        DB_CLOSE()
        WK_DtView1 = New DataView(WK_DsList1.Tables("close_date"), "", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then
            Label3.Text = WK_DtView1(0)("CLS_CODE_NAME")
        Else
            Label3.Text = Nothing
        End If
        Label2.Text = Mid(Date6.Text, 1, 4) & "/" & Mid(Date6.Text, 6, 2) & "/20" 'VJ Add 2020/09/27
        WK_DD = Format(Now.Date, "dd")
        Select Case WK_DD
            Case Is <= "05"
              '  Date1.Text = Format(DateAdd(DateInterval.Month, -1, Now.Date), "yyyy/MM") & "/25"
            Case Is <= "15"
                'Date1.Text = Format(Now.Date, "yyyy/MM") & "/05"
            Case Is <= "25"
                'Date1.Text = Format(Now.Date, "yyyy/MM") & "/15"

            Case Else
                'Date1.Text = Format(Now.Date, "yyyy/MM") & "/25"
        End Select

        '保険会社
        strSQL = "SELECT insurance_co_sub.*, insurance_co_mtr.insurance_name"
        strSQL += " FROM insurance_co_sub INNER JOIN"
        strSQL += " insurance_co_mtr ON"
        strSQL += " insurance_co_sub.insurance_code = insurance_co_mtr.insurance_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "insurance_co_sub")

        'エラーメッセージ
        strSQL = "SELECT CLS_CODE, CLS_CODE_NAME FROM CLS_CODE WHERE (CLS_NO = '011')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "cls_011")

        strSQL = "SELECT '' AS 区分, '' AS システム区分, '' AS 請求番号, '' AS 処理日, '' AS データ連番, '' AS 伝票番号, '' AS 手書き区分"
        strSQL += ", '' AS 承認番号, '' AS 事故日, '' AS 事故所, '' AS 事故状況フラグ, '' AS 項目有無フラグ, '' AS 全損フラグ"
        strSQL += ", '' AS 修理購入店コード体系, '' AS 修理品購入店, '' AS 修理受付店コード体系, '' AS 修理受付店, '' AS 修理完了店コード体系"
        strSQL += ", '' AS 修理完了店, '' AS 伝票区分, '' AS 修理伝票番号, '' AS 顧客名, '' AS 電話番号, '' AS 商品コード, '' AS 型式"
        strSQL += ", '' AS 修理品製造番号, '' AS 修理受付日, '' AS 修理完了日, '' AS 出張料, '' AS 作業料, '' AS 部品料計, '' AS 値引き額"
        strSQL += ", '' AS 請求除外金額, '' AS 請求額, '' AS 見積額, '' AS 修理番号, '' AS データ処理日, '' AS 請求区分, '' AS 掛種コード"
        strSQL += ", 0 AS No, '' AS err_code, '' AS err_msg, '' AS ON_cls, '' AS line_no, 0 AS seq, '' AS kbn_No, 0 AS Limit_money"
        strSQL += ", '' AS item_cat_code, '' AS bend_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
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
    End Sub

    Private Sub Date1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date1.TextChanged
        CHK_date1()
    End Sub

    Sub CHK_date1()
        msg.Text = Nothing
        Button1.Enabled = True

        If Date1.Number = 0 Then
            Date1.Focus()
            msg.Text = "取込み処理日を指定してください。"
            Button1.Enabled = False
            Button2.Enabled = False
        Else
            WK_DD = Format(CDate(Date1.Text), "dd")
            Select Case WK_DD
                Case Is = "05", "15"
                    Date6.Text = Format(CDate(Date1.Text), "yyyy.MM")
                Case Is = "25"
                    Date6.Text = Format(DateAdd(DateInterval.Month, 1, CDate(Date1.Text)), "yyyy.MM")
                Case Else
                    Date1.Focus()
                    msg.Text = "取込み処理日は5日、15日、25日、を指定してください。"
                    Button1.Enabled = False
                    Button2.Enabled = False
            End Select
        End If

    End Sub

    Private Sub Date6_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date6.TextChanged
        Label2.Text = Mid(Date6.Text, 1, 4) & "/" & Mid(Date6.Text, 6, 2) & "/20"

        If Label2.Text <= Label3.Text Then
            msg.Text = "締め処理は完了しています。"
            Button1.Enabled = False
            Button2.Enabled = False
        Else
            msg.Text = Nothing
            Button1.Enabled = True
        End If
    End Sub


    '***************************************************************************
    '** 取込み
    '***************************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DsImp.Clear()
        Label1.Text = Nothing
        No = 0

        With OpenFileDialog1
            .CheckFileExists = True     'ファイルが存在するか確認
            .RestoreDirectory = True    'ディレクトリの復元
            .ReadOnlyChecked = True
            .ShowReadOnly = True
            .Filter = "csv ﾌｧｲﾙ(*.csv)|*.csv|すべてのファイル(*.*)|*.*"
            .FilterIndex = 1            'Filterプロパティの2つ目を表示
            'ダイアログボックスを表示し、［開く]をクリックした場合
            If .ShowDialog = DialogResult.OK Then
                Ans = MessageBox.Show("取込み処理を開始します。よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
                If Ans = "7" Then Exit Sub 'いいえ

                Cursor = System.Windows.Forms.Cursors.WaitCursor
                Button1.Enabled = False
                Date1.Enabled = False
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
                            No += 1
                            waitDlg.ProgressMsg = Fix(No * 100 / CNT) & "%　（" & Format(No, "##,##0") & " / " & Format(CNT, "##,##0") & " 件）"
                            waitDlg.Text = "実行中・・・" & Fix(No * 100 / CNT) & "%"
                            Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                            waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                            dttable0 = DsImp.Tables("imp")
                            dtRow0 = dttable0.NewRow
                            dtRow0("区分") = strTemp(0)
                            dtRow0("システム区分") = strTemp(1)
                            dtRow0("請求番号") = strTemp(2)
                            If strTemp(3) = "" Then dtRow0("処理日") = "" Else dtRow0("処理日") = MidB(strTemp(3), 1, 4) & "/" & MidB(strTemp(3), 5, 2) & "/" & MidB(strTemp(3), 7, 2)
                            dtRow0("データ連番") = CInt(strTemp(4))
                            dtRow0("伝票番号") = strTemp(5)
                            dtRow0("手書き区分") = strTemp(6)
                            dtRow0("承認番号") = strTemp(7)
                            If strTemp(8) = "" Then dtRow0("事故日") = "" Else dtRow0("事故日") = MidB(strTemp(8), 1, 4) & "/" & MidB(strTemp(8), 5, 2) & "/" & MidB(strTemp(8), 7, 2)
                            dtRow0("事故所") = strTemp(9)
                            dtRow0("事故状況フラグ") = strTemp(10)
                            dtRow0("項目有無フラグ") = strTemp(11)
                            dtRow0("全損フラグ") = strTemp(12)
                            dtRow0("修理購入店コード体系") = strTemp(13)
                            dtRow0("修理品購入店") = strTemp(14)
                            dtRow0("修理受付店コード体系") = strTemp(15)
                            dtRow0("修理受付店") = strTemp(16)
                            dtRow0("修理完了店コード体系") = strTemp(17)
                            dtRow0("修理完了店") = strTemp(18)
                            dtRow0("伝票区分") = strTemp(19)
                            dtRow0("修理伝票番号") = strTemp(20)
                            dtRow0("顧客名") = strTemp(21)
                            dtRow0("電話番号") = strTemp(22)
                            dtRow0("商品コード") = strTemp(23)
                            dtRow0("型式") = strTemp(24)
                            dtRow0("修理品製造番号") = strTemp(25)
                            If strTemp(26) = "" Then dtRow0("修理受付日") = "" Else dtRow0("修理受付日") = MidB(strTemp(26), 1, 4) & "/" & MidB(strTemp(26), 5, 2) & "/" & MidB(strTemp(26), 7, 2)
                            If strTemp(27) = "" Then dtRow0("修理完了日") = "" Else dtRow0("修理完了日") = MidB(strTemp(27), 1, 4) & "/" & MidB(strTemp(27), 5, 2) & "/" & MidB(strTemp(27), 7, 2)
                            dtRow0("出張料") = CInt(strTemp(28))
                            dtRow0("作業料") = CInt(strTemp(29))
                            dtRow0("部品料計") = CInt(strTemp(30))
                            dtRow0("値引き額") = CInt(strTemp(31))
                            dtRow0("請求除外金額") = CInt(strTemp(32))
                            dtRow0("請求額") = CInt(strTemp(33))
                            dtRow0("見積額") = CInt(strTemp(34))
                            dtRow0("修理番号") = strTemp(35)
                            If strTemp(36) = "" Then dtRow0("データ処理日") = "" Else dtRow0("データ処理日") = MidB(strTemp(36), 1, 4) & "/" & MidB(strTemp(36), 5, 2) & "/" & MidB(strTemp(36), 7, 2)
                            dtRow0("請求区分") = strTemp(37)
                            dtRow0("掛種コード") = ""
                            dtRow0("No") = No
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

        DtView1 = New DataView(DsImp.Tables("imp"), "", "データ連番, No", DataViewRowState.CurrentRows)
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
                    dtRow1("請求番号") = DtView1(k)("請求番号")
                    dtRow1("処理日") = DtView1(k)("処理日")
                    dtRow1("データ連番") = DtView1(k)("データ連番")
                    dtRow1("伝票番号") = DtView1(k)("伝票番号")
                    dtRow1("手書き区分") = DtView1(k)("手書き区分")
                    dtRow1("承認番号") = DtView1(k)("承認番号")
                    dtRow1("事故日") = DtView1(k)("事故日")
                    dtRow1("事故所") = DtView1(k)("事故所")
                    dtRow1("事故状況フラグ") = DtView1(k)("事故状況フラグ")
                    dtRow1("項目有無フラグ") = DtView1(k)("項目有無フラグ")
                    dtRow1("全損フラグ") = DtView1(k)("全損フラグ")
                    dtRow1("修理購入店コード体系") = DtView1(k)("修理購入店コード体系")
                    dtRow1("修理品購入店") = DtView1(k)("修理品購入店")
                    dtRow1("修理受付店コード体系") = DtView1(k)("修理受付店コード体系")
                    dtRow1("修理受付店") = DtView1(k)("修理受付店")
                    dtRow1("修理完了店コード体系") = DtView1(k)("修理完了店コード体系")
                    dtRow1("修理完了店") = DtView1(k)("修理完了店")
                    dtRow1("伝票区分") = DtView1(k)("伝票区分")
                    dtRow1("修理伝票番号") = DtView1(k)("修理伝票番号")
                    dtRow1("顧客名") = DtView1(k)("顧客名")
                    dtRow1("電話番号") = DtView1(k)("電話番号")
                    dtRow1("商品コード") = DtView1(k)("商品コード")
                    dtRow1("型式") = DtView1(k)("型式")
                    dtRow1("修理品製造番号") = DtView1(k)("修理品製造番号")
                    dtRow1("修理受付日") = DtView1(k)("修理受付日")
                    dtRow1("修理完了日") = DtView1(k)("修理完了日")
                    dtRow1("出張料") = DtView1(k)("出張料")
                    dtRow1("作業料") = DtView1(k)("作業料")
                    dtRow1("部品料計") = DtView1(k)("部品料計")
                    dtRow1("値引き額") = DtView1(k)("値引き額")
                    dtRow1("請求除外金額") = DtView1(k)("請求除外金額")
                    dtRow1("請求額") = DtView1(k)("請求額")
                    dtRow1("見積額") = DtView1(k)("見積額")
                    dtRow1("修理番号") = DtView1(k)("修理番号")
                    dtRow1("データ処理日") = DtView1(k)("データ処理日")
                    dtRow1("請求区分") = DtView1(k)("請求区分")
                    dtRow1("掛種コード") = DtView1(k)("掛種コード")
                    dtRow1("No") = DtView1(k)("No")
                    dtRow1("ON_cls") = DtView1(k)("ON_cls")
                    dtRow1("line_no") = DtView1(k)("line_no")
                    dtRow1("seq") = DtView1(k)("seq")
                    dtRow1("kbn_No") = DtView1(k)("kbn_No")
                    dtRow1("Limit_money") = DtView1(k)("Limit_money")
                    dtRow1("item_cat_code") = DtView1(k)("item_cat_code")
                    dtRow1("bend_code") = DtView1(k)("bend_code")
                    dttable1.Rows.Add(dtRow1)
                Else
                    err_cnt = err_cnt + 1
                    dttable2 = DsImp.Tables("err")
                    dtRow2 = dttable2.NewRow
                    dtRow2("err_code") = WK_err_code
                    WK_DtView1 = New DataView(DsList1.Tables("cls_011"), "CLS_CODE = '" & WK_err_code & "'", "", DataViewRowState.CurrentRows)
                    If WK_DtView1.Count <> 0 Then
                        dtRow2("err_msg") = Trim(WK_DtView1(0)("CLS_CODE_NAME"))
                    End If
                    dtRow2("区分") = DtView1(k)("区分")
                    dtRow2("システム区分") = DtView1(k)("システム区分")
                    dtRow2("請求番号") = DtView1(k)("請求番号")
                    dtRow2("処理日") = DtView1(k)("処理日")
                    dtRow2("データ連番") = DtView1(k)("データ連番")
                    dtRow2("伝票番号") = DtView1(k)("伝票番号")
                    dtRow2("手書き区分") = DtView1(k)("手書き区分")
                    dtRow2("承認番号") = DtView1(k)("承認番号")
                    dtRow2("事故日") = DtView1(k)("事故日")
                    dtRow2("事故所") = DtView1(k)("事故所")
                    dtRow2("事故状況フラグ") = DtView1(k)("事故状況フラグ")
                    dtRow2("項目有無フラグ") = DtView1(k)("項目有無フラグ")
                    dtRow2("全損フラグ") = DtView1(k)("全損フラグ")
                    dtRow2("修理購入店コード体系") = DtView1(k)("修理購入店コード体系")
                    dtRow2("修理品購入店") = DtView1(k)("修理品購入店")
                    dtRow2("修理受付店コード体系") = DtView1(k)("修理受付店コード体系")
                    dtRow2("修理受付店") = DtView1(k)("修理受付店")
                    dtRow2("修理完了店コード体系") = DtView1(k)("修理完了店コード体系")
                    dtRow2("修理完了店") = DtView1(k)("修理完了店")
                    dtRow2("伝票区分") = DtView1(k)("伝票区分")
                    dtRow2("修理伝票番号") = DtView1(k)("修理伝票番号")
                    dtRow2("顧客名") = DtView1(k)("顧客名")
                    dtRow2("電話番号") = DtView1(k)("電話番号")
                    dtRow2("商品コード") = DtView1(k)("商品コード")
                    dtRow2("型式") = DtView1(k)("型式")
                    dtRow2("修理品製造番号") = DtView1(k)("修理品製造番号")
                    dtRow2("修理受付日") = DtView1(k)("修理受付日")
                    dtRow2("修理完了日") = DtView1(k)("修理完了日")
                    dtRow2("出張料") = DtView1(k)("出張料")
                    dtRow2("作業料") = DtView1(k)("作業料")
                    dtRow2("部品料計") = DtView1(k)("部品料計")
                    dtRow2("値引き額") = DtView1(k)("値引き額")
                    dtRow2("請求除外金額") = DtView1(k)("請求除外金額")
                    dtRow2("請求額") = DtView1(k)("請求額")
                    dtRow2("見積額") = DtView1(k)("見積額")
                    dtRow2("修理番号") = DtView1(k)("修理番号")
                    dtRow2("データ処理日") = DtView1(k)("データ処理日")
                    dtRow2("請求区分") = DtView1(k)("請求区分")
                    dtRow2("掛種コード") = DtView1(k)("掛種コード")
                    dtRow2("No") = DtView1(k)("No")
                    dtRow2("ON_cls") = DtView1(k)("ON_cls")
                    dtRow2("line_no") = DtView1(k)("line_no")
                    dtRow2("seq") = DtView1(k)("seq")
                    dtRow2("kbn_No") = DtView1(k)("kbn_No")
                    dtRow2("Limit_money") = DtView1(k)("Limit_money")
                    dtRow2("item_cat_code") = DtView1(k)("item_cat_code")
                    dtRow2("bend_code") = DtView1(k)("bend_code")
                    dttable2.Rows.Add(dtRow2)

                    'DtView1(k)("err_code") = WK_err_code

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
        Dim WK_Date, WK_date21, WK_prch_date As Date
        Dim WK_corp_flg As String
        DG_Err_F = "0"

        'システム区分(B:BEST Y:YAMADA)
        Select Case DtView1(k)("システム区分")
            Case Is = Nothing, ""
                WK_err_code = "15" '"システム区分 未入力"
                DG_Err_F = "1" : Exit Sub
            Case Is = "B", "Y"
            Case Else
                WK_err_code = "16" '"システム区分 エラー"
                DG_Err_F = "1" : Exit Sub
        End Select

        '請求番号
        If DtView1(k)("請求番号") = Nothing Then
            WK_err_code = "04" '"請求番号 未入力"  '04
            DG_Err_F = "1" : Exit Sub
        Else
            If LenB(DtView1(k)("請求番号")) > 6 Then
                WK_err_code = "04" '"請求番号 桁数オーバー"
                DG_Err_F = "1" : Exit Sub
            End If
        End If

        '処理日
        If DtView1(k)("処理日") = Nothing Then
            WK_err_code = "73" '"処理日 未入力"
            DG_Err_F = "1" : Exit Sub
        Else
            If IsDate(DtView1(k)("処理日")) = False Then
                WK_err_code = "73" '"処理日 エラー"
                DG_Err_F = "1" : Exit Sub
            End If
        End If

        'データ連番

        '伝票番号
        If DtView1(k)("伝票番号") = Nothing Then
            WK_err_code = "01" '"伝票番号 未入力"  '01
            DG_Err_F = "1" : Exit Sub
        Else
            If LenB(DtView1(k)("伝票番号")) > 13 Then
                WK_err_code = "01" '"伝票番号 桁数オーバー"
                DG_Err_F = "1" : Exit Sub
            Else
                If LenB(DtView1(k)("伝票番号")) = 13 And Mid(DtView1(k)("伝票番号"), 1, 1) = "0" Then
                    DtView1(k)("伝票番号") = Mid(DtView1(k)("伝票番号"), 2, 12)
                    'WK_ordr_no = DtView1(k)("伝票番号")
                End If
            End If
        End If

        '手書き区分
        If DtView1(k)("手書き区分") = Nothing Then
        Else
            If LenB(DtView1(k)("手書き区分")) > 2 Then
                WK_err_code = "17" '"手書き区分 桁数オーバー"
                DG_Err_F = "1" : Exit Sub
            End If
        End If

        '承認番号
        If DtView1(k)("承認番号") = Nothing Then
        Else
            If LenB(DtView1(k)("承認番号")) > 4 Then
                WK_err_code = "37" '"承認番号 桁数オーバー"
                DG_Err_F = "1" : Exit Sub
            End If
        End If

        '事故日
        If DtView1(k)("事故日") = Nothing Then
            WK_err_code = "21" '"事故日 未入力"    '21
            DG_Err_F = "1" : Exit Sub
        Else
            If IsDate(DtView1(k)("事故日")) = False Then
                WK_err_code = "21" '"事故日 エラー"
                DG_Err_F = "1" : Exit Sub
            Else
                WK_事故日 = DtView1(k)("事故日")
                If WK_事故日 > Now.Date Then
                    WK_err_code = "22" '"事故日 エラー(未来日付)"    '22
                    DG_Err_F = "1" : Exit Sub
                End If
            End If
        End If

        '事故所
        If DtView1(k)("事故所") = Nothing Then
            WK_err_code = "38" '"事故所 未入力"
            DG_Err_F = "1" : Exit Sub
        Else
            If DtView1(k)("事故所") <> "1" And DtView1(k)("事故所") <> "2" Then '1:自宅 2:その他
                WK_err_code = "38" '"事故所 エラー"
                DG_Err_F = "1" : Exit Sub
            End If
        End If

        '事故状況フラグ
        If DtView1(k)("事故状況フラグ") = Nothing Then
            WK_err_code = "06" '"事故状況フラグ 未入力"
            DG_Err_F = "1" : Exit Sub
        Else
            WK_DsList1.Clear()
            strSQL = "SELECT CLS_CODE FROM V_cls_002 WHERE (CLS_CODE = '" & DtView1(k)("事故状況フラグ") & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("best_wrn")
            r = DaList1.Fill(WK_DsList1, "V_cls_002")
            DB_CLOSE()
            If r = 0 Then
                WK_err_code = "06" '"事故状況フラグ エラー"    '06
                DG_Err_F = "1" : Exit Sub
            End If
        End If

        '項目有無フラグ
        If DtView1(k)("項目有無フラグ") = Nothing Then
            WK_err_code = "39" '"項目有無フラグ 未入力"
            DG_Err_F = "1" : Exit Sub
        Else
            If DtView1(k)("項目有無フラグ") <> "0" And DtView1(k)("項目有無フラグ") <> "1" Then '0:無し 1:有り(盗難,火災)
                WK_err_code = "39" '"項目有無フラグ エラー"
                DG_Err_F = "1" : Exit Sub
            End If
        End If

        '全損フラグ
        If DtView1(k)("全損フラグ") = Nothing Then
            WK_err_code = "36" '"全損フラグ 未入力"
            DG_Err_F = "1" : Exit Sub
        Else
            If DtView1(k)("全損フラグ") <> "0" And DtView1(k)("全損フラグ") <> "1" Then '0:無し 1:有り(破損)
                WK_err_code = "36" '"全損フラグ エラー"
                DG_Err_F = "1" : Exit Sub
            End If
        End If

        '修理購入店コード体系
        If DtView1(k)("修理購入店コード体系") = Nothing Then
            WK_err_code = "18" '"修理購入店コード体系 未入力"
            DG_Err_F = "1" : Exit Sub
        Else
            If DtView1(k)("修理購入店コード体系") <> "B" And DtView1(k)("修理購入店コード体系") <> "Y" Then
                WK_err_code = "18" '"修理購入店コード体系 エラー"
                DG_Err_F = "1" : Exit Sub
            End If
        End If

        '修理品購入店
        If DtView1(k)("修理品購入店") = Nothing Then
            WK_err_code = "40" '"修理品購入店 未入力"
            DG_Err_F = "1" : Exit Sub
        Else
            WK_DsList1.Clear()
            strSQL = "SELECT BY_cls, shop_code FROM Shop_mtr WHERE (BY_cls = '" & DtView1(k)("修理購入店コード体系") & "') AND (shop_code = N'" & DtView1(k)("修理品購入店") & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("best_wrn")
            r = DaList1.Fill(WK_DsList1, "Shop_mtr")
            DB_CLOSE()
            If r = 0 Then
                '2014/08/08 請求データの修理品購入店該当なし対応 START
                '加入データを元に修理品購入店を取得する
                WK_DsList1.Clear()
                strSQL = "SELECT shop_code FROM Wrn_mtr WHERE Wrn_mtr.ordr_no = '" & Trim(DtView1(k)("伝票番号")) & "'"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN("best_wrn")
                r = DaList1.Fill(WK_DsList1, "Wrn_mtr")
                DB_CLOSE()
                If r = 0 Then
                    WK_err_code = "41" '"修理品購入店 エラー"
                    DG_Err_F = "1" : Exit Sub
                Else
                    WK_DtView1 = New DataView(WK_DsList1.Tables("Wrn_mtr"), "", "", DataViewRowState.CurrentRows)
                    DtView1(k)("修理品購入店") = WK_DtView1(0)("shop_code")
                End If
                '2014/08/08 請求データの修理品購入店該当なし対応 END
            End If
        End If

        '修理受付店コード体系
        If DtView1(k)("修理受付店コード体系") = Nothing Then
            WK_err_code = "19" '"修理受付店コード体系 未入力"
            DG_Err_F = "1" : Exit Sub
        Else
            If DtView1(k)("修理受付店コード体系") <> "B" And DtView1(k)("修理受付店コード体系") <> "Y" Then
                WK_err_code = "19" '"修理受付店コード体系 エラー"
                DG_Err_F = "1" : Exit Sub
            End If
        End If

        '修理受付店
        If DtView1(k)("修理受付店") = Nothing Then
            WK_err_code = "42" '"修理受付店 未入力"
            DG_Err_F = "1" : Exit Sub
        Else
            WK_DsList1.Clear()
            strSQL = "SELECT BY_cls, shop_code FROM Shop_mtr WHERE (BY_cls = '" & DtView1(k)("修理受付店コード体系") & "') AND (shop_code = N'" & DtView1(k)("修理受付店") & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("best_wrn")
            r = DaList1.Fill(WK_DsList1, "Shop_mtr")
            DB_CLOSE()
            If r = 0 Then
                WK_err_code = "43" '"修理受付店 エラー"
                DG_Err_F = "1" : Exit Sub
            End If
        End If

        '修理完了店コード体系
        If DtView1(k)("修理完了店コード体系") = Nothing Then
            WK_err_code = "20" '"修理完了店コード体系 未入力"
            DG_Err_F = "1" : Exit Sub
        Else
            If DtView1(k)("修理完了店コード体系") <> "B" And DtView1(k)("修理完了店コード体系") <> "Y" Then
                WK_err_code = "20" '"修理完了店コード体系 エラー"
                DG_Err_F = "1" : Exit Sub
            End If
        End If

        '修理完了店
        If DtView1(k)("修理完了店") = Nothing Then
            WK_err_code = "44" '"修理完了店 未入力"
            DG_Err_F = "1" : Exit Sub
        Else
            WK_DsList1.Clear()
            strSQL = "SELECT BY_cls, shop_code FROM Shop_mtr WHERE (BY_cls = '" & DtView1(k)("修理完了店コード体系") & "') AND (shop_code = N'" & DtView1(k)("修理完了店") & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("best_wrn")
            r = DaList1.Fill(WK_DsList1, "Shop_mtr")
            DB_CLOSE()
            If r = 0 Then
                WK_err_code = "45" '"修理完了店 エラー"
                DG_Err_F = "1" : Exit Sub
            End If
        End If

        '伝票区分
        If DtView1(k)("伝票区分") = Nothing Then
            WK_err_code = "46" '"伝票区分 未入力"
            DG_Err_F = "1" : Exit Sub
        Else
            If DtView1(k)("伝票区分") <> "F0" And DtView1(k)("伝票区分") <> "F2" Then
                WK_err_code = "46" '"伝票区分 エラー"
                DG_Err_F = "1" : Exit Sub
            End If
        End If

        '修理伝票番号
        If DtView1(k)("修理伝票番号") = Nothing Then
            WK_err_code = "47" '"修理伝票番号 未入力"
            DG_Err_F = "1" : Exit Sub
        Else
            If LenB(DtView1(k)("修理伝票番号")) > 13 Then
                WK_err_code = "47" '"修理伝票番号 桁数オーバー"
                DG_Err_F = "1" : Exit Sub
            End If
        End If

        '顧客名
        If DtView1(k)("顧客名") = Nothing Then
            WK_err_code = "11" '"顧客名 未入力"    '11
            DG_Err_F = "1" : Exit Sub
        Else
            If LenB(DtView1(k)("顧客名")) > 120 Then
                WK_err_code = "11" '"顧客名 桁数オーバー"
                DG_Err_F = "1" : Exit Sub
            End If
        End If

        '電話番号
        If DtView1(k)("電話番号") = Nothing Then
            WK_err_code = "48" '"電話番号 未入力"
            DG_Err_F = "1" : Exit Sub
        Else
            If LenB(DtView1(k)("電話番号")) > 15 Then
                WK_err_code = "48" '"電話番号 桁数オーバー"
                DG_Err_F = "1" : Exit Sub
            End If
        End If

        '商品コード
        If DtView1(k)("商品コード") = Nothing Then
        Else
            If LenB(DtView1(k)("商品コード")) > 10 Then
                WK_err_code = "24" '"商品コード 桁数オーバー"
                DG_Err_F = "1" : Exit Sub
            End If
        End If

        '型式
        If DtView1(k)("型式") = Nothing Then
            WK_err_code = "05" '"型式 未入力"  '05
            DG_Err_F = "1" : Exit Sub
        Else
            If LenB(DtView1(k)("型式")) > 30 Then
                WK_err_code = "05" '"型式 桁数オーバー"
                DG_Err_F = "1" : Exit Sub
            End If
        End If

        '修理品製造番号
        If DtView1(k)("修理品製造番号") = Nothing Then
            WK_err_code = "07" '"修理品製造番号 未入力"    '07
            DG_Err_F = "1" : Exit Sub
        Else
            If LenB(DtView1(k)("修理品製造番号")) > 15 Then
                WK_err_code = "07" '"修理品製造番号 桁数オーバー"
                DG_Err_F = "1" : Exit Sub
            End If
        End If

        '修理受付日
        If DtView1(k)("修理受付日") = Nothing Then
            WK_err_code = "53" '"修理受付日 未入力"
            DG_Err_F = "1" : Exit Sub
        Else
            If IsDate(DtView1(k)("修理受付日")) = False Then
                WK_err_code = "53" '"修理受付日 エラー"
                DG_Err_F = "1" : Exit Sub
            Else
                WK_修理受付日 = DtView1(k)("修理受付日")
                If WK_修理受付日 > Now.Date Then
                    WK_err_code = "54" '"修理受付日 エラー(未来日付)"    '22
                    DG_Err_F = "1" : Exit Sub
                End If
            End If
        End If

        '修理完了日
        If DtView1(k)("修理完了日") = Nothing Then
            WK_err_code = "55" '"修理完了日 未入力"
            DG_Err_F = "1" : Exit Sub
        Else
            If IsDate(DtView1(k)("修理完了日")) = False Then
                WK_err_code = "55" '"修理完了日 エラー"
                DG_Err_F = "1" : Exit Sub
            Else
                WK_修理完了日 = DtView1(k)("修理完了日")
                If WK_修理完了日 > Now.Date Then
                    WK_err_code = "56" '"修理完了日 エラー(未来日付)"    
                    DG_Err_F = "1" : Exit Sub
                End If
            End If
        End If

        '出張料
        If DtView1(k)("出張料") = Nothing Then
            WK_err_code = "61" '"出張料 未入力"
            DG_Err_F = "1" : Exit Sub
        Else
            If IsNumeric(DtView1(k)("出張料")) = False Then
                WK_err_code = "61" '"出張料 数値エラー"
                DG_Err_F = "1" : Exit Sub
            Else
                If LenB(DtView1(k)("出張料")) > 8 Then
                    WK_err_code = "61" '"出張料 桁数オーバー"
                    DG_Err_F = "1" : Exit Sub
                End If
            End If
        End If

        '作業料
        If DtView1(k)("作業料") = Nothing Then
            WK_err_code = "62" '"作業料 未入力"
            DG_Err_F = "1" : Exit Sub
        Else
            If IsNumeric(DtView1(k)("作業料")) = False Then
                WK_err_code = "62" '"作業料 数値エラー"
                DG_Err_F = "1" : Exit Sub
            Else
                If LenB(DtView1(k)("作業料")) > 8 Then
                    WK_err_code = "62" '"作業料 桁数オーバー"
                    DG_Err_F = "1" : Exit Sub
                End If
            End If
        End If

        '部品料計
        If DtView1(k)("部品料計") = Nothing Then
            WK_err_code = "63" '"部品料計 未入力"
            DG_Err_F = "1" : Exit Sub
        Else
            If IsNumeric(DtView1(k)("部品料計")) = False Then
                WK_err_code = "63" '"部品料計 数値エラー"
                DG_Err_F = "1" : Exit Sub
            Else
                If LenB(DtView1(k)("部品料計")) > 8 Then
                    WK_err_code = "63" '"部品料計 桁数オーバー"
                    DG_Err_F = "1" : Exit Sub
                End If
            End If
        End If

        '値引き額
        If DtView1(k)("値引き額") = Nothing Then
            WK_err_code = "64" '"値引き額 未入力"
            DG_Err_F = "1" : Exit Sub
        Else
            If IsNumeric(DtView1(k)("値引き額")) = False Then
                WK_err_code = "64" '"値引き額 数値エラー"
                DG_Err_F = "1" : Exit Sub
            Else
                If LenB(DtView1(k)("値引き額")) > 8 Then
                    WK_err_code = "64" '"値引き額 桁数オーバー"
                    DG_Err_F = "1" : Exit Sub
                End If
            End If
        End If

        '請求除外金額
        If DtView1(k)("請求除外金額") = Nothing Then
            WK_err_code = "65" '"請求除外金額 未入力"
            DG_Err_F = "1" : Exit Sub
        Else
            If IsNumeric(DtView1(k)("請求除外金額")) = False Then
                WK_err_code = "65" '"請求除外金額 数値エラー"
                DG_Err_F = "1" : Exit Sub
            Else
                If LenB(DtView1(k)("請求除外金額")) > 8 Then
                    WK_err_code = "65" '"請求除外金額 桁数オーバー"
                    DG_Err_F = "1" : Exit Sub
                End If
            End If
        End If

        '請求額
        If DtView1(k)("請求額") = Nothing Then
            WK_err_code = "66" '"請求額 未入力"
            DG_Err_F = "1" : Exit Sub
        Else
            If IsNumeric(DtView1(k)("請求額")) = False Then
                WK_err_code = "66" '"請求額 数値エラー"
                DG_Err_F = "1" : Exit Sub
            Else
                If LenB(DtView1(k)("請求額")) > 8 Then
                    WK_err_code = "66" '"請求額 桁数オーバー"
                    DG_Err_F = "1" : Exit Sub
                End If
            End If
        End If

        '見積額
        If DtView1(k)("見積額") = Nothing Then
            WK_err_code = "67" '"見積額 未入力"
            DG_Err_F = "1" : Exit Sub
        Else
            If IsNumeric(DtView1(k)("見積額")) = False Then
                WK_err_code = "67" '"見積額 数値エラー"
                DG_Err_F = "1" : Exit Sub
            Else
                If LenB(DtView1(k)("見積額")) > 8 Then
                    WK_err_code = "67" '"見積額 桁数オーバー"
                    DG_Err_F = "1" : Exit Sub
                End If
            End If
        End If

        '修理番号
        If DtView1(k)("修理番号") = Nothing Then
            WK_err_code = "72" '"修理番号 未入力"
            DG_Err_F = "1" : Exit Sub
        Else
            If IsNumeric(DtView1(k)("修理番号")) = False Then
                WK_err_code = "72" '"修理番号 数値エラー"
                DG_Err_F = "1" : Exit Sub
            Else
                If LenB(DtView1(k)("修理番号")) > 13 Then
                    WK_err_code = "72" '"修理番号 桁数オーバー"
                    DG_Err_F = "1" : Exit Sub
                End If
            End If
        End If

        'データ処理日
        If DtView1(k)("データ処理日") = Nothing Then
            WK_err_code = "73" '"データ処理日 未入力"
            DG_Err_F = "1" : Exit Sub
        Else
            If IsDate(DtView1(k)("データ処理日")) = False Then
                WK_err_code = "73" '"データ処理日 エラー"
                DG_Err_F = "1" : Exit Sub
            Else
                WK_データ処理日 = DtView1(k)("データ処理日")
                If WK_データ処理日 > Now.Date Then
                    WK_err_code = "23" '"データ処理日 エラー(未来日付)"
                    DG_Err_F = "1" : Exit Sub
                End If
            End If
        End If

        '請求区分
        If DtView1(k)("請求区分") = Nothing Then
            WK_err_code = "03" '"請求区分 未入力"
            DG_Err_F = "1" : Exit Sub
        Else
            If DtView1(k)("請求区分") <> "1" And DtView1(k)("請求区分") <> "2" Then '[1]:請求　[2]:請求取消
                WK_err_code = "03" '"請求区分 エラー"  '03
                DG_Err_F = "1" : Exit Sub
            End If
        End If

        '*********************************
        'ここから連携チェック
        '*********************************

        '伝票番号（加入データチェック）
        S_flg = Nothing
        b_flg = Nothing
        WK_DsList1.Clear()
        strSQL = "SELECT * FROM Wrn_mtr WHERE (ordr_no = '" & DtView1(k)("伝票番号") & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        r = DaList1.Fill(WK_DsList1, "Wrn_mtr")
        DB_CLOSE()
        If r = 0 Then   '旧データもチェックする
            strSQL = "SELECT ordr_no FROM wrn_data WHERE (ordr_no = '" & DtView1(k)("伝票番号") & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("best_wrn_data2")
            r = DaList1.Fill(WK_DsList1, "wrn_data")
            DB_CLOSE()
            If r = 0 Then
                WK_err_code = "02" '"該当する受注なし" '02
                DG_Err_F = "1" : Exit Sub
            Else
                DtView1(k)("ON_cls") = "O"
            End If
        Else
            WK_DtView1 = New DataView(WK_DsList1.Tables("Wrn_mtr"), "", "", DataViewRowState.CurrentRows)
            If Not IsDBNull(WK_DtView1(0)("S_flg")) Then
                If WK_DtView1(0)("S_flg") = "1" Then S_flg = "1"
            End If
            If Not IsDBNull(WK_DtView1(0)("b_flg")) Then
                If WK_DtView1(0)("b_flg") = "1" Then b_flg = "1"
            End If
            WK_entry_date = WK_DtView1(0)("entry_date")
            DtView1(k)("ON_cls") = "N"
        End If

        '加入機種チェック
        If DtView1(k)("ON_cls") = "N" Then  '新データ
            DsList12.Clear()
            strSQL = "SELECT Wrn_sub.*, Wrn_sub_2.wrn_prod2"
            strSQL += " FROM Wrn_sub LEFT OUTER JOIN"
            strSQL += " Wrn_sub_2 ON Wrn_sub.seq = Wrn_sub_2.seq AND Wrn_sub.line_no = Wrn_sub_2.line_no AND"
            strSQL += " Wrn_sub.ordr_no = Wrn_sub_2.ordr_no"
            strSQL += " WHERE (Wrn_sub.ordr_no = '" & DtView1(k)("伝票番号") & "')"
            strSQL += " AND (Wrn_sub.model_name = '" & DtView1(k)("型式") & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("best_wrn")
            r = DaList1.Fill(DsList12, "Wrn_sub")
            DB_CLOSE()
            Select Case r
                Case Is = 0
                    WK_err_code = "10" '"型式 該当なし"    '10
                    DG_Err_F = "1" : Exit Sub
                Case Is = 1
                    DtView2 = New DataView(DsList12.Tables("Wrn_sub"), "", "", DataViewRowState.CurrentRows)
                    If DtView2(0)("cont_flg") = "C" Then
                        WK_err_code = "30" '"契約状況=C"    '30
                        DG_Err_F = "1" : Exit Sub
                    End If
                    DtView1(k)("line_no") = DtView2(0)("line_no")
                    DtView1(k)("seq") = DtView2(0)("seq")

                    If Not IsDBNull(DtView2(0)("b_flg")) Then
                        If DtView2(0)("b_flg") = "1" Then
                            '修理受付日
                            If DtView2(0)("corp_flg") = "0" Then
                                WK_date21 = DtView1(k)("修理受付日")
                                If DateAdd(DateInterval.Year, 3, DtView2(0)("prch_date")) <= WK_date21 Then
                                    b_flg = "1"
                                End If
                            End If
                        End If
                    End If
                    WK_corp_flg = DtView2(0)("corp_flg")
                    If Not IsDBNull(DtView2(0)("prch_date")) Then WK_prch_date = DtView2(0)("prch_date") Else WK_prch_date = Nothing
                    If Not IsDBNull(DtView2(0)("wrn_prod2")) Then
                        WK_nen = Round(CInt(DtView2(0)("wrn_prod2")) / 12, 0)
                    Else
                        WK_nen = Round(CInt(DtView2(0)("wrn_prod")) / 12, 0)
                    End If
                    DtView1(k)("item_cat_code") = DtView2(0)("item_cat_code")
                    DtView1(k)("bend_code") = DtView2(0)("bend_code")
                Case Else
                    DtView2 = New DataView(DsList12.Tables("Wrn_sub"), "cont_flg = 'A'", "", DataViewRowState.CurrentRows)
                    Select Case DtView2.Count
                        Case Is = 0
                            WK_err_code = "30" '"契約状況=C"    '30
                            DG_Err_F = "1" : Exit Sub
                        Case Is = 1
                            DtView1(k)("line_no") = DtView2(0)("line_no")
                            DtView1(k)("seq") = DtView2(0)("seq")

                            If Not IsDBNull(DtView2(0)("b_flg")) Then
                                If DtView2(0)("b_flg") = "1" Then
                                    '修理受付日
                                    If DtView2(0)("corp_flg") = "0" Then
                                        WK_date21 = DtView1(k)("修理受付日")
                                        If DateAdd(DateInterval.Year, 3, DtView2(0)("prch_date")) <= WK_date21 Then
                                            b_flg = "1"
                                        End If
                                    End If
                                End If
                            End If
                            WK_corp_flg = DtView2(0)("corp_flg")
                            If Not IsDBNull(DtView2(0)("prch_date")) Then WK_prch_date = DtView2(0)("prch_date") Else WK_prch_date = Nothing
                            If Not IsDBNull(DtView2(0)("wrn_prod2")) Then
                                WK_nen = Round(CInt(DtView2(0)("wrn_prod2")) / 12, 0)
                            Else
                                WK_nen = Round(CInt(DtView2(0)("wrn_prod")) / 12, 0)
                            End If
                            DtView1(k)("item_cat_code") = DtView2(0)("item_cat_code")
                            DtView1(k)("bend_code") = DtView2(0)("bend_code")
                        Case Else
                            For L = 0 To DtView2.Count - 1
                                DsList13.Clear()
                                strSQL = "SELECT ordr_no, line_no, seq, close_date, seq_sub, FLD020"
                                strSQL += " FROM Wrn_ivc"
                                strSQL += " WHERE (ordr_no = '" & DtView2(L)("ordr_no") & "')"
                                strSQL += " AND (line_no = '" & DtView2(L)("line_no") & "')"
                                strSQL += " AND (seq = " & DtView2(L)("seq") & ")"
                                strSQL += " AND (FLD020 = '" & Trim(DtView1(k)("修理品製造番号")) & "')"
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                DaList1.SelectCommand = SqlCmd1
                                DB_OPEN("best_wrn")
                                r = DaList1.Fill(DsList13, "Wrn_ivc")
                                DB_CLOSE()
                                If r <> 0 Then
                                    DtView3 = New DataView(DsList13.Tables("Wrn_ivc"), "", "", DataViewRowState.CurrentRows)
                                    DtView1(k)("line_no") = DtView3(0)("line_no")
                                    DtView1(k)("seq") = DtView3(0)("seq")

                                    If Not IsDBNull(DtView2(L)("b_flg")) Then
                                        If DtView2(L)("b_flg") = "1" Then
                                            '修理受付日
                                            If DtView2(L)("corp_flg") = "0" Then
                                                WK_date21 = DtView1(k)("修理受付日")
                                                If DateAdd(DateInterval.Year, 3, DtView2(L)("prch_date")) <= WK_date21 Then
                                                    b_flg = "1"
                                                End If
                                            End If
                                        End If
                                    End If
                                    WK_corp_flg = DtView2(L)("corp_flg")
                                    If Not IsDBNull(DtView2(L)("prch_date")) Then WK_prch_date = DtView2(L)("prch_date") Else WK_prch_date = Nothing
                                    If Not IsDBNull(DtView2(L)("wrn_prod2")) Then
                                        WK_nen = Round(CInt(DtView2(L)("wrn_prod2")) / 12, 0)
                                    Else
                                        WK_nen = Round(CInt(DtView2(L)("wrn_prod")) / 12, 0)
                                    End If
                                    DtView1(k)("item_cat_code") = DtView2(L)("item_cat_code")
                                    DtView1(k)("bend_code") = DtView2(L)("bend_code")

                                    GoTo skp01
                                End If
                            Next
                            For L = 0 To DtView2.Count - 1
                                DsList13.Clear()
                                strSQL = "SELECT ordr_no, line_no, seq, close_date, seq_sub, FLD020"
                                strSQL += " FROM Wrn_ivc"
                                strSQL += " WHERE (ordr_no = '" & DtView2(L)("ordr_no") & "')"
                                strSQL += " AND (line_no = '" & DtView2(L)("line_no") & "')"
                                strSQL += " AND (seq = " & DtView2(L)("seq") & ")"
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                DaList1.SelectCommand = SqlCmd1
                                DB_OPEN("best_wrn")
                                r = DaList1.Fill(DsList13, "Wrn_ivc")
                                DB_CLOSE()
                                If r = 0 Then
                                    DtView1(k)("line_no") = DtView2(L)("line_no")
                                    DtView1(k)("seq") = DtView2(L)("seq")

                                    If Not IsDBNull(DtView2(L)("b_flg")) Then
                                        If DtView2(L)("b_flg") = "1" Then
                                            '修理受付日
                                            If DtView2(L)("corp_flg") = "0" Then
                                                WK_date21 = DtView1(k)("修理受付日")
                                                If DateAdd(DateInterval.Year, 3, DtView2(L)("prch_date")) <= WK_date21 Then
                                                    b_flg = "1"
                                                End If
                                            End If
                                        End If
                                    End If
                                    WK_corp_flg = DtView2(L)("corp_flg")
                                    If Not IsDBNull(DtView2(L)("prch_date")) Then WK_prch_date = DtView2(L)("prch_date") Else WK_prch_date = Nothing
                                    If Not IsDBNull(DtView2(L)("wrn_prod2")) Then
                                        WK_nen = Round(CInt(DtView2(L)("wrn_prod2")) / 12, 0)
                                    Else
                                        WK_nen = Round(CInt(DtView2(L)("wrn_prod")) / 12, 0)
                                    End If
                                    DtView1(k)("item_cat_code") = DtView2(L)("item_cat_code")
                                    DtView1(k)("bend_code") = DtView2(L)("bend_code")

                                    GoTo skp01

                                End If
                            Next
skp01:
                    End Select
            End Select

        Else                                '旧データ
            strSQL = "SELECT * FROM wrn_data, 0 AS prch_tax"
            strSQL += " WHERE (ordr_no = '" & DtView1(k)("伝票番号") & "')"
            strSQL += " AND (model_name = '" & DtView1(k)("型式") & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("best_wrn_data2")
            r = DaList1.Fill(DsList12, "wrn_data")
            DB_CLOSE()
            If r = 0 Then
                WK_err_code = "10" '"型式 該当なし"    '10
                DG_Err_F = "1" : Exit Sub
            Else
                DtView2 = New DataView(DsList12.Tables("wrn_data"), "", "", DataViewRowState.CurrentRows)
                If DtView2(0)("cont_flg") = "C" Then
                    WK_err_code = "30" '"契約状況=C"    '30
                    DG_Err_F = "1" : Exit Sub
                End If
                DtView1(k)("line_no") = DtView2(0)("line_no")
                DtView1(k)("seq") = 0

                WK_corp_flg = "0"
                If Not IsDBNull(DtView2(0)("prch_date")) Then WK_prch_date = DtView2(0)("prch_date") Else WK_prch_date = Nothing
                DtView1(k)("item_cat_code") = DtView2(0)("item_cat_code")
                DtView1(k)("bend_code") = DtView2(0)("vend_code")
                WK_nen = 5
            End If
        End If

        '購入日チェック（加入データ）
        If WK_prch_date = Nothing Then
            WK_err_code = "25" '"加入データの購入日なし"
            DG_Err_F = "1" : Exit Sub
        End If

        '全損チェック
        If Not IsDBNull(DtView2(0)("total_loss_flg")) Then
            If DtView2(0)("total_loss_flg") = "1" Then
                WK_err_code = "31" '"全損のため契約満了"
                DG_Err_F = "1" : Exit Sub
            End If
        End If

        '保障期間チェック
        If DateAdd(DateInterval.Year, WK_nen, WK_prch_date) <= WK_事故日 Then
            Select Case WK_nen
                Case Is = 3
                    WK_err_code = "78" 'WK_nen & "年間の保証期限切れ"
                Case Is = 5
                    WK_err_code = "32" 'WK_nen & "年間の保証期限切れ"
                Case Is = 10
                    WK_err_code = "79" 'WK_nen & "年間の保証期限切れ"
            End Select
            DG_Err_F = "1" : Exit Sub
        End If

        '事故状況と経過年数チェック
        Select Case DtView1(k)("事故状況フラグ")
            Case Is = "0"   '故障
                If DateAdd(DateInterval.Year, 1, WK_prch_date) > WK_事故日 Then
                    WK_err_code = "33" '"故障は2年目から対象"
                    DG_Err_F = "1" : Exit Sub
                End If
            Case Is = "4"   '破損
                If DateAdd(DateInterval.Year, 1, WK_prch_date) <= WK_事故日 Then
                    WK_err_code = "34" '"破損は1年目のみ対象"
                    DG_Err_F = "1" : Exit Sub
                End If
        End Select

        '日付相関チェック
        If WK_事故日 > DtView1(k)("修理受付日") Then
            WK_err_code = "57" '"事故日＞修理受付日エラー"
            DG_Err_F = "1" : Exit Sub
        End If
        If WK_事故日 < DtView2(0)("prch_date") Then
            WK_err_code = "58" '"事故日が購入日前エラー"
            DG_Err_F = "1" : Exit Sub
        End If
        If WK_事故日 > DtView1(k)("修理完了日") Then
            WK_err_code = "59" '"事故日＞修理完了日エラー"
            DG_Err_F = "1" : Exit Sub
        End If
        If DtView1(k)("修理受付日") > DtView1(k)("修理完了日") Then
            WK_err_code = "60" '"修理受付日＞修理完了日エラー"
            DG_Err_F = "1" : Exit Sub
        End If
        If Not IsDBNull(DtView2(0)("cxl_date")) Then
            If WK_事故日 > DtView2(0)("cxl_date") Then
                WK_err_code = "75" '"キャンセル日以降の事故日エラー"
                DG_Err_F = "1" : Exit Sub
            End If
        End If

        '保証番号重複チェック
        WK_DsList1.Clear()
        strSQL = "SELECT Wrn_ivc.*"
        strSQL += " FROM Wrn_ivc"
        strSQL += " WHERE (ordr_no = '" & DtView1(k)("伝票番号") & "')"
        strSQL += " AND (FLD019 = '" & DtView1(k)("型式") & "')"
        strSQL += " AND (FLD020 = '" & DtView1(k)("修理品製造番号") & "')"
        strSQL += " AND (close_date = CONVERT(DATETIME, '" & Label2.Text & "', 102))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        r = DaList1.Fill(WK_DsList1, "Wrn_ivc")
        DB_CLOSE()
        If DtView1(k)("請求区分") = "1" Then  '請求

            If DtView1(k)("伝票番号") = "078551140051" Then
                Dim a1 As String
                a1 = DtView1(k)("伝票番号")
            End If

            If r <> 0 Then
                WK_err_code = "08" '"同一締め内に保証番号重複エラー"   '08
                DG_Err_F = "1" : Exit Sub
            Else    '取込みデータもチェック
                WK_DtView1 = New DataView(DsImp.Tables("imp"), "伝票番号 = '" & DtView1(k)("伝票番号") & "' AND 請求区分 = '1' AND No < " & DtView1(k)("No") & " AND err_msg IS NULL", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count <> 0 Then
                    WK_err_code = "08" '"同一締め内に保証番号重複エラー"   '08
                    DG_Err_F = "1" : Exit Sub
                End If
            End If
        Else                        '取消
            If r = 0 Then
                WK_err_code = "09" '"同一締め内に取り消す保証番号なし" '09
                DG_Err_F = "1" : Exit Sub
            Else    '取込みデータもチェック
                WK_DtView1 = New DataView(DsImp.Tables("imp"), "伝票番号 = '" & DtView1(k)("伝票番号") & "' AND 請求区分 = '1' AND No < " & DtView1(k)("No") & " AND err_msg IS NULL", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count = 0 Then
                    WK_err_code = "09" '"同一締め内に取り消す保証番号なし" '09
                    DG_Err_F = "1" : Exit Sub
                End If
            End If
        End If

        '修理伝票番号重複チェック
        WK_DsList1.Clear()
        strSQL = "SELECT FLD014 FROM Wrn_ivc"
        strSQL += " WHERE (FLD014 = N'" & Format(DtView1(k)("修理伝票番号"), "000000000000") & "' AND (ordr_no = '" & DtView1(k)("伝票番号") & "')"
        strSQL += " OR FLD014 = N'" & DtView1(k)("修理伝票番号") & "') AND (ordr_no = '" & DtView1(k)("伝票番号") & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        r = DaList1.Fill(WK_DsList1, "Wrn_ivc")
        DB_CLOSE()
        If r <> 0 Then
            WK_err_code = "14" '"修理伝票番号重複" '14
            DG_Err_F = "1" : Exit Sub
        Else    '取込みデータもチェック
            WK_DtView1 = New DataView(DsImp.Tables("imp"), "伝票番号 = '" & DtView1(k)("伝票番号") & "' AND 請求区分 = '1' AND No < " & DtView1(k)("No") & " AND err_msg IS NULL AND 修理伝票番号 =" & DtView1(k)("修理伝票番号") & "", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count <> 0 Then
                WK_err_code = "14" '"修理伝票番号重複" '14
                DG_Err_F = "1" : Exit Sub
            End If
        End If

        '修理品製造番号チェック
        If DtView1(k)("事故状況フラグ") = "1" Then    '盗難の場合はnullでもOK
        Else
            WK_DsList1.Clear()
            strSQL = "SELECT close_date, seq_sub, FLD020 FROM Wrn_ivc"
            strSQL += " WHERE (ordr_no = '" & DtView1(k)("伝票番号") & "')"
            strSQL += " AND (line_no = '" & DtView1(k)("line_no") & "')"
            strSQL += " AND (seq = " & DtView1(k)("seq") & ")"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("best_wrn")
            DaList1.Fill(WK_DsList1, "Wrn_ivc")
            DB_CLOSE()
            WK_DtView1 = New DataView(WK_DsList1.Tables("Wrn_ivc"), "", "close_date DESC, seq_sub DESC", DataViewRowState.CurrentRows)
            If WK_DtView1.Count <> 0 Then
                If Trim(WK_DtView1(0)("FLD020")) <> Trim(DtView1(k)("修理品製造番号")) Then
                    WK_err_code = "76" '"修理品製造番号が前回と不一致"
                    DG_Err_F = "1" : Exit Sub
                End If
            End If
        End If

        '該当保険会社チェック
        If WK_corp_flg <> "1" Then    '個人   
            WK_DtView1 = New DataView(DsList1.Tables("insurance_co_sub"), "start_date <= '" & WK_prch_date & "' AND end_date >= '" & WK_prch_date & "' AND accident_flg = '" & DtView1(k)("事故状況フラグ") & "' AND corp_flg = '0'", "", DataViewRowState.CurrentRows)
        Else                                    '法人
            Dim A_YYYY As Integer
            If DateAdd(DateInterval.Year, 1, DtView2(0)("prch_date")) > WK_事故日 Then  '1年以下
                A_YYYY = 0
            Else
                If DateAdd(DateInterval.Year, 2, DtView2(0)("prch_date")) > WK_事故日 Then  '2年以下
                    A_YYYY = 1
                Else
                    If DateAdd(DateInterval.Year, 3, DtView2(0)("prch_date")) > WK_事故日 Then  '3年以下
                        A_YYYY = 2
                    Else
                        If DateAdd(DateInterval.Year, 4, DtView2(0)("prch_date")) > WK_事故日 Then  '4年以下
                            A_YYYY = 3
                        Else
                            If DateAdd(DateInterval.Year, 5, DtView2(0)("prch_date")) > WK_事故日 Then  '5年以下
                                A_YYYY = 4
                            Else
                                A_YYYY = 9
                            End If
                        End If
                    End If
                End If
            End If
            WK_DtView1 = New DataView(DsList1.Tables("insurance_co_sub"), "start_date <= '" & WK_prch_date & "' AND end_date >= '" & WK_prch_date & "' AND accident_flg = '" & DtView1(k)("事故状況フラグ") & "' AND corp_flg = '1' AND years_later = " & A_YYYY, "", DataViewRowState.CurrentRows)
        End If
        If S_flg = "1" Then
            WK_kbn_No = "S01"
        Else
            If b_flg = "1" Then
                WK_kbn_No = "BS1"
            Else
                If WK_DtView1.Count = 0 Then
                    WK_err_code = "35" '"該当する保険会社なし"
                    DG_Err_F = "1" : Exit Sub
                Else
                    WK_kbn_No = WK_DtView1(0)("kbn_No")
                End If
            End If
        End If
        DtView1(k)("kbn_No") = WK_kbn_No

        '2014/05/14 限度額修正対応  start
        '限度額チェック
        If DtView1(k)("事故状況フラグ") = "0" Then  '延長修理
            'If WK_kbn_No >= "N01" And WK_kbn_No <= "N08" Then
            '   WK_Limit_money = Round((DtView2(0)("prch_price") + DtView2(0)("prch_price")) * 0.8, 0)                                      '消費税8%対応　2014/04/22
            'Else
            '   If WK_kbn_No >= "N09" And WK_kbn_No <= "N10" Then
            '       WK_Limit_money = Round((DtView2(0)("prch_price") + DtView2(0)("prch_price")) * 0.8 * 0.9, 0)                            '消費税8%対応　2014/04/22
            '   Else
            '       If WK_kbn_No >= "N11" And WK_kbn_No <= "N13" Then
            '           WK_Limit_money = Round((DtView2(0)("prch_price") + DtView2(0)("prch_price")) * 0.9, 0)                              '消費税8%対応　2014/04/22
            '       Else
            '           If WK_kbn_No >= "N14" And WK_kbn_No <= "N99" Then
            '               If DtView2(0)("BY_cls") = "B" Then
            '                   If Trim(DtView2(0)("item_cat_code")) = "0501" And DtView2(0)("prch_date") >= "2007/06/1" Then   'PC
            '                       WK_Limit_money = RoundUP((DtView2(0)("prch_price") + DtView2(0)("prch_price")) * 0.5, 0)                '消費税8%対応　2014/04/22
            '                   Else
            '                       WK_Limit_money = Round((DtView2(0)("prch_price") + DtView2(0)("prch_price")) * 0.9, 0)                  '消費税8%対応　2014/04/22
            '                   End If
            '               Else
            '                   WK_Limit_money = Round((DtView2(0)("prch_price") + DtView2(0)("prch_price")) * 0.9, 0)                      '消費税8%対応　2014/04/22
            '               End If
            '           Else
            '               If WK_kbn_No >= "I01" And WK_kbn_No <= "I99" Then
            '                   WK_Limit_money = DtView2(0)("prch_price") + DtView2(0)("prch_price")                                        '消費税8%対応　2014/04/22
            '               Else
            '                   If WK_kbn_No >= "S01" And WK_kbn_No <= "S99" Then
            '                       WK_Limit_money = Round((DtView2(0)("prch_price") + DtView2(0)("prch_price")) * 0.9, 0)                  '消費税8%対応　2014/04/22
            '                   Else
            '                       If WK_kbn_No >= "BS1" And WK_kbn_No <= "BS9" Then
            '                           WK_Limit_money = DtView2(0)("prch_price") + DtView2(0)("prch_price")                                '消費税8%対応　2014/04/22
            '                       Else
            '                           If WK_kbn_No >= "E01" And WK_kbn_No <= "E99" Then
            '                               WK_Limit_money = DtView2(0)("prch_price") + DtView2(0)("prch_price")                            '消費税8%対応　2014/04/22
            '                           Else
            '                               If WK_kbn_No >= "BZ1" And WK_kbn_No <= "BZ9" Then
            '                                   WK_Limit_money = DtView2(0)("prch_price") + DtView2(0)("prch_price")                        '消費税8%対応　2014/04/22
            '                               Else
            '                                   If WK_kbn_No >= "BD1" And WK_kbn_No <= "BD9" Then
            '                                       WK_Limit_money = DtView2(0)("prch_price") + DtView2(0)("prch_price")                    '消費税8%対応　2014/04/22
            '                                   Else
            '                                       WK_Limit_money = Round((DtView2(0)("prch_price") + DtView2(0)("prch_price")) * 0.8, 0)  '消費税8%対応　2014/04/22
            '                                   End If
            '                               End If
            '                           End If
            '                       End If
            '                   End If
            '               End If
            '           End If
            '       End If
            '   End If
            'End If
            '上記のうち、限度額修正対応時点で必要な区分 I01～I99, E01～E99, BZ1～BZ9,BD1～BD9のケースのみの以下に変更。
            WK_Limit_money = DtView2(0)("prch_price") + DtView2(0)("prch_tax")      '購入価格（税抜） + 消費税

        Else
            If DateAdd(DateInterval.Year, 1, DtView2(0)("prch_date")) > WK_事故日 Then  '1年以下
                'WK_Limit_money = DtView2(0)("prch_price") + DtView2(0)("prch_price")                                                        '消費税8%対応　2014/04/22
                WK_Limit_money = DtView2(0)("prch_price") + DtView2(0)("prch_tax")
            Else
                If DateAdd(DateInterval.Year, 2, DtView2(0)("prch_date")) > WK_事故日 Then  '2年以下
                    'WK_Limit_money = Round((DtView2(0)("prch_price") + DtView2(0)("prch_price")) * 0.8, 0)                                  '消費税8%対応　2014/04/22
                    WK_Limit_money = Round((DtView2(0)("prch_price") + DtView2(0)("prch_tax")) * 0.8, 0)
                Else
                    If DateAdd(DateInterval.Year, 3, DtView2(0)("prch_date")) > WK_事故日 Then  '3年以下
                        'WK_Limit_money = Round((DtView2(0)("prch_price") + DtView2(0)("prch_price")) * 0.6, 0)                              '消費税8%対応　2014/04/22
                        WK_Limit_money = Round((DtView2(0)("prch_price") + DtView2(0)("prch_tax")) * 0.6, 0)
                    Else
                        If DateAdd(DateInterval.Year, 4, DtView2(0)("prch_date")) > WK_事故日 Then  '4年以下
                            'WK_Limit_money = Round((DtView2(0)("prch_price") + DtView2(0)("prch_price")) * 0.4 * 1.08, 0)                   '消費税8%対応　2014/04/22
                            WK_Limit_money = Round((DtView2(0)("prch_price") + DtView2(0)("prch_tax")) * 0.4, 0)
                        Else
                            If DateAdd(DateInterval.Year, 5, DtView2(0)("prch_date")) > WK_事故日 Then  '5年以下
                                'WK_Limit_money = Round((DtView2(0)("prch_price") + DtView2(0)("prch_price")) * 0.2, 0)                      '消費税8%対応　2014/04/22
                                WK_Limit_money = Round((DtView2(0)("prch_price") + DtView2(0)("prch_tax")) * 0.2, 0)
                            Else
                                WK_Limit_money = 0
                            End If
                        End If
                    End If
                End If
            End If
        End If

        DtView1(k)("Limit_money") = WK_Limit_money

        'If DtView1(k)("全損フラグ") = "0" Then
        '   If WK_Limit_money < CInt(DtView1(k)("請求額")) Then
        '       WK_err_code = "71" '"修理限度額 エラー"
        '       DG_Err_F = "1" : Exit Sub
        '   End If
        'Else
        '   If WK_Limit_money < Fix(CInt(DtView1(k)("請求額")) * 100 / 103) Then
        '       WK_err_code = "71" '"修理限度額 エラー"
        '       DG_Err_F = "1" : Exit Sub
        '   End If
        'End If

        '限度額修正対応の時点で、故障と全損で限度額に差異なしの為、以下に変更
        If WK_Limit_money < CInt(DtView1(k)("請求額")) Then
            WK_err_code = "71" '"修理限度額 エラー"
            DG_Err_F = "1" : Exit Sub
        End If
        '2014/05/14 限度額修正対応  end

        '掛種コードセット
        WK_DsList1.Clear()
        strSQL = "SELECT kakesyu"
        strSQL += " FROM insurance_co_decision"
        strSQL += " WHERE (kbn_No = '" & WK_kbn_No & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        DaList1.Fill(WK_DsList1, "insurance_co_decision")
        DB_CLOSE()
        WK_DtView1 = New DataView(WK_DsList1.Tables("insurance_co_decision"), "", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then
            DtView1(k)("掛種コード") = WK_DtView1(0)("kakesyu")
        Else
            WK_err_code = "74" '"掛種コードエラー"
            DG_Err_F = "1" : Exit Sub
        End If

    End Sub

    '***************************************************************************
    '** 反映
    '***************************************************************************
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Ans = MessageBox.Show("反映処理を開始します。よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
        If Ans = "6" Then
            Cursor = System.Windows.Forms.Cursors.WaitCursor
            now_date = Now.Date

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

                    upd_best_ok()   'ベストOK分更新
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

                    upd_best_err()  'ベストNG分更新
                Next
            End If

            'inp_log
            WK_DsList1.Clear()
            strSQL = "SELECT A_Data FROM inp_log WHERE (A_Data = 'A37" & Format(CDate(Date1.Text), "yyMMdd") & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("best_wrn")
            r = DaList1.Fill(WK_DsList1, "inp_log")
            If r = 0 Then
                strSQL = "INSERT INTO inp_log"
                strSQL += " (A_Data, close_date)"
                strSQL += " VALUES ('A37" & Format(CDate(Date1.Text), "yyMMdd") & "'"
                strSQL += ", CONVERT(DATETIME, '" & Label2.Text & "', 102))"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.ExecuteNonQuery()
            End If
            DB_CLOSE()

            MsgBox("反映しました。", MsgBoxStyle.OKOnly, "確認")
            waitDlg.Close()         '進行状況ダイアログを閉じる
            DsImp.Clear()
            Label1.Text = Nothing
            Button2.Enabled = False
            Button1.Enabled = True
            Button4.Enabled = True
            Button98.Enabled = True
            Date1.Enabled = True
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '***************************************************************************
    '** ベストOK分更新
    '***************************************************************************
    Sub upd_best_ok()   'ベストOK分更新

        If DtView1(i)("請求区分") = "1" Then    '請求
            strSQL = "INSERT INTO Wrn_ivc"
            strSQL += " (ordr_no, line_no, seq, close_date, seq_sub, FLD002, FLD004, FLD005, FLD006, FLD007, FLD008"
            strSQL += ", FLD009, FLD010, FLD011, FLD012, FLD013, FLD014, FLD015, FLD016, FLD017, FLD018, FLD019, FLD020"
            strSQL += ", FLD021, FLD022, FLD023, FLD024, FLD025, FLD026, FLD027, FLD028, FLD029, FLD030, FLD031, FLD032"
            strSQL += ", FLD033, FLD034, trbl_code, trbl_memo, rpar_mome, Remarks, kbn_No, Limit_money, Cancel_flg"
            strSQL += ", Cancel_date, close_flg, Limit_money_off, FLD020_off, BY_cls, entry_flg, buy_BY_cls"
            strSQL += ", ent_BY_cls, fin_BY_cls, pos_code, imp_date)"
            strSQL += " VALUES ('" & DtView1(i)("伝票番号") & "'"
            strSQL += ", '" & DtView1(i)("line_no") & "'"
            strSQL += ", " & DtView1(i)("seq") & ""
            strSQL += ", CONVERT(DATETIME, '" & Label2.Text & "', 102)"
            strSQL += ", 1"
            strSQL += ", N'" & DtView1(i)("請求番号") & "'"
            strSQL += ", N'" & DtView1(i)("承認番号") & "'"
            strSQL += ", CONVERT(DATETIME, '" & DtView1(i)("事故日") & "', 102)"
            strSQL += ", N'" & DtView1(i)("事故所") & "'"
            strSQL += ", N'" & DtView1(i)("事故状況フラグ") & "'"
            strSQL += ", N'" & DtView1(i)("項目有無フラグ") & "'"
            strSQL += ", N'" & DtView1(i)("全損フラグ") & "'"
            strSQL += ", N'" & DtView1(i)("修理品購入店") & "'"
            strSQL += ", N'" & DtView1(i)("修理受付店") & "'"
            strSQL += ", N'" & DtView1(i)("修理完了店") & "'"
            strSQL += ", '" & DtView1(i)("伝票区分") & "'"
            strSQL += ", N'" & DtView1(i)("修理伝票番号") & "'"
            strSQL += ", '" & DtView1(i)("顧客名") & "'"
            strSQL += ", '" & DtView1(i)("電話番号") & "'"
            strSQL += ", '" & DtView1(i)("bend_code") & "'"
            strSQL += ", '" & DtView1(i)("item_cat_code") & "'"
            strSQL += ", '" & DtView1(i)("型式") & "'"
            strSQL += ", '" & DtView1(i)("修理品製造番号") & "'"
            strSQL += ", CONVERT(DATETIME, '" & DtView1(i)("修理受付日") & "', 102)"
            strSQL += ", CONVERT(DATETIME, '" & DtView1(i)("修理完了日") & "', 102)"
            strSQL += ", " & DtView1(i)("出張料") & ""
            strSQL += ", " & DtView1(i)("作業料") & ""
            strSQL += ", " & DtView1(i)("部品料計") & ""
            strSQL += ", " & DtView1(i)("値引き額") & ""
            strSQL += ", " & DtView1(i)("請求除外金額") & ""
            strSQL += ", " & DtView1(i)("請求額") & ""
            strSQL += ", " & DtView1(i)("見積額") & ""
            strSQL += ", N'" & DtView1(i)("修理番号") & "'"
            strSQL += ", CONVERT(DATETIME, '" & DtView1(i)("データ処理日") & "', 102)"
            strSQL += ", N'" & DtView1(i)("請求区分") & "'"
            strSQL += ", '" & DtView1(i)("掛種コード") & "'"
            strSQL += ", ''"    '余白
            strSQL += ", ''"    'trbl_code
            strSQL += ", ''"    'trbl_memo
            strSQL += ", ''"    'rpar_mome
            strSQL += ", ''"    'Remarks
            strSQL += ", '" & DtView1(i)("kbn_No") & "'"
            strSQL += ", " & DtView1(i)("Limit_money") & ""
            strSQL += ", '0'"   'Cancel_flg
            strSQL += ", NULL"  'Cancel_date
            strSQL += ", '0'"   'close_flg
            strSQL += ", 0"     'Limit_money_off
            strSQL += ", 0"     'FLD020_off
            strSQL += ", '" & DtView1(i)("システム区分") & "'"
            strSQL += ", '0'"   'entry_flg
            strSQL += ", '" & DtView1(i)("修理購入店コード体系") & "'"
            strSQL += ", '" & DtView1(i)("修理受付店コード体系") & "'"
            strSQL += ", '" & DtView1(i)("修理完了店コード体系") & "'"
            strSQL += ", '" & DtView1(i)("商品コード") & "'"
            strSQL += ", CONVERT(DATETIME, '" & Date1.Text & "', 102))"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DB_OPEN("best_wrn")
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()

            '全損の場合
            If DtView1(i)("全損フラグ") = "1" Then
                If DtView1(i)("ON_cls") = "N" Then
                    strSQL = "UPDATE Wrn_sub"
                    strSQL += " SET total_loss_flg = '1'"
                    strSQL += " WHERE (ordr_no = '" & DtView1(i)("伝票番号") & "')"
                    strSQL += " AND (line_no = '" & DtView1(i)("line_no") & "')"
                    strSQL += " AND (seq = " & DtView1(i)("seq") & ")"
                    DB_OPEN("best_wrn")
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()

                    strSQL = "INSERT INTO total_loss"
                    strSQL += " (ordr_no, line_no, seq, total_loss_date)"
                    strSQL += " VALUES ('" & DtView1(i)("伝票番号") & "'"
                    strSQL += ", '" & DtView1(i)("line_no") & "'"
                    strSQL += ", " & DtView1(i)("seq") & ""
                    strSQL += ", '" & DtView1(i)("データ処理日") & "')"
                    DB_OPEN("best_wrn")
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()
                Else
                    strSQL = "UPDATE Wrn_data"
                    strSQL += " SET total_loss_flg = '1'"
                    strSQL += " WHERE (ordr_no = '" & DtView1(i)("伝票番号") & "')"
                    strSQL += " AND (line_no = '" & DtView1(i)("line_no") & "')"
                    DB_OPEN("best_wrn_data2")
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()

                    strSQL = "INSERT INTO total_loss"
                    strSQL += " (ordr_no, line_no, total_loss_date)"
                    strSQL += " VALUES ('" & DtView1(i)("伝票番号") & "'"
                    strSQL += ", '" & DtView1(i)("line_no") & "'"
                    strSQL += ", '" & DtView1(i)("データ処理日") & "')"
                    DB_OPEN("best_wrn_data2")
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()
                End If
            End If

        Else                                    '請求取消

            '請求データ
            strSQL = "UPDATE Wrn_ivc"
            strSQL += " SET Cancel_flg = '1'"
            strSQL += ", Cancel_date = '" & DtView1(i)("データ処理日") & "'"
            strSQL += " WHERE (ordr_no = '" & DtView1(i)("伝票番号") & "')"
            strSQL += " AND (FLD019 = '" & DtView1(i)("型式") & "')"
            strSQL += " AND (FLD020 = '" & DtView1(i)("修理品製造番号") & "')"
            DB_OPEN("best_wrn")
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()

            '全損の場合
            If DtView1(i)("全損フラグ") = "1" Then
                If DtView1(i)("ON_cls") = "N" Then
                    strSQL = "UPDATE Wrn_sub"
                    strSQL += " SET total_loss_flg = '0'"
                    strSQL += " WHERE (ordr_no = '" & DtView1(i)("伝票番号") & "')"
                    strSQL += " AND (line_no = '" & DtView1(i)("line_no") & "')"
                    strSQL += " AND (seq = " & DtView1(i)("seq") & ")"
                    DB_OPEN("best_wrn")
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()

                    strSQL = "DELETE FROM total_loss"
                    strSQL += " WHERE (ordr_no = '" & DtView1(i)("伝票番号") & "')"
                    strSQL += " AND (line_no = '" & DtView1(i)("line_no") & "')"
                    strSQL += " AND (seq = " & DtView1(i)("seq") & ")"
                    DB_OPEN("best_wrn")
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()
                Else
                    strSQL = "UPDATE Wrn_data"
                    strSQL += " SET total_loss_flg = '0'"
                    strSQL += " WHERE (ordr_no = '" & DtView1(i)("伝票番号") & "')"
                    strSQL += " AND (line_no = '" & DtView1(i)("line_no") & "')"
                    DB_OPEN("best_wrn_data2")
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()

                    strSQL = "DELETE FROM total_loss"
                    strSQL += " WHERE (ordr_no = '" & DtView1(i)("伝票番号") & "')"
                    strSQL += " AND (line_no = '" & DtView1(i)("line_no") & "')"
                    DB_OPEN("best_wrn_data2")
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()
                End If
            End If
        End If

    End Sub

    '***************************************************************************
    '** ベストNG分更新
    '***************************************************************************
    Sub upd_best_err()  'ベストNG分更新


        'strSQL = "SELECT '' AS 区分, '' AS システム区分, '' AS , '' AS 処理日, '' AS データ連番, '' AS , '' AS 手書き区分"
        'strSQL += ", '' AS 修理購入店コード体系, '' AS , '' AS 修理受付店コード体系, '' AS , '' AS 修理完了店コード体系"
        'strSQL += ", '' AS , '' AS , '' AS , '' AS , '' AS , '' AS 商品コード, '' AS "
        'strSQL += ", '' AS , '' AS , '' AS , '' AS , '' AS , '' AS , '' AS 掛種コード"
        'strSQL += ", 0 AS No, '' AS err_msg, '' AS ON_cls, '' AS line_no, 0 AS seq, '' AS kbn_No, 0 AS Limit_money"

        strSQL = "INSERT INTO Error_data_ivc"
        strSQL += " (Error_seq, Error_no, Error_msg"
        strSQL += ", ordr_no, FLD002, FLD004, FLD005, FLD006, FLD007, FLD008, FLD009, FLD010"
        strSQL += ", FLD011, FLD012, FLD013, FLD014, FLD015, FLD016, FLD017, FLD018, FLD019"
        strSQL += ", FLD020, FLD021, FLD022, FLD023, FLD024, FLD025, FLD026, FLD027, FLD028"
        strSQL += ", FLD029, FLD030, FLD031, FLD032, FLD033, FLD034"
        strSQL += ", Error_data, line_no, seq, Fixed_flg, Del_flg, close_date"
        strSQL += ", BY_cls, entry_flg, buy_BY_cls, ent_BY_cls, fin_BY_cls, pos_code, imp_date)"
        strSQL += " VALUES (" & Count_Get("003", "請求エラーSEQ")
        strSQL += ", '" & DtView1(i)("err_code") & "'"
        strSQL += ", '" & DtView1(i)("err_msg") & "'"
        strSQL += ", '" & MidB(DtView1(i)("伝票番号"), 1, 14) & "'"
        strSQL += ", '" & MidB(DtView1(i)("請求番号"), 1, 6) & "'"
        strSQL += ", '" & MidB(DtView1(i)("承認番号"), 1, 4) & "'"
        strSQL += ", '" & MidB(Replace(DtView1(i)("事故日"), "/", ""), 1, 8) & "'"
        strSQL += ", '" & MidB(DtView1(i)("事故所"), 1, 1) & "'"
        strSQL += ", '" & MidB(DtView1(i)("事故状況フラグ"), 1, 1) & "'"
        strSQL += ", '" & MidB(DtView1(i)("項目有無フラグ"), 1, 1) & "'"
        strSQL += ", '" & MidB(DtView1(i)("全損フラグ"), 1, 1) & "'"
        strSQL += ", '" & MidB(DtView1(i)("修理品購入店"), 1, 4) & "'"
        strSQL += ", '" & MidB(DtView1(i)("修理受付店"), 1, 4) & "'"
        strSQL += ", '" & MidB(DtView1(i)("修理完了店"), 1, 4) & "'"
        strSQL += ", '" & MidB(DtView1(i)("伝票区分"), 1, 2) & "'"
        strSQL += ", '" & MidB(DtView1(i)("修理伝票番号"), 1, 13) & "'"
        strSQL += ", '" & MidB(DtView1(i)("顧客名"), 1, 30) & "'"
        strSQL += ", '" & MidB(DtView1(i)("電話番号"), 1, 20) & "'"
        strSQL += ", ''"
        strSQL += ", ''"
        strSQL += ", '" & MidB(DtView1(i)("型式"), 1, 20) & "'"
        strSQL += ", '" & MidB(DtView1(i)("修理品製造番号"), 1, 15) & "'"
        strSQL += ", '" & MidB(Replace(DtView1(i)("修理受付日"), "/", ""), 1, 8) & "'"
        strSQL += ", '" & MidB(Replace(DtView1(i)("修理完了日"), "/", ""), 1, 8) & "'"
        strSQL += ", '" & MidB(DtView1(i)("出張料"), 1, 6) & "'"
        strSQL += ", '" & MidB(DtView1(i)("作業料"), 1, 8) & "'"
        strSQL += ", '" & MidB(DtView1(i)("部品料計"), 1, 8) & "'"
        strSQL += ", '" & MidB(DtView1(i)("値引き額"), 1, 8) & "'"
        strSQL += ", '" & MidB(DtView1(i)("請求除外金額"), 1, 8) & "'"
        strSQL += ", '" & MidB(DtView1(i)("請求額"), 1, 8) & "'"
        strSQL += ", '" & MidB(DtView1(i)("見積額"), 1, 8) & "'"
        strSQL += ", '" & MidB(DtView1(i)("修理番号"), 1, 13) & "'"
        strSQL += ", '" & MidB(Replace(DtView1(i)("データ処理日"), "/", ""), 1, 8) & "'"
        strSQL += ", '" & MidB(DtView1(i)("請求区分"), 1, 1) & "'"
        strSQL += ", '" & MidB(DtView1(i)("掛種コード"), 1, 5) & "'"
        strSQL += ", ''"
        strSQL += ", ''"
        strSQL += ", '" & DtView1(i)("line_no") & "'"
        strSQL += ", '" & DtView1(i)("seq") & "'"
        strSQL += ", '0', '0'"
        strSQL += ", CONVERT(DATETIME, '" & Label2.Text & "', 102)"
        strSQL += ", '" & DtView1(i)("システム区分") & "'"
        strSQL += ", '0'"   'entry_flg
        strSQL += ", '" & DtView1(i)("修理購入店コード体系") & "'"
        strSQL += ", '" & DtView1(i)("修理受付店コード体系") & "'"
        strSQL += ", '" & DtView1(i)("修理完了店コード体系") & "'"
        strSQL += ", '" & DtView1(i)("商品コード") & "'"
        strSQL += ", CONVERT(DATETIME, '" & Date1.Text & "', 102))"
        DB_OPEN("best_wrn")
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

    End Sub

    '***************************************************************************
    '** クリア
    '***************************************************************************
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        DsImp.Clear()
        Label1.Text = Nothing
        Button1.Enabled = True  '取込み
        Button2.Enabled = False '反映
        Date1.Enabled = True
    End Sub

    '***************************************************************************
    '** 戻る
    '***************************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        Application.Exit()
    End Sub
End Class
