namespace P03.DetailPrinter
{
    using System;
    using System.Collections.Generic;

    public class DetailsPrinter
    {
        protected IList<Employee> employees;

        public DetailsPrinter(IList<Employee> employees)
        {
            this.employees = employees;
        }

        public void PrintDetails()
        {
            foreach (Employee employee in this.employees)
            {
                Console.WriteLine(employee);
            }
        }
    }
}
