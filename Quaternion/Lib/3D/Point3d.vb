Public Class Point3d
#Region "Constructor"
    Public Sub New()
        m_x = 0
        m_y = 0
        m_z = 0
        m_t = 0
        m_Iter = 0
    End Sub
    Public Sub New(x As Double, y As Double, z As Double, t As Double, iter As Integer)
        m_x = x
        m_y = y
        m_z = z
        m_t = t
        m_iter = iter
    End Sub
#End Region
#Region "Propertie"
    Private m_x As Double
    Public Property x() As Double
        Get
            Return m_x
        End Get
        Set(ByVal value As Double)
            m_x = value
        End Set
    End Property

    Private m_y As Double
    Public Property y() As Double
        Get
            Return m_y
        End Get
        Set(ByVal value As Double)
            m_y = value
        End Set
    End Property

    Private m_z As Double
    Public Property z() As Double
        Get
            Return m_z
        End Get
        Set(ByVal value As Double)
            m_z = value
        End Set
    End Property

    Private m_t As Double
    Public Property t() As Double
        Get
            Return m_t
        End Get
        Set(ByVal value As Double)
            m_t = value
        End Set
    End Property

    Private m_iter As Double
    Public Property iter() As Double
        Get
            Return m_iter
        End Get
        Set(ByVal value As Double)
            m_iter = value
        End Set
    End Property

#End Region
#Region "Fonction"
    Public Function print() As String
        Return (y.ToString + ";" + z.ToString + ";" + t.ToString).Replace(",", ".")
    End Function

    Public Function print_All() As String
        Return (x.ToString + ";" + y.ToString + ";" + z.ToString + ";" + t.ToString + ";" + iter.ToString).Replace(",", ".")
    End Function
#End Region

End Class
