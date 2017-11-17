Imports Kitware.VTK
Public Class Form1
    Public Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        q1.Text = "0,1"
        q2.Text = "0,1"
        q3.Text = "0,1"
        q4.Text = "0,1"

        Nb_iter.Value = 20


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        ''''''Dim MandelbulbV2 = New MandelbulbV2(4, 0.025, 10, 265)
        ''''''MandelbulbV2.Clear()

        ''''''Parallel.For(1, 8, Sub(i)
        ''''''                       MandelbulbV2.Compute_Secteur(i, -0.27)
        ''''''                   End Sub)

        ''''''Plot_ListePoint(MandelbulbV2)

        Dim Tab_Pas As Double() = {1, 0.5, 0.25, 0.125, 0.1, 0.05, 0.025, 0.0125, 0.01, 0.005, 0.0025, 0.00125, 0.001}

        For Each Pas As Double In Tab_Pas

            For PowerX As Integer = 2 To 10

                m_RichTextBox.Text = "PAs =  " + Pas.ToString + " Avec Power = " + PowerX.ToString + Chr(10)
                Dim Power As Integer = PowerX
                Dim L As Double = 4
                Dim Item_Min = 10
                Dim Item_max = 255

                Dim ListX As New List(Of Double)
                For X As Double = -2 To 2 Step Pas
                    ListX.Add(Math.Round(X, 5))
                Next
                Parallel.ForEach(ListX, Sub(Xr)
                                            'For Each Xr In ListX
                                            Dim MandelbulbV2 = New MandelbulbV2(L, Pas, Item_Min, Item_max, Power)
                                            MandelbulbV2.Clear()
                                            For i As Integer = 1 To 8
                                                MandelbulbV2.Compute_Secteur(i, Xr)
                                            Next
                                            MandelbulbV2.Write_On_C()
                                            'Next
                                        End Sub)


            Next
        Next
        ''''''Dim MandelbulbV2 = New MandelbulbV2(4, 0.025, 10, 265)
        ''''''MandelbulbV2.Clear()


    End Sub
    Private Sub Plot_ListePoint(MandelbulbV2 As MandelbulbV2)
        'Create components of the rendering subsystem
        Dim ren1 = New vtkRenderer_rh
        Dim renWin = New vtkRenderWindow_rh
        renWin.AddRenderer(ren1)
        Dim iren = New vtkRenderWindowInteractor
        iren.SetRenderWindow(renWin)


        'Dim a As IntPtr = 1.2

        Dim vtkPolyData As New vtkPolyData
        'Parallel.ForEach(MandelbulbV2.ListPoints, Sub(Point3d)
        '                                              SyncLock vtkPolyData
        '                                                  vtkPolyData.SetPoints(New vtkPoints((Point3d.y, Point3d.z, Point3d.t))

        '                                              End SyncLock
        '                                          End Sub)


        Parallel.ForEach(MandelbulbV2.ListPoints, Sub(Point3d)
                                                      SyncLock ren1
                                                          ren1.AddViewProp(Creaate_Cube(Point3d.y, Point3d.z, Point3d.t,
                          MandelbulbV2.m_Pas, MandelbulbV2.m_Pas, MandelbulbV2.m_Pas,
                          1, 0, 0))
                                                      End SyncLock
                                                  End Sub)



        Dim vtkSTLWriter As New vtkSTLWriter
                                                     vtkSTLWriter.SetFileName("C:\toto.stl")
                                                     ' vtkSTLWriter.SetInputConnection()


                                                     renWin.SetSize(250, 250)
                                                     renWin.Render()
                                                     Dim camera = New vtkCamera
                                                     camera = ren1.GetActiveCamera()
                                                     camera.Zoom(1.5)
                                                     Try
                                                         renWin.Render()
                                                         iren.Initialize()
                                                         iren.Start()

                                                     Catch ex As Exception

                                                     End Try

                                                 End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Create a simple sphere. A pipeline is created.
        'Dim sphere = New vtkSphereSource()
        'sphere.SetThetaResolution(8)
        'sphere.SetPhiResolution(16)

        Dim sphere = New vtkCubeSource
        sphere.SetCenter(1.0, 1.1, 1.9)
        sphere.SetXLength(2)
        sphere.SetYLength(4)
        sphere.SetZLength(8)


        Dim shrink = New vtkShrinkPolyData
        shrink.SetInputConnection(sphere.GetOutputPort)
        shrink.SetShrinkFactor(0.9)

        Dim mapper = New vtkPolyDataMapper_RH()
        mapper.SetInputConnection(shrink.GetOutputPort())

        'The actor links the data pipeline to the rendering subsystem 
        Dim Actor = New vtkActor
        Actor.SetMapper(mapper)
        Actor.GetProperty().SetColor(1, 0, 0)

        'Create components of the rendering subsystem
        Dim ren1 = New vtkRenderer_rh
        Dim renWin = New vtkRenderWindow_rh
        renWin.AddRenderer(ren1)
        Dim iren = New vtkRenderWindowInteractor
        iren.SetRenderWindow(renWin)

        'Add the actors to the renderer, set the window Size         
        ren1.AddViewProp(Actor)
        renWin.SetSize(250, 250)
        renWin.Render()
        Dim camera = New vtkCamera
        camera = ren1.GetActiveCamera()
        camera.Zoom(1.5)

        renWin.Render()
        iren.Initialize()
        iren.Start()




    End Sub




End Class
