using System;

namespace MuOnline.Utilities
{
  public  class Validators
    {
        public static void ValidateNullInput<T>(T input, string argumentType)
        {
            if (input == null)
            {
                throw new ArgumentNullException($"{argumentType} cannot be null!");
            }
        }

        public static string SuccessfullyCreateMessage = "Successfully created new {0}!";
    }
}
