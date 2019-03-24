namespace _08_CustomAttribute.Factories.Contracts
{
    using Models.Contracts;

    public interface IWeaponFactory
    {
        IWeapon CreateWeapon(string weaponType, string weaponName, string rearityLevel);
    }
}
