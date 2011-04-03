
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
            Dim stream As clsFormulaTokenStream = New clsFormulaTokenStream(formula)
            parser.parseFormula(stream)
            If (Not stream.isEnd()) Then
                Throw New Exception("Bad chemical formula")
            End If
        End Sub
    End Class
End Namespace