﻿namespace AnimalCentre.Models.Animals
{
    public class Lion : Animal
    {
        public Lion(string name, int happiness, int energy, int procedureTime) 
            : base(name, happiness, energy, procedureTime)
        {
        }

        public override string ToString()
        {
            return $"    Animal type: {typeof(Lion).Name} - {this.Name} - Happiness: {this.Happiness} - Energy: {this.Energy}";
        }
    }
}
