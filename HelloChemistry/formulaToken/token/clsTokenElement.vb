
Imports HelloChemistry.formulaToken.char

Namespace formulaToken.token
    Public Class clsTokenElement
        Implements IFormulaToken

        Private _elementSymbol As String

        Public ReadOnly Property elementSymbol As String
            Get
                Return _elementSymbol
            End Get
        End Property

        Public Function length() As Integer Implements IFormulaToken.length
            Return _elementSymbol.Length
        End Function

        Public Function match(ByVal formula As String, ByVal position As Integer) As Boolean Implements IFormulaToken.match
            If (clsFormulaChar.charType(formula(position)) <> enumFormulaChar.charUpperCase) Then
                Return False
            End If

            _elementSymbol = formula(position)
            position += 1
            If (position < formula.Length) Then
                If (clsFormulaChar.charType(formula(position)) = enumFormulaChar.charLowerCase) Then
                    _elementSymbol &= formula(position)
                End If
            End If

            Return True
        End Function

        Public Function tokenType() As enumFormulaToken Implements IFormulaToken.tokenType
            Return enumFormulaToken.tokenElement
        End Function
    End Class
End Namespace