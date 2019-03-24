namespace _08_CustomAttribute.Core
{
    using _08_CustomAttribute.Attributes;
    using _08_CustomAttribute.Models.Contracts;
    using Contracts;
    using Factories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class Engine : IEngine
    {

        public void Run()
        {
            var command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                var types = Assembly.GetExecutingAssembly().GetTypes().First(t => t.Name == "Weapon");

                var attribute = types.GetCustomAttribute<WeaponAttribute>();


                var result = string.Empty;
                switch (command)
                {
                    case "Author":
                        result = $"Author: {attribute.Author}";
                        break;

                    case "Revision":
                        result = $"Revision: {attribute.Revision}";
                        break;

                    case "Description":
                        result = $"Class description: {attribute.Description}";
                        break;

                    case "Reviewers":
                        result = $"Reviewers: {string.Join(", ", attribute.Reviewers)}";
                        break;
                }

                if (result != string.Empty)
                {
                    Console.WriteLine(result);
                }

            }

            
        }
    }
}
