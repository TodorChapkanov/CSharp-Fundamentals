namespace _04_Telephony
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var phoneNumbers = Console.ReadLine().Split();
            var websites = Console.ReadLine().Split();
            var smartphone = new SmartPhone();

            foreach (var number in phoneNumbers)
            {
                smartphone.AddPhoneNumber(number);
            }

            foreach (var website in websites)
            {
                smartphone.AddWebsite(website);
            }

            Console.Write(smartphone.Calling());
            Console.Write(smartphone.Browsing());

        }
    }
}
