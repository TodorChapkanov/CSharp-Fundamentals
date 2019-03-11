namespace _09_CollectionHierarchy.Models
{
    using _09_CollectionHierarchy.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class AddCollection : Collection, IAddable<string>
    {
        public AddCollection() : base()
        {
        }
        public int Add(string argument)
        {
            this.myList.Add(argument);
            return myList.Count - 1 ;
        }
    }

}
