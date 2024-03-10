using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RELaba3Sem2.Src
{
    public class ArgsOfTaxiDriver
    {
        public TaxiDriver TaxiDriver;
        public ArgsOfTaxiDriver(TaxiDriver taxiDriver)
        {
            TaxiDriver = taxiDriver;
        }
    }
    public class ArgsOfTaxiOrder
    {
        public Order Order;
        public ArgsOfTaxiOrder(Order order)
        {
            Order = order;
        }
    }
}
