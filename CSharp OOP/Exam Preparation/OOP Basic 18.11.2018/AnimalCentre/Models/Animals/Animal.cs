using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        private int hapiness;
        private int energy;

        protected Animal(string name, int energy, int happiness, int procedureTime)
        {
            Name = name;
            Happiness = happiness;
            Energy = energy;
            ProcedureTime = procedureTime;
            Owner = "Centre";
            IsAdopt = false;
            IsChipped = false;
            IsVaccinated = false;
        }

        public string Name { get; private set; }

        public int Happiness
        {
            get => this.hapiness;
            set
            {
                this.ValidatePoints(value, nameof(Happiness).ToLower());
                this.hapiness = value;
            }
        }

        public int Energy
        {
            get => this.energy;
            set
            {
                this.ValidatePoints(value, nameof(Energy).ToLower());
                this.energy = value;
            }
        }

        public int ProcedureTime { get; set; }

        public string Owner { get; set; }

        public bool IsAdopt { get; set; }

        public bool IsChipped { get; set; }

        public bool IsVaccinated { get; set; }

        private void ValidatePoints(int value, string type)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"Invalid {type}");
            }
        }
    }
}
