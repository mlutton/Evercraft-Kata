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

    public class InvalidAbilityException : ApplicationException
    {
        
    }

    public class Character
    {
        public Character()
        {
            ArmorClass = DefaultArmorClass;
            HitPoints = DefaultHitPoints;
            
            Strength = new Ability();
            Wisdom = new Ability();
            Intelligence = new Ability();
            Dexterity = new Ability();
            Constitution = new Ability();
            Charisma = new Ability();
        }

        public const int DefaultArmorClass = 10;
        public const int DefaultHitPoints = 5;
        public const int DefaultDamage = 1;

        public String Name { get; set; }
        public AlignmentTypes Alignment  { get; set; }

        private int _armorClass = DefaultArmorClass;

        public int ArmorClass
        {
            get
            {
                return _armorClass + Dexterity.GetModifier();
            }
            set
            {
                _armorClass = value;
            }
        }

        private int _hitPoints = DefaultHitPoints;

        public int HitPoints
        {
            get
            {
                if (_hitPoints == 0) return 0;

                var hitPoints = _hitPoints + Constitution.GetModifier();

                if (hitPoints < 1) return 1;

                return hitPoints;
            }
            set
            {
                _hitPoints = value;
            }
        }

        public int Attacks(int armorClass, int roll)
        {
            if (roll == 20)
            {
                var baseDamage = DefaultDamage + Strength.GetModifier();

                if (baseDamage < 1) return DefaultDamage;

                return baseDamage*2;
            }

            var modifiedRoll = roll + Strength.GetModifier();

            if (modifiedRoll >= armorClass)
            {
                var potentialDamage = DefaultDamage + Strength.GetModifier();

                if (potentialDamage < DefaultDamage) return DefaultDamage;
                return potentialDamage;
            }

            return 0;
        }

        public bool IsAlive()
        {
            if (HitPoints <= 0) return false;
            return true;
        }

        public Ability Strength { get; set; }
        public Ability Wisdom { get; set; }
        public Ability Intelligence { get; set; }
        public Ability Dexterity { get; set; }
        public Ability Constitution { get; set; }
        public Ability Charisma { get; set; }

    }
}
