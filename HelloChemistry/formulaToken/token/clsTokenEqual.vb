﻿
Imports HelloChemistry.formulaToken.char

Namespace formulaToken.token
    Public Class clsTokenEqual
        Implements IFormulaToken

        Public Function length() As Integer Implements IFormulaToken.length
            Return 1
        End Function

        Public Function match(ByVal formula As String, ByVal position As Integer) As Boolean Implements IFormulaToken.match
            Return (clsFormulaChar.charType(formula(position)) = enumFormulaChar.charEqual)
        End Function

        Public Function tokenType() As enumFormulaToken Implements IFormulaToken.tokenType
            Return enumFormulaToken.tokenEqual
        End Function
    End Class
End Namespace