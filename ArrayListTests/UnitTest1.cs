using List;
using NUnit.Framework;


namespace ArrayListTests
{
    public class Tests
    {

        //1
        [TestCase(8, new int[] { 1, 4, 5 }, new int[] { 1, 4, 5, 8 })]
        public void AddLastTests(int value, int[] actualArray, int[] expectedArray)
        {

            ArrayList actual = new ArrayList(actualArray); 
            ArrayList expected = new ArrayList(expectedArray);           
            actual.AddLast(value);
            Assert.AreEqual(expected, actual);
        }

        //2
        [TestCase(5, new int[] { 1, 4, 5 }, new int[] { 5, 1, 4, 5 })]
        public void AddFirstTests(int value, int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList expected = new ArrayList(expectedArray);            
            actual.AddFirst(value);
            Assert.AreEqual(expected, actual);
        }

        //3
        [TestCase(25, 3, new int[] { 8, 1, 4, 5 }, new int[] { 8, 1, 4, 25, 5 })]
        public void AddValueByIndexTests(int value, int index, int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList expected = new ArrayList(expectedArray);
            actual.AddValueByIndex(value, index);

            Assert.AreEqual(expected, actual);
        }

        //
        //[TestCase(2, new int[] { 1, 2, 0, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        //public void MoveByIndexTests(int index, int[] expectedArray, int[] actualArray)
        //{
        //    ArrayList expected = new ArrayList(expectedArray);
        //    ArrayList actual = new ArrayList(actualArray);
        //    actual.MoveByIndex(index);
        //    Assert.AreEqual(expected, actual);
        //}

        //4
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 4, 6, 7, 9, 4 }, new int[] { 4, 6, 7, 9 })]
        public void RemoveLastTests(int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList expected = new ArrayList(expectedArray);           
            actual.RemoveLast();
            Assert.AreEqual(expected, actual);
        }
        //5
        [TestCase(new int[] { 4, 6, 7, 9 }, new int[] { 6, 7, 9 })]
        public void RemoveFirstTests(int[] actualArray, int[] expectedArray)
        {           
            ArrayList actual = new ArrayList(actualArray);
            ArrayList expected = new ArrayList(expectedArray);
            actual.RemoveFirst();
            Assert.AreEqual(expected, actual);
        }

        //6
        [TestCase(3, new int[] { 2, 6, 77, 3 }, new int[] { 2, 6, 77 })]
        public void RemoveByIndexTests(int index, int[] actualArray, int[] expectedArray)
        {           
            ArrayList actual = new ArrayList(actualArray);
            ArrayList expected = new ArrayList(expectedArray);
            actual.RemoveByIndex(index);
            Assert.AreEqual(expected, actual);
        }

        //7
        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3 })]
        public void RemoveLastElementsTest(int n, int[] actualArray, int[] expectedArray)
        {           
            ArrayList actual = new ArrayList(actualArray);
            ArrayList expected = new ArrayList(expectedArray);
            actual.RemoveLastElements(n);
            Assert.AreEqual(expected, actual);
        }

        //8
        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 3, 4, 5 })]
        [TestCase(1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 })]
        [TestCase(3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 4, 5 })]
        public void RemoveFirstNTests(int n, int[] actualArray, int[] expectedArray)
        {           
            ArrayList actual = new ArrayList(actualArray);
            ArrayList expected = new ArrayList(expectedArray);
            actual.RemoveFirstN(n);
            Assert.AreEqual(expected, actual);
        }

        ////9
        [TestCase(3, 5, new int[] { 2, 6, 77, 3, 6, 3, 3, -5, 3, 3, 2 }, new int[] { 2, 6, 77, 3, 3, 2 })]
        public void RemoveByIndexNElementsTests(int index, int n, int[] actualArray, int[] expectedArray)
        {           
            ArrayList actual = new ArrayList(actualArray);
            ArrayList expected = new ArrayList(expectedArray);
            actual.RemoveByIndexNElements(index, n);
            Assert.AreEqual(expected, actual);
        }

        //10
        [TestCase(new int[] { 2, 3, 5, 4, 6, 7, 5, 6, 7, 6 }, 10)]
        public void GetLengthTests(int[] actualArray, int expected)
        {
            ArrayList list = new ArrayList(actualArray);
            int actual = list.GetLength();
            Assert.AreEqual(expected, actual);
        }

        //11

        //12
        //[TestCase(7, new int[] { 2, 3, 5, 4, 6, 7, 5, 6, 7, 6 }, 5)]

        //public void GetFirstIndexByValueTests (int expected, int[] actualArray)
        //{
        //    ArrayList List = new ArrayList(actualArray);
        //    int actual = List.Get

        //}

        //13
        //14
        //15
        //16
        //17
        //18
        //19
        //20
        //21
        //22
        //23
        //24
        //25
        [TestCase( new int[] { 1, 4 }, new int[] { 2, 3, 5, 4, 6 }, new int[] { 1, 4, 2, 3, 5, 4, 6 })]
        public void AddArrayListAtTheBeginingTests(int[] array, int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList expected = new ArrayList(expectedArray);
            actual.AddArrayListAtTheBegining(array);
            Assert.AreEqual(expected, actual);
        }

        //26
        [TestCase(2, new int[] {2,3}, new int[] { 2, 3, 5, 4, 6 }, new int[] { 2, 3, 2, 3, 5, 4, 6 })]
        public void AddArrayListByIndexTests(int index, int[] array, int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList expected = new ArrayList(expectedArray);           
            actual.AddArrayListByIndex(index, array);
            Assert.AreEqual(expected, actual);
        }

        //[TestCase(3, 5, new int[] { 2, 6, 77, 3, 3, 2 }, new int[] { 2, 6, 77, 3, 6, 3, 3, -5, 3, 3, 2 })]
        //public void RemoveByIndexNElementsTests(int index, int n, int[] expectedArray, int[] actualArray)
        //{
        //    ArrayList expected = new ArrayList(expectedArray);
        //    ArrayList actual = new ArrayList(actualArray);
        //    actual.RemoveByIndexNElements(index, n);
        //    Assert.AreEqual(expected, actual);
        //}

        //[Test]
        //public void AddFirst()
        //{
        //    ArrayList expected = new ArrayList();
        //    expected.Add(2);
        //    expected.Add(6);
        //    expected.Add(77);
        //    expected.Add(3);
        //    expected.Add(6);
        //    expected.Add(3);
        //    expected.Add(3);
        //    expected.Add(-5);
        //    expected.Add(3);
        //    expected.Add(3);
        //    expected.Add(2);

        //    expected.RemoveByIndexNElements(3, 5);
    }
}