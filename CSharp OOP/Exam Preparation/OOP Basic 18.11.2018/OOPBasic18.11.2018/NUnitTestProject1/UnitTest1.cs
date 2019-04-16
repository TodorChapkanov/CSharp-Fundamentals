using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using AnimalCentre;

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace

[TestFixture]
public class Business_Logic_005_Chip_Animal
{
    // MUST exist within project, otherwise a Compile Time Error will be thrown.
    private static readonly Assembly ProjectAssembly = typeof(StartUp).Assembly;

    [Test]
    public void ChipAnimal()
    {
        var animalParam = new object[]
        {
            "Molly", 15, 20, 10
        };

        var animal = Activator.CreateInstance(GetType("Pig"), animalParam);
        var chip = Activator.CreateInstance(GetType("Chip"));
        var chipObject = new object[]
        {
            animal, 5
        };
        chip.GetType().GetMethod("DoService").Invoke(chip, chipObject);
        var isChipped = animal.GetType().GetProperty("IsChipped").GetValue(animal);
        Assert.That(() => isChipped, Is.True,
            "Property IsChipped is not set to true");
        Assert.That(GetType("Animal")
            .GetProperty("Happiness", (BindingFlags)62)
            .GetValue(animal), Is.EqualTo(15),
            "Happiness is not getting lower");
    }


    private static Type GetType(string name)
    {
        var type = ProjectAssembly
            .GetTypes()
            .FirstOrDefault(t => t.Name == name);

        return type;
    }
}