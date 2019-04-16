using DungeonsAndCodeWizards.Entities.Characters;
using DungeonsAndCodeWizards.Utils;

namespace DungeonsAndCodeWizards.Entities.Items
{
    public class PoisonPotion : Item
    {
        private const int PoisonPoints = 20;
        private const int HealthPotionWeight = 5;

        public PoisonPotion() : base(HealthPotionWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            ValidaionMethods.ValidateIsAlive(character);
            if (character.Health - PoisonPoints <= 0)
            {
                character.IsAlive = false;
                character.Health = 0;
            }
        }
    }
}
