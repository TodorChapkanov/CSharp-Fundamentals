
public class Pokemon
{
    private string name;
    public string element { get; set; }
    public int Health { get; set; }



    public Pokemon(string name, string element, int health)
    {
        this.name = name;
        this.element = element;
        this.Health = health;
    }
}

