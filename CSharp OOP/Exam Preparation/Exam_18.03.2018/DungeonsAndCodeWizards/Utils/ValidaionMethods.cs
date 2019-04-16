using DungeonsAndCodeWizards.Entities.Characters;
using DungeonsAndCodeWizards.Entities.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonsAndCodeWizards.Utils
{
   public  class ValidaionMethods
    {
        public static void ValidateIsAlive(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

        public static void ValidateCharacterIsExist(List<Character> characters, params string[] names)
        {
            foreach (var name in names)
            {
                if (!characters.Any(c => c.Name == name))
                {
                    throw new ArgumentException($"Character {name} not found!");
                }
            }
            
        }

        
    }
}
