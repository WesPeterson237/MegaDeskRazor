using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDeskRazor
{
    public class DeskQuote
    {
        public DeskQuote()
        {
        }

        private const decimal BaseDeskPrice = 200.00m;
        private const decimal SurfaceAreaCost = 1.00m;
        private const decimal DrawerCost = 50.00m;

        public int DeskQuoteId { get; set; }

        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Display(Name = "Quote Date")]
        [DataType(DataType.Date)]
        public DateTime QuoteDate { get; set; }

        [Display(Name = "Quote Price")]
        [DisplayFormat(DataFormatString ="{0:C}")]
        public decimal QuotePrice { get; set; }

        public int DeskId { get; set; }
        public int DeliveryTypeId { get; set; }

        [Display(Name = "Delivery Type")]
        public DeliveryType DeliveryType { get; set; }
        public Desk Desk { get; set; }
    }
}
