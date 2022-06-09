using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDeskRazor
{
    public class DeliveryType
    {
        public int DeliveryTypeId { get; set; }

        public string DeliveryName { get; set; }

        public decimal PriceUnder1000 { get; set; }

        public decimal PriceBetween1000And2000 { get; set; }

        public decimal PriceOver2000 { get; set; }

    }
}
