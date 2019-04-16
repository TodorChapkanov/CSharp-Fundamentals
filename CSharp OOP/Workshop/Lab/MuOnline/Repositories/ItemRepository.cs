namespace MuOnline.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Utilities;

    using Contracts;
    using MuOnline.Models.Items.Contracts;

    public class ItemRepository : IRepository<IItem>
    {
        private readonly List<IItem> itemRepository;

        public ItemRepository()
        {
            this.itemRepository = new List<IItem>();
        }

        public IReadOnlyCollection<IItem> Repository
            => this.itemRepository.AsReadOnly();

        public void Add(IItem item)
        {
            Validators.ValidateNullInput<IItem>(item, item.GetType().Name);
            this.itemRepository.Add(item);
        }

        public bool Remove(IItem item)
        {
            bool isRemoved = this.itemRepository.Remove(item);
            return isRemoved;
        }

        public IItem Get(string item)
        {
            var targetItem = this.itemRepository.FirstOrDefault(x => x.GetType().Name == item);
            Validators.ValidateNullInput<IItem>(targetItem, targetItem.GetType().Name);
            return targetItem;
        }

        
    }
}
