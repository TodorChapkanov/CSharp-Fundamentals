using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Factories;
using AnimalCentre.Models.Hotels;
using AnimalCentre.Models.Procedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Core
{
    public class AnimalCentre
    {
        private Hotel hotel;
        private AnimalFactory factory;
        private IDictionary<string, IProcedure> procedures;
        private IDictionary<string, List<IAnimal>> adoptedAnimals;

        public AnimalCentre(Hotel hotel, AnimalFactory factory)
        {
            this.hotel = hotel;
            this.factory = factory;
            this.procedures = new Dictionary<string, IProcedure>();
            this.adoptedAnimals = new Dictionary<string, List<IAnimal>>();
            SetProcedure();
        }

        private void SetProcedure()
        {
            this.procedures["Chip"] = new Chip();
            this.procedures["DentalCare"] = new DentalCare();
            this.procedures["Fitness"] = new Fitness();
            this.procedures["NailTrim"] = new NailTrim();
            this.procedures["Play"] = new Play();
            this.procedures["Vaccinate"] = new Vaccinate();
        }

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            var animal = this.factory.CreateAnimal(type, name, energy, happiness, procedureTime);
            this.hotel.Accommodate(animal);

            return $"Animal {name} registered successfully";
        }

        public string Chip(string name, int procedureTime)
        {

            var animal = this.hotel.Animals.First(c => c.Key == name).Value;
            this.procedures["Chip"].DoService(animal, procedureTime);
            return $"{name} had chip procedure";
        }

        public string Vaccinate(string name, int procedureTime)
        {
            var animal = this.hotel.Animals.First(c => c.Key == name).Value;
            this.procedures["Vaccinate"].DoService(animal, procedureTime);
            return $"{name} had vaccination procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            var animal = this.hotel.Animals.First(c => c.Key == name).Value;
            this.procedures["Fitness"].DoService(animal, procedureTime);
            return $"{name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            var animal = this.hotel.Animals.First(c => c.Key == name).Value;
            this.procedures["Play"].DoService(animal, procedureTime);
            return $"{name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            var animal = this.hotel.Animals.First(c => c.Key == name).Value;
            this.procedures["DentalCare"].DoService(animal, procedureTime);
            return $"{name} had dental care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            var animal = this.hotel.Animals.First(c => c.Key == name).Value;
            this.procedures["NailTrim"].DoService(animal, procedureTime);
            return $"{name} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            this.hotel.ValidateAnimalIsExist(animalName);
            var animal = hotel.Animals.First(a => a.Key == animalName).Value;
            if (!this.adoptedAnimals.ContainsKey(owner))
            {
                this.adoptedAnimals[owner] = new List<IAnimal>();
            }

            this.adoptedAnimals[owner].Add(animal);
            this.hotel.Adopt(animalName, owner);
            return AnimaIsChiped(animal, owner);
        }

        public string History(string type)
        {
            var builder = new StringBuilder();
            builder.Append(this.procedures[type].History());

            return builder.ToString();
        }

        public string AdoptedAnimals()
        {
            var builder = new StringBuilder();

            foreach (var owner in adoptedAnimals.OrderBy(n => n.Key))
            {
                builder.AppendLine($"--Owner: {owner.Key}");
                builder.AppendLine($"    - Adopted animals: {string.Join(' ', owner.Value.Select(a => a.Name))}");
            }

            return builder.ToString();
        }

        private string AnimaIsChiped(IAnimal animal, string owner)
        {
            if (animal.IsChipped == true)
            {
                return $"{owner} adopted animal with chip";
            }
            else
            {
                return $"{owner} adopted animal without chip";
            }
        }
    }
}
