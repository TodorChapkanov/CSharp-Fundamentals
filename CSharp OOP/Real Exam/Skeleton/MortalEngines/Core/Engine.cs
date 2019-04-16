using MortalEngines.Core.Contracts;
using MortalEngines.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Core
{
    public class Engine : IEngine
    {
        private MachinesManager machinesManager;
        private IReader reader;
        private IWriter writer;
        public Engine(MachinesManager manager, IReader reader , IWriter writer)
        {
            this.machinesManager = manager;
            this.reader = reader;
            this.writer = writer;
        }
        public void Run()
        {
            while (true)
            {
                var args = this.reader.ReadCommands().Split();
                if (args[0] == "Quit")
                {
                    break;
                }
                var command = args[0];
                var result = string.Empty;
                try
                {
                    switch (command)
                    {
                        case "HirePilot":
                            result = this.machinesManager.HirePilot(args[1]);
                            break;

                        case "PilotReport":
                            result = this.machinesManager.PilotReport(args[1]);
                            break;

                        case "ManufactureTank":
                            result = this.machinesManager.ManufactureTank(args[1], double.Parse(args[2]), double.Parse(args[3]));
                            break;

                        case "ManufactureFighter":
                            result = this.machinesManager.ManufactureFighter(args[1], double.Parse(args[2]), double.Parse(args[3]));
                            break;

                        case "MachineReport":
                            result = this.machinesManager.MachineReport(args[1]);
                            break;

                        case "AggressiveMode":
                            result = this.machinesManager.ToggleFighterAggressiveMode(args[1]);
                            break;

                        case "DefenseMode":
                            result = this.machinesManager.ToggleTankDefenseMode(args[1]);
                            break;

                        case "Engage":
                            result = this.machinesManager.EngageMachine(args[1], args[2]);
                            break;

                        case "Attack":
                            result = this.machinesManager.AttackMachines(args[1], args[2]);
                            break;
                    }

                    this.writer.Write(result);
                }

                catch (Exception msg)
                {
                    this.writer.Write($"Error: {msg.Message}");
                }
            }
        }
    }
}
