
Public Class DataGridEx
    Inherits System.Windows.Forms.DataGrid

#Region " Windows フォーム デザイナで生成されたコード "

    Public Sub New()
        MyBase.New()

        ' この呼び出しは Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。

    End Sub

    'UserControl はコンポーネント一覧を消去するために dispose をオーバーライドします。
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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
    End Sub

#End Region

    Public Event CmdKeyEvent(ByVal keyData As System.Windows.Forms.Keys, ByRef Cancel As Boolean)

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Dim blnCancel As Boolean
        Select Case keyData
            Case Keys.Return, Keys.Tab
                RaiseEvent CmdKeyEvent(keyData, blnCancel)
                If blnCancel Then
                    Return True
                End If
            Case Keys.Space, Keys.Tab
                RaiseEvent CmdKeyEvent(keyData, blnCancel)
                If blnCancel Then
                    Return True
                End If
            Case Keys.Delete, Keys.Tab
                RaiseEvent CmdKeyEvent(keyData, blnCancel)
                If blnCancel Then
                    Return True
                End If
            Case Keys.Right, Keys.Tab
                RaiseEvent CmdKeyEvent(keyData, blnCancel)
                If blnCancel Then
                    Return True
                End If
            Case Keys.Left, Keys.Tab
                RaiseEvent CmdKeyEvent(keyData, blnCancel)
                If blnCancel Then
                    Return True
                End If
        End Select
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

End Class
