using System;
using System.Collections.Generic;
using System.Text;

namespace _07_Tuple
{
    public class Tuple<TFirst, TSecond>
    {

        private TFirst first;
        private TSecond second;
       

        public Tuple(TFirst first, TSecond second)
        {
            this.first = first;
            this.second = second;
           
        }

        public override string ToString() => $"{this.first} -> {this.second}";
    }
}
