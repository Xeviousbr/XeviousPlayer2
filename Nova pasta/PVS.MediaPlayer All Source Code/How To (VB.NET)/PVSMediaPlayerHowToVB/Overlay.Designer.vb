<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Overlay
    Inherits System.Windows.Forms.Form

    ''Form overrides dispose to clean up the component list.
    '<System.Diagnostics.DebuggerNonUserCode()> _
    'Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    '    Try
    '        If disposing AndAlso components IsNot Nothing Then
    '            components.Dispose()
    '        End If
    '    Finally
    '        MyBase.Dispose(disposing)
    '    End Try
    'End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.flashLabel = New PVSMediaPlayerHowTo.BlendLabel()
        Me.subtitlesLabel = New PVSMediaPlayerHowTo.BlendLabel()
        Me.SuspendLayout()
        '
        'flashLabel
        '
        Me.flashLabel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flashLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.flashLabel.ForeColor = System.Drawing.Color.Red
        Me.flashLabel.Location = New System.Drawing.Point(-1, 5)
        Me.flashLabel.Name = "flashLabel"
        Me.flashLabel.Size = New System.Drawing.Size(294, 161)
        Me.flashLabel.TabIndex = 2
        Me.flashLabel.Text = "Display Overlay"
        Me.flashLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'subtitlesLabel
        '
        Me.subtitlesLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.subtitlesLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.subtitlesLabel.ForeColor = System.Drawing.Color.Yellow
        Me.subtitlesLabel.Location = New System.Drawing.Point(-4, 127)
        Me.subtitlesLabel.Name = "subtitlesLabel"
        Me.subtitlesLabel.Size = New System.Drawing.Size(302, 34)
        Me.subtitlesLabel.TabIndex = 3
        Me.subtitlesLabel.Text = "Subtitles"
        Me.subtitlesLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.subtitlesLabel.UseMnemonic = False
        '
        'Overlay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(294, 172)
        Me.Controls.Add(Me.subtitlesLabel)
        Me.Controls.Add(Me.flashLabel)
        Me.Name = "Overlay"
        Me.Text = "Display Overlay"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents flashLabel As BlendLabel
    Friend WithEvents subtitlesLabel As BlendLabel
End Class
