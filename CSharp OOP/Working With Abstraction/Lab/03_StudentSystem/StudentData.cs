namespace P03_StudentSystem
{
    using System;
    using System.Collections.Generic;


    class StudentData
    {
        private Dictionary<string, Student> students;

        public StudentData()
        {
            this.students = new Dictionary<string, Student>();
        }
        
        public void Create(string name, int age, double grade)
        {
            if (!this.students.ContainsKey(name))
            {
                var student = new Student(name, age, grade);
                this.students[name] = student;
            }
        }

        public Student Show(string name)
        { 
            if (this.students.ContainsKey(name))
            {
                var student = students[name];
                return student;
            }

            else
            {
                return null;
            }
        }
    }
}
