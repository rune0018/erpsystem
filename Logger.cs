using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ERPsystem
{
    class Logger
    {
        public static void logThis(string type,string text)
        {
            string message = "";
            message = string.Format("[{0}][{1}] {2}",
            DateTime.Now.ToString(),
            type,
            text);
            File.AppendAllText("../../../program.log", message+"\n");
        }
        public static void Info(string Text)
        {
            logThis("INFO", Text);
        }
        public static void Error(string Text)
        {
            logThis("ERROR", Text);
        }
       
    }
}
