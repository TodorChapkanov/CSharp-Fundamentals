using _07_InfernoInfinity.Core.Contracts;
using _07_InfernoInfinity.Factories.Contracts;
using _07_InfernoInfinity.Models.Contracts;
using System.Collections.Generic;
using System.Text;

namespace _07_InfernoInfinity.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private IWeaponFactory weaponFactory;
        private IGemFactory gemFactory;

        public CommandInterpreter(IWeaponFactory weaponFactory, IGemFactory gemFactory)
        {
            this.WeaponFactory = weaponFactory;
            this.GemFactory = gemFactory;
        }
        public IWeaponFactory WeaponFactory
        {
            get => weaponFactory;
            private set => weaponFactory = value;
        }

        public IGemFactory GemFactory
        {
            get => gemFactory;
            private set => gemFactory = value;
        }

        public  IWeapon CreateWeapon(string[] arguments)
        {
            var weaponArguments = arguments[0].Split();
            var weaponType = weaponArguments[1];
            var weaponRearity = weaponArguments[0];
            var weaponName = arguments[1];
            var weapon = WeaponFactory.CreateWeapon(weaponType, weaponName, weaponRearity);

            return weapon;
        }

        public void AddGemToWeapon(IWeapon weapon, string[] arguments)
        {
            var socket = int.Parse(arguments[0]);
            var gemArguments = arguments[1].Split();
            var gemType = gemArguments[1];
            var gemClarity = gemArguments[0];
            var gem = this.GemFactory.CreateGem(gemType, gemClarity);
            weapon.InsertGemToWeapon(gem, socket);
        }

        public void RemoveGemFromWeapon(IWeapon weapon, int socket)
        {
            weapon.RemoveGem(socket);
        }

        public string GetWeaponToString(IWeapon weapon)
        {
            var builder = new StringBuilder();
            builder.Append(weapon);

            return builder.ToString();
        }
    }
}
