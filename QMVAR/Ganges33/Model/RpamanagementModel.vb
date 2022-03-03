Imports System
Imports System.Collections.Generic
Imports System.Configuration
Namespace Ganges33.model
    Public Class RpamanagementModel
        Public Sub RpamanagementModel()
            TASKID = String.Empty
            CRTDT = String.Empty
            CRTCD = String.Empty
            UPDDT = String.Empty
            UPDCD = String.Empty
            UPDPG = String.Empty
            DELFG = String.Empty
            TASK_NAME = String.Empty
            FILE_NAME = String.Empty
            PATH = String.Empty
            TEST_STATUS = String.Empty
            STATUS = String.Empty
            RUN_DURATION = String.Empty
            IP_ADDRESS = String.Empty

        End Sub
        Public Property TASKID As Int32
        Public Property CRTDT As String
        Public Property CRTCD As String
        Public Property UPDDT As String
        Public Property UPDCD As String
        Public Property UPDPG As String
        Public Property DELFG As String
        Public Property TASK_NAME As String
        Public Property FILE_NAME As String
        Public Property PATH As String
        Public Property TEST_STATUS As String
        Public Property STATUS As String
        Public Property RUN_DURATION As String
        Public Property IP_ADDRESS As String

    End Class
End Namespace
