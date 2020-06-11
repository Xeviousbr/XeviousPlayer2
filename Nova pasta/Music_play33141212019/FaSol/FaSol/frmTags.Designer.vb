<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTags
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txgenre = New System.Windows.Forms.TextBox()
        Me.txyear = New System.Windows.Forms.TextBox()
        Me.txpublisher = New System.Windows.Forms.TextBox()
        Me.txcomposer = New System.Windows.Forms.TextBox()
        Me.txalbum = New System.Windows.Forms.TextBox()
        Me.txartist = New System.Windows.Forms.TextBox()
        Me.txname = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txgenre
        '
        Me.txgenre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txgenre.Location = New System.Drawing.Point(107, 299)
        Me.txgenre.Name = "txgenre"
        Me.txgenre.Size = New System.Drawing.Size(387, 20)
        Me.txgenre.TabIndex = 77
        '
        'txyear
        '
        Me.txyear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txyear.Location = New System.Drawing.Point(107, 255)
        Me.txyear.Name = "txyear"
        Me.txyear.Size = New System.Drawing.Size(387, 20)
        Me.txyear.TabIndex = 76
        '
        'txpublisher
        '
        Me.txpublisher.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txpublisher.Location = New System.Drawing.Point(107, 211)
        Me.txpublisher.Name = "txpublisher"
        Me.txpublisher.Size = New System.Drawing.Size(387, 20)
        Me.txpublisher.TabIndex = 75
        '
        'txcomposer
        '
        Me.txcomposer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txcomposer.Location = New System.Drawing.Point(107, 167)
        Me.txcomposer.Name = "txcomposer"
        Me.txcomposer.Size = New System.Drawing.Size(387, 20)
        Me.txcomposer.TabIndex = 74
        '
        'txalbum
        '
        Me.txalbum.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txalbum.Location = New System.Drawing.Point(107, 123)
        Me.txalbum.Name = "txalbum"
        Me.txalbum.Size = New System.Drawing.Size(387, 20)
        Me.txalbum.TabIndex = 72
        '
        'txartist
        '
        Me.txartist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txartist.Location = New System.Drawing.Point(107, 79)
        Me.txartist.Name = "txartist"
        Me.txartist.Size = New System.Drawing.Size(387, 20)
        Me.txartist.TabIndex = 73
        '
        'txname
        '
        Me.txname.BackColor = System.Drawing.SystemColors.Window
        Me.txname.Enabled = False
        Me.txname.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txname.Location = New System.Drawing.Point(107, 35)
        Me.txname.Name = "txname"
        Me.txname.ReadOnly = True
        Me.txname.Size = New System.Drawing.Size(387, 20)
        Me.txname.TabIndex = 71
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label9.Location = New System.Drawing.Point(73, 258)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(28, 13)
        Me.Label9.TabIndex = 69
        Me.Label9.Text = "Any:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label7.Location = New System.Drawing.Point(64, 214)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 68
        Me.Label7.Text = "Editor:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label6.Location = New System.Drawing.Point(39, 170)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 67
        Me.Label6.Text = "Compositor:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label4.Location = New System.Drawing.Point(62, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 66
        Me.Label4.Text = "Artista:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label3.Location = New System.Drawing.Point(59, 126)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 65
        Me.Label3.Text = "Album :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label5.Location = New System.Drawing.Point(69, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 64
        Me.Label5.Text = "Nom:"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(297, 336)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(87, 29)
        Me.Button3.TabIndex = 80
        Me.Button3.Text = "Acceptar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(56, 302)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 81
        Me.Label1.Text = "Gènere:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(407, 336)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 29)
        Me.Button1.TabIndex = 82
        Me.Button1.Text = "Cancel·lar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmTags
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(537, 396)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.txgenre)
        Me.Controls.Add(Me.txyear)
        Me.Controls.Add(Me.txpublisher)
        Me.Controls.Add(Me.txcomposer)
        Me.Controls.Add(Me.txalbum)
        Me.Controls.Add(Me.txartist)
        Me.Controls.Add(Me.txname)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Name = "frmTags"
        Me.ShowInTaskbar = False
        Me.Text = "frmTags"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txgenre As System.Windows.Forms.TextBox
    Friend WithEvents txyear As System.Windows.Forms.TextBox
    Friend WithEvents txpublisher As System.Windows.Forms.TextBox
    Friend WithEvents txcomposer As System.Windows.Forms.TextBox
    Friend WithEvents txalbum As System.Windows.Forms.TextBox
    Friend WithEvents txartist As System.Windows.Forms.TextBox
    Friend WithEvents txname As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
