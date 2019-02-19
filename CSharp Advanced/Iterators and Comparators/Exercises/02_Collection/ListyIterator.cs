namespace _02_Collection
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> data;
        private int count;

        public ListyIterator()
        {
            this.count = 0;
        }

        public ListyIterator(T[] data)
        {
            this.data = new List<T>(data);
            this.count = 0;
        }

        public bool Move()
        {

            if (this.count + 1 < this.data.Count)
            {
                this.count++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public string Print()
        {
            try
            {
                return this.data[this.count].ToString();
            }
            catch (Exception)
            {
                return "Invalid Operation!";

            }
        }

        public bool HasNext()
        {
            if (this.count + 1 < this.data.Count)
            {

                return true;
            }
            else
            {

                return false;
            }

        }
        public IEnumerator<T> PrintAll()
        {
            for (int i = 0; i < this.data.Count; i++)
            {
                yield return this.data[i];
            }
        }

        public IEnumerator<T> GetEnumerator() => this.data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
