
Imports HelloChemistry.formulaToken
Imports HelloChemistry.chemicalFormula.parser.internal

Namespace chemicalFormula.parser

    Public Class clsChemicalFormulaParser

#Region "Sington Pattern"
        Private Shared ReadOnly _instance As New clsChemicalFormulaParser

        Public Shared ReadOnly Property instance As clsChemicalFormulaParser
            Get
                Return _instance
            End Get
        End Property

        Private Sub New()
        End Sub
#End Region

        Public Function parse(ByVal stream As clsFormulaTokenStream) As clsChemicalFormula
            Dim parser As New clsChemicalFormula1

            stream.addRecorder()
            parser.parseFormula(stream)

            Dim strChemicalFormula As String = stream.getRecordResult

            Return New clsChemicalFormula(parser._electron,
                                          strChemicalFormula,
                                          parser._element,
                                          parser._matterState,
                                          parser._factor)
        End Function

        Public Function parse(ByVal formula As String) As clsChemicalFormula
            Return parse(New clsFormulaTokenStream(formula))
        End Function
    End Class
End Namespace