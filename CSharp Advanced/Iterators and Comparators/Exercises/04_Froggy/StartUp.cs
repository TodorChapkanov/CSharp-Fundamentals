namespace _04_Froggy
{
    using System;
    using System.Linq;

    public class StartUp
    {
       public static void Main(string[] args)
        {
            var path = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var jumps = new Lake(path);

            Console.WriteLine(string.Join(", ", jumps));
        }
    }
}
