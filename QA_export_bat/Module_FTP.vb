Module Module_FTP

    'FTP
    Public dl_fldr As String
    Public log_fldr As String

    Dim intProcID As Integer
    Dim pgm, strcurdir As String

    '********************************************************************
    '**  CSV�f�[�^�A�b�v���[�h
    '********************************************************************
    Public Function FTP_up()
        On Error GoTo TAG_Err

        strcurdir = System.IO.Directory.GetCurrentDirectory                                         '���s�t�H���_�[

        'Dim psi As New ProcessStartInfo("WScript.exe")
        'psi.Arguments = strcurdir & "\QA.vbs"
        'Dim job As Process = Process.Start(psi)
        'job.WaitForExit()

        '�ڑ��J�n
        pgm = "C:\Program Files\WinSCP\winscp.exe"
        pgm = pgm & " /console"
        pgm = pgm & " /script=" & strcurdir & "\QA_ftp_up.txt"
        intProcID = Shell(pgm, AppWinStyle.NormalFocus)

        Exit Function
TAG_Err:
        If Err.Number = 5 Then
            System.Diagnostics.EventLog.WriteEntry("QA_export_Error", "�r�e�s�o�G���[", System.Diagnostics.EventLogEntryType.Error)
        Else
            System.Diagnostics.EventLog.WriteEntry("QA_export_Error", Err.Description, System.Diagnostics.EventLogEntryType.Error)
        End If
    End Function
End Module
