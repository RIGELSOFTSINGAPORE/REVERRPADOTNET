Module Module_Start
    Sub Main(ByVal CmdArgs() As String)
        Dim CountArg As Integer = Cmdargs.Length
        For Each arg As String In CmdArgs
            P_EMPL_BRCH = arg
        Next

        Dim Menu20 As New Menu20
        Menu20.ShowDialog()
    End Sub
End Module
