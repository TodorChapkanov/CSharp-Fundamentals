using DungeonsAndCodeWizards.Entities.Bags;
using DungeonsAndCodeWizards.Entities.Enums;
using DungeonsAndCodeWizards.Entities.Items;
using DungeonsAndCodeWizards.Utils;
using System;

namespace DungeonsAndCodeWizards.Entities.Characters
{
    public abstract class Character
    {
        private const double InitialRestHealMultiplier = 0.2;

        private string name;

        protected Character(string name, double health,
            double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.Health = health;
            this.BaseHealth = health;
            this.Armor = armor;
            this.BaseArmor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
            this.RestHealMultiplier = InitialRestHealMultiplier;
            this.IsAlive = true;
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                this.name = value;
            }
        }

        public double BaseHealth { get; private set; }

        public double Health { get; set; }

        public double BaseArmor { get; private set; }

        public double Armor { get;  set; }

        public double AbilityPoints { get; private set; }

        public Bag Bag { get; private set; }

        public Faction Faction { get; private set; }

        public bool IsAlive { get;  set; }

        public virtual double RestHealMultiplier { get; set; }


       public  void TakeDamage(double hitPoints)
        {
            ValidaionMethods.ValidateIsAlive(this);
            if (this.Armor >= hitPoints)
            {
                this.Armor -= hitPoints;
            }

            else
            {
                hitPoints -= this.Armor;
                this.Armor = 0;
                this.Health -= hitPoints;
                if (this.Health <= 0)
                {
                    this.IsAlive = false;
                    this.Health = 0;
                }
            }
        }

        public void Rest()
        {
            ValidaionMethods.ValidateIsAlive(this);

            this.Health += this.BaseHealth * this.RestHealMultiplier;
        }

        public void UseItem(Item item)
        {
            ValidaionMethods.ValidateIsAlive(this);
            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            ValidaionMethods.ValidateIsAlive(this);
            ValidaionMethods.ValidateIsAlive(character);
            item.AffectCharacter(character);
        }

       public void GiveCharacterItem(Item item, Character character)
        {
            ValidaionMethods.ValidateIsAlive(this);
            ValidaionMethods.ValidateIsAlive(character);

            character.Bag.AddItem(item);
        }

        public void ReceiveItem(Item item)
        {
            ValidaionMethods.ValidateIsAlive(this);
            this.Bag.AddItem(item);
        }
    }
}
