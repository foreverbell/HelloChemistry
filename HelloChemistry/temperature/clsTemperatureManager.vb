

Imports HelloChemistry.general

Namespace temperature
    Public Class clsTemperatureManager
        Inherits Subject

#Region "Sington Pattern"
        Private Shared ReadOnly _instance As New clsTemperatureManager

        Public Shared ReadOnly Property instance As clsTemperatureManager
            Get
                Return _instance
            End Get
        End Property

        Private Sub New()
        End Sub
#End Region

        ' Optional temperature expression mode: Kelvins
        Private _expressionMode As enumTemperatureExpressionMode = enumTemperatureExpressionMode.K

        Public Property expressionMode As enumTemperatureExpressionMode
            Get
                Return _expressionMode
            End Get
            Set(ByVal value As enumTemperatureExpressionMode)
                _expressionMode = value
                notify()
            End Set
        End Property

        Public Function KtoC(ByVal K As Double) As Double
            Return K - 273.15
        End Function

        Public Function KtoF(ByVal K As Double) As Double
            Return 1.8 * (K - 273.15) + 32
        End Function

        Public Function createTemperature(ByVal temperatureK As Double) As clsTemperature
            Dim result As clsTemperature

            If (temperatureK = 0) Then
                result = New clsNullTemperature
            Else
                result = New clsTemperature(temperatureK)
            End If

            attach(result)

            Return result
        End Function
    End Class
End Namespace