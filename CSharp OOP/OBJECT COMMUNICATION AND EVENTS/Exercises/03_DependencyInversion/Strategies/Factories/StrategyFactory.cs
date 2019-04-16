using _03_DependencyInversion.Strategies.Contracts;
using P03_DependencyInversion;

namespace _03_DependencyInversion.Strategies.Factories
{
    public class StrategyFactory
    {
        public IStrategy CreateStrategy(string strategyType)
        {
           
            switch (strategyType)
            {
                case "+":
                    return new AdditionStrategy();
                case "-":
                    return new SubtractionStrategy();
                case "*":
                    return new MultiplicationStrategy();
                case "/":
                    return new DivideStrategy();
                default:
                    return null;
            }
        }
    }
}
