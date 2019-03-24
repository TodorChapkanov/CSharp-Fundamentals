namespace _03_BarraksWars.Core.Commands
{
    using _03_BarracksFactory.Contracts;

    class AddCommand : Command
    {
        public AddCommand(string[] data, IRepository repository, IUnitFactory unitFactory) : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            string unitType = this.Data[1];
             IUnit unitToAdd = this.UnitFactory.CreateUnit(unitType);
             this.Repository.AddUnit(unitToAdd);
              string output = unitType + " added!";
             return output;
        }
    }
}
