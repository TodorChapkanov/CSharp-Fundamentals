﻿namespace AnimalCentre.Models.Animals
{
    public class Dog : Animal
    {
        public Dog(string name, int happiness, int energy, int procedureTime)
            : base(name, happiness, energy, procedureTime)
        {
        }

        public override string ToString()
        {
            return $"    Animal type: {typeof(Dog).Name} - {this.Name} - Happiness: {this.Happiness} - Energy: {this.Energy}";
        }
    }
}
