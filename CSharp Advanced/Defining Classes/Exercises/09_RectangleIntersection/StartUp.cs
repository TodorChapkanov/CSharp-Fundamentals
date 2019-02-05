namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            var count = int.Parse(input[0]);
            var intersectionChecks = int.Parse(input[1]);

            var allRectangles = new List<Rectangle>();

            for (int i = 0; i < count; i++)
            {
                var line = Console.ReadLine().Split();

                var id = line[0];
                var width = double.Parse(line[1]);
                var height = double.Parse(line[2]);
                var topLeftX = double.Parse(line[3]);
                var topLeftY = double.Parse(line[4]);

                var rectangle = new Rectangle(id, width, height, topLeftX, topLeftY);

                allRectangles.Add(rectangle);
            }

            for (int i = 0; i < intersectionChecks; i++)
            {
                var line = Console.ReadLine().Split();

                var firstRectangle = allRectangles.FirstOrDefault(r => r.Id == line[0]);
                var secondRectangle = allRectangles.FirstOrDefault(r => r.Id == line[1]);

                var isIntersect = firstRectangle.IsIntersect(secondRectangle).ToString().ToLower();
                Console.WriteLine(isIntersect);
            }
        }
    }
}
