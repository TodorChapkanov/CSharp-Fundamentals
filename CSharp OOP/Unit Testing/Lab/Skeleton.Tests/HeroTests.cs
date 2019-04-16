namespace Skeleton.Tests
{
    using Moq;
    using NUnit.Framework;
    using Skeleton.Contracts;

    [TestFixture]
    public class HeroTests
    {
        [Test]
        public void HeroAttackMustIncreaseExperienceIfTargetIsDead()
        {
            //Arrange
            Mock<IWeapon> mockWeapon = new Mock<IWeapon>();
            Mock<ITarget> mockTarget = new Mock<ITarget>();
            IHero hero = new Hero("Ivan", mockWeapon.Object);

            //Act
            
            mockTarget.Setup(t => t.GiveExperience()).Returns(30);
            
            mockTarget.Setup(t => t.IsDead()).Returns(true);
            hero.Attack(mockTarget.Object);

            //Assert
            Assert.AreEqual(30, hero.Experience, "Hero experience is not change after attack");
        }

        [Test]
        public void HeroAttackNotIncreasExperienceIfTargetIsAlive()
        {
            //Arrange
            Mock<IWeapon> mockWeapon = new Mock<IWeapon>();
            Mock<ITarget> mockTarget = new Mock<ITarget>();
            IHero hero = new Hero("Ivan", mockWeapon.Object);

            //Act
            mockWeapon.Setup(w => w.AttackPoints).Returns(20);
            mockTarget.Setup(t => t.GiveExperience()).Returns(30);
            mockTarget.Setup(t => t.IsDead()).Returns(false);
            hero.Attack(mockTarget.Object);

            //Assert
            Assert.AreEqual(0, hero.Experience, "Hero experience is changed after attack of live target");
        }
    }
}
