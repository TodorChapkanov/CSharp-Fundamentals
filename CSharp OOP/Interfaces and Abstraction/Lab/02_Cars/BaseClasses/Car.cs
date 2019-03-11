﻿namespace Cars.BaseClasses
{
    using Cars.Interfaces;

    public class Car : ICar
    {
        private string model;
        private string color;

        public Car(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }

        public string Model
        {
            get => this.model;
            private set
            {
                this.model = value;
            }
        }

        public string Color
        {
            get => this.color;
            private set
            {
                this.color = value;
            }
        }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }
    }
}