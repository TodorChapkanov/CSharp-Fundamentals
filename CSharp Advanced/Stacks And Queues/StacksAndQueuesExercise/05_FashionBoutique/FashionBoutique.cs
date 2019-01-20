namespace _05_FashionBoutique
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FashionBoutique
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var clothes = new Stack<int>(input);
            var capacity = int.Parse(Console.ReadLine());
            var clothesInRack = 0;
            var rack = 1;

            for (int i = 0; i < input.Length; i++)
            {
                var curentClothes = clothes.Pop();
                clothesInRack += curentClothes;

                if (clothesInRack > capacity )
                {
                    rack++;
                    clothesInRack = curentClothes;
                }
                else if (clothesInRack == capacity && clothes.Count > 0)
                {
                    rack++;
                    clothesInRack = 0;
                }

            }
            Console.WriteLine(rack);
        }
    }
}
