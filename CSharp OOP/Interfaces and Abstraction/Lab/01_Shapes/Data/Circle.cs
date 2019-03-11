namespace Shapes.Data
{
    using Shapes.Interfaces;
    using System;

    public class Circle : IDrawable
    {
        private int radius;

        public Circle(int radius)
        {
            this.Radius = radius;
        }

        public int Radius {
            get => this.radius;
            private set
            {
                this.radius = value;
            }
        }

        public void Draw()
        {
            var outsideRadius = this.radius + 0.4;
            var insideRadius = this.radius - 0.4;
            for (double row = this.radius; row >= -this.radius; --row)
            {
                for (double col = -this.radius; col < outsideRadius; col += 0.5)
                {
                    var value = row * row + col * col;
                    var insideValue = insideRadius * insideRadius;
                    var outsideValue = outsideRadius * outsideRadius;

                    if (value >= insideValue && value <= outsideValue)
                    {
                        Console.Write("*");
                    }

                    else
                    {
                        Console.Write(" ");
                    }
                }

                Console.WriteLine();

            }
        }
    }
}
