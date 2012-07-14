
Imports HelloChemistry.formulaToken
Imports HelloChemistry.matterState
Imports HelloChemistry.matterState.state

Namespace chemicalFormula.parser.internal

    Public MustInherit Class clsChemicalFormula0
        Protected Friend _element As New clsElementList
        Protected Friend _electron As Integer
        Protected Friend _expectedTokenList As New List(Of enumFormulaToken)
        Protected Friend _matterState As IMatterState
        Protected Friend _factor As Integer

        Public ReadOnly Property element As clsElementList
            Get
                Return _element
            End Get
        End Property

        Protected Friend Function isExpectedToken(ByVal stream As clsFormulaTokenStream) As Boolean
            For Each expectedToken As enumFormulaToken In _expectedTokenList
                If (expectedToken = stream.nextTokenType) Then
                    Return True
                End If
            Next
            Return False
        End Function

        Public MustOverride Sub initializeExpectedTokenList()
        Public MustOverride Sub parseFormula(ByVal stream As clsFormulaTokenStream)

        Protected Friend Sub New()
            initializeExpectedTokenList()
        End Sub
    End Class
End Namespace