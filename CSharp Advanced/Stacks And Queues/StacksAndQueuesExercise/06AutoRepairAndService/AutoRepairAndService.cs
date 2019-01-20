namespace _06AutoRepairAndService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var cars = new Queue<string>(input);
            var servedCars = new Stack<string>();
            var command = Console.ReadLine();
            var sb = new StringBuilder();
            while (true)
            {
                if (command == "End")
                {
                    if (cars.Count > 0)
                    {
                        sb.AppendLine($"Vehicles for service: {String.Join(", ", cars)}");
                    }
                    if (servedCars.Count > 0)
                    {
                        sb.AppendLine($"Served vehicles: {string.Join(", ", servedCars)}");
                    }
                    Console.Write(sb);
                    break;
                }

                else if(command == "History")
                {
                    sb.AppendLine(string.Join(", ", servedCars));
                }

                else if (command.Contains("CarInfo"))
                {
                    
                    bool served = IsServed(cars,command);
                    if (served)
                    {
                        sb.AppendLine("Still waiting for service.");
                    }
                    else
                    {
                        sb.AppendLine("Served.");
                    }
                }
                else if (command == "Service" && cars.Count > 0)
                {
                    var curentCar = cars.Dequeue();
                    sb.AppendLine($"Vehicle {curentCar} got served.");
                    servedCars.Push(curentCar);
                }
                command = Console.ReadLine();
            }
        }

        private static bool IsServed(Queue<string> cars, string command)
        {
            var curentCar = command.Split('-');
            string car = curentCar[1];
            return cars.Contains(car);
        }
    }
}

