using System;
using System.Collections.Generic;
using System.Text;

namespace _10_CarSalesman
{
    public class Engine
    {
        

        public string Model { get; private set; }
        public int Power { get; private set; }
        public int Displacement { get; private set; }
        public string Efficiency { get; private set; }

        public Engine()
        {
        }

        public Engine(string model, int power) : this(model, power, 0, "n/a")
        {
        }
        public Engine(string model, int power, string efficiency) : this(model, power, 0, efficiency)
        {

        }

        public Engine(string model, int power, int displacement) : this(model, power, displacement, "n/a")
        {
        }

        public Engine(string model, int power, int displacement, string efficiency)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }


    }
}
