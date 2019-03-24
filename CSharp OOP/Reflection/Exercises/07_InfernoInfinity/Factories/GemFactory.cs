namespace _07_InfernoInfinity.Factories
{
    using _07_InfernoInfinity.Factories.Contracts;
    using _07_InfernoInfinity.Models.Gems.Enums;
    using Models.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class GemFactory: IGemFactory
    {
        public IGem CreateGem(string gemType, string clarityLevel)
        {
            var interfaceType = typeof(IGem);
            var allClasses = Assembly.GetExecutingAssembly().GetTypes().Where(c=> c.GetInterfaces().Contains(interfaceType));

            var currentGem = allClasses.First(c => c.Name == gemType);

            var gemInstance = (IGem)Activator.CreateInstance(currentGem);
            var clarity = this.ClarituLevelParser(clarityLevel);
            gemInstance.SetClarityLevel(clarity);
            return gemInstance;
        }
        private GemsClarityLevel ClarituLevelParser(string clarityLevel)
        {

            GemsClarityLevel clarity;
            if (!Enum.TryParse<GemsClarityLevel>(clarityLevel, out clarity))
            {
                throw new ArgumentException("Invalid Gem Type!");
            }
            return clarity;
        }
    }
}
