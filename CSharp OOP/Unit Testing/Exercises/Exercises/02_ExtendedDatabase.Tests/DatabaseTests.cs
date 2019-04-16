namespace _02_ExtendedDatabase.Tests
{
    using System;
    using NUnit.Framework;

    using _02_ExtendedDatabase.Models;
    using _02_ExtendedDatabase.Models.Contracts;

    [TestFixture]
    public class DatabaseTests
    {
        public IPerson[] peopleForTest;
        public Database database;

        [SetUp]
        public void SetUp()
        {
            peopleForTest = new IPerson[]
           {
                new Person(1, "Jon"),
                new Person(2, "Mark"),
                new Person(3, "Ron")
           };

            database = new Database(peopleForTest);
        }
        [Test]
        public void TestConstructor()
        {
            var errorMessage = "Constructor is not set properly";
            for (int i = 0; i < peopleForTest.Length; i++)
            {
                var expectedValue = peopleForTest[i];
                var actualrValue = database[i];

                Assert.AreEqual(expectedValue, actualrValue, errorMessage);
            }
        }

        [Test]
        public void TestAddMethodWithProperPerson()
        {
            var errorMessage = "Add method not record person in database";
            var perso = new Person(4, "Josh");

            database.Add(perso);

            Assert.AreEqual(perso, database[3], errorMessage);
        }

        [Test]
        public void TestAddMethodWithExistingUsernameMustThrowException()
        {
            var person = new Person(7, "Jon");

            Assert.That(() => database.Add(person),
                Throws.InvalidOperationException);
        }

        [Test]
        public void TestAddMethodWithExistingPersonIdMustThrowException()
        {
            var person = new Person(3, "Toni");

            Assert.That(() => database.Add(person),
                Throws.InvalidOperationException);
        }

        [Test]
        public void TestRemoveMethodWithExistingPerson()
        {
            var errorMessage = "Remove method is not remove element!";
            var personToRemove = peopleForTest[1];
            database.Remove(personToRemove);

            var expectedValue = database.Count;
            var actualValue = peopleForTest.Length - 1;

            Assert.AreEqual(expectedValue, actualValue, errorMessage);
        }

        [Test]
        public void TestRamoveMethodShouldThrowExceptionIfNotContainPerson()
        {
            var person = new Person(10, "Mik");

            Assert.That(() => database.Remove(person),
                Throws.InvalidOperationException);
        }

        [Test]
        public void TestRemoveMethodShouldThrowExeptinIfIsCalledOverEmptyDatabase()
        {
            this.database = new Database();
            var perso = peopleForTest[0];

            Assert.That(() => database.Remove(perso),
                Throws.InvalidOperationException);
        }

        [TestCase("Jon")]
        [TestCase("Mark")]
        public void TestFindByUsernameMethodShouldWorkProperly(string username)
        {
            var errorMessage = "Find method with username in not return proper person";

            var expectedValue = username;
            var actualValue = database.FindByUsername(username).Name;

            Assert.AreEqual(expectedValue, actualValue, errorMessage);
        }

        [Test]
        public void TestFindByUsernameMethodshouldThrowExceptionIfUsernameIsNull()
        {
            var errorMessage = "Find by username not throw proper exception when username iz null";
            string username = null;

            Assert.That(() => database.FindByUsername(username),
            Throws.ArgumentNullException,
            errorMessage);
        }

        [Test]
        public void TestFindByUsernameMethodShouldThrowExceptionWhenUsernameIsNotFound()
        {
            var errorMessage = "Finde by username method in not throw proper exception";
            var username = "Stamat";

            Assert.That(() => database.FindByUsername(username),
                Throws.InvalidOperationException,
                errorMessage);
        }

        [Test]
        public void TestFindByIdMethodShouldReturnPersonWhenUsernameIsCorrect()
        {
            var errorMessage = "Finde by id method is not return correct person {0}";
            var expectedPersonId = peopleForTest[0].Id;
            var actualPersonId = database.FindById(expectedPersonId).Id;

            Assert.AreEqual(expectedPersonId, actualPersonId, string.Format(errorMessage, expectedPersonId));
        }

        [Test]
        public void TestFindByIdMethodShouldThrowExceptionWhenIdIsNegative()
        {
            var errorMessage = "Finde by id method not throw proper exception when id is negative";
            var negativeId = long.MinValue;

            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(negativeId), errorMessage);
        }

        [Test]
        public void TestFindByIdMethodShouldThrowExceptionIfIdIsNotFound()
        {
            var errorMessage = "Finde by id method not throw proper exception when not contain id{0}";
            var personId = long.MaxValue;

            Assert.That(() => database.FindById(personId),
                Throws.InvalidOperationException,
                string.Format(errorMessage, personId));
        }
    }
}
