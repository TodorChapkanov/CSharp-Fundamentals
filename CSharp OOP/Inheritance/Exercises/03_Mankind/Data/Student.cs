using _03_Mankind.Constant;
using System;
using System.Text;

namespace _03_Mankind.Data
{
   public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber): base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get => this.facultyNumber;
            set
            {
                this.ValidateNumber(value);
                this.ValidateLettersInNumber(value);
                this.facultyNumber = value;
            }
        }

        private  void ValidateLettersInNumber(string number)
        {
            for (int i = 0; i < number.Length; i++)
            {
                if (!char.IsDigit(number[i]) && !char.IsLetter(number[i]))
                {
                    throw new ArgumentException(Messages.InvalidFacultyNumber);
                }
            }
        }

        private void ValidateNumber(string number)
        {
            if (10 < number.Length || number.Length < 5)
            {
                throw new ArgumentException(Messages.InvalidFacultyNumber);
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"First Name: {this.FirstName}");
            builder.AppendLine($"Last Name: {this.LastName}");
            builder.AppendLine($"Faculty number: {this.FacultyNumber}");

            return builder.ToString();
        }
    }
}
