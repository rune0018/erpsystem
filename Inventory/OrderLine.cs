using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPsystem
{
    public class OrderLine
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int ItemID { get; set; }
        public int Amount { get; set; }
    }
}
