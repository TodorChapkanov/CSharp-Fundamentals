namespace _08_Ranking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Ranking
    {
        public static void Main()
        {
            var contests = new Dictionary<string, string>();

            while (true)
            {
                var input = Console.ReadLine().Split(":");
                if (input[0] == "end of contests")
                {
                    break;
                }

                if (!contests.ContainsKey(input[0]))
                {
                    contests.Add(input[0], input[1]);
                }
            }

            var users = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                var curentContest = Console.ReadLine().Split(new string[] { "=>", " => ", "=>", " =>" }, StringSplitOptions.RemoveEmptyEntries);

                if (curentContest[0] == "end of submissions")
                {
                    break;
                }
                var contest = curentContest[0];
                var password = curentContest[1];
                var curentUser = curentContest[2];
                var score = int.Parse(curentContest[3]);

                if (contests.ContainsKey(contest) && contests[contest] == password)
                {

                    if (!users.ContainsKey(curentContest[2]))
                    {
                        users.Add(curentUser, new Dictionary<string, int>());
                        users[curentUser].Add(contest, score);
                    }
                    else if (users.ContainsKey(curentUser) && !users[curentUser].ContainsKey(contest))
                    {
                        users[curentUser].Add(contest, score);
                    }
                    else if (users.ContainsKey(curentUser) && users[curentUser].ContainsKey(contest))
                    {
                        if (users[curentUser][contest] <= score)
                        {
                            users[curentUser][contest] = score;
                        }
                    }

                }
            }
            var sum = 0;
            var user = "";

            foreach (var item in users)
            {
                int curentSum = 0;

                foreach (var score in item.Value)
                {
                    curentSum += score.Value;
                }
                if (curentSum > sum)
                {
                    sum = curentSum;
                    user = item.Key;
                }

            }
            Console.WriteLine($"Best candidate is {user} with total {sum} points.");
            Console.WriteLine("Ranking: ");
            foreach (var item in users.OrderBy(x => x.Key))
            {
                Console.WriteLine(item.Key);
                foreach (var score in item.Value.OrderByDescending(x => x.Value))
                {
                    Console.Write("#  " + score.Key + " -> " + score.Value);
                    Console.WriteLine();
                }
            }

        }
    }
}
