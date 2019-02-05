namespace _06_CompanyRoster
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var count = int.Parse(Console.ReadLine());

            Employee employee;
            var employees = new List<Employee>();

            for (int i = 0; i < count; i++)
            {
                var line = Console.ReadLine().Split();
                

                var name = line[0];
                var salary = double.Parse(line[1]);
                var position = line[2];
                var department = line[3];

                if (line.Length == 4)
                {
                     employee = new Employee(name, salary, position, department);
                }
                else if (line.Length ==5)
                {
                    if (line[line.Length-1].Contains('.'))
                    {
                        var email = line[line.Length - 1];
                        employee = new Employee(name, salary, position, department, email);
                    }
                    else
                    {
                        var age = int.Parse(line[line.Length - 1]);
                        employee = new Employee(name, salary, position, department, age);
                    }
                }
                else
                {
                    var email = line[line.Length - 2];
                    var age = int.Parse(line[line.Length - 1]);
                    employee = new Employee(name, salary, position, department, email, age);
                }

                employees.Add(employee);
            }

            var mostPaidDepartment = employees
                .GroupBy(d => d.Department)
                .OrderByDescending(s => s.Select(p => p.Salary).Average())
                .FirstOrDefault().Key;

            Console.WriteLine($"Highest Average Salary: {mostPaidDepartment}");

            foreach (var person in employees.Where(d => d.Department == mostPaidDepartment).OrderByDescending(s => s.Salary))
            {
                Console.WriteLine($"{person.Name} {person.Salary:f2} {person.Email} {person.Age}");
            }

        }
    }
}
