namespace _06_BombTheBasement
{
    using System;
    using System.Linq;

    public class BombTheBasement
    {
        public static void Main()
        {
            var matrxSize = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();


            var matrix = new int[matrxSize[0], matrxSize[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = 0;
                }
            }

            var bombCell = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var curentRow = bombCell[0];
            var curentCol = bombCell[1];
            var bombPower = bombCell[2];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    var isInside = Math.Pow((row - curentRow), 2) + Math.Pow((col - curentCol), 2) <= Math.Pow(bombPower, 2);

                    if (isInside)
                    {
                        matrix[row, col] = 1;
                    }
                }
            }

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                var couter = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    if (matrix[row, col] == 0)
                    {
                        couter++;
                    }
                }
                for (int r = 0; r < matrix.GetLength(0); r++)
                {
                    if (r > couter - 1)
                    {
                        matrix[r, col] = 1;
                    }
                    else
                    {
                        matrix[r, col] = 0;
                    }
                }

            }
            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)

            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);

                }
                Console.WriteLine();
            }
        }
    }
}
