using StorageMaster.Models.Vehicles;

namespace StorageMaster.Models.Warehouses
{
    public class Warehouse : Storage
    {
        private static int WarehouseCapacity = 10;
        private static int WarehouseGarageSlots = 10;
        private static Vehicle[] vehicles = new Vehicle[]
        {
            new Semi(),
            new Semi(),
            new Semi()
        };

        public Warehouse(string name)
            : base(name, WarehouseCapacity, WarehouseGarageSlots, vehicles)
        {
        }
    }
}
