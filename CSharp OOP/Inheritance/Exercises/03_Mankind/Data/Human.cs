using _03_Mankind.Constant;
using System;

namespace _03_Mankind
{
    public class Human
    {
        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get => this.firstName;
            private set
            {
                this.ValidateFirstNameLength(value);
                this.ValidateCapitalLetterCase(value, "firstName");
                
                this.firstName = value;
            }
        }

        public string LastName
        {
            get => this.lastName;
            set
            {
                this.ValidateLastNameLength(value);
                this.ValidateCapitalLetterCase(value, "lastName");
               
                this.lastName = value;
            }
        }

        private void ValidateFirstNameLength(string name)
        {
            if (name.Length < 4)
            {
                throw new ArgumentException(string.Format(Messages.InvalidFirstNameLength, nameof(firstName)));
            }
        }

        private void ValidateCapitalLetterCase(string name , string type)
        {
            if (!char.IsUpper(name[0]))
            {
                throw new ArgumentException(string.Format(Messages.InvalidUpperLetterCase, type));
            }

        }

        private void ValidateLastNameLength(string name)
        {
            if (name.Length < 3)
            {
                throw new ArgumentException(string.Format(Messages.InvalidLastNameLength, nameof(lastName)));
            }
        }
    }
}
