<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class R30_終了予定契約_日付指定
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
        Me.dtR30_3BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.xsdR30_終了予定契約_日付指定 = New ExpirationNotice.xsdR30_終了予定契約_日付指定()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        CType(Me.dtR30_3BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xsdR30_終了予定契約_日付指定, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtR30_3BindingSource
        '
        Me.dtR30_3BindingSource.DataMember = "dtR30_3"
        Me.dtR30_3BindingSource.DataSource = Me.xsdR30_終了予定契約_日付指定
        '
        'xsdR30_終了予定契約_日付指定
        '
        Me.xsdR30_終了予定契約_日付指定.DataSetName = "xsdR30_終了予定契約_日付指定"
        Me.xsdR30_終了予定契約_日付指定.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.dtR30_3BindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "ExpirationNotice.R30_終了予定契約_日付指定.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(1, 2)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(1264, 538)
        Me.ReportViewer1.TabIndex = 0
        '
        'R30_終了予定契約_日付指定
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 545)
        Me.Controls.Add(Me.ReportViewer1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "R30_終了予定契約_日付指定"
        Me.RightToLeftLayout = True
        Me.Text = "R30_終了予定契約_日付指定"
        CType(Me.dtR30_3BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xsdR30_終了予定契約_日付指定, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dtR30_3BindingSource As BindingSource
    Friend WithEvents xsdR30_終了予定契約_日付指定 As xsdR30_終了予定契約_日付指定
End Class
