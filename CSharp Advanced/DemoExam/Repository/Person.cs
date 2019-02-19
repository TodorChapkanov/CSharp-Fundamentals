﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
   public class Person
    {
        public Person(string name, int age, DateTime birthdata)
        {
            this.Name = name;
            this.Age = age;
            this.Birthdate = birthdata;
        }
        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime Birthdate { get; set; }
    }
}
