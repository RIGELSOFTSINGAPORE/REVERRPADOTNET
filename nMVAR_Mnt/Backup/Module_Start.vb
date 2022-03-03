Module Module_Start
    Sub Main(ByVal CmdArgs() As String)
        Dim CountArg As Integer = Cmdargs.Length
        For Each arg As String In CmdArgs
            P_EMPL_BRCH = arg
        Next

        Dim F10_Form21 As New F10_Form21
        F10_Form21.ShowDialog()
    End Sub
End Module
