using _03_DependencyInversion.Strategies.Contracts;

namespace P03_DependencyInversion
{
	public class SubtractionStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand - secondOperand;
        }
    }
}
