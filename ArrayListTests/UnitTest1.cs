using List;
using System;

namespace ArrayListTests
{
    public class Tests
    {

        [TestCase(5, new int[] { 1, 4 })]
        public void AddFirst(int value, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList();
            actual.AddFirst(value);


            Assert.AreEqual(expected, actual);
        }

        //[Test]
        //public void AddFirst();
        //{
        //    Assert.AreEqual(excepted, actual)
        //}
    }
}