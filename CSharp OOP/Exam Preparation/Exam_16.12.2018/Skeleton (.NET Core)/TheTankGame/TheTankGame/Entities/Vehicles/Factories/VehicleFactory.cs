using System.Reflection;
using TheTankGame.Entities.Vehicles.Contracts;
using TheTankGame.Entities.Vehicles.Factories.Contracts;
using System.Linq;
using System;
using TheTankGame.Entities.Miscellaneous;

namespace TheTankGame.Entities.Vehicles.Factories
{
    public class VehicleFactory : IVehicleFactory
    {
        public IVehicle CreateVehicle(string vehicleType, string model, double weight, decimal price, int attack, int defense, int hitPoints)
        {
            var vehicleAssembler = new VehicleAssembler();
            var vehicle = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .First(t => t.Name == vehicleType);
            var instance = (IVehicle)Activator
                .CreateInstance(vehicle, new object[] { model, weight, price, attack, defense, hitPoints, vehicleAssembler });

            return instance;
        }
    }
}
