using _04_StorageMaster.Entities.Products;
using _04_StorageMaster.Entities.Vehicles;
using NUnit.Framework;
using System.Linq;

namespace _04_StorageMaster.Structure.Tests.EntitiesTests.VehiclesTests
{
    [TestFixture]
    public class TruckTests
    {
        Vehicle truck;
        [SetUp]
        public void SetUp()
        {
            truck = new Truck();
        }

        [Test]
        public void TestCapasitySet()
        {
            var errorMessage = "Truck capasity must be {0} but is {1}";
            var expectedValue = 5;
            var actualValue = truck.Capacity;

            Assert.AreEqual(expectedValue, actualValue, string.Format(errorMessage,expectedValue, actualValue));
        }

        [Test]
        public void TestTrunkSet()
        {
            var ram = new Ram(1.20);
            truck.LoadProduct(ram);
            var actualItem = truck.Trunk.Last();
            Assert.AreSame(ram, actualItem, "Trunk not return proper product");
        }

        [Test]
        public void IsFullShouldReturnTrueIfIsFull()
        {
            var product = new HardDrive(15.80);

            for (int i = 0; i < 5; i++)
            {
                truck.LoadProduct(product);
            }

            Assert.IsTrue(truck.IsFull, "IsFull prop return different result");
        }

        [Test]
        public void IsFullshouldReturnFalseIfIsNotFull()
        {
            Assert.IsFalse(truck.IsFull, "IsFull prop return different result");
        }

        [Test]
        public void IsEmptyShouldReturTrue()
        {
            Assert.IsTrue(truck.IsEmpty, "IsEmpty return different result from true");
        }

        [Test]
        public void IsEmptyShouldReturFalseIfInTrunkHaveItem()
        {
            var product = new Ram(1.58);
            truck.LoadProduct(product);

            Assert.IsFalse(truck.IsEmpty, "IsEmpty return different rezult from false");
        }

        [Test]
        public void LoadProductShouldAddProductInTrunk()
        {
            var product = new Ram(4.85);

            truck.LoadProduct(product);

            Assert.IsFalse(truck.IsEmpty, "LoadProduct method not add product in trunk");
        }

        [Test]
        public void LoadProductShouldThrowExceptionIfTrunkIsFull()
        {
            var product = new HardDrive(18.85);

            for (int i = 0; i < 5; i++)
            {
                truck.LoadProduct(product);
            }

            Assert.That(() => truck.LoadProduct(product),
                Throws.InvalidOperationException,
                "LoadProduct not throw exception when is full");
        }

        [Test]
        public void UnloadShouldRemoveItemFormTrunk()
        {
            var product = new Ram(10);
            truck.LoadProduct(product);

            truck.Unload();

            Assert.IsTrue(truck.IsEmpty, "Unload method is mot remove product from trunk");
        }

        [Test]
        public void UnloadMethodShouldReturnProduct()
        {
            var produc = new Ram(15);
            truck.LoadProduct(produc);

            var actualResult = truck.Unload();

            Assert.AreSame(produc, actualResult, "Unload methof doesn't return product");
        }

        [Test]
        public void UnloadMethodShouldThrowExceptionIfTrunkIsEmpty()
        {
            Assert.That(() => truck.Unload(),
                Throws.InvalidOperationException,
                "Unload method Doesn't throw proper exception");
        }
    }
}
