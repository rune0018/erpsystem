using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPsystem
{
    class Costumor
    {
        public int ID { get; set; }
        public int Costumornumber { get; set; }
        public int PersonalID { get; set; }
        public int LatestOrderID { get; set; }
        public DateTime LatestOrderDate { get; set; }
    }
}
