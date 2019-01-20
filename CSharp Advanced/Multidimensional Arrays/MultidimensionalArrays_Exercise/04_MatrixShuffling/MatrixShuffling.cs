namespace _04_MatrixShuffling
{
    using System;
    using System.Linq;

    public class MatrixShuffling
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var matrix = new string[matrixSize[0], matrixSize[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine()
                    .Split();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];

                }
            }
            while (true)
            {
                var line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (line[0] == "END")
                {
                    return;
                }
                if (line.Length > 5 || line.Length < 0 || line[0] != "swap")
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                var firstRow = int.Parse(line[1]);
                var firstCol = int.Parse(line[2]);
                var secondRow = int.Parse(line[3]);
                var secondCol = int.Parse(line[4]);

                if (firstRow < 0 || firstRow > matrix.GetLength(0) ||
                    firstCol < 0 || firstCol > matrix.GetLength(1) ||
                    secondRow < 0 || secondRow > matrix.GetLength(0) ||
                    secondCol < 0 || secondCol > matrix.GetLength(1))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                var curentCell = matrix[firstRow, firstCol];
                matrix[firstRow, firstCol] = matrix[secondRow, secondCol];
                matrix[secondRow, secondCol] = curentCell;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        Console.Write($"{matrix[row, col]} ");
                    }
                    Console.WriteLine();
                }

            }
        }
    }
}
