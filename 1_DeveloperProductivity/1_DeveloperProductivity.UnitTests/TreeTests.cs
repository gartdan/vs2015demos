using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperProductivity.UnitTests
{
    [TestClass]
    public class TreeTests
    {
        [TestMethod]
        public void AddingAnElement_IncrementsCount()
        {
            var tree = new Tree<int>();
            tree.Add(1).Add(2).Add(3).Add(4);
            Assert.IsTrue(tree.Count == 4);
        }

        [TestMethod]
        public void AnEmptyTree_HasNoElements()
        {
            var tree = new Tree<int>();
            Assert.IsTrue(tree.Count == 0);
        }

        [TestMethod]
        public void ToString_ReturnsBFSString()
        {
            var tree = new Tree<int>();
            tree.Add(3).Add(2).Add(5).Add(4);
            var result = tree.ToString();
            Assert.AreEqual("3 2 5 4 ", result);
        }
    }
}
