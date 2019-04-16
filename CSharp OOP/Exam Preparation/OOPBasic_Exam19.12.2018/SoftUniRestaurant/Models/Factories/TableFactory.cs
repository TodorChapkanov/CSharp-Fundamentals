using SoftUniRestaurant.Models.Tables.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace SoftUniRestaurant.Models.Factories
{
    public class TableFactory 
    {
        private const string Suffix = "Table";
        public static ITable CreateTable(string type, int tableNumber, int capacity)
        {
            var tableType = Assembly
               .GetCallingAssembly()
               .GetTypes()
               .FirstOrDefault(t => t.Name == type + Suffix);

            if (tableType == null)
            {
                return null;
            }

            var instance = (ITable)Activator.CreateInstance(tableType, new object[] { tableNumber, capacity });

            return instance;
        }
    }
}
