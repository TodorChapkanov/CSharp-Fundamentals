namespace _07_InfernoInfinity
{
    using _07_InfernoInfinity.Factories;
    using Core;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var weaponFactory = new WeaponFactory();
            var gemFactory = new GemFactory();
            var commandInterpreter = new CommandInterpreter(weaponFactory, gemFactory);
            var engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}
