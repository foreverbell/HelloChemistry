
Imports HelloChemistry.chemicalFormula
Imports HelloChemistry.formulaToken

Namespace chemicalEquation.parser.internal
    Public Class clsChemicalEquation2

        Public Sub parseEquation(ByVal stream As clsFormulaTokenStream, ByVal formulaList As List(Of clsChemicalFormula))
            Do
                Dim equation As New clsChemicalEquation3
                equation.parseEquation(stream, formulaList)

                If (Not stream.isEnd()) Then
                    If (stream.nextTokenType = enumFormulaToken.tokenPlus) Then
                        stream.lex(True)
                    Else
                        Exit Do
                    End If
                End If

            Loop Until stream.isEnd()
        End Sub
    End Class
End Namespace