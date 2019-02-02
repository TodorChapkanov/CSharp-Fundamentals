namespace _07_PredicateForNames
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PredicateForNames
    {
        public static void Main()
        {
            var lenght = int.Parse(Console.ReadLine());

             Console.ReadLine()
                .Split()
                .Where(w => w.Length <= lenght)
                .ToList()
                .ForEach(w => Console.WriteLine(w));

            
                
        }
    }
}
