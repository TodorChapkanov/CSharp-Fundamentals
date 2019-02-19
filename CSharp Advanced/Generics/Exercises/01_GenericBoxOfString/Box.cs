using System.Collections.Generic;
using System.Text;

namespace _01_GenericBoxOfString
{
    public class Box<T>
    {
        private T data;



        public Box(T data)
        {
            this.data = data;

        }

        public override string ToString()
        {
            return $"{typeof(T)}: {this.data}";
        }
    }
}
