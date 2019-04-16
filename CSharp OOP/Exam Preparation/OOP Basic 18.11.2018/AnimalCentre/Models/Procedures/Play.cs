using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class Play : Procedure
    {
        public const int HappinessToAdd = 12;
        public const int EnergyToRemove = 6;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.ValidateProcedureTimeLeft(animal, procedureTime);
            animal.Happiness += HappinessToAdd;
            animal.Energy -= EnergyToRemove;
            animal.ProcedureTime -= procedureTime;

            base.RecordProcedure( animal);
        }
    }
}
