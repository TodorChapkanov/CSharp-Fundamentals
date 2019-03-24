using System;
using System.Collections.Generic;
using System.Reflection;

namespace _06_TrafficLights.Models
{
   public class TrafficLight
    {
        public TrafficLight(string light)
        {
            this.Light = TraficLightParser(light);
        }

        public Lights Light  { get; private set; }

        public void ChangeLight()
        {
            var lightCount = Lights.GetValues(typeof(Lights)).Length;

            var nextLight = ((int)this.Light + 1) % lightCount;

            this.Light = (Lights)nextLight;
        }

        private Lights TraficLightParser(string light)
        {
            Lights parsedLight;

            if (!Enum.TryParse<Lights>(light, out parsedLight))
            {
                throw new ArgumentException("Inavlid Light!");
            }
            
            return parsedLight;
        }

        public override string ToString()
        {
            return this.Light.ToString();
        }
    }
}
