using _04_StorageMaster.Entities.Factories;
using NUnit.Framework;

namespace _04_StorageMaster.Structure.Tests.EntitiesTests.FactoriesTests
{
    [TestFixture]
    public class VehicleFactoryTests
    {

        VehicleFactory factory;

        [SetUp]
        public void SetUp()
        {
            factory = new VehicleFactory();
        }

        [Test]
        public void CreateProductShouldReturProductInstance()
        {
            var vehicleType = "Van";
            var product = factory.CreateVehicle(vehicleType);

            Assert.That(product.GetType().Name == vehicleType,
                $"CreateVehicle method return different type of product form {vehicleType}");
        }

        [Test]
        public void CreateProductShouldThrowExceptionIfNameIsNull()
        {
            Assert.That(() => factory.CreateVehicle(null),
                Throws.InvalidOperationException
                .With
                .Message
                .EqualTo("Invalid vehicle type!"),
                "CreateVehicle throw different exception or messege");
        }
    }
}
