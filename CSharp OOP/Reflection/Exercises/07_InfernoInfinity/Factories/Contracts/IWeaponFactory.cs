namespace _07_InfernoInfinity.Factories.Contracts
{
    using Models.Contracts;

    public interface IWeaponFactory
    {
        IWeapon CreateWeapon(string weaponType, string weaponName, string rearityLevel);
    }
}
