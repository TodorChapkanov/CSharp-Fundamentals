namespace Shapes.Data
{
    using Shapes.Interfaces;
    using System;

    public class Rectangle : IDrawable
    {
        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public int Width
        {
            get => this.width;
            private set
            {
                this.width = value;
            }
        }

        public int Height
        {
            get => this.height;
            private set
            {
                this.height = value;
            }
        }


        public void Draw()
        {
            this.DrawLine(this.width, '*', '*');
            for (int i = 1; i <= this.height - 1; i++)
            {
                this.DrawLine(this.width, '*', ' ');
            }

            this.DrawLine(this.width, '*', '*');
        }

        private void DrawLine(int width, char end, char mid)
        {
            Console.Write(end);
            for (int i = 1; i < width - 1; i++)
            {
                Console.Write(mid);
            }
            Console.WriteLine(end);
        }
    }
}
