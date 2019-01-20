namespace _05_SnakeMoves
{
    using System;
    using System.Linq;

    public class SnakeMoves
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rowSize = matrixSize[0];
            var colSize = matrixSize[1];

            var text = Console.ReadLine();
            var counter = 1;
            var charToAdd = 0;

            var matrix = new char[rowSize, colSize];

            while (true)
            {


                for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        matrix[row, col] = text[charToAdd];

                        charToAdd = counter % text.Length;
                        counter++;

                    }
                }
                break;

            }
            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
