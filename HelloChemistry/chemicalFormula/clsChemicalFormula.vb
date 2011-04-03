
Imports HelloChemistry.formulaToken
Imports HelloChemistry.chemicalFormula.parser

Namespace chemicalFormula
    Public Class clsChemicalFormula

        Dim _parser As New clsChemicalFormula1
        Dim _chemicalFormula As String

        Public ReadOnly Property mass As Double
            Get
                Return _parser.element.mass
            End Get
        End Property

        Public ReadOnly Property chemicalFormula As String
            Get
                Return _chemicalFormula
            End Get
        End Property

        Public ReadOnly Property element As clsElementList
            Get
                Return _parser.element
            End Get
        End Property

        Private Sub parse(ByVal stream As clsFormulaTokenStream)
            Dim startPos As Integer = stream.position

            _parser.parseFormula(stream)

            _chemicalFormula = Mid(stream.formula, startPos + 1, stream.position - startPos)
        End Sub

        Public Sub New(ByVal formula As String)
            parse(New clsFormulaTokenStream(formula))
        End Sub

        Public Sub New(ByVal formula As clsFormulaTokenStream)
            parse(formula)
        End Sub
    End Class
End Namespace