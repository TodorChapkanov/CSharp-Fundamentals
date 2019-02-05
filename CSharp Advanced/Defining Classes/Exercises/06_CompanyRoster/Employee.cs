namespace _06_CompanyRoster
{
   public class Employee
    {
        //: name, salary, position, department, email and age

        public Employee(string name, double salary, string position, string department, string email, int age)
        {
            this.Name = name;
            this.Salary = salary;
            this.Position = position;
            this.Department = department;
            this.Email = email;
            this.Age = age;
        }
        public Employee(string name, double salary, string position, string depatment, string email)
            :this( name, salary, position,  depatment, email, -1)
        {
        }

        public Employee(string name, double salary, string position, string department, int age )
            : this(name, salary, position, department, "n/a" ,age)
        {
        }

        public Employee(string name, double salary, string position, string deparment)
            : this(name, salary, position, deparment, "n/a", -1)
        {
        }


        public string Name { get; set; }

        public double Salary { get; set; }

        public string Position { get; set; }

        public string Department { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }
    }
}
