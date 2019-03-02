namespace _04_HotelReservation
{
    using System;
    
    public class Startup
    {
        public static void Main()
        {
            var holiday = Console.ReadLine().Split();

            var priceForHotel = PriceCalculator.Calculate(holiday);

            Console.WriteLine($"{priceForHotel:f2}");
        }
    }
}
