<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class R30_終了予定契約
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.dtR30_1終了予定契約BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.xsd_R30_終了予定契約 = New ExpirationNotice.xsd_R30_終了予定契約()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        CType(Me.dtR30_1終了予定契約BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xsd_R30_終了予定契約, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtR30_1終了予定契約BindingSource
        '
        Me.dtR30_1終了予定契約BindingSource.DataMember = "dtR30_1終了予定契約"
        Me.dtR30_1終了予定契約BindingSource.DataSource = Me.xsd_R30_終了予定契約
        '
        'xsd_R30_終了予定契約
        '
        Me.xsd_R30_終了予定契約.DataSetName = "xsd_R30_終了予定契約"
        Me.xsd_R30_終了予定契約.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        ReportDataSource1.Name = "ds_R30_R30_終了予定契約"
        ReportDataSource1.Value = Me.dtR30_1終了予定契約BindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "ExpirationNotice.Report1.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(1, 4)
        Me.ReportViewer1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(1685, 662)
        Me.ReportViewer1.TabIndex = 0
        '
        'R30_終了予定契約
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1685, 671)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "R30_終了予定契約"
        Me.Text = "R30_終了予定契約"
        CType(Me.dtR30_1終了予定契約BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xsd_R30_終了予定契約, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dtR30_1終了予定契約BindingSource As BindingSource
    Friend WithEvents xsd_R30_終了予定契約 As xsd_R30_終了予定契約
End Class
