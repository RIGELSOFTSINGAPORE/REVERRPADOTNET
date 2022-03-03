
Imports System.IO
Imports System.Text
Imports System.Globalization
Imports Ganges33.Ganges33.model
Imports Ganges33.Ganges33.logic
Imports System.Reflection
Public Class Apple_Reword
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then


            '***セッションなしログインユーザの対応***            Dim userid As String = Session("user_id")
            Dim userid As String = Session("user_id")
            If userid = "" Then
                Response.Redirect("Login.aspx")
            End If

            'Verify Valid User to use this page 
            Dim adminFlg As Boolean = Session("admin_Flg")
            If adminFlg = False Then
                Response.Redirect("Login.aspx")
            End If

            GridViewBind()
        End If

    End Sub
    Private Sub gvReword_PageIndexChanged(sender As Object, e As EventArgs) Handles gvReword.PageIndexChanged

    End Sub



    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        GridViewBind()
    End Sub

    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Response.Redirect("Apple_Reword_Create.aspx")
    End Sub
    Protected Sub gvReword_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Log4NetControl.ComInfoLogWrite(Session("UserName"))
        gvReword.PageIndex = e.NewPageIndex
        GridViewBind()
    End Sub
    Protected Sub GridViewBind(ByVal Optional Location As String = "")
        Dim _AppleRewordModel As AppleRewordModel = New AppleRewordModel()
        Dim _AppleRewordControl As AppleRewordControl = New AppleRewordControl()
        _AppleRewordModel.PART_NO = Trim(txtPartNo.Text)
        _AppleRewordModel.LABOUR_CODE = Trim(txtLabourCode.Text)
        Dim dtAppleQmv As DataTable = _AppleRewordControl.SelectReword(_AppleRewordModel)
        gvReword.DataSource = dtAppleQmv
        gvReword.DataBind()

    End Sub

    Private Sub drpPage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpPage.SelectedIndexChanged
        If drpPage.SelectedItem.Value IsNot "0" Then

            Dim size = drpPage.SelectedItem.Value
            gvReword.PageSize = size
            GridViewBind()
        Else
            gvReword.PageSize = 5
            GridViewBind()
        End If
    End Sub

    'Cannot insert duplicate key row in object 'dbo.AP_REWORD' with unique index 'NonClusteredIndex-20210419-195436'. The duplicate key value is (111, Mac, partno1, LAB3).The statement has been terminated.
End Class