using System;
using System.Collections.Generic;
using System.Text;

namespace CosmosX.Entities.Modules.Absorbing
{
    class CooldownSystem : BaseAbsorbingModule
    {
        public CooldownSystem(int id, int heatAbsorbing) 
            : base(id, heatAbsorbing)
        {
        }
    }
}
