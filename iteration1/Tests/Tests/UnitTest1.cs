using System;
using System.Collections.Generic;
using ConsoleApplication1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        private CrazyStringGenerator _context;

        [TestInitialize]
        public void TestInitialize()
        {
            _context = new CrazyStringGenerator();
        }

        // basic behaviour tests

        [TestMethod]
        public void WhereTheNumberIsDivisibleBy3PrintHello()
        {
            Assert.AreSame("hello", _context.Filter(3));
        }

        [TestMethod]
        public void WhereTheNumberIsDivisibleBy5PrintGoodbye()
        {
            Assert.AreSame("goodbye", _context.Filter(5));
        }

        [TestMethod]
        public void WhereTheNumberIsDivisibleByBothPrintHellogoodbye()
        {
            Assert.AreSame("hellogoodbye", _context.Filter(15));
        }

        [TestMethod]
        public void WhereTheNumberIs1Print1()
        {
            Assert.AreEqual(1, int.Parse(_context.Filter(1)));
        }

        [TestMethod]
        public void GeneratorReturnsFifteenElements()
        {
            Assert.AreEqual(15, (_context.Process(15).Count));
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
