namespace _01_ListyIterator
{
    using System;
    using System.Collections.Generic;


    class ListyIterator<T>
    {
        private List<T> data;
        private int count;

        public ListyIterator()
        {
            this.count = 0;
        }

        public ListyIterator( T[] data)
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

        public string  Print()
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
            if (this.count+1 < this.data.Count)
            {
               
                return true;
            }
            else
            {
                
                return false;
            }
            
        }


    }
}
