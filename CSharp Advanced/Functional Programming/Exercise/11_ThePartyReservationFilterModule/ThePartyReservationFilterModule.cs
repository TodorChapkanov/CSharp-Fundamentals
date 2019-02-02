namespace _11_ThePartyReservationFilterModule
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ThePartyReservationFilterModule
    {
        public static void Main()
        {
            var guests = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var guestsFilters = new List<string>();

            string line;
            var replacedInput = string.Empty;
            while ((line = Console.ReadLine()) != "Print")
            {
                var commands = line.Split(';');
                if (commands[0] == "Add filter")
                {
                   guestsFilters.Add(commands[1] + " " + commands[2]);
                }
                else if (commands[0] == "Remove filter")
                {
                    guestsFilters.Remove(commands[1] + " " + commands[2]);
                }
            }
            foreach (var filter in guestsFilters)
            {

                var splitedInput = filter.Split(' ',StringSplitOptions.RemoveEmptyEntries);
               
                
                    if (splitedInput.Contains("Starts"))
                    {
                        guests.RemoveAll(x => x.StartsWith(splitedInput[2]));
                    }
                    else if (splitedInput.Contains("Ends"))
                    {
                        guests.RemoveAll(x => x.EndsWith(splitedInput[2]));
                    }
                    else if (splitedInput.Contains("Contains"))
                    {
                        guests.RemoveAll(x => x.Contains(splitedInput[1]));
                    }
                    else if (splitedInput.Contains("Length"))
                    {
                        guests.RemoveAll(x => x.Length == int.Parse(splitedInput[1]));
                    }
            }
            if (guests.Any())
            {
                Console.WriteLine(string.Join(' ', guests));
            }
        }
    }

}