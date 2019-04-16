namespace MuOnline.Models.Inventories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Items.Contracts;

    public class Inventory : IInventory
    {
        private List<IItem> items;

        public Inventory()
        {
            this.items = new List<IItem>();
        }

        public IReadOnlyCollection<IItem> Items
            => this.items.AsReadOnly();

        public void AddItem(IItem item)
        {
            this.ValidateItem(item);
            this.items.Add(item);
        }

        public bool RemoveItem(IItem item)
        {
            this.ValidateItem(item);

            if (!this.items.Contains(item))
            {
                throw new ArgumentException("Invalit item type");
            }

            var result = this.items.Remove(item);
            return result;
        }

        public IItem GetItem(string item)
        {
            var result = this.items.FirstOrDefault(i => i.GetType().Name == item);
            this.ValidateItem(result);
            return result;
        }

        private void ValidateItem(IItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Invalid item type!");
            }
        }
    }
}
