namespace EverCraft
{
    public class Ability
    {
        private int _abilityValue;

        public const int AbilityMinimumValue = 1;
        public const int AbilityMaximumValue = 20;

        public void SetAbility(int abilityValue)
        {
            if (abilityValue < AbilityMinimumValue)
                throw new InvalidAbilityException();

            if (abilityValue > AbilityMaximumValue)
                throw new InvalidAbilityException();

            _abilityValue = abilityValue;
        }

        public int GetAbility()
        {
            return _abilityValue;
        }
    }
}
