
Namespace element
    Public Class clsElement

        Private _index As Integer
        Private _name As String
        Private _symbol As String
        Private _weight As Double
        Private _electron As clsElementElectronShell

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

        Public Sub New(ByVal index As Integer, _
                       ByVal name As String, _
                       ByVal symbol As String, _
                       ByVal weight As Double, _
                       ByVal electron As String)
            _index = index
            _name = name
            _symbol = symbol
            _weight = weight
            _electron = New clsElementElectronShell(electron)
        End Sub
    End Class
End Namespace