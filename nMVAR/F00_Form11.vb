Imports System.DirectoryServices
Imports ActiveDs

Public Class F00_Form11
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button99 = New System.Windows.Forms.Button
        Me.msg = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.AutoSize = False
        Me.TextBox1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox1.Location = New System.Drawing.Point(132, 36)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.TextBox1.Size = New System.Drawing.Size(176, 23)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = "TextBox1"
        '
        'TextBox2
        '
        Me.TextBox2.AutoSize = False
        Me.TextBox2.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox2.Location = New System.Drawing.Point(132, 68)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.TextBox2.Size = New System.Drawing.Size(176, 23)
        Me.TextBox2.TabIndex = 1
        Me.TextBox2.Text = "TextBox2"
        '
        'TextBox3
        '
        Me.TextBox3.AutoSize = False
        Me.TextBox3.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox3.Location = New System.Drawing.Point(132, 100)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.TextBox3.Size = New System.Drawing.Size(176, 23)
        Me.TextBox3.TabIndex = 2
        Me.TextBox3.Text = "TextBox3"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(160, 176)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 32)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "決定"
        '
        'Button99
        '
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.Location = New System.Drawing.Point(240, 176)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(68, 32)
        Me.Button99.TabIndex = 4
        Me.Button99.Text = "戻る"
        '
        'msg
        '
        Me.msg.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(20, 144)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(288, 32)
        Me.msg.TabIndex = 1232
        Me.msg.Text = "msg"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(20, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 24)
        Me.Label1.TabIndex = 1233
        Me.Label1.Text = "古いﾊﾟｽﾜｰﾄﾞ"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(20, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 24)
        Me.Label2.TabIndex = 1234
        Me.Label2.Text = "新しいﾊﾟｽﾜｰﾄﾞ"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(20, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 40)
        Me.Label3.TabIndex = 1235
        Me.Label3.Text = "新しいﾊﾟｽﾜｰﾄﾞ確認入力"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'F00_Form11
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(334, 216)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button99)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "F00_Form11"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "パスワード変更"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F00_Form11_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = Nothing
        TextBox2.Text = Nothing
        TextBox3.Text = Nothing
        msg.Text = Nothing
    End Sub

    '********************************************************************
    '** 決定
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim usr As ActiveDs.IADsUser
        Dim szOldPass As String = TextBox1.Text
        Dim szNewPass As String = TextBox2.Text

        On Error GoTo Cleanup

        usr = GetObject("WinNT://qgs.local/" & GetUserName() & ",user")

        usr.ChangePassword(szOldPass, szNewPass)

Cleanup:
        If (Err.Number <> 0) Then
            MsgBox("An error has occurred. " & Err.Number)
        End If
        usr = Nothing


        '        On Error GoTo TAG_Err

        '        Cursor = System.Windows.Forms.Cursors.WaitCursor
        '        msg.Text = Nothing

        '        If TextBox1.Text = Nothing Or TextBox2.Text = Nothing Or TextBox3.Text = Nothing Then
        '            msg.Text = "各項目を正しく入力してください。"
        '            If TextBox3.Text = Nothing Then TextBox3.Focus()
        '            If TextBox2.Text = Nothing Then TextBox2.Focus()
        '            If TextBox1.Text = Nothing Then TextBox1.Focus()
        '            Cursor = System.Windows.Forms.Cursors.Default
        '            Exit Sub
        '        End If

        '        If TextBox2.Text <> TextBox3.Text Then
        '            msg.Text = "新しいパスワードを正しく入力してください。"
        '            Cursor = System.Windows.Forms.Cursors.Default
        '            TextBox3.Focus() : Exit Sub
        '        End If

        '        'Try
        '        Dim ldap As String = "LDAP://153.63.199.108/CN=Users,DC=qgs, DC=local"
        '        Dim authTypes As New AuthenticationTypes
        '        authTypes = AuthenticationTypes.Secure

        '        Dim entry As DirectoryEntry = New DirectoryEntry(ldap, GetUserName(), TextBox1.Text, authTypes)
        '        Dim o As Object = entry.NativeObject

        '        Dim searcher As DirectorySearcher = New DirectorySearcher
        '        searcher.SearchRoot = entry
        '        searcher.Filter = "(SAMAccountName=" + GetUserName() + ")"
        '        Dim searchResult As SearchResult = searcher.FindOne()


        '        If IsDBNull(searchResult) = False Then
        '            msg.Text = GetUserName()
        '            'Dim newEntry As DirectoryEntry = New DirectoryEntry(searchResult.Path, GetUserName(), TextBox1.Text, authTypes)
        '            'newEntry.Invoke("ChangePassword", New Object() {TextBox1.Text, TextBox2.Text})
        '            'newEntry.CommitChanges()
        '            'msg.Text = "パスワードが変更されました。"
        '        End If
        '        'Catch ex As Exception
        '        '    Throw ex
        '        '    msg.Text = "正しく入力されていません。"
        '        'End Try

        '        Cursor = System.Windows.Forms.Cursors.Default
        '        Exit Sub
        'TAG_Err:
        '        Cursor = System.Windows.Forms.Cursors.Default
        '        msg.Text = Err.Description
    End Sub

    Declare Function GetUserName Lib "advapi32.dll" Alias _
       "GetUserNameA" (ByVal lpBuffer As String, _
       ByRef nSize As Integer) As Integer

    Public Function GetUserName() As String
        Dim iReturn As Integer
        Dim userName As String
        userName = New String(CChar(" "), 50)
        iReturn = GetUserName(userName, 50)
        GetUserName = userName.Substring(0, userName.IndexOf(Chr(0)))
    End Function

    '********************************************************************
    '**  戻る
    '********************************************************************
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        Close()
    End Sub

    '********************************************************************
    '**  GotFocus
    '********************************************************************
    Private Sub TextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus
        TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub TextBox2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.GotFocus
        TextBox2.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub TextBox3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.GotFocus
        TextBox3.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub TextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus
        TextBox1.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub TextBox2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.LostFocus
        TextBox2.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub TextBox3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.LostFocus
        TextBox3.BackColor = System.Drawing.SystemColors.Window
    End Sub

End Class
