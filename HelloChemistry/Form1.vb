
Imports System.IO.Compression
Imports HelloChemistry.element
Imports HelloChemistry.data

Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Debug.Print(clsElementManager.instance.element("Cu").electron.valenceElectron)
    End Sub
End Class
