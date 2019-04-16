using _02_King_sGambit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02_King_sGambit.Core
{
   public  class Engine
    {
        private King king;
        private List<Soldier> sodiers;

        public Engine()
        {
            this.sodiers = new List<Soldier>();
        }

        public void Run()
        {


            var kingName = Console.ReadLine();
            this.king = new King(kingName);

            var royalGuardNames = Console.ReadLine().Split();

            foreach (var royalGuardName in royalGuardNames)
            {
                var guard = new RoyalGuard(royalGuardName);
                this.king.UnderAttack += guard.KingIsUnderAttack;
                this.sodiers.Add(guard);
            }

            var footmanNames = Console.ReadLine().Split();
            foreach (var footmanName in footmanNames)
            {
                var footman = new Footman(footmanName);
                this.king.UnderAttack += footman.KingIsUnderAttack;
                this.sodiers.Add(footman);
            }

            var commands = string.Empty;
            while ((commands = Console.ReadLine()) != "End")
            {
                var command = commands.Split()[0];

                switch (command)
                {
                    case "Attack":
                        king.Attack();
                        break;

                    case "Kill":
                        var soldierName = commands.Split()[1];
                        var soldier = this.sodiers.FirstOrDefault(s => s.Name == soldierName);
                        this.king.UnderAttack -= soldier.KingIsUnderAttack;
                        this.sodiers.Remove(soldier);
                        break;
                }
            }

        }
    }
}
