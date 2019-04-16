using _03_DependencyInversion.Core;
using _03_DependencyInversion.IO;
using _03_DependencyInversion.Strategies.Factories;
using P03_DependencyInversion;
using System;

namespace _03_DependencyInversion
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var calculator = new PrimitiveCalculator();
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();
            var factory = new StrategyFactory();

            var engine = new Engine(calculator, reader, writer, factory);
            engine.Run();
        }
    }
}
