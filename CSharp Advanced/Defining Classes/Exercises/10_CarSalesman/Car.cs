using System;
using System.Text;

namespace _10_CarSalesman
{
    public class Car
    {
        private string model;
        private int weight;
        private string color;

        private Engine engine;

        public Car()
        {

        }

        public Car(string model, Engine engine, int weight, string color)
        {
            this.model = model;
            this.weight = weight;
            this.color = color;
            this.engine = engine;
        }



        public Car(string model, Engine engine, string color) : this(model, engine, 0, color)
        {
        }

        public Car(string model, Engine engine, int weight) : this(model, engine, weight, "n/a")
        {
        }

        public Car(string model, Engine engine) : this(model, engine, 0, "n/a")
        {
        }

        private bool ValidateWeight(int weight)
        {
            if (weight > 0)
            {
                return true;
            }

            return false;
        }

        public bool ValidateDisplacement(int displacement)
        {
            if (displacement > 0)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {

            var builder = new StringBuilder();
            var model = this.model;
            var color = this.color;
            string weight = GetCarWeight(this.weight);
            var engineModel = this.engine.Model;
            var engineEfficiency = this.engine.Efficiency;
            var enginePower = this.engine.Power;
            string engineDisplacement = GetEnfineDisplacement(this.engine.Displacement);

            builder.AppendLine($"{model}:");
            builder.AppendLine($"  {engineModel}:");
            builder.AppendLine($"    Power: {enginePower}");
            builder.AppendLine($"    Displacement: {engineDisplacement}");
            builder.AppendLine($"    Efficiency: {engineEfficiency}");
            builder.AppendLine($"  Weight: {weight}");
            builder.AppendLine($"  Color: {color}");

            return builder.ToString();



        }
        //FordFocus:
          //V4-33:
            // Power: 140
            // Displacement: 28
            // Efficiency: B
          //Weight: 1300
          // Color: Silver

        private string GetEnfineDisplacement(int displacement)
        {
            if (ValidateDisplacement(this.engine.Displacement))
            {
                return this.engine.Displacement.ToString();
            }
            return "n/a";
        }

        private string GetCarWeight(int weight)
        {
            if (ValidateWeight(this.weight))
            {
               return  this.weight.ToString();
            }
            else
            {
                return "n/a";
            }
        }
    }
}

