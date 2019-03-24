namespace _08_CustomAttribute.Models.Weapons
{
    using _08_CustomAttribute.Attributes;
    using _08_CustomAttribute.Models.Constants;
    using Contracts;
    using Enums;
    using System;
    using System.Collections.Generic;

    [Weapon("Pesho",3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
    public abstract class Weapon : IWeapon
    {
        public Weapon(string name)
        {
            this.Name = name;
        }

       public  string Name { get; protected set; }

        public int MinDamage { get; protected set; }

        public int MaxDamage { get; protected set; }

        public IGem[] Gems { get; protected  set; }


        public void SetRearity(WeaponRearityLevel rearityLevel)
        {
            this.MinDamage *= (int)rearityLevel;
            this.MaxDamage *= (int)rearityLevel;
        }

        public void RemoveGem(int socket)
        {
            if (this.Gems[socket] == null && socket < 0 && socket >= this.Gems.Length)
            {
                throw new ArgumentException("Invalid socket!");
            }

            this.RemoveBonusDamageForOldGem(socket);
            this.Gems[socket] = null;
        }

        public void InsertGemToWeapon(IGem gem, int socket)
        {
            try
            {
                if (this.Gems[socket] != null)
                {
                    this.RemoveGem(socket);
                }
                
                this.Gems[socket] = gem;
                SetDamageWithGem(gem);
            }
            catch (Exception)
            {
                throw new ArgumentException("Invalid socket number");
            }
        }

        private void RemoveBonusDamageForOldGem(int socket)
        {
            var gemToRemove = this.Gems[socket];
            var totalMinBonusDamage = (gemToRemove.Agility * GemsPointsForWeaponDamage.MinDamagePerAgilityPoint)
                + (gemToRemove.Strength * GemsPointsForWeaponDamage.MinDamagePerStreingthPoint);

            var totalMaxBonusDamage = (gemToRemove.Agility * GemsPointsForWeaponDamage.MaxDamagePerAgilityPoint)
                + (gemToRemove.Strength * GemsPointsForWeaponDamage.MaxDamagePerStringthPoin);

            this.MinDamage -= totalMinBonusDamage;
            this.MaxDamage -= totalMaxBonusDamage;
        }

        private void SetDamageWithGem(IGem gem)
        {
            var totalMinBonusDamage = (gem.Agility * GemsPointsForWeaponDamage.MinDamagePerAgilityPoint)
                + (gem.Strength * GemsPointsForWeaponDamage.MinDamagePerStreingthPoint);

            var totalMaxBonusDamage = (gem.Agility * GemsPointsForWeaponDamage.MaxDamagePerAgilityPoint)
                + (gem.Strength * GemsPointsForWeaponDamage.MaxDamagePerStringthPoin);

            this.MinDamage += totalMinBonusDamage;
            this.MaxDamage += totalMaxBonusDamage;
        }

        public override string ToString()
        {
            var totalStrength =0;
            var totalAgility = 0;
            var totalVitality = 0;
            foreach (var gem in Gems)
            {
                if (gem != null)
                {
                    totalStrength += gem.Strength;
                    totalAgility += gem.Agility;
                    totalVitality += gem.Vitlity;
                }
                
            }

            return $"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage, +{totalStrength} Strength, +{totalAgility} Agility, +{totalVitality} Vitality";
        }
    }
}
