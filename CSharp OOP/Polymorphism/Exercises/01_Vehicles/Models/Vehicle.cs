using System;

namespace _01_Vehicles.Models
{
    public abstract class Vehicle
    {
        internal const double CarFuelIncrease = 0.9;
        protected const double TruckFuelIncrease = 1.6;
        protected const double BusFuelIncrease = 1.4;

        private double fuelQuantity;
        private double fuelConsumptionPerKilometer;
        private double tankCapacity;

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;

        }


        public double FuelQuantity
        {
            get => this.fuelQuantity;
            set
            {
                if (value > this.TankCapacity)
                {
                    value = 0;
                }
                this.fuelQuantity = value;
            }
        }

        public double FuelConsumption
        {
            get => this.fuelConsumptionPerKilometer;
            set { this.fuelConsumptionPerKilometer = value; }
        }

        public double TankCapacity
        {
            get => this.tankCapacity;
            private set { this.tankCapacity = value; }
        }

        public virtual string Drive(double distance)
        {
            this.CheckFuelIsЕnough(distance);
            this.fuelQuantity -= distance * this.FuelConsumption;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double fuelQuantity)
        {
            this.ValidateFuelAmount(fuelQuantity);
            this.FuelQuantity += fuelQuantity;
        }


        protected virtual void CheckFuelIsЕnough(double distance)
        {
            var neededFuel = distance * this.FuelConsumption;
            if (neededFuel > this.FuelQuantity)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }
        }

        internal void ValidateFuelAmount(double fuelAmount)
        {
            if (fuelAmount <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            if (fuelAmount > this.TankCapacity - this.FuelQuantity)
            {
                throw new ArgumentException($"Cannot fit {fuelAmount} fuel in the tank");
            }
        }
    }
}
