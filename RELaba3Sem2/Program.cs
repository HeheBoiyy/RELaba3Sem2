using RELaba3Sem2.Src;

namespace RELaba3Sem2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            TaxiAggregator aggregator = new TaxiAggregator();
            Customer customer = new Customer() { Name = "ARINA HLOVOPA KOTORAYA HOCHET DOMOI" };
            Address destination = new Address() { Coordinates = new Tuple<double, double>(89, 100), House = 23, Street = "Свободный проспект" }; // Первый Кастомер
            Address depurture = new Address() { Coordinates = new Tuple<double, double>(120, 120), House = 10, Street = "Академика Киренского" };
            TaxiDriver driver1 = new TaxiDriver()
            {
                ball = 100,
                Car = new Car() { Brand = "Toyota", ChildSeat = true, Number = "К324ВЫ124" },
                IsFree = true,
                Name = "Timurka",
                CurrentLocation = new Tuple<double, double>(70, 100)
            };
            TaxiDriver driver2 = new TaxiDriver()
            {
                ball = 120,
                Car = new Car() { Brand = "Rolls-Royce", ChildSeat = true, Number = "А001АА124" },
                IsFree = true,
                Name = "Katysha",
                CurrentLocation = new Tuple<double, double>(89, 102)
            };
            TaxiDriver driver3 = new TaxiDriver()
            {
                ball = 120,
                Car = new Car() { Brand = "Land Rover", ChildSeat = false, Number = "Х004ХХ197" },
                IsFree = true,
                Name = "David",
                CurrentLocation = new Tuple<double, double>(89, 100)
            };
            aggregator.AddNewTaxiDriver(driver1);
            aggregator.AddNewTaxiDriver(driver2);
            aggregator.AddNewTaxiDriver(driver3);

            aggregator.CreateAnOrder(customer, destination, depurture, true);
            Customer customer1 = new Customer() { Name = "Уставшая Катя которая хочет домой" };
            Address destination1 = new Address() { Coordinates = new Tuple<double, double>(102, 89), House = 23, Street = "Свободный проспект" }; // Второй Кастомер
            Address depurture1 = new Address() { Coordinates = new Tuple<double, double>(113, 123), House = 10, Street = "Академика Киренского" };
            aggregator.CreateAnOrder(customer1 , destination1, depurture1, true);
        }
    }
}
