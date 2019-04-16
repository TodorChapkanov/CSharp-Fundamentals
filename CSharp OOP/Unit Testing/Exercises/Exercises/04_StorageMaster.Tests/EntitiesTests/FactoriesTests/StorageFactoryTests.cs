using _04_StorageMaster.Entities.Factories;
using NUnit.Framework;

namespace _04_StorageMaster.Structure.Tests.EntitiesTests.FactoriesTests
{
    [TestFixture]
   public class StorageFactoryTests
    {

        StorageFactory factory;

        [SetUp]
        public void SetUp()
        {
            factory = new StorageFactory();
        }

        [Test]
        public void CreateProductShouldReturProductInstance()
        {
            var storageType = "Warehouse";
            var product = factory.CreateStorage(storageType, "Warehouse");

            Assert.That(product.GetType().Name == storageType,
                $"CreateStorage method return different type of product form {storageType}");
        }

        [Test]
        public void CreateProductShouldThrowExceptionIfNameIsNull()
        {
            Assert.That(() => factory.CreateStorage(null, "Warehouse"),
                Throws.InvalidOperationException
                .With
                .Message
                .EqualTo("Invalid storage type!"),
                "CreateStorage throw different exception or messege");
        }
    }
}
