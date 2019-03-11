using _09_CollectionHierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _09_CollectionHierarchy.Models
{
   public class AddRemoveCollection : Collection,IRemovable
    {
        public int Add(string argument)
        {
            this.myList.Insert(0, argument);
            return 0;
        }

        public virtual string Remove()
        {
            var indexToRemove = this.myList.Count-1;
            var removedItem = myList[indexToRemove];
            myList.RemoveAt(indexToRemove);
            return removedItem;
        }
    }
}
