using System;
using System.Collections.Generic;
using System.Text;

namespace _09_CollectionHierarchy.Contracts
{
    interface IRoster : IRemovable
    {   
        int Used { get; }
    }
}
