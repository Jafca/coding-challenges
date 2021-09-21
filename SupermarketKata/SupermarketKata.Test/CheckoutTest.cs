using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SupermarketKata.Test
{
    [TestClass]
    public class CheckoutTest
    {
        Dictionary<string, Item> Items = new Dictionary<string, Item>
        {
            { "A", new Item("A", 50, "3 for 130") },
            { "B", new Item("B", 30, "2 for 45") },
            { "C", new Item("C", 20) },
            { "D", new Item("D", 15) }
        };

        [TestMethod]
        [DataRow(new string[] { "A" }, 50)]
        [DataRow(new string[] { "B" }, 30)]
        [DataRow(new string[] { "C" }, 20)]
        [DataRow(new string[] { "D" }, 15)]
        public void Scan_SingleItems_OfSameSKU(string[] itemsToScan, int expected)
        {
            ICheckout checkout = new Checkout(Items);
            foreach (var item in itemsToScan)
                checkout.Scan(item);

            int actual = checkout.GetTotalPrice();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(new string[] { "A", "A" }, 100)]
        [DataRow(new string[] { "C", "C" }, 40)]
        [DataRow(new string[] { "D", "D", "D" }, 45)]
        public void Scan_MultipleItems_OfSameSKU_WithoutOffer(string[] itemsToScan, int expected)
        {
            ICheckout checkout = new Checkout(Items);
            foreach (var item in itemsToScan)
                checkout.Scan(item);

            int actual = checkout.GetTotalPrice();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(new string[] { "A", "A", "A" }, 130)]
        [DataRow(new string[] { "A", "A", "A", "A" }, 180)]
        [DataRow(new string[] { "B", "B" }, 45)]
        [DataRow(new string[] { "B", "B", "B" }, 75)]
        public void Scan_MultipleItems_OfSameSKU_WithOffer(string[] itemsToScan, int expected)
        {
            ICheckout checkout = new Checkout(Items);
            foreach (var item in itemsToScan)
                checkout.Scan(item);

            int actual = checkout.GetTotalPrice();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(new string[] { "A", "A", "A", "B", "B" }, 175)]
        [DataRow(new string[] { "A", "A", "A", "C", "D" }, 165)]
        public void Scan_MultipleItems_WithOffer_WithOrder(string[] itemsToScan, int expected)
        {
            ICheckout checkout = new Checkout(Items);
            foreach (var item in itemsToScan)
                checkout.Scan(item);

            int actual = checkout.GetTotalPrice();

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        [DataRow(new string[] { "A", "A", "A", "B", "B" }, 175)]
        [DataRow(new string[] { "A", "A", "A", "C", "D" }, 165)]
        public void Scan_MultipleItems_WithOffer_WithoutOrder(string[] itemsToScan, int expected)
        {
            ICheckout checkout = new Checkout(Items);
            foreach (var item in itemsToScan)
                checkout.Scan(item);

            int actual = checkout.GetTotalPrice();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(new string[] { "B", "A", "B" }, 95)]
        public void SampleData(string[] itemsToScan, int expected)
        {
            ICheckout checkout = new Checkout(Items);
            foreach (var item in itemsToScan)
                checkout.Scan(item);

            int actual = checkout.GetTotalPrice();

            Assert.AreEqual(expected, actual);
        }
    }
}
