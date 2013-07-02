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
        public void CharacterIsAliveWhenHitPointsAreGreaterThanZero()
        {
            var defender = new Character();

            defender.HitPoints = 1;

            Assert.IsTrue(defender.IsAlive());
        }

        [Test]
        public void CharacterDiesWhenHitPointsAreZero()
        {
            var defender = new Character();

            defender.HitPoints = 0;

            Assert.IsFalse(defender.IsAlive());
        }

        
        [TestCase(2, 14)]
        [TestCase(10, 10)]
        [TestCase(18, 6)]
        public void CharactersStrengthAffectsSuccessfulHitRoll(int strengthValue, int dieRoll)
        {
            var attacker = new Character();
            var defender = new Character();

            attacker.Strength.Set(strengthValue);

            Assert.LessOrEqual(Character.DefaultDamage, attacker.Attacks(defender.ArmorClass, dieRoll) );
        }

        [TestCase(1, 14)]
        [TestCase(10, 9)]
        [TestCase(19, 5)]
        public void CharactersStrengthAffectsMissHitRoll(int strengthValue, int dieRoll)
        {
            var attacker = new Character();
            var defender = new Character();

            attacker.Strength.Set(strengthValue);

            Assert.AreEqual(0, attacker.Attacks(defender.ArmorClass, dieRoll));
        }

        [TestCase(1, 1)]
        [TestCase(10, 1)]
        [TestCase(12, 2)]
        [TestCase(19, 5)]
        public void CharactersStrengthAffectsDamageAmmount(int strengthValue, int expectedDamage)
        {
            var attacker = new Character();
            var defender = new Character();

            attacker.Strength.Set(strengthValue);

            const int alwaysHitRoll = 19;

            Assert.LessOrEqual(expectedDamage, attacker.Attacks(defender.ArmorClass, alwaysHitRoll));
        }

        [TestCase(1, 1)]
        [TestCase(10, 2)]
        [TestCase(12, 4)]
        [TestCase(19, 10)]
        public void CharactersStrengthAffectsCriticalDamageAmmount(int strengthValue, int expectedDamage)
        {
            var attacker = new Character();
            var defender = new Character();

            attacker.Strength.Set(strengthValue);

            const int criticalHit = 20;

            Assert.AreEqual(expectedDamage, attacker.Attacks(defender.ArmorClass, criticalHit));
        }

        [TestCase(1, 5)]
        [TestCase(9, 9)]
        [TestCase(11, 10)]
        [TestCase(20, 15)]
        public void CharactersDexterityAffectsArmorClass(int dexterityValue, int expectedArmorClass)
        {
            var defender = new Character();

            defender.Dexterity.Set(dexterityValue);

            Assert.AreEqual(expectedArmorClass, defender.ArmorClass);
        }

        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(8, 4)]
        [TestCase(11, 5)]
        [TestCase(20, 10)]
        public void CharactersConstitutionAffectsHitPoints(int constitutionValue, int expectedDefaultHitPoints)
        {
            var defender = new Character();

            defender.Constitution.Set(constitutionValue);

            Assert.AreEqual(expectedDefaultHitPoints, defender.HitPoints);
        }
    }
}
