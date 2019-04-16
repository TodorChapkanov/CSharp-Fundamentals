using System;
using System.Collections.Generic;
using System.Text;

namespace _03_DependencyInversion.IO
{
   public class ConsoleWriter
    {
        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }
    }
}
