Module ServerParser
    Function ParseServerJS(location As String)
        Dim Server As String = IO.File.ReadAllText(location)
        Dim Actions As List(Of String) = New List(Of String)
        Dim FuncHandler As New ServerSide
        For Each _Method As Reflection.MethodInfo In FuncHandler.GetType().GetMethods()
            If _Method.DeclaringType.Name <> "ServerSide" Then Continue For
            Actions.Add(_Method.Name)
        Next
        For Each Action In Actions
            While Server.Contains(Action + "(")
                Dim Paramaters As String = GetStringBetween(Server, Action + "(", ")")
                If Paramaters = "ERROR" Then Continue For
                Server = Server.Replace(Action + "(" + Paramaters + ")", CStr(CallByName(FuncHandler, Action, Microsoft.VisualBasic.CallType.Method, Paramaters)))
            End While
        Next
        Return Server
    End Function
End Module
