using StorageMaster.Models.Products;
using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Models.Warehouses
{
    public abstract class Storage
    {
        private Vehicle[] garage;
        private List<Product> products;

        public Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;
            this.garage = new Vehicle[GarageSlots];
            this.products = new List<Product>();
            this.SetInitialVehiclesInGarage(vehicles);
        }

        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public int GarageSlots { get;}

        public bool IsFull => this.products.Sum(p => p.Weight) >= this.Capacity;

        public IReadOnlyCollection<Vehicle> Garage
            => Array.AsReadOnly(garage);

        public IReadOnlyCollection<Product> Products
            => this.products.AsReadOnly();

        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot < 0 || garageSlot >= this.GarageSlots)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }

            if (this.garage[garageSlot] == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }

            return this.garage[garageSlot];
        }

       public  int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            var vehicle = this.GetVehicle(garageSlot);
            var index = -1;
            Vehicle freeGarageSlot;
            try
            {
                freeGarageSlot = deliveryLocation.garage.First(s => s == null);
                index = Array.IndexOf(deliveryLocation.garage, freeGarageSlot);
            }
            catch (Exception)
            {
                throw new InvalidOperationException("No room in garage!");
            }

            freeGarageSlot = vehicle;
            this.garage[garageSlot] = null;
            
            deliveryLocation.garage[index] = vehicle;
            return index;
        }

        public int UnloadVehicle(int garageSlot)
        {
            var vehicle = this.GetVehicle(garageSlot);
            if (this.IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }

            var unloadedProductsCount = 0;
            while (!vehicle.IsEmpty && !this.IsFull)
            {
               
                var unloadedProduct = vehicle.Unload();
                this.products.Add(unloadedProduct);
                unloadedProductsCount++;
            }

            return unloadedProductsCount;
        }
        

        private void SetInitialVehiclesInGarage(IEnumerable<Vehicle> vehicles)
        {
            var index = 0;
            foreach (var vehicle in vehicles)
            {
                this.garage[index] = vehicle;
                index++;
            }
        }
    }
}
