using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class Vaccinate : Procedure
    {
        public const int EnergyToRemove = 8;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.ValidateProcedureTimeLeft(animal, procedureTime);

            animal.Energy -= EnergyToRemove;
            animal.IsVaccinated = true;
            animal.ProcedureTime -= procedureTime;

            base.RecordProcedure(animal);
        }
    }
}
