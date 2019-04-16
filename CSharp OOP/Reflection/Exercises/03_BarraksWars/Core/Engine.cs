﻿namespace _03_BarracksFactory.Core
{
    using System;
    using Contracts;

    public class Engine : IRunnable
    {

        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;

        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    var command = this.commandInterpreter.InterpretCommand(data, commandName);
                    string result = command.Execute();


                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}