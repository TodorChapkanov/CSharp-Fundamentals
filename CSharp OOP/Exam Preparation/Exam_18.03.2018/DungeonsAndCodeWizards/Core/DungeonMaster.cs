using DungeonsAndCodeWizards.Entities.Characters;
using DungeonsAndCodeWizards.Entities.Factories;
using DungeonsAndCodeWizards.Entities.Items;
using DungeonsAndCodeWizards.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    public class DungeonMaster
    {
        private List<Character> party;
        private List<Item> itemsPool;

        private int lastSurvivorRounds;

        public DungeonMaster()
        {
            this.party = new List<Character>();
            this.itemsPool = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            var type = args[1];
            var name = args[2];
            var faction = args[0];
            var character = CharacterFactory.CreateCharacter(type, name, faction);

            this.party.Add(character);
            return $"{character.Name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            var type = args[0];
            var item = ItemFactory.CreateItem(type);

            this.itemsPool.Add(item);
            return $"{type} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            var characterName = args[0];
            ValidaionMethods.ValidateCharacterIsExist(this.party, characterName);
            if (!this.itemsPool.Any())
            {
                throw new InvalidOperationException($"No items left in pool!");
            }
            var item = ((Item)this.itemsPool.Last());
            var currentCharacter = this.party.First(c => c.Name == characterName);
            currentCharacter.ReceiveItem(item);
            return $"{characterName} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            var characterName = args[0];
            var itemName = args[1];
            ValidaionMethods.ValidateCharacterIsExist(this.party, characterName);
            var character = this.GetCharacter(characterName);
            var item = character.Bag.GetItem(itemName);
            character.UseItem(item);

            return $"“{character.Name} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            
            var giverName = args[0];
            var receiverName = args[1];
            var itemName = args[2];
            ValidaionMethods.ValidateCharacterIsExist(this.party, giverName, receiverName);
            var giver = this.GetCharacter(giverName);
            var receiver = this.GetCharacter(receiverName);
            var item = giver.Bag.GetItem(itemName);
            receiver.UseItem(item);

            return $"{giverName} used {itemName} on {receiverName}.";

        }

        public string GiveCharacterItem(string[] args)
        {
            var giverName = args[0];
            var receiverName = args[1];
            var itemName = args[2];

            ValidaionMethods.ValidateCharacterIsExist(this.party, giverName, receiverName);
            var giver = this.GetCharacter(giverName);
            var receiver = this.GetCharacter(receiverName);
            var item = giver.Bag.GetItem(itemName);
            receiver.Bag.AddItem(item);

            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            var builder = new StringBuilder();
            foreach (var character in this.party.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health))
            {
                builder.AppendLine($"{character.Name}" +
                    $" - HP: {character.Health}/{character.BaseHealth}," +
                    $" AP: {character.Armor}/{character.BaseArmor}, Status: {character.IsAlive}");
            }

            return builder.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            var attackerName = args[0];
            var receiverName = args[1];

            ValidaionMethods.ValidateCharacterIsExist(this.party, attackerName, receiverName);
            var attacker = this.GetCharacter(attackerName);
            var receiver = this.GetCharacter(receiverName);
            if (attacker.GetType().GetMethods().Any(m => m.Name == "Attack"))
            {
                ((Warrior)attacker).Attack(receiver);
            }

            else
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

            var builder = new StringBuilder();
            builder.AppendLine($"{attacker.Name} attacks {receiver.Name} for {attacker.AbilityPoints}" +
                $" hit points!{receiver.Name} has {receiver.Health} / {receiver.BaseHealth}" +
                $" HP and {receiver.Armor} / {receiver.BaseArmor} AP left!");

            if (!receiver.IsAlive)
            {
                builder.AppendLine($"{receiver.Name} is dead!");
            }

            return builder.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            var healerName = args[0];
            var healingReceiverName = args[1];
            ValidaionMethods.ValidateCharacterIsExist(this.party, healerName, healingReceiverName);
            var healer = this.GetCharacter(healerName);
            var receiver = this.GetCharacter(healingReceiverName);
            if (healer.GetType().GetMethods().Any(m => m.Name == "Heal"))
            {
                ((Cleric)healer).Heal(receiver);
            }

            else
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }

            return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
        }

        public string EndTurn(string[] args)
        {
            var aliveCharacters = party.Where(c => c.IsAlive).ToArray();

            var sb = new StringBuilder();

            foreach (var character in aliveCharacters)
            {
                var previousHealth = character.Health;

                character.Rest();

                var currentHealth = character.Health;
                sb.AppendLine($"{character.Name} rests ({previousHealth} => {currentHealth})");
            }

            if (aliveCharacters.Length <= 1)
            {
                this.lastSurvivorRounds++;
            }

            var result = sb.ToString().TrimEnd('\r', '\n');
            return result;
        }

        public bool IsGameOver()
        {
            var oneOrZeroSurvivorsLeft = this.party.Count(c => c.IsAlive) <= 1;
            var lastSurviverSurvivedTooLong = this.lastSurvivorRounds > 1;

            return oneOrZeroSurvivorsLeft && lastSurviverSurvivedTooLong;
        }


        public Character GetCharacter(string name)
        {
           return this.party.First(c => c.Name == name);
        }
    }
}
