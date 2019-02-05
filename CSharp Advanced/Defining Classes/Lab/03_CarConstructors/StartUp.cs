namespace _03_CarConstructors
{
    using System;


    public class StartUp
    {
        public static void Main()
        {
            var make = Console.ReadLine();
            var model = Console.ReadLine();
            var year = int.Parse(Console.ReadLine());
            var fuelQuantity = int.Parse(Console.ReadLine());
            var fuelConsumption = int.Parse(Console.ReadLine());

            var firstCar = new Car();
            var secondCar = new Car(make, model, year);
            var thirdCar = new Car(make, model, year, fuelQuantity, fuelConsumption);
        }
    }
}
