namespace _01_Person
{
    using System;

    public class Child : Person
    {

        public Child(string name, int age) : base(name, age)
        {
        }

        public override string Name
        {
            get => base.Name;
            set
            {
                base.ValidateNameLength(value);
                base.Name = value;

            }
        }

        public override int Age
        {
            get => base.Age;
            set
            {
                if (value >= 15)
                {
                    throw new ArgumentException(Constant.InvalidChildAge);
                }
                base.Age = value;
            }
        }
    }
}
