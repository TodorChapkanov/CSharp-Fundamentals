using _03_DependencyInversion.Strategies.Contracts;

namespace P03_DependencyInversion
{
    public class PrimitiveCalculator
    {
        private IStrategy strategy;

        public PrimitiveCalculator()
        {
            this.strategy = new  AdditionStrategy();
        }

        public PrimitiveCalculator(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void ChangeStrategy(IStrategy strategy)
        {
            this.strategy = strategy;
        }


        public int performCalculation(int firstOperand, int secondOperand)
        {
            return strategy.Calculate(firstOperand, secondOperand);
        }
    }
}
