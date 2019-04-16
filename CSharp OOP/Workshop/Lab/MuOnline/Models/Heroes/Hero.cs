namespace MuOnline.Models.Heroes
{
    using System;
    using System.Linq;

    using HeroContracts;
    using Inventories;
    using Inventories.Contracts;

    public abstract class Hero : IHero, IIdentifiable, IProgress
    {
        public const string InvalidAbilitiesPoints = "{0} cannot be less than zero!";

        private string username;
        private int strength;
        private int agility;
        private int stamina;
        private int energy;
        private int experience;
        private int level;
        private int resets;
        private int totalAgilityPoints;
        private int totalAttackPoints;
        private int totalEnergyPoints;
        private int totalStaminaPoints;

        protected Hero(
            string username,
            int strength, int agility, int stamina, int energy)
        {
            this.Username = username;
            this.Strength = strength;
            this.Agility = agility;
            this.Stamina = stamina;
            this.Energy = energy;
            this.Experience = 0;
            this.Level = 0;
            this.Resets = 0;

            this.Inventory = new Inventory();
        }

        public IInventory Inventory { get; }

        public bool IsAlive
            => this.totalStaminaPoints > 0;

        public string Username
        {
            get
            {
                return this.username;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Username cannot be null!");
                }

                this.username = value;
            }
        }

        public int Strength
        {
            get
            {
                return this.strength;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(InvalidAbilitiesPoints, nameof(Strength)));
                }

                this.strength = value;
            }
        }

        public int Agility
        {
            get
            {
                return this.agility;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(InvalidAbilitiesPoints, nameof(Agility)));
                }

                this.agility = value;
            }
        }

        public int Stamina
        {
            get
            {
                return this.stamina;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(InvalidAbilitiesPoints, nameof(Stamina)));
                }

                this.stamina = value;
            }
        }

        public int Energy
        {
            get
            {
                return this.energy;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(InvalidAbilitiesPoints, nameof(Energy)));
                }

                this.energy = value;
            }
        }

        public int Experience
        {
            get
            {
                return this.experience;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(InvalidAbilitiesPoints, nameof(Experience)));
                }

                this.experience = value;
            }
        }

        public int Level
        {
            get
            {
                return this.level;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(InvalidAbilitiesPoints, nameof(Level)));
                }

                this.level = value;
            }
        }

        public int Resets
        {
            get
            {
                return this.resets;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(InvalidAbilitiesPoints, nameof(Resets)));
                }

                this.resets = value;
            }
        }

        public void TakeDamage(int damagePoints)
        {
            if (this.TotalAgilityPoints > 0)
            {
                this.TotalAgilityPoints -= damagePoints;
            }
            else
            {
                this.TotalStaminaPoints -= damagePoints;
            }
        }

        public void AddExperience(int experience)
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Hero is not alive!");
            }

            this.Experience += experience;

            if (this.Experience >= 9000)
            {
                AddLevel();
            }

            if (this.Level >= 400)
            {
                AddReset();
            }
        }

        private void AddReset()
        {
            this.resets++;
        }

        private void AddLevel()
        {
            this.level++;
        }

        public int TotalAttackPoints
        {
            get
            {
                return this.totalAttackPoints;
            }
            private set
            {
                totalAttackPoints = this.SetTotalAttackPoints();
            }
        }


        public int TotalEnergyPoints
        {
            get
            {
                return this.totalEnergyPoints;
            }
            private set
            {
                this.totalEnergyPoints = this.SetTotalEnergyPoints();
            }
        }


        public int TotalAgilityPoints
        {
            get
            {
                return this.totalAgilityPoints;
            }
            private set
            {
                this.totalAgilityPoints = this.SetTotalAgilityPoints();
            }
        }

        public int TotalStaminaPoints
        {
            get
            {
                return this.totalStaminaPoints;
            }
            private set
            {
                this.totalStaminaPoints = this.SetTotalStaminaPoints();
            }
        }

        private int SetTotalEnergyPoints()
        {
            var result = this.Energy + this.Inventory.Items.Sum(x => x.Energy);
            return result;
        }

        private int SetTotalAttackPoints()
        {
            var result = this.Strength +
                this.Agility * 10 / 100 +
                this.Energy * 5 / 100 +
                this.Inventory.Items.Sum(x => x.Strength);
            return result;
        }

        private int SetTotalAgilityPoints()
        {
            var result = this.Agility + this.Inventory.Items.Sum(x => x.Agility);
            return result;
        }

        private int SetTotalStaminaPoints()
        {
            var result = this.Stamina + this.Inventory.Items.Sum(x => x.Stamina);
            return result;
        }
    }
}
