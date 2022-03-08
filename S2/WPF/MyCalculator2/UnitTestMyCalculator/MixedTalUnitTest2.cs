using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BIZ;

namespace UnitTestMyCalculator
{
    [TestClass]
    public class MixedTalUnitTest2
    {
        [TestMethod]
        public void TestMethodPlus()
        {
            //Arrange
            ClassBIZ biz = new ClassBIZ();
            biz.tal1 = "-50";
            biz.tal2 = "125";
            double res = 0D;
            double expected = 75D;

            //Act
            res = biz.resPlus;

            //Assert
            Assert.AreEqual(expected, res);
        }

        [TestMethod]
        public void TestMethodMinus()
        {
            //Arrange
            ClassBIZ biz = new ClassBIZ();
            biz.tal1 = "-50";
            biz.tal2 = "125";
            double res = 0D;
            double expected = -175D;

            //Act
            res = biz.resMinus;

            //Assert
            Assert.AreEqual(expected, res);
        }

        [TestMethod]
        public void TestMethodGange()
        {
            //Arrange
            ClassBIZ biz = new ClassBIZ();
            biz.tal1 = "-10";
            biz.tal2 = "125";
            double res = 0D;
            double expected = -1250D;

            //Act
            res = biz.resGange;

            //Assert
            Assert.AreEqual(expected, res);
        }

        [TestMethod]
        public void TestMethodDivi()
        {
            //Arrange
            ClassBIZ biz = new ClassBIZ();
            biz.tal1 = "-50";
            biz.tal2 = "125";
            double res = 0D;
            double expected = -0.4D;

            //Act
            res = biz.resDivi;

            //Assert
            Assert.AreEqual(expected, res);
        }
    }
}
