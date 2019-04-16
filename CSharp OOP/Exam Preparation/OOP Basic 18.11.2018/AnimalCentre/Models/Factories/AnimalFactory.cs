using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Factories
{
   public class AnimalFactory
    {
        public IAnimal CreateAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            switch (type.ToLower())
            {
                case "dog":
                    return new Dog(name, happiness, energy, procedureTime);
                case "cat":
                    return new Cat(name, happiness, energy, procedureTime);
                case "lion":
                    return new Lion(name, happiness, energy, procedureTime);
                case "pig":
                    return new Pig(name, happiness, energy, procedureTime);
                default:
                    throw new  ArgumentException("Invalid type of animal");
            }
        }
    }
}
