using System;
using System.Collections.Generic;
using CrazyNumberGenerator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void TestInitialize()
        {
        }

        // basic behaviour tests

        [TestMethod]
        public void WhereTheNumberIsDivisibleBy3PrintHello()
        {
            var context = new CanDivideBy(3, "hello");
            Assert.AreSame("hello", context.Execute(3));
        }

        [TestMethod]
        public void WhereTheNumberIsDivisibleBy5PrintGoodbye()
        {
            var context = new CanDivideBy(5, "goodbye");
            Assert.AreSame("goodbye", context.Execute(5));
        }

        [TestMethod]
        public void WhereTheNumberIsDivisibleByBothPrintHellogoodbye()
        {
            var context = new CanDivideByThese(new List<int> { 3, 5 }, "hellogoodbye");
            Assert.AreSame("hellogoodbye", context.Execute(15));
        }

        [TestMethod]
        public void WhereTheNumberIs1Print1()
        {
            var context = new OtherwiseJustOutputTheNumber();
            Assert.AreEqual(1, int.Parse(context.Execute(1)));
        }

        [TestMethod]
        public void GeneratorReturnsFifteenElements()
        {
            var pipe = new CrazyStringGenerator();
            Assert.AreEqual(15, (pipe.Execute(15).Count));
        }

        // Heading into unit-testing

        [TestMethod]
        public void ThirtyIsDiviableByThree()
        {
            Assert.IsTrue(30.CanDivideBy(3));
        }

        [TestMethod]
        public void ThiftyIsDiviableByFive()
        {
            Assert.IsTrue(50.CanDivideBy(5));
        }

        [TestMethod]
        public void ThreeIsNotDiviableByFive()
        {
            Assert.IsFalse(3.CanDivideBy(5));
        }

        [TestMethod]
        public void FiveIsNotDiviableByThree()
        {
            Assert.IsFalse(5.CanDivideBy(3));
        }


    }
}
