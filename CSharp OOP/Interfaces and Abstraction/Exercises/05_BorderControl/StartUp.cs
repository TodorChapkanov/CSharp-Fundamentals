namespace _05_BorderControl
{
    using _05_BorderControl.Contracts;
    using _05_BorderControl.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var visitors = new List<IIdentifiable>();
            var line = string.Empty;
            IIdentifiable visitor = null;
            
            while ((line = Console.ReadLine()) != "End")
            {
                var tokens = line.Split();
                if (tokens.Length == 3)
                {
                    var citizenName = tokens[0];
                    var citizenAge = int.Parse(tokens[1]);
                    var citizenId = tokens[2];
                    visitor = new Citizen(citizenId, citizenName, citizenAge); 

                }
                else
                {
                    var robotModel = tokens[0];
                    var robotId = tokens[1];

                    visitor = new Robor(robotId, robotModel);
                }
                visitors.Add(visitor);
            }

            var fakeId = Console.ReadLine();
            visitors.Where(r => r.Id.EndsWith(fakeId))
                .ToList()
                .ForEach(v => Console.WriteLine(v.Id));
            
        }
    }
}
