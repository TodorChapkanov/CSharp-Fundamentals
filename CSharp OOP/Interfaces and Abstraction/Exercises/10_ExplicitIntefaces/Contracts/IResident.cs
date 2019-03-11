using System;
using System.Collections.Generic;
using System.Text;

namespace _10_ExplicitIntefaces.Contracts
{
   public interface IResident
    {
        string Name { get; }

        string Country { get; }

        string GetName();
    }
}
