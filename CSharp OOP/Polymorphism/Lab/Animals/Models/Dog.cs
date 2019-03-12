namespace Animals.Models
{
    using System.Text;
    using System;


    public class Dog : Animal
    {
        public Dog(string name, string favouriteFood)
            :base(name, favouriteFood)
        {
        }

        public override string ExplainSelf()
        {
            var builder = new StringBuilder();
            builder.AppendLine(base.ExplainSelf());
            builder.Append("DJAAF");

            return builder.ToString();
        }
    }
}
