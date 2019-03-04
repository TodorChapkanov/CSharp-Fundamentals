using System.Text;

namespace Heroes
{
   public class Item
    {
        public Item(int strengyh, int ability, int intelligence)
        {
            this.Strength = strengyh;
            this.Ability = ability;
            this.Intelligence = intelligence;
        }
        public int Strength { get; set; }

        public int Ability { get; set; }

        public int Intelligence { get; set; }


        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine("Item:");
            builder.AppendLine($"  * Strength: { this.Strength}");
            builder.AppendLine($"  * Ability: {this.Ability}");
            builder.Append($"  * Intelligence: {this.Intelligence}");

            return builder.ToString();

        }
    }
    
}
