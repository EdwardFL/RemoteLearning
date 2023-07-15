using HashtableImplementation;
using System;
using Xunit;

namespace HashtableUnitTests
{
    public class HashtableTest
    {
        [Fact]
        public void HavingAStringHashtable_WhenTheNumberOfItemsIsSet_ThenCompareItWithExpectedCountValue()
        {
            int actual = 2;
            BasicHashTable<string, string> stringHashtable = new BasicHashTable<string, string>(5);
            stringHashtable.Put("doi", "unu");
            stringHashtable.Put("trei", "unu");

            int expected = stringHashtable.Count();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void HavingAStringHashtable_WhenTheValueForTheAddedKeyValuePairIsSet_ThenCompareItWithExpectedValue()
        {
            string actual = "unu";
            BasicHashTable<string, string> stringHashtable = new BasicHashTable<string, string>(1);
            stringHashtable.Put("doi", "unu");

            string expected = stringHashtable.Get("doi");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void HavingAnIntHashtable_WhenTheValueForAddedKeyValuePairIsSet_ThenCompareItWithExpectedValue()
        {
            int actual = 100;
            BasicHashTable<int, int> intHashtable = new BasicHashTable<int, int>(1);
            intHashtable.Put(1, 100);

            int expected = intHashtable.Get(1);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void HavingAStringHashtable_WhenTheValueForAddedKeyValuePairIsSetAndTwoKeysAreAtTheSamePosition_ThenCompareItWithExpectedValue()
        {
            string actual = "unu";
            BasicHashTable<string, string> stringHashtable = new BasicHashTable<string, string>(2);
            stringHashtable.Put("doi", "unu");
            stringHashtable.Put("trei", "unu");
            stringHashtable.Put("patru", "unu");
            stringHashtable.Put("unu", "unu");

            string expected = stringHashtable.Get("patru");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void HavingAnEmptyStringHashtable_WhenGetMethodResultIsSet_ThenCompareItWithExpectedValue()
        {
            string actual = null;
            BasicHashTable<string, string> stringHashtable = new BasicHashTable<string, string>(1);

            string expected = stringHashtable.Get("doi");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void HavingAStringHashtable_WhenContainsKeyMethodResultIsSet_ThenCompareItWithExpectedValue()
        {
            bool actual = true;
            BasicHashTable<string, string> stringHashtable = new BasicHashTable<string, string>(2);
            stringHashtable.Put("doi", "unu");

            bool expected = stringHashtable.ContainsKey("doi");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void HavingAStringHashtable_WhenContainsKeyMethodResultIsSetAndTwoKeysAreAtTheSamePosition_ThenCompareItWithExpectedValue()
        {
            bool actual = true;
            BasicHashTable<string, string> stringHashtable = new BasicHashTable<string, string>(2);
            stringHashtable.Put("doi", "unu");
            stringHashtable.Put("trei", "unu");
            stringHashtable.Put("patru", "unu");
            stringHashtable.Put("unu", "unu");

            bool expected = stringHashtable.ContainsKey("doi");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void HavingAnEmptyStringHashtable_WhenContainsKeyMethodResultIsSet_ThenCompareItWithExpectedValue()
        {
            bool actual = false;
            BasicHashTable<string, string> stringHashtable = new BasicHashTable<string, string>(1);

            bool expected = stringHashtable.ContainsKey("doi");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void HavingAStringHashtable_WhenRemoveMethodIsCalledAndContainsKeyMethodResultIsSet_ThenCompareItWithExpectedValue()
        {
            bool actual = false;
            BasicHashTable<string, string> stringHashtable = new BasicHashTable<string, string>(1);
            stringHashtable.Put("doi", "unu");
            stringHashtable.Remove("doi");

            bool expected = stringHashtable.ContainsKey("cinci");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void HavingAStringHashtable_WhenRemoveMethodIsCalledAndTwoKeysAreAtTheSamePosition_ThenCompareItWithExpectedValue()
        {
            bool actual = false;
            BasicHashTable<string, string> stringHashtable = new BasicHashTable<string, string>(1);
            stringHashtable.Put("doi", "unu");
            stringHashtable.Put("trei", "unu");
            stringHashtable.Put("patru", "unu");
            stringHashtable.Put("cinci", "unu");
            stringHashtable.Remove("cinci");
            stringHashtable.Remove("doi");

            bool expected = stringHashtable.ContainsKey("cinci");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void HavingAStringHashtable_WhenGetMethodIsCalledWithANullKey_ThenThrowsArgumentNullException()
        {
            BasicHashTable<string, string> stringHashtable = new BasicHashTable<string, string>(1);

            Assert.Throws<ArgumentNullException>(() =>
            {
                stringHashtable.Get(null);
            });
        }

        [Fact]
        public void HavingAStringHashtable_WhenGetHashMethodIsCalledWithANullKey_ThenThrowsArgumentNullException()
        {
            BasicHashTable<string, string> stringHashtable = new BasicHashTable<string, string>(1);

            Assert.Throws<ArgumentNullException>(() =>
            {
                stringHashtable.GetHash(null);
            });
        }

        [Fact]
        public void HavingAStringHashtable_WhenAddingAnItemWithANullKey_ThenThrowsArgumentNullException()
        {
            BasicHashTable<string, string> stringHashtable = new BasicHashTable<string, string>(1);

            Assert.Throws<ArgumentNullException>(() =>
            {
                stringHashtable.Put(null, "test");
            });
        }

        [Fact]
        public void HavingAStringHashtable_WhenContainsKeyMethodIsCalledWithANullKey_ThenThrowsArgumentNullException()
        {
            BasicHashTable<string, string> stringHashtable = new BasicHashTable<string, string>(1);

            Assert.Throws<ArgumentNullException>(() =>
            {
                stringHashtable.ContainsKey(null);
            });
        }

        [Fact]
        public void HavingAStringHashtable_WhenRemoveIsCalledWithANullKey_ThenThrowsArgumentNullException()
        {
            BasicHashTable<string, string> stringHashtable = new BasicHashTable<string, string>(1);

            Assert.Throws<ArgumentNullException>(() =>
            {
                stringHashtable.Remove(null);
            });
        }
    }
}