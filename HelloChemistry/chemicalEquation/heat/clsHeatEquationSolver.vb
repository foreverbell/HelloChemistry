
Namespace chemicalEquation.heat
    Public Class clsHeatEquationSolver

#Region "Sington Pattern"
        Private Shared ReadOnly _instance As New clsHeatEquationSolver

        Public Shared ReadOnly Property instance As clsHeatEquationSolver
            Get
                Return _instance
            End Get
        End Property

        Private Sub New()
        End Sub
#End Region

        Private _sourceEquationList As New HashSet(Of clsHeatEquation)
        Private _destinationEquation As clsChemicalEquation

        Public Sub clearSourceEquationList()
            _sourceEquationList.Clear()
        End Sub

        Public Sub addEquationToSourceList(ByVal equation As clsHeatEquation)
            _sourceEquationList.Add(equation)
        End Sub

        Public Sub setDestinationEquation(ByVal equation As clsChemicalEquation)
            _destinationEquation = equation
        End Sub

        Public Function solve() As clsHeatEquation
            ' TODO: Not implemented
        End Function
    End Class
End Namespace