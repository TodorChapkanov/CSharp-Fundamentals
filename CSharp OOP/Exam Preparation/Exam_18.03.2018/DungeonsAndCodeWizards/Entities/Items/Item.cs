using DungeonsAndCodeWizards.Entities.Characters;
using DungeonsAndCodeWizards.Utils;

namespace DungeonsAndCodeWizards.Entities.Items
{
    public abstract class Item
    {
        protected Item(int weight)
        {
            Weight = weight;
        }

        public int Weight { get; private set; }

        public abstract void AffectCharacter(Character character);
    }
}
