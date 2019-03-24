namespace _03_BarracksFactory.Core.Factories
{
    using System;
    using Contracts;
    using System.Reflection;
    using System.Linq;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {

            var interfaceType = typeof(IUnit);
            var allCalssesInAssembly = Assembly.GetExecutingAssembly();
            var allClasses = allCalssesInAssembly.GetTypes();
            var interfaceImplementers
                = allClasses.Where(t => t.GetInterfaces().Contains(interfaceType));

            var unitClass = interfaceImplementers.First(c => c.Name == unitType);
            var initInstance =(IUnit) Activator.CreateInstance(unitClass);
            return initInstance;
           
        }
    }
}
