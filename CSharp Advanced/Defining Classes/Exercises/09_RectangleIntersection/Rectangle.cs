namespace DefiningClasses
{
    public class Rectangle
    {
        public Rectangle(string id, double width, double height, double topLeftX, double topLeftY)
        {
            this.Id = id;
            this.Width = width;
            this.Height = height;
            this.TopLeftX = topLeftX;
            this.TopLeftY = topLeftY;
        }

        public string Id { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public double TopLeftX { get; set; }

        public double TopLeftY { get; set; }


        public bool IsIntersect(Rectangle rectangle)
        {
            return !(this.TopLeftX > rectangle.TopLeftX + rectangle.Width
                || this.TopLeftX + this.Width < rectangle.TopLeftX
                || this.TopLeftY > rectangle.TopLeftY + rectangle.Height
                || this.TopLeftY + this.Height < rectangle.TopLeftY);
        }
    }
}
