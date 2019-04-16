using DungeonsAndCodeWizards.Entities.Characters;
using DungeonsAndCodeWizards.Utils;

namespace DungeonsAndCodeWizards.Entities.Items
{
    public class ArmorRepairKit : Item
    {
        private const int InitialArmorKitWeight = 10;
        public ArmorRepairKit() : base(InitialArmorKitWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            ValidaionMethods.ValidateIsAlive(character);

            character.Armor = character.BaseArmor;
        }
    }
}
