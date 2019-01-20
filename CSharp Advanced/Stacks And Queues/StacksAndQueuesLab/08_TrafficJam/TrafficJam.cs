namespace _08_TrafficJam
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TrafficJam
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());

            var cars = new Queue<string>();
            var sb = new StringBuilder();
            var coun = 0;

            while (true)
            {
                var curentCar = Console.ReadLine();
                if (curentCar == "end")
                {
                    Console.Write(sb);
                    Console.WriteLine($"{coun} cars passed the crossroads.");
                    break;
                }
                else if (curentCar == "green")
                {
                    var carsToPass = Math.Min(number, cars.Count);
                    for (int i = 0; i < carsToPass; i++)
                    {
                        sb.AppendLine($"{cars.Dequeue()} passed!");
                        coun++;
                    }
                    
                }
                else
                {
                    cars.Enqueue(curentCar);
                }
                
            }
        }
    }
}
