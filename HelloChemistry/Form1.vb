
Imports HelloChemistry.chemicalFormula
Imports HelloChemistry.element
Imports HelloChemistry.temperature
Imports HelloChemistry.chemicalEquation
Imports HelloChemistry.chemicalFormula.parser
Imports HelloChemistry.chemicalEquation.parser

Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim f As clsChemicalFormula = clsChemicalFormulaParser.instance.parse("e{-}")

        Dim formula As clsChemicalFormula = clsChemicalFormulaParser.instance.parse("Fe2(SO4(5CuSO4·H2O)2)3·6H2O")

        Debug.Print("Fe2(SO4(5CuSO4·H2O)2)3·6H2O mass: " + formula.mass.ToString)

        formula = clsChemicalFormulaParser.instance.parse("AlO2{-}")
        Debug.Print(formula.electron)


        Dim element As clsElement = clsElementManager.instance.element("Cu")
        Debug.Print(element.meltingPoint.temperatureExpression)
        clsTemperatureManager.instance.expressionMode = enumTemperatureExpressionMode.C
        Debug.Print(element.meltingPoint.temperatureExpression)
        element = clsElementManager.instance.element("Fe")
        Debug.Print(element.meltingPoint.temperatureExpression)


        Dim ee As clsChemicalEquation = clsChemicalEquationParser.instance.parse("Fe=Fe{2+}+e{-}")
        ee = ee.balance()
        Debug.Print(ee.strChemicalEquation)

        ee = clsChemicalEquationParser.instance.parse("FeS2+O2=Fe2O3+SO2")
        ee = ee.balance()
        Debug.Print(ee.strChemicalEquation)

        ee = clsChemicalEquationParser.instance.parse("Cu+HNO3=Cu(NO3)2+NO+H2O")
        ee = ee.balance()
        Debug.Print(ee.strChemicalEquation)
    End Sub
End Class
