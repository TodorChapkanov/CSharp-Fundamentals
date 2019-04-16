using _02_King_sGambit.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _02_King_sGambit
{
    class RoyalGuard : Soldier
    {
        public RoyalGuard(string name) 
            : base(name)
        {
        }

        public override void KingIsUnderAttack(object sender, EventArgs args)
        {
            Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }
    }
}
