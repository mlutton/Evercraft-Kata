using System;

namespace EverCraft
{
    public enum AlignmentTypes
    {
        Good,
        Neutral,
        Evil
    }

    public class Character
    {
        public Character()
        {
            ArmorClass = DefaultArmorClass;
            HitPoints = DefaultHitPoints;
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

        public bool IsDead()
        {
            if (HitPoints > 0) return false;
            return true;
        }
    }
}
