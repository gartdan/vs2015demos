// <copyright file="IntTreeBuilderTest.cs">Copyright ©  2016</copyright>

using System;
using DeveloperProductivity;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DeveloperProductivity.Tests
{
    [TestClass]
    [PexClass(typeof(IntTreeBuilder))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class IntTreeBuilderTest
    {

        [PexMethod]
        [PexAllowedException(typeof(ArgumentOutOfRangeException))]
        public Tree<int> Build([PexAssumeUnderTest]IntTreeBuilder target, int numNodes)
        {
            Tree<int> result = target.Build(numNodes);
            return result;
            // TODO: add assertions to method IntTreeBuilderTest.Build(IntTreeBuilder, Int32)
        }
    }
}
