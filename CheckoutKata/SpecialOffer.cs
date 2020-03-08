using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutKata
{
    public class SpecialOffer
    {
        public string SKU { get; private set; }
        public int Quantity { get; private set; }
        public decimal OfferPrice { get; private set; }

        private SpecialOffer() // hide default constructor.
        {
        }

        public SpecialOffer(string sku, int quantity, decimal offerPrice)
        {
            this.SKU = sku;
            this.Quantity = quantity;
            this.OfferPrice = offerPrice;
        }
    }
}
