Public Class Form1
    Inherits System.Windows.Forms.Form
    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1 As DataView

    Dim strSQL As String
    Dim r As Integer

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
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Edit1 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit2 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label1 As System.Windows.Forms.Label
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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
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
        Me.Button99 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label45 = New System.Windows.Forms.Label
        Me.Edit1 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit2 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label1 = New System.Windows.Forms.Label
        Me.DataGridTextBoxColumn37 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn38 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn39 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn40 = New System.Windows.Forms.DataGridTextBoxColumn
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGrid1
        '
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(12, 80)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.RowHeaderWidth = 10
        Me.DataGrid1.Size = New System.Drawing.Size(840, 492)
        Me.DataGrid1.TabIndex = 4
        Me.DataGrid1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGrid1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn37, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8, Me.DataGridTextBoxColumn9, Me.DataGridTextBoxColumn10, Me.DataGridTextBoxColumn38, Me.DataGridTextBoxColumn11, Me.DataGridTextBoxColumn39, Me.DataGridTextBoxColumn12, Me.DataGridTextBoxColumn40, Me.DataGridTextBoxColumn13, Me.DataGridTextBoxColumn14, Me.DataGridTextBoxColumn15, Me.DataGridTextBoxColumn16, Me.DataGridTextBoxColumn17, Me.DataGridTextBoxColumn18, Me.DataGridTextBoxColumn19, Me.DataGridTextBoxColumn20, Me.DataGridTextBoxColumn21, Me.DataGridTextBoxColumn22, Me.DataGridTextBoxColumn23, Me.DataGridTextBoxColumn24, Me.DataGridTextBoxColumn25, Me.DataGridTextBoxColumn26, Me.DataGridTextBoxColumn27, Me.DataGridTextBoxColumn28, Me.DataGridTextBoxColumn29, Me.DataGridTextBoxColumn30, Me.DataGridTextBoxColumn31, Me.DataGridTextBoxColumn32, Me.DataGridTextBoxColumn33, Me.DataGridTextBoxColumn34, Me.DataGridTextBoxColumn35, Me.DataGridTextBoxColumn36})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "scan"
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "保証番号"
        Me.DataGridTextBoxColumn1.MappingName = "ordr_no"
        Me.DataGridTextBoxColumn1.Width = 75
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "行番号"
        Me.DataGridTextBoxColumn2.MappingName = "line_no"
        Me.DataGridTextBoxColumn2.Width = 75
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "締め日"
        Me.DataGridTextBoxColumn3.MappingName = "close_date"
        Me.DataGridTextBoxColumn3.NullText = ""
        Me.DataGridTextBoxColumn3.Width = 75
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "請求番号"
        Me.DataGridTextBoxColumn4.MappingName = "FLD002"
        Me.DataGridTextBoxColumn4.NullText = ""
        Me.DataGridTextBoxColumn4.Width = 75
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "承認番号"
        Me.DataGridTextBoxColumn5.MappingName = "FLD004"
        Me.DataGridTextBoxColumn5.NullText = ""
        Me.DataGridTextBoxColumn5.Width = 75
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "事故日"
        Me.DataGridTextBoxColumn6.MappingName = "FLD005"
        Me.DataGridTextBoxColumn6.NullText = ""
        Me.DataGridTextBoxColumn6.Width = 75
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "事故場所"
        Me.DataGridTextBoxColumn7.MappingName = "FLD006"
        Me.DataGridTextBoxColumn7.NullText = ""
        Me.DataGridTextBoxColumn7.Width = 75
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn8.Format = ""
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "事故状況ﾌﾗｸﾞ"
        Me.DataGridTextBoxColumn8.MappingName = "FLD007"
        Me.DataGridTextBoxColumn8.NullText = ""
        Me.DataGridTextBoxColumn8.Width = 75
        '
        'DataGridTextBoxColumn9
        '
        Me.DataGridTextBoxColumn9.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn9.Format = ""
        Me.DataGridTextBoxColumn9.FormatInfo = Nothing
        Me.DataGridTextBoxColumn9.HeaderText = "項目有無ﾌﾗｸﾞ"
        Me.DataGridTextBoxColumn9.MappingName = "FLD008"
        Me.DataGridTextBoxColumn9.NullText = ""
        Me.DataGridTextBoxColumn9.Width = 75
        '
        'DataGridTextBoxColumn10
        '
        Me.DataGridTextBoxColumn10.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn10.Format = ""
        Me.DataGridTextBoxColumn10.FormatInfo = Nothing
        Me.DataGridTextBoxColumn10.HeaderText = "全損ﾌﾗｸﾞ"
        Me.DataGridTextBoxColumn10.MappingName = "FLD009"
        Me.DataGridTextBoxColumn10.NullText = ""
        Me.DataGridTextBoxColumn10.Width = 75
        '
        'DataGridTextBoxColumn11
        '
        Me.DataGridTextBoxColumn11.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn11.Format = ""
        Me.DataGridTextBoxColumn11.FormatInfo = Nothing
        Me.DataGridTextBoxColumn11.HeaderText = "修理品購入店"
        Me.DataGridTextBoxColumn11.MappingName = "FLD010"
        Me.DataGridTextBoxColumn11.NullText = ""
        Me.DataGridTextBoxColumn11.Width = 75
        '
        'DataGridTextBoxColumn12
        '
        Me.DataGridTextBoxColumn12.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn12.Format = ""
        Me.DataGridTextBoxColumn12.FormatInfo = Nothing
        Me.DataGridTextBoxColumn12.HeaderText = "修理受付店"
        Me.DataGridTextBoxColumn12.MappingName = "FLD011"
        Me.DataGridTextBoxColumn12.NullText = ""
        Me.DataGridTextBoxColumn12.Width = 75
        '
        'DataGridTextBoxColumn13
        '
        Me.DataGridTextBoxColumn13.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn13.Format = ""
        Me.DataGridTextBoxColumn13.FormatInfo = Nothing
        Me.DataGridTextBoxColumn13.HeaderText = "修理完了店"
        Me.DataGridTextBoxColumn13.MappingName = "FLD012"
        Me.DataGridTextBoxColumn13.NullText = ""
        Me.DataGridTextBoxColumn13.Width = 75
        '
        'DataGridTextBoxColumn14
        '
        Me.DataGridTextBoxColumn14.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn14.Format = ""
        Me.DataGridTextBoxColumn14.FormatInfo = Nothing
        Me.DataGridTextBoxColumn14.HeaderText = "伝票区分"
        Me.DataGridTextBoxColumn14.MappingName = "FLD013"
        Me.DataGridTextBoxColumn14.NullText = ""
        Me.DataGridTextBoxColumn14.Width = 75
        '
        'DataGridTextBoxColumn15
        '
        Me.DataGridTextBoxColumn15.Format = ""
        Me.DataGridTextBoxColumn15.FormatInfo = Nothing
        Me.DataGridTextBoxColumn15.HeaderText = "修理伝票番号"
        Me.DataGridTextBoxColumn15.MappingName = "FLD014"
        Me.DataGridTextBoxColumn15.NullText = ""
        Me.DataGridTextBoxColumn15.Width = 75
        '
        'DataGridTextBoxColumn16
        '
        Me.DataGridTextBoxColumn16.Format = ""
        Me.DataGridTextBoxColumn16.FormatInfo = Nothing
        Me.DataGridTextBoxColumn16.HeaderText = "顧客名"
        Me.DataGridTextBoxColumn16.MappingName = "FLD015"
        Me.DataGridTextBoxColumn16.NullText = ""
        Me.DataGridTextBoxColumn16.Width = 75
        '
        'DataGridTextBoxColumn17
        '
        Me.DataGridTextBoxColumn17.Format = ""
        Me.DataGridTextBoxColumn17.FormatInfo = Nothing
        Me.DataGridTextBoxColumn17.HeaderText = "電話番号"
        Me.DataGridTextBoxColumn17.MappingName = "FLD016"
        Me.DataGridTextBoxColumn17.NullText = ""
        Me.DataGridTextBoxColumn17.Width = 75
        '
        'DataGridTextBoxColumn18
        '
        Me.DataGridTextBoxColumn18.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn18.Format = ""
        Me.DataGridTextBoxColumn18.FormatInfo = Nothing
        Me.DataGridTextBoxColumn18.HeaderText = "メーカー"
        Me.DataGridTextBoxColumn18.MappingName = "FLD017"
        Me.DataGridTextBoxColumn18.NullText = ""
        Me.DataGridTextBoxColumn18.Width = 75
        '
        'DataGridTextBoxColumn19
        '
        Me.DataGridTextBoxColumn19.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn19.Format = ""
        Me.DataGridTextBoxColumn19.FormatInfo = Nothing
        Me.DataGridTextBoxColumn19.HeaderText = "品種"
        Me.DataGridTextBoxColumn19.MappingName = "FLD018"
        Me.DataGridTextBoxColumn19.NullText = ""
        Me.DataGridTextBoxColumn19.Width = 75
        '
        'DataGridTextBoxColumn20
        '
        Me.DataGridTextBoxColumn20.Format = ""
        Me.DataGridTextBoxColumn20.FormatInfo = Nothing
        Me.DataGridTextBoxColumn20.HeaderText = "型式"
        Me.DataGridTextBoxColumn20.MappingName = "FLD019"
        Me.DataGridTextBoxColumn20.NullText = ""
        Me.DataGridTextBoxColumn20.Width = 75
        '
        'DataGridTextBoxColumn21
        '
        Me.DataGridTextBoxColumn21.Format = ""
        Me.DataGridTextBoxColumn21.FormatInfo = Nothing
        Me.DataGridTextBoxColumn21.HeaderText = "修理品製造番号"
        Me.DataGridTextBoxColumn21.MappingName = "FLD020"
        Me.DataGridTextBoxColumn21.NullText = ""
        Me.DataGridTextBoxColumn21.Width = 75
        '
        'DataGridTextBoxColumn22
        '
        Me.DataGridTextBoxColumn22.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn22.Format = ""
        Me.DataGridTextBoxColumn22.FormatInfo = Nothing
        Me.DataGridTextBoxColumn22.HeaderText = "修理受付日"
        Me.DataGridTextBoxColumn22.MappingName = "FLD021"
        Me.DataGridTextBoxColumn22.NullText = ""
        Me.DataGridTextBoxColumn22.Width = 75
        '
        'DataGridTextBoxColumn23
        '
        Me.DataGridTextBoxColumn23.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn23.Format = ""
        Me.DataGridTextBoxColumn23.FormatInfo = Nothing
        Me.DataGridTextBoxColumn23.HeaderText = "修理完了日"
        Me.DataGridTextBoxColumn23.MappingName = "FLD022"
        Me.DataGridTextBoxColumn23.NullText = ""
        Me.DataGridTextBoxColumn23.Width = 75
        '
        'DataGridTextBoxColumn24
        '
        Me.DataGridTextBoxColumn24.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn24.Format = ""
        Me.DataGridTextBoxColumn24.FormatInfo = Nothing
        Me.DataGridTextBoxColumn24.HeaderText = "出張料"
        Me.DataGridTextBoxColumn24.MappingName = "FLD023"
        Me.DataGridTextBoxColumn24.NullText = ""
        Me.DataGridTextBoxColumn24.Width = 75
        '
        'DataGridTextBoxColumn25
        '
        Me.DataGridTextBoxColumn25.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn25.Format = ""
        Me.DataGridTextBoxColumn25.FormatInfo = Nothing
        Me.DataGridTextBoxColumn25.HeaderText = "作業料"
        Me.DataGridTextBoxColumn25.MappingName = "FLD024"
        Me.DataGridTextBoxColumn25.NullText = ""
        Me.DataGridTextBoxColumn25.Width = 75
        '
        'DataGridTextBoxColumn26
        '
        Me.DataGridTextBoxColumn26.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn26.Format = ""
        Me.DataGridTextBoxColumn26.FormatInfo = Nothing
        Me.DataGridTextBoxColumn26.HeaderText = "部品料計"
        Me.DataGridTextBoxColumn26.MappingName = "FLD025"
        Me.DataGridTextBoxColumn26.NullText = ""
        Me.DataGridTextBoxColumn26.Width = 75
        '
        'DataGridTextBoxColumn27
        '
        Me.DataGridTextBoxColumn27.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn27.Format = ""
        Me.DataGridTextBoxColumn27.FormatInfo = Nothing
        Me.DataGridTextBoxColumn27.HeaderText = "値引き額"
        Me.DataGridTextBoxColumn27.MappingName = "FLD026"
        Me.DataGridTextBoxColumn27.NullText = ""
        Me.DataGridTextBoxColumn27.Width = 75
        '
        'DataGridTextBoxColumn28
        '
        Me.DataGridTextBoxColumn28.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn28.Format = ""
        Me.DataGridTextBoxColumn28.FormatInfo = Nothing
        Me.DataGridTextBoxColumn28.HeaderText = "請求除外金額"
        Me.DataGridTextBoxColumn28.MappingName = "FLD027"
        Me.DataGridTextBoxColumn28.NullText = ""
        Me.DataGridTextBoxColumn28.Width = 75
        '
        'DataGridTextBoxColumn29
        '
        Me.DataGridTextBoxColumn29.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn29.Format = ""
        Me.DataGridTextBoxColumn29.FormatInfo = Nothing
        Me.DataGridTextBoxColumn29.HeaderText = "請求額"
        Me.DataGridTextBoxColumn29.MappingName = "FLD028"
        Me.DataGridTextBoxColumn29.NullText = ""
        Me.DataGridTextBoxColumn29.Width = 75
        '
        'DataGridTextBoxColumn30
        '
        Me.DataGridTextBoxColumn30.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn30.Format = ""
        Me.DataGridTextBoxColumn30.FormatInfo = Nothing
        Me.DataGridTextBoxColumn30.HeaderText = "見積額"
        Me.DataGridTextBoxColumn30.MappingName = "FLD029"
        Me.DataGridTextBoxColumn30.NullText = ""
        Me.DataGridTextBoxColumn30.Width = 75
        '
        'DataGridTextBoxColumn31
        '
        Me.DataGridTextBoxColumn31.Format = ""
        Me.DataGridTextBoxColumn31.FormatInfo = Nothing
        Me.DataGridTextBoxColumn31.HeaderText = "修理番号"
        Me.DataGridTextBoxColumn31.MappingName = "FLD030"
        Me.DataGridTextBoxColumn31.NullText = ""
        Me.DataGridTextBoxColumn31.Width = 75
        '
        'DataGridTextBoxColumn32
        '
        Me.DataGridTextBoxColumn32.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn32.Format = ""
        Me.DataGridTextBoxColumn32.FormatInfo = Nothing
        Me.DataGridTextBoxColumn32.HeaderText = "処理日"
        Me.DataGridTextBoxColumn32.MappingName = "FLD031"
        Me.DataGridTextBoxColumn32.NullText = ""
        Me.DataGridTextBoxColumn32.Width = 75
        '
        'DataGridTextBoxColumn33
        '
        Me.DataGridTextBoxColumn33.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn33.Format = ""
        Me.DataGridTextBoxColumn33.FormatInfo = Nothing
        Me.DataGridTextBoxColumn33.HeaderText = "請求区分"
        Me.DataGridTextBoxColumn33.MappingName = "FLD032"
        Me.DataGridTextBoxColumn33.NullText = ""
        Me.DataGridTextBoxColumn33.Width = 75
        '
        'DataGridTextBoxColumn34
        '
        Me.DataGridTextBoxColumn34.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn34.Format = ""
        Me.DataGridTextBoxColumn34.FormatInfo = Nothing
        Me.DataGridTextBoxColumn34.HeaderText = "掛種ｺｰﾄﾞ"
        Me.DataGridTextBoxColumn34.MappingName = "FLD033"
        Me.DataGridTextBoxColumn34.NullText = ""
        Me.DataGridTextBoxColumn34.Width = 75
        '
        'DataGridTextBoxColumn35
        '
        Me.DataGridTextBoxColumn35.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn35.Format = ""
        Me.DataGridTextBoxColumn35.FormatInfo = Nothing
        Me.DataGridTextBoxColumn35.HeaderText = "区分"
        Me.DataGridTextBoxColumn35.MappingName = "kbn_No"
        Me.DataGridTextBoxColumn35.NullText = ""
        Me.DataGridTextBoxColumn35.Width = 75
        '
        'DataGridTextBoxColumn36
        '
        Me.DataGridTextBoxColumn36.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn36.Format = ""
        Me.DataGridTextBoxColumn36.FormatInfo = Nothing
        Me.DataGridTextBoxColumn36.HeaderText = "限度額"
        Me.DataGridTextBoxColumn36.MappingName = "Limit_money"
        Me.DataGridTextBoxColumn36.NullText = ""
        Me.DataGridTextBoxColumn36.Width = 75
        '
        'Button99
        '
        Me.Button99.Location = New System.Drawing.Point(784, 16)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(64, 28)
        Me.Button99.TabIndex = 3
        Me.Button99.Text = "終了"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(340, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(64, 28)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "検索"
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.DarkBlue
        Me.Label22.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label22.Location = New System.Drawing.Point(16, 12)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(112, 24)
        Me.Label22.TabIndex = 1084
        Me.Label22.Text = "修理伝票番号"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label45
        '
        Me.Label45.BackColor = System.Drawing.Color.DarkBlue
        Me.Label45.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label45.Location = New System.Drawing.Point(16, 44)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(112, 24)
        Me.Label45.TabIndex = 1087
        Me.Label45.Text = "修理品製造番号"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit1
        '
        Me.Edit1.Format = "9"
        Me.Edit1.Location = New System.Drawing.Point(128, 12)
        Me.Edit1.Name = "Edit1"
        Me.Edit1.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit1.Size = New System.Drawing.Size(116, 24)
        Me.Edit1.TabIndex = 0
        Me.Edit1.Text = "1"
        Me.Edit1.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit2
        '
        Me.Edit2.Format = "9A"
        Me.Edit2.Location = New System.Drawing.Point(128, 44)
        Me.Edit2.Name = "Edit2"
        Me.Edit2.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit2.Size = New System.Drawing.Size(116, 24)
        Me.Edit2.TabIndex = 1
        Me.Edit2.Text = "1"
        Me.Edit2.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(728, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 16)
        Me.Label1.TabIndex = 1088
        Me.Label1.Text = "Label1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DataGridTextBoxColumn37
        '
        Me.DataGridTextBoxColumn37.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn37.Format = ""
        Me.DataGridTextBoxColumn37.FormatInfo = Nothing
        Me.DataGridTextBoxColumn37.HeaderText = "ｼｽﾃﾑ区分"
        Me.DataGridTextBoxColumn37.MappingName = "BY_cls"
        Me.DataGridTextBoxColumn37.Width = 75
        '
        'DataGridTextBoxColumn38
        '
        Me.DataGridTextBoxColumn38.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn38.Format = ""
        Me.DataGridTextBoxColumn38.FormatInfo = Nothing
        Me.DataGridTextBoxColumn38.HeaderText = "購入店体系"
        Me.DataGridTextBoxColumn38.MappingName = "buy_BY_cls"
        Me.DataGridTextBoxColumn38.Width = 75
        '
        'DataGridTextBoxColumn39
        '
        Me.DataGridTextBoxColumn39.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn39.Format = ""
        Me.DataGridTextBoxColumn39.FormatInfo = Nothing
        Me.DataGridTextBoxColumn39.HeaderText = "受付店体系"
        Me.DataGridTextBoxColumn39.MappingName = "ent_BY_cls"
        Me.DataGridTextBoxColumn39.Width = 75
        '
        'DataGridTextBoxColumn40
        '
        Me.DataGridTextBoxColumn40.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn40.Format = ""
        Me.DataGridTextBoxColumn40.FormatInfo = Nothing
        Me.DataGridTextBoxColumn40.HeaderText = "完了店体系"
        Me.DataGridTextBoxColumn40.MappingName = "fin_BY_cls"
        Me.DataGridTextBoxColumn40.Width = 75
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(870, 584)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Edit2)
        Me.Controls.Add(Me.Edit1)
        Me.Controls.Add(Me.Label45)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button99)
        Me.Controls.Add(Me.DataGrid1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "修理検索"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '起動時
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call DB_INIT()
        Edit1.Text = Nothing
        Edit2.Text = Nothing
        Label1.Text = Nothing
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        If Edit1.Text = Nothing And Edit2.Text = Nothing Then
            MsgBox("検索条件を入力してください")
        Else
            DsList1.Clear()

            'ﾃﾞｰﾀｸﾞﾘｯﾄﾞ設定
            strSQL = "SELECT * FROM Wrn_ivc"
            strSQL = strSQL & " WHERE (ordr_no IS NOT NULL)"
            If Edit1.Text <> Nothing Then strSQL = strSQL & " AND (FLD014 LIKE N'" & Edit1.Text & "%')"
            If Edit2.Text <> Nothing Then strSQL = strSQL & " AND (FLD020 LIKE '" & Edit2.Text & "%')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("best_wrn")
            SqlCmd1.CommandTimeout = 600
            r = DaList1.Fill(DsList1, "scan")
            DB_CLOSE()

            Label1.Text = Format(r, "##,##0") & "件"

            Dim tbl As New DataTable
            tbl = DsList1.Tables("scan")
            DataGrid1.DataSource = tbl
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        Application.Exit()
    End Sub

    Private Sub Edit1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit1.LostFocus
        Edit1.Text = Trim(Edit1.Text)

    End Sub

    Private Sub Edit2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit2.LostFocus
        Edit2.Text = Trim(Edit2.Text)

    End Sub
End Class
