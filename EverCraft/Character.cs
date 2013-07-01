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

        public String Name { get; set; }
        public AlignmentTypes Alignment  { get; set; }
        public int ArmorClass { get; set; }
        public int HitPoints { get; set; }
    }
}
