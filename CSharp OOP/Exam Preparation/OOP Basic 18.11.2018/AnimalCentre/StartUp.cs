namespace AnimalCentre
{
    using AnimalCentre.Core;
    using AnimalCentre.IO;
    using AnimalCentre.Models.Factories;
    using AnimalCentre.Models.Hotels;
    using System;


    public class StartUp
    {
        public static void Main(string[] args)
        {
            var animalHotel = new Hotel();
            var factory = new AnimalFactory();
            var center = new AnimalCentre(animalHotel,factory);
            var reader = new Reader();
            var writer = new Writer();
            var engine = new Engine(center,reader, writer);
            engine.Run();

            
        }
    }
}
