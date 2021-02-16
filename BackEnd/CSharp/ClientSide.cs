namespace WebApp
{
    class ClientSide
    {
        public string DeleteFile(string Paramaters)
        {
            // MsgBox("DeleteFile-Paramaters:" + Paramaters)
            return "alert('Deleted File: " + Paramaters + "');";
        }

        public string SomethingElse(string Paramaters)
        {
            // MsgBox("SomethingElse-Paramaters:" + Paramaters)
            return "SomethingElse";
        }
    }
}
