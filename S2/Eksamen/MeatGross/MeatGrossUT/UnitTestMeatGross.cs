using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using BIZ;
using Repository;
using IO;

namespace MeatGrossUT
{
    [TestClass]
    public class UnitTestMeatGross
    {
        [TestMethod]
        public void TestCalculation()
        {
            //Arrange
            ClassBiz biz = new ClassBiz();
            double expected = 4.4D;

            //Act
            biz.selectedCustomer.country.valutaRate = 1.1;
            biz.order.orderCustomer = biz.selectedCustomer;
            biz.order.orderWeight = 2;
            biz.order.orderMeat.pricePerKG = 2;

            //Assert
            Assert.AreEqual(expected, biz.order.orderPriceValuta);
        }

        // Lavet efter ankommelse på skolen

        [TestMethod]
        public void TestCalculationAttemptTwo()
        {
            //Arrange
            ClassOrder order = new ClassOrder(new ClassApiRates());
            double expectedPrice = 4D;

            order.apiRates.Rates.Add("DKK", 1);
            order.apiRates.Rates.Add("EUR", 1.5);

            //Act 
            order.orderMeat.pricePerKG = 1.5;
            order.orderCustomer.country.valutaName = "EUR";
            order.orderCustomer.country.valutaRate = 1.5;
            order.orderWeight = 2;

            //Assert
            Assert.AreEqual(expectedPrice, order.orderPriceDKK);
            Assert.AreEqual(expectedPrice, order.orderPriceValuta);
        }
    }
}
