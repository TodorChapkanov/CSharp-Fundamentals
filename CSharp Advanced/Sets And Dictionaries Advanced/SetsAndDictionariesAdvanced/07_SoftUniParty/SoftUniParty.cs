namespace _07_SoftUniParty
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class SoftUniParty
    {
        public static void Main()
        {
            var guestList = new HashSet<string>();
            var vipGuests = new HashSet<string>();
            var vipMatch = @"[0-9][A-Za-z0-9]{7}";
            while (true)
            {
                var line = Console.ReadLine();

                if (line == "PARTY")
                {
                    break;
                }

                var isVip = IsVipGuest(line, vipMatch);
                

                if (isVip)
                {
                    vipGuests.Add(line);
                }
                else
                {
                    guestList.Add(line);
                }

            }
            
            while (true)
            {
                var line = Console.ReadLine();
                if (line == "END")
                {
                    break;
                }

                var isVip = IsVipGuest(line, vipMatch);
                if (isVip)
                {
                    vipGuests.Remove(line);
                }
                else
                {
                    guestList.Remove(line);
                }
            }

            var sum = vipGuests.Count + guestList.Count;
            Console.WriteLine(sum);
            if (vipGuests.Count > 0 )
            {
                Console.WriteLine(string.Join(Environment.NewLine, vipGuests));
            }
            if (guestList.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, guestList));
            }

        }

        private static bool IsVipGuest(string line, string vipMatch)
        {
            var match = Regex.IsMatch(line, vipMatch);
            return match;
        }
    }
}
