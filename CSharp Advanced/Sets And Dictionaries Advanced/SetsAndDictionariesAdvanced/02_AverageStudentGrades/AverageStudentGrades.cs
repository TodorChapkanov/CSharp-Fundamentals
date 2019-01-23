namespace _02_AverageStudentGrades
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class AverageStudentGrades
    {
        public static void Main()
        {
            var numberCommands = int.Parse(Console.ReadLine());

            var studentsGrades = new Dictionary<string, List<double>>();

            for (int c = 0; c < numberCommands; c++)
            {
                var line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var studentName = line[0];
                var grade = double.Parse(line[1]);

                if (!studentsGrades.ContainsKey(studentName))
                {
                    studentsGrades[studentName] = new List<double>();
                }
                studentsGrades[studentName].Add(grade);
            }
            
            foreach (var student in studentsGrades)
            {
                var average = student.Value.Average();
                var name = student.Key;
                var grades = student.Value;

                Console.Write($"{name} -> ");
                foreach (var grade in student.Value)
                {
                    Console.Write($"{grade:f2} ");
                }
                Console.WriteLine($"(avg: {average:f2})");
                    
                    
            }
        }
    }
}
