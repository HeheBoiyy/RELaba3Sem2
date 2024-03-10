using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RELaba3Sem2.Src
{
    public class TaxiAggregator
    {
        private List<Customer> customers = new List<Customer>();
        private List<TaxiDriver> taxiDrivers = new List<TaxiDriver>();
        private List<TaxiDriver> taxiDriversTemp = new List<TaxiDriver>();
        public void CreateAnOrder(Customer customer, Address destination, Address departure, bool childSeat)
        {
            foreach (TaxiDriver taxiDriver in taxiDrivers)
            {
                customer.IWantToTakeATaxi += taxiDriver.GoToOrder; // Бархатная подписочка на событие
            }

            ArgsOfTaxiOrder argsOfTaxiOrder = new ArgsOfTaxiOrder(new Order()
            {
                Destination = destination,
                Departure = departure,
                NeedChildSeat = childSeat,
                Distance = Math.Sqrt(Math.Pow(destination.Coordinates.Item1 - departure.Coordinates.Item1, 2) +
                Math.Pow(destination.Coordinates.Item2 - departure.Coordinates.Item2, 2))
            });

            customer.TempOrder = argsOfTaxiOrder.Order; // Указываем что заказ кустомера = заказу выше

            customer.TakeATaxi(); // Вызываем метод TakeATaxi-> Срабатывает ивент IWantToTakeATaxi

            if (taxiDriversTemp.Count > 0)
            {
                double maxballs = -1;
                TaxiDriver tDriver = new();
                foreach (var driver in taxiDriversTemp)
                {
                    if (driver.ball > maxballs)
                    {
                        tDriver = driver;
                        maxballs = driver.ball;
                    }
                }
                Console.WriteLine($"Водитель {tDriver.Name} на {tDriver.Car.Brand} с гос. номером {tDriver.Car.Number}\n" +
                    $" отправилась на заказ: \n от {destination.Street} {destination.House} {destination.Coordinates.Item1} " +
                    $"{destination.Coordinates.Item2}\n до {departure.Street} {departure.House} {departure.Coordinates.Item1} " +
                    $"{departure.Coordinates.Item2}\n");

                tDriver.ball += customer.TempOrder.Distance; // Начисляем баллы

                taxiDriversTemp.Clear();
                RemoveTaxiDriver(tDriver);

            }
            else
            {
                Console.WriteLine("Свободных таксистов нет");
            }


        }
        public void AddNewTaxiDriver(TaxiDriver driver)
        {
            driver.RespondedToOrder += () => taxiDriversTemp.Add(driver); // Подписываемся на событие и добавляем данного водилу как потенциального исполнителя заказа
            taxiDrivers.Add(driver);
        }

        public void RemoveTaxiDriver(TaxiDriver driver)
        {
            
            taxiDrivers.Remove(driver);
            taxiDriversTemp.Remove(driver);
            
        }
    }
}
