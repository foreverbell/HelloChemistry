
Imports HelloChemistry.element
Imports HelloChemistry.formulaToken.char

Namespace formulaToken.token
    Public Class clsTokenElement
        Implements IFormulaToken

        Private _elementSymbol As String
        Private _element As clsElement

        Public ReadOnly Property element As clsElement
            Get
                Return _element
            End Get
        End Property

        Public ReadOnly Property length As Integer Implements IFormulaToken.length
            Get
                Return _elementSymbol.Length
            End Get
        End Property

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

            If (clsElementManager.instance.hasElement(_elementSymbol)) Then
                _element = clsElementManager.instance.element(_elementSymbol)
                Return True
            Else
                Return False
            End If
        End Function

        Public Function tokenType() As enumFormulaToken Implements IFormulaToken.tokenType
            Return enumFormulaToken.tokenElement
        End Function
    End Class
End Namespace