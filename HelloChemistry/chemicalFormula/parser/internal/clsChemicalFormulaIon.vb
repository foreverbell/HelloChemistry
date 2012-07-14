
Imports HelloChemistry.formulaToken

Namespace chemicalFormula.parser.internal

    Public Class clsChemicalFormulaIon
        Inherits clsChemicalFormula0

        Public Overrides Sub initializeExpectedTokenList()
            With _expectedTokenList
                .Add(enumFormulaToken.tokenNumber)
                .Add(enumFormulaToken.tokenPlus)
                .Add(enumFormulaToken.tokenMinus)
            End With
        End Sub

        Public Overrides Sub parseFormula(ByVal stream As clsFormulaTokenStream)
            If (stream.nextTokenType = enumFormulaToken.tokenNumber) Then
                _electron = stream.number
                stream.lex(True)
            Else
                _electron = 1
            End If
            If (Not isExpectedToken(stream)) Then
                stream.matchNextToken(enumFormulaToken.tokenPlus) ' Token mismatched
            End If
            If (stream.nextTokenType = enumFormulaToken.tokenMinus) Then
                _electron = -_electron
            End If
            stream.lex(True)
        End Sub
    End Class
End Namespace