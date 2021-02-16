Module Generic
    Public Function GetStringBetween(ByVal InputText As String, ByVal starttext As String, ByVal endtext As String) As String
        Dim startPos As Integer
        Dim endPos As Integer
        Dim lenStart As Integer
        startPos = InputText.IndexOf(starttext, StringComparison.CurrentCultureIgnoreCase)
        If startPos >= 0 Then
            lenStart = startPos + starttext.Length
            endPos = InputText.IndexOf(endtext, lenStart, StringComparison.CurrentCultureIgnoreCase)
            If endPos >= 0 Then
                Return InputText.Substring(lenStart, endPos - lenStart)
            End If
        End If
        Return "ERROR"
    End Function
End Module
