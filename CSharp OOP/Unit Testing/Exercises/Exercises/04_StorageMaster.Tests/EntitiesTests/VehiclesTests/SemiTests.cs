using _04_StorageMaster.Entities.Products;
using _04_StorageMaster.Entities.Vehicles;
using NUnit.Framework;
using System.Linq;

namespace _04_StorageMaster.Structure.Tests.EntitiesTests.VehiclesTests
{
    [TestFixture]
    public class SemiTests
    {
        Vehicle semi;
        [SetUp]
        public void SetUp()
        {
            semi = new Semi();
        }

        [Test]
        public void TestCapasitySet()
        {
            var errorMessage = "Semi capasity must be 10 but is {0}";
            var expectedValue = 10;
            var actualValue = semi.Capacity;

            Assert.AreEqual(expectedValue, actualValue, string.Format(errorMessage, actualValue));
        }

        [Test]
        public void TestTrunkSet()
        {
            var ram = new Ram(1.20);
            semi.LoadProduct(ram);
            var actualItem = semi.Trunk.Last();
            Assert.AreSame(ram, actualItem, "Trunk not return proper product");
        }

        [Test]
        public void IsFullShouldReturnTrueIfIsFull()
        {
            var product = new HardDrive(15.80);

            for (int i = 0; i < 10; i++)
            {
                semi.LoadProduct(product);
            }

            Assert.IsTrue(semi.IsFull, "IsFull prop return different result");
        }

        [Test]
        public void IsFullshouldReturnFalseIfIsNotFull()
        {
            Assert.IsFalse(semi.IsFull, "IsFull prop return different result");
        }

        [Test]
        public void IsEmptyShouldReturTrue()
        {
            Assert.IsTrue(semi.IsEmpty, "IsEmpty return different result from true");
        }

        [Test]
        public void IsEmptyShouldReturFalseIfInTrunkHaveItem()
        {
            var product = new Ram(1.58);
            semi.LoadProduct(product);

            Assert.IsFalse(semi.IsEmpty, "IsEmpty return different rezult from false");
        }

        [Test]
        public void LoadProductShouldAddProductInTrunk()
        {
            var product = new Ram(4.85);

            semi.LoadProduct(product);

            Assert.IsFalse(semi.IsEmpty, "LoadProduct method not add product in trunk");
        }

        [Test]
        public void LoadProductShouldThrowExceptionIfTrunkIsFull()
        {
            var product = new HardDrive(18.85);

            for (int i = 0; i < 10; i++)
            {
                semi.LoadProduct(product);
            }

            Assert.That(() => semi.LoadProduct(product),
                Throws.InvalidOperationException,
                "LoadProduct not throw exception when is full");
        }

        [Test]
        public void UnloadShouldRemoveItemFormTrunk()
        {
            var product = new Ram(10);
            semi.LoadProduct(product);

            semi.Unload();

            Assert.IsTrue(semi.IsEmpty, "Unload method is mot remove product from trunk");
        }

        [Test]
        public void UnloadMethodShouldReturnProduct()
        {
            var produc = new Ram(15);
            semi.LoadProduct(produc);

            var actualResult = semi.Unload();

            Assert.AreSame(produc, actualResult, "Unload methof doesn't return product");
        }

        [Test]
        public void UnloadMethodShouldThrowExceptionIfTrunkIsEmpty()
        {
            Assert.That(() => semi.Unload(),
                Throws.InvalidOperationException,
                "Unload method Doesn't throw proper exception");
        }
    }
}
