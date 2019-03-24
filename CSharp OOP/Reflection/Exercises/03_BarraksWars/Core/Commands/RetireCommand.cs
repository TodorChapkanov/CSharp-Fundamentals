namespace _03_BarraksWars.Core.Commands
{
    using _03_BarracksFactory.Contracts;

   public  class RetireCommand : Command
    {
        public RetireCommand(string[] data, IRepository repository, IUnitFactory unitFactory) : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            string unitType = this.Data[1];
            this.Repository.RemoveUnit(unitType);
            string output = unitType + " retired!";
            return output;
        }
    }
}
