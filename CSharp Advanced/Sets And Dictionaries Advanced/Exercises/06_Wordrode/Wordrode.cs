namespace _06_Wordrode
{
    using System;
    using System.Collections.Generic;

    public class Wordrode
    {
        public static void Main()
        {
            var commandsCount = int.Parse(Console.ReadLine());

            var clothes = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < commandsCount; i++)
            {
                var line = Console.ReadLine().Split(new[] { " -> ", "," },StringSplitOptions.RemoveEmptyEntries);
                var colors = line[0];

                if (!clothes.ContainsKey(colors))
                {
                    clothes.Add(colors, new Dictionary<string, int>());
                }

                for (int c = 1; c < line.Length; c++)
                {
                    if (!clothes[colors].ContainsKey(line[c]))
                    {
                        clothes[colors][line[c]] = 0;
                    }
                    clothes[colors][line[c]]++;
                }
            }
            var clothingToFinde = Console.ReadLine().Split();
            var color = clothingToFinde[0];
            var clothing = clothingToFinde[1];
            foreach (var item in clothes)
            {
                Console.WriteLine($"{item.Key} clothes:");
                foreach (var kvp in item.Value)
                {
                    if (item.Key == color && kvp.Key == clothing)
                    {
                        Console.WriteLine($"* {kvp.Key} - {kvp.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {kvp.Key} - {kvp.Value}");
                    }
                }
            }
        }
    }
}
