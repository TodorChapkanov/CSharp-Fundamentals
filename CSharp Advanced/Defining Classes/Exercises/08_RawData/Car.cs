namespace _08_RawData
{
    public class Car
    {
        private Engine engine;
        private Cargo cargo;
        private Tire[] tires;

        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tires = tires;
        }

        public string Model { get; set; }

        public  Engine Engine
        {
            get { return this.engine; }

            set { this.engine = value; }
        }

        public Tire[] Tires
        {
            get { return this.tires; }

            set { this.tires = value; }
        }

        public Cargo Cargo
        {
            get { return this.cargo; }

            set { this.cargo = value; }

        }

    }
}
