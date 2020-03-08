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

            CheckoutKata.Repository repo = new RepositoryForTesting(items);
            Checkout checkout = new Checkout(repo);

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

            CheckoutKata.Repository repo = new RepositoryForTesting(items);
            Checkout checkout = new Checkout(repo);

            checkout.Scan(repo.GetItem("A99"));
            checkout.Scan(repo.GetItem("B15"));
            checkout.Scan(repo.GetItem("C40"));


            //Act
            decimal total = checkout.Total();

            //Assert
            Assert.AreEqual(1.40m, total);
        }
    }
}