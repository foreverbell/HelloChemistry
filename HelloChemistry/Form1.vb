
Imports HelloChemistry.chemicalFormula
Imports HelloChemistry.element
Imports HelloChemistry.temperature
Imports HelloChemistry.chemicalEquation

Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim formula As New clsChemicalFormula("Fe2(SO4(5CuSO4·H2O)2)3·6H2O")

        Debug.Print("Fe2(SO4(5CuSO4·H2O)2)3·6H2O mass: " + formula.mass.ToString)

        formula = New clsChemicalFormula("AlO2{-}")
        Debug.Print(formula.electron)


        Dim element As clsElement = clsElementManager.instance.element("Cu")
        Debug.Print(element.meltingPoint.temperatureExpression)
        clsTemperatureManager.instance.expressionMode = enumTemperatureExpressionMode.C
        Debug.Print(element.meltingPoint.temperatureExpression)
        element = clsElementManager.instance.element("Fe")
        Debug.Print(element.meltingPoint.temperatureExpression)


        Dim ee As New clsChemicalEquation("Fe=Fe{2+}+e{-}")
        ee.balance()

    End Sub
End Class
