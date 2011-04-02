
Imports HelloChemistry.temperature

Namespace element
    Public Class clsElement

        Private _index As Integer
        Private _name As String
        Private _symbol As String
        Private _weight As Double
        Private _electron As clsElementElectronShell
        Private _meltingPoint As clsTemperature
        Private _boilingPoint As clsTemperature

        Public ReadOnly Property index As Integer
            Get
                Return _index
            End Get
        End Property

        Public ReadOnly Property name As String
            Get
                Return _name
            End Get
        End Property

        Public ReadOnly Property symbol As String
            Get
                Return _symbol
            End Get
        End Property

        Public ReadOnly Property weight As Double
            Get
                Return _weight
            End Get
        End Property

        Public ReadOnly Property electron As clsElementElectronShell
            Get
                Return _electron
            End Get
        End Property

        Public ReadOnly Property meltingPoint As clsTemperature
            Get
                Return _meltingPoint
            End Get
        End Property

        Public ReadOnly Property boilingPoint As clsTemperature
            Get
                Return _boilingPoint
            End Get
        End Property

        Public Sub New(ByVal index As Integer,
                       ByVal name As String,
                       ByVal symbol As String,
                       ByVal weight As Double,
                       ByVal electron As String,
                       ByVal meltingPoint As Double,
                       ByVal boilingPoint As Double)
            _index = index
            _name = name
            _symbol = symbol
            _weight = weight
            _electron = New clsElementElectronShell(electron)
            _meltingPoint = clsTemperatureManager.instance.createTemperature(meltingPoint)
            _boilingPoint = clsTemperatureManager.instance.createTemperature(boilingPoint)
        End Sub
    End Class
End Namespace