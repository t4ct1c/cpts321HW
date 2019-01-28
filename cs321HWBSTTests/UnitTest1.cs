using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        cs321HWBSTTests.BST tree1;

        [SetUp]
        public void Setup()
        {
            List<int> list = new List<int>(new int[] {1,2,3,4,5,6,7 });

            tree1 = new cs321HWBSTTests.BST();

        }

        [Test]
        public void Test1()
        {
            Assert.AreEqual(7, tree1.countNodes());
            Assert.AreNotEqual(2, tree1.minLevel());
            Assert.AreEqual(3, tree1.minLevel());
            Assert.Pass();
        }
    }
}