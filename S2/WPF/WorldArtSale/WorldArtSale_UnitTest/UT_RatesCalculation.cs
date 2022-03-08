using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using Repository;

namespace WorldArtSale_UnitTest
{
    [TestClass]
    public class UT_RatesCalculation
    {
        [TestMethod]
        public void TestUsdToEur()
        {
            // Arrange
            ClassSalesValue salesValue = new ClassSalesValue();
            salesValue.customerValutaCode = "DKK";
            salesValue.classCurrency.rates.Add("EUR", 0.7500M);
            salesValue.classCurrency.rates.Add("DKK", 6.8500M);

            // Act
            salesValue.bidUSD = "1000";

            // Assert
            Assert.AreEqual("750,0000", salesValue.bidEUR);
            Assert.AreEqual("6850,0000", salesValue.bidOwnValuta);
        }

        [TestMethod]
        public void TestUsdToNok()
        {
            // Arrange
            ClassSalesValue salesValue = new ClassSalesValue();
            salesValue.customerValutaCode = "NOK";
            salesValue.classCurrency.rates.Add("EUR", 0.7500M);
            salesValue.classCurrency.rates.Add("NOK", 0.7600M);

            // Act
            salesValue.bidUSD = "1000";

            // Assert
            Assert.AreEqual("760,0000", salesValue.bidOwnValuta);
        }

        [TestMethod]
        public void TestUsdToIsk()
        {
            // Arrange
            ClassSalesValue salesValue = new ClassSalesValue();
            salesValue.customerValutaCode = "ISK";
            salesValue.classCurrency.rates.Add("EUR", 0.7500M);
            salesValue.classCurrency.rates.Add("ISK", 0.0500M);

            // Act
            salesValue.bidUSD = "1000";

            // Assert
            Assert.AreEqual("50,0000", salesValue.bidOwnValuta);
        }

        [TestMethod]
        public void TestUsdToRBX()
        {
            // Arrange
            ClassSalesValue salesValue = new ClassSalesValue();
            salesValue.customerValutaCode = "RBX";
            salesValue.classCurrency.rates.Add("EUR", 0.7500M);
            salesValue.classCurrency.rates.Add("RBX", 0.0600M);

            // Act
            salesValue.bidUSD = "1000";

            // Assert
            Assert.AreEqual("60,0000", salesValue.bidOwnValuta);
        }
    }
}
