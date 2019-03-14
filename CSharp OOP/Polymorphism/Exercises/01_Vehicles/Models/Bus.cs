namespace _01_Vehicles.Models
{
    using System;

    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumprion, double tankCapacity)
            :base(fuelQuantity, fuelConsumprion, tankCapacity)
        {
        }

        public override string Drive(double distance)
        {
            var neededFuel = distance * (base.FuelConsumption + 1.4);

            if (neededFuel > base.FuelQuantity)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            base.FuelQuantity -= neededFuel;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public string DriveEmpty(double distance)
        {
            base.Drive(distance);
            return $"{this.GetType().Name} travelled {distance} km";
        }
    }
}
