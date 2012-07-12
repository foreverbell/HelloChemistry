
Imports HelloChemistry.data

Namespace element

    Public Class clsElementManager
        Private Shared ReadOnly _instance As New clsElementManager

        Public Shared ReadOnly Property instance As clsElementManager
            Get
                Return _instance
            End Get
        End Property

        Private Sub New()
            initializeElement()
        End Sub

        Private _elementList As New List(Of clsElement)
        Private Const ELEMENT_COUNT As Integer = 112

        Public Overloads ReadOnly Property element(ByVal index As Integer) As clsElement
            Get
                For Each ele As clsElement In _elementList
                    If (ele.index = index) Then
                        Return ele
                    End If
                Next
                Throw New ArgumentException("No such a element with index " + index.ToString)
            End Get
        End Property

        Public Overloads ReadOnly Property element(ByVal symbol As String) As clsElement
            Get
                For Each ele As clsElement In _elementList
                    If (ele.symbol = symbol) Then
                        Return ele
                    End If
                Next
                Throw New ArgumentException("No such a element " + symbol)
            End Get
        End Property

        Public Function hasElement(ByVal symbol As String) As Boolean
            For Each ele As clsElement In _elementList
                If (ele.symbol = symbol) Then
                    Return True
                End If
            Next
            Return False
        End Function

        Private Sub initializeElement()
            For index As Integer = 1 To ELEMENT_COUNT
                Dim symbol As String
                Dim name As String
                Dim weight As Double
                Dim electron As String
                Dim meltingPoint As Double
                Dim boilingPoint As Double

                With clsDataReaderManager.instance
                    symbol = Split(.dataReader(enumDataReaderArgment.elementSymbol).data(index), " ")(0)
                    name = Split(.dataReader(enumDataReaderArgment.elementSymbol).data(index), " ")(1)
                    weight = Val(.dataReader(enumDataReaderArgment.elementWeight).data(index))
                    electron = .dataReader(enumDataReaderArgment.elementElectronShell).data(index)
                    meltingPoint = Split(.dataReader(enumDataReaderArgment.elementMeltingAndBoilingPoint).data(index), " ")(0)
                    boilingPoint = Split(.dataReader(enumDataReaderArgment.elementMeltingAndBoilingPoint).data(index), " ")(1)
                End With

                _elementList.Add(New clsElement(index,
                                                name,
                                                symbol,
                                                weight,
                                                electron,
                                                meltingPoint,
                                                boilingPoint))
            Next

            ' Dispose all
            With clsDataReaderManager.instance
                .dataReader(enumDataReaderArgment.elementSymbol).Dispose()
                .dataReader(enumDataReaderArgment.elementWeight).Dispose()
                .dataReader(enumDataReaderArgment.elementElectronShell).Dispose()
                .dataReader(enumDataReaderArgment.elementMeltingAndBoilingPoint).Dispose()
            End With
        End Sub
    End Class
End Namespace