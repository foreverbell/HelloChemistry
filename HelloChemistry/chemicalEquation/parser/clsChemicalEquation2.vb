
Imports HelloChemistry.chemicalFormula
Imports HelloChemistry.formulaToken

Namespace chemicalEquation.parser
    Public Class clsChemicalEquation2

        Public Sub parseFormula(ByVal stream As clsFormulaTokenStream, ByVal formulaList As List(Of clsChemicalFormula))
            Do
                Dim equation As New clsChemicalEquation3
                equation.parseFormula(stream, formulaList)

                If (Not stream.isEnd()) Then
                    If (stream.nextTokenType = enumFormulaToken.tokenPlus) Then
                        stream.lex()
                    Else
                        Exit Do
                    End If
                End If

            Loop Until stream.isEnd()
        End Sub
    End Class
End Namespace