namespace _03_OldestFamilyMember
{
    using System;


    public class StartUp
    {
        public static void Main(string[] args)
        {
            var membersCount = int.Parse(Console.ReadLine());

            var family = new Family();

            for (int i = 0; i < membersCount; i++)
            {
                var curentPerson = Console.ReadLine()
                    .Split();

                var name = curentPerson[0];
                var age =int.Parse(curentPerson[1]);

                var person = new Person(name,age);
                family.AddMember(person);
                
                
            }
            var oldestMemer = family.GetOldestMember();

            Console.WriteLine($"{oldestMemer.Name} {oldestMemer.Age}");
        }
    }
}
