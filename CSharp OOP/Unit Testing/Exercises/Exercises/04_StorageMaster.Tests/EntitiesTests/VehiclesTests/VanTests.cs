using _04_StorageMaster.Entities.Products;
using _04_StorageMaster.Entities.Vehicles;
using NUnit.Framework;
using System.Linq;

namespace _04_StorageMaster.Structure.Tests.EntitiesTests.VehiclesTests
{
    [TestFixture]
    public class VanTests
    {
        Vehicle van;
        [SetUp]
        public void SetUp()
        {
            van = new Van();
        }

        [Test]
        public void TestCapasitySet()
        {
            var errorMessage = "Truck capasity must be {0} but is {1}";
            var expectedValue = 2;
            var actualValue = van.Capacity;

            Assert.AreEqual(expectedValue, actualValue, string.Format(errorMessage, expectedValue, actualValue));
        }

        [Test]
        public void TestTrunkSet()
        {
            var ram = new Ram(1.20);
            van.LoadProduct(ram);
            var actualItem = van.Trunk.Last();
            Assert.AreSame(ram, actualItem, "Trunk not return proper product");
        }

        [Test]
        public void IsFullShouldReturnTrueIfIsFull()
        {
            var product = new HardDrive(15.80);

            for (int i = 0; i < 2; i++)
            {
                van.LoadProduct(product);
            }

            Assert.IsTrue(van.IsFull, "IsFull prop return different result");
        }

        [Test]
        public void IsFullshouldReturnFalseIfIsNotFull()
        {
            Assert.IsFalse(van.IsFull, "IsFull prop return different result");
        }

        [Test]
        public void IsEmptyShouldReturTrue()
        {
            Assert.IsTrue(van.IsEmpty, "IsEmpty return different result from true");
        }

        [Test]
        public void IsEmptyShouldReturFalseIfInTrunkHaveItem()
        {
            var product = new Ram(1.58);
            van.LoadProduct(product);

            Assert.IsFalse(van.IsEmpty, "IsEmpty return different rezult from false");
        }

        [Test]
        public void LoadProductShouldAddProductInTrunk()
        {
            var product = new Ram(4.85);

            van.LoadProduct(product);

            Assert.IsFalse(van.IsEmpty, "LoadProduct method not add product in trunk");
        }

        [Test]
        public void LoadProductShouldThrowExceptionIfTrunkIsFull()
        {
            var product = new HardDrive(18.85);

            for (int i = 0; i < 2; i++)
            {
                van.LoadProduct(product);
            }

            Assert.That(() => van.LoadProduct(product),
                Throws.InvalidOperationException,
                "LoadProduct not throw exception when is full");
        }

        [Test]
        public void UnloadShouldRemoveItemFormTrunk()
        {
            var product = new Ram(10);
            van.LoadProduct(product);

            van.Unload();

            Assert.IsTrue(van.IsEmpty, "Unload method is mot remove product from trunk");
        }

        [Test]
        public void UnloadMethodShouldReturnProduct()
        {
            var produc = new Ram(15);
            van.LoadProduct(produc);

            var actualResult = van.Unload();

            Assert.AreSame(produc, actualResult, "Unload methof doesn't return product");
        }

        [Test]
        public void UnloadMethodShouldThrowExceptionIfTrunkIsEmpty()
        {
            Assert.That(() => van.Unload(),
                Throws.InvalidOperationException,
                "Unload method Doesn't throw proper exception");
        }
    }
}
