namespace _01__RhombusOfStars
{
    using System;


   public class Program
    {
      public  static void Main()
        {
            var number = int.Parse(Console.ReadLine());

            PrintTopSide(number);
            PrintBottomSide(number);
        }

        private static void PrintTopSide(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                Console.Write(new string(' ', number - i));
                for (int row = 0; row < i; row++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
        }

        private static void PrintBottomSide(int number)
        {
            for (int i = number-1; i >= 1; i--)
            {
                Console.Write(new string(' ', number - i));
                for (int row = i; row >= 1; row--)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
            
        }
    }
}
