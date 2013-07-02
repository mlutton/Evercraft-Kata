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

            Experience = 0;
            Level = 1;
        }

        public const int DefaultArmorClass = 10;
        public const int DefaultHitPoints = 5;
        public const int DefaultDamage = 1;
        public const int DefaultExperiencePointsPerHit = 10;

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
                return _hitPoints == 0 ? 0 : GetHitPointsWithModifier();
            }
            set
            {
                _hitPoints = value;
            }
        }

        private int GetHitPointsWithModifier()
        {
            var hitPoints = _hitPoints + Constitution.GetModifier();

            if (hitPoints < 1) return 1;

            return hitPoints;
        }

        public int Attacks(int armorClass, int roll)
        {
            var damageAmmount = 0;

            if (roll == 20)
            {
                damageAmmount = GetCriticalDamageAmount(DefaultDamage, Strength.GetModifier());
            }
            else if (GetModifiedRoll(roll, Level, Strength.GetModifier()) >= armorClass)
            {
                damageAmmount = GetDamageAmount(DefaultDamage, Strength.GetModifier());
            }

            if (damageAmmount > 0)
            {
                AddExperiencePoints();
            }

            return damageAmmount;
        }

        private void AddExperiencePoints()
        {
            Experience += DefaultExperiencePointsPerHit;

            int level = Experience/1000;
            level = (int) Math.Round((double) level, 0) + 1;

            if (Level != level)
            {
                HitPoints = HitPoints + 5 + Constitution.GetModifier();
                Level = level;
            }
        }

        private static int GetDamageAmount(int defaultDamage, int strengthModifier)
        {
            var potentialDamage = defaultDamage + strengthModifier;

            if (potentialDamage < defaultDamage) return defaultDamage;
            return potentialDamage;
        }

        private static int GetModifiedRoll(int roll, int level, int strengthModifier)
        {
            
            int levelDiv = level/2;
            var levelRounded = (int) Math.Round((double) levelDiv, 0);
            return roll + strengthModifier + levelRounded;
        }

        private static int GetCriticalDamageAmount(int defaultDamage, int strengthModifier)
        {
            var baseDamage = defaultDamage + strengthModifier;

            if (baseDamage < 1) return defaultDamage;

            return baseDamage*2;
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
        public int Experience { get; set; }
        public int Level { get; set; }
    }
}
