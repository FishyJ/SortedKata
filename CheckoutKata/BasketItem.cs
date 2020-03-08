using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutKata
{
    public class BasketItem : Item
    {
        public int ItemCount { get; set; }

        public BasketItem(string sku, decimal unitPrice, string description) : base(sku, unitPrice, description)
        {
            this.ItemCount = 0;
        }

        public BasketItem(Item item) : base(item.SKU, item.UnitPrice, item.Description)
        {
            this.ItemCount = 0;
        }
    }
}
