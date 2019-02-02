namespace _04AddVAT
{
    using System;
    using System.Linq;

    public class AddVAT
    {
        public static void Main()
           => Console.ReadLine()
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(d => d * 1.2)
                .ToList()
                .ForEach(d => Console.WriteLine($"{d:f2}"));
    }
}
