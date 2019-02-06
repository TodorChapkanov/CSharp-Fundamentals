namespace _10_CarSalesman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {

            var allCars = new List<Car>();
            var allEngines = new List<Engine>();
            var enginesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < enginesCount; i++)
            {
                var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var model = input[0];
                var power = int.Parse(input[1]);

                if (input.Length == 2)
                {
                    var engine = new Engine(model, power);

                    allEngines.Add(engine);
                }
                
                else if (input.Length == 3)
                {
                    int displacement;
                    int.TryParse(input[2], out displacement);
                    if (displacement > 0)
                    {
                        var engine = new Engine(model, power, displacement);
                        allEngines.Add(engine);
                    }
                    else
                    {
                        var effisiency = input[2];
                        var engine = new Engine(model, power, effisiency);
                        allEngines.Add(engine);
                    }

                }
                else
                {
                    var displacement = int.Parse(input[2]);
                    var effisiency = input[3];
                    var engine = new Engine(model, power, displacement, effisiency);
                    allEngines.Add(engine);
                }
            }

            var carCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carCount; i++)
            {
                var line = Console.ReadLine().Split(new[] { ' '}, StringSplitOptions.RemoveEmptyEntries);

                var carModel = line[0];
                var engineModel = line[1];
                var engine = allEngines.FirstOrDefault(e => e.Model == engineModel);
                
                if (line.Length == 2)
                {
                    var car = new Car(carModel, engine);
                    allCars.Add(car);
                }
                else if (line.Length == 3)
                {
                    if (char.IsDigit(line[2][1]))
                    {
                        var weight = int.Parse(line[2]);
                        var car = new Car(carModel, engine, weight);
                        allCars.Add(car);
                    }
                    else
                    {
                        var color = line[2];
                        var car = new Car(carModel, engine, color);
                        allCars.Add(car);
                    }
                }
                else
                {
                    var weight = int.Parse(line[2]);
                    var color = line[3];
                    var car = new Car(carModel, engine, weight, color);
                    allCars.Add(car);
                }
            }
            foreach (var item in allCars)
            {
                Console.Write(item);
            }

        }
    }
}
