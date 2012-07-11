
Imports HelloChemistry.chemicalFormula
Imports HelloChemistry.formulaToken

Namespace chemicalEquation.parser.internal
    Public Class clsChemicalEquation1

        Private _leftList As New List(Of clsChemicalFormula)
        Private _rightList As New List(Of clsChemicalFormula)

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

        Public Sub parseEquation(ByVal stream As clsFormulaTokenStream)
            Dim equation As New clsChemicalEquation2

            equation.parseEquation(stream, _leftList)

            stream.matchNextToken(enumFormulaToken.tokenEqual)
            stream.lex()

            equation.parseEquation(stream, _rightList)
        End Sub
    End Class
End Namespace