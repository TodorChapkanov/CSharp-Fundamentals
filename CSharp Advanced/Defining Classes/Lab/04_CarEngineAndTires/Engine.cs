namespace CarManufacturer
{
    public class Engine
    {
        private int power;
        private double cubicCapacity;
        public Engine(int power, double cubicCapacity)
        {
            this.Power = power;
            this.CubicCapacity = cubicCapacity;
        }

        public int Power
        {
            get { return this.power; }

            set { this.power = value; }
        }
        public double CubicCapacity
        {
            get { return this.cubicCapacity; }

            set { this.cubicCapacity = value; }
        }
    }
}
