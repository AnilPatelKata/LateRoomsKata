using LateRoomsKataCheckout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateRoomsKataCheckout
{
    public interface ICheckout
    {
        ICheckout scanPineapple(String scan);
        decimal Total();
        char[] scannedPineapples { get; }
    }
}
