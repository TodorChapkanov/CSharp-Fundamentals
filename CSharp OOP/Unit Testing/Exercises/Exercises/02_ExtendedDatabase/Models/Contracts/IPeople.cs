using System;
using System.Collections.Generic;
using System.Text;

namespace _02_ExtendedDatabase.Models.Contracts
{
    public interface IPerson
    {
        string Name { get; }

        long Id { get; }
    }
}
