namespace LInkedList
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;

    public class Program
    {
        public static void Main()
        {
            var linkedList = new DoubleLinkedList();
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            linkedList.AddHead(5);

            linkedList.AddHead(20);
            linkedList.AddTail(40);
           
            
             Console.WriteLine((int)linkedList.Tail == 40);
             Console.WriteLine((int)linkedList.Head == 20);
             Console.WriteLine((int)linkedList.RemoveHead() == 20);
            
             Console.WriteLine(linkedList.Count != 0);
            
             try
             {
                 Console.WriteLine(linkedList.Head);
                 Console.WriteLine(false);
             }
             catch (InvalidOperationException ex)
             {
                 Console.WriteLine(true);
                 Console.WriteLine(ex.Message);
              
             }
            linkedList.Clear();
            try
            {
                Console.WriteLine(linkedList.Head);
                Console.WriteLine(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(true);
                Console.WriteLine(ex.Message);

            }
            linkedList.ForEach(c => Console.WriteLine(c));
        }
    }
}
