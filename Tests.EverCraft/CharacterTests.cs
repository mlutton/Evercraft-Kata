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

            Assert.IsTrue(attacker.Attacks(defender.ArmorClass, dieRoll));
        }

        [Test]
        public void CharacterHitsWithAttackThatMeetsArmorClass2()
        {
            var attacker = new Character();
            var defender = new Character();

            var dieRoll = defender.ArmorClass + 1;

            Assert.IsTrue(attacker.Attacks(defender.ArmorClass, dieRoll));
        }

        [Test]
        public void CharacterMissesWithAttackThaIsLessThanArmorClass()
        {
            var attacker = new Character();
            var defender = new Character();

            var dieRoll = defender.ArmorClass - 1;

            Assert.IsFalse(attacker.Attacks(defender.ArmorClass, dieRoll));
        }
    }
}
