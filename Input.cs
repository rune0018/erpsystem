using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPsystem
{
    class Input
    {
        public static int GetNumberFromUser(string hint)
        {
            Console.Write(hint + ": ");
            int svar;
            int.TryParse(Console.ReadLine(), out svar);
            return svar;
        }

        public static string GetStringFromUser(string hint)
        {
            Console.Write(hint + ": ");
            string svar = Console.ReadLine();
            return svar;
        }

        public static double GetDoubleFromUser(string hint)
        {
            Console.Write(hint + ": ");
            double awnser;
            double.TryParse(Console.ReadLine(), out awnser);
            return awnser;
        }
    }
}
