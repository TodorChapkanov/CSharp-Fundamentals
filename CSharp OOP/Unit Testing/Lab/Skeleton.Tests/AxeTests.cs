namespace Skeleton.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AxeLoosesDurabilityAftertAttack()
        {
            Axe axe = new Axe(10, 10);
            var dummy = new Dummy(5, 15);

            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe durability doesnt change after attack");
        }
        
        [Test]
        public void AxeAttackWithNoDurability()
        {
            Axe axe = new Axe(10, 0);
            Dummy dummy = new Dummy(10, 10);

            Assert.Catch<InvalidOperationException>(() => axe.Attack(dummy), "Axe is broken and must return exeption");
        }
    }
}
