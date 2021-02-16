
namespace WebApp
{
    public class ServerSide
    {
        public string GetLocalFiles(string Paramaters)
        {
            // MsgBox("GetLocalFiles-Paramaters:" + Paramaters)
            return "['test','test2']";
        }

        public string SomethingElse(string Paramaters)
        {
            // MsgBox("SomethingElse-Paramaters:" + Paramaters)
            return "SomethingElse";
        }
    }
}