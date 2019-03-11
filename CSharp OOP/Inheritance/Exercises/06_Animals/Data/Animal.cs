namespace _06_Animals.Data
{
    using _06_Animals.Interfaces;
    using System;
    using System.Text;

    public class Animal : ISoundProducable
    {
        public  const string InvalidInput = "Invalid input!";

        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (value.Length < 3 )
                {
                    throw new ArgumentException(InvalidInput);
                }

                this.name = value;
            }
        }

        public int Age
        {
            get => this.age;
            private set
            {
                if (value <0 )
                {
                    throw new ArgumentException(InvalidInput);
                }

                this.age = value;
            }
        }

        public string Gender
        {
            get => this.gender;
            private set
            {
                if (value.Length != 4 && value.Length != 6 )
                {
                    throw new ArgumentException(InvalidInput);
                }

                this.gender = value;
            }
        }

        public virtual string ProduceSound()
        {
            return "";
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"{this.name} {this.age} {this.gender}");
            builder.Append(this.ProduceSound());

            return builder.ToString();
        }
    }
}
