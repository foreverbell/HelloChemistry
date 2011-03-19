
Imports HelloChemistry.formulaToken

Namespace chemicalFormula.parser
    
    Public Class clsChemicalFormula3
        Inherits clsChemicalFormula0

        ' Parse multiple formula4
        Public Overrides Sub parseFormula(ByVal stream As clsFormulaTokenStream)
            Do
                If (isExpectedToken(stream)) Then
                    Dim formula As New clsChemicalFormula4

                    formula.parseFormula(stream)

                    _element.merge(formula._element)
                Else
                    Exit Do
                End If

            Loop Until stream.isEnd()
        End Sub

        Public Overrides Sub initializeExpectedTokenList()
            With _expectedTokenList
                .Add(enumFormulaToken.tokenElement)
                ' .Add(enumFormulaToken.tokenNumber)
                .Add(enumFormulaToken.tokenLeftBracket)
                ' .Add(enumFormulaToken.tokenRightBracket)
            End With
        End Sub
    End Class
End Namespace