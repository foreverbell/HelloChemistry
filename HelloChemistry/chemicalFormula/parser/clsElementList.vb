
Imports HelloChemistry.element

Namespace chemicalFormula.parser

    Public Class clsElementList
        Private _elementTable As New Hashtable

        Public Sub add(ByVal element As String, ByVal factor As Integer)
            If (Not _elementTable.ContainsKey(element)) Then
                _elementTable.Add(element, factor)
            Else
                _elementTable.Item(element) += factor
            End If

            Debug.Print("Element added, " & element & ", with factor " & factor.ToString)
        End Sub

        Public Sub merge(ByVal list As clsElementList)
            Dim keys As ICollection = list._elementTable.Keys

            For Each key As String In keys
                If (Not _elementTable.ContainsKey(key)) Then
                    _elementTable.Item(key) = list._elementTable.Item(key)
                Else
                    _elementTable.Item(key) += list._elementTable.Item(key)
                End If
            Next
        End Sub

        Public Sub mult(ByVal factor As Integer)
            Dim keys As ICollection = _elementTable.Clone().Keys

            For Each key As String In keys
                _elementTable.Item(key) *= factor
            Next

            Debug.Print("All element multiply " & factor.ToString)
        End Sub

        Public ReadOnly Property mass As Double
            Get
                Dim keys As ICollection = _elementTable.Keys
                Dim result As Double

                For Each key As String In keys
                    result += clsElementManager.instance.element(key).weight * _elementTable.Item(key)
                Next
                Return result
            End Get
        End Property

        Public ReadOnly Property elementTableCopy
            Get
                Return _elementTable.Clone
            End Get
        End Property
    End Class
End Namespace