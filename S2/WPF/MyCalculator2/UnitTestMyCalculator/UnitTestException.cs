using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BIZ;

namespace UnitTestMyCalculator
{
    [TestClass]
    public class UnitTestException
    {
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestMethodOutOfRange()
        {
            //Arrange
            ClassBIZ biz = new ClassBIZ();

            //Act
            double res = biz.TestOutOfRangeException(10);

            //Assert
            //Assert.AreEqual(expected, res);
        }


        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestMethodDivideBy0()
        {
            //Arrange
            ClassBIZ biz = new ClassBIZ();
            double a = 10;
            double b = 0;

            //Act
            double res = biz.TestDivideByZeroException(a, b);

            //Assert
            //Assert.AreEqual(expected, res);
        }
    }
}
