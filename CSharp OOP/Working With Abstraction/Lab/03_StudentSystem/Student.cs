﻿namespace P03_StudentSystem
{
    using System;
    using System.Collections.Generic;

    public class Student
    {
        public Student(string name, int age, double grade)
        {
            this.Name = name;
            this.Age = age;
            this.Grade = grade;
        }
        public string Name { get; set; }

        public int Age { get; set; }

        public double Grade { get; set; }

        
        public override string ToString()
        {
            var studentInfo = $"{this.Name} is {this.Age} years old.";
            if (this.Grade >= 5.00)
            {
                studentInfo += " Excellent student.";
            }

            else if (this.Grade < 5.00 && this.Grade >= 3.50)
            {
                studentInfo += " Average student.";
            }

            else
            {
                studentInfo += " Very nice person.";
            }
            return studentInfo;
        }
    }
}