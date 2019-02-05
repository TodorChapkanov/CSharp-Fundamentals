namespace _05_DateModifier
{
    using System;


    public class DateModifier
    {
        public DateModifier(int year, int month, int day)
        {
            this.Year = year;
            this.Month = month;
            this.Day = day;
        }

        public DateModifier()
        {
        }

        public int Year { get; set; }

        public int Month { get; set; }

        public int Day { get; set; }


        public int GetDifference(DateModifier firstDate, DateModifier secondDate)
        {
            var firstYear = firstDate.Year;
            var firstMonth = firstDate.Month;
            var firstDay = firstDate.Day;
            var first = new DateTime(firstYear, firstMonth, firstDay);

            var secondYear = secondDate.Year;
            var secondMonth = secondDate.Month;
            var secondDay = secondDate.Day;

            var second = new DateTime(secondYear, secondMonth, secondDay);

            var result = (int)Math.Abs((first - second).TotalDays);
            return result;
        }
    }
}
