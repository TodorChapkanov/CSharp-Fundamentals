namespace 01_BoxOfT
{
    using System;


    public class StartUp
    {
        public static void Main()
        {
            var numbers = new Box<int>();

            numbers.Add(5);
            numbers.Add(10);
            numbers.Add(20);
            Console.WriteLine(numbers.Remove() == 20);

            numbers.ForEach(c => Console.WriteLine(c));
            Console.WriteLine(numbers.Count);
        }
    }
}
