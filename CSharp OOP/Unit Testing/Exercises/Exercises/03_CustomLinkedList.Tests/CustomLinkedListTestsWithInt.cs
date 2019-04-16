namespace _03_CustomLinkedList.Tests
{
    using CustomLinkedList;
    using NUnit.Framework;
    using System;
    using System.Reflection;

    [TestFixture]
    public class CustomLinkedListTestsWithInt
    {
        DynamicList<int> dynamicList;
        [SetUp]
        public void SetUp()
        {
            dynamicList = new DynamicList<int>();

            dynamicList.Add(0);
            dynamicList.Add(1);
            dynamicList.Add(2);
        }

        [Test]
        public void TestConstructor()
        {
            var errorMessage = "Constructor is create instance of Dynamic List";
            var expectedValueOfCount = 3;

            Assert.AreEqual(expectedValueOfCount, dynamicList.Count, errorMessage);
        }

        [Test]
        public void CountShouldReturnCotrrectValue()
        {
            var errorMessage = "Count return({0}) when items in dynamcList are {1}";
            var expectedValue = 3;
            var actualValue = dynamicList.Count;

            Assert.AreEqual(expectedValue, actualValue, string.Format(errorMessage, actualValue, expectedValue));
        }

        [Test]
        public void ContainsMethodShouldReturnTrueIfItemExistInDynamicList()
        {
            var errorMessage = "Contains method not return proper result when item is in dynamicList";
            var item = 1;
            Assert.IsTrue(dynamicList.Contains(item), errorMessage);
        }

        [Test]
        public void ContainsMethodShouldReturFalseIfItemIsNotInDynamicList()
        {
            var errorMessage = "Contains method return different result form false when item value is {0}";
            var item = -10;
            Assert.IsFalse(dynamicList.Contains(item), string.Format(errorMessage, item));
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void IndexOfShouldReturnCorrectIndexonExistingItem(int item)
        {
            var errorMessage = "IndexOf return index({0}) when shoulde return index({1})";
            var expectedIndex = item;
            var actualIndex = dynamicList.IndexOf(item);

            Assert.AreEqual(expectedIndex , actualIndex, string.Format(errorMessage, actualIndex, expectedIndex));
        }

        [TestCase(10)]
        [TestCase(-50)]
        [TestCase(899)]
        public void IndexOfShouldReturnNegativeIntegerIfItemIsNotFound(int item)
        {
            var errorMessage = "IndexOf method should return -1 but return {0}";

            var expectedValue = -1;
            var actualValue = dynamicList.IndexOf(item);

            Assert.AreEqual(expectedValue, actualValue, string.Format(errorMessage, actualValue));
        }

        [TestCase(int.MinValue)]
        [TestCase(15)]
        [TestCase(int.MaxValue)]
        public void AddShouldWorkProperly(int value)
        {
            var errorMessage = "Add method is not record correct value in dynamic list!";

            dynamicList.Add(value);

            var expectedValue = 4;
            var actualValue = dynamicList.Count;
            Assert.AreEqual(expectedValue, actualValue, errorMessage);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void TestIndexerShouldeGetCorrectValue(int index)
        {
            var errorMessage = "Indexer is return different from correct value{0}";


            var expectedValue = index;
            var actualValue = dynamicList[index];
            Assert.AreEqual(expectedValue, actualValue, string.Format(errorMessage, index));
        }

        [TestCase(-1)]
        [TestCase(10)]
        public void IndexerShouldThrowExceprionIfGetIncorrecIndex(int index)
        {
            var errorMessage = "Indexer not throw proper exception when index is out of range!";


            Assert.That(() => dynamicList[index],
                Throws.InstanceOf<ArgumentOutOfRangeException>()
                , errorMessage);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void IndexerShouldSetValueIfIndexIsValid(int index)
        {
            var errorMessage = "Indexer not set value{0} on index{1}";
            var value = 999;
            dynamicList[index] = value;

            var expectedValue = value;
            var actualValue = dynamicList[index];

            Assert.AreEqual(expectedValue, actualValue, string.Format(errorMessage, value, index));
        }

        [TestCase(-1)]
        [TestCase(15)]
        public void IndexerShouldThrowExceptionIfIndexToSetIsOutOfRange(int index)
        {
            var errorMessage = "Indexer not throw exception when index value is {0}";
            var value = 100;

            Assert.That(() => dynamicList[index] = value,
                Throws.InstanceOf<ArgumentOutOfRangeException>(),
                string.Format(errorMessage, index));
        }

        [Test]
        public void RemoveAtIndexMethodShouldRemoveItemAtCorrectIndex()
        {
            var errorMessage = "RemoveAt index method is not remove item on current index";
            dynamicList.Add(50);
            dynamicList.RemoveAt(2);

            var expectedValue = 50;
            var actualValue = dynamicList[2];
            Assert.AreEqual(expectedValue, actualValue, errorMessage);
        }

        [TestCase(-1)]
        [TestCase(20)]
        public void RemoveAtIndexMethodShoulrThrowExceptionWhenIndexIsOutOfRange(int index)
        {
            var errorMessage = "RemoveAt index method is not throw exception when index is {0}";

            Assert.That(() => dynamicList.RemoveAt(index),
                Throws.InstanceOf<ArgumentOutOfRangeException>(),
                string.Format(errorMessage, index));
        }

        [TestCase(1)]
        [TestCase(2)]
        public void RemoveMethodShouldRemoveOneExistingItem(int item)
        {
            var errorMessage = "Remove method not remove item with value{0} which exist in dynamicList";


            dynamicList.Remove(item);

            Assert.IsFalse(dynamicList.Contains(item), string.Format(errorMessage, item));
        }

        [Test]
        public void RemoveMethodShouldReturnIndexOfRemovedItem()
        {
            var errorMessage = "Remove method should return expected index({0}) bur return {1} index!";
            var itemToRemove = 2;
            var indexOfItemToRemove = dynamicList.IndexOf(itemToRemove);

            var actualIndex = dynamicList.Remove(itemToRemove);

            Assert.AreEqual(indexOfItemToRemove, actualIndex, 
                string.Format(errorMessage, indexOfItemToRemove, actualIndex));

        }

        [Test]
        public void RemoveMethodShoulrReturnNegativeIntegerIfItemNotExist()
        {
            var errorMessage = "Remove method not retrn -1 when item not exist in dynamicList";
            var item = 4;
            var expectedValue = -1;
            var actualValue = dynamicList.Remove(item);


            Assert.AreEqual(expectedValue, actualValue, errorMessage);
        }
    }
}
