namespace E_commerce.System
{
    internal class Cart
    {
        private List<CartItem> _items = new List<CartItem>();
        public void AddItem(Product product, int quantity)
        {
            if (quantity > product.Quantity)
            {
                Console.WriteLine("Not enough quantity in stock.");
                return;
            }
            var existingItem = _items.FirstOrDefault(item => item.Product == product);
            if (existingItem != null)
            { 
                _items.Remove(existingItem);
                _items.Add(new CartItem(product, existingItem.Quantity + quantity));
            }
            else
            {
                _items.Add(new CartItem(product, quantity));
            }
        }
        public List<CartItem> GetItems() => _items;
        public bool IsEmpty() => _items.Count == 0;
    }
}
