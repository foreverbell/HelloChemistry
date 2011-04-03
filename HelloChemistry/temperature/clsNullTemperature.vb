
Namespace temperature
    Public Class clsNullTemperature
        Inherits clsTemperature

        Public Overrides Function isNull() As Boolean
            Return True
        End Function

        Public Overrides ReadOnly Property temperatureExpression As String
            Get
                Return "N/A"
            End Get
        End Property

        Public Sub New()
            MyBase.New(0)
        End Sub
    End Class
End Namespace
