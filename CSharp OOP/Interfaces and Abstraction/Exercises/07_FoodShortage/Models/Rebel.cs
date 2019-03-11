using _07_FoodShortage.Contrcts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07_FoodShortage.Models
{
    class Rebel : Person, IBuyer
    {
        public Rebel(string name, int age, string group)
            :base(name, age)
        {
            this.Group = group;
            this.Food = 0;
        }

        public string Group { get; set; }

        public int Food { get; private set; }

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
