using System;
using System.Collections.Generic;
using System.Text;
using CheckoutKata;

namespace CheckoutKataTest
{
    public class RepositoryForTesting : Repository
    {
        public RepositoryForTesting(List<Item> items)
        {
            base.items = new List<Item>();
            base.items.AddRange(items);
        }
    }
}
