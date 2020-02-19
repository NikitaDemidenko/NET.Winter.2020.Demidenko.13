using System;
using NUnit.Framework;
using System.Collections.Generic;
using static FlaviusJosephusTask.JosephusGame;

namespace FlaviusJosephusTask.Tests
{
    public class JosephusTests
    {
        [Test]
        public void Josephus_InvalidCount_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => Josephus(0, 23));

        [Test]
        public void Josephus_InvalidK_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => Josephus(10, 0));

        [TestCase(1, 1000000, ExpectedResult = new [] { 1 })]
        [TestCase(3, 6, ExpectedResult = new[] { 3, 2, 1 })]
        [TestCase(7, 2, ExpectedResult = new[] { 2, 4, 6, 1, 5, 3, 7 })]
        [TestCase(10, 6, ExpectedResult = new[] { 6, 2, 9, 7, 5, 8, 1, 10, 4, 3 })]
        public IEnumerable<int> Josephus_Tests(int count, int k)
        {
            return Josephus(count, k);
        }

        [TestCase(66, 1, ExpectedResult = 66)]
        [TestCase(1000, 123, ExpectedResult = 2)]
        [TestCase(1000, 1000, ExpectedResult = 609)]
        [TestCase(10000, 3, ExpectedResult = 2692)]
        public int Josephus_LastPersonToSurviveTests(int count, int k)
        {
            var list = new List<int>(Josephus(count, k));
            return list[^1];
        }
    }
}