using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_ClubParty
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int bunkerCapacity = int.Parse(Console.ReadLine());
            int freeCapacity = bunkerCapacity;
            var halls = new Queue<string>();
            var peopleInHall = new Queue<int>();

            var input = Console.ReadLine().Split().Reverse();

            foreach (var element in input)
            {
                if (char.IsLetter(element[0]))
                {
                    halls.Enqueue(element);
                }

                else
                {
                    int people = int.Parse(element);

                    while (halls.Count > 0)
                    {
                        if (freeCapacity >= people)
                        {
                            peopleInHall.Enqueue(people);
                            freeCapacity -= people;
                            break;
                        }

                        else
                        {
                            Console.WriteLine($"{halls.Dequeue()} -> {string.Join(", ", peopleInHall)}");
                        }

                        peopleInHall.Clear();
                        freeCapacity = bunkerCapacity;
                    }
                }
            }
        }

    }
}
