﻿namespace Animals
{
    using System;
    using Models;

    public class StartUp
    {
        public static void Main()
        {
            Animal cat = new Cat("Pesho", "Whiskas");
            Animal dog = new Dog("Gosho", "Meat");

            Console.WriteLine(cat.ExplainSelf());
            Console.WriteLine(dog.ExplainSelf());

        }
    }
}
