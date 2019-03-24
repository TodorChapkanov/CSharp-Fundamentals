namespace _07_InfernoInfinity.Core
{
    using _07_InfernoInfinity.Models.Contracts;
    using Contracts;
    using Factories;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine : IEngine
    {
        private ICollection<IWeapon> weapons;
        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.CommandInterpreter = commandInterpreter;
            this.weapons = new List<IWeapon>();
        }
        public ICommandInterpreter CommandInterpreter { get; private set; }



        public void Run()
        {
            var commands = string.Empty;
            while ((commands = Console.ReadLine()) != "END")
            {
                IWeapon weapon;
                var arguments = commands.Split(';');
                var command = arguments[0];
                try
                {
                    switch (command)
                    {
                        case "Create":
                            weapon = this.CommandInterpreter.CreateWeapon(arguments.Skip(1).ToArray());
                            this.weapons.Add(weapon);
                            break;

                        case "Add":
                            weapon = weapons.First(w => w.Name == arguments[1]);
                            this.CommandInterpreter.AddGemToWeapon(weapon, arguments.Skip(2).ToArray());
                            break;

                        case "Remove":
                            weapon = weapons.First(w => w.Name == arguments[1]);
                            var socket = int.Parse(arguments[2]);
                            this.CommandInterpreter.RemoveGemFromWeapon(weapon, socket);
                            break;

                        case "Print":
                            weapon = weapons.First(w => w.Name == arguments[1]);
                            var result = this.CommandInterpreter.GetWeaponToString(weapon);
                            Console.WriteLine(result);
                            break;
                    }
                }
                catch (Exception)
                {
                }
            }

            
        }
    }
}
