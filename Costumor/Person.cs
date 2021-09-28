using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPsystem.Costumor
{
    class Person
    {
        public static string PersonalId { get; set; }
        public static string FirstName { get; set; }
        public static string LastName { get; set; }
        public static Address Address { get; set; }
        public static List<Contactinfo> Contactinfos { get; set; }
    }
}
