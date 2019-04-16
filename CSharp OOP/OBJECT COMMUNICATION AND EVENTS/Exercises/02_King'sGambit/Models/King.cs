using _02_King_sGambit.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _02_King_sGambit
{
    public class King : IPerson
    {
        public King(string name)
        {
            Name = name;
        }

        public event EventHandler UnderAttack;

        public string Name { get; private set; }

        public void Attack()
        {
            Console.WriteLine($"King {this.Name} is under attack!");
            UnderAttack?.Invoke(this, EventArgs.Empty);
        }
    }
}
