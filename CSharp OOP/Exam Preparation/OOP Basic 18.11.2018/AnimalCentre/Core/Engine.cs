using AnimalCentre.IO;
using System;
using System.Text;

namespace AnimalCentre.Core
{
    public  class Engine
    {
        private AnimalCentre centre;
        private Reader reader;
        private Writer writer;

        public Engine(AnimalCentre centre, Reader reader, Writer writer)
        {
            this.centre = centre;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            var commands = this.reader.ReadLine().Split();
            while (true)
            {
               
                if (commands[0] == "End")
                {
                    break;
                }
                


                var command = commands[0];
                var animalName = commands[1];

                try
                {
                    switch (command)
                    {
                        case "RegisterAnimal":
                            var animalType = commands[1];
                            var name = commands[2];
                            var animalEnergy = int.Parse(commands[4]);
                            var animalHappiness = int.Parse(commands[3]);
                            var procedureTime = int.Parse(commands[5]);
                            writer.WriteLine(this.centre.RegisterAnimal(animalType, name, animalEnergy, animalHappiness, procedureTime));
                            break;

                        case "Chip":
                            var chipProcedurTime = int.Parse(commands[2]);
                            writer.WriteLine(this.centre.Chip(animalName, chipProcedurTime));
                            break;
                        case "DentalCare":
                            var dentalCareTimeProcedure = int.Parse(commands[2]);
                            writer.WriteLine(this.centre.DentalCare(animalName, dentalCareTimeProcedure));
                            break;
                        case "Fitness":
                            var fitnessProcedureTime = int.Parse(commands[2]);
                            writer.WriteLine(this.centre.Fitness(animalName, fitnessProcedureTime));
                            break;
                        case "NailTrim":
                            var nailTrimeProcedureTime = int.Parse(commands[2]);
                            writer.WriteLine(this.centre.NailTrim(animalName, nailTrimeProcedureTime));
                            break;
                        case "Play":
                            var playProcedureTime = int.Parse(commands[2]);
                            writer.WriteLine(this.centre.Play(animalName, playProcedureTime));
                            break;
                        case "Vaccinate":
                            var vaccinateProcedureTime = int.Parse(commands[2]);
                            writer.WriteLine(this.centre.Vaccinate(animalName, vaccinateProcedureTime));
                            break;
                        case "Adopt":
                            var ownerName = commands[2];
                            writer.WriteLine(this.centre.Adopt(animalName, ownerName));
                            break;
                        case "History":
                            writer.Write(this.centre.History(animalName));
                            break;
                        default:
                            break;
                    }

                   
                }
                catch (InvalidOperationException msg)
                {
                    writer.WriteLine("InvalidOperationException: " + msg.Message);
                }

                catch (ArgumentException msg)
                {
                    writer.WriteLine("ArgumentException: " + msg.Message);
                }

                commands = this.reader.ReadLine().Split();
            }

            this.writer.Write(this.centre.AdoptedAnimals());
        }
        
    }
}
