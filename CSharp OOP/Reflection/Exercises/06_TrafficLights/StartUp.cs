namespace _06_TrafficLights
{
    using _06_TrafficLights.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var trafficLightsInput = Console.ReadLine().Split().ToList();

            var trafficLights = new List<TrafficLight>();

            trafficLightsInput
                .ForEach(l => trafficLights.Add(new TrafficLight(l)));

            var changeLightCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < changeLightCount; i++)
            {
                trafficLights.ForEach(l => l.ChangeLight());

                Console.WriteLine(string.Join(' ', trafficLights));
            }
        }
    }
}
