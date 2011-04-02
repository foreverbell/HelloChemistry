
Imports System.IO
Imports System.IO.Compression

Namespace data
    Public Class clsDataReader
        Implements IDisposable

        Private _dataType As enumDataReaderArgment
        Private _numOfLines As Integer
        Private _lineData() As String

        Private Sub parseData(ByVal data As Byte())
            Dim mStream As New MemoryStream(data)
            Dim packStream As DeflateStream = New DeflateStream(mStream, CompressionMode.Decompress)
            Dim streamToRead As StreamReader = New StreamReader(packStream)

            _lineData = Split(streamToRead.ReadToEnd, vbCrLf)
            _numOfLines = _lineData.GetLength(0)

            mStream.Dispose()
            packStream.Dispose()
            streamToRead.Dispose()
        End Sub

        Public ReadOnly Property dataType As Integer
            Get
                Return _dataType
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

        Public Sub New(ByVal type As enumDataReaderArgment, ByVal data As Byte())
            _dataType = type
            parseData(data)
        End Sub

#Region "IDisposable Support"
        Private disposedValue As Boolean

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                Erase _lineData
            End If
            Me.disposedValue = True
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class
End Namespace