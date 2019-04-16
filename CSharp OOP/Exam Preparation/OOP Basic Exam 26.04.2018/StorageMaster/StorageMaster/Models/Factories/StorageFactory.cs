using StorageMaster.Models.Vehicles;
using StorageMaster.Models.Warehouses;
using System;
using System.Linq;
using System.Reflection;

namespace StorageMaster.Models.Factories
{
    public  class StorageFactory
    {
        public static Storage CreateStorage(string type, string name)
        {
            var storageType = Assembly
            .GetCallingAssembly()
            .GetTypes()
            .FirstOrDefault(s => s.Name == type);

            if (storageType == null || storageType.IsAbstract)
            {
                return null;
            }
            var instance = (Storage)Activator.CreateInstance(storageType, new object[] { name });

            return instance;
        }
        
    }
}
