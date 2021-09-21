namespace SupermarketKata
{
    public class Item
    {
        public string Sku { get; }
        public int Price { get; }
        public bool Special { get; }
        public int SpecialQuantity { get; }
        public int SpecialPrice { get; }

        public Item(string sku, int price, string special_offer = null)
        {
            Sku = sku;
            Price = price;
            if (!string.IsNullOrEmpty(special_offer))
            {
                var details = special_offer.Split(' ');
                Special = true;
                SpecialQuantity = int.Parse(details[0]);
                SpecialPrice = int.Parse(details[2]);
            }
        }
    }
}
