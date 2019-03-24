namespace _08_CustomAttribute.Models.Weapons
{
    using Contracts;
    using Constants;
    public class Sword : Weapon
    {
        public Sword(string name) 
            : base(name)
        {
            this.MinDamage = WeaponsConstants.SwordMinDamage;
            this.MaxDamage = WeaponsConstants.SwordMaxDamage;
            this.Gems = new IGem[WeaponsConstants.SwordSocketsCount];
        }
    }
}
