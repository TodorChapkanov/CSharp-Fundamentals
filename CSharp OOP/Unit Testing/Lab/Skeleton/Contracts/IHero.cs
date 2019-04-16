using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Contracts
{
    public interface IHero
    {
        string Name { get; }

        int Experience { get; }

        void Attack(ITarget target);
    }
}
