namespace _10_PredicateParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PredicateParty
    {
        public static void Main()
        {
            var guests = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();


            string line;
            while ((line = Console.ReadLine()) != "Party!")
            {
                var splitedLine = line.Split();
                var command = splitedLine[0];
                var condition = splitedLine[1];
                var words = splitedLine[2];

                if (command == "Double")
                {
                    guests = GetDoubleNames(guests, condition, words);
                }
                else if (command == "Remove")
                {
                    guests = RemoveGuests(guests, condition, words);
                }


            }
            if (guests.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", guests)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }

        }
        
        private static List<string> RemoveGuests(List<string> guests, string condition, string words)
        {
            if (condition == "StartsWith")
            {
                guests.RemoveAll(n => n.StartsWith(words));


            }
            else if (condition == "EndWith")
            {
                guests.RemoveAll(n => n.EndsWith(words));

            }
            else if (condition == "Length")
            {
               guests.RemoveAll(n => n.Length == int.Parse(words));
            }
            return guests;
        }

        private static List<string> GetDoubleNames(List<string> guests, string condition, string words)
        {
            
            var list = new List<string>();

            
            if (condition == "StartsWith")
            {
                list = guests.FindAll(n => n.StartsWith(words));
                guests.AddRange(list);
                   
               

            }
            else if (condition == "EndsWith")
            {
                list = guests.FindAll(n => n.EndsWith(words));
                guests.AddRange(list);
                

            }
            else if (condition == "Length")
            {
                list = guests.FindAll(n => n.Length == int.Parse(words));
                guests.AddRange(list);

               
            }
            
            
            return guests;
        }

      
    }
}
