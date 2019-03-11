using _03_Mankind.Constant;
using System;
using System.Text;

namespace _03_Mankind.Data
{
    public class Worker : Human
    {
        private decimal weekSalary;
        private decimal workHoursPerDay;
        private decimal salaryPerHour;

        public Worker(string firstName, string lastName, decimal weekSalary, decimal hoursPerDay) : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.HoursPerDay = hoursPerDay;
            this.salaryPerHour = this.SetSalaryPerHour(this.weekSalary, this.workHoursPerDay);
        }

        public decimal WeekSalary
        {
            get => this.weekSalary;
            set
            {
                this.ValidateWeekSalary(value);
                this.weekSalary = value;
            }
        }

        public decimal HoursPerDay
        {
            get => this.salaryPerHour;
            set
            {
                this.ValidateHoursPerDay(value);
                this.workHoursPerDay = value;

            }
        }

        private decimal SetSalaryPerHour(decimal weekSalary, decimal hoursPerDay)
        {
            var salaryPerHour = weekSalary / (hoursPerDay* 5);
            return salaryPerHour;
        }

        private void ValidateWeekSalary(decimal salary)
        {
            if (salary < 10)
            {
                throw new ArgumentException($"Expected value mismatch! Argument: {nameof(weekSalary)}");
            }
        }

        private void ValidateHoursPerDay(decimal hours)
        {
            if (hours > 12 || hours < 1)
            {
                throw new ArgumentException($"Expected value mismatch! Argument: {nameof(workHoursPerDay)}");
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"First Name: {this.FirstName}");
            builder.AppendLine($"Last Name: {this.LastName}");
            builder.AppendLine($"Week Salary: {this.weekSalary:f2}");
            builder.AppendLine($"Hours per day: {this.workHoursPerDay:f2}");
            builder.Append($"Salary per hour: {this.salaryPerHour:f2}");

            return builder.ToString();
        }
    }
}
