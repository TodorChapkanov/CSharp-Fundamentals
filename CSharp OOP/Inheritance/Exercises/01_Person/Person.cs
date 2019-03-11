namespace _01_Person
{
    using System;

    public class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public virtual string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.ValidateNameLength(value);

                this.name = value;
            }
        }

        public virtual int Age
        {
            get
            {
                return this.age;
            }
            
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(Constant.InvalidAge);
                }

                this.age = value;
            }
        }

        internal void ValidateNameLength(string value)
        {
            if (value.Length < 3)
            {
                throw new ArgumentException(Constant.InvalidName);
            }
        }

        public override string ToString()
        {
            return $"Name: {this.name}, Age: {this.age}";
        }
    }
}
