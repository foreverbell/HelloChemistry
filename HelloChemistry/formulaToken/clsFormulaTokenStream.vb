
Imports HelloChemistry.element
Imports HelloChemistry.formulaToken.token
Imports HelloChemistry.matterState.state

Namespace formulaToken

    Public Class clsFormulaTokenStream

        Private _formula As String
        Private _length As Integer
        Private _oldPosition As Integer
        Private _position As Integer
        Private _endFlag As Boolean
        Private _currentToken As IFormulaToken
        Private _strStack As New Stack(Of String)

        Public Sub lex(ByVal recorded As Boolean)
            Debug.Assert(Not isEnd())

            If (recorded) Then
                If (Not (_strStack.Count = 0)) Then
                    Dim oldStr As String = _strStack.Pop()
                    oldStr &= _currentToken.toStr()
                    _strStack.Push(oldStr)
                End If
            End If

            If (_position >= _length) Then
                _oldPosition = _position
                _endFlag = True
            Else
                _currentToken = clsFormulaToken.token(_formula, _position)
                _oldPosition = _position
                _position += _currentToken.length
            End If
        End Sub

        Public Function isEnd() As Boolean
            Return _endFlag
        End Function

        Public Sub matchNextToken(ByVal expectedToken As enumFormulaToken)
            If (nextTokenType <> expectedToken) Then
                Throw New Exception("Token mismatch.")
            End If
        End Sub

        Public ReadOnly Property position As Integer
            Get
                Return _oldPosition
            End Get
        End Property

        Public ReadOnly Property formula As String
            Get
                Return _formula
            End Get
        End Property

        Public ReadOnly Property nextTokenType As enumFormulaToken
            Get
                Return _currentToken.tokenType
            End Get
        End Property

        Public ReadOnly Property number() As Integer
            Get
                Return CType(_currentToken, clsTokenNumber).number
            End Get
        End Property

        Public ReadOnly Property element As clsElement
            Get
                Return CType(_currentToken, clsTokenElement).element
            End Get
        End Property

        Public ReadOnly Property matterState As IMatterState
            Get
                Return CType(_currentToken, clsTokenMatterState).stateType
            End Get
        End Property

        Public Sub addRecorder()
            _strStack.Push("")
        End Sub

        Public Function getRecordResult() As String
            Dim ret As String = _strStack.Pop()
            If (Not (_strStack.Count = 0)) Then
                Dim oldStr As String = _strStack.Pop()
                oldStr &= ret
                _strStack.Push(oldStr)
            End If
            Return ret
        End Function

        Public Sub New(ByVal formula As String)
            ' Removing white space
            _formula = Replace(formula, " ", "")

            _position = 0
            _length = _formula.Length
            lex(False)
        End Sub
    End Class
End Namespace
