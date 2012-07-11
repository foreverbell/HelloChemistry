
Imports HelloChemistry.formulaToken

Namespace chemicalFormula.parser.internal

    Public Class clsChemicalFormula2
        Inherits clsChemicalFormula0

        ' Parse (Number)Formula3, like 5CuSO4
        Public Overrides Sub parseFormula(ByVal stream As clsFormulaTokenStream)
            Dim factor As Integer = 1

            If (stream.nextTokenType = enumFormulaToken.tokenNumber) Then
                factor = stream.number
                stream.lex()
            End If

            Dim formula As New clsChemicalFormula3
            formula.parseFormula(stream)

            _element.merge(formula._element)
            _element.multiply(factor)

        End Sub

        Public Overrides Sub initializeExpectedTokenList()
            With _expectedTokenList
                .Add(enumFormulaToken.tokenElement)
                .Add(enumFormulaToken.tokenNumber)
            End With
        End Sub
    End Class
End Namespace