namespace _03_CustomMinFunction
{
    using System;
    using System.Linq;

    public class CustomMinFunction
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> getMinNumber = n => n.Min();

            Console.WriteLine(getMinNumber(numbers));


        }
    }
}