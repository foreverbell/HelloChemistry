
Imports HelloChemistry.chemicalEquation.heat
Imports HelloChemistry.formulaToken
Imports HelloChemistry.chemicalFormula
Imports HelloChemistry.element
Imports HelloChemistry.temperature
Imports HelloChemistry.chemicalEquation
Imports HelloChemistry.chemicalFormula.parser
Imports HelloChemistry.chemicalEquation.parser
Imports HelloChemistry.matterState.state

Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim formula As clsChemicalFormula = clsChemicalFormulaParser.instance.parse("Fe2(SO4(5CuSO4)2)3(aq)")

        Debug.Print("Fe2(SO4(5CuSO4)2)3 mass: " + formula.mass.ToString)

        formula = clsChemicalFormulaParser.instance.parse("3AlO2{-}")
        Debug.Print(formula.electron)


        Dim element As clsElement = clsElementManager.instance.element("Cu")
        Debug.Print(element.meltingPoint.temperatureExpression)
        clsTemperatureManager.instance.expressionMode = enumTemperatureExpressionMode.C
        Debug.Print(element.meltingPoint.temperatureExpression)
        element = clsElementManager.instance.element("Fe")
        Debug.Print(element.meltingPoint.temperatureExpression)


        Dim ee As clsChemicalEquation = clsChemicalEquationParser.instance.parse("Fe=Fe{2+}+e{-}")
        ee = ee.balance()
        Debug.Print(ee.strEquation)

        ee = clsChemicalEquationParser.instance.parse("FeS2+O2=Fe2O3+SO2")
        ee = ee.balance()
        Debug.Print(ee.strEquation)

        ee = clsChemicalEquationParser.instance.parse("3Cu + 8HNO3 = 3Cu(NO3)2 + 2NO + 4H2O")
        Debug.Print(clsChemicalEquationBalancedChecker.instance.checkBalanced(ee))
        ee = ee.balance()


        clsHeatEquationSolver.instance.addEquationToSourceList(New clsHeatEquation(clsChemicalEquationParser.instance.parse("N2(g)+2O2(g)=2NO2(g)"), 67.7))
        clsHeatEquationSolver.instance.addEquationToSourceList(New clsHeatEquation(clsChemicalEquationParser.instance.parse("N2H4(g)+O2(g)=N2(g)+2H2O(g)"), -534.0))
        clsHeatEquationSolver.instance.setDestinationEquation(clsChemicalEquationParser.instance.parse("N2H4(g)+NO2(g)=N2(g)+H2O(g)"))
        Debug.Print(clsHeatEquationSolver.instance.solve().strEquation)

        clsHeatEquationSolver.instance.clearSourceEquationList()

        clsHeatEquationSolver.instance.addEquationToSourceList(New clsHeatEquation(clsChemicalEquationParser.instance.parse("CH4(g)+H2O(g)=CO(g)+3H2(g)"), 206.2))
        clsHeatEquationSolver.instance.addEquationToSourceList(New clsHeatEquation(clsChemicalEquationParser.instance.parse("CH4(g)+CO2(g)=2CO(g)+2H2(g)"), 247.4))
        clsHeatEquationSolver.instance.addEquationToSourceList(New clsHeatEquation(clsChemicalEquationParser.instance.parse("2H2S(g)=2H2(g)+S2(g)"), 196.8))
        clsHeatEquationSolver.instance.setDestinationEquation(clsChemicalEquationParser.instance.parse("CH4(g)+H2O(g)=CO2(g)+H2(g)"))
        Debug.Print(clsHeatEquationSolver.instance.solve().strEquation)
    End Sub
End Class
