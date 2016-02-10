using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DeveloperProductivity.UnitTests
{
    [TestClass]
    public class TreeBuilderTests
    {
        [TestMethod]
        public void CreatesATreeOfExpectedSize()
        {
            var sut = new IntTreeBuilder();
            var tree = sut.Build(5);
            Assert.AreEqual(5, tree.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ThrowsForNegativeNumbers()
        {
            var sut = new IntTreeBuilder();
            var tree = sut.Build(-1);

        }
    }
}
