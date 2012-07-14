
Namespace formulaToken.char

    Public Class clsFormulaChar

        Private Shared ReadOnly _formulaCharList As New List(Of IFormulaChar) From
            {
                New clsCharUpperCase,
                New clsCharLowerCase,
                New clsCharNumber,
                New clsCharLeftBracket,
                New clsCharRightBracket,
                New clsCharLeftBracket2,
                New clsCharRightBracket2,
                New clsCharPlus,
                New clsCharMinus,
                New clsCharEqual
            }

        Public Shared ReadOnly Property charType(ByVal ch As Char) As enumFormulaChar
            Get
                For Each formulaChar As IFormulaChar In _formulaCharList
                    If (formulaChar.match(ch)) Then
                        Return formulaChar.charType
                    End If
                Next
                Throw New ArgumentException("Bad char.")
            End Get
        End Property
    End Class
End Namespace