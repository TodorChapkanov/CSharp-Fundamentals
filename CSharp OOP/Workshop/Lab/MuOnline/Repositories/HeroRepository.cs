namespace MuOnline.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Heroes.HeroContracts;
    using MuOnline.Utilities;

    public class HeroRepository : IRepository<IHero>
    {
        private List<IHero> heroes;

        public HeroRepository()
        {
            this.heroes = new List<IHero>();
        }

        public IReadOnlyCollection<IHero> Repository
            => this.heroes.AsReadOnly();

        public void Add(IHero hero)
        {
            Validators.ValidateNullInput<IHero>(hero, hero.GetType().Name);
            this.heroes.Add(hero);
        }
        
        public IHero Get(string heroName)
        {
            var targetHero = this.heroes.FirstOrDefault(h => ((IIdentifiable)h).Username == heroName);
            Validators.ValidateNullInput<IHero>(targetHero, targetHero.GetType().Name);

            return targetHero;
        }

        public bool Remove(IHero hero)
        {
            var isRemoved = this.heroes.Remove(hero);
            return isRemoved;
        }
    }
}
