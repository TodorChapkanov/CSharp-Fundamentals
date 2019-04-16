using _03_DependencyInversion.IO;
using _03_DependencyInversion.Strategies.Contracts;
using _03_DependencyInversion.Strategies.Factories;
using P03_DependencyInversion;
using System;
using System.Reflection.PortableExecutable;

namespace _03_DependencyInversion.Core
{
   public class Engine
    {
        private PrimitiveCalculator calculator;
        private ConsoleReader reader;
        private ConsoleWriter writer;
        private StrategyFactory factory;

        public Engine(PrimitiveCalculator calculator, ConsoleReader reader, ConsoleWriter writer, StrategyFactory factory)
        {
            this.calculator = calculator;
            this.reader = reader;
            this.writer = writer;
            this.factory = factory;
        }

        public void Run()
        {
            var input = reader.Read();
            while (input != "End")
            {
                var arguments = input.Split();

                var firsOperand = 0;
                if (int.TryParse(arguments[0], out firsOperand))
                {
                    var secondOperand = int.Parse(arguments[1]);
                    var result = calculator.performCalculation(firsOperand, secondOperand);
                    this.writer.WriteLine(result.ToString());
                }
                else
                {
                    var strategyType = arguments[1];
                    var calculatorStrategy = factory.CreateStrategy(strategyType);
                    this.calculator.ChangeStrategy(calculatorStrategy);
                }

                input = Console.ReadLine();
            }
        }

    }
}
