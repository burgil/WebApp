using System;

namespace WebApp
{
    static class Generic
    {
        public static string GetStringBetween(string InputText, string starttext, string endtext)
        {
            int startPos;
            int endPos;
            int lenStart;
            startPos = InputText.IndexOf(starttext, StringComparison.CurrentCultureIgnoreCase);
            if (startPos >= 0)
            {
                lenStart = startPos + starttext.Length;
                endPos = InputText.IndexOf(endtext, lenStart, StringComparison.CurrentCultureIgnoreCase);
                if (endPos >= 0)
                {
                    return InputText.Substring(lenStart, endPos - lenStart);
                }
            }
            return "ERROR";
        }
    }
}