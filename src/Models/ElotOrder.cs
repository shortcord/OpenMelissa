using System;
using System.Collections.Generic;
using System.Text;

namespace OpenMelissa.Models
{
    /// <summary>
    /// ELot Number and Order
    /// </summary>
    public class ELotOrder : IEquatable<ELotOrder>
    {
        /// <summary>
        /// Where the current address falls in the delivery order within the ZIP+4
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// <para>Order returns the letters "A" or "D" to indicate whether the Post Office delviers mail within
        /// the ZIP+4 in ascending or descending order.</para>
        /// <para>Example, if the eLot number is 1 and the eLot Order is "D", then the address is typically the last delivery of the day.</para>
        /// </summary>
        public string Order { get; set; }

        public ELotOrder() { }
        public ELotOrder(string eLotNumber, string eLotOrder)
        {
            Number = eLotNumber;
            Order = eLotOrder;
        }

        public bool Equals(ELotOrder other)
        {
            return Number == other.Number &&
                Order == other.Order;
        }
    }
}
