﻿namespace StorageMaster.Models.Products
{
    public class SolidStateDrive : Product
    {
        private const double weight = 0.2;
        public SolidStateDrive(double price) : base(price, weight)
        {
        }
    }
}
