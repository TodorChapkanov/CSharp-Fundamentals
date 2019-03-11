namespace _06_Animals.Data
{
   public class Tomcat : Cat
    {
        public Tomcat(string name, int age)
            : base(name, age, "Male")
        {
        }

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
