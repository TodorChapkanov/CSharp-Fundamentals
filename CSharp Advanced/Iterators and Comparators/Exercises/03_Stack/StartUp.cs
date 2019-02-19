namespace _03_Stack
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var customStack = new Stack<string>();
            string line;
            while ((line = Console.ReadLine()) != "END")
            {
                var splitedLine = line.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                if (splitedLine.Contains("Push"))
                {
                    splitedLine.RemoveAt(0);
                    var dataToPush = splitedLine.ToArray();
                    customStack.Push(dataToPush);
                }
                else
                {
                    try
                    {
                        customStack.Pop();
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                
                if (customStack.Any())
                {
                    foreach (var item in customStack)
                    {
                        Console.WriteLine(item);
                    }

                    Console.WriteLine(string.Join(Environment.NewLine, customStack));
                }
            }
        }
    }
}