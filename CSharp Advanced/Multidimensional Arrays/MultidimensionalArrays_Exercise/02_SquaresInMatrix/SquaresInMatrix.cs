namespace _02_SquaresInMatrix
{
    using System;
    using System.Linq;

    public class SquaresInMatrix
    {
        public static void Main()
        {
            var sizes = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
            var firsDimension = sizes[0];
            var secondDimention = sizes[1];
            var matrix = new char[firsDimension, secondDimention];



            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                var charsInRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = charsInRow[c];
                }
            }
            var squaresCount = 0;
            for (int f = 0; f < matrix.GetLength(0) - 1; f++)
            {
                for (int s = 0; s < matrix.GetLength(1) - 1; s++)
                {
                    if (matrix[f, s] == matrix[f, s + 1] && matrix[f + 1, s] == matrix[f, s] && matrix[f + 1, s] == matrix[f + 1, s + 1])
                    {
                        squaresCount++;
                    }
                }
            }
            Console.WriteLine(squaresCount);
        }
    }
}
