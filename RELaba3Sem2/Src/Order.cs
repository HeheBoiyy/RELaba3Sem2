using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RELaba3Sem2.Src
{
    public class Order
    {
        public Address ?Destination { get; set; }
        public Address ?Departure { get; set; }
        public bool NeedChildSeat { get; set; }
        public double Distance { get; set; }
    }
}
