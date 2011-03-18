
Namespace chemicalFormula.formulaToken.formulaChar

    Public Class clsFormulaChar

        Private Shared ReadOnly _formulaCharList As New HashSet(Of IFormulaChar) From
            {
                New clsUpperCase,
                New clsLowerCase,
                New clsNumber,
                New clsLeftBracket,
                New clsRightBracket
            }

        Public Shared ReadOnly Property charType(ByVal ch As Char) As enumFormulaChar
            Get
                For Each formulaChar As IFormulaChar In _formulaCharList
                    If (formulaChar.match(ch)) Then
                        Return formulaChar.charType
                    End If
                Next
                Throw New ArgumentException
            End Get
        End Property

        Public Shared Sub match(ByVal ch As Char, ByVal charTypeToExpect As enumFormulaChar)
            If (charType(ch) <> charTypeToExpect) Then
                Throw New Exception("char mismatch")
            End If
        End Sub
    End Class
End Namespace