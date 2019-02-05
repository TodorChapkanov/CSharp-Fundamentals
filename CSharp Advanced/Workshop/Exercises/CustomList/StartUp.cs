namespace CustomList
{
    using System;


    public class StartUp
    {
        public static void Main()
        {
            var customList = new CustomList();

            customList.Add(10);

            customList.Add(15);

            customList.Add(20);

            // Testing Add Method - adding the given number on the end of the CustomList
            Console.WriteLine(customList[0] == 10);
            Console.WriteLine(customList[1] == 15);
            Console.WriteLine(customList[2] == 20);
            customList.Add(30);
            customList.Add(40);

            customList.RemoveAt(3);

            // Testing the RemoveAt Method - remove value on the given index 
            Console.WriteLine(customList[3] == 40);

            customList.Swap(2, 3);
            // Testing the Swap Method;
            Console.WriteLine(customList[2] == 40);
            Console.WriteLine(customList[3] == 20);

            // Test Count Method - elemnes in CustomList { 10, 15, 40, 20}
            Console.WriteLine(customList.Count() == 4);

            // Test on Contains Method
            Console.WriteLine(customList.Contains(50));

        }
    }
}
