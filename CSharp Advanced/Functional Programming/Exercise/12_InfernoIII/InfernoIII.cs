namespace _12_InfernoIII
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class InfernoIII
    {
        public static void Main()
        {
            var gems = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();



            var allComands = new List<string>();
            string line;
            while ((line = Console.ReadLine()) != "Forge")
            {
                var splitedInput = line.Split(';', StringSplitOptions.RemoveEmptyEntries);

                var command = splitedInput[0];
                var condition = splitedInput[1];
                var parameter = int.Parse(splitedInput[2]);

                var curentCommand = $"{condition}:{parameter}";

                if (command == "Exclude")
                {
                    allComands.Add(curentCommand);
                }

                else if (command == "Reverse")
                {
                    var commandRemove = allComands.LastIndexOf(curentCommand);
                    if (commandRemove != -1)
                    {
                        allComands.Remove(curentCommand);
                    }

                }

            }
            var gemsToRemove = new List<int>();


            foreach (var command in allComands)
            {
                var subCommand = command.Split(':')[0];
                var condition = int.Parse(command.Split(':')[1]);

                if (subCommand == "Sum Left")
                {
                    gemsToRemove.AddRange(GetIndexByLeftSum(gems, condition));
                }
                else if (subCommand == "Sum Right")
                {
                    gemsToRemove.AddRange(GetIndexByRightSum(gems, condition));
                }
                else if (subCommand == "Sum Left Right")
                {
                    gemsToRemove.AddRange(GetIndexByLeftAndRightSum(gems, condition));
                }
            }
            gemsToRemove = gemsToRemove.Distinct().ToList();

            var gemsLeft = new List<int>();

            for (int i = 0; i < gems.Count; i++)
            {
                if (!gemsToRemove.Contains(i))
                {
                    gemsLeft.Add(gems[i]);
                }
            }
            Console.WriteLine(string.Join(' ', gemsLeft));

        }

        public static List<int> GetIndexByLeftSum(List<int> gems, int parameter)
        {
            var leftSumElemnts = new List<int>();
            for (int i = 0; i < gems.Count; i++)
            {
                var leftIndex = i == 0 ? 0 : gems[i - 1];
                var sum = gems[i] + leftIndex;

                if (sum == parameter)
                {
                    leftSumElemnts.Add(i);
                }
            }
            return leftSumElemnts;
        }
        public static List<int> GetIndexByRightSum(List<int> gems, int parameter)
        {
            var rightSumElemnts = new List<int>();
            for (int i = 0; i < gems.Count; i++)
            {
                var rightIndex = i == gems.Count - 1 ? 0 : gems[i + 1];
                var sum = gems[i] + rightIndex;

                if (sum == parameter)
                {
                    rightSumElemnts.Add(i);
                }
            }
            return rightSumElemnts;
        }
        public static List<int> GetIndexByLeftAndRightSum(List<int> gems, int parameter)
        {
            var rightSumElemnts = new List<int>();
            for (int i = 0; i < gems.Count; i++)
            {
                var leftIndex = i == 0 ? 0 : gems[i - 1];
                var rightIndex = i == gems.Count - 1 ? 0 : gems[i + 1];
                var sum = leftIndex + gems[i] + rightIndex;

                if (sum == parameter)
                {
                    rightSumElemnts.Add(i);
                }
            }
            return rightSumElemnts;
        }
    }
}
