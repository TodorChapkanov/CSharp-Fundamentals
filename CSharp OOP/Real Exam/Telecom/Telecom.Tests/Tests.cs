namespace Telecom.Tests
{
    using NUnit.Framework;
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Constructor()
        {
            var phone = new Phone("Nokia", "A5");

            Assert.AreEqual("Nokia", phone.Make);
            Assert.AreEqual("A5", phone.Model);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void  MakeShouldThrowExceprionIfISNull(string test)
        {
            Assert.That(() => new Phone(test, "A5"),
                Throws.ArgumentException);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void ModelShouldThrowExceptionIfIsNull(string test)
        {
            Assert.That(() => new Phone("Nokia", test),
                Throws.ArgumentException);
        }

        [Test]
        public void CountShouldReturnProperValue()
        {
            var phone = new Phone("Nokia", "A5");
            phone.AddContact("Ivan", "1111");

            Assert.AreEqual(1, phone.Count);
        }

        [Test]
        public void AddContactShouldThrowException()
        {
            var phone = new Phone("Nokia", "A5");
            phone.AddContact("Ivan", "1111");

            Assert.That(() => phone.AddContact("Ivan", "1111"),
                Throws.InvalidOperationException);
        }

        [Test]
        public void CallingShouldWorkCorrect()
        {
            var phone = new Phone("Nokia", "A5");
            phone.AddContact("Ivan", "1111");

            var expectedValue = $"Calling Ivan - 1111...";
            var actualValue = phone.Call("Ivan");

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void CallingShouldRhtowException()
        {
            var phone = new Phone("Nokia", "A5");
            phone.AddContact("Ivan", "1111");



            Assert.That(() => phone.Call("PESHO"),
               Throws.InvalidOperationException);
        }
    }
}