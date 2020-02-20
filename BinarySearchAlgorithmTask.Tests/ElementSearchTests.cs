using System;
using System.Collections.Generic;
using Notebook;
using NUnit.Framework;
using static BinarySearchAlgorithmTask.ElementSearch;

namespace BinarySearchAlgorithmTask.Tests
{
    [TestFixture]
    public class ElementSearchTests
    {
        private static IEnumerable<TestCaseData> DataCases
        {
            get
            {
                yield return new TestCaseData(new Note[] { new Note("Albahari", "test"), new Note("Skeet", "test"), new Note("Troelsen", "test") }, new Note("Skeet", "qwe")).Returns(1);
                yield return new TestCaseData(new Note[] { new Note("A", "test"), new Note("B", "test"), new Note("C", "test"), new Note("D", "test") }, new Note("C", "qwe")).Returns(2);
            }
        }

        [Test]
        public void BinarySearch_ComparerIsNull_ThrowArgumentNullException()
        {
            IComparer<int> comparer = null;
            Assert.Throws<ArgumentNullException>(() => BinarySearch(new int[] { 1, 2 }, 1, comparer));
        }

        [Test]
        public void BinarySearch_UnorderedArray_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => BinarySearch(new int[] { 1, 3, 3, 5, 6, 11, 13, 16, -2, 22 }, 1, Comparer<int>.Default));

        [TestCase(new[] { 1, 3, 3, 5, 6, 11, 13, 16 }, 11, ExpectedResult = 5)]
        [TestCase(new int[] { 14, 22, 30, 45, 45, 94, 120 }, 88, ExpectedResult = -1)]
        [TestCase(new[] { 1, 2, 3, 4, 5, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 25 }, 8, ExpectedResult = 8)]
        public int BinarySearch_Integer_Tests(int[] source, int item)
        {
            return BinarySearch(source, item, Comparer<int>.Default);
        }

        [TestCaseSource(nameof(DataCases))]
        public int BinarySearch_Note_Tests(Note[] notes, Note item)
        {
            return BinarySearch(notes, item, new NoteComparer());
        }
    }
}