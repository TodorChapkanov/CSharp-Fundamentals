﻿using System;
using System.Collections.Generic;
using System.Text;
namespace _03_WildFarm.Models.Animals
{
   public abstract class Mammal : Animal
    {
        private string livingRegion;

        public Mammal(string name, double weight,  string livingRegion)
            : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion
        {
            get => this.livingRegion;
            set { this.livingRegion = value; }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{ this.Name}, { this.Weight}, { this.LivingRegion}, {this.FoodEaten}]";
            
        }
    }
}
