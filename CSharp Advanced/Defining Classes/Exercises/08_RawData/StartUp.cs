namespace _08_RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var count = int.Parse(Console.ReadLine());

            var allCars = new List<Car>();

           

            for (int i = 0; i < count; i++)
            {
                var line = Console.ReadLine().Split();

                var model = line[0];
                var speed = int.Parse(line[1]);
                var power = int.Parse(line[2]);
                var cargoWeight = int.Parse(line[3]);
                var cargoType = line[4];
                var firstTirePressure = double.Parse(line[5]);
                var firsTireYear = int.Parse(line[6]);
                var secongTirePressure = double.Parse(line[7]);
                var secondTireYear = int.Parse(line[8]);
                var thirdTirePressur = double.Parse(line[9]);
                var thirdTireYear = int.Parse(line[10]);
                var fourthTirePressur = double.Parse(line[11]);
                var fourthTireYear = int.Parse(line[12]);

                var engine = new Engine(speed, power);
                var cargo = new Cargo(cargoWeight, cargoType);

                var tires = new Tire[]
                {
                    new Tire(firstTirePressure,firsTireYear),
                    new Tire(secongTirePressure,secondTireYear),
                    new Tire(thirdTirePressur,thirdTireYear),
                    new Tire(fourthTirePressur, fourthTireYear)
                };

                var car = new Car(model, engine, cargo, tires);

                allCars.Add(car);
            }
            var input = Console.ReadLine();

            if (input == "fragile")
            {
                 allCars.Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1 )).ToList().ForEach(m => Console.WriteLine(m.Model));
               
            }
            else
            {
                allCars.Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250).ToList().ForEach(m => Console.WriteLine(m.Model));
                
            }
        }
    }
}
