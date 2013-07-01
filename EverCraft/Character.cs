using System;
using System.Collections.Generic;

namespace EverCraft
{
    public enum AlignmentTypes
    {
        Good,
        Neutral,
        Evil
    }

    public enum AbilityTypes
    {
        Strength,
        Wisdom,
        Intelligence,
        Dexterity,
        Constitution,
        Charisma
    }

    public class InvalidAbilityExceptionType : ApplicationException
    {
        
    }

    public class Character
    {
        Dictionary<AbilityTypes, int> _abilities = new Dictionary<AbilityTypes, int>(); 

        public Character()
        {
            ArmorClass = DefaultArmorClass;
            HitPoints = DefaultHitPoints;
        }

        public const int DefaultArmorClass = 10;
        public const int DefaultHitPoints = 5;
        public const int DefaultDamage = 1;
        public const int AbilityMinimumValue = 1;        
        public const int AbilityMaximumValue = 20;

        public String Name { get; set; }
        public AlignmentTypes Alignment  { get; set; }
        public int ArmorClass { get; set; }
        public int HitPoints { get; set; }

        public int Attacks(int armorClass, int roll)
        {
            if (roll == 20)
            {
                return DefaultDamage*2;
            }
            else if (roll >= armorClass)
            {
                return DefaultDamage;
            }

            return 0;
        }

        public bool IsDead()
        {
            if (HitPoints > 0) return false;
            return true;
        }

        public void SetAbility(AbilityTypes abilityType, int abilityValue)
        {
            if (abilityValue < AbilityMinimumValue)
                throw new InvalidAbilityExceptionType();

            if (abilityValue > AbilityMaximumValue)
                throw new InvalidAbilityExceptionType();

            if (_abilities.ContainsKey(abilityType))
            {
                _abilities.Remove(abilityType);
            }

            _abilities.Add(abilityType, abilityValue);
        }

        public int GetAbility(AbilityTypes abilityType)
        {
            return _abilities[abilityType];
        }
    }
}
