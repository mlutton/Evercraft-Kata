using EverCraft;
using NUnit.Framework;

namespace Tests.EverCraft
{
    [TestFixture]
    public class AbilityTests
    {
        [TestCase(Ability.AbilityMinimumValue)]
        [TestCase(Ability.AbilityMaximumValue)]
        public void AbilitiesSetWithinScopeCanBeSet( int abilityValue)
        {
            var ability = new Ability();
            ability.SetAbility(abilityValue);
            Assert.AreEqual(ability.GetAbility(), abilityValue);
        }

        [TestCase(Ability.AbilityMinimumValue - 1)]
        [TestCase(Ability.AbilityMaximumValue + 1)]
        [ExpectedException(typeof(InvalidAbilityException))]
        public void CharactersHaveAbilitiesSetOutsideScopeThrows(int abilityValue)
        {
            var ability = new Ability();
            ability.SetAbility(abilityValue);
        }
    }
}
