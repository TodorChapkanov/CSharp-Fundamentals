namespace _07_PascalTriangle
{
    using System;

    public class PascalTriangle
    {
        public static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());

            var array = new long[input][];

            array[0] = new long[1];
            array[0][0] = 1;
            if (input > 1)
            {
                array[1] = new long[2];
                array[1][0] = 1;
                array[1][1] = 1;
            }
            

            for (int row = 2; row < array.Length; row++)
            {
                array[row] = new long[row+1];
                for (int col = 0; col < array[row].Length; col++)
                {
                    if (col == 0 || col == array[row].Length-1)
                    {
                        array[row][col] = 1;
                        continue;
                    }

                     var sum = array[row - 1][col] + array[row - 1][col - 1];
                    array[row][col] = sum;
                }
            }
            for (int row = 0; row < array.Length; row++)
            {
                Console.WriteLine(string.Join(' ', array[row]));
            }
        }
    }
}
