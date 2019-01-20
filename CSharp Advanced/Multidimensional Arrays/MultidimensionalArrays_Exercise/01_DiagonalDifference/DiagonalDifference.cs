namespace _01_DiagonalDifference
{
    using System;
    using System.Linq;

    public class DiagonalDifference
    {
        public static void Main()
        {
            var matrixSize = int.Parse(Console.ReadLine());
            var matrix = new int[matrixSize, matrixSize];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];

                }
            }
            var primaryDiagonalumSum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                primaryDiagonalumSum += matrix[row, row];
            }
            var secondaryDiagonalSum = 0;
            var curentRow = 0;
            for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
            {

                secondaryDiagonalSum += matrix[curentRow, i];
                curentRow++;
            }
            var curentDifference = Math.Abs(primaryDiagonalumSum - secondaryDiagonalSum);
            Console.WriteLine(curentDifference);
        }
    }
}
