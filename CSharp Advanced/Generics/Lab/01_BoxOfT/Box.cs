namespace _01_BoxOfT
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

   public class Box<T>
    {
        private List<T> data;

        public Box()
        {
            this.data = new List<T>();
        }

        public int Count => this.data.Count;

        public void Add(T item)
        {
            this.data.Insert(0, item);
        }

        public T Remove()
        {
            T item = this.data[0];
            this.data.RemoveAt(0);
            return item;
        }

        public void ForEach(Action<T> action)
        {

            for (int i = 0; i < this.Count; i++)
            {
                action(this.data[i]);
            }
        }
    }
}