namespace _05_PizzaCalories.Models
{
    using _05_PizzaCalories.ConstantData;
    using System;

    public class Dough
    {
        private string type;
        private string bakingTechnique;
        private double weight;

        public Dough(string type, string bakingTechnique, double weight)
        {
            this.Type = type;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string Type
        {
            get
            {
                return this.type;
            }

            set
            {
                if (!DoughCalories.DoughType.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.type = value.ToLower();
            }
        }

        public string BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }
            set
            {
                if (!DoughCalories.BakingTechniqueType.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.bakingTechnique = value.ToLower();
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                if (value <= 0 || value > 200 )
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                this.weight = value;
            }
        }

        public double CalculateCalories()
        {
            var result = (this.weight * DoughCalories.GramDough) * DoughCalories.DoughType[this.type] * DoughCalories.BakingTechniqueType[this.bakingTechnique];

            return result;
        }
    }
}
