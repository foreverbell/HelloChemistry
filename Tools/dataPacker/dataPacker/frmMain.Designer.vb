<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.textFilePath = New System.Windows.Forms.TextBox()
        Me.btnOpenFile = New System.Windows.Forms.Button()
        Me.btnPack = New System.Windows.Forms.Button()
        Me.textOutFilePath = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "File Path:"
        '
        'textFilePath
        '
        Me.textFilePath.Location = New System.Drawing.Point(83, 6)
        Me.textFilePath.Name = "textFilePath"
        Me.textFilePath.Size = New System.Drawing.Size(349, 21)
        Me.textFilePath.TabIndex = 1
        '
        'btnOpenFile
        '
        Me.btnOpenFile.Location = New System.Drawing.Point(438, 7)
        Me.btnOpenFile.Name = "btnOpenFile"
        Me.btnOpenFile.Size = New System.Drawing.Size(26, 20)
        Me.btnOpenFile.TabIndex = 2
        Me.btnOpenFile.Text = ".."
        Me.btnOpenFile.UseVisualStyleBackColor = True
        '
        'btnPack
        '
        Me.btnPack.Location = New System.Drawing.Point(397, 60)
        Me.btnPack.Name = "btnPack"
        Me.btnPack.Size = New System.Drawing.Size(66, 23)
        Me.btnPack.TabIndex = 3
        Me.btnPack.Text = "Pack"
        Me.btnPack.UseVisualStyleBackColor = True
        '
        'textOutFilePath
        '
        Me.textOutFilePath.Location = New System.Drawing.Point(83, 33)
        Me.textOutFilePath.Name = "textOutFilePath"
        Me.textOutFilePath.Size = New System.Drawing.Size(381, 21)
        Me.textOutFilePath.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 12)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Out Path:"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(475, 88)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.textOutFilePath)
        Me.Controls.Add(Me.btnPack)
        Me.Controls.Add(Me.btnOpenFile)
        Me.Controls.Add(Me.textFilePath)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HelloChemistry Data Packer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents textFilePath As System.Windows.Forms.TextBox
    Friend WithEvents btnOpenFile As System.Windows.Forms.Button
    Friend WithEvents btnPack As System.Windows.Forms.Button
    Friend WithEvents textOutFilePath As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
