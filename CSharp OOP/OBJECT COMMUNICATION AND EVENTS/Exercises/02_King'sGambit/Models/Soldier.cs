using _02_King_sGambit.Models.Contracts;
using System;

namespace _02_King_sGambit.Models
{
    public abstract class Soldier : IPerson
    {
        protected Soldier(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public abstract void KingIsUnderAttack(object sender, EventArgs args);
    }
}
