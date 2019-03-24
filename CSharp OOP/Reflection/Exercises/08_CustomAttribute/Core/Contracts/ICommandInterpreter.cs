using _08_CustomAttribute.Factories.Contracts;
using _08_CustomAttribute.Models.Contracts;

namespace _08_CustomAttribute.Core.Contracts
{
   public interface ICommandInterpreter
    {
        IWeaponFactory WeaponFactory { get; }

        IGemFactory GemFactory { get; }

        IWeapon CreateWeapon(string[] arguments);

        void AddGemToWeapon(IWeapon weapon, string[] arguments);

        void RemoveGemFromWeapon(IWeapon weapon, int socket);

        string GetWeaponToString(IWeapon weapon);
    }
}
