using StorageMaster.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageMaster.Models.Vehicles
{
    public abstract class Vehicle
    {
        private readonly List<Product> products;

        public Vehicle(int capacity)
        {
            this.Capacity = capacity;
            this.products = new List<Product>();
        }

        public int Capacity { get; private set; }

        public IReadOnlyCollection<Product> Trunk
            => products.AsReadOnly();

        public bool IsFull => this.IsTrunkFull();

        public bool IsEmpty => this.IsTrunkEmpty();

        public void LoadProduct(Product product)
        {
            if (IsFull)
            {
                throw new InvalidOperationException("Vehicle is full!");
            }

            this.products.Add(product);
        }

       public  Product Unload()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("No products left in vehicle!");
            }

            var product = this.products.Last();
            this.products.Remove(product);
            return product;
        }

        private bool IsTrunkEmpty()
        {
            var load = this.Trunk.Sum(l => l.Weight);
            if (load == 0)
            {
                return true;
            }

            return false;
        }

        private bool IsTrunkFull()
        {
            var load = this.Trunk.Sum(l => l.Weight);

            if (load >= this.Capacity)
            {
                return true;
            }

            return false;
        }
    }
}
