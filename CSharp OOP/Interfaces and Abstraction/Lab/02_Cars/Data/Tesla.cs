namespace Cars.Data
{
    using Cars.Interfaces;
    using Cars.BaseClasses;
    using System.Text;

    class Tesla : Car, IElectricCar
    {
        private int battery;
        
        public Tesla(string model, string color, int battery)
            : base(model, color)
        {
            this.Battery = battery;
        }
        public int Battery
        {
            get => this.battery;
            private set
            {
                this.battery = value;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"{this.Color} {nameof(Tesla)} {this.Model} with {this.Battery} Batteryes");
            builder.AppendLine(this.Start());
            builder.Append(this.Stop());

            return builder.ToString();
        }
    }
}
