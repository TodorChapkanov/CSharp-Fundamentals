namespace _02_CarsSalesman
{
    using System.Text;

    public class Car
    {

        internal Engine Engine { get;private set; }
        public string Model { get;private set; }
        public int Weight { get;private set; }
        public string Color { get;private set; }

        public Car(string model, Engine engine) : this(model, engine, -1, "n/a")
        {
        }

        public Car(string model, Engine engine, int weight) : this(model, engine, weight, "n/a")
        {
        }

        public Car(string model, Engine engine, string color) : this(model, engine, -1, color)
        {
        }

        public Car(string model, Engine engine, int weight, string color)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}:\n", this.Model);
            sb.Append(this.Engine.ToString());
            sb.AppendFormat("{0}Weight: {1}\n", Constant.offset, this.Weight == -1 ? "n/a" : this.Weight.ToString());
            sb.AppendFormat("{0}Color: {1}", Constant.offset, this.Color);

            return sb.ToString();
        }
    }
}
