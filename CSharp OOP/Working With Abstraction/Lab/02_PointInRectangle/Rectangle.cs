namespace _02_PointInRectangle
{
    class Rectangle
    {
        private Point topLeft;
        private Point bottomRight;

        public Rectangle(Point topLeft, Point bottomRight)
        {
            this.topLeft = topLeft;
            this.bottomRight = bottomRight;
        }

        public bool  Contains(Point point)
        {
            return point.X >= this.topLeft.X && point.Y >= this.topLeft.Y && point.X <= this.bottomRight.X && point.Y <= this.bottomRight.Y;
        }
    }
}
