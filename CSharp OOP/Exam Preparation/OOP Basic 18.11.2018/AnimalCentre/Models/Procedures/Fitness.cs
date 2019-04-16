using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class Fitness : Procedure
    {
        public const int HappinessToRemove = 3;
        public const int EnergyToAdd = 10;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.ValidateProcedureTimeLeft(animal, procedureTime);
            animal.Happiness -= HappinessToRemove;
            animal.Energy += EnergyToAdd;
            animal.ProcedureTime -= procedureTime;

            base.RecordProcedure(animal);
        }
    }
}
