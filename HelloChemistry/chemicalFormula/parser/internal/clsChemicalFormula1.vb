
Imports HelloChemistry.formulaToken
Imports HelloChemistry.matterState

Namespace chemicalFormula.parser.internal

    Public Class clsChemicalFormula1
        Inherits clsChemicalFormula0

        Public Overrides Sub parseFormula(ByVal stream As formulaToken.clsFormulaTokenStream)
            Do
                Dim formula As New clsChemicalFormula2
                formula.parseFormula(stream)

                _element.merge(formula._element)
                _factor = formula._factor
                _electron = formula._electron

                If (Not stream.isEnd()) Then
                    If (stream.nextTokenType = enumFormulaToken.tokenLeftBracket2) Then
                        stream.lex(True)

                        Dim formulaElectron As New clsChemicalFormulaIon
                        formulaElectron.parseFormula(stream)
                        _electron = formulaElectron._electron * _factor

                        stream.matchNextToken(enumFormulaToken.tokenRightBracket2)
                        stream.lex(True)
                    End If

                    If (stream.nextTokenType = enumFormulaToken.tokenMatterState) Then
                        _matterState = stream.matterState
                        stream.lex(True)
                    Else
                        _matterState = clsMatterStateManager.instance.getNullMatterState()
                    End If

                    Exit Do
                End If
            Loop Until (stream.isEnd())
        End Sub

        Public Overrides Sub initializeExpectedTokenList()
            With _expectedTokenList
                '
            End With
        End Sub
    End Class
End Namespace