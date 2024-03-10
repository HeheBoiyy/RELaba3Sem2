using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RELaba3Sem2.Src
{
    public class Customer
    {
        public string ?Name;
        public Order ?TempOrder;
        public delegate void NotificationOfCustomer(ArgsOfTaxiOrder order);
        public event NotificationOfCustomer IWantToTakeATaxi;
        public void TakeATaxi()
        {
            IWantToTakeATaxi?.Invoke(new ArgsOfTaxiOrder(TempOrder));
        }

    }
}
