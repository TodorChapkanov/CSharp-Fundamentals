using _04_StorageMaster.Entities.Factories;
using NUnit.Framework;
using System.Reflection;

namespace _04_StorageMaster.Structure.Tests.EntitiesTests.FactoriesTests
{
    [TestFixture]
    public class ProductFactoryTests
    {
        ProductFactory factory;

        [SetUp]
        public void SetUp()
        {
            factory = new ProductFactory();
        }

        [Test]
        public void CreateProductShouldReturProductInstance()
        {
            var productType = "Gpu";
            var product = factory.CreateProduct(productType, 15.10);

            Assert.That(product.GetType().Name == productType,
                $"CreateProduct method return different type of product form {productType}");
        }

        [Test]
        public void CreateProductShouldThrowExceptionIfNameIsNull()
        {
            Assert.That(() => factory.CreateProduct(null, 12.50),
                Throws.InvalidOperationException
                .With
                .Message
                .EqualTo("Invalid product type!"),
                "CreateProduct throw different exception or messege");
        }

        [Test]
        public void CreateProductShouldThrowExceptionIfPriceIsNegative()
        {
            Assert.That(() => factory.CreateProduct("Gpu", -15),Throws.InvalidOperationException
                .With
                .Message
                .EqualTo("Price cannot be negative!"));
        }
    }
}
