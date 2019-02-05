using LateRoomsKataCheckout;
using LateRoomsKataCheckout.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LateRoomsKataCheckoutTestProject
{
    [TestClass]
    public class CheckoutTests
    {
        private Checkout checkout;

        public CheckoutTests()
        {
            System.Collections.Generic.IEnumerable<ProductSku> products = new[]
            {
                new ProductSku{ProductProductSku = 'A', Price = 50, },
                new ProductSku{ProductProductSku = 'B', Price = 30},
                new ProductSku{ProductProductSku = 'C', Price = 20},
                new ProductSku{ProductProductSku = 'D', Price = 15}
            };

            System.Collections.Generic.IEnumerable<Discount> discountedpineapples = new[]
            {
                new Discount{ProductSku = 'A', Quantity = 3, Value = 20},
                new Discount{ProductSku = 'B', Quantity = 2, Value = 15}
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

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("AAAB", 160)]
        [DataRow("AA", 100)]
        [DataRow("AB", 80)]
        [DataRow("ABC", 100)]
        [DataRow("ABCCDD", 150)]
        [DataRow("CDBA", 115)]
        public void ScanPineappleWithNoDiscountAndExpectTotal(string scanPineapple, int expected)
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
        public void DiscountedCombinationsAndExpectTotal(string scanPineapple, int expected)
        {
            Assert.AreEqual(expected, checkout.scanPineapple(scanPineapple).Total());
        }


        [TestMethod]
        [DataTestMethod]
        [DataRow("EEGHKYLP", "")]
        [DataRow("ABCDE", "ABCD")]
        [DataRow("AAAA", "AAAA")]
        public void ScannedPineapplesFilterInvalidProductSku(string scanPineapple, string expected)
        {
            Assert.AreEqual(
                expected,
                new string(checkout.scanPineapple(scanPineapple).scannedPineapples)
            );
        }



    }
}

