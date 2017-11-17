Imports System.IO

Public Class Viewer
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_TextBox_Path.ReadOnly = True
        Button_Load.Enabled = False
        Liste_Pt3d = New List(Of Point3d)
        m_NumericUpDown_pas.Minimum = CDec(4)
        m_NumericUpDown_pas.Maximum = CDec(10000)
        m_NumericUpDown_pas.Value = CDec(50)

        m_NumericUpDown_Size.Minimum = CDec(2)
        m_NumericUpDown_Size.Maximum = CDec(8)
        m_NumericUpDown_Size.Value = CDec(4)

    End Sub
    Private Liste_Pt3d As List(Of Point3d)
    Private Sub Button_Get_File_Click(sender As Object, e As EventArgs) Handles Button_Get_File.Click
        Using MyOpenFileDialog As New OpenFileDialog
            MyOpenFileDialog.Filter = " files (*.CSV)" + "| *.CSV"
            MyOpenFileDialog.Title = "Open File CSV"
            MyOpenFileDialog.ShowDialog()
            If MyOpenFileDialog.FileNames.Length > 0 Then
                m_TextBox_Path.ReadOnly = False
                m_TextBox_Path.Text = MyOpenFileDialog.FileName
                m_TextBox_Path.ReadOnly = True

                Button_Load.Enabled = True
            End If
        End Using
    End Sub

    Private Sub Button_Load_Click(sender As Object, e As EventArgs) Handles Button_Load.Click
        If m_TextBox_Path.Text <> "" Then
            Liste_Pt3d.Clear()

            Using sr As StreamReader = File.OpenText(m_TextBox_Path.Text)
                Do While sr.Peek() >= 0
                    Dim txt = sr.ReadLine().Replace(".", ",").Replace(Chr(10), "")
                    Dim Tab = txt.Split(";"c)
                    Dim Pt As New Point3d()
                    Pt.x = CType(Tab(0), Double)
                    Pt.y = CType(Tab(1), Double)
                    Pt.z = CType(Tab(2), Double)
                    Pt.t = CType(Tab(3), Double)
                    Pt.iter = CType(Tab(4), Double)

                    Liste_Pt3d.Add(Pt)
                Loop
            End Using
        End If
    End Sub
    Private Sub Compute_SiezCube()
        If m_NumericUpDown_pas.Value <> 0 And m_NumericUpDown_Size.Value <> 0 Then
            Dim NbPas As Double = CDbl(m_NumericUpDown_pas.Value)
            Dim NbCube = Math.Pow(NbPas, 3) / 1000

            m_Label_Cube_Iso.Text = NbCube.ToString + " K Cube"
        End If
    End Sub
    Private Sub m_NumericUpDown_pas_ValueChanged(sender As Object, e As EventArgs) Handles m_NumericUpDown_pas.ValueChanged
        Compute_SiezCube()
    End Sub

    Private Sub m_NumericUpDown_Size_ValueChanged(sender As Object, e As EventArgs) Handles m_NumericUpDown_Size.ValueChanged
        Compute_SiezCube()
    End Sub

    Private Sub Button_Cube_iso_Click(sender As Object, e As EventArgs) Handles Button_Cube_iso.Click
        Dim PAs As Double = CDbl(m_NumericUpDown_Size.Value / m_NumericUpDown_pas.Value)

        Cube_Iso(PAs, CDbl(m_NumericUpDown_Size.Value))

    End Sub

    Private Sub Button_Plot_Click(sender As Object, e As EventArgs) Handles Button_Plot.Click
        Plot_Point3ds(Liste_Pt3d, 0.0125)
    End Sub
End Class