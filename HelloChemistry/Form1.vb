
Imports HelloChemistry.chemicalFormula

Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim t As New clsFormulaStream("Fe2(SO4)3")

        t.parseFormula()

    End Sub
End Class
