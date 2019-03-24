namespace _08_CustomAttribute.Models.Weapons
{
    using Contracts;
    using Constants;
   public class Axe : Weapon
    {
        public Axe(string name)
            :base(name)
        {
            this.MinDamage = WeaponsConstants.AxeMinDamage;
            this.MaxDamage = WeaponsConstants.AxeMaxDamage;
            this.Gems = new IGem[WeaponsConstants.AxeSocketsCount];
        }
    }
}
