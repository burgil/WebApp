Public Class ServerSide
    Function GetLocalFiles(Paramaters As String) As String
        'MsgBox("GetLocalFiles-Paramaters:" + Paramaters)
        Return "['test','test2']"
    End Function
    Function SomethingElse(Paramaters As String) As String
        'MsgBox("SomethingElse-Paramaters:" + Paramaters)
        Return "SomethingElse"
    End Function
End Class
