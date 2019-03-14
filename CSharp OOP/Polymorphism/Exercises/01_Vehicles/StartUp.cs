namespace _01_Vehicles
{
    using _01_Vehicles.Models;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var carArguments = Console.ReadLine().Split();
            var carFuelQuantity = double.Parse(carArguments[1]);
            var carFuelConsumtion = double.Parse(carArguments[2]);
            var carTankCapacity = double.Parse(carArguments[3]);
            Vehicle car = new Car(carFuelQuantity, carFuelConsumtion,carTankCapacity);

            var truckArguments = Console.ReadLine().Split();
            var truckFuelQuantity = double.Parse(truckArguments[1]);
            var truckFuelConsumtrion = double.Parse(truckArguments[2]);
            var truckTankCapacity = double.Parse(truckArguments[3]);
            Vehicle truck = new Truck(truckFuelQuantity, truckFuelConsumtrion, truckTankCapacity);

            var busArguments = Console.ReadLine().Split();
            var busFuelQuantity = double.Parse(busArguments[1]);
            var bussFuelCansumation = double.Parse(busArguments[2]);
            var busTankCapacity = double.Parse(busArguments[3]);
            var bus = new Bus(busFuelQuantity, bussFuelCansumation, busTankCapacity);

            var lineCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < lineCount; i++)
            {
                var commands = Console.ReadLine().Split();
                var command = commands[0];
                var vehicleType = commands[1];
                var kilometersORFuel = double.Parse(commands[2]);

                try
                {
                    switch (command)
                    {
                        case "Drive":
                            switch (vehicleType)
                            {
                                case "Car":
                                    Console.WriteLine(car.Drive(kilometersORFuel));
                                    break;
                                case "Truck":
                                    Console.WriteLine(truck.Drive(kilometersORFuel));
                                    break;
                                case "Bus":
                                    Console.WriteLine(bus.Drive(kilometersORFuel));
                                    break;
                            }

                            break;

                        case "DriveEmpty":
                            Console.WriteLine(bus.DriveEmpty(kilometersORFuel));
                            break;

                        case "Refuel":
                            switch (vehicleType)
                            {
                                case "Car":
                                    car.Refuel(kilometersORFuel);
                                    break;

                                case "Truck":
                                    truck.Refuel(kilometersORFuel);
                                    break;

                                case "Bus":
                                    bus.Refuel(kilometersORFuel);
                                    break;
                            }

                            break;
                    }
                }
                catch (ArgumentException message)
                {
                    Console.WriteLine(message.Message);
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}
