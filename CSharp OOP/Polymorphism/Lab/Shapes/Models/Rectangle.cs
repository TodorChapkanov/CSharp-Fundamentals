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
            var builder = new StringBuilder();
            this.DrawLine(this.Width, '*', '*', builder);
            for (int i = 1; i <= this.Height - 1; i++)
            {
                this.DrawLine(this.Width, '*', ' ', builder);
            }

            this.DrawLine(this.Width, '*', '*', builder);

            return builder.ToString();
        }

        private void DrawLine(double width, char end, char mid, StringBuilder builder)
        {
            builder.Append(end);
            for (int i = 1; i < width - 1; i++)
            {
                builder.Append(mid);
            }
            builder.AppendLine(end.ToString());
        }
    }
}
