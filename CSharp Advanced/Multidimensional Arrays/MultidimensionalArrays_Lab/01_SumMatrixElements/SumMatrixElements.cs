namespace _01_SumMatrixElements
{
    using System;
    using System.Linq;

    public class SumMatrixElements
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine().
                Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var row = matrixSize[0];
            var col = matrixSize[1];
            var sum = 0;

            var matrix = new int[row][];

            for (int i = 0; i < row; i++)
            {
                var line = Console.ReadLine().
                Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                sum += line.Sum();

                matrix[i] = line;
            }
            Console.WriteLine(row);
            Console.WriteLine(col);
            Console.WriteLine(sum);
        }
    }
}
