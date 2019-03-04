using System;
using System.Linq;

namespace _03_JediGalaxy
{
    public class Program
    {
        public static void Main()
        {
            var dimestions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var row = dimestions[0];
            var col = dimestions[1];

            var matrix = Matrix.Create(row, col);

            var sum = 0L;

            var command = string.Empty;
            while ((command= Console.ReadLine()) != "Let the Force be with you")
            {
                var heroCoordinates = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var enemyCoordinates = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                var enemyRow = enemyCoordinates[0];
                var enemyCol = enemyCoordinates[1];
                var enemy = new Enemy(enemyRow, enemyCol);

                enemy.Move(matrix);
                
                var heroRow = heroCoordinates[0];
                var heroCol = heroCoordinates[1];

                 var hero = new Hero(heroRow, heroCol);
                
                 sum += hero.Move(matrix);
                
            }

            Console.WriteLine(sum);
        }
    }
}
