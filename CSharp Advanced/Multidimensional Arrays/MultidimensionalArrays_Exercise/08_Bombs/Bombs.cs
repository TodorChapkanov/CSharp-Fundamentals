namespace _08_Bombs
{
    using System;
    using System.Linq;
    using System.Collections.Generic;


    public class Bombs
    {
       public static void Main()
        {
            var matrixSize = int.Parse(Console.ReadLine());

            var matrix = new int[matrixSize, matrixSize];

            for (int row = 0; row < matrixSize; row++)
            {
                var line = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = line[col];
                }
            }
            var bombsCoordinates = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var curentCoordinate = new Queue<string>(bombsCoordinates);

            while (curentCoordinate.Any())

            {
                var splitedCoordinats = curentCoordinate.Dequeue()
                    .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                var bombRow = splitedCoordinats[0];
                var bombCol = splitedCoordinats[1];

                if (matrix[bombRow, bombCol] > 0)
                {

                    IsImpactCellsIsDead(bombRow, bombCol, matrix);
                    matrix[bombRow, bombCol] = 0;
                }
            }
            var aliveCellsCount = 0;
            var aliveCellsSum = 0;
            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCellsCount++;
                        aliveCellsSum += matrix[row, col];
                    }
                }

            }
            Console.WriteLine($"Alive cells: {aliveCellsCount}");
            Console.WriteLine($"Sum: {aliveCellsSum}");
            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }

        }

        private static void IsImpactCellsIsDead(int bombRow, int bombCol, int[,] matrix)
        {
            var bombPower = matrix[bombRow, bombCol];
            for (int row = bombRow - 1; row <= bombRow + 1; row++)
            {
                for (int col = bombCol - 1; col <= bombCol + 1; col++)
                {
                    if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
                    {
                        if (row == bombRow && col == bombCol)
                        {
                            continue;
                        }
                        if (matrix[row, col] > 0)
                        {
                            ReduceCells(row, col, matrix, bombPower);
                        }
                    }

                }
            }
        }

        private static void ReduceCells(int row, int col, int[,] matrix, int bombPower)
        {
            matrix[row, col] -= bombPower;
        }
    }
}
