using System.Collections.Generic;

namespace _05_PizzaCalories.ConstantData
{
    internal class DoughCalories
    {
        public static readonly double GramDough = 2;
        public static readonly Dictionary<string, double> DoughType = new Dictionary<string, double>()
        {
            {"white", 1.5 },
            {"wholegrain", 1.0 }
        };
        
        public static readonly Dictionary<string, double> BakingTechniqueType = new Dictionary<string, double>()
        {
            {"crispy", 0.9 },
            {"chewy", 1.1 },
            {"homemade", 1.0 }
        };

       
    }
}
