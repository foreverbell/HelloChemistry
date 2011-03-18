
Namespace element

    Public Class clsElementElectronShell

        Private _numOfShells As Integer
        Private _electronCount() As Integer

        Private Sub initialize(ByVal electron As String)
            Dim shells() As String = Split(electron, ",")

            _numOfShells = shells.GetLength(0)
            ReDim _electronCount(_numOfShells)
            For index As Integer = 0 To _numOfShells - 1
                _electronCount(index + 1) = Val(shells(index))
            Next
        End Sub

        Public ReadOnly Property numOfShells As Integer
            Get
                Return _numOfShells
            End Get
        End Property

        Public ReadOnly Property electron(ByVal shell As Integer) As Integer
            Get
                Return _electronCount(shell)
            End Get
        End Property

        Public ReadOnly Property valenceElectron As Integer
            Get
                Return _electronCount(_numOfShells)
            End Get
        End Property

        Public Sub New(ByVal electron As String)
            initialize(electron)
        End Sub
    End Class

End Namespace