namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class Repository
    {
        public Repository()
        {
            this.Id = 0;
            this.Repositorys = new Dictionary<int,Person>();
        }
        public Dictionary<int, Person> Repositorys { get; set; }

        public int Id { get; set; }

        public int Count
        {
            get
            {
                return this.Repositorys.Count;
            }
        }

        public void Add(Person person)
        {
            this.Repositorys.Add(this.Id,person);
            this.Id++;
        }
        public Person Get(int index)
        {
                return this.Repositorys[index];
        }

        public bool Update(int index, Person person)
        {
            if (index >= this.Repositorys.Count)
            {
                return false;
            }
            this.Repositorys[index] = person;
            return true;
            
        }
        public bool Delete(int id)
        {
            if (id >= this.Repositorys.Count)
            {
                return false;
            }
            this.Repositorys.Remove(id);
            return true;
        }

       
    }

}
