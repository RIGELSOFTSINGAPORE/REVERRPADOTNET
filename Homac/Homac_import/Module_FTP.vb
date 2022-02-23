Module Module_FTP

    Dim intProcID As Integer
    Dim pgm, strcurdir As String

    '********************************************************************
    '**  テキストデータ受信
    '********************************************************************
    Public Function FTP_DL()
        On Error GoTo TAG_Err

        strcurdir = System.IO.Directory.GetCurrentDirectory                                         '実行フォルダー

        '接続開始
        pgm = "C:\Program Files\WinSCP\winscp.exe"
        pgm = pgm & " /console"
        pgm = pgm & " /script=" & strcurdir & "\Homac_ftp.txt"
        intProcID = Shell(pgm, AppWinStyle.NormalFocus)

        Exit Function
TAG_Err:
        If Err.Number = 5 Then
            System.Diagnostics.EventLog.WriteEntry("Homac_inport_Error", "ＦＴＰエラー", System.Diagnostics.EventLogEntryType.Error)
        Else
            System.Diagnostics.EventLog.WriteEntry("Homac_inport_Error", Err.Description, System.Diagnostics.EventLogEntryType.Error)
        End If
    End Function
End Module
