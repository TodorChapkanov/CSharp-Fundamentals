namespace _03_Mankind
{
    using _03_Mankind.Data;
    using System;

    public class StartUp
    {
       public static void Main()
        {
            var studentArguments = Console.ReadLine().Split();
            var workerArguments = Console.ReadLine().Split();
            Student student = null;
            Worker worker = null;

            try
            {
                var studentFirstName = studentArguments[0];
                var studentLastName = studentArguments[1];
                var facultyNumber = studentArguments[2];
                 student = new Student(studentFirstName, studentLastName, facultyNumber);

                var workerFirsName = workerArguments[0];
                var workerLastName = workerArguments[1];
                var weekSalary = decimal.Parse(workerArguments[2]);
                var hoursPerDay = decimal.Parse(workerArguments[3]);

                 worker = new Worker(workerFirsName, workerLastName, weekSalary, hoursPerDay);
            }
            catch (ArgumentException message)
            {

                Console.WriteLine(message.Message);
                return;
            }

            Console.WriteLine(student);
            Console.WriteLine(worker);
        }
    }
}
