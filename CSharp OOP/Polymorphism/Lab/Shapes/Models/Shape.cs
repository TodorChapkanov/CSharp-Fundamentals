namespace Shapes.Models
{
    using System;

    public abstract class Shape
    {
        public abstract double CalculatePerimeter();

        public abstract double CalculateArea();

        public virtual string Draw()
        {
            return string.Empty;
        }

        internal void ValidateValue(double value)
        {
            if (value <= 0)
            {
                throw new ArgumentException("The Width must be non negative number!");
            }
        }
    }
}
