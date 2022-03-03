Module Module_Start
    Sub Main(ByVal CmdArgs() As String)
        Dim CountArg As Integer = Cmdargs.Length
        For Each arg As String In CmdArgs
            P_EMPL_BRCH = arg
        Next

        Dim Menu30 As New Menu30
        Menu30.ShowDialog()
    End Sub
End Module
