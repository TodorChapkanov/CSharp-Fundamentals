namespace _02_PersonsInfo
{
    public class Person
    {
        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.salary = salary;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public int Age { get; private set; }

        public void IncreaseSalary(decimal percentage)
        {
            if (this.Age < 30)
            {
                this.salary += salary * ((percentage / 2) / 100);
            }
            else
            {
                this.salary += salary * (percentage / 100);
            }
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.salary:f2} leva.";
        }
    }
}
