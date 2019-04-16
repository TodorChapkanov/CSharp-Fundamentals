namespace _01_Database.Tests
{
    using _01_Database.Models;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        public const int DefaultDatabaseLength = 16;
        public Database database;

        [Test]
        public void TestConstructorWithValidParameter()
        {
            var paremeters = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };

            database = new Database(paremeters);

            for (int i = paremeters.Length - 1; i >= 0; i--)
            {
                var errorMessage = "Initial insert from constructor is wrong";
                var expectedNumber = paremeters[i];
                var actualNumber = database.Remove();
                Assert.AreEqual(expectedNumber, actualNumber, errorMessage);
            }
        }

        [Test]
        public void TestConstructorWithMoreNumbersThanDefaultDatebaseLength()
        {
            var parameters = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };

            var erroeMessage = "Constructor not throw exception with more numbers than database length";
            Assert.That(() => database = new Database(parameters)
            , Throws.InvalidOperationException
                .With
                .Message
                .EqualTo(string.Format($"Canot add more than {DefaultDatabaseLength} numbers in Database")),
                erroeMessage);
        }

        [Test]
        public void TestAddMethodInValidState()
        {
            var errorMessage = "Add method is not adding elements properly";
            database = new Database();

            database.Add(10);
            var expecterNumber = 10;
            var actualNumber = database.Remove();

            Assert.AreEqual(expecterNumber, actualNumber, errorMessage);
        }

        [Test]
        public void TestAddMethodShouldThrowExceptionIfAddElementInFullDatabase()
        {
            var errorMessage = "Add method not throw exception after adding overflow number";
            var data = new int[DefaultDatabaseLength];
            database = new Database(data);

            Assert.That(() => database.Add(10),
                Throws.InvalidOperationException
                .With
                .Message
                .EqualTo($"Canot add more than {DefaultDatabaseLength} numbers in Database")
                , errorMessage);
        }

        [Test]
        public void TestRemoveMethodWithElementsInDatabase()
        {
            var errorMessage = "Remove method is not delete number from database";
            var arguments = new int[] { 1, 2, 3 };
            database = new Database(arguments);

            database.Remove();

            var expectedValue = arguments.Length - 1;
            var actualValue = database.Fetch;
            Assert.AreEqual(expectedValue, actualValue.Length,errorMessage);
        }

        [Test]
        public void TestRemoveMetodShouldRemoveLastElementFromDatabase()
        {
            var errorMessage = "Reomve method do not remove last element form database";
            var arguments = new int[] { 1, 2, 3 };
            database = new Database(arguments);

            var expectedVaue = arguments[arguments.Length - 1];
            var actualValu = database.Remove();

            Assert.AreEqual(expectedVaue, actualValu, errorMessage);
        }

        [Test]
        public void TestRemoveMethodShouldThrowExceptionWithEmptyDatabase()
        {
            var errorMessage = "Remove method not throw exception after try to remove element from empty database";
            database = new Database();

            Assert.That(() => database.Remove(), Throws.InvalidOperationException
                .With
                .Message
                .EqualTo("DataBase is empty"),
                errorMessage);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5})]
        [TestCase(new int[] { int.MinValue, 10, 100 ,-50, int.MaxValue})]
        public void TestFetchMethodShouldReturnProperValues(int[] parameters)
        {
            var errorMessage = "Fetch method do not return proper values";
            database = new Database(parameters);

            var actualrResult = database.Fetch;

            Assert.AreEqual(parameters, actualrResult, errorMessage);
        }
    }
}
