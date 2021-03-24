using System;
using System.Text;
using List;
using NUnit.Framework;


namespace ArrayListTests
{
    class LinkedListTests
    {
        [TestCase(8, new int[] { 1, 4, 5 }, new int[] { 8, 1, 4, 5 })]
        public void AddAtTheBeginingTests(int value, int[]actualLinked, int[]expectedLinked)
        {
            LinkedList actual = new LinkedList(actualLinked);
            LinkedList expected = new LinkedList(expectedLinked);
            actual.AddAtTheBegining(value);
            Assert.AreEqual(expected, actual);
        }
    }
}
