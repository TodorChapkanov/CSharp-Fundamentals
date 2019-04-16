namespace TheTankGame.Tests
{
    using NUnit.Framework;
  // using TheTankGame.Entities.Miscellaneous;
  // using TheTankGame.Entities.Miscellaneous.Contracts;
  // using TheTankGame.Entities.Parts;
  // using TheTankGame.Entities.Vehicles;
  // using TheTankGame.Entities.Vehicles.Contracts;

    [TestFixture]
    public class BaseVehicleTests
    {
        IAssembler assembler;

        [SetUp]
        public void SetUp()
        {
            assembler = new VehicleAssembler();

        }

        [Test]
        public void ConstructorShouldSetProperly()
        {
            var vehicle = new Revenger("SU-105", 1000.00, 20000, 100, 100, 100, assembler);

            Assert.AreEqual("SU-105", vehicle.Model);
            Assert.AreEqual(1000, vehicle.Weight);
            Assert.AreEqual(20000, vehicle.Price);
            Assert.AreEqual(100, vehicle.Attack);
            Assert.AreEqual(100, vehicle.Defense);
            Assert.AreEqual(100, vehicle.HitPoints);
        }

        [TestCase(" ")]
        [TestCase(null)]
        public void ModelShouldThrowExceptionIfIsNull(string model)
        {
            Assert.That(() => new Revenger(model, 1000.00, 20000, 100, 100, 100, assembler),
                Throws.ArgumentException
                .With
                .Message
                .EqualTo("Model cannot be null or white space!"));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-500)]
        public void WeightShouldThrowException(int weight)
        {
            Assert.That(() => new Revenger("SU-105", weight, 20000, 100, 100, 100, assembler),
                Throws.ArgumentException
                .With
                .Message
                .EqualTo("Weight cannot be less or equal to zero!"));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-500)]
        public void PriceShouldThrowException(int price)
        {
            Assert.That(() => new Revenger("SU-105", 1000, price, 100, 100, 100, assembler),
                Throws.ArgumentException
                .With
                .Message
                .EqualTo("Price cannot be less or equal to zero!"));
        }

        [TestCase(-1)]
        [TestCase(-500)]
        public void AttackShouldThrowException(int attack)
        {
            Assert.That(() => new Revenger("SU-105", 1000, 20000, attack, 100, 100, assembler),
                Throws.ArgumentException
                .With
                .Message
                .EqualTo("Attack cannot be less than zero!"));
        }

        [TestCase(-1)]
        [TestCase(-500)]
        public void DefenceShouldThrowException(int defence)
        {
            Assert.That(() => new Revenger("SU-105", 1000, 20000, 100, defence, 100, assembler),
                Throws.ArgumentException
                .With
                .Message
                .EqualTo("Defense cannot be less than zero!"));
        }

        [TestCase(-1)]
        [TestCase(-500)]
        public void HitPointsShouldThrowException(int hitPoints)
        {
            Assert.That(() => new Revenger("SU-105", 1000, 20000, 100, 100, hitPoints, assembler),
                Throws.ArgumentException
                .With
                .Message
                .EqualTo("HitPoints cannot be less than zero!"));
        }

        [Test]
        public void AddArsenalPartShoulWorkCorrecly()
        {
            var part = new ArsenalPart("Gun", 100, 200, 150);
            var vehicle = new Revenger("SU-105", 1000.00, 20000, 100, 100, 100, assembler);
            vehicle.AddArsenalPart(part);

            var expectedValue = part.AttackModifier + vehicle.Attack;
            var actualValue = vehicle.TotalAttack;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void AddShellPartShoulWorkCorrecly()
        {
            var part = new ShellPart("Gun", 100, 200, 150);
            var vehicle = new Revenger("SU-105", 1000.00, 20000, 100, 100, 100, assembler);
            vehicle.AddShellPart(part);

            var expectedValue = part.DefenseModifier + vehicle.Defense;
            var actualValue = vehicle.TotalDefense;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void AddEndurancePartShoulWorkCorrecly()
        {
            var part = new EndurancePart("Gun", 100, 200, 150);
            var vehicle = new Revenger("SU-105", 1000.00, 20000, 100, 100, 100, assembler);
            vehicle.AddEndurancePart(part);

            var expectedValue = part.HitPointsModifier + vehicle.HitPoints;
            var actualValue = vehicle.TotalHitPoints;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void PartsShouldReturnCorrectParts()
        {
            var part = new EndurancePart("Gun", 100, 200, 150);
            var vehicle = new Revenger("SU-105", 1000.00, 20000, 100, 100, 100, assembler);
            vehicle.AddEndurancePart(part);

            var parts = vehicle.Parts;

            foreach (var item in parts)
            {
                Assert.AreSame(part, item);
            }
        }

        [Test]
        public void TotalWeightShouldReturnCorrectValue()
        {
            var part = new EndurancePart("Gun", 100, 200, 150);
            var vehicle = new Revenger("SU-105", 1000.00, 20000, 100, 100, 100, assembler);
            vehicle.AddEndurancePart(part);

            var expectedValue = part.Weight + vehicle.Weight;
            var actualValue = vehicle.TotalWeight;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void TotalPriceShouldReturnCorrectValue()
        {
            var part = new EndurancePart("Gun", 100, 200, 150);
            var vehicle = new Revenger("SU-105", 1000.00, 20000, 100, 100, 100, assembler);
            vehicle.AddEndurancePart(part);

            var expectedValue = part.Price + vehicle.Price;
            var actualValue = vehicle.TotalPrice;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void ToStringShouldReturnCorrectString()
        {
            var vehicle = new Revenger("SU-105", 1000.00, 20000, 100, 100, 100, assembler);
            var expectedValue = "Revenger - SU-105\r\n" +
                "Total Weight: 1000.000\r\n" +
                "Total Price: 20000.000\r\n" +
                "Attack: 100\r\n" +
                "Defense: 100\r\n" +
                "HitPoints: 100\r\n"+
                "Parts: "+
                "None";
            var actualValue = vehicle.ToString();

            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}