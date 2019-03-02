namespace _04_HotelReservation
{
    using System;

    public class PriceCalculator
    {
        public static decimal Calculate(string[] holiday)
        {
            var price = decimal.Parse(holiday[0]);
            var days = int.Parse(holiday[1]);
            var season = holiday[2];
            var discount = 0m;

            if (holiday.Length> 3)
            {
                var type = holiday[3];
                discount = (decimal)(int)Enum.Parse<Discount>(type) / 10;
            }
            var seasonPrice = (int)Enum.Parse<SeasonPrice>(season);
            var totalPrice = ((price * seasonPrice) * days) * (1-discount);
            return totalPrice;
        }
    }
}
