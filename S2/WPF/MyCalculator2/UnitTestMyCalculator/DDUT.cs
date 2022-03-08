using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BIZ;

namespace UnitTestMyCalculator
{
    [TestClass]
    public class DDUT
    {
        ClassBIZ biz = new ClassBIZ();
        private TestContext _testContext;

        public TestContext TestContext
        {
            get { return _testContext; }
            set { _testContext = value; }
        }

        [TestMethod]
        [DataSource("System.Data.SqlClient", @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=DDUT2022; Integrated Security=True", "Calculation1000", DataAccessMethod.Sequential)]
        public void TestMethod1000Plus()
        {
            //Arrange
            biz.tal1 = TestContext.DataRow["Tal1"].ToString();
            biz.tal2 = TestContext.DataRow["Tal2"].ToString();
            double res = 0D;
            double expected = Convert.ToDouble(TestContext.DataRow["ResPlus"]);
            
            //Act
            res = biz.resPlus;

            //Assert
            Assert.AreEqual(expected, Math.Round(res, 6));
        }

        [TestMethod]
        [DataSource("System.Data.SqlClient", @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=DDUT2022; Integrated Security=True", "Calculation1000", DataAccessMethod.Sequential)]
        public void TestMethod1000Minus()
        {
            //Arrange
            biz.tal1 = TestContext.DataRow["Tal1"].ToString();
            biz.tal2 = TestContext.DataRow["Tal2"].ToString();
            double res = 0D;
            double expected = Convert.ToDouble(TestContext.DataRow["ResMinus"]);

            //Act
            res = biz.resMinus;

            //Assert
            Assert.AreEqual(expected, Math.Round(res, 6));
        }

        [TestMethod]
        [DataSource("System.Data.SqlClient", @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=DDUT2022; Integrated Security=True", "Calculation1000", DataAccessMethod.Sequential)]
        public void TestMethod1000Gange()
        {
            //Arrange
            biz.tal1 = TestContext.DataRow["Tal1"].ToString();
            biz.tal2 = TestContext.DataRow["Tal2"].ToString();
            double res = 0D;
            double expected = Convert.ToDouble(TestContext.DataRow["ResGange"]);

            //Act
            res = biz.resGange;

            //Assert
            Assert.AreEqual(expected, Math.Round(res, 6));
        }

        [TestMethod]
        [DataSource("System.Data.SqlClient", @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=DDUT2022; Integrated Security=True", "Calculation1000", DataAccessMethod.Sequential)]
        public void TestMethod1000Divider()
        {
            //Arrange
            biz.tal1 = TestContext.DataRow["Tal1"].ToString();
            biz.tal2 = TestContext.DataRow["Tal2"].ToString();
            double res = 0D;
            double expected = Convert.ToDouble(TestContext.DataRow["ResDivider"]);

            //Act
            res = biz.resDivi;

            //Assert
            Assert.AreEqual(expected, Math.Round(res, 6));
        }
    }
}
