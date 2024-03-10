using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RELaba3Sem2.Src
{
    public class TaxiDriver
    {
        public string? Name;

        public Tuple<double, double>? CurrentLocation;

        public bool IsFree;

        public Car? Car;

        public double ball;

        public delegate void NotificationOfDriver();

        public event NotificationOfDriver ?RespondedToOrder;

        public ArgsOfTaxiOrder ?ArgsOfTaxiOrder;

        private int MaxDistant = 40;

        public void GoToOrder(ArgsOfTaxiOrder argsOfTaxiOrder)
        {
            double distance = Math.Sqrt(Math.Pow(CurrentLocation.Item1 - argsOfTaxiOrder.Order.Destination.Coordinates.Item1, 2) + Math.Pow(CurrentLocation.Item2 - argsOfTaxiOrder.Order.Destination.Coordinates.Item2, 2));

            if (IsFree && (argsOfTaxiOrder.Order.NeedChildSeat & Car.ChildSeat | argsOfTaxiOrder.Order.NeedChildSeat == false) & distance < MaxDistant)
            {
                RespondedToOrder?.Invoke();
            }
        }
    }
}
