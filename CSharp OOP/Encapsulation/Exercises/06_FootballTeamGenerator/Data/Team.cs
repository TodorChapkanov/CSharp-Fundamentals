using System;
using System.Collections.Generic;
namespace _06_FootballTeamGenerator.Data
{
    using _06_FootballTeamGenerator.ConstantData;
    using System.Linq;

    public class Team 
    {
        private string name;
        private double rating;
        private IList<Player> players;

        public Team(string name)
        {
            this.Name = name;
            players = new List<Player>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(Messages.EmptiName));
                }
                this.name = value;
            }
        }
        public double Rating => this.rating;

        public void AddPlayer(Player player)
        {
            
            players.Add(player);
        }

        public void Remove(string playerName)
        {
            if (!players.Any(p => p.Name == playerName) || string.IsNullOrWhiteSpace(playerName))
            {
                throw new ArgumentException(string.Format(Messages.MissingPlayer, playerName, this.name));
            }
            var player = this.players.FirstOrDefault(n => n.Name == playerName);
            players.Remove(player);
        }

        public double GetRating()
        {
            if (!players.Any())
            {
                return 0;
            }

          var sum = 0.0;
         
          foreach (var player in this.players)
          {
              sum += player.Rating;
          }
          sum /= this.players.Count;
         
          return sum;
        }
    }
}
