namespace _07_InfernoInfinity.Models.Weapons
{
    using Contracts;
    using Constants;

    public class Knife : Weapon
    {
        public Knife(string name) : base(name)
        {
            this.MinDamage = WeaponsConstants.KnifeMinDamage;
            this.MaxDamage = WeaponsConstants.KnifeMaxDamage;
            this.Gems = new IGem[WeaponsConstants.KnifeSocketsCount];
        }
    }
}
