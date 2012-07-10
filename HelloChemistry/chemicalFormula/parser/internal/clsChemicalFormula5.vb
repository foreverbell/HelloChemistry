
Imports HelloChemistry.formulaToken

Namespace chemicalFormula.parser.internal

    Public Class clsChemicalFormula5
        Inherits clsChemicalFormula0

        ' Only parse the number and the element symbol
        Public Overrides Sub parseFormula(ByVal stream As clsFormulaTokenStream)
            Do
                ' Token mismatched, end of matching
                If (Not isExpectedToken(stream)) Then
                    Exit Do
                End If

                ' Process the current element(optional factor = 1)
                Dim currentElement As String = stream.element
                Dim currentNumber As Integer = 1

                stream.lex()

                ' Process the factor if it exists
                If (Not stream.isEnd()) Then
                    If (stream.nextTokenType = enumFormulaToken.tokenNumber) Then
                        currentNumber = stream.number
                        stream.lex()
                    End If
                End If

                _element.add(currentElement, currentNumber)

            Loop Until stream.isEnd()

        End Sub

        Public Overrides Sub initializeExpectedTokenList()
            With _expectedTokenList
                .Add(enumFormulaToken.tokenElement)
                ' .Add(enumFormulaToken.tokenNumber)
            End With
        End Sub
    End Class
End Namespace