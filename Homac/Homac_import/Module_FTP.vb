Module Module_FTP

    Dim intProcID As Integer
    Dim pgm, strcurdir As String

    '********************************************************************
    '**  �e�L�X�g�f�[�^��M
    '********************************************************************
    Public Function FTP_DL()
        On Error GoTo TAG_Err

        strcurdir = System.IO.Directory.GetCurrentDirectory                                         '���s�t�H���_�[

        '�ڑ��J�n
        pgm = "C:\Program Files\WinSCP\winscp.exe"
        pgm = pgm & " /console"
        pgm = pgm & " /script=" & strcurdir & "\Homac_ftp.txt"
        intProcID = Shell(pgm, AppWinStyle.NormalFocus)

        Exit Function
TAG_Err:
        If Err.Number = 5 Then
            System.Diagnostics.EventLog.WriteEntry("Homac_inport_Error", "�e�s�o�G���[", System.Diagnostics.EventLogEntryType.Error)
        Else
            System.Diagnostics.EventLog.WriteEntry("Homac_inport_Error", Err.Description, System.Diagnostics.EventLogEntryType.Error)
        End If
    End Function
End Module
