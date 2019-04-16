using DungeonsAndCodeWizards.Entities.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonsAndCodeWizards.Entities.Bags
{
   public abstract class Bag
    {
        private List<Item> items;

        public Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public int Capacity { get; private set; }

        public int Load => CalculateWeightOfItems();

        public IReadOnlyCollection<Item> Items
            => this.items.AsReadOnly();

       public void AddItem(Item item)
        {
            if (this.Load + item.Weight > Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            this.items.Add(item);
        }

       public Item GetItem(string name)
        {
            if (!this.items.Any())
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            if (!this.items.Any(i => i.GetType().Name == name))
            {
                throw new ArgumentException($"No item with name { name } in bag!");
            }

            var item =  this.items.First(i => i.GetType().Name == name);
            this.items.Remove(item);
            return item;
        }

        private int CalculateWeightOfItems()
        {
            var result = this.items.Sum(i => i.Weight);
            return result;
        }
    }
}
