using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models.Warehouses
{
  public  class DistributionCenter : Storage
    {
        private static int DistributionCapacity = 2;
        private static int DistributionGarageSlots = 5;
        private static Vehicle[] vehicles = new Vehicle[]
        {
            new Van(),
            new Van(),
            new Van()
        };

        public DistributionCenter(string name)
            : base(name, DistributionCapacity, DistributionGarageSlots, vehicles)
        {
        }
    }
}
