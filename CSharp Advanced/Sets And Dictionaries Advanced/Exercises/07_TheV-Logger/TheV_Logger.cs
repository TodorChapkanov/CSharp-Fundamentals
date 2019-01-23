namespace _07_TheV_Logger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TheV_Logger
    {
        public static void Main()
        {
            var vloggerAndFollowers = new Dictionary<string, List<string>>();
            var vloggerAndCountFollowing = new Dictionary<string, int>();

            

            while (true)
            {
                var line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (line[0] == "Statistics")
                {
                    break;
                }
                var loggerName = line[0];
                var action = line[1];
                var followName = line[2];

                if (action == "joined")
                {
                    if (!vloggerAndFollowers.ContainsKey(loggerName))
                    {
                        vloggerAndFollowers.Add(loggerName, new List<string>());
                        vloggerAndCountFollowing.Add(loggerName, 0);
                    }

                }
                if (action == "followed")
                {
                    if (vloggerAndFollowers.ContainsKey(loggerName) && vloggerAndFollowers.ContainsKey(followName) && 
                        loggerName != followName && !vloggerAndFollowers[followName].Contains(loggerName))
                    {

                        vloggerAndFollowers[followName].Add(loggerName);
                        vloggerAndCountFollowing[loggerName]++;
                    }

                }


                
            }
            var count = 1;
            Console.WriteLine($"The V-Logger has a total of {vloggerAndFollowers.Keys.Count()} vloggers in its logs.");
            foreach (var logger in vloggerAndFollowers
                .OrderByDescending(v => v.Value.Count())
                .ThenBy(n => n.Key.Count())
                .ThenBy(n => vloggerAndCountFollowing[n.Key]))
            {
                
                if (count == 1)
                {
                    Console.WriteLine($"{count}. { logger.Key} : { logger.Value.Count()} followers, {vloggerAndCountFollowing[logger.Key]} following");
                    foreach (var item in logger.Value.OrderBy(n => n))
                    {
                        
                        Console.WriteLine("*  " + item);
                    }
                }
                else
                {
                    Console.WriteLine($"{count}. { logger.Key} : { vloggerAndFollowers[logger.Key].Count()} followers, { vloggerAndCountFollowing[logger.Key]} following");
                }
                count++;
                
            }
        }
    }
}
