namespace _07_SpeedRacing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumption = fuelConsumption;
        }
       

        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumption { get; set; }

        public double Distance { get; set; }

        public void CanDrive(double distance)
        {
            var fuelForDistance = distance * this.FuelConsumption;

            if (fuelForDistance > this.FuelAmount)
            {
                throw new InvalidOperationException("Insufficient fuel for the drive");
            }

            this.FuelAmount -= fuelForDistance;
            this.Distance += distance;
            
        }

        public override string ToString()
        {
            return $"{Model} {FuelAmount:f2} {Distance}"; 
        }
    }
}
