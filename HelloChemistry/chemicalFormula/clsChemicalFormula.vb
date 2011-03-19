
Imports HelloChemistry.formulaToken
Imports HelloChemistry.chemicalFormula.parser

Namespace chemicalFormula
    Public Class clsChemicalFormula

        Dim parser As New clsChemicalFormula1

        Public ReadOnly Property mass As Double
            Get
                Return parser.element.mass
            End Get
        End Property

        Public Sub New(ByVal formula As String)
            parser.parseFormula(New clsFormulaTokenStream(formula))
        End Sub
    End Class
End Namespace