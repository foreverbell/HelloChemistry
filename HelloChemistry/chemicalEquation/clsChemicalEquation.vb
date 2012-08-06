
Imports HelloChemistry.chemicalFormula
Imports HelloChemistry.chemicalEquation.parser

Namespace chemicalEquation
    Public Class clsChemicalEquation

        Private _leftList As New List(Of clsChemicalFormula)
        Private _rightList As New List(Of clsChemicalFormula)
        Private _strChemicalEquation As String
        Private _balanced As Boolean

        Public ReadOnly Property leftList As List(Of clsChemicalFormula)
            Get
                Return _leftList
            End Get
        End Property

        Public ReadOnly Property rightList As List(Of clsChemicalFormula)
            Get
                Return _rightList
            End Get
        End Property

        Public ReadOnly Property strChemicalEquation As String
            Get
                Return _strChemicalEquation
            End Get
        End Property

        Public Function balance() As clsChemicalEquation
            If (_balanced) Then
                Throw New Exception("Equation already balanced.")
            Else
                Return clsChemicalEquationBalancer.instance.balance(Me)
            End If
        End Function

        Public Function isBalanced() As Boolean
            If (Not _balanced) Then
                Dim result As Boolean = clsChemicalEquationBalancedChecker.instance.checkBalanced(Me)
                _balanced = result
            End If
            Return _balanced
        End Function

        Public Sub New(ByVal leftList As List(Of clsChemicalFormula),
                       ByVal rightList As List(Of clsChemicalFormula),
                       ByVal strChemicalEqualtion As String,
                       ByVal balanced As Boolean)
            _leftList = leftList
            _rightList = rightList
            _strChemicalEquation = strChemicalEqualtion
            _balanced = balanced
        End Sub
    End Class
End Namespace