namespace INStock.Tests
{
    using INStock.Contracts;
    using INStock.Models;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class ProductStockTests
    {
        IProductStock stock;
        IProduct dummyProduct;

        [SetUp]
        public void SetUp()
        {
            this.stock = new ProductStock();

            var label = "SSD";
            var price = 15.15m;
            var quantity = 2;
            this.dummyProduct = new Product(label, price, quantity);

        }
      
        [Test]
        public void CountShouldReturnProperValue()
        {
            var label = "SSD";
            var price = 15.25m;
            var quantity = 2;
            var product = new Product(label, price, quantity);
            stock = new ProductStock();

            this.stock.Add(product);

            var expectedValue = 1;
            var actualValue = this.stock.Count;

            Assert.AreEqual(expectedValue, actualValue);
        }
        
        [Test]
        public void IndexerShouldReturnProperItem()
        {
            this.stock.Add(dummyProduct);

            var product = this.stock[0];

            Assert.AreSame(this.dummyProduct, product);
        }

        [Test]
        public void IndexShouldThrouExceptionIfIndexIsNegative()
        {
            Assert.That(() => this.stock[-3],
                Throws.ArgumentException);
        }

        [Test]
        public void IndexShouldThrouExceptionIfIndexIsBiggerThanCollectionCapacity()
        {
            Assert.That(() => this.stock[10],
                Throws.ArgumentException);
        }

        [Test]
        public void IndexShouldThrouExceptionIfValueOnTheIndexIsNull()
        {
            Assert.That(() => this.stock[2],
                Throws.ArgumentException);
        }

        [Test]
        public void ContinsShouldReturnTrueIfItemExist()
        {
            this.stock.Add(this.dummyProduct);

            Assert.IsTrue(this.stock.Contains(this.dummyProduct));

        }


        [Test]
        public void ContinsShouldReturnFalseIfItemNotExist()
        {
            Assert.IsFalse(this.stock.Contains(this.dummyProduct));
        }

        [Test]
        public void ContainsShouldThrowExceptionIfItemIsNull()
        {
            Assert.That(() => this.stock.Contains(null),
                Throws.ArgumentNullException);

        }

        [Test]
        public void AddMethodShouldInsertProperly()
        {
            this.stock.Add(this.dummyProduct);

            Assert.IsTrue(this.stock.Contains(this.dummyProduct));
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfProductIsNull()
        {
            Assert.That(() => this.stock.Add(null),
                Throws.ArgumentNullException);
        }

        [Test]
        public void AddMethodShouldIncreaseQuantityIfItemExisteIiCollection()
        {
            this.stock.Add(this.dummyProduct);
            var expectedValue = this.dummyProduct.Quantity * 2;
            this.stock.Add(this.dummyProduct);
            var actualValue = this.stock[0].Quantity;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void AddMetodShouldIncreaseCounter()
        {
            this.stock.Add(dummyProduct);

            var expectedValue = 1;
            var actualValue = this.stock.Count;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void FindeShouldReturnProperProduct()
        {
            this.stock.Add(this.dummyProduct);

            var expectedValue = this.dummyProduct;
            var actualValue = this.stock[0];

            Assert.AreSame(expectedValue, actualValue);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-50)]
        [TestCase(50)]
        [TestCase(500)]
        public void FindeShouldThrowExeptionIfIndexIsOutOfRange(int index)
        {
            Assert.That(() => this.stock[index],
                Throws.ArgumentException);
        }
        
        [Test]
        public void FindAllByPriceShouldReturnProperProduct()
        {
            var label = "RAM";
            var price = 15.15m;
            var quantity = 5;
            var product = new Product(label, price, quantity);
            this.stock.Add(product);
            this.stock.Add(this.dummyProduct);

            var IsContainsProductsBuPrice = true;
            var allProducts = this.stock.FindAllByPrice(15.15);
            foreach (var item in allProducts)
            {
                if (item != product && item != this.dummyProduct)
                {
                    IsContainsProductsBuPrice = false;
                }
            }

            Assert.IsTrue(IsContainsProductsBuPrice);
        }

        [Test]
        public void FindeAllByPriceShouldTrowExceptionIfQuantityIsNegative()
        {
            Assert.That(() => this.stock.FindAllByPrice(-5),
                Throws.ArgumentException);
        }

        [Test]
        public void FindeAllByQuantityShouldReturnProperProduct()
        {
            var label = "RAM";
            var price = 15.15m;
            var quantity = 2;
            var product = new Product(label, price, quantity);
            this.stock.Add(product);
            this.stock.Add(dummyProduct);

           
            var actualValue = this.stock.FindAllByQuantity(this.dummyProduct.Quantity);

            var IsContainItemByQuantity = true;

            foreach (var item in actualValue)
            {
                if (item != product && item != this.dummyProduct)
                {
                    IsContainItemByQuantity = false;
                }
            }

            Assert.IsTrue(IsContainItemByQuantity);
        }

        [Test]
        public void FindeAllByQuantityShouldTrowExceptionIfQuantityIsNegative()
        {
            Assert.That(() => this.stock.FindAllByQuantity(-5),
                Throws.ArgumentException);
        }
        
        [Test]
        public void FindeAllInRangeShouldReturnAllProductsInPriceRange()
        {
            var lowPrice = 1.00;
            var highPrice = 20.00;
            var label = "RAM";
            var price = 17.15m;
            var quantity = 2;
            var product = new Product(label, price, quantity);
            this.stock.Add(product);
            this.stock.Add(dummyProduct);

            var allProductsInPriceRange = this.stock.FindAllInRange(lowPrice, highPrice);

            var IsContainItemByPriceRange = true;

            foreach (var item in allProductsInPriceRange)
            {
                if (item != product && item != this.dummyProduct)
                {
                    IsContainItemByPriceRange = false;
                }
            }

            Assert.IsTrue(IsContainItemByPriceRange);
        }

        [Test]
        public void FindeAllInRangeShouldThrowExceptionIfHighPriceIsLowerThanLowPrice()
        {
            var lowPrice = 10.00;
            var highPrice = 2.00;
            var label = "RAM";
            var price = 17.15m;
            var quantity = 2;
            var product = new Product(label, price, quantity);
            this.stock.Add(product);
            this.stock.Add(dummyProduct);

            Assert.That(() => this.stock.FindAllInRange(lowPrice, highPrice),
                Throws.ArgumentException);
        }

        [Test]
        public void FindeAllInRangeShouldThrowExceptionIfLowPriceIsNegative()
        {
            var lowPrice = -10.00;
            var highPrice = 2.00;
            var label = "RAM";
            var price = 17.15m;
            var quantity = 2;
            var product = new Product(label, price, quantity);
            this.stock.Add(product);
            this.stock.Add(dummyProduct);

            Assert.That(() => this.stock.FindAllInRange(lowPrice, highPrice),
                Throws.ArgumentException);
        }
        
        [Test]
        public void RemoveMethodShouldReturnTrueIfItemIsRemoved()
        {
            this.stock.Add(this.dummyProduct);

            var result = this.stock.Remove(this.dummyProduct);

            Assert.IsTrue(result);
        }

        [Test]
        public void RemoveShouldReturnFalseIfItemNotExiste()
        {
            var result = this.stock.Remove(this.dummyProduct);

            Assert.IsFalse(result);
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionIfProductIsNull()
        {
            Assert.That(() => this.stock.Remove(null),
                Throws.ArgumentNullException);
        }
       
        [Test]
        public void FindeByLabelShouldReturnProperProduct()
        {
            this.stock.Add(this.dummyProduct);
            var expectedValue = this.dummyProduct.Label;
            var actualValue = this.stock.FindByLabel(expectedValue).Label;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void FindeByLabelShouldThrowExceptionIfLabelIsNull()
        {
            Assert.That(() => this.stock.FindByLabel(null),
                Throws.ArgumentNullException);
        }

        [Test]
        public void FindeByLabelShouldThrowExceptionIfNoItemWithSameLabel()
        {
            Assert.That(() => this.stock.FindByLabel(this.dummyProduct.Label),
                Throws.InvalidOperationException);
        }
        
        [Test]
        public void FindMostExpensiveProductShouldReturnProperProduct()
        {
            var label = "RAM";
            var price = 85.15m;
            var quantity = 2;
            var product = new Product(label, price, quantity);
            this.stock.Add(product);
            this.stock.Add(dummyProduct);

            var actualProduct = this.stock.FindMostExpensiveProduct();

            Assert.AreSame(product, actualProduct);
        }

        [Test]
        public void FindMostExpensiveProductShouldThrowExceptionIfCollectionIsEmpty()
        {
            Assert.That(() => this.stock.FindMostExpensiveProduct(),
                Throws.InvalidOperationException);
        }
    }
}
