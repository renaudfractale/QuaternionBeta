Imports System.IO
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks


Public Class MandelbulbV2
#Region "Constructor"
    Public Sub New(L As Double, Pas As Double,
                   Itermin As Integer, Itermax As Integer,
                   Power As Integer)
        m_L = L
        m_Pas = Pas

        m_Itermin = Itermin
        m_Itermax = Itermax

        m_Power = Power

        ListPoints = New List(Of Point3d)
        Round = 8
    End Sub
#End Region
#Region "Properties"
    Friend ListPoints As List(Of Point3d)
    Friend Round As Integer

    Private m_L As Double
    Friend m_Pas As Double

    Private m_Itermin As Integer
    Private m_Itermax As Integer

    Private m_Power As Integer


#End Region
#Region "Procedure"
    Public Sub Clear()
        ListPoints.Clear()
    End Sub

    Public Sub Compute_Secteur(I As Integer, X As Double)
        Dim Tmin As Integer
        Dim Tmax As Integer
        Dim Ymin As Integer
        Dim Ymax As Integer
        Dim Zmin As Integer
        Dim Zmax As Integer

        Dim L = CInt(m_L / m_Pas)

        If I >= 5 Then
            Tmin = 0
            Tmax = L
        Else
            Tmin = -L
            Tmax = 0
        End If

        If I <= 2 Or I >= 7 Then
            Ymin = 0
            Ymax = L
        Else
            Ymin = -L
            Ymax = 0
        End If

        If I Mod 2 = 1 Then
            Zmin = 0
            Zmax = L
        Else
            Zmin = -L
            Zmax = 0
        End If
        Parallel.For(Tmin, Tmax, Sub(Tr)
                                     'For Tr As Integer = Tmin To Tmax
                                     Dim t As Double = Math.Round(CDbl(Tr) * m_Pas, Round)

                                     For Yr As Integer = Ymin To Ymax
                                         Dim y As Double = Math.Round(CDbl(Yr) * m_Pas, Round)

                                         For Zr As Integer = Zmin To Zmax
                                             Dim z As Double = Math.Round(CDbl(Zr) * m_Pas, Round)

                                             Dim iter = ComputeIter(X, y, z, t)

                                             If iter <> 0 Then

                                                 If Filtre(X, y, z, t) Then
                                                     SyncLock ListPoints
                                                         Try
                                                             ListPoints.Add(New Point3d(X, y, z, t, iter))
                                                         Catch ex As Exception
                                                             Write_On_C()
                                                             ListPoints.Clear()
                                                             ListPoints.Add(New Point3d(X, y, z, t, iter))
                                                         End Try

                                                     End SyncLock
                                                 End If
                                             End If
                                         Next
                                     Next
                                     'Next
                                 End Sub)
    End Sub
    Private Function Write(ms As MemoryStream, i As Integer, x As Double) As Integer
        ms.Position = 0

        Dim Xr As Double = Math.Round(x, 6)


        Dim file0 As New FileStream("d:\test_" + Xr.ToString + "_" + i.ToString + ".CSV", FileMode.Create, FileAccess.Write)
        ms.WriteTo(file0)
        file0.Close()

        i += 1
        Return i
    End Function

    Public Sub Write_On_C()
        If ListPoints.Count > 0 Then
            Dim Xr As Double = ListPoints.Item(0).x

            Dim Dir = "c:\Quaterion\P" + m_Pas.ToString + "_" + m_Power.ToString
            If Not Directory.Exists(Dir) Then
                Directory.CreateDirectory(Dir)
            End If

            Dim Path_File As String = Dir + "\test_" + Xr.ToString + ".CSV"
            Dim i As Integer = 0

            While File.Exists(Path_File)
                i += 1
                Path_File = Dir + "\test_" + Xr.ToString + "_" + i.ToString + ".CSV"
            End While
            Using outputFile As New StreamWriter(Path_File)
                For Each Point3d In ListPoints
                    outputFile.WriteLine(Point3d.print_All)
                Next
            End Using
        End If
    End Sub
    Public Function Filtre(x As Double, y As Double, z As Double, t As Double) As Boolean
        Dim Nb_pas As Integer = 1


        Dim TrMin As Double = Math.Round(t - Nb_pas * m_Pas, Round)
        Dim TrMax As Double = Math.Round(t + Nb_pas * m_Pas, Round)

        Dim YrMin As Double = Math.Round(y - Nb_pas * m_Pas, Round)
        Dim YrMax As Double = Math.Round(y + Nb_pas * m_Pas, Round)

        Dim ZrMin As Double = Math.Round(z - Nb_pas * m_Pas, Round)
        Dim ZrMax As Double = Math.Round(z + Nb_pas * m_Pas, Round)

        'If t = y And t = z And x = t And t = 0 And m_Pas <= 0.125 Then Stop

        For Tr As Double = TrMin To TrMax Step m_Pas
            For Yr As Double = YrMin To YrMax Step m_Pas
                For Zr As Double = ZrMin To ZrMax Step m_Pas
                    If ComputeIter(x, Yr, Zr, Tr) = 0 Then
                        Return True
                    End If
                Next
            Next
        Next
        Return False

    End Function


#End Region
#Region "Fonction"
    Friend Function ComputeIter(x As Double, y As Double, z As Double, t As Double) As Integer
        Dim nb_iter As Integer = 0
        Dim q As New Quaternion(x, y, z, t)
        'Dim q2 As New Quaternion(0.5, 0.75, -0.5, -0.75)
        Dim q2 As New Quaternion(q.q1, q.q2, q.q3, q.q4)
        Do
            q.Power(m_Power)
            q.add(q2)
            nb_iter += 1

            If nb_iter >= m_Itermax Then Exit Do
        Loop Until q.length > 4

        If nb_iter >= m_Itermin Then Return nb_iter
        Return 0
    End Function
#End Region
End Class
