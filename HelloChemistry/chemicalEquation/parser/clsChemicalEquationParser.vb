
Imports HelloChemistry.formulaToken
Imports HelloChemistry.chemicalEquation.parser.internal

Namespace chemicalEquation.parser
    Public Class clsChemicalEquationParser

#Region "Sington Pattern"
        Private Shared ReadOnly _instance As New clsChemicalEquationParser

        Public Shared ReadOnly Property instance As clsChemicalEquationParser
            Get
                Return _instance
            End Get
        End Property

        Private Sub New()
        End Sub
#End Region

        Public Function parse(ByVal stream As clsFormulaTokenStream) As clsChemicalEquation
            Dim parser As New clsChemicalEquation1

            stream.addRecorder()
            parser.parseEquation(stream)

            Return New clsChemicalEquation(parser.leftList,
                                           parser.rightList,
                                           False)
        End Function

        Public Function parse(ByVal equation As String) As clsChemicalEquation
            Return parse(New clsFormulaTokenStream(equation))
        End Function
    End Class
End Namespace