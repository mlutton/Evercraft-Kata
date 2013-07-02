using System.Runtime.Serialization.Formatters;

namespace EverCraft
{
    public class Ability
    {
        private int _abilityValue = 10;

        public const int AbilityMinimumValue = 1;
        public const int AbilityMaximumValue = 20;

        public void Set(int abilityValue)
        {
            if (abilityValue < AbilityMinimumValue)
                throw new InvalidAbilityException();

            if (abilityValue > AbilityMaximumValue)
                throw new InvalidAbilityException();

            _abilityValue = abilityValue;
        }

        public int Get()
        {
            return _abilityValue;
        }

        public int GetModifier()
        {
            switch (_abilityValue)
            {
                case 1:
                    return -5;
                case 3:
                case 2:
                    return -4;
                case 5:
                case 4:
                    return -3;
                case 7:
                case 6:
                    return -2;
                case 9:
                case 8:
                    return -1;
                case 11:
                case 10:
                    return 0;
                case 13:
                case 12:
                    return 1;
                case 15:
                case 14:
                    return 2;
                case 17:
                case 16:
                    return 3;
                case 19:
                case 18:
                    return 4;
                default:
                    return 5;
            }
        }
    }
}
