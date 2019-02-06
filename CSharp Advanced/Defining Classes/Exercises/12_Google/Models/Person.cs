using System.Collections.Generic;
using System.Linq;
using System.Text;

class Person
{
    public Person(string name)
    {
        this.Name = name;
        this.Pokemons = new List<Pokemon>();
        this.Parents = new List<People>();
        this.Childrens = new List<People>();
    }

    public string Name { get; set; }

    public Company Company { get; set; }

    public Car Car { get; set; }

    public List<Pokemon> Pokemons { get; set; }

    public List<People> Parents { get; set; }

    public List<People> Childrens { get; set; }
    //TonchoTonchev
    //Company:///Car:


    public override string ToString()
    {
        var form = new StringBuilder();
        form.AppendLine(this.Name);
        form.AppendLine("Company:");
        if (this.Company != null)
        {
            form.AppendLine($"{this.Company.Name} {this.Company.Department} {this.Company.Salary:f2}");
        }
        form.AppendLine("Car:");
        if (this.Car != null)
        {
            form.AppendLine($"{this.Car.Model} {this.Car.Speed}");
        }
        form.AppendLine("Pokemon:");
        if (this.Pokemons.Count !=0)
        {
            foreach (var item in this.Pokemons)
            {
                form.AppendLine($"{item.Name} {item.Type}");
            }
        }
        form.AppendLine("Parents:");
        if (this.Parents.Any())
        {
            foreach (var item in this.Parents)
            {
                form.AppendLine($"{item.Name} {item.Birthday}");
            }
        }
        form.AppendLine("Children:");
        if (this.Childrens.Any())
        {
            foreach (var item in this.Childrens)
            {
                form.AppendLine($"{item.Name} {item.Birthday}");
            }
        }
        return form.ToString(); 
    }
}
