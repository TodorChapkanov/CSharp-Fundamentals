namespace StorageMaster
{
    using Models.Warehouses;
    using StorageMaster.Core;
    using System;
    using System.Linq;

    public class StartUp
    {
        
        public static void Main()
        {
            var storageMaster = new StorageMaster();

            var commands = Console.ReadLine().Split();
            while (true)
            {
                if (commands[0] == "END")
                {
                    break;
                }

                var command = commands[0];

                var type = commands[1] != null ? commands[1] : string.Empty;
                var name = commands.Length >= 3 ? commands[2] : string.Empty;
                try
                {

                    switch (command)
                    {
                        case "AddProduct":
                            Console.WriteLine(storageMaster.AddProduct(type, double.Parse(name)));
                            break;

                        case "RegisterStorage":
                            Console.WriteLine(storageMaster.RegisterStorage(type, name));
                            break;

                        case "SelectVehicle":
                            Console.WriteLine(storageMaster.SelectVehicle(type, int.Parse(name)));
                            break;

                        case "LoadVehicle":
                            Console.WriteLine(storageMaster.LoadVehicle(commands.Skip(1)));
                            break;

                        case "SendVehicleTo":
                            Console.WriteLine(storageMaster.SendVehicleTo(type, int.Parse(name), commands[3]));
                            break;

                        case "UnloadVehicle":
                            Console.WriteLine(storageMaster.UnloadVehicle(type, int.Parse(name)));
                            break;

                        case "GetStorageStatus":
                            Console.WriteLine(storageMaster.GetStorageStatus(type));
                            break;
                    }
                }
                catch (InvalidOperationException msg)
                {
                    Console.WriteLine($"Error: {msg.Message}");
                }

                commands = Console.ReadLine().Split();
            }

            Console.WriteLine(storageMaster.GetSummary());
        }
    }
}
