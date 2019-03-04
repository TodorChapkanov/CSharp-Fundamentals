namespace Heroes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class HeroRepository
    {
        private List<Hero> data;
        public HeroRepository()
        {
            this.data = new List<Hero>();
        }

        public int Count => this.data.Count; 

        public void Add(Hero hero)
        {
            this.data.Add(hero);
        }
        public void Remove(string name)
        {
            var hero = data.FirstOrDefault(x => x.Name == name);
            this.data.Remove(hero);
        }
        public Hero GetHeroWithHighestStrength()
        {

            data.OrderByDescending(x => x.Item.Strength);
            return this.data.FirstOrDefault();
        }

        public  Hero GetHeroWithHighestAbility()
        {
            data.OrderByDescending(x => x.Item.Ability);
            return this.data.FirstOrDefault();
        }
        public Hero GetHeroWithHighestIntelligence()
        {
            data.OrderByDescending(x => x.Item.Intelligence);
            return this.data.FirstOrDefault();
        }

        public override string ToString()
        {
            var builde = new StringBuilder();
            foreach (var hero in data)
            {
                builde.AppendLine(hero.ToString());
            }
            return builde.ToString();
        }
    }
}
