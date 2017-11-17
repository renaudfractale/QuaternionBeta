<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Viewer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button_Get_File = New System.Windows.Forms.Button()
        Me.m_TextBox_Path = New System.Windows.Forms.TextBox()
        Me.Button_Load = New System.Windows.Forms.Button()
        Me.m_NumericUpDown_pas = New System.Windows.Forms.NumericUpDown()
        Me.m_NumericUpDown_Size = New System.Windows.Forms.NumericUpDown()
        Me.Button_Cube_iso = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.m_Label_Cube_Iso = New System.Windows.Forms.Label()
        Me.Button_Plot = New System.Windows.Forms.Button()
        CType(Me.m_NumericUpDown_pas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_NumericUpDown_Size, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button_Get_File
        '
        Me.Button_Get_File.Location = New System.Drawing.Point(41, 30)
        Me.Button_Get_File.Name = "Button_Get_File"
        Me.Button_Get_File.Size = New System.Drawing.Size(75, 23)
        Me.Button_Get_File.TabIndex = 0
        Me.Button_Get_File.Text = "Get_File"
        Me.Button_Get_File.UseVisualStyleBackColor = True
        '
        'm_TextBox_Path
        '
        Me.m_TextBox_Path.Location = New System.Drawing.Point(159, 30)
        Me.m_TextBox_Path.Multiline = True
        Me.m_TextBox_Path.Name = "m_TextBox_Path"
        Me.m_TextBox_Path.Size = New System.Drawing.Size(311, 35)
        Me.m_TextBox_Path.TabIndex = 1
        '
        'Button_Load
        '
        Me.Button_Load.Location = New System.Drawing.Point(41, 97)
        Me.Button_Load.Name = "Button_Load"
        Me.Button_Load.Size = New System.Drawing.Size(510, 23)
        Me.Button_Load.TabIndex = 2
        Me.Button_Load.Text = "Load"
        Me.Button_Load.UseVisualStyleBackColor = True
        '
        'm_NumericUpDown_pas
        '
        Me.m_NumericUpDown_pas.Location = New System.Drawing.Point(41, 178)
        Me.m_NumericUpDown_pas.Name = "m_NumericUpDown_pas"
        Me.m_NumericUpDown_pas.Size = New System.Drawing.Size(120, 20)
        Me.m_NumericUpDown_pas.TabIndex = 3
        '
        'm_NumericUpDown_Size
        '
        Me.m_NumericUpDown_Size.Location = New System.Drawing.Point(41, 214)
        Me.m_NumericUpDown_Size.Name = "m_NumericUpDown_Size"
        Me.m_NumericUpDown_Size.Size = New System.Drawing.Size(120, 20)
        Me.m_NumericUpDown_Size.TabIndex = 3
        '
        'Button_Cube_iso
        '
        Me.Button_Cube_iso.Location = New System.Drawing.Point(41, 253)
        Me.Button_Cube_iso.Name = "Button_Cube_iso"
        Me.Button_Cube_iso.Size = New System.Drawing.Size(120, 23)
        Me.Button_Cube_iso.TabIndex = 4
        Me.Button_Cube_iso.Text = "Cube Iso"
        Me.Button_Cube_iso.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(2, 184)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Pas : "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(2, 214)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Sise :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'm_Label_Cube_Iso
        '
        Me.m_Label_Cube_Iso.AutoSize = True
        Me.m_Label_Cube_Iso.Location = New System.Drawing.Point(38, 291)
        Me.m_Label_Cube_Iso.Name = "m_Label_Cube_Iso"
        Me.m_Label_Cube_Iso.Size = New System.Drawing.Size(39, 13)
        Me.m_Label_Cube_Iso.TabIndex = 6
        Me.m_Label_Cube_Iso.Text = "Label3"
        '
        'Button_Plot
        '
        Me.Button_Plot.Location = New System.Drawing.Point(41, 127)
        Me.Button_Plot.Name = "Button_Plot"
        Me.Button_Plot.Size = New System.Drawing.Size(510, 23)
        Me.Button_Plot.TabIndex = 7
        Me.Button_Plot.Text = "Plot"
        Me.Button_Plot.UseVisualStyleBackColor = True
        '
        'Viewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 313)
        Me.Controls.Add(Me.Button_Plot)
        Me.Controls.Add(Me.m_Label_Cube_Iso)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button_Cube_iso)
        Me.Controls.Add(Me.m_NumericUpDown_Size)
        Me.Controls.Add(Me.m_NumericUpDown_pas)
        Me.Controls.Add(Me.Button_Load)
        Me.Controls.Add(Me.m_TextBox_Path)
        Me.Controls.Add(Me.Button_Get_File)
        Me.Name = "Viewer"
        Me.Text = "Viewer"
        CType(Me.m_NumericUpDown_pas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_NumericUpDown_Size, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button_Get_File As Button
    Friend WithEvents m_TextBox_Path As TextBox
    Friend WithEvents Button_Load As Button
    Friend WithEvents m_NumericUpDown_pas As NumericUpDown
    Friend WithEvents m_NumericUpDown_Size As NumericUpDown
    Friend WithEvents Button_Cube_iso As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents m_Label_Cube_Iso As Label
    Friend WithEvents Button_Plot As Button
End Class
