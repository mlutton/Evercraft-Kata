using System;
using EverCraft;
using NUnit.Framework;

namespace Tests.EverCraft
{
    [TestFixture]
    public class CharacterTests
    {
        [Test]
        public void CharacterShouldSupportGettingAndSettingAName()
        {
            var character = new Character();

            character.Name = "Faceman";

            Assert.AreEqual("Faceman", character.Name);
        }

        [Test]
        public void CharacterShouldSupportGettingAndSettingAlignment()
        {
            var character = new Character();

            character.Alignment = AlignmentTypes.Good;

            Assert.AreEqual(AlignmentTypes.Good, character.Alignment);
        }

        [Test]
        public void CharacterHasDefaultArmorClass()
        {
            var character = new Character();

            Assert.AreEqual(Character.DefaultArmorClass, character.ArmorClass);
        }

        [Test]
        public void CharacterHasADefaultSetOfHitPoints()
        {
            var character = new Character();

            Assert.AreEqual(Character.DefaultHitPoints, character.HitPoints);
        }

        [Test]
        public void CharacterHitsWithAttackThatMeetsArmorClass()
        {
            var attacker = new Character();
            var defender = new Character();

            var dieRoll = defender.ArmorClass;

            Assert.Greater(attacker.Attacks(defender.ArmorClass, dieRoll), 0);
        }

        [Test]
        public void CharacterHitsWithAttackThatIsGreaterThanArmorClass()
        {
            var attacker = new Character();
            var defender = new Character();

            var dieRoll = defender.ArmorClass + 1;

            Assert.Greater(attacker.Attacks(defender.ArmorClass, dieRoll), 0);
        }

        [Test]
        public void CharacterMissesWithAttackThaIsLessThanArmorClass()
        {
            var attacker = new Character();
            var defender = new Character();

            var dieRoll = defender.ArmorClass - 1;

            Assert.AreEqual(attacker.Attacks(defender.ArmorClass, dieRoll), 0);
        }

        [Test]
        public void CharacterDefaultsDamangeOnNormalHit()
        {
            var attacker = new Character();
            var defender = new Character();

            var dieRoll = defender.ArmorClass;

            Assert.AreEqual(attacker.Attacks(defender.ArmorClass, dieRoll), Character.DefaultDamage);
        }

        [Test]
        public void CharacterDoublesDamageOnCriticalHit()
        {
            var attacker = new Character();
            var defender = new Character();

            var dieRoll = 20;

            Assert.AreEqual(attacker.Attacks(defender.ArmorClass, dieRoll), Character.DefaultDamage*2);
        }

        [Test]
        public void CharacterIsAlivesWhenHitPointsAreGreaterThanZero()
        {
            var attacker = new Character();
            var defender = new Character();

            defender.HitPoints = 1;

            Assert.IsFalse(defender.IsDead());
        }

        [Test]
        public void CharacterDiesWhenHitPointsAreZero()
        {
            var attacker = new Character();
            var defender = new Character();

            defender.HitPoints = 0;

            Assert.IsTrue(defender.IsDead());
        }

        [TestCase(AbilityTypes.Strength, Character.AbilityMinimumValue)]
        [TestCase(AbilityTypes.Strength, Character.AbilityMaximumValue)]
        [TestCase(AbilityTypes.Charisma, Character.AbilityMinimumValue)]
        [TestCase(AbilityTypes.Constitution, Character.AbilityMinimumValue)]
        [TestCase(AbilityTypes.Dexterity, Character.AbilityMinimumValue)]
        [TestCase(AbilityTypes.Intelligence, Character.AbilityMinimumValue)]
        [TestCase(AbilityTypes.Wisdom, Character.AbilityMinimumValue)]
        public void CharactersHaveAbilitiesSetWithinScopeCanBeSet(AbilityTypes abilityType, int abilityValue)
        {
            var character = new Character();
            character.SetAbility(abilityType, abilityValue);
            Assert.AreEqual(character.GetAbility(abilityType), abilityValue);
        }

        [TestCase(AbilityTypes.Strength, Character.AbilityMinimumValue-1)]
        [TestCase(AbilityTypes.Strength, Character.AbilityMaximumValue+1)]
        [ExpectedException(typeof(InvalidAbilityExceptionType))]
        public void CharactersHaveAbilitiesSetWithinScopeThrows(AbilityTypes abilityType, int abilityValue)
        {
            var character = new Character();
            character.SetAbility(abilityType, abilityValue);
            Assert.AreEqual(character.GetAbility(abilityType), abilityValue);
        }
    }
}
