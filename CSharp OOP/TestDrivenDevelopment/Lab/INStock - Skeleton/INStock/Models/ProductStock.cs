using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using INStock.Contracts;

namespace INStock.Models
{
    public class ProductStock : IProductStock
    {
        private List<IProduct> products;

        public ProductStock()
        {
            products = new List<IProduct>();
        }

        public IProduct this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this.products[index];
            }

            set
            {
                this.ValidateIndex(index);
                products[index] = value;
            }
        }
        public int Count => this.products.Count;



        public void Add(IProduct product)
        {
            ValidateProduct(product);

            if (IsItemExist(product))
            {
                var currentProduct = this.products.First(p => p == product);

                currentProduct.Quantity += product.Quantity;
            }

            else
            {
                this.products.Add(product);
            }
        }

        public bool Contains(IProduct product)
        {
            this.ValidateProduct(product);
            return this.IsItemExist(product);
        }

        public IProduct Find(int index)
        {
            this.ValidateIndex(index);

            return null;
        }

        public IEnumerable<IProduct> FindAllByPrice(double price)
        {
            if (price <= 0)
            {
                throw new ArgumentException();
            }
            var decimalPrice = (decimal)price;
            var productsByPrice = this.products.Where(c => c.Price == decimalPrice);

            return productsByPrice;
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            if (quantity < 0)
            {
                throw new ArgumentException();
            }

            var productsByQuantity = this.products.Where(q => q.Quantity == quantity);

            return productsByQuantity;
        }

        public IEnumerable<IProduct> FindAllInRange(double lo, double hi)
        {
            if (lo < 0 || hi < lo)
            {
                throw new ArgumentException();
            }
            var decimalLow = (decimal)lo;
            var decimalHigh = (decimal)hi;
            var allProductsInRange = this.products
                .Where(p => p.Price >= decimalLow && p.Price <= decimalHigh);

            return allProductsInRange;
        }

        public IProduct FindByLabel(string label)
        {
            if (string.IsNullOrEmpty(label))
            {
                throw new ArgumentNullException();
            }

            if (!this.products.Any(p => p.Label == label))
            {
                throw new InvalidOperationException();
            }

            var result = this.products.First(l => l.Label == label);

            return result;
        }

        public IProduct FindMostExpensiveProduct()
        {
            if (this.products.Count == 0)
            {
                throw new InvalidOperationException();
            }

            var result = this.products.OrderByDescending(p => p.Price).First();
            return result;
        }

        public bool Remove(IProduct product)
        {
            this.ValidateProduct(product);
            var result = this.products.Remove(product);

            return result;
        }

        public IEnumerator<IProduct> GetEnumerator() => this.products.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void ValidateIndex(int index)
        {
            if (index < 0 || index > this.Count)
            {
                throw new ArgumentException();
            }
        }

        private bool IsItemExist(IProduct product)
        {
            if (this.products.Contains(product))
            {
                return true;
            }

            return false;
        }

        public void ValidateProduct(IProduct product)
        {
            if (product == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
