using List;
using NUnit.Framework;


namespace ArrayListTests
{
    public class Tests
    {

        //[TestCase(5, new int[] { 1, 4 })]
        //public void AddFirst(int value, int[] expectedArray)
        //{
        //    ArrayList expected = new ArrayList(expectedArray);
        //    ArrayList actual = new ArrayList();
        //    actual.AddFirst(value);


        //    Assert.AreEqual(expected, actual);
        //}

        [Test]
        public void AddFirst()
        {
            ArrayList expected = new ArrayList();
            expected.Add(2);
            expected.Add(6);
            expected.Add(77);
            expected.Add(3);
            expected.Add(6);
            expected.Add(3);
            expected.Add(3);
            expected.Add(-5);
            expected.Add(3);
            expected.Add(3);
            expected.Add(2);

            expected.RemoveByIndexNElements(3,5);

        }

        [TestCase(3, new int[] { 2, 6, 77 }, new int[] { 2, 6, 77, 3 })]
        public void RemoveByIndexTests(int index, int[] expectedArray, int[] actualArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.RemoveByIndex(index);
            Assert.AreEqual(expected, actual);
        }

        //[Test]
        //public void AddFirst();
        //{
        //    Assert.AreEqual(excepted, actual)
        //}


        [TestCase(3, 5, new int[] { 2, 6, 77, 3, 3, 2 }, new int[] { 2, 6, 77, 3, 6, 3, 3, -5, 3, 3, 2 })]
        public void RemoveByIndexNElementsTests(int index, int n, int[] expectedArray, int[] actualArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.RemoveByIndexNElements(index, n);
            Assert.AreEqual(expected, actual);
        }
    }
}