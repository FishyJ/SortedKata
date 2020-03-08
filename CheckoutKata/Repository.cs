using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckoutKata
{
    public class Repository
    {
        protected List<Item> items;

        public Repository()
        {
            items = new List<Item>();
        }

        public Item GetItem(string sku)
        {
            return items.FirstOrDefault(i => i.SKU == sku);
        }
    }
}
