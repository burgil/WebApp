Public Class ClientSide
    Function DeleteFile(Paramaters As String) As String
        'MsgBox("DeleteFile-Paramaters:" + Paramaters)
        Return "alert('Deleted File: " + Paramaters + "');"
    End Function
    Function SomethingElse(Paramaters As String) As String
        'MsgBox("SomethingElse-Paramaters:" + Paramaters)
        Return "SomethingElse"
    End Function
End Class
