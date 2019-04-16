namespace MuOnline.Core.Factories
{
    using Contracts;
    using MuOnline.Models.Monsters.Contracts;


    public class MonsterFactory : IMonsterFactory
    {
        public IMonster Create(string monsterType, int attackPoints, int defensePoints)
        {
            throw new System.NotImplementedException();
        }
    }
}
