
'
' Robot for helloChemistry to download element electron shell on wikipedia.
' Written by ForeverBell on Mar 17, 2011.
'

Imports System.Net
Imports System.IO
Imports System.Text.RegularExpressions

Module entry

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
        Dim streamToRead As New StreamReader("symbol.txt", False)
        Dim streamToWrite As New StreamWriter("shell.txt", False)
        Dim elementName As String

        For i As Integer = 1 To 112
            elementName = Split(streamToRead.ReadLine(), " ")(1)

            Dim reg1 As New Regex("<div class=" + """" + "fullImageLink" + """" + " id=" + """" + "file" + """" + "><a href=" + """" + "(.*?)" + """" + ">", RegexOptions.Singleline)
            Dim match1 As Match = reg1.Match(readHtml("http://en.wikipedia.org/wiki/File:Electron_shell_" + formatNumber(i) + "_" + elementName + ".svg"))

            Dim reg2 As New Regex("<text x=" + """" + "900" + """" + " y=" + """" + "-1000" + """" + " text-anchor=" + """" + "end" + """" + ">(.*?)</text>", RegexOptions.Singleline)
            Dim match2 As Match = reg2.Match(readHtml(match1.Groups(1).ToString))

            Threading.Thread.Sleep(1000)

            Console.Write("Processing element " + i.ToString + ": " + elementName + " " + match2.Groups(1).ToString )
            Console.WriteLine()

            streamToWrite.Write(match2.Groups(1))
            streamToWrite.WriteLine()
            streamToWrite.Flush()
        Next
    End Sub

End Module
