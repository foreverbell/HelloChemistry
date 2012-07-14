
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
            Dim parser As New clsChemicalEquation1

            stream.addRecorder()
            parser.parseEquation(stream)

            Dim strChemicalEquation As String = stream.getRecordResult

            Return New clsChemicalEquation(parser.leftList,
                                           parser.rightList,
                                           strChemicalEquation,
                                           False)
        End Function

        Public Function parse(ByVal equation As String) As clsChemicalEquation
            Debug.Print("Equation: " & equation)
            Return parse(New clsFormulaTokenStream(equation))
        End Function
    End Class
End Namespace