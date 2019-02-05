using System;
using LateRoomsKataCheckout.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LateRoomsKataCheckout.Tests
{
    [TestClass]
    public class CheckoutTests
    {
        private Checkout checkout;

        public CheckoutTests()
        {
            System.Collections.Generic.IEnumerable<Sku> products = new[]
            {
                new Sku{ProductSku = 'A', Price = 50, },
                new Sku{ProductSku = 'B', Price = 30},
                new Sku{ProductSku = 'C', Price = 20},
                new Sku{ProductSku = 'D', Price = 15}
            };

            System.Collections.Generic.IEnumerable<Discount> discountedpineapples = new[]
            {
                new Discount{SKU = 'A', Quantity = 3, Value = 20},
                new Discount{SKU = 'B', Quantity = 2, Value = 15}
            };
            checkout = new Checkout(products, discountedpineapples);
        }
        

        [TestMethod]
        [DataTestMethod]
        [DataRow("AAA", 130)]
        [DataRow("AAAB", 160)]
        [DataRow("AAABB", 175)]
        [DataRow("AAAAAA", 260)]
        [DataRow("AAAAAABB", 305)]
        [DataRow("BB", 45)]
        [DataRow("ABB", 95)]
        [DataRow("BBBB", 90)]
        [DataRow("BBBBACD", 175)]
              
        public void scanDiscountedPineapples(string scanPineapple, int expected)
        {
            Assert.AreEqual(expected, checkout.scanPineapple(scanPineapple).Total());
        }

        [TestMethod]
        public void TestCheckoutZeroItemReturnsZero()
        {
            decimal result = checkout.Total();

            Assert.AreEqual(0,result);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("AAAB", 160)]
        [DataRow("AA", 100)]
        [DataRow("AB", 80)]
        [DataRow("ABC", 100)]
        [DataRow("ABCCDD", 150)]
        [DataRow("CDBA", 115)]
        public void scanPineapple_no_discount_combinations_and_expect_total(string scanPineapple, int expected)
        {
            Assert.AreEqual(expected, checkout.scanPineapple(scanPineapple).Total());
        }


        [TestMethod]
        [DataTestMethod]
        [DataRow("AAA", 130)]
        [DataRow("AAAB", 160)]
        [DataRow("AAABB", 175)]
        [DataRow("AAAAAA", 260)]
        [DataRow("AAAAAABB", 305)]
        [DataRow("BB", 45)]
        [DataRow("ABB", 95)]
        [DataRow("BBBB", 90)]
        [DataRow("BBBBACD", 175)]
        public void scanPineapple_discounted_combinations_and_expect_correct_total(string scanPineapple, int expected)
        {
            Assert.AreEqual(expected, checkout.scanPineapple(scanPineapple).Total());
        }


        [TestMethod]
        [DataTestMethod]
        [DataRow("EEGHKYLP", "")]
        [DataRow("ABCDE", "ABCD")]
        [DataRow("AAAA", "AAAA")]
        public void scanPineapple_should_filter_invalid_sku(string scanPineapple, string expected)
        {
            Assert.AreEqual(
                expected,
                new String(checkout.scanPineapple(scanPineapple).scanPineapplenedPineapples)
            );
        }


        
    }
}
