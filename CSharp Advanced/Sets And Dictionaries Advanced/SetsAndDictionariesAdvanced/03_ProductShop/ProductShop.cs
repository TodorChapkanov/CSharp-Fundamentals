namespace _03_ProductShop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductShop
    {
        public static void Main()
        {
            var shopsAndProducts = new Dictionary<string, Dictionary<string, double>>();

            while (true)
            {
                var line = Console.ReadLine()
                    .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (line[0] == "Revision")
                {
                    break;
                }
                var shop = line[0];
                var product = line[1];
                var price = double.Parse(line[2]);

                if (!shopsAndProducts.ContainsKey(shop))
                {
                    shopsAndProducts.Add(shop, new Dictionary<string, double>());
                }
                if (!shopsAndProducts[shop].ContainsKey(product))
                {
                    shopsAndProducts[shop][product]= price;
                }
                shopsAndProducts[shop][product] = price;

            }
            foreach (var shop in shopsAndProducts.OrderBy(s => s.Key))
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
