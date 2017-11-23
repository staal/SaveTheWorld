using NUnit.Framework;

namespace SaveTheWorld.Tests
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void AddTest()
        {
            SimpleClass simpleClass = new SimpleClass();
            int result = simpleClass.Add(5, 7);
            Assert.AreEqual(12, result);
        }

        [Test]
        public void SubtractTest()
        {
            SimpleClass simpleClass = new SimpleClass();
            int result = simpleClass.Sub(5, 3);
            Assert.AreEqual(2, result);
        }
    }
}
