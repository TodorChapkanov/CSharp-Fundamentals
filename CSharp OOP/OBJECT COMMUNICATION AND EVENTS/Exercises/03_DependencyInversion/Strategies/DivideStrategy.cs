﻿using _03_DependencyInversion.Strategies.Contracts;

namespace _03_DependencyInversion.Strategies
{
   public class DivideStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand / secondOperand;
        }
    }
}
