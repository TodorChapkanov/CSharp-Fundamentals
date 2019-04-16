namespace INStock.Tests
{
    using INStock.Models;
    using NUnit.Framework;

    public class ProductTests
    {
        //Product
          //-constructor
          [Test]
          public void ConstructorShoulSetProperValues()
        {
            var label = "DDR";
            var price = 15.50m;
            var quantity = 2;
            var product = new Product(label, price, quantity);

            Assert.AreEqual(label, product.Label);
            Assert.AreEqual(price, product.Price);
            Assert.AreEqual(quantity, product.Quantity);
        }


        //string Label
        // -if label is null
        [Test]
        public void ConstructorShouldThrowExceptionIfLabelIsNull()
        {
            string label = null;
            var price = 15.50m;
            var quantity = 2;
            Assert.That(() => new Product(label, price, quantity),
                Throws.ArgumentNullException);
        }

       // decimal Price
         //- is negative
         [Test]
         public void ConstructorShouldThroExceptionIfPriceIsNegative()
        {
            string label = "DDR";
            var price = -15m;
            var quantity = 2;
            Assert.That(() => new Product(label, price, quantity),
                Throws.ArgumentException);
        }

        [Test]
        public void ConstructorShoulrThrowExceptionIfPriceIsSero()
        {
            string label = "DDR";
            var price = 0;
            var quantity = 2;
            Assert.That(() => new Product(label, price, quantity),
                Throws.ArgumentException);
        }
       // int Quantity
         // -is negative
         [Test]
         public void ConstructorShouldThrowExceptionIfQuantityIsNegative()
        {
            string label = "DDR";
            var price = 15.50m;
            var quantity = -3;
            Assert.That(() => new Product(label, price, quantity),
                Throws.ArgumentException);
        }

        [Test]
        public void CompareToShouldRetutnProperResult()
        {
            string firstLabel = "SOLID HD";
            var firstPrice = 18.25m;
            var firstQuantity = 2;
            var firstProduct = new Product(firstLabel, firstPrice, firstQuantity);

            string secondLabel = "SSD HD";
            var secondPrice = 15.20m;
            var secondQuantity = 2;
            var secondProduct = new Product(secondLabel, secondPrice, secondQuantity);

            var expectedValue = 1;
            var actualValue = firstProduct.CompareTo(secondProduct);

            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}