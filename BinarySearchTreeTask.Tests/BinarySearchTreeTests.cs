using System;
using NUnit.Framework;
using BinarySearchTreeTask;
using Moq;
using System.Collections.Generic;
using Notebook;

namespace BinarySearchTreeTask.Tests
{
    public class BinarySearchTreeTests
    {
        private Mock<IComparer<int>> mockIntComparer;
        private IComparer<int> intCustomComparer;

        private Mock<IComparer<string>> mockStringComparer;
        private IComparer<string> stringCustomComparer;

        private Mock<IComparer<Note>> mockNoteComparer;
        private IComparer<Note> noteCustomComparer;

        private Mock<IComparer<Point>> mockPointComparer;
        private IComparer<Point> pointCustomComparer;

        [SetUp]
        public void Setup()
        {
            mockIntComparer = new Mock<IComparer<int>>();

            mockIntComparer
                .Setup(c => c.Compare(It.IsAny<int>(), It.IsAny<int>()))
                .Returns((int x, int y) => -1 * x.CompareTo(y));

            intCustomComparer = mockIntComparer.Object;

            mockStringComparer = new Mock<IComparer<string>>();

            mockStringComparer
                .Setup(c => c.Compare(It.IsAny<string>(), It.IsAny<string>()))
                .Returns((string left, string right) => left.Length.CompareTo(right.Length));

            stringCustomComparer = mockStringComparer.Object;

            mockNoteComparer = new Mock<IComparer<Note>>();

            mockNoteComparer
                .Setup(c => c.Compare(It.IsAny<Note>(), It.IsAny<Note>()))
                .Returns((Note left, Note right) => left.Content.CompareTo(right.Content));

            noteCustomComparer = mockNoteComparer.Object;

            mockPointComparer = new Mock<IComparer<Point>>();

            mockPointComparer
                .Setup(c => c.Compare(It.IsAny<Point>(), It.IsAny<Point>()))
                .Returns((Point first, Point second) => (first.X + first.Y).CompareTo(second.X + second.Y));

            pointCustomComparer = mockPointComparer.Object;
        }

        [Test]
        public void IntegerTree_DefaultComparer()
        {
            var numbers = new int[] { 6, 23, 1, -23, 45, 15, 8 };
            var tree = new BinarySearchTree<int>(numbers);
            Assert.IsTrue(tree.Contains(-23));
            Assert.IsTrue(tree.Contains(15));
            Assert.IsFalse(tree.Contains(99));

            var expected = new int[] { -23, 1, 6, 8, 15, 23, 45 };
            var actual = tree.InorderTraversal();
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void IntegerTree_CustomComparer()
        {
            var numbers = new int[] { 6, 23, 1, -23, 45, 15, 8 };
            var tree = new BinarySearchTree<int>(numbers, intCustomComparer);
            Assert.IsTrue(tree.Contains(-23));
            Assert.IsTrue(tree.Contains(15));
            Assert.IsFalse(tree.Contains(99));

            var expected = new int[] { 45, 23, 15, 8, 6, 1, -23 };
            var actual = tree.InorderTraversal();
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void StringTree_DefaultComparer()
        {
            var strings = new string[] { "g", "h", "b", "z", "a", "c" };
            var tree = new BinarySearchTree<string>(strings);
            Assert.IsTrue(tree.Contains("z"));
            Assert.IsTrue(tree.Contains("h"));
            Assert.IsFalse(tree.Contains("q"));

            var expected = new string[] { "a", "b", "c", "g", "h", "z" };
            var actual = tree.InorderTraversal();
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void StringTree_CustomComparer()
        {
            var strings = new string[] { "qwerty", "h", "bbbbbbbbbb", "zz", "aaa", "cccc" };
            var tree = new BinarySearchTree<string>(strings, stringCustomComparer);

            var expected = new string[] { "h", "zz", "aaa", "cccc", "qwerty", "bbbbbbbbbb" };
            var actual = tree.InorderTraversal();
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void NoteTree_DefaultComparer()
        {
            var notes = new Note[] { new Note("Troelsen", "test"), new Note("Skeet", "test"), new Note("Albahari", "test"), new Note("A", "test"), new Note("B", "test"), new Note("C", "test"), new Note("D", "test") };
            var tree = new BinarySearchTree<Note>(notes);
            Assert.IsTrue(tree.Contains(new Note("Albahari", "test")));
            Assert.IsFalse(tree.Contains(new Note("Schildt", "test")));

            var expected = new Note[] { new Note("A", "test"), new Note("Albahari", "test"), new Note("B", "test"), new Note("C", "test"), new Note("D", "test"), new Note("Skeet", "test"), new Note("Troelsen", "test") };
            var actual = tree.InorderTraversal();
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void NoteTree_CustomComparer()
        {
            var notes = new Note[] { new Note("Troelsen", "test6"), new Note("Skeet", "test4"), new Note("Albahari", "test8"), new Note("A", "test1"), new Note("B", "test3"), new Note("C", "test9"), new Note("D", "test0") };
            var tree = new BinarySearchTree<Note>(notes, noteCustomComparer);

            var expected = new Note[] { new Note("D", "test0"), new Note("A", "test1"), new Note("B", "test3"), new Note("Skeet", "test4"), new Note("Troelsen", "test6"), new Note("Albahari", "test8"), new Note("C", "test9") };
            var actual = tree.InorderTraversal();
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void PointTree_CustomComparer()
        {
            var points = new Point[] { new Point(5, 5), new Point(1, 1), new Point(-4, 7), new Point(2, 2), new Point(6, 8) };
            var tree = new BinarySearchTree<Point>(points, pointCustomComparer);

            Assert.IsTrue(tree.Contains(new Point(6, 8)));
            Assert.IsTrue(tree.Contains(new Point(0, 4)));
            Assert.IsFalse(tree.Contains(new Point(13, 2)));

            var expected = new Point[] { new Point(1, 1), new Point(-4, 7), new Point(2, 2), new Point(5, 5), new Point(6, 8) };
            var actual = tree.InorderTraversal();
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}