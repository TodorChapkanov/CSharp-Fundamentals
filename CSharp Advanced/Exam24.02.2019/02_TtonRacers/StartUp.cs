namespace _02_TtonRacers
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var sizeMatrix = int.Parse(Console.ReadLine());

            var matrix = new char[sizeMatrix][];
            var firstPLayerRow = 0;
            var firstPLayerCol = 0;
            var secondPlayerRow = 0;
            var secondPLayerCol = 0;


            for (int i = 0; i < sizeMatrix; i++)
            {
                var line = Console.ReadLine().ToCharArray();
                matrix[i] = line;
                if (line.Contains('f'))
                {
                    firstPLayerRow = i;
                    firstPLayerCol = Array.IndexOf(line, 'f');

                }
                if (line.Contains('s'))
                {
                    secondPlayerRow = i;
                    secondPLayerCol = Array.IndexOf(line, 's');
                }

            }
            while (true)
            {
                var commands = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var firstCommand = commands[0];
                var secondCommand = commands[1];

                switch (firstCommand)
                {

                    case "up":

                        --firstPLayerRow;
                        break;
                    case "down":
                        ++firstPLayerRow;
                        break;
                    case "left":
                        --firstPLayerCol;
                        break;
                    case "right":
                        ++firstPLayerCol;
                        break;
                }
                if (IsOnEnd(matrix, firstPLayerRow, firstPLayerCol)) ;
                {
                    if (firstPLayerRow < 0)
                    {
                        firstPLayerRow = matrix.Length - 1;
                    }
                    else if (firstPLayerRow > matrix.Length - 1)
                    {
                        firstPLayerRow = 0;
                    }
                    if (firstPLayerCol < 0)
                    {
                        firstPLayerCol = matrix[0].Length - 1;
                    }
                    else if (firstPLayerCol > matrix[0].Length - 1)
                    {
                        firstPLayerCol = 0;
                    }
                    if (IsDead(matrix, firstPLayerRow, firstPLayerCol))
                    {
                        matrix[firstPLayerRow][firstPLayerCol] = 'x';
                        break;
                    }
                    MoveFirsPlayer(matrix, firstPLayerRow, firstPLayerCol);
                }
                switch (secondCommand)
                {
                    case "up":
                        --secondPlayerRow;
                        break;
                    case "down":
                        ++secondPlayerRow;
                        break;
                    case "left":
                        --secondPLayerCol;
                        break;
                    case "right":
                        ++secondPLayerCol;
                        break;

                }
                if (IsOnEnd(matrix, secondPlayerRow, secondPLayerCol))
                {
                    if (secondPlayerRow < 0)
                    {
                        secondPlayerRow = matrix.Length - 1;
                    }
                    else if (secondPlayerRow > matrix.Length - 1)
                    {
                        secondPlayerRow = 0;
                    }
                    if (secondPLayerCol < 0)
                    {
                        secondPLayerCol = matrix[0].Length - 1;
                    }
                    else if (secondPLayerCol > matrix[0].Length - 1)
                    {
                        secondPLayerCol = 0;
                    }
                    
                   

                }
                if (IsDead(matrix, secondPlayerRow, secondPLayerCol))
                {
                    matrix[secondPlayerRow][secondPLayerCol] = 'x';
                    break;
                }
                MoveSecondPLayer(matrix, secondPlayerRow, secondPLayerCol);

            }
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();
            }
            
        }
        static bool IsDead(char[][] matrix, int firstPLayerRow, int firstPLayerCol)
        {
            if (matrix[firstPLayerRow][firstPLayerCol] != '*')
            {
                return true;
            }
            return false;
        }

        public static void MoveFirsPlayer(char[][] matrix, int row, int col)
        {
            matrix[row][col] = 'f';
            
        }

        private static bool IsOnEnd(char[][] matrix, int row, int col)
        {
            if (row < 0 || row > matrix.Length - 1 || col < 0 || col > matrix[0].Length - 1)
            {
                return true;
            }
            return false;
        }

       public static void MoveSecondPLayer(char[][] matrix, int row, int col)
        {
            matrix[row][col] = 's';
        }
    }
}
