
Imports HelloChemistry.matterState.state

Namespace matterState
    Public Class clsMatterStateManager
#Region "Sington Pattern"
        Private Shared ReadOnly _instance As New clsMatterStateManager

        Public Shared ReadOnly Property instance As clsMatterStateManager
            Get
                Return _instance
            End Get
        End Property

        Private Sub New()
        End Sub
#End Region

        Private _matterStateList As New List(Of IMatterState) From
            {
                New clsMatterStateSolid,
                New clsMatterStateLiquid,
                New clsMatterStateGas,
                New clsMatterStateAqueous
            }
        Private _nullMatterState As New clsMatterStateNull

        Public Function matchMatterStateWithBracket(ByVal str As String, ByVal pos As Integer) As IMatterState
            For Each m As IMatterState In _matterStateList
                If (String.Compare(str, pos, m.matterStateNameWithBracket, 0, m.matterStateNameWithBracket.Length) = 0) Then
                    Return m
                End If
            Next
            Return _nullMatterState
        End Function

        Public Function getNullMatterState()
            Return _nullMatterState
        End Function
    End Class
End Namespace