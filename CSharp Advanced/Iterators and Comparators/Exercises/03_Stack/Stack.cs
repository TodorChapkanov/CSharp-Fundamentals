namespace _03_Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Stack<T> : IEnumerable<T>
    {
        private IList<T> data;

        public Stack()
        {
            this.data = new List<T>();
        }
        
        public void Pop()
        {
            try
            {
                var indexToRemove = this.data.Count - 1;
                data.RemoveAt(indexToRemove);
            }
            catch (ArgumentOutOfRangeException)
            {

                throw new ArgumentException("No elements");
            }
        }
        public void Push( T[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                this.data.Add(input[i]);
            }
            
        }
        public IEnumerator<T> GetEnumerator()
        {
            if (this.data.Any())
            {
                for (int i = this.data.Count - 1; i >= 0; i--)
                {
                    yield return this.data[i];
                }
            }
        }
        
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
