namespace _04_ShoppingSpree
{
    using System;
    using _04_ShoppingSpree.Models;
    using System.Collections.Generic;
    using System.Linq;
    public class StartUp
    {
        public static void Main()
        {
            var peopleInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            var productsInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            var productCatalog = new List<Product>();
            var allPeople = new List<Person>();
            try
            {
                GetPeople(peopleInput, allPeople);
                GetProducts(productsInput, productCatalog);

            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            string line;
            while ((line = Console.ReadLine()) != "END")
            {
                try
                {
                    var arguments = line.Split();
                    var personName = arguments[0];
                    var productName = arguments[1];
                    var person = allPeople.First(p => p.Name == personName);
                    var product = productCatalog.FirstOrDefault(p => p.Name == productName);
                    person.Buy(product);
                }

                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            try
            {
                Console.WriteLine(string.Join(Environment.NewLine, allPeople));
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
            }
            
        }
        private static void GetPeople(string[] peopleInput, List<Person> people)
        {
            for (int i = 0; i < peopleInput.Length; i++)
            {
                var arguments = peopleInput[i].Split('=');
                var name = arguments[0];
                var budget = double.Parse(arguments[1]);
                var person = new Person(name, budget);
                people.Add(person);

            }
        }

        private static void GetProducts(string[] productsInput, List<Product> productCatalog)
        {
            for (int i = 0; i < productsInput.Length; i++)
            {
                var arguments = productsInput[i].Split('=');
                var name = arguments[0];
                var price = double.Parse(arguments[1]);
                var product = new Product(name, price);
                productCatalog.Add(product);
            }
        }

    }
}
