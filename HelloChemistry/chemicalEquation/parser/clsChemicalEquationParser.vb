
Imports HelloChemistry.formulaToken
Imports HelloChemistry.chemicalEquation.parser.internal

Namespace chemicalEquation.parser
    Public Class clsChemicalEquationParser
        Private Shared ReadOnly _instance As New clsChemicalEquationParser

        Public Shared ReadOnly Property instance As clsChemicalEquationParser
            Get
                Return _instance
            End Get
        End Property

        Private Sub New()
        End Sub

        Public Function parse(ByVal stream As clsFormulaTokenStream) As clsChemicalEquation
            Dim _parser As New clsChemicalEquation1
            Dim startPos As Integer = stream.position

            _parser.parseEquation(stream)

            Dim strChemicalEquation As String = Mid(stream.formula, startPos + 1, stream.position - startPos)

            Return New clsChemicalEquation(_parser.leftList, _parser.rightList, strChemicalEquation, False)
        End Function

        Public Function parse(ByVal equation As String) As clsChemicalEquation
            Debug.Print("Equation: " & equation)
            Return parse(New clsFormulaTokenStream(equation))
        End Function
    End Class
End Namespace