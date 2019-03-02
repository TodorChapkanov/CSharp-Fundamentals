namespace _04_Team
{
    using System.Collections.Generic;
    using System.Text;

    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team(string name)
        {
            this.name = name;
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }

        public IReadOnlyList<Person> FirstTeam
        {
            get
            {
                return this.firstTeam.AsReadOnly();
            }
        }

        public IReadOnlyList<Person> ReserveTeam
        {
            get
            {
                return this.reserveTeam.AsReadOnly();
            }
        }

        public void AddPlayer(Person player)
        {
            if (player.Age >= 40)
            {
                this.reserveTeam.Add(player);
            }

            else
            {
                firstTeam.Add(player);
            }
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"First team has {this.firstTeam.Count} players.");
            stringBuilder.Append($"Reserve team has {this.reserveTeam.Count} players.");

            return stringBuilder.ToString();
        }
    }
}
