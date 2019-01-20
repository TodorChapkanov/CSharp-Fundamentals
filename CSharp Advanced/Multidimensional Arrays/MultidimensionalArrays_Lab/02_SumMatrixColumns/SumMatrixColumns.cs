namespace _02_SumMatrixColumns
{
    using System;
    using System.Linq;

    public class SumMatrixColumns
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine().
                Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rowSize = matrixSize[0];
            var colSize = matrixSize[1];
            

            var matrix = new int[rowSize][];

            for (int i = 0; i < rowSize; i++)
            {
                var line = Console.ReadLine().
                Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
                
                matrix[i] = line;
            }
            
            for (int col = 0; col < colSize; col++)
            {
                var sum = 0;
                for (int row = 0; row < rowSize; row++)
                {
                    sum += matrix[row][col];
                }
                Console.WriteLine(sum);

            }
        }
    }
}
