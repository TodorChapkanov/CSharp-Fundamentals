using _09_CollectionHierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _09_CollectionHierarchy.Models
{
   public class MyList :  AddRemoveCollection, IRoster
    {

        public int Used => this.myList.Count;

        public override string Remove()
        {
            var removedItem = this.myList[0];
            this.myList.RemoveAt(0);
            return removedItem;

        }
    }
}
