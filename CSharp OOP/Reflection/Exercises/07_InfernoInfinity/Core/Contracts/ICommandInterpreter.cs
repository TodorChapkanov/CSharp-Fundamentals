using _07_InfernoInfinity.Factories.Contracts;
using _07_InfernoInfinity.Models.Contracts;

namespace _07_InfernoInfinity.Core.Contracts
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
