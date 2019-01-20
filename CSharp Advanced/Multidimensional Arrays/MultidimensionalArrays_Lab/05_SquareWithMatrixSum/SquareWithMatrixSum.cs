namespace _05_SquareWithMatrixSum
{
    using System;
    using System.Linq;

    public class SquareWithMatrixSum
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rowSize = matrixSize[0];
            var colSize = matrixSize[1];

            var matrix = new int[rowSize, colSize];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            var sum = 0;
            var curentRow = 0;
            var curentCol = 0;

            for (int row = 0; row < matrix.GetLength(0) -1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1)-1; col++)
                {
                    var curentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];

                    if (curentSum > sum)
                    {
                        sum = curentSum;
                        curentRow = row;
                        curentCol = col;
                    }
                }
            }
            Console.WriteLine($"{matrix[curentRow, curentCol]} {matrix[curentRow, curentCol + 1]}");
            Console.WriteLine($"{matrix[curentRow + 1, curentCol]} {matrix[curentRow + 1, curentCol + 1]}");
            Console.WriteLine(sum);
        }
    }
}
