namespace _04_FastFood
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FastFood
    {
        public static void Main()
        {
            var totalFood = int.Parse(Console.ReadLine());
            var ordersInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var orders = new Queue<int>(ordersInput);
            var biggestOrder = int.MinValue;

            for (int i = 0; i < ordersInput.Length; i++)
            {
                var curentOrder = orders.Peek();

                if (curentOrder > biggestOrder)
                {
                    biggestOrder = curentOrder;
                }
                if (curentOrder > totalFood)
                {
                    Console.WriteLine($"{biggestOrder}");
                    Console.WriteLine($"Orders left: {string.Join(' ',orders)}");
                    return;
                }
                orders.Dequeue();
                totalFood -= curentOrder;

            }
            
                Console.WriteLine($"{biggestOrder}");
                Console.WriteLine("Orders complete");

        }
    }
}
