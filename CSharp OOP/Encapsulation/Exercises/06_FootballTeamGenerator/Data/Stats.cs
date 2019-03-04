namespace _06_FootballTeamGenerator.Data
{
    using System;
    using _06_FootballTeamGenerator.ConstantData;

   public class Stats
    {
        private double endurance;
        private double sprint;
        private double dribble;
        private double passing;
        private double shooting;

        public Stats(double endurance, double sprint, double dribble, double passing, double shoting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shoting;
        }
        
        internal double Endurance
        {
            get
            {
                return this.endurance;
            }
            private set
            {
                this.ValidateStats(nameof(Endurance), value);
                this.endurance = value;
            }
        }
        internal double Sprint
        {
            get
            {
                return this.sprint;
            }
            private set
            {
                this.ValidateStats(nameof(Sprint), value);
                this.sprint = value;
            }
        }

        internal double Dribble
        {
            get
            {
                return this.dribble;
            }

            private set
            {
                this.ValidateStats(nameof(Dribble), value);
                this.dribble = value;
            }
        }

        internal double Passing
        {
            get
            {
                return this.passing;
            }

            set
            {
                this.ValidateStats(nameof(Passing), value);
                this.passing = value;
            }
        }

        internal double Shooting
        {
            get
            {
                return this.shooting;
            }
            private set
            {
                this.ValidateStats(nameof(Shooting), value);
                this.shooting = value;
            }
        }

        private void ValidateStats(string stat, double value)
        {
            if (value <=0 || value > 100)
            {
                throw new ArgumentException(string.Format(Messages.StatsRange, stat));
            }
        }
    }
}
