namespace _06_StrategyPattern
{
using System;
using System.Collections.Generic;
using System.Text;

   public class AgeCompare : IComparer<Person>
    {
        public int Compare(Person firstPerson, Person secondPerson)
        {
            return firstPerson.Age.CompareTo(secondPerson.Age);
        }
    }
}
