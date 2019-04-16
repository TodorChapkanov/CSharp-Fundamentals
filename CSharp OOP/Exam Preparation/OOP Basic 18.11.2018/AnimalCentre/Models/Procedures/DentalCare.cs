using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class DentalCare : Procedure
    {
        public const int HappinessToAdd = 12;
        public const int EnergyToAdd = 10;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.ValidateProcedureTimeLeft(animal, procedureTime);
            animal.Happiness += HappinessToAdd;
            animal.Energy += EnergyToAdd;
            animal.ProcedureTime -= procedureTime;

            base.RecordProcedure(animal);

        }
    }
}
