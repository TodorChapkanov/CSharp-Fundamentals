namespace _06_FootballTeamGenerator
{
    using System;
    using _06_FootballTeamGenerator.ConstantData;
    using _06_FootballTeamGenerator.Data;

   public class Player
    {
        private string name;
        private double rating;
        private Stats stats;

        public Player(string name, Stats stats)
        {
            this.Name = name;
            this.stats = stats;
            this.rating = SetRating();
        }


        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(Messages.EmptiName));
                }
                this.name = value;
            }
        }
        public double Rating => this.rating;

        private double SetRating()
        {
            double result = (this.stats.Endurance
                + this.stats.Dribble
                + this.stats.Passing
                + this.stats.Shooting
                + this.stats.Sprint)
                / 5;

            return result;
        }

    }
}
