namespace GenericScale
{
    using System;


    public class StartUp
    {
        public static void Main()
        {
            var scale = new Scale<int>(10, 10);
           var result =  scale.GetHeavier();

            Console.WriteLine(result);
        }
    }
}
