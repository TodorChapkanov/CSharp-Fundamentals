namespace P03_StudentSystem
{
    using System;


    public class Startup
    {
       public static void Main()
        {
            var commandParser = new CommandParser();
            var studentSystem = new StudentData();
            while (true)
            {
                var command = commandParser.Parse(Console.ReadLine());

                if (command.Name == "Create")
                {
                    var name = command.Argumentd[0];
                    var age = int.Parse(command.Argumentd[1]);
                    var grade = double.Parse(command.Argumentd[2]);

                    studentSystem.Create(name, age, grade);
                }
                else if (command.Name == "Show")
                {
                    var name = command.Argumentd[0];
                    Console.WriteLine(studentSystem.Show(name));
                    
                }
                if (command.Name == "Exit")
                {
                    break;
                }
            }
        }
    }
}
