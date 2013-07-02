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
            ability.Set(abilityValue);
            Assert.AreEqual(ability.Get(), abilityValue);
        }

        [TestCase(Ability.AbilityMinimumValue - 1)]
        [TestCase(Ability.AbilityMaximumValue + 1)]
        [ExpectedException(typeof(InvalidAbilityException))]
        public void CharactersHaveAbilitiesSetOutsideScopeThrows(int abilityValue)
        {
            var ability = new Ability();
            ability.Set(abilityValue);
        }

        [TestCase(1, -5)]
        [TestCase(2, -4)]
        [TestCase(3, -4)]
        [TestCase(4, -3)]
        [TestCase(5, -3)]
        [TestCase(6, -2)]
        [TestCase(7, -2)]
        [TestCase(8, -1)]
        [TestCase(9, -1)]
        [TestCase(10, 0)]
        [TestCase(11, 0)]
        [TestCase(12, 1)]
        [TestCase(13, 1)]
        [TestCase(14, 2)]
        [TestCase(15, 2)]
        [TestCase(16, 3)]
        [TestCase(17, 3)]
        [TestCase(18, 4)]
        [TestCase(19, 4)]
        [TestCase(20, 5)]
        public void CharactersAbilityValueEffectsModifiers(int abilityValue, int modifier)
        {
            var ability = new Ability();
            ability.Set(abilityValue);

            Assert.AreEqual(modifier, ability.GetModifier());
        }

    }
}
