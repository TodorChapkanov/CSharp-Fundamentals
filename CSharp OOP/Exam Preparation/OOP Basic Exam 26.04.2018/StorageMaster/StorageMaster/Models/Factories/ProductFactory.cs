using StorageMaster.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace StorageMaster.Models.Factories
{
    public class ProductFactory
    {
        public static Product CreateProduct(string type, double price)
        {
            var productType = Assembly
            .GetCallingAssembly()
            .GetTypes()
            .FirstOrDefault(s => s.Name == type);
            Product instance;

            if (productType == null || productType.IsAbstract)
            {
                return null;
            }

            try
            {
                instance = (Product)Activator.CreateInstance(productType, new object[] { price });
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }

            return instance;
        }
    }
}
