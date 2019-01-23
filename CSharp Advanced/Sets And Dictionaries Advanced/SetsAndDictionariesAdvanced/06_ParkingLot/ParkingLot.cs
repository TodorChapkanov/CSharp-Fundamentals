namespace _06_ParkingLot
{
    using System;
    using System.Collections.Generic;

    public class ParkingLot
    {
        public static void Main()
        {
            var carsPlates = new HashSet<string>();

            while (true)
            {
                var line = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (line[0] == "END")
                {
                    break;
                }
                var direction = line[0];
                var carNumber = line[1];

                if (direction == "IN")
                {
                    carsPlates.Add(carNumber);
                }
                else if (carsPlates.Contains(carNumber) && direction == "OUT")
                {
                    carsPlates.Remove(carNumber);
                }
            }
            if (carsPlates.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, carsPlates));
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
