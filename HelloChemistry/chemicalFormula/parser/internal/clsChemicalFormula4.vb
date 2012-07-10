
Imports HelloChemistry.formulaToken

Namespace chemicalFormula.parser.internal

    Public Class clsChemicalFormula4
        Inherits clsChemicalFormula0

        ' Parse formula1/5, (, )
        Public Overrides Sub parseFormula(ByVal stream As clsFormulaTokenStream)
            Dim formula As clsChemicalFormula0

            If (stream.nextTokenType = enumFormulaToken.tokenLeftBracket) Then
                ' The first token might be '('
                stream.matchNextToken(enumFormulaToken.tokenLeftBracket)
                stream.lex()

                ' Processed by formula1
                formula = New clsChemicalFormula1
                formula.parseFormula(stream)

                ' Test if the token is ')'
                stream.matchNextToken(enumFormulaToken.tokenRightBracket)
                stream.lex()
            Else
                ' Processed by formula5
                formula = New clsChemicalFormula5
                formula.parseFormula(stream)
            End If

            Dim factor As Integer = 1

            ' Process the number
            If (Not stream.isEnd()) Then
                If (stream.nextTokenType = enumFormulaToken.tokenNumber) Then
                    factor = stream.number
                    stream.lex()
                End If
            End If

            ' Initialize the element list
            _element.merge(formula._element)
            _element.mult(factor)

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