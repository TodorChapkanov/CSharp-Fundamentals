﻿using MortalEngines.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.IO
{
    public class Reader : IReader
    {
        public string ReadCommands()
        {
            return Console.ReadLine();
        }

        
    }
}
