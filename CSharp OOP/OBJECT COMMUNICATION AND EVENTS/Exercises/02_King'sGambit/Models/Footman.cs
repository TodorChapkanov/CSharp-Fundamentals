using _02_King_sGambit.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _02_King_sGambit
{
    public class Footman : Soldier
    {
        public Footman(string name)
            : base(name)
        {
        }

        public override void KingIsUnderAttack(object sender, EventArgs args)
        {
            Console.WriteLine($"Footman {this.Name} is panicking!");
        }
    }
}
