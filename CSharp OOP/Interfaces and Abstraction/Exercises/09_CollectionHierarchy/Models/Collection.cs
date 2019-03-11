namespace _09_CollectionHierarchy.Models
{
    using System.Collections.Generic;


   public class Collection
    {
        public Collection()
        {
            myList = new List<string>();
        }
        protected List<string> myList;
    }
}
