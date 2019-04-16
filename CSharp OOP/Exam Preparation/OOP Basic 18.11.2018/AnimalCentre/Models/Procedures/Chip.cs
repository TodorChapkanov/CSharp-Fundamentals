using AnimalCentre.Models.Contracts;
using System;

namespace AnimalCentre.Models.Procedures
{
    public class Chip : Procedure
    {
        public const int HappinessToRemove = 5;

        public override void DoService(IAnimal animal, int procedureTime)
        {
           
            base.ValidateProcedureTimeLeft(animal, procedureTime);
            if (animal.IsChipped == true)
            {
                throw new ArgumentException($"{animal.Name} is already chipped");
            }
            animal.Happiness -= HappinessToRemove;
            animal.IsChipped = true;
            animal.ProcedureTime -= procedureTime;

            base.RecordProcedure(animal);
        }
    }
}
