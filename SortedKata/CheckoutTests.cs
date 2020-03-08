using System.Collections.Generic;
using CheckoutKata;
using NUnit.Framework;

namespace CheckoutKataTest
{
    public class CheckoutTests
    {
        [Test]
        public void WhereCheckoutIsEmptyTotalIsZero()
        {
            //Arrange
            List<Item> items = new List<Item>();
            items.Add(new Item("A99", 0.50m, "Apple"));
            items.Add(new Item("B15", 0.30m, "Pack of biscuits"));
            items.Add(new Item("C40", 0.60m, "Something else"));

            List<SpecialOffer> offers = new List<SpecialOffer>();
            offers.Add(new SpecialOffer("A99", 3, 1.30m));
            offers.Add(new SpecialOffer("B15", 2, 0.45m));

            CheckoutKata.Repository repo = new RepositoryForTesting(items);
            Checkout checkout = new Checkout(repo);
            checkout.SetOffers(offers);

            //Act
            decimal total = checkout.Total();

            //Assert
            Assert.AreEqual(0m, total);
        }

        [Test]
        public void WhereCheckoutIsSimpleSumOfItems()
        {
            //Arrange
            List<Item> items = new List<Item>();
            items.Add(new Item("A99", 0.50m, "Apple"));
            items.Add(new Item("B15", 0.30m, "Pack of biscuits"));
            items.Add(new Item("C40", 0.60m, "Something else"));

            List<SpecialOffer> offers = new List<SpecialOffer>();
            offers.Add(new SpecialOffer("A99", 3, 1.30m));
            offers.Add(new SpecialOffer("B15", 2, 0.45m));

            CheckoutKata.Repository repo = new RepositoryForTesting(items);
            Checkout checkout = new Checkout(repo);
            checkout.SetOffers(offers);

            checkout.Scan(repo.GetItem("A99"));
            checkout.Scan(repo.GetItem("B15"));
            checkout.Scan(repo.GetItem("C40"));


            //Act
            decimal total = checkout.Total();

            //Assert
            Assert.AreEqual(1.40m, total);
        }

        [Test]
        public void WhereCheckoutAnOfferItem()
        {
            //Arrange
            List<Item> items = new List<Item>();
            items.Add(new Item("A99", 0.50m, "Apple"));
            items.Add(new Item("B15", 0.30m, "Pack of biscuits"));
            items.Add(new Item("C40", 0.60m, "Something else"));

            List<SpecialOffer> offers = new List<SpecialOffer>();
            offers.Add(new SpecialOffer("A99", 3, 1.30m));
            offers.Add(new SpecialOffer("B15", 2, 0.45m));

            CheckoutKata.Repository repo = new RepositoryForTesting(items);
            Checkout checkout = new Checkout(repo);
            checkout.SetOffers(offers);

            checkout.Scan(repo.GetItem("A99"));
            checkout.Scan(repo.GetItem("A99"));
            checkout.Scan(repo.GetItem("A99"));

            //Act
            decimal total = checkout.Total();

            //Assert
            Assert.AreEqual(1.30m, total);
        }
    }
}