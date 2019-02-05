namespace _05_DateModifier
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var firstInput = Console.ReadLine().Split().Select(int.Parse).ToList();
            var secondInput = Console.ReadLine().Split().Select(int.Parse).ToList();
            

            var firstDate = new DateModifier(firstInput[0], firstInput[1], firstInput[2]);
            var secondDate = new DateModifier(secondInput[0], secondInput[1], secondInput[2]);
            
            var result = firstDate.GetDifference(firstDate, secondDate);
            Console.WriteLine(result);
        }
    }
}
