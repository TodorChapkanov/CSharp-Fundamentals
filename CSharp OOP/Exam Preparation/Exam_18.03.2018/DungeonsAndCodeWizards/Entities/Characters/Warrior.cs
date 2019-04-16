using DungeonsAndCodeWizards.Entities.Bags;
using DungeonsAndCodeWizards.Entities.Characters.Contracts;
using DungeonsAndCodeWizards.Entities.Enums;
using DungeonsAndCodeWizards.Utils;
using System;

namespace DungeonsAndCodeWizards.Entities.Characters
{
    public class Warrior :Character, IAttackable
    {
        private const int InitialHealth = 100;
        private const int InitialArmor = 50;
        private const int InitialAbility = 40;
        private static Bag InitialBag = new Satchel();

        public Warrior(string name,  Faction faction) : base(name, InitialHealth, InitialArmor, InitialAbility, InitialBag, faction)
        {
        }

        public void Attack(Character character)
        {
            ValidaionMethods.ValidateIsAlive(this);
            ValidaionMethods.ValidateIsAlive(character);

            if (this == character)
            {
                throw new InvalidOperationException("Cannot attack self!");
            }

            if (this.Faction == character.Faction)
            {
                throw new ArgumentException($"Friendly fire! Both characters are from {this.Faction} faction!");
            }

            character.TakeDamage(this.AbilityPoints);
            if (character.Health <=0)
            {
                character.IsAlive = false;
            }
        }
    }
}
