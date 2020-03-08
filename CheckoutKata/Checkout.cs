using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata
{
    public class Checkout
    {
        private Repository repo;
        private List<BasketItem> itemsInBasket;
        private List<SpecialOffer> offers;

        private Checkout() // hide the default constructor.
        { }

        public Checkout(Repository repo)
        {
            offers = new List<SpecialOffer>();
            itemsInBasket = new List<BasketItem>();
            this.repo = repo;
        }

        public void SetOffers(List<SpecialOffer> offers) // Wanted to show an alternative to changing the constructor arguments, which would have meant changing 'production' code.
        {
            this.offers = offers ?? throw new ArgumentNullException(nameof(offers), "Offers should not be set to null!");
        }
        public decimal Total()
        {
            if (!offers.Any()) // no offers? do simple maths
            {
                return itemsInBasket.Sum(i => i.UnitPrice * i.ItemCount);
            }
            else
            {
                decimal total = 0m;
                var sortedOffers = offers.OrderByDescending(o => o.Quantity);
                foreach (var offer in sortedOffers)
                {
                    while (itemsInBasket.Any(i => i.SKU == offer.SKU && i.ItemCount >= offer.Quantity))
                    {
                        var theItem = itemsInBasket.FirstOrDefault(i => i.SKU == offer.SKU);
                        total += offer.OfferPrice;
                        theItem.ItemCount -= offer.Quantity;

                        if (theItem.ItemCount < 0 ) { throw new ApplicationException("Logic error in Total method!"); } // Should not happen.
                    }
                }

                total += itemsInBasket.Sum(i => i.ItemCount * i.UnitPrice);

                return total;
            }
        }

        public void Scan(Item item)
        {
            BasketItem theItem = itemsInBasket.FirstOrDefault(i => i.SKU == item.SKU);

            if (theItem != null && theItem.SKU == item.SKU) // Item was found.
            {
                theItem.ItemCount++;
            }
            else // item was not found
            {
                theItem = new BasketItem(item);
                theItem.ItemCount++;
                itemsInBasket.Add(theItem);
            }
        }
    }
}
