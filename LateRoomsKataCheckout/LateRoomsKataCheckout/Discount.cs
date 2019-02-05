using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LateRoomsKataCheckout
{
    public class Discount:IDiscount
    {
        public char ProductSku { get; set; }
        public int Quantity { get; set; }
        public int Value { get; set; }
    }
}