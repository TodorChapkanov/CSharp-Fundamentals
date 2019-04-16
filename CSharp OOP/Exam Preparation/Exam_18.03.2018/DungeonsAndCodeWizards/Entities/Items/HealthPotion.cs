using DungeonsAndCodeWizards.Entities.Characters;
using DungeonsAndCodeWizards.Utils;

namespace DungeonsAndCodeWizards.Entities.Items
{
    public class HealthPotion : Item
    {
        private const int HealingPoints = 20;
        private const int HealthPotionWeight = 5;

        public HealthPotion() : base(HealthPotionWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            ValidaionMethods.ValidateIsAlive(character);

            if (character.Health + HealingPoints >= character.BaseHealth )
            {
                character.Health = character.BaseHealth;
            }

            else
            {
                character.Health += HealingPoints;
            }
        }
    }
}
