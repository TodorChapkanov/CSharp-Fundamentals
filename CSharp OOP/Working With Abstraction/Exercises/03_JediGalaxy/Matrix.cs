namespace _03_JediGalaxy
{
    public  class Matrix
    {
        public static int[,] Create(int row, int col)
        {
            var matrix = new int[row, col];

            var value = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = value++;
                }
            }
            return matrix;
        }
    }
}
