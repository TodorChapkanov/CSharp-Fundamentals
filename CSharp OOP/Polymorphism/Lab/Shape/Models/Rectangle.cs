namespace Shapes.Models
{
    using System.Text;

    public class Rectangle : Shape
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }


        public double Width
        {
            get => this.width;
            private set
            {
                base.ValidateValue(value);
                this.width = value;
            }
        }

        public double Height
        {
            get => this.height;
            private set
            {
                base.ValidateValue(value);
                this.height = value;
            }
        }

        public override double CalculateArea()
        {
            var result = this.Width * this.Height;
            return result;
        }

        public override double CalculatePerimeter()
        {
            var result = 2 * (this.Width + this.Height);
            return result;
        }

        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }
}
