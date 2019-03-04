namespace _02_CarsSalesman
{
    using System.Text;
    
    public class Engine
    {

        public Engine(string model, int power) : this(model, power, -1, "n/a")
        {
        }

        public Engine(string model, int power, int displacement) : this(model, power, displacement, "n/a")
        {
        }

        public Engine(string model, int power, string efficiency) : this(model, power, -1, efficiency)
        {
        }

        public Engine(string model, int power, int displacement, string efficiency)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }

        public string Model { get; private set; }
        public int Power { get; private set; }
        public int Displacement { get; private set; }
        public string Efficiency { get; private set; }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}{1}:\n", Constant.offset, this.Model);
            sb.AppendFormat("{0}{0}Power: {1}\n", Constant.offset, this.Power);
            sb.AppendFormat("{0}{0}Displacement: {1}\n",Constant.offset, this.Displacement == -1 ? "n/a" : this.Displacement.ToString());
            sb.AppendFormat("{0}{0}Efficiency: {1}\n", Constant.offset, this.Efficiency);

            return sb.ToString();
        }
    }
}
