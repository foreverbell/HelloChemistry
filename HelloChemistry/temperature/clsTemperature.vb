
Imports HelloChemistry.general

Namespace temperature
    Public Class clsTemperature
        Inherits Observer
        Implements INullable
        Implements IDisposable


        Private _temperatureK As Double
        ' Optional temperature expression mode: Kelvins
        Private _expressionMode As enumTemperatureExpressionMode = enumTemperatureExpressionMode.K

        Public ReadOnly Property K As Double
            Get
                Return _temperatureK
            End Get
        End Property

        Public ReadOnly Property C As Double
            Get
                Return clsTemperatureManager.instance.KtoC(_temperatureK)
            End Get
        End Property

        Public ReadOnly Property F As Double
            Get
                Return clsTemperatureManager.instance.KtoF(_temperatureK)
            End Get
        End Property

        Public Property expressionMode() As enumTemperatureExpressionMode
            Get
                Return _expressionMode
            End Get
            Set(ByVal value As enumTemperatureExpressionMode)
                _expressionMode = value
            End Set
        End Property

        Public Overridable ReadOnly Property temperatureExpression As String
            Get
                Select Case expressionMode
                    Case enumTemperatureExpressionMode.K
                        Return K.ToString & " K"
                    Case enumTemperatureExpressionMode.F
                        Return F.ToString & " °F"
                    Case enumTemperatureExpressionMode.C
                        Return C.ToString & " °C"
                    Case Else
                        Throw New ArgumentException
                End Select
            End Get
        End Property

        Public Overrides Sub update(ByVal hostSubject As Subject)
            _expressionMode = CType(hostSubject, clsTemperatureManager).expressionMode
        End Sub

        Public Overridable Function isNull() As Boolean Implements general.INullable.isNull
            Return False
        End Function

        Public Sub New(ByVal temperatureK As Double)
            _temperatureK = temperatureK
        End Sub

#Region "IDisposable Support"
        Private disposedValue As Boolean

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                clsTemperatureManager.instance.detach(Me)
            End If
            Me.disposedValue = True
        End Sub

        Protected Overrides Sub Finalize()
            Dispose(False)
            MyBase.Finalize()
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class
End Namespace