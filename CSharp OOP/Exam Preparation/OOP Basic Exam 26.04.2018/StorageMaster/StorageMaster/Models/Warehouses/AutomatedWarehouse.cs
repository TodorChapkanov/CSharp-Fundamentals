using StorageMaster.Models.Vehicles;
using System.Collections;
using System.Collections.Generic;

namespace StorageMaster.Models.Warehouses
{
    class AutomatedWarehouse : Storage
    {
        private static int AutomatedCapacity = 1;
        private static int AutomatedGarageSlots = 2;
        private static Vehicle[] vehicles = new Vehicle[] { new Truck() };

        public AutomatedWarehouse(string name) 
            : base(name, AutomatedCapacity, AutomatedGarageSlots, vehicles)
        {
        }
    }
}
