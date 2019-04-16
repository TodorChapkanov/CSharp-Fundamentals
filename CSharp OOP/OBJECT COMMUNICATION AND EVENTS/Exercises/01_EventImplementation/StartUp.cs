using System;

namespace _01_EventImplementation
{
    public class StartUp
    {
        public static void Main()
        {
            var dispatcher = new Dispatcher();
            var handler = new Handler();
            dispatcher.NameChange += handler.OnDispatcherNameChange;

            var input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                dispatcher.Name = input;
            }
        }
    }
}
