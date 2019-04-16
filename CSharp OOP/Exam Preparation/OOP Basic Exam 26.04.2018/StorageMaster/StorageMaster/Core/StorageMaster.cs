using StorageMaster.Models.Factories;
using StorageMaster.Models.Products;
using StorageMaster.Models.Vehicles;
using StorageMaster.Models.Warehouses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Core
{
   public class StorageMaster
    {
        private IDictionary<string,Storage> storageRegistry;
        private List<Product> productPool;
        private Vehicle vehicle;

        public StorageMaster()
        {
            this.storageRegistry = new Dictionary<string, Storage>();
            this.productPool = new List<Product>();
        }

        public string AddProduct(string type, double price)
        {
            var product = ProductFactory.CreateProduct(type, price);

            if (product == null)
            {
                throw new InvalidOperationException("Invalid product type!");
            }
           
            this.productPool.Add(product);
            var orderedList = this.productPool.OrderBy(p => p.GetType().Name).ThenByDescending(p => p.Price).ToList();
            
            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            var storage = StorageFactory.CreateStorage(type, name);

            if (storage == null)
            {
                throw new InvalidOperationException("Invalid storage type!");
            }

            this.storageRegistry.Add(storage.Name, storage);
            return $"Registered {name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            this.vehicle = this.storageRegistry[storageName].GetVehicle(garageSlot);

            return $"Selected {vehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            var loadedProducts = 0;
            foreach (var product in productNames)
            {
                
                if (this.productPool.Any(p => p.GetType().Name == product))
                {
                    try
                    {
                        
                        var currentProduct = this.productPool.Last(p => p.GetType().Name == product);
                        this.vehicle.LoadProduct(currentProduct);
                        this.productPool.Remove(currentProduct);
                        loadedProducts++;
                    }
                    catch (Exception)
                    {
                    }
                    
                }

                else
                {
                    throw new InvalidOperationException($"{product} is out of stock!");
                }
                
            }

            return $"Loaded { loadedProducts}/{ productNames.Count()}" +
                $" products into { this.vehicle.GetType().Name}";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            if (!this.storageRegistry.ContainsKey(sourceName) 
                || !this.storageRegistry.ContainsKey(destinationName))
            {
                var message = !this.storageRegistry.ContainsKey(sourceName)
                    ? "Invalid source storage!"
                    : "Invalid destination storage!";
                throw new InvalidOperationException(message);
            }

            var sourceStore = this.storageRegistry[sourceName];
            var destination = this.storageRegistry[destinationName];
            var vehicle = sourceStore.GetVehicle(sourceGarageSlot);
           var destinationSlot = sourceStore.SendVehicleTo(sourceGarageSlot, destination);

            return $"Sent {vehicle.GetType().Name} to {destinationName} (slot {destinationSlot})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            var store = this.storageRegistry[storageName];
            var productsInVehicle = store.GetVehicle(garageSlot).Trunk.Count();
           var unloadedProductsCount =  store.UnloadVehicle(garageSlot);
            return $"Unloaded { unloadedProductsCount}/{ productsInVehicle} products at { storageName}";
        }

        public string GetStorageStatus(string storageName)
        {
            var storage = this.storageRegistry[storageName];
            var stock = storage
                .Products
                .GroupBy(p => p.GetType().Name)
                .OrderByDescending(p => p.Count())
                .ThenBy(p => p.Key)
                .Select(p =>$"{p.Key} ({p.Count()})")
                .ToArray();

            var garage = storage.Garage.Select(g => (g != null ? g.GetType().Name.ToString() : "empty")).ToArray();

            var builder = new StringBuilder();
            var totalWeight = storage.Products.Sum(p => p.Weight);
            var capacity = storage.Capacity;
            builder.AppendLine($"Stock ({totalWeight}/{capacity}): [{string.Join(", ", stock)}]");
            builder.Append($"Garage: [{string.Join('|', garage)}]");

            return builder.ToString();
        }

        public string GetSummary()
        {
            var builder = new StringBuilder();
           // this.storageRegistry.OrderByDescending(s => s.Value.Products.Sum(p => p.Price));
            
            foreach (var store in storageRegistry.OrderByDescending(s => s.Value.Products.Sum(p => p.Price)))
            {
                builder.AppendLine($"{store.Key}:");
                builder.AppendLine($"Storage worth: ${store.Value.Products.Sum(p => p.Price):f2}");
            }

            return builder.ToString().TrimEnd();
            
        }

    }
}
