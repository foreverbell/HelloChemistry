
Imports HelloChemistry.chemicalFormula.formulaToken

Namespace chemicalFormula

    Public Class clsFormulaStream

        Private _formula As String
        Private _length As Integer
        Private _position As Integer
        Private _endFlag As Boolean

        Private _currentToken As IFormulaToken

        Public Sub lexer()
            Debug.Assert(Not isEnd())
            If (_position >= _length) Then
                _endFlag = True
            Else
                _currentToken = clsFormulaToken.token(_formula, _position)
                _position += _currentToken.length
            End If
        End Sub

        Public Function isEnd() As Boolean
            Return _endFlag
        End Function

        Public ReadOnly Property nextTokenType As enumFormulaToken
            Get
                Return _currentToken.tokenType
            End Get
        End Property

        Public ReadOnly Property number() As Integer
            Get
                Debug.Assert(_currentToken.tokenType = enumFormulaToken.tokenNumber)
                Dim result As Integer = CType(_currentToken, clsTokenNumber).number
                lexer()
                Return result
            End Get
        End Property

        Public ReadOnly Property element As String
            Get
                Debug.Assert(_currentToken.tokenType = enumFormulaToken.tokenElement)
                Dim result As String = CType(_currentToken, clsTokenElement).elementSymbol
                lexer()
                Return result
            End Get
        End Property

        Public Sub New(ByVal formula As String)
            _formula = formula
            _position = 0
            _length = formula.Length
            lexer()
        End Sub

#If DEBUG Then
        Public Sub parseFormula()
            Debug.Print("parsing formula " + _formula)
            Do
                If (nextTokenType = enumFormulaToken.tokenElement) Then
                    Debug.Print("Element " + element)
                ElseIf (nextTokenType = enumFormulaToken.tokenNumber) Then
                    Debug.Print("Number " + number.ToString)
                ElseIf (nextTokenType = enumFormulaToken.tokenLeftBracket) Then
                    Debug.Print("Left Bracket")
                    lexer()
                Else
                    Debug.Print("Right Bracket")
                    lexer()
                End If
            Loop Until (isEnd())
        End Sub
#End If
    End Class

End Namespace