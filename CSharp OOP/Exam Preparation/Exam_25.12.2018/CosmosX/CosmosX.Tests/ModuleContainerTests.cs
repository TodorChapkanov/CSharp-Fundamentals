namespace CosmosX.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ModuleContainerTests
    {
        IContainer moduleContainer;
        IAbsorbingModule heatProcesor;
        IEnergyModule cryogenRod;

        [SetUp]
        public void SetUp()
        {
            moduleContainer = new ModuleContainer(2);
            heatProcesor = new HeatProcessor(1, 500);
            cryogenRod = new CryogenRod(2, 100);
        }

        [Test]
        public void ConstructorShouldInitialiseCorrect()
        {
            Assert.IsNotNull(this.moduleContainer);
            Assert.AreEqual(0, this.moduleContainer.ModulesByInput.Count);
        }
        [Test]
        public void AddEnergyModuleShouldAddProperly()
        {
            this.moduleContainer.AddEnergyModule(this.cryogenRod);
            var expectedValue = this.cryogenRod.EnergyOutput;
            var actualValue = this.moduleContainer.TotalEnergyOutput;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void AddEnergyModuleShouldThrowExceptionIfEnergyModuleIsNull()
        {
            Assert.That(() => this.moduleContainer.AddEnergyModule(null),
                Throws.ArgumentException);
        }

        [Test]
        public void AddEnergyModuleShouldRemoveOldestModule()
        {
            var energyModule = new CryogenRod(3, 100);
            this.moduleContainer.AddAbsorbingModule(this.heatProcesor);
            this.moduleContainer.AddEnergyModule(this.cryogenRod);
            this.moduleContainer.AddEnergyModule(energyModule);

            var expectedValue = this.cryogenRod.EnergyOutput + energyModule.EnergyOutput;
            var actualValue = this.moduleContainer.TotalEnergyOutput;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void AddAbsorbingModuleShouldWorkCorrect()
        {
            this.moduleContainer.AddAbsorbingModule(this.heatProcesor);
            var expectedValue = this.heatProcesor.HeatAbsorbing;
            var actualValue = this.moduleContainer.TotalHeatAbsorbing;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void AddAbsorbingModuleShouldThrowExceptionIfModuleIsNull()
        {
            Assert.That(() => this.moduleContainer.AddAbsorbingModule(null),
                Throws.ArgumentException);
        }

        [Test]
        public void AddAbsorbingModuleShouldRemoveFirstModul()
        {
            var modul = new HeatProcessor(4, 500);
            this.moduleContainer.AddEnergyModule(this.cryogenRod);
            this.moduleContainer.AddAbsorbingModule(modul);
            this.moduleContainer.AddAbsorbingModule(this.heatProcesor);

            var expectedValue = this.heatProcesor.HeatAbsorbing + modul.HeatAbsorbing;
            var actualValue = this.moduleContainer.TotalHeatAbsorbing;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void ModulesByInputShouldReturnCorrectValue()
        {
            this.moduleContainer.AddAbsorbingModule(heatProcesor);
            this.moduleContainer.AddEnergyModule(cryogenRod);

            var expectedValue = 2;
            var actualValue = this.moduleContainer.ModulesByInput.Count;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void ModulesByInputShouldReturnEmpryCollectionIfIsEmpty()
        {
            Assert.AreEqual(0, this.moduleContainer.ModulesByInput.Count);
        }

        [Test]
        public void TotalHeatAbsorbingShouldWorkCorrect()
        {
            this.moduleContainer.AddAbsorbingModule(heatProcesor);
            var expectedValue = this.heatProcesor.HeatAbsorbing;
            var actualValue = this.moduleContainer.TotalHeatAbsorbing;
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void TotalHeatAbsorbingshoulReturnZeroIfIsNotHaveHeatModule()
        {
            this.moduleContainer.AddEnergyModule(this.cryogenRod);

            Assert.AreEqual(0, this.moduleContainer.TotalHeatAbsorbing);
        }

        [Test]
        public void TotalEnergyOutputeShouldWorkCorrect()
        {
            this.moduleContainer.AddEnergyModule(this.cryogenRod);

            var expectedValue = this.cryogenRod.EnergyOutput;
            var actualValue = this.moduleContainer.TotalEnergyOutput;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void TotalEnergyOutputeShouldReturnZeroIfIsNotHaveEnergyModule()
        {
            this.moduleContainer.AddAbsorbingModule(this.heatProcesor);

            Assert.AreEqual(0, this.moduleContainer.TotalEnergyOutput);
        }
    }
}