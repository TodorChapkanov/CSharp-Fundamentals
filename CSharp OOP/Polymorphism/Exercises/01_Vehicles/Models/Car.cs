namespace _01_Vehicles.Models
{
   public class Car :Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            :base(fuelQuantity, fuelConsumption + CarFuelIncrease, tankCapacity)
        {
        }

    }
}
