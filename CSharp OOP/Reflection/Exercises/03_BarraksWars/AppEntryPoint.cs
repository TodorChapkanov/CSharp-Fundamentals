namespace _03_BarracksFactory
{
    using Contracts;
    using Core;
    using Core.Factories;
    using Data;
    using _03_BarraksWars.Core;

    class AppEntryPoint
    {
        static void Main(string[] args)
        {
            var repository = new UnitRepository();
            var factory = new UnitFactory();
            var commandInterpreter = new CommandInterpreter(repository, factory);

            IRunnable engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}
