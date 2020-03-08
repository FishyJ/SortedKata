using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata
{
    public class Checkout
    {
        private Repository repo;
        private List<Item> items;

        private Checkout() // hide the default constructor.
        { }

        public Checkout(Repository repo)
        {
            items = new List<Item>();
            this.repo = repo;
        }

        public decimal Total()
        {
            return items.Sum(i => i.UnitPrice);
        }

        public void Scan(Item item)
        {
            items.Add(item);
        }
    }
}
