namespace _03_WildFarm
{
    using System;
    using Models.Animals;
    using System.Collections.Generic;
    using _03_WildFarm.Factories;

    public class StartUp
    {
        public static void Main()
        {
            var animals = new List<Animal>();
            var line = string.Empty;
            Animal animal = null;
            var counter = -1;
            while ((line = Console.ReadLine()) != "End")
            {
                counter++;

                try
                {
                    var tokens = line.Split();
                    var type = tokens[0];
                    if (counter % 2 == 0)
                    {
                        
                        var animalName = tokens[1];
                        var animalWeight = double.Parse(tokens[2]);
                        var argument = tokens[3];
                        switch (type)
                        {
                            case "Hen":

                                animal = new Hen(animalName, animalWeight, double.Parse(argument));
                                break;

                            case "Owl":
                                animal = new Owl(animalName, animalWeight, double.Parse(argument));
                                break;

                            case "Mouse":
                                animal = new Mouse(animalName, animalWeight, argument);
                                break;

                            case "Dog":
                                animal = new Dog(animalName,animalWeight, argument);
                                break;

                            case "Cat":

                                animal = new Cat(animalName, animalWeight, argument, tokens[4]);
                                break;

                            case "Tiger":
                                animal = new Tiger(animalName, animalWeight, argument, tokens[4]);
                                break;

                        }
                        Console.WriteLine(animal.AskForFood());
                        animals.Add(animal);
                    }

                    else
                    {
                        var foodType = tokens[0];
                        var quantity = int.Parse(tokens[1]);
                        var food = FoodFactory.CreateFood(foodType, quantity);
                        animal.Eat(food);

                    }
                }
                catch (Exception message)
                {

                    Console.WriteLine(message.Message);
                }  
            }

            foreach (var item in animals)
            {
                Console.WriteLine(item);
            }
        }
    }
}
