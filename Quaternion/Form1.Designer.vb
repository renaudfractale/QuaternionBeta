<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.m_RichTextBox = New System.Windows.Forms.RichTextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Nb_iter = New System.Windows.Forms.NumericUpDown()
        Me.q1 = New System.Windows.Forms.TextBox()
        Me.q2 = New System.Windows.Forms.TextBox()
        Me.q3 = New System.Windows.Forms.TextBox()
        Me.q4 = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        CType(Me.Nb_iter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'm_RichTextBox
        '
        Me.m_RichTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.m_RichTextBox.Location = New System.Drawing.Point(13, 13)
        Me.m_RichTextBox.Name = "m_RichTextBox"
        Me.m_RichTextBox.Size = New System.Drawing.Size(612, 236)
        Me.m_RichTextBox.TabIndex = 0
        Me.m_RichTextBox.Text = ""
        '
        'Button1
        '
        Me.Button1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(631, 128)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 22)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Nb_iter
        '
        Me.Nb_iter.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Nb_iter.Location = New System.Drawing.Point(631, 223)
        Me.Nb_iter.Name = "Nb_iter"
        Me.Nb_iter.Size = New System.Drawing.Size(120, 20)
        Me.Nb_iter.TabIndex = 2
        '
        'q1
        '
        Me.q1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.q1.Location = New System.Drawing.Point(651, 12)
        Me.q1.Name = "q1"
        Me.q1.Size = New System.Drawing.Size(100, 20)
        Me.q1.TabIndex = 3
        '
        'q2
        '
        Me.q2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.q2.Location = New System.Drawing.Point(651, 38)
        Me.q2.Name = "q2"
        Me.q2.Size = New System.Drawing.Size(100, 20)
        Me.q2.TabIndex = 3
        '
        'q3
        '
        Me.q3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.q3.Location = New System.Drawing.Point(651, 64)
        Me.q3.Name = "q3"
        Me.q3.Size = New System.Drawing.Size(100, 20)
        Me.q3.TabIndex = 3
        '
        'q4
        '
        Me.q4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.q4.Location = New System.Drawing.Point(651, 90)
        Me.q4.Name = "q4"
        Me.q4.Size = New System.Drawing.Size(100, 20)
        Me.q4.TabIndex = 3
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(712, 127)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(631, 156)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(712, 156)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 6
        Me.Button4.Text = "Button4"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(789, 261)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.q4)
        Me.Controls.Add(Me.q3)
        Me.Controls.Add(Me.q2)
        Me.Controls.Add(Me.q1)
        Me.Controls.Add(Me.Nb_iter)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.m_RichTextBox)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.Nb_iter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents m_RichTextBox As RichTextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Nb_iter As NumericUpDown
    Friend WithEvents q1 As TextBox
    Friend WithEvents q2 As TextBox
    Friend WithEvents q3 As TextBox
    Friend WithEvents q4 As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
End Class
