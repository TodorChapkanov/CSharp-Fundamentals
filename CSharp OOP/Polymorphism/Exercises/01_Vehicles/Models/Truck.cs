using System;

namespace _01_Vehicles.Models
{
   public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            :base(fuelQuantity, fuelConsumption + TruckFuelIncrease, tankCapacity)
        {
        }

        public override void Refuel(double fuelQuantity)
        {
            ValidateFuelAmount(fuelQuantity);
            this.FuelQuantity += fuelQuantity*0.95;
        }
    }
}
