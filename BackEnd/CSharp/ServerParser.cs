using System.Collections.Generic;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace WebApp
{
    static class ServerParser
    {
        public static object ParseServerJS(string location)
        {
            string Server = System.IO.File.ReadAllText(location);
            var Actions = new List<string>();
            var FuncHandler = new ServerSide();
            foreach (System.Reflection.MethodInfo _Method in FuncHandler.GetType().GetMethods())
            {
                if (_Method.DeclaringType.Name != "ServerSide")
                    continue;
                Actions.Add(_Method.Name);
            }

            foreach (var Action in Actions)
            {
                while (Server.Contains(Action + "("))
                {
                    string Paramaters = Generic.GetStringBetween(Server, Action + "(", ")");
                    if (Paramaters == "ERROR")
                        continue;
                    Server = Server.Replace(Action + "(" + Paramaters + ")", Conversions.ToString(Interaction.CallByName(FuncHandler, Action, CallType.Method, Paramaters)));
                }
            }

            return Server;
        }
    }
}