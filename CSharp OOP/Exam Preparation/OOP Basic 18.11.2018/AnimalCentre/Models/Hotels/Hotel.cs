using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;

namespace AnimalCentre.Models.Hotels
{
    public class Hotel : IHotel
    {
        private const int Capacity = 10;

        private Dictionary<string, IAnimal> animals;
        private int intcapacity => Capacity;

        public Hotel()
        {
            this.animals = new Dictionary<string, IAnimal>();
        }

        public IReadOnlyDictionary<string, IAnimal> Animals
            => animals;

        public void Accommodate(IAnimal animal)
        {
            this.ValidateHotelCapacity();
            if (this.animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }

            this.animals.Add(animal.Name, animal);
        }

        public void Adopt(string animalName, string owner)
        {
            this.ValidateAnimalIsExist(animalName);

           IAnimal currentAnimal = animals[animalName];
            currentAnimal.IsAdopt = true;
            currentAnimal.Owner = owner;
            animals.Remove(animalName);
        }

        public  void ValidateAnimalIsExist(string animalName)
        {
            if (!this.animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }
        }

        private void ValidateHotelCapacity()
        {
            if (this.animals.Count == Capacity)
            {
                throw new InvalidOperationException("Not enough capacity");
            }
        }
    }
}
