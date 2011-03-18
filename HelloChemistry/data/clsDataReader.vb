
Imports System.IO
Imports System.IO.Compression

Namespace data
    Public Class clsDataReader

        Private _dataIndex As enumDataReaderArgment
        Private _numOfLines As Integer
        Private _lineData() As String

        Private Sub parseData(ByVal data As Byte())
            Dim packStream As DeflateStream = New DeflateStream(New MemoryStream(data), CompressionMode.Decompress)
            Dim streamToRead As StreamReader = New StreamReader(packStream)

            _lineData = Split(streamToRead.ReadToEnd, vbCrLf)
            _numOfLines = _lineData.GetLength(0)
        End Sub

        Public ReadOnly Property dataIndex As Integer
            Get
                Return _dataIndex
            End Get
        End Property

        Public ReadOnly Property numOfLine() As Integer
            Get
                Return _numOfLines
            End Get
        End Property

        Public ReadOnly Property data(ByVal line As Integer) As String
            Get
                Return _lineData(line - 1)
            End Get
        End Property

        Public Sub New(ByVal index As enumDataReaderArgment, ByVal data As Byte())
            _dataIndex = index
            parseData(data)
        End Sub
    End Class
End Namespace