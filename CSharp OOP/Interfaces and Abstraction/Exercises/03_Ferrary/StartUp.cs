namespace _03_Ferrary
{
    using System;


    public class StartUp
    {
       public static void Main()
        {
            var driverName = Console.ReadLine();
            IFerrary ferrary = new Ferrary(driverName);

            Console.WriteLine(ferrary);
        }
    }
}
