using System;
using System.Text;

namespace Shapes.Models
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get => this.radius;
            private set
            {
                base.ValidateValue(value);
                this.radius = value;
            }
        }

        public override double CalculateArea()
        {
            var result = Math.PI * Math.Pow(this.radius, 2);
            return result;
        }

        public override double CalculatePerimeter()
        {
            var result = 2 * Math.PI * this.Radius;
            return result;
        }

        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }
}
