namespace MuOnline.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Monsters.Contracts;
    using MuOnline.Utilities;

    public class MonsterRepository : IRepository<IMonster>
    {
        private List<IMonster> monsters;

        public MonsterRepository()
        {
            this.monsters = new List<IMonster>();
        }

        public IReadOnlyCollection<IMonster> Repository
            => this.monsters.AsReadOnly();

        public void Add(IMonster monster)
        {
            Validators.ValidateNullInput<IMonster>(monster, monster.GetType().Name);
            this.monsters.Add(monster);
        }

        public IMonster Get(string monsterType)
        {
            var targetMonster = monsters.FirstOrDefault(m => m.GetType().Name == monsterType);
            Validators.ValidateNullInput<IMonster>(targetMonster, targetMonster.GetType().Name);
            return targetMonster;
        }

        public bool Remove(IMonster monster)
        {
            var result = monsters.Remove(monster);
            return result;
        }
    }
}
