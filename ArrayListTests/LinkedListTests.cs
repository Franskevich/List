using System;
using System.Text;
using List;
using NUnit.Framework;


namespace ArrayListTests
{
    class LinkedListTests
    {       
        //1
        [TestCase(8, new int[] { 1, 4, 5 }, new int[] { 1, 4, 5, 8 })]
        public void AddAtTheEndTests(int value, int[] actualLinked, int[] expectedLinked)
        {
            LinkedList actual = new LinkedList(actualLinked);
            LinkedList expected = new LinkedList(expectedLinked);
            actual.AddAtTheEnd(value);
            Assert.AreEqual(expected, actual);
        }    

        //2
        [TestCase(8, new int[] { 1, 4, 5 }, new int[] { 8, 1, 4, 5 })]
        public void AddAtTheBeginingTests(int value, int[] actualLinked, int[] expectedLinked)
        {
            LinkedList actual = new LinkedList(actualLinked);
            LinkedList expected = new LinkedList(expectedLinked);
            actual.AddAtTheBegining(value);
            Assert.AreEqual(expected, actual);
        }

        //3
        [TestCase(8, 1, new int[] { 1, 4, 5 }, new int[] { 1, 8, 4, 5 })]
        public void AddValueByIndexTEst(int value, int index, int[]actualLinked, int[]expectedLinked)
        {
            LinkedList actual = new LinkedList(actualLinked);
            LinkedList expected = new LinkedList(expectedLinked);
            actual.AddValueByIndex(value, index);
            Assert.AreEqual(expected, actual);
        }

        ////4
        [TestCase(new int[] { 1, 4, 5, 8 }, new int[] { 1, 4, 5 })]
        public void RemoveLastTests(int[] actualLinked, int[] expectedLinked)
        {
            LinkedList actual = new LinkedList(actualLinked);
            LinkedList expected = new LinkedList(expectedLinked);
            actual.RemoveLast();
            Assert.AreEqual(expected, actual);
        }

        //5
        [TestCase(new int[] { 1, 4, 5, 8 }, new int[] { 4, 5, 8 })]
        public void RemoveFirstTests(int[] actualLinked, int[] expectedLinked)
        {
            LinkedList actual = new LinkedList(actualLinked);
            LinkedList expected = new LinkedList(expectedLinked);
            actual.RemoveFirst();
            Assert.AreEqual(expected, actual);
        }

        //6
        [TestCase(3, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 4 })]
        public void RemoveByIndexTests(int index, int[] actualLinked, int[] expectedLinked)
        {
            LinkedList actual = new LinkedList(actualLinked);
            LinkedList expected = new LinkedList(expectedLinked);
            actual.RemoveByIndex(index);
            Assert.AreEqual(expected, actual);
        }

        //11 private
        //[TestCase(1, new int[] { 5, 4, 6, 7 }, 4)]
        //public void GetNodeByIndexTests(int index, int[] actualLinked, int expected)
        //{
        //    LinkedList actual = new LinkedList(actualLinked);
        //    Node a = actual.GetNodeByIndex(index);
        //    Assert.AreEqual(expected, a.Value);
        //}

        //7
        [TestCase(3, new int[] { 1, 2, 3, 4, 7, 9 }, new int[] { 1, 2, 3 })]
        public void RemoveLastElementsTests(int n, int[] actualLinked, int[] expectedLinked)
        {
            LinkedList actual = new LinkedList(actualLinked);
            LinkedList expected = new LinkedList(expectedLinked);
            actual.RemoveLastElements(n);
            Assert.AreEqual(expected, actual);
        }

        //8
        [TestCase(3, new int[] { 1, 2, 3, 4, 7, 9 }, new int[] { 4, 7, 9 })]
        public void RemoveFromTheBeginningNElementsTests(int n, int[]actualLinked, int[]expectedLinked)
        {
            LinkedList actual = new LinkedList(actualLinked);
            LinkedList expected = new LinkedList(expectedLinked);
            actual.RemoveFromTheBeginningNElements(n);
            Assert.AreEqual(expected, actual);
        }

        //9
        [TestCase(2,2, new int[] { 1, 2, 3, 4, 7, 9 }, new int[] { 1, 2, 7, 9 })]
        public void RemoveByIndexNElementsTests(int index, int n, int[] actualLinked, int[] expectedLinked)
        {
            LinkedList actual = new LinkedList(actualLinked);
            LinkedList expected = new LinkedList(expectedLinked);
            actual.RemoveByIndexNElements(index, n);
            Assert.AreEqual(expected, actual);
        }
        //14
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 4, 3, 2, 1 })]
        public void ReverseTests(int[] actualLinked, int[] expectedLinked)
        {
            LinkedList actual = new LinkedList(actualLinked);
            LinkedList expected = new LinkedList(expectedLinked);
            actual.Reverse();
            Assert.AreEqual(expected, actual);
        }
    }
}
