Imports System.Runtime.InteropServices

Public Class Menu30
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
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button98 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Menu30))
        Me.Button12 = New System.Windows.Forms.Button
        Me.Button11 = New System.Windows.Forms.Button
        Me.Button10 = New System.Windows.Forms.Button
        Me.Button9 = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button98 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Button12
        '
        Me.Button12.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button12.Enabled = False
        Me.Button12.Location = New System.Drawing.Point(224, 364)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(164, 48)
        Me.Button12.TabIndex = 53
        Me.Button12.Visible = False
        '
        'Button11
        '
        Me.Button11.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button11.Enabled = False
        Me.Button11.Location = New System.Drawing.Point(224, 300)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(164, 48)
        Me.Button11.TabIndex = 52
        Me.Button11.Visible = False
        '
        'Button10
        '
        Me.Button10.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button10.Enabled = False
        Me.Button10.Location = New System.Drawing.Point(224, 236)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(164, 48)
        Me.Button10.TabIndex = 51
        Me.Button10.Visible = False
        '
        'Button9
        '
        Me.Button9.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button9.Enabled = False
        Me.Button9.Location = New System.Drawing.Point(224, 172)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(164, 48)
        Me.Button9.TabIndex = 50
        Me.Button9.Visible = False
        '
        'Button8
        '
        Me.Button8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button8.Enabled = False
        Me.Button8.Location = New System.Drawing.Point(224, 108)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(164, 48)
        Me.Button8.TabIndex = 49
        Me.Button8.Visible = False
        '
        'Button7
        '
        Me.Button7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button7.Enabled = False
        Me.Button7.Location = New System.Drawing.Point(224, 44)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(164, 48)
        Me.Button7.TabIndex = 48
        Me.Button7.Visible = False
        '
        'Button6
        '
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.Enabled = False
        Me.Button6.Location = New System.Drawing.Point(32, 364)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(164, 48)
        Me.Button6.TabIndex = 47
        Me.Button6.Visible = False
        '
        'Button5
        '
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Enabled = False
        Me.Button5.Location = New System.Drawing.Point(32, 300)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(164, 48)
        Me.Button5.TabIndex = 46
        Me.Button5.Visible = False
        '
        'Button4
        '
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Enabled = False
        Me.Button4.Location = New System.Drawing.Point(32, 236)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(164, 48)
        Me.Button4.TabIndex = 45
        Me.Button4.Text = "一　般"
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Enabled = False
        Me.Button3.Location = New System.Drawing.Point(32, 172)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(164, 48)
        Me.Button3.TabIndex = 44
        Me.Button3.Text = "メーカー"
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Enabled = False
        Me.Button2.Location = New System.Drawing.Point(32, 108)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(164, 48)
        Me.Button2.TabIndex = 43
        Me.Button2.Text = "保険会社"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Enabled = False
        Me.Button1.Location = New System.Drawing.Point(32, 44)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(164, 48)
        Me.Button1.TabIndex = 42
        Me.Button1.Text = "販　社"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(32, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(580, 20)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "Label1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button98
        '
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(416, 364)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(164, 48)
        Me.Button98.TabIndex = 54
        Me.Button98.Text = "戻る"
        '
        'Menu30
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 19)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.ClientSize = New System.Drawing.Size(618, 440)
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button98)
        Me.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Menu30"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "入金メニュー"
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub Menu30_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo TAG_Err
        If DB_INIT() = "1" Then Application.Exit() : Exit Sub
        inz()   '**  初期処理
        If Err_F = "1" Then Application.Exit() : Exit Sub
        ACES()  '**  権限チェック
        pc_name()   '**  ローカルＰＣ名取得

        Exit Sub
TAG_Err:
        MessageBox.Show(Err.Description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Application.Exit()
    End Sub

    '********************************************************************
    '**  初期処理
    '********************************************************************
    Sub inz()
        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

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

        '入金処理（販社）
        Button1.Enabled = False
        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='301'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Select Case DtView1(0)("access_cls")
                Case Is = "2", "3", "4"
                    Button1.Enabled = True
            End Select
        End If

        '入金処理（保険会社）
        Button2.Enabled = False
        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='302'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Select Case DtView1(0)("access_cls")
                Case Is = "2", "3", "4"
                    Button2.Enabled = True
            End Select
        End If

        '入金処理（メーカー）
        Button3.Enabled = False
        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='303'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Select Case DtView1(0)("access_cls")
                Case Is = "2", "3", "4"
                    Button3.Enabled = True
            End Select
        End If

        '入金処理（一般）
        Button4.Enabled = False
        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='304'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Select Case DtView1(0)("access_cls")
                Case Is = "2", "3", "4"
                    Button4.Enabled = True
            End Select
        End If

    End Sub

    '********************************************************************
    '**  入金処理（販社）
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.Hide()
        Dim F30_Form01 As New F30_Form01
        F30_Form01.ShowDialog()
        Me.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  入金処理（保険会社）
    '********************************************************************
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

    End Sub

    '********************************************************************
    '**  入金処理（メーカー）
    '********************************************************************
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.Hide()
        Dim F30_Form03 As New F30_Form03
        F30_Form03.ShowDialog()
        Me.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  入金処理（一般）
    '********************************************************************
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.Hide()
        Dim F30_Form04 As New F30_Form04
        F30_Form04.ShowDialog()
        Me.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  戻る
    '********************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        DsList1.Clear()
        Close()
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
    Private Declare Function WTSQuerySessionInformation Lib "WtsApi32.dll" Alias "WTSQuerySessionInformationW" (ByVal hServer As Int64,
    ByVal SessionId As Int64, ByVal WTSInfoClass As Int64, <MarshalAs(UnmanagedType.LPWStr)> ByRef ppBuffer As String, ByRef pCount As Int64) As Boolean

    'Function for TS Client IP Address
    Private Declare Function WTSQuerySessionInformation2 Lib "WtsApi32.dll" Alias "WTSQuerySessionInformationW" (ByVal hServer As Int64,
      ByVal SessionId As Int64, ByVal WTSInfoClass As Int64, ByRef ppBuffer As IntPtr, ByRef pCount As Int64) As Boolean

    Private Declare Function GetCurrentProcessId Lib "Kernel32.dll" Alias "GetCurrentProcessId" () As Int64
    Private Declare Function ProcessIdToSessionId Lib "Kernel32.dll" Alias "ProcessIdToSessionId" (ByVal processID As Int64, ByRef sessionID As Int64) As Boolean
    Private Declare Function WTSGetActiveConsoleSessionId Lib "Kernel32.dll" Alias "WTSGetActiveConsoleSessionId" () As Int64

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
            If ptrOpenedServer.ToInt64 = vbNull Then
                MessageBox.Show("Terminal Services not running on : " & ServerName)
                GetSessions = False
                Exit Function
            End If
            Dim FRetVal As Int64
            Dim ppSessionInfo As IntPtr = IntPtr.Zero
            Dim Count As Int64 = 0
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
        Dim active_process As Int64 = GetCurrentProcessId()
        Dim active_session As Int64 = 0
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
        If WTSQuerySessionInformation(ptrOpenedServer.ToInt64, active_session, WTS_INFO_CLASS.WTSUserName, str, returned) = True Then
            ClientInfo.WTSUserName = str
        End If

        'Get StationName of this TS session
        If WTSQuerySessionInformation(ptrOpenedServer.ToInt64, active_session, WTS_INFO_CLASS.WTSWinStationName, str, returned) = True Then
            ClientInfo.WTSStationName = str
        End If

        'Get Domain Name of this TS session
        If WTSQuerySessionInformation(ptrOpenedServer.ToInt64, active_session, WTS_INFO_CLASS.WTSDomainName, str, returned) = True Then
            ClientInfo.WTSDomainName = str
        End If

        'Skip client name and client address if this is a console session
        If ClientInfo.WTSStationName <> "Console" Then
            If WTSQuerySessionInformation(ptrOpenedServer.ToInt64, active_session, WTS_INFO_CLASS.WTSClientName, str, returned) = True Then
                ClientInfo.WTSClientName = str
            End If

            'Get client IP address
            Dim addr As IntPtr
            If WTSQuerySessionInformation2(ptrOpenedServer.ToInt64, active_session, WTS_INFO_CLASS.WTSClientAddress, addr, returned) = True Then
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
