namespace _01_ClassBox
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.length = length;
            this.width = width;
            this.height = height;
        }

        public double GetSurfaceArea()
        {
            var area = (2 * this.length * this.height) + (2 * this.length * this.width) + (2 * this.width * this.height);
            return area;
        }

        public double GetLateralSurfaceArea()
        {
            var lateralArea = (2 * this.length * this.height) + (2 * this.width * this.height);
            return lateralArea;
        }

        public double GetVolume()
        {
            var volume = this.length * this.height * this.width;
            return volume;
        }
    }
}
