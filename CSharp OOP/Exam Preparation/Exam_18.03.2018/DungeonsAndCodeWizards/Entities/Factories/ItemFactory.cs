using DungeonsAndCodeWizards.Entities.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DungeonsAndCodeWizards.Entities.Factories
{
   public class ItemFactory
    {
        public static Item CreateItem(string type)
        {
            Item item;
            try
            {
                var itemType = Assembly
                    .GetCallingAssembly()
                    .GetTypes()
                    .FirstOrDefault(i => i.GetTypeInfo().Name == type);

                item = (Item)Activator.CreateInstance(itemType, new object[0]);
            }
            catch (Exception)
            {

                throw new ArgumentException($"Invalid item \"{ type }\"!");
            }

            return item;
        }
    }
}
