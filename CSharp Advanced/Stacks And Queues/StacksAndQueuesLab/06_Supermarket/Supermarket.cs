namespace _06_Supermarket
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Supermarket
    {
        public static void Main()
        {
            var customers = new Queue<string>();

            var sb = new StringBuilder();
            while (true)
            {
                var input = Console.ReadLine();

                if (input == "End")
                {
                    Console.Write(sb);
                    Console.WriteLine($"{customers.Count} people remaining.");
                    break;
                }
                else if (input == "Paid")
                {
                    while (customers.Any())
                    {
                        var curentCustomer = customers.Dequeue();
                        sb.AppendLine(curentCustomer);
                    }
                }
                else
                {
                    customers.Enqueue(input);
                }
            }
        }
    }
}
