namespace MuOnline.Core.Factories
{
    using Contracts;
    using MuOnline.Models.Heroes.HeroContracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class HeroFactory : IHeroFactory
    {
        public IHero Create(string heroType, string username)
        {
            var heroTypeAsLower = heroType.ToLower();
            var type = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name.ToLower() == heroTypeAsLower);

            if (type == null)
            {
                throw new ArgumentNullException("Invalit hero type");
            }

            var hero = (IHero)Activator.CreateInstance(type, new object[] { username });

            return hero;
        }
    }
}
