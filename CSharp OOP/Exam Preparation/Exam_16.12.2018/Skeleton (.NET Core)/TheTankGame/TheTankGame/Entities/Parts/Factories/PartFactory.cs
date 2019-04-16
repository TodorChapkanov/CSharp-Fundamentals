using System;
using System.Linq;
using System.Reflection;
using TheTankGame.Entities.Parts.Contracts;
using TheTankGame.Entities.Parts.Factories.Contracts;

namespace TheTankGame.Entities.Parts.Factories
{
    public class PartFactory : IPartFactory
    {
        private const string Suffix = "Part";
        public IPart CreatePart(string partType, string model, double weight, decimal price, int additionalParameter)
        {
            var currentPartType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .First(t => t.Name == partType + Suffix);

            var instance = (IPart) Activator
                .CreateInstance(currentPartType, new object[] { model, weight, price, additionalParameter });

            return instance;
        }
    }
}
