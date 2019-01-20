namespace TruckTour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = int.Parse(Console.ReadLine());

            var kilometers = new Queue<int>();

            var petrol = new Queue<int>();

            for (int i = 0; i < input; i++)
            {
                var station = Console.ReadLine().
                    Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                petrol.Enqueue(station[0]);
                kilometers.Enqueue(station[1]);

               
            }
            for (int k = 0; k < kilometers.Count; k++)
            {
                bool finish = IsFinish(kilometers, petrol);

                if (finish)
                {
                    Console.WriteLine(k);
                    break;
                }
                var curentPetrol = petrol.Dequeue();
                var curenKilometer = kilometers.Dequeue();

                petrol.Enqueue(curentPetrol);
                kilometers.Enqueue(curenKilometer);
            }
        }

        private static bool IsFinish(Queue<int> kilometers, Queue<int> petrol)
        {
            bool finish = true;
            var fuelLeft = 0;
            for (int i = 0; i < kilometers.Count; i++)
            {
                
                var curentKilometer = kilometers.Dequeue();
                var curentFuel = petrol.Dequeue();
                fuelLeft += curentFuel-curentKilometer;

                if (fuelLeft < 0 )
                {
                    finish = false;
                }
                kilometers.Enqueue(curentKilometer);
                petrol.Enqueue(curentFuel);
                
            }
            return finish;
        }
    }
}
