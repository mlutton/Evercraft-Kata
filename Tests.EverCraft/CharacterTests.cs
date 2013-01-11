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
    }
}
