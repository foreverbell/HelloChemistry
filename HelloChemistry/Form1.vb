
Imports HelloChemistry.chemicalFormula
Imports HelloChemistry.element
Imports HelloChemistry.temperature
Imports HelloChemistry.fraction
Imports HelloChemistry.algorithm
Imports HelloChemistry.chemicalEquation

Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim formula As New clsChemicalFormula("Fe2(SO4(5CuSO4·H2O)2)3·6H2O")

        Debug.Print("Fe2(SO4(5CuSO4·H2O)2)3·6H2O mass: " + formula.mass.ToString)


        Dim element As clsElement = clsElementManager.instance.element("Cu")
        Debug.Print(element.meltingPoint.temperatureExpression)
        clsTemperatureManager.instance.expressionMode = enumTemperatureExpressionMode.C
        Debug.Print(element.meltingPoint.temperatureExpression)
        element = clsElementManager.instance.element("Fe")
        Debug.Print(element.meltingPoint.temperatureExpression)


        Dim f1 As New clsFraction(3, 5)
        Dim f2 As New clsFraction(1, 2)
        Dim f3 As clsFraction = (f1 / f2)

        Dim array(3, 4) As clsFraction
        Dim o() As clsFraction

        Dim value(,) As Integer =
            {
                {0, 0, 0, 0, 0},
                {0, 2, 1, -1, 8},
                {0, -3, -1, 2, -11},
                {0, -2, 1, 2, -3}
            }


        For i As Integer = 1 To 3
            For j As Integer = 1 To 4
                array(i, j) = New clsFraction(value(i, j))
            Next
        Next

        clsGaussJordanElimination.gaussJordanElimination(array, o)

        Dim a() As Integer
        Dim ee As New clsChemicalEquation("FeS2+O2=Fe2O3+SO2")
        ee.balance(a)
    End Sub
End Class
