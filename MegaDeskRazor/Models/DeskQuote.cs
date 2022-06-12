using MegaDeskRazor.Data;
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

        [Display(Name = "Delivery Type")]
        public int DeliveryTypeId { get; set; }

        [Display(Name = "Delivery Type")]
        public DeliveryType DeliveryType { get; set; }
        public Desk Desk { get; set; }

        // Constants
        private const decimal BASE_PRICE = 200M;
        private const decimal SURFACE_AREA_COST = 1.00M;
        private const decimal DRAWER_PRICE = 50M;

        public decimal GetQuotePrice(MegaDeskRazorContext context)
        {


            decimal price = BASE_PRICE;

            decimal deskArea = Desk.Width * Desk.Depth;

            // Surface area
            if (deskArea > 1000)
            {
                price = price + (deskArea - 1000) * SURFACE_AREA_COST;
            }

            // Drawers
            price += Desk.NumberOfDrawers * DRAWER_PRICE;

            // Desktop Material

            var surfaceMaterialPrices = context.DesktopMaterial
                .Where(d => d.DesktopMaterialId == this.Desk.DesktopMaterialId)
                .FirstOrDefault();

            price += surfaceMaterialPrices.DesktopMaterialPrice;

            // Delivery Type cost

            var shippingPrices = context.DeliveryType
                .Where(d => d.DeliveryTypeId == this.DeliveryTypeId).FirstOrDefault();

            if (deskArea < 1000)
            {
                price = price + shippingPrices.PriceUnder1000;
            }
            else if (deskArea <= 2000)
            {
                price = price + shippingPrices.PriceBetween1000And2000;
            }
            else
            {
                price = price + shippingPrices.PriceOver2000;
            }

            return price;
        }
    }
}
