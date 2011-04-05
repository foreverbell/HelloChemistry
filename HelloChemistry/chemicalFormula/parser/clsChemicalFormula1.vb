
Imports HelloChemistry.formulaToken

Namespace chemicalFormula.parser

    Public Class clsChemicalFormula1
        Inherits clsChemicalFormula0

        Public Overrides Sub parseFormula(ByVal stream As formulaToken.clsFormulaTokenStream)
            Do
                Dim formula As New clsChemicalFormula2
                formula.parseFormula(stream)

                _element.merge(formula._element)
                If (Not stream.isEnd()) Then
                    If (stream.nextTokenType = enumFormulaToken.tokenPeriod) Then
                        ' stream.matchNextToken(enumFormulaToken.tokenPeriod)
                        stream.lexer()
                    Else
                        If (stream.nextTokenType = enumFormulaToken.tokenLeftBracket2) Then
                            stream.lexer()

                            Dim formulaElectron As New clsChemicalFormulaElectron
                            formulaElectron.parseFormula(stream)
                            _electron = formulaElectron._electron

                            stream.matchNextToken(enumFormulaToken.tokenRightBracket2)
                            stream.lexer()
                        End If
                        Exit Do
                    End If
                End If
            Loop Until (stream.isEnd())
        End Sub

        Public Overrides Sub initializeExpectedTokenList()
            With _expectedTokenList
                .Add(enumFormulaToken.tokenPeriod)
            End With
        End Sub
    End Class
End Namespace