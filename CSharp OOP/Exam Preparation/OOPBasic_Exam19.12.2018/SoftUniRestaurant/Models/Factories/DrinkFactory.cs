using SoftUniRestaurant.Models.Drinks.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace SoftUniRestaurant.Models.Factories
{
    public class DrinkFactory
    {
        public static IDrink CreateDrink(string type, string name, int servingSize, string brand)
        {
            var foodType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .First(t => t.Name == type);
            IDrink instance;
            try
            {
                instance = (IDrink)Activator
               .CreateInstance(foodType, new object[] { name, servingSize, brand });
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.InnerException.Message);
            }
            
            return instance;
        }
    }
}
