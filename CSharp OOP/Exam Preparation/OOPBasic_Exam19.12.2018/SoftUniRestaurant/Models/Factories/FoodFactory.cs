
using SoftUniRestaurant.Models.Foods.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace SoftUniRestaurant.Models.Factories
{
    public class FoodFactory 
    {
        public static IFood CreateFood(string type, string name, decimal price)
        {
            var foodtype = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == type);
            IFood instance;
           
            try
            {
                instance = (IFood)Activator.CreateInstance(foodtype, new object[] { name, price });
            }
            catch (Exception ex )
            {

                throw new ArgumentException(ex.InnerException.Message);
            }
            
            return instance;
        }
    }
}
