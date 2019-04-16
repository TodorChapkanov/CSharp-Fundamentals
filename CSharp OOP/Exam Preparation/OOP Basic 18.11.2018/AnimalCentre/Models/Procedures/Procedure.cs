using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        protected List<IAnimal> procedureHistory;

        public Procedure()
        {
            procedureHistory = new  List<IAnimal>();
        }
        public string History()
        {
            var builder = new StringBuilder();
            builder.AppendLine(this.GetType().Name);
            foreach (var animal in procedureHistory)
            {
                    builder.AppendLine(animal.ToString());
            }

            return builder.ToString();
        }

        public abstract void DoService(IAnimal animal, int procedureTime);

        protected void ValidateProcedureTimeLeft(IAnimal animal, int time)
        {
            if (animal.ProcedureTime < time)
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }
        }

        protected void RecordProcedure(IAnimal animal)
        {
            procedureHistory.Add(animal);
        }
    }
}
