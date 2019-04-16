using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class NailTrim : Procedure
    {
        public const int HappinessToRemove = 7;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.ValidateProcedureTimeLeft(animal, procedureTime);
            animal.Happiness -= HappinessToRemove;
            animal.ProcedureTime -= procedureTime;

            base.RecordProcedure(animal);
        }
    }
}
