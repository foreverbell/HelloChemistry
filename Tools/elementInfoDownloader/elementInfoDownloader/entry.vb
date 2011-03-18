
'
' Robot for helloChemistry to download element information on It's element.
' Written by ForeverBell on Mar 17, 2011.
'

Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Net
Imports System.Math

Module entry

    Private Structure elementType
        Dim index As Integer
        Dim weight As Double
        Dim symbol As String
        Dim name As String
    End Structure

    Private element(112) As elementType

    Private Function formatNumber(ByVal num As Integer) As String
        Return Format(num, "000")
    End Function

    Private Function readHtml(ByVal url As String) As String
        Dim response As HttpWebResponse
        Dim reader As StreamReader
        Dim result As String
        Dim request As HttpWebRequest = HttpWebRequest.Create(url)

        With request
            .Method = "GET"
            .Timeout = 20000
            .UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; Trident/4.0; QQWubi 133; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; CIBA; InfoPath.2)"
            response = .GetResponse
        End With

        reader = New StreamReader(response.GetResponseStream, System.Text.Encoding.UTF8)

        With reader
            result = .ReadToEnd
            .Close()
            .Dispose()
        End With

        Return result
    End Function

    Sub Main()
        Dim streamToWrite As New StreamWriter("symbol.txt", False)
        Dim streamToWriteWeight As New StreamWriter("weight.txt", False)

        For i As Integer = 1 To 112

            Dim reg As New Regex("<p id=" + """" + "boxchemicalsymbol" + """" + ">([a-zA-Z+]+)</p><p id=" + """" + "boxelementname" + """" + ">([a-zA-Z+]+)</p><p id=" + """" + "boxatomicmass" + """" + ">([0-9/.+]+)</p>", RegexOptions.Singleline)
            Dim match As Match = reg.Match(readHtml("http://education.jlab.org/itselemental/ele" + formatNumber(i) + ".html"))

            With element(i)
                .index = i
                .symbol = match.Groups(1).ToString
                .name = match.Groups(2).ToString
                If (.symbol = "Cl") Then
                    .weight = 35.5
                Else
                    .weight = Round(Val(match.Groups(3).Value), 0)
                End If

                Threading.Thread.Sleep(1000)

                Console.Write("Processing element " + i.ToString + ": " + .symbol + " " + .weight.ToString + " " + .name)
                Console.WriteLine()

                streamToWrite.Write(.symbol + " " + .name)
                streamToWrite.WriteLine()
                streamToWrite.Flush()

                streamToWriteWeight.Write(.weight.ToString)
                streamToWriteWeight.WriteLine()
                streamToWriteWeight.Flush()

            End With
        Next
    End Sub

End Module
