
Imports HelloChemistry.formulaToken.char

Namespace formulaToken.token
    Public Class clsTokenNumber
        Implements IFormulaToken

        Private _length As Integer
        Private _number As Integer

        Public ReadOnly Property number As Integer
            Get
                Return _number
            End Get
        End Property

        Public Function length() As Integer Implements IFormulaToken.length
            Return _length
        End Function

        Public Function match(ByVal formula As String, ByVal position As Integer) As Boolean Implements IFormulaToken.match
            If (clsFormulaChar.charType(formula(position)) <> enumFormulaChar.charNumber) Then
                Return False
            End If
            _number = 0
            While (clsFormulaChar.charType(formula(position)) = enumFormulaChar.charNumber)
                _number *= 10
                _number += Val(formula(position))
                _length += 1
                position += 1

                If (position >= formula.Length) Then
                    Exit While
                End If
            End While
            Return True
        End Function

        Public Function tokenType() As enumFormulaToken Implements IFormulaToken.tokenType
            Return enumFormulaToken.tokenNumber
        End Function
    End Class
End Namespace