using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{

    public class Potato
    {
      public  static void Main()
        {
            var input  = long.Parse(Console.ReadLine());
            var safe = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bagWithТreasures = new Dictionary<string, Dictionary<string, long>>();
            var gold = 0L;
            var gem = 0L;
            var money = 0L;

            for (int i = 0; i < safe.Length; i += 2)
            {
                string name = safe[i];
                long count = long.Parse(safe[i + 1]);

                string treasureType = string.Empty;

                if (name.Length == 3)
                {
                    treasureType = "Cash";
                }
                else if (name.ToLower().EndsWith("gem"))
                {
                    treasureType = "Gem";
                }
                else if (name.ToLower() == "gold")
                {
                    treasureType = "Gold";
                }

                if (treasureType == "")
                {
                    continue;
                }
                else if (input < bagWithТreasures.Values.Select(x => x.Values.Sum()).Sum() + count)
                {
                    continue;
                }

                switch (treasureType)
                {
                    case "Gem":
                        if (!bagWithТreasures.ContainsKey(treasureType))
                        {
                            if (bagWithТreasures.ContainsKey("Gold"))
                            {
                                if (count > bagWithТreasures["Gold"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bagWithТreasures[treasureType].Values.Sum() + count > bagWithТreasures["Gold"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                    case "Cash":
                        if (!bagWithТreasures.ContainsKey(treasureType))
                        {
                            if (bagWithТreasures.ContainsKey("Gem"))
                            {
                                if (count > bagWithТreasures["Gem"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bagWithТreasures[treasureType].Values.Sum() + count > bagWithТreasures["Gem"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                }

                if (!bagWithТreasures.ContainsKey(treasureType))
                {
                    bagWithТreasures[treasureType] = new Dictionary<string, long>();
                }

                if (!bagWithТreasures[treasureType].ContainsKey(name))
                {
                    bagWithТreasures[treasureType][name] = 0;
                }

                bagWithТreasures[treasureType][name] += count;
                if (treasureType == "Gold")
                {
                    gold += count;
                }
                else if (treasureType == "Gem")
                {
                    gem += count;
                }
                else if (treasureType == "Cash")
                {
                    money += count;
                }
            }

            foreach (var treasure in bagWithТreasures)
            {
                Console.WriteLine($"<{treasure.Key}> ${treasure.Value.Values.Sum()}");
                foreach (var item2 in treasure.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item2.Key} - {item2.Value}");
                }
            }
        }
    }
}