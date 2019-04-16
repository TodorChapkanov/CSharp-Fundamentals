using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Utils
{
    public class ValidationMethods
    {
        public static void ValidateInputNumberIsEqualOrLessThanZero(decimal value, string message)
        {
            if (value <= 0)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ValidateInputNumberIsLessThanZero(decimal value, string message)
        {
            if (value < 0)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ValidateStringForNullOrWhiteSpace(string value, string message)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(message);
            }
        }
    }
}
