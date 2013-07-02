﻿using System;
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
