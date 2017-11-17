Public Class Quaternion
#Region "Constructor"
    Public Sub New(q1 As Double, q2 As Double, q3 As Double, q4 As Double)
        m_q1 = q1
        m_q2 = q2
        m_q3 = q3
        m_q4 = q4
    End Sub
#End Region

#Region "Properties"
    Private m_q1 As Double
    Public Property q1() As Double
        Get
            Return m_q1
        End Get
        Set(ByVal value As Double)
            m_q1 = value
        End Set
    End Property

    Private m_q2 As Double
    Public Property q2() As Double
        Get
            Return m_q2
        End Get
        Set(ByVal value As Double)
            m_q2 = value
        End Set
    End Property

    Private m_q3 As Double
    Public Property q3() As Double
        Get
            Return m_q3
        End Get
        Set(ByVal value As Double)
            m_q3 = value
        End Set
    End Property

    Private m_q4 As Double
    Public Property q4() As Double
        Get
            Return m_q4
        End Get
        Set(ByVal value As Double)
            m_q4 = value
        End Set
    End Property
#End Region
#Region "Operation"
    Public Sub normalise()
        Dim n = Me.length
        Me.q1 /= n
        Me.q2 /= n
        Me.q3 /= n
        Me.q4 /= n
    End Sub

    Public Sub add(s As Double)
        Me.q1 += s
        Me.q2 += s
        Me.q3 += s
        Me.q4 += s
    End Sub

    Public Sub multiplication(a1 As Double, a2 As Double, a3 As Double, a4 As Double)
        Dim b1 = m_q1
        Dim b2 = m_q2
        Dim b3 = m_q3
        Dim b4 = m_q4



        Me.q1 = b1 * a4 + b2 * a3 - b3 * a2 + b4 * a1
        Me.q2 = -b1 * a3 + b2 * a4 + b3 * a1 + b4 * a2
        Me.q3 = b1 * a2 - b2 * a1 + b3 * a4 + b4 * a3
        Me.q4 = -b1 * a1 - b2 * a2 - b3 * a3 + b4 * a4
    End Sub
    Public Sub Power(n As Integer)
        Dim a1 = Me.q1
        Dim a2 = Me.q2
        Dim a3 = Me.q3
        Dim a4 = Me.q4



        For i As Integer = 1 To (n - 1)
            Me.multiplication(a1, a2, a3, a4)
        Next


    End Sub
    Public Sub add(Q As Quaternion)
        Me.q1 += Q.q1
        Me.q2 += Q.q1
        Me.q3 += Q.q1
        Me.q4 += Q.q1
    End Sub
#End Region

#Region "Function"
    Public Function length() As Double
        Return Math.Sqrt(q1 * q1 + q2 * q2 + q3 * q3 + q4 * q4)
    End Function

    Public Function print() As String
        Return "[" + Math.Round(Me.length, 2).ToString + "] i*" +
            Math.Round(q1, 2).ToString + " + j*" +
            Math.Round(q2, 2).ToString + " + k*" +
            Math.Round(q3, 2).ToString + " + " +
            Math.Round(q4, 2).ToString
    End Function

#End Region
End Class
