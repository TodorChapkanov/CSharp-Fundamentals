namespace _07_InfernoInfinity.Factories
{
    using Contracts;
    using Models.Contracts;
    using Models.Weapons.Enums;
    using System;
    using System.Linq;
    using System.Reflection;

    public class WeaponFactory : IWeaponFactory
    {
        public IWeapon CreateWeapon(string weaponType, string weaponName, string rearityLevel)
        {
            var weaponsType = typeof(IWeapon);
            var allClasses = Assembly.GetExecutingAssembly().GetTypes().Where(t=> t.GetInterfaces().Contains(weaponsType));

            var weapons = allClasses.First(c => c.Name == weaponType);

            var weapon = (IWeapon)Activator.CreateInstance(weapons, new object[] { weaponName });
            var rearity = RearityParser(rearityLevel);
            weapon.SetRearity(rearity);
            return weapon;
        }

        private WeaponRearityLevel RearityParser(string rearityLevel)
        {
            WeaponRearityLevel rearity;
            if (!Enum.TryParse<WeaponRearityLevel>(rearityLevel, out rearity))
            {
                throw new ArgumentException("Invalit rearity type");
            }

            return rearity;
        }
    }
}
