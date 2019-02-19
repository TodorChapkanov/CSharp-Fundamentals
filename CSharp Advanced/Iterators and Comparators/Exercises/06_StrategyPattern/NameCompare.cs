namespace _06_StrategyPattern
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class NameCompare : IComparer<Person>
    {
        public int Compare(Person firstPerson, Person secondPerson)
        {
            var result = firstPerson.Name.Length.CompareTo(secondPerson.Name.Length);

            if (result != 0)
            {
                return result;
            }
            var firstPersonLetter = firstPerson.Name.ToLower()[0];
            var secondPersonLetter = secondPerson.Name.ToLower()[0];
            return firstPersonLetter.CompareTo(secondPersonLetter);
        }
    }
}
