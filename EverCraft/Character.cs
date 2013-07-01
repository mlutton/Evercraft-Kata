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
        public String Name { get; set; }
        public AlignmentTypes Alignment  { get; set; }
    }
}
