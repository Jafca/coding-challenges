using System.Collections.Generic;

namespace SupermarketKata
{
    public class Checkout : ICheckout
    {
        public Dictionary<string, Item> Items;

        private Dictionary<string, int> _scannedItems = new Dictionary<string, int>();

        public Checkout(Dictionary<string, Item> items)
        {
            Items = items;
        }

        public void Scan(string item)
        {
            if (_scannedItems.ContainsKey(item))
                _scannedItems[item]++;
            else
                _scannedItems.Add(item, 1);
        }

        public int GetTotalPrice()
        {
            int totalPrice = 0;

            foreach (var pair in _scannedItems)
            {
                var item = Items[pair.Key];
                if (item.Special)
                {
                    var itemsAtUnitPrice = pair.Value % item.SpecialQuantity;
                    totalPrice += item.Price * itemsAtUnitPrice;

                    var itemsAtSpecialPrice = pair.Value / item.SpecialQuantity;
                    totalPrice += item.SpecialPrice * itemsAtSpecialPrice;
                }
                else
                {
                    totalPrice += item.Price * pair.Value;
                }
            }
            return totalPrice;
        }
    }
}