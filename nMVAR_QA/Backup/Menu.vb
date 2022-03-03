Imports System.Runtime.InteropServices

Public Class Menu
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1, DtView2 As DataView

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
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents Button15 As System.Windows.Forms.Button
    Friend WithEvents Button16 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Menu))
        Me.Button12 = New System.Windows.Forms.Button
        Me.Button15 = New System.Windows.Forms.Button
        Me.Button98 = New System.Windows.Forms.Button
        Me.Button14 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button13 = New System.Windows.Forms.Button
        Me.Button16 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Button12
        '
        Me.Button12.BackColor = System.Drawing.SystemColors.Control
        Me.Button12.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button12.Location = New System.Drawing.Point(8, 48)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(156, 40)
        Me.Button12.TabIndex = 1
        Me.Button12.Text = "受付入力"
        '
        'Button15
        '
        Me.Button15.BackColor = System.Drawing.SystemColors.Control
        Me.Button15.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button15.Location = New System.Drawing.Point(176, 104)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(156, 40)
        Me.Button15.TabIndex = 5
        Me.Button15.Text = "破棄登録"
        '
        'Button98
        '
        Me.Button98.BackColor = System.Drawing.SystemColors.Control
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(344, 160)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(156, 40)
        Me.Button98.TabIndex = 7
        Me.Button98.Text = "戻る"
        '
        'Button14
        '
        Me.Button14.BackColor = System.Drawing.SystemColors.Control
        Me.Button14.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button14.Location = New System.Drawing.Point(8, 104)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(156, 40)
        Me.Button14.TabIndex = 4
        Me.Button14.Text = "出荷処理"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(476, 20)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Label1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button13
        '
        Me.Button13.BackColor = System.Drawing.SystemColors.Control
        Me.Button13.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button13.Location = New System.Drawing.Point(176, 48)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(156, 40)
        Me.Button13.TabIndex = 2
        Me.Button13.Text = "受信データ参照"
        '
        'Button16
        '
        Me.Button16.BackColor = System.Drawing.SystemColors.Control
        Me.Button16.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button16.Location = New System.Drawing.Point(344, 48)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(156, 40)
        Me.Button16.TabIndex = 3
        Me.Button16.Text = "一覧表"
        '
        'Menu
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 15)
        Me.ClientSize = New System.Drawing.Size(506, 215)
        Me.Controls.Add(Me.Button16)
        Me.Controls.Add(Me.Button13)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button14)
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.Button15)
        Me.Controls.Add(Me.Button98)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Menu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Q&Aメニュー"
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub Menu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DB_INIT()
        inz()       '**  初期処理
        ACES()      '**  権限チェック
        pc_name()   '**  ローカルＰＣ名取得
    End Sub

    '********************************************************************
    '**  初期処理
    '********************************************************************
    Sub inz()
        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        strcurdir = System.IO.Directory.GetCurrentDirectory                                         '実行フォルダー

        Err_F = "0"
        P_EMPL = System.Environment.UserName
        If P_EMPL = "otsuki" Then P_EMPL = "administrator" '大槻テスト用

        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("SP_Login_01", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.VarChar, 20)
        Pram1.Value = P_EMPL
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsList1, "M01_EMPL")
        DB_CLOSE()

        DtView1 = New DataView(DsList1.Tables("M01_EMPL"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 0 Then
            Err_F = "1"
            MessageBox.Show("ユーザーが登録されていません。", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If DtView1(0)("delt_flg") = "1" Then
                Err_F = "1"
                MessageBox.Show("ユーザー登録が無効です。", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                P_EMPL_NO = DtView1(0)("empl_code")
                P_EMPL_NAME = Trim(DtView1(0)("name"))

                If P_EMPL_BRCH <> Nothing Then
                    SqlCmd1 = New SqlClient.SqlCommand("SP_Login_02", cnsqlclient)
                    SqlCmd1.CommandType = CommandType.StoredProcedure
                    Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 2)
                    Pram2.Value = P_EMPL_BRCH
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN("nMVAR")
                    SqlCmd1.CommandTimeout = 600
                    DaList1.Fill(DsList1, "BRCH")
                    DB_CLOSE()
                    DtView2 = New DataView(DsList1.Tables("BRCH"), "", "", DataViewRowState.CurrentRows)
                    If DtView2.Count <> 0 Then
                        P_EMPL_BRCH_name = Trim(DtView2(0)("brch_name"))
                        P_full = DtView2(0)("full_cntl")
                        P_comp_code = DtView2(0)("comp_code")
                        P_area_code = DtView2(0)("area_code")
                    End If
                Else
                    P_EMPL_BRCH = Trim(DtView1(0)("brch_code"))
                    P_EMPL_BRCH_name = Trim(DtView1(0)("brch_name"))
                    P_full = DtView1(0)("full_cntl")
                    P_comp_code = DtView1(0)("comp_code")
                    P_area_code = DtView1(0)("area_code")
                End If
                P_ACES_brch_code = P_EMPL_BRCH
                P_ACES_post_code = Trim(DtView1(0)("post_code"))

                If Not IsDBNull(DtView1(0)("admin_flg")) Then P_DBG = DtView1(0)("admin_flg") Else P_DBG = "False"

                Label1.Text = P_EMPL_NAME & " / " & P_EMPL_BRCH_name
            End If
        End If
    End Sub

    '********************************************************************
    '**  ローカルＰＣ名取得
    '********************************************************************
    Sub pc_name()
        Dim serverName As String
        Dim clientInfo As New WTS_CLIENT_INFO
        ReDim clientInfo.Address(20)
        serverName = ""
        If GetSessions(serverName, clientInfo) = True Then
            If clientInfo.WTSClientName = "" Then
                P_PC_NAME = clientInfo.WTSDomainName
            Else
                P_PC_NAME = clientInfo.WTSClientName
            End If
            P_PC_NAME2 = clientInfo.WTSClientName
        End If
    End Sub

    '********************************************************************
    '**  権限チェック
    '********************************************************************
    Sub ACES()

        SqlCmd1 = New SqlClient.SqlCommand("sp_ACES_CHK", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 2)
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.Char, 2)
        Pram1.Value = P_ACES_brch_code
        Pram2.Value = P_ACES_post_code
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsList1, "ACES_CHK")
        DB_CLOSE()

        '受付入力
        Button12.Enabled = False
        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='Q12'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Select Case DtView1(0)("access_cls")
                Case Is = "2", "3", "4"
                    Button12.Enabled = True
            End Select
        End If

        '受信データ参照
        Button13.Enabled = False
        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='Q13'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Select Case DtView1(0)("access_cls")
                Case Is = "2", "3", "4"
                    Button13.Enabled = True
            End Select
        End If

        '一覧表表示
        Button16.Enabled = False
        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='Q16'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Select Case DtView1(0)("access_cls")
                Case Is = "2", "3", "4"
                    Button16.Enabled = True
            End Select
        End If

        '出荷処理
        Button14.Enabled = False
        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='Q14'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Select Case DtView1(0)("access_cls")
                Case Is = "2", "3", "4"
                    Button14.Enabled = True
            End Select
        End If

        '破棄登録
        Button15.Enabled = False
        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='Q15'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Select Case DtView1(0)("access_cls")
                Case Is = "2", "3", "4"
                    Button15.Enabled = True
            End Select
        End If

    End Sub

    '********************************************************************
    '**  受付入力
    '********************************************************************
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim F01_Form12 As New F01_Form12
        F01_Form12.ShowDialog()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  受信データ参照
    '********************************************************************
    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim F01_Form13 As New F01_Form13
        F01_Form13.ShowDialog()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  一覧表表示
    '********************************************************************
    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim F01_Form16 As New F01_Form16
        F01_Form16.ShowDialog()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  出荷処理
    '********************************************************************
    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim F01_Form14 As New F01_Form14
        F01_Form14.ShowDialog()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  破棄登録
    '********************************************************************
    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim F01_Form15 As New F01_Form15
        F01_Form15.ShowDialog()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  閉じる・終了 ボタン
    '********************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        Application.Exit()
    End Sub

    '********************************************************************
    '**  GotFocus 
    '********************************************************************
    Private Sub Button12_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.GotFocus
        Button12.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
    End Sub
    Private Sub Button13_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.GotFocus
        Button13.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
    End Sub
    Private Sub Button14_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.GotFocus
        Button14.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
    End Sub
    Private Sub Button15_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.GotFocus
        Button15.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
    End Sub
    Private Sub Button16_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.GotFocus
        Button16.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
    End Sub
    Private Sub Button98_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.GotFocus
        Button98.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub Button12_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.LostFocus
        Button12.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub Button13_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.LostFocus
        Button13.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub Button14_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.LostFocus
        Button14.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub Button15_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.LostFocus
        Button15.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub Button16_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.LostFocus
        Button16.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub Button98_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.LostFocus
        Button98.BackColor = System.Drawing.SystemColors.Control
    End Sub

    Private Enum WTS_CONNECTSTATE_CLASS
        WTSActive
        WTSConnected
        WTSConnectQuery
        WTSShadow
        WTSDisconnected
        WTSIdle
        WTSListen
        WTSReset
        WTSDown
        WTSInit
    End Enum

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto)> _
    Private Structure WTS_SESSION_INFO
        Dim SessionID As Int32 'DWORD integer
        Dim pWinStationName As String ' integer LPTSTR - Pointer to a null-terminated string containing the name of the WinStation for this session
        Dim State As WTS_CONNECTSTATE_CLASS
    End Structure

    Friend Structure strSessionsInfo
        Dim SessionID As Integer
        Dim StationName As String
        Dim ConnectionState As String
    End Structure

    Private Enum WTS_INFO_CLASS
        WTSInitialProgram
        WTSApplicationName
        WTSWorkingDirectory
        WTSOEMId
        WTSSessionId
        WTSUserName
        WTSWinStationName
        WTSDomainName
        WTSConnectState
        WTSClientBuildNumber
        WTSClientName
        WTSClientDirectory
        WTSClientProductId
        WTSClientHardwareId
        WTSClientAddress
        WTSClientDisplay
        WTSClientProtocolType
        WTSIdleTime
        WTSLogonTime
        WTSIncomingBytes
        WTSOutgoingBytes
        WTSIncomingFrames
        WTSOutgoingFrames
    End Enum

    'Structure for TS Client IP Address
    <StructLayout(LayoutKind.Sequential)> _
    Private Structure _WTS_CLIENT_ADDRESS
        Public AddressFamily As Integer
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=20)> _
        Public Address As Byte()
    End Structure

    'Structure for TS Client Information
    Friend Structure WTS_CLIENT_INFO
        Public WTSStatus As Boolean
        Public WTSUserName As String
        Public WTSStationName As String
        Public WTSDomainName As String
        Public WTSClientName As String
        Public AddressFamily As Integer
        Public Address As Byte()
    End Structure

    'Function for TS Session Information excluding Client IP address
    Private Declare Function WTSQuerySessionInformation Lib "WtsApi32.dll" Alias "WTSQuerySessionInformationW" (ByVal hServer As Int32, _
    ByVal SessionId As Int32, ByVal WTSInfoClass As Int32, <MarshalAs(UnmanagedType.LPWStr)> ByRef ppBuffer As String, ByRef pCount As Int32) As Boolean

    'Function for TS Client IP Address
    Private Declare Function WTSQuerySessionInformation2 Lib "WtsApi32.dll" Alias "WTSQuerySessionInformationW" (ByVal hServer As Int32, _
      ByVal SessionId As Int32, ByVal WTSInfoClass As Int32, ByRef ppBuffer As IntPtr, ByRef pCount As Int32) As Boolean

    Private Declare Function GetCurrentProcessId Lib "Kernel32.dll" Alias "GetCurrentProcessId" () As Int32
    Private Declare Function ProcessIdToSessionId Lib "Kernel32.dll" Alias "ProcessIdToSessionId" (ByVal processID As Int32, ByRef sessionID As Int32) As Boolean
    Private Declare Function WTSGetActiveConsoleSessionId Lib "Kernel32.dll" Alias "WTSGetActiveConsoleSessionId" () As Int32

    <DllImport("wtsapi32.dll", _
    bestfitmapping:=True, _
    CallingConvention:=CallingConvention.StdCall, _
    CharSet:=CharSet.Auto, _
    EntryPoint:="WTSEnumerateSessions", _
    setlasterror:=True, _
    ThrowOnUnmappableChar:=True)> _
    Private Shared Function WTSEnumerateSessions( _
    ByVal hServer As IntPtr, _
    <MarshalAs(UnmanagedType.U4)> _
    ByVal Reserved As Int32, _
    <MarshalAs(UnmanagedType.U4)> _
    ByVal Vesrion As Int32, _
    ByRef ppSessionInfo As IntPtr, _
    <MarshalAs(UnmanagedType.U4)> _
    ByRef pCount As Int32) As Int32
    End Function

    <DllImport("wtsapi32.dll")> _
    Private Shared Sub WTSFreeMemory(ByVal pMemory As IntPtr)
    End Sub

    <DllImport("wtsapi32.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
     Private Shared Function WTSOpenServer(ByVal pServerName As String) As IntPtr
    End Function

    <DllImport("wtsapi32.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
     Private Shared Sub WTSCloseServer(ByVal hServer As IntPtr)
    End Sub

    Friend Function GetSessions(ByVal ServerName As String, ByRef ClientInfo As WTS_CLIENT_INFO) As Boolean
        Dim ptrOpenedServer As IntPtr
        Try
            ptrOpenedServer = WTSOpenServer(ServerName)
            If ptrOpenedServer.ToInt32 = vbNull Then
                MessageBox.Show("Terminal Services not running on : " & ServerName)
                GetSessions = False
                Exit Function
            End If
            Dim FRetVal As Int32
            Dim ppSessionInfo As IntPtr = IntPtr.Zero
            Dim Count As Int32 = 0
            Try
                FRetVal = WTSEnumerateSessions(ptrOpenedServer, 0, 1, ppSessionInfo, Count)
                If FRetVal <> 0 Then
                    Dim sessionInfo() As WTS_SESSION_INFO = New WTS_SESSION_INFO(Count) {}
                    Dim i As Integer
                    Dim session_ptr As IntPtr
                    For i = 0 To Count - 1
                        'session_ptr = ppSessionInfo.ToInt32() + (i * Marshal.SizeOf(sessionInfo(i)))
                        sessionInfo(i) = CType(Marshal.PtrToStructure(session_ptr, GetType(WTS_SESSION_INFO)), WTS_SESSION_INFO)
                    Next
                    WTSFreeMemory(ppSessionInfo)
                    Dim tmpArr(sessionInfo.GetUpperBound(0)) As strSessionsInfo
                    For i = 0 To tmpArr.GetUpperBound(0)
                        tmpArr(i).SessionID = sessionInfo(i).SessionID
                        tmpArr(i).StationName = sessionInfo(i).pWinStationName
                        tmpArr(i).ConnectionState = GetConnectionState(sessionInfo(i).State)
                        'MessageBox.Show(tmpArr(i).StationName & "  " & tmpArr(i).SessionID & "  " & tmpArr(i).ConnectionState)
                    Next
                    ReDim sessionInfo(-1)
                Else
                    Throw New ApplicationException("No data retruned")
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message & vbCrLf & System.Runtime.InteropServices.Marshal.GetLastWin32Error)
            End Try
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Exit Function
        Finally
        End Try
        'Get ProcessID of TS Session that executed this TS Session
        Dim active_process As Int32 = GetCurrentProcessId()
        Dim active_session As Int32 = 0
        Dim success1 As Boolean = ProcessIdToSessionId(active_process, active_session)
        If success1 = False Then
            MessageBox.Show("Error: ProcessIdToSessionId")
        End If
        Dim returned As Integer
        Dim str As String = ""
        Dim success As Boolean = False
        ClientInfo.WTSStationName = ""
        ClientInfo.WTSClientName = ""
        ClientInfo.Address(2) = 0
        ClientInfo.Address(3) = 0
        ClientInfo.Address(4) = 0
        ClientInfo.Address(5) = 0

        'Get User Name of this TS session
        If WTSQuerySessionInformation(ptrOpenedServer.ToInt32, active_session, WTS_INFO_CLASS.WTSUserName, str, returned) = True Then
            ClientInfo.WTSUserName = str
        End If

        'Get StationName of this TS session
        If WTSQuerySessionInformation(ptrOpenedServer.ToInt32, active_session, WTS_INFO_CLASS.WTSWinStationName, str, returned) = True Then
            ClientInfo.WTSStationName = str
        End If

        'Get Domain Name of this TS session
        If WTSQuerySessionInformation(ptrOpenedServer.ToInt32, active_session, WTS_INFO_CLASS.WTSDomainName, str, returned) = True Then
            ClientInfo.WTSDomainName = str
        End If

        'Skip client name and client address if this is a console session
        If ClientInfo.WTSStationName <> "Console" Then
            If WTSQuerySessionInformation(ptrOpenedServer.ToInt32, active_session, WTS_INFO_CLASS.WTSClientName, str, returned) = True Then
                ClientInfo.WTSClientName = str
            End If

            'Get client IP address
            Dim addr As IntPtr
            If WTSQuerySessionInformation2(ptrOpenedServer.ToInt32, active_session, WTS_INFO_CLASS.WTSClientAddress, addr, returned) = True Then
                Dim obj As New _WTS_CLIENT_ADDRESS
                obj = CType(Marshal.PtrToStructure(addr, obj.GetType()), _WTS_CLIENT_ADDRESS)
                ClientInfo.Address(2) = obj.Address(2)
                ClientInfo.Address(3) = obj.Address(3)
                ClientInfo.Address(4) = obj.Address(4)
                ClientInfo.Address(5) = obj.Address(5)
            End If
        End If
        WTSCloseServer(ptrOpenedServer)
        Return True
    End Function

    Private Function GetConnectionState(ByVal State As WTS_CONNECTSTATE_CLASS) As String
        Dim RetVal As String
        Select Case State
            Case WTS_CONNECTSTATE_CLASS.WTSActive
                RetVal = "Active"
            Case WTS_CONNECTSTATE_CLASS.WTSConnected
                RetVal = "Connected"
            Case WTS_CONNECTSTATE_CLASS.WTSConnectQuery
                RetVal = "Query"
            Case WTS_CONNECTSTATE_CLASS.WTSDisconnected
                RetVal = "Disconnected"
            Case WTS_CONNECTSTATE_CLASS.WTSDown
                RetVal = "Down"
            Case WTS_CONNECTSTATE_CLASS.WTSIdle
                RetVal = "Idle"
            Case WTS_CONNECTSTATE_CLASS.WTSInit
                RetVal = "Initializing."
            Case WTS_CONNECTSTATE_CLASS.WTSListen
                RetVal = "Listen"
            Case WTS_CONNECTSTATE_CLASS.WTSReset
                RetVal = "reset"
            Case WTS_CONNECTSTATE_CLASS.WTSShadow
                RetVal = "Shadowing"
            Case Else
                RetVal = "Unknown connect state"
        End Select
        Return RetVal
    End Function
End Class
