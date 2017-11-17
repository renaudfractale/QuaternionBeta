Imports Kitware.VTK

Module Module_VTK
    Public Function Creaate_Cube(x As Double, y As Double, z As Double, Lx As Double, Ly As Double, Lz As Double, r As Double, g As Double, b As Double) As vtkActor
        Dim sphere2 = New vtkCubeSource
        sphere2.SetCenter(x, y, z)
        sphere2.SetXLength(Lx)
        sphere2.SetYLength(Ly)
        sphere2.SetZLength(Lz)

        Dim shrink2 = New vtkShrinkPolyData
        shrink2.SetInputConnection(sphere2.GetOutputPort)
        shrink2.SetShrinkFactor(1)

        Dim mapper2 = New vtkPolyDataMapper_RH()
        mapper2.SetInputConnection(shrink2.GetOutputPort)


        'The actor links the data pipeline to the rendering subsystem 
        Dim Actor2 = New vtkActor
        Actor2.SetMapper(mapper2)
        Actor2.GetProperty().SetColor(r, g, b)
        Return Actor2
    End Function

    Public Sub Cube_Iso(Pas As Double, Size As Double)
        'Create components of the rendering subsystem
        Dim ren1 = New vtkRenderer_rh
        Dim renWin = New vtkRenderWindow_rh
        renWin.AddRenderer(ren1)
        Dim iren = New vtkRenderWindowInteractor
        iren.SetRenderWindow(renWin)

        Dim NbCube As Integer = 0

        Dim C As Double = Pas
        Dim Lmin As Double = -Size / 2
        Dim Lmax As Double = Size / 2
        Dim L As Double = Lmax - Lmin

        Dim LsiteX As New List(Of Double)
        For x As Double = Lmin To Lmax + C Step C
            LsiteX.Add(x)
        Next
        Parallel.ForEach(LsiteX, Sub(x As Double)
                                     For y As Double = Lmin To Lmax + C Step C
                                         For z As Double = Lmin To Lmax + C Step C
                                             If Math.Abs(x) >= Lmax Or Math.Abs(y) >= Lmax Or Math.Abs(z) >= Lmax Then

                                                 Dim r As Double = (x - Lmin) / L
                                                 Dim g As Double = (y - Lmin) / L
                                                 Dim b As Double = (z - Lmin) / L
                                                 SyncLock ren1
                                                     ren1.AddViewProp(Creaate_Cube(x, y, z, C, C, C, r, g, b))
                                                 End SyncLock
                                             End If
                                         Next
                                     Next
                                 End Sub)








        'Add the actors to the renderer, set the window Size        
        renWin.SetSize(250, 250)
        renWin.Render()
        Dim camera = New vtkCamera
        camera = ren1.GetActiveCamera()
        camera.Zoom(1.5)

        renWin.Render()
        iren.Initialize()
        iren.Start()

    End Sub


    Public Sub Plot_Point3ds(Liste3d As List(Of Point3d), C As Double)
        'Create components of the rendering subsystem

        Dim ren1 = New vtkRenderer_rh
        Dim renWin = New vtkRenderWindow_rh
        renWin.AddRenderer(ren1)
        Dim iren = New vtkRenderWindowInteractor
        iren.SetRenderWindow(renWin)

        Parallel.ForEach(Liste3d, Sub(Point3d As Point3d)
                                      Dim r As Double = 1
                                      Dim g As Double = 0.5
                                      Dim b As Double = 0.25
                                      SyncLock ren1
                                          ren1.AddViewProp(Creaate_Cube(Point3d.y, Point3d.z, Point3d.t, C, C, C, r, g, b))
                                      End SyncLock
                                  End Sub)

        'Add the actors to the renderer, set the window Size        
        renWin.SetSize(250, 250)
        renWin.Render()
        Dim camera = New vtkCamera
        camera = ren1.GetActiveCamera()
        camera.Zoom(1.5)

        renWin.Render()
        iren.Initialize()
        iren.Start()
    End Sub
End Module
