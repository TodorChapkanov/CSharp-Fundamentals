namespace _07_InfernoInfinity.Models.Contracts
{
    using _07_InfernoInfinity.Models.Weapons.Enums;
    using System.Collections.Generic;


    public interface IWeapon
    {
        string Name { get; }

        int MinDamage { get; }

        int MaxDamage { get; }

        IGem[] Gems { get; }

        void SetRearity(WeaponRearityLevel rearityLevel);

        void InsertGemToWeapon(IGem gem, int socket);

        void RemoveGem(int socket);
    }
}
