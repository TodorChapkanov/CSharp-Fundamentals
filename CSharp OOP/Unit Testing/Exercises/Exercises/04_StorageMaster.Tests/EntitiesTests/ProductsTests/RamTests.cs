using _04_StorageMaster.Entities.Products;
using NUnit.Framework;

namespace _04_StorageMaster.Structure.Tests.EntitiesTests.ProductsTests
{
    [TestFixture]
    public class RamTests
    {
        [Test]
        public void PriceShouldBeSetProperly()
        {
            var product = new Ram(15.25);

            var expectedValue = 15.25;
            var actualValue = product.Price;
            Assert.AreEqual(expectedValue, actualValue,
                $"Price is not set correct, expected price{expectedValue} but is {actualValue}");
        }

        [Test]
        public void PriceShouldThrowExceptionIfValueIsNegative()
        {
            Assert.That(() => new Ram(-25.15),
                Throws.InvalidOperationException
                .With
                .Message
                .EqualTo("Price cannot be negative!"),
                "Price set method throw different exceprion");
        }

        [Test]
        public void WeightSetworkProperly()
        {
            var product = new Ram(12.50);

            var expectedValue = 0.1;
            var actualValue = product.Weight;
            Assert.AreEqual(expectedValue, actualValue,
                $"Weight should be {expectedValue} but is {actualValue}");
        }
    }
}
