using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var allPersons = new List<Person>();

        string line;
        while ((line = Console.ReadLine()) != "End")
        {
            var splitedLine = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var personName = splitedLine[0];
            var position = splitedLine[1];
            var parameters = splitedLine.Skip(2).ToArray();

            Person person;
            if (!allPersons.Any(n => n.Name == personName))
            {
                 person = new Person(personName);
                allPersons.Add(person);
            }
            else
            {
                 person = allPersons.First(n => n.Name == personName);
            }
            
           
            switch (position)
            {
                
                case "company":
                    var name = parameters[0];
                    var department = parameters[1];
                    var salary = double.Parse(parameters[2]);
                    var company = new Company(name, department, salary);
                    person.Company = company;
                    break;

                case "pokemon":
                    var pokemonName = parameters[0];
                    var type = parameters[1];
                    var pokemon = new Pokemon(pokemonName, type);
                    person.Pokemons.Add(pokemon);
                    break;

                case "parents":
                    var parentsName = parameters[0];
                    var birthday = parameters[1];
                    var parents = new People(parentsName, birthday);
                    person.Parents.Add(parents);
                    break;

                case "children":
                    var childName = parameters[0];
                    var childBirthday = parameters[1];
                    var child = new People(childName, childBirthday);
                    person.Childrens.Add(child);
                    break;

                case "car":
                    var model = parameters[0];
                    var speed = int.Parse(parameters[1]);
                    var car = new Car(model, speed);
                    person.Car = car;
                    break;
                    
            }

            
        }
        var personToPrint = Console.ReadLine();

        var curentPerson = allPersons.First(n => n.Name == personToPrint);

        Console.Write(curentPerson);
    }
}




