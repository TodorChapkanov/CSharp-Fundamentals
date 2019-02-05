namespace _07_SpeedRacing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var carCount = int.Parse(Console.ReadLine());

            var cars = new List<Car>();
            Car currentCar;



            for (int i = 0; i < carCount; i++)
            {
                var line = Console.ReadLine().Split();

                string model = line[0];
                double fuelAmount = double.Parse(line[1]);
                double fuelConsumption = double.Parse(line[2]);

                currentCar = new Car(model, fuelAmount, fuelConsumption);

                cars.Add(currentCar);
            }
            string[] input;
           
            while ((input = Console.ReadLine().Split())[0] != "End")
            {
                var model = input[1];
                var distance = double.Parse(input[2]);
                var curentCar = cars.FirstOrDefault(c => c.Model == model);
                try
                {
                    curentCar.CanDrive(distance);
                }
                catch (InvalidOperationException ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }

            cars.ForEach(c => Console.WriteLine(c));
        }
    }
}
