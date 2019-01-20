namespace _03_MaximalSum
{
    using System;
    using System.Linq;

    public class MaximalSum
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine().
                Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rowSize = matrixSize[0];
            var colSize = matrixSize[1];
            var matrix = new int[rowSize, colSize];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];

                }
            }
            var maxSum = int.MinValue;
            var firstRow = 0;
            var secondRow = 0;
            var thirdRow = 0;
            var rowIndex = 0;
            var colIndex = 0;
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    firstRow = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2];
                    secondRow = matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2];
                    thirdRow = matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    var curentSum = firstRow + secondRow + thirdRow;

                    if (curentSum > maxSum)
                    {
                        maxSum = curentSum;
                        rowIndex = row;
                        colIndex = col;
                    }

                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            for (int row = rowIndex; row < rowIndex + 3; row++)
            {
                for (int col = colIndex; col < colIndex + 3; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
