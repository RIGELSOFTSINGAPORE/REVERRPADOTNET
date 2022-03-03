Imports System.Web.UI.WebControls
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Public Class rpa_Logs_1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            '***セッションなしログインユーザの対応***
            Dim userid As String = Session("user_id")
            If userid = "" Then
                Response.Redirect("Login.aspx")
            End If

            txtDateFrom1.Text = DateTime.Now.ToString("yyyy/MM/dd")
            txtDateTo1.Text = DateTime.Now.ToString("yyyy/MM/dd")
            BindGridview(txtDateFrom1.Text, txtDateTo1.Text)
        End If
    End Sub

    Protected Sub BindGridview(strDateFrom As String, strDateTo As String)
        'Dim ds As New DataSet()
        'Using con As New SqlConnection(WebConfigurationManager.ConnectionStrings("cnstr").ToString())
        '    con.Open()
        '    Dim cmd As New SqlCommand("select * from RpaLiveStatus", con)
        '    Dim da As New SqlDataAdapter(cmd)
        '    da.Fill(ds)
        '    con.Close()
        '    gvDetails.DataSource = ds
        '    gvDetails.DataBind()
        'End Using

        Dim _RpaStatusModel As RpaStatusModel = New RpaStatusModel()
        Dim _RpaStatusControl As RpaStatusControl = New RpaStatusControl()
        _RpaStatusModel.DateFrom = strDateFrom
        _RpaStatusModel.DateTo = strDateTo

        Dim dtRpaStatus As DataTable = _RpaStatusControl.SelectRpaStatus(_RpaStatusModel)
        If (dtRpaStatus Is Nothing) Or (dtRpaStatus.Rows.Count = 0) Then
            gvDetails1.DataSource = Nothing
            gvDetails1.DataBind()
            gvDetails1.Visible = False
            lblInfo.Text = "<font color=red>There is no status transaction log found</font>"
        Else

            For Each dr As DataRow In dtRpaStatus.Rows
                If dr("status") = "Started" Then
                    dr("status") = "<font color=green>Processing</font><progress></progress>"
                End If
            Next
            gvDetails1.DataSource = dtRpaStatus
            gvDetails1.DataBind()
            gvDetails1.Visible = True
            lblInfo.Text = ""
        End If


    End Sub
    Protected Sub gvDetails_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        gvDetails1.PageIndex = e.NewPageIndex
        BindGridview(txtDateFrom1.Text, txtDateTo1.Text)
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        lblInfo.Text = ""
        If (Not (String.IsNullOrEmpty(txtDateFrom1.Text.Trim)) And (Not (String.IsNullOrEmpty(txtDateTo1.Text.Trim)))) Then
            BindGridview(txtDateFrom1.Text.Trim, txtDateTo1.Text)
        End If
        'Dim dtRpaStatus As DataTable = _RpaStatusControl.SelectRpaStatus(_RpaStatusModel)
        'If (dtRpaStatus Is Nothing) Or (dtRpaStatus.Rows.Count = 0) Then
        '    gvDetails.DataSource = Nothing
        '    gvDetails.DataBind()
        '    gvDetails.Visible = False
        '    lblInfo.Text = "<font color=red>There is no status transaction log found</font>"
        'Else
        '    gvDetails.DataSource = dtRpaStatus
        '    gvDetails.DataBind()
        '    gvDetails.Visible = True
        '    lblInfo.Text = ""
        'End If
    End Sub

End Class