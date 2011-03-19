
Imports HelloChemistry.chemicalFormula

Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim formula As New clsChemicalFormula("Fe2(SO4)3.5H2O")

        Debug.Print("Fe2(SO4)3.5H2O mass: " + formula.mass.ToString)

    End Sub
End Class
