namespace _01_ListyIterator
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var createLine = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var list = new ListyIterator<string>();
            if (createLine.Length > 1)
            {
                var data = createLine.Skip(1).ToArray();
                list = new ListyIterator<string>(data);
            }
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                switch (command)
                {
                    case "Move":
                        Console.WriteLine(list.Move());
                        break;
                    case "Print":
                        Console.WriteLine(list.Print());
                        break;
                    case "HasNext":
                        Console.WriteLine(list.HasNext());
                        break;
                }
            }
        }
    }
}
