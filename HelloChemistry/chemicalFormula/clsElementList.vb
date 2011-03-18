
Imports HelloChemistry.element

Namespace chemicalFormula
    Public Class clsElementList
        Private _elementTable As Hashtable

        Public Sub add(ByVal element As clsElement, ByVal factor As Integer)
            If (Not _elementTable.ContainsKey(element.symbol)) Then
                _elementTable.Add(element.symbol, factor)
            Else
                _elementTable.Item(element.symbol) += factor
            End If
        End Sub

        Public Sub New()
            _elementTable = New Hashtable
        End Sub

        Public Sub New(ByVal list1 As clsElementList, ByVal list2 As clsElementList)
            _elementTable = list1._elementTable.Clone()

            Dim keys As ICollection = list2._elementTable.Keys

            For Each key As String In keys
                If (Not _elementTable.ContainsKey(key)) Then
                    _elementTable.Item(key) = 1
                Else
                    _elementTable.Item(key) += list2._elementTable.Item(key)
                End If
            Next
        End Sub

        Public Sub New(ByVal list As clsElementList, ByVal factor As Integer)
            _elementTable = list._elementTable.Clone()

            Dim keys As ICollection = _elementTable.Keys

            For Each key As String In keys
                _elementTable.Item(key) *= factor
            Next
        End Sub
    End Class
End Namespace