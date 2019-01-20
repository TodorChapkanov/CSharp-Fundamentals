namespace _07_KnightGame
{
    using System;


    public class KnightGame
    {
        public static void Main()
        {
            var matrixSize = int.Parse(Console.ReadLine());

            var matrix = new char[matrixSize, matrixSize];

            var count = 0;

            for (int row = 0; row < matrixSize; row++)
            {
                var line = Console.ReadLine().ToLower();
                for (int col = 0; col < matrixSize; col++)
                {

                    matrix[row, col] = line[col];
                }
            }
            var dangerousCnight = 0;
            var curentCnight = 0;
            var curentRowIndex = 0;
            var CurentColIndex = 0;
            while (true)
            {
                for (int row = 0; row < matrixSize; row++)
                {
                    for (int col = 0; col < matrixSize; col++)
                    {
                        if (matrix[row, col] == 'k')
                        {

                            count += IsMoveInMatrix(row + 2, col - 1, matrix);
                            count += IsMoveInMatrix(row + 2, col + 1, matrix);
                            count += IsMoveInMatrix(row + 1, col - 2, matrix);
                            count += IsMoveInMatrix(row + 1, col + 2, matrix);
                            count += IsMoveInMatrix(row - 2, col - 1, matrix);
                            count += IsMoveInMatrix(row - 2, col + 1, matrix);
                            count += IsMoveInMatrix(row - 1, col - 2, matrix);
                            count += IsMoveInMatrix(row - 1, col + 2, matrix);


                        }
                        if (count > dangerousCnight)
                        {
                            dangerousCnight = count;
                            curentRowIndex = row;
                            CurentColIndex = col;
                        }
                        count = 0;
                    }


                }

                if (dangerousCnight > 0)
                {
                    matrix[curentRowIndex, CurentColIndex] = 'o';
                    curentCnight++;
                    dangerousCnight = 0;
                }
                else
                {
                    Console.WriteLine(curentCnight);
                    return;
                }

            }
        }



        private static int IsMoveInMatrix(int row, int col, char[,] matrix)
        {

            var count = 0;
            if (row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(0))
            {
                count = RemoveKnight(row, col, matrix);
                return count;
            }
            return count;
        }



        private static int RemoveKnight(int curentRow, int curentCol, char[,] matrix)
        {
            var count = 0;
            if (matrix[curentRow, curentCol] == 'k')
            {

                count = 1;
            }
            return count;
        }
    }
}
