namespace _02_ExtendedDatabase.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class Database
    {
        private IList<IPerson> people;

        public Database(params IPerson[] people)
        {
            this.people = new List<IPerson>(people);
        }


        public IPerson this[int index] => this.people[index];
        public int Count => this.people.Count;

        public void Add(IPerson person)
        {
            var personUsername = person.Name;
            var personId = person.Id;

            if (people.Any(p => p.Name == personUsername))
            {
                throw new InvalidOperationException();
            }

            if (people.Any(p => p.Id == personId))
            {
                throw new InvalidOperationException();
            }

            this.people.Add(person);
        }

        public void Remove(IPerson person)
        {
            if (!this.people.Contains(person) || !people.Any())
            {
                throw new InvalidOperationException();
            }

            people.Remove(person);
        }

        public IPerson FindByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException();
            }

            return this.people
                 .FirstOrDefault(p => p.Name == username)
                 ?? throw new InvalidOperationException();
        }

        public IPerson FindById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            return this.people
                .FirstOrDefault(p => p.Id == id)
                ?? throw new InvalidOperationException();
        }
    }
}
