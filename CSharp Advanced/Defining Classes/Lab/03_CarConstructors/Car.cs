﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _03_CarConstructors
{
    class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;

        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity = 200;
            this.fuelConsumption = 10;

        }

        public Car(string make, string model, int year): this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption) : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;

        }

        public string Make
        {
            get { return this.make; }

            set { this.make = value; }
        }

        public string Model
        {
            get { return this.model; }

            set { this.model = value; }
        }

        public int Year
        {
            get { return this.year; }

            set { this.year = value; }
        }

        public double FuelQuantity
        {
            get { return this.fuelQuantity; }

            set { this.fuelQuantity = value; }
        }

        public double FuelConsumption
        {
            get { return this.fuelConsumption; }

            set { this.fuelConsumption = value; }
        }

        public void Drive(double distance)
        {
            var fuelLeft = this.fuelQuantity - this.fuelConsumption * distance;
            if (fuelLeft >= 0)
            {
                this.fuelQuantity -= this.fuelConsumption * distance;
            }

            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }
        public string WhoAmI()
        {
             var result = new StringBuilder();
            
             result.AppendLine($"Make: {this.Make}");
            
             result.AppendLine($"Model: {this.Model}");
            
             result.AppendLine($"Year: {this.Year}");
            
             result.Append($"Fuel: {this.FuelQuantity:F2}L");

            return result.ToString();
            
        }
    }
}
