using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPsystem
{
    public class Order
    {
        public int ID { get; set; }
        public int CosutormorID { get; set; }
        public DateTime date = DateTime.Now;
    }
}
