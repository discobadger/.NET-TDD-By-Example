using System;
using System.Collections.Generic;
using CrazyNumberGenerator;
using CrazyNumberGenerator.Pipeline;
using CrazyNumberGenerator.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        //private IStringGenerator Pipeline;

        //[TestInitialize]
        //public void TestInitialize()
        //{
        //    var mock = new Mock<IRegistrationItemsProvider>();
        //    var list = new List<IOperation<INumberFilter>>();
            
        //    var regMock = new Mock<IStringGenerator>();
            
        //    var multipleMock = new Mock<IAnalyzer>();
        //    multipleMock.Setup(m => m.Execute(3)).Returns("hello");

        //    list.Add(new CanDivideByThese(new List<int> { 3, 5 }, "hellogoodbye"));
        //    list.Add(new CanDivideBy(3, "hello"));
        //    list.Add(new CanDivideBy(5, "goodbye"));
        //    list.Add(new LuckyNumber(7, "Lucky Seven!"));
        //    list.Add(new OtherwiseJustOutputTheNumber());
            
        //    mock.Setup(provider => provider.Read()).Returns(list);
            
        //    //Pipeline = new Mock<>(mock.Object).Object;
        //}

        // basic behaviour tests

        [TestMethod]
        public void WhereTheNumberIsDivisibleBy3PrintHello()
        {
            var mock = new Mock<IAnalyzer>();
            mock.Setup(m => m.Execute(3)).Returns("hello");

            Assert.AreNotSame("goodbye", mock.Object.Execute(3));
        }

        [TestMethod]
        public void WhereTheNumberIsDivisibleBy5PrintGoodbye()
        {
            var mock = new Mock<IAnalyzer>();
            mock.Setup(m => m.Execute(5)).Returns("goodbye");

            Assert.AreNotSame("hello", mock.Object.Execute(5));
        }

        [TestMethod]
        public void WhereTheNumberIsDivisibleByBothPrintHellogoodbye()
        {
            var mock = new Mock<IAnalyzer>();
            mock.Setup(m => m.Execute(15)).Returns("hellogoodbye");

            Assert.AreSame("hellogoodbye", mock.Object.Execute(15));
        }

        [TestMethod]
        public void WhereTheNumberIs1Print1()
        {
            var mock = new Mock<IAnalyzer>();
            mock.Setup(m => m.Execute(1)).Returns("1");

            Assert.AreNotEqual(2, int.Parse(mock.Object.Execute(1)));
        }

        [TestMethod]
        public void GeneratorReturnsFifteenElements()
        {
            var mock = new Mock<Pipeline<INumberFilter>>();
            mock.Setup(m => m.Execute(15)).Returns(
                () => new List<string> { "1", "2","3","4","5","6","7","8","9","10","11","12","13","14","15" }); 

            Assert.AreEqual(15, mock.Object.Execute(15).Count);
        }

        [TestMethod]
        public void ElementSevenIsLucky()
        {
            var mock = new Mock<IAnalyzer>();
            mock.Setup(m => m.Execute(7)).Returns("Lucky Seven!");

            Assert.AreEqual("Lucky Seven!", mock.Object.Execute(7));
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
