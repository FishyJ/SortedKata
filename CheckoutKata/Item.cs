using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutKata
{
    public class Item
    {
        public string SKU { get; private set; }
        public decimal UnitPrice { get; private set; }
        public string Description { get; private set; }

        public Item(string sku, decimal unitPrice, string description)
        {
            this.SKU = sku;
            this.UnitPrice = unitPrice;
            this.Description = description;
        }
    }
}
