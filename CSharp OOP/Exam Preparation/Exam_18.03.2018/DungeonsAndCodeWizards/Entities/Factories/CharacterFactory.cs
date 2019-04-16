using DungeonsAndCodeWizards.Entities.Characters;
using DungeonsAndCodeWizards.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DungeonsAndCodeWizards.Entities.Factories
{
   public  class CharacterFactory
    {
        public static Character CreateCharacter(string type, string name,string faction)
        {
            Character character;
            try
            {
                var factionToSet = Enum.Parse<Faction>(faction);
                var characterType = Assembly
                    .GetCallingAssembly()
                    .GetTypes()
                    .First(t => t.GetTypeInfo().Name == type);

               character =  (Character)Activator.CreateInstance(characterType, new object[] { name, factionToSet });
            }

            catch (TargetInvocationException)
            {
                throw new ArgumentException($"Invalid character type \"{type}\"!");
            }
            catch (Exception)
            {
                throw new ArgumentException($"Invalid faction \"{faction}\"!");
            }

            return character;
        }
    }
}
