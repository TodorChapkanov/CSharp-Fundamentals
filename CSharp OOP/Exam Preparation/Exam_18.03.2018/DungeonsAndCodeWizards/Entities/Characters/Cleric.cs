using DungeonsAndCodeWizards.Entities.Bags;
using DungeonsAndCodeWizards.Entities.Characters.Contracts;
using DungeonsAndCodeWizards.Entities.Enums;
using DungeonsAndCodeWizards.Utils;
using System;

namespace DungeonsAndCodeWizards.Entities.Characters
{
   public class Cleric : Character, IHealable
    {
        private const int InitialHealth = 50;
        private const int InitialArmor = 25;
        private const int InitialAbility = 40;
        private static Bag InitialBag = new Backpack();
        private const double InitialRestHeal = 0.5;

        public Cleric(string name, Faction faction) : base(name, InitialHealth, InitialArmor, InitialAbility, InitialBag, faction)
        {
        }

        public override double RestHealMultiplier { get => base.RestHealMultiplier; set => base.RestHealMultiplier = InitialRestHeal; }

        public void Heal(Character character)
        {
            ValidaionMethods.ValidateIsAlive(this);
            ValidaionMethods.ValidateIsAlive(character);

            if (this.Faction != character.Faction)
            {
                throw new InvalidOperationException("Cannot heal enemy character!");
            }

            if (character.Health + this.AbilityPoints >= character.BaseHealth)
            {
                character.Health = character.BaseHealth;
            }
            else
            {
                character.Health += this.AbilityPoints;
            }
        }
    }
}
