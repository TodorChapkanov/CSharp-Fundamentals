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
            var builder = new StringBuilder();
            var outsideRadius = this.Radius + 0.4;
            var insideRadius = this.Radius - 0.4;

            for (double row = this.Radius; row >= -this.radius; --row)
            {
                for (double col = -this.Radius; col < outsideRadius; col += 0.5)
                {
                    var value = row * row + col * col;
                    var insideValue = insideRadius * insideRadius;
                    var outsideValue = outsideRadius * outsideRadius;

                    if (value >= insideValue && value <= outsideValue)
                    {
                        builder.Append("*");
                    }

                    else
                    {
                        builder.Append(" ");
                    }
                }

                builder.AppendLine();
            }

            return builder.ToString();
        }
    }
}
