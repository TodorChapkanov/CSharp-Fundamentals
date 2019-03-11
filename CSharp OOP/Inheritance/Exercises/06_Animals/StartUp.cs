namespace _06_Animals
{
    using _06_Animals.Data;
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var animals = new HashSet<Animal>();
            string line;
            while ((line = Console.ReadLine()) != "Beast!")
            {
                try
                {

                    var arguments = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    var name = arguments[0];
                    var age = int.Parse(arguments[1]);
                    var gender = arguments[2];
                    Animal animal = null;

                    switch (line)
                    {
                        case "Cat":
                            animal = new Cat(name, age, gender);
                            break;

                        case "Dog":
                            animal = new Dog(name, age, gender);
                            break;

                        case "Frog":
                            animal = new Frog(name, age, gender);
                            break;

                        case "Kitten":
                            animal = new Kitten(name, age);
                            break;

                        case "Tomcat":
                            animal = new Tomcat(name, age);
                            break;

                        default:
                            throw new ArgumentException(Animal.InvalidInput);
                    }

                    animals.Add(animal);
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine(Animal.InvalidInput);
                }

                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.GetType().Name);

                Console.WriteLine(animal);
            }
        }
    }

}
