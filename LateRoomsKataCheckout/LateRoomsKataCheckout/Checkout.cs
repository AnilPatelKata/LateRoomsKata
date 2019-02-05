using System.Collections.Generic;
using System.Linq;

namespace LateRoomsKataCheckout
{
    public class Checkout:ICheckout
    {
        private readonly IEnumerable<IProductSku> pineapples;
        private readonly IEnumerable<IDiscount> discountedpineapples;


        public char[] scannedPineapples { get; private set; }

        public Checkout(IEnumerable<IProductSku> products, IEnumerable<IDiscount> discountedpineapples)
        {
            pineapples = products;
            this.discountedpineapples = discountedpineapples;
            scannedPineapples = new char[] { };
        }


        public ICheckout scanPineapple(string scanPineapple)
        {
            if (!string.IsNullOrEmpty(scanPineapple))
            {
                scannedPineapples = scanPineapple.ToCharArray()
                    .Where(scanPineapplenedpineapple => pineapples.Any(product => product.ProductProductSku == scanPineapplenedpineapple))
                    .ToArray();
            }
            return this;
        }

        public decimal Total()
        {
            var total = 0.0M;
            var totalDiscount = 0.0M;
            var totalMinusDiscount = 0.0M;
            total = scannedPineapples.Sum(item => PriceForPineapples(item));
            if (total == 0)
            {
                return total;
            }
            totalDiscount = discountedpineapples.Sum(discount => CalculateDiscountForDiscountedPineapples(discount, scannedPineapples));
            if (totalDiscount == 0)
            {
                return total;
            }
            else
            {
                totalMinusDiscount = total - totalDiscount;
                return totalMinusDiscount;
            }

        }

        private int PriceForPineapples(char ProductSku)
        {
            return pineapples.Single(p => p.ProductProductSku == ProductSku).Price;
        }

        private int CalculateDiscountForDiscountedPineapples(IDiscount discount, char[] cart)
        {
            int itemCount = cart.Count(item => item == discount.ProductSku);
            return (itemCount / discount.Quantity) * discount.Value;
        }



    }
}