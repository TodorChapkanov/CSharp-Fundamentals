namespace P03.DetailPrinter
{
    using System.Collections.Generic;
    using System.Text;

    public class Manager  : Employee
    {
        private IReadOnlyCollection<string> Documents { get; set; }

        public Manager(string name, ICollection<string> documents) 
            : base(name)
        {
            this.Documents = new List<string>(documents);
        }
        
        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(this.Name);

            foreach (var document in Documents)
            {
                builder.AppendLine(document);
            }

            return builder.ToString();
        }
        
    }
}
