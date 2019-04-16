namespace MuOnline.Core.Commands
{
    using Contracts;
    using Models.Heroes.HeroContracts;
    using MuOnline.Core.Factories.Contracts;
    using MuOnline.Utilities;
    using Repositories.Contracts;


    public class AddHeroCommand : ICommand
    {
        private readonly IRepository<IHero> heroes;
        private readonly IHeroFactory heroFactory;

        public AddHeroCommand(IRepository<IHero> heroes, IHeroFactory heroFactory)
        {
            this.heroes = heroes;
            this.heroFactory = heroFactory;
        }

        public string Execute(string[] inputArgs)
        {
            var heroType = inputArgs[0];
            var username = inputArgs[1];

            var hero = this.heroFactory.Create(heroType, username);
            this.heroes.Add(hero);
            return string.Format(Validators.SuccessfullyCreateMessage, hero.GetType().Name);
        }
    }
}
