using SoftUniRestaurant.IO;
using System;

namespace SoftUniRestaurant.Core
{
    public class Engine
    {
        private RestaurantController controller;
        private Writer writer;
        private Reader reader;

        public Engine(RestaurantController controller, Writer writer, Reader reader)
        {
            this.controller = controller;
            this.writer = writer;
            this.reader = reader;
        }

        public void Run()
        {
            while (true)
            {
                var commandArgs = this.reader.ReadLine().Split();
                if (commandArgs[0] == "END")
                {
                    break;
                }
                try
                {
                    

                    var command = commandArgs[0];
                    var type = commandArgs.Length > 1 ? commandArgs[1] : string.Empty;
                    var name = commandArgs.Length > 2 ? commandArgs[2] : string.Empty;
                    var result = string.Empty;
                    switch (command)
                    {
                        case "AddFood":
                            var price = decimal.Parse(commandArgs[3]);
                            result = this.controller.AddFood(type, name, price);
                            this.writer.WriteLine(result);
                            break;

                        case "AddDrink":
                            var servingSize = int.Parse(commandArgs[3]);
                            var brand = commandArgs[4];
                            result = this.controller.AddDrink(type, name, servingSize, brand);
                            this.writer.WriteLine(result);
                            break;

                        case "AddTable":
                            var tableNumber = int.Parse(name);
                            var capacity = int.Parse(commandArgs[3]);
                            result = this.controller.AddTable(type, tableNumber, capacity);
                            this.writer.WriteLine(result);
                            break;

                        case "ReserveTable":
                            var numberOfPeople = int.Parse(type);
                            result = this.controller.ReserveTable(numberOfPeople);
                            this.writer.WriteLine(result);
                            break;

                        case "OrderFood":
                            var number = int.Parse(type);
                            result = this.controller.OrderFood(number, name);
                            this.writer.WriteLine(result);
                            break;

                        case "OrderDrink":
                            var table = int.Parse(type);
                            var drinkName = name;
                            var drinkBrand = commandArgs[3];
                            result = this.controller.OrderDrink(table, drinkName, drinkBrand);
                            this.writer.WriteLine(result);
                            break;

                        case "LeaveTable":
                            var numberOfTable = int.Parse(type);
                            result = this.controller.LeaveTable(numberOfTable);
                            this.writer.WriteLine(result);
                            break;

                        case "GetFreeTablesInfo":
                            result = this.controller.GetFreeTablesInfo();
                            this.writer.WriteLine(result);
                            break;
                        case "GetOccupiedTablesInfo":
                            result = this.controller.GetOccupiedTablesInfo();
                            this.writer.WriteLine(result);
                            break;

                        default:
                            break;
                    }
                }

                catch (ArgumentNullException )
                {

                }

                catch (ArgumentException msg)
                {
                    this.writer.WriteLine(msg.Message);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
            }

            this.writer.WriteLine(this.controller.GetSummary());
        }
    }
}
