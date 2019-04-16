namespace Skeleton.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    class DummyTests
    {
        [Test]
        public void DummyLosesHealthAfterAttack()
        {
            Dummy dummy = new Dummy(10, 10);

            dummy.TakeAttack(5);

            Assert.AreEqual(5, dummy.Health,"Dummy health is not changing after attack!");
        }

        [Test]
        public void DeathDummyMustThrowExeprionIfAttackHim()
        {
            Dummy dummy = new Dummy(2, 12);

            dummy.TakeAttack(5);

            Assert.Catch<InvalidOperationException>(() => dummy.TakeAttack(4),"Death Dummy not throw Exeption after attack!");
        }
        
        [Test]
        public void DeathDummyMustReturExperienceFromGetExperienceMethod()
        {
            Dummy dummy = new Dummy(2, 10);

            dummy.TakeAttack(5);
            var experience = dummy.GiveExperience();

            Assert.AreEqual(10, experience);
        }

        [Test]
        public void AliveDummyCanotReturnExperienceFormGiveExperienceMethod()
        {
            var dummy = new Dummy(10, 10);

            Assert.Catch<InvalidOperationException>(() => dummy.GiveExperience(), "Alive Dummy return experience from GiveExperience method!");
        }
    }
}
