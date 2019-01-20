namespace _07_HotPotato
{
    using System;
    using System.Collections.Generic;

    public class HotPotato
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var number = int.Parse(Console.ReadLine());
            var children = new Queue<string>(input);
            var count = 1;

            while (children.Count > 1)
            {
                var curentChild = children.Dequeue();
                if (count % number != 0)
                {
                    children.Enqueue(curentChild);
                }
                else
                {
                    Console.WriteLine($"Removed {curentChild}");
                }
                count++;

            }
            Console.WriteLine($"Last is {children.Dequeue()}");
        }
    }
}
