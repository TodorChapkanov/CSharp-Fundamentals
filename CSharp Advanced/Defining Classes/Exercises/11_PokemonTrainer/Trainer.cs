using System.Collections.Generic;
using System.Linq;

public class Trainer
{
    private List<Pokemon> pokemons = new List<Pokemon>();


    public Trainer(string name, Pokemon pokemon)
    {
        this.Name = name;
        pokemons.Add(pokemon);
    }
    public List<Pokemon> Pokemons
    {
        get { return pokemons; }
        set { this.pokemons = value; }
    }

    public string Name { get; private set; }

    public int Badges { get; private set; }



    public void AddPokemon(Pokemon pokemon)
    {
        this.pokemons.Add(pokemon);
    }

    public void AddBadges()
    {
        this.Badges++;
    }

    public void ReduceHealth()
    {
        foreach (var item in pokemons)
        {
            item.Health -= 10;
        }

        RemoveDeadPokemon();
    }

    private void RemoveDeadPokemon()
    {
        pokemons.RemoveAll(x => x.Health <= 0);
    }
}
