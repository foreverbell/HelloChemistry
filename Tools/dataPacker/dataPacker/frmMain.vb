
'
' Data Packer for HelloChemistry
' Written by ForeverBell on Mar 18, 2011
'

Imports System.IO
Imports System.IO.Compression

Public Class frmMain

    Private Sub packFile(ByVal inFile As String, ByVal outFile As String)

        Dim packStream As New DeflateStream(New FileStream(outFile, FileMode.Create), CompressionMode.Compress)
        Dim inFileStream As New FileStream(inFile, FileMode.Open)

        Dim bytBuffer(inFileStream.Length) As Byte

        inFileStream.Read(bytBuffer, 0, inFileStream.Length)
        packStream.Write(bytBuffer, 0, inFileStream.Length)

        MsgBox("Compressed " & inFile & " from " & inFileStream.Length() & " to " & packStream.BaseStream.Length() & " bytes. ")

        packStream.Close()
    End Sub

    Private Sub btnOpenFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenFile.Click
        Dim fileDialog As New OpenFileDialog

        If fileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            textFilePath.Text = fileDialog.FileName
            textOutFilePath.Text = fileDialog.FileName + ".dat"
        End If
    End Sub

    Private Sub btnPack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPack.Click
        packFile(textFilePath.Text, textOutFilePath.Text)
    End Sub
End Class
