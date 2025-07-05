namespace E_commerce.System
{
    internal static class ECommerceSystem
    {
        public static void SendToShippingService(List<IShippable> itemsToShip)
        {
            Console.WriteLine("** Shipment notice **");
            double totalWeight = 0;
            foreach (var item in itemsToShip)
            {
                Console.Write(item.GetName());
                Console.WriteLine($"   {item.GetWeight() * 1000}g");
                totalWeight += item.GetWeight();
            }
            Console.WriteLine($"Total package weight {totalWeight}kg");
            Console.WriteLine("--------------------");
        }
        public static void Checkout(Customer customer, Cart cart)
        {
            if (cart.IsEmpty())
            {
                Console.WriteLine("Error: Cart is empty");
                return;
            }
            double subtotal = 0;
            double totalWeight = 0;
            var shippableItems = new List<IShippable>();
            foreach (var item in cart.GetItems())
            {
                if (item.Product is IExpirable expirable)
                    if (expirable.IsExpired())
                        Console.WriteLine($"{item.Product.Name} is expired.");

                if (item.Quantity > item.Product.Quantity)
                    Console.WriteLine($"{item.Product.Name} is out of stock.");
                subtotal += item.Product.Price * item.Quantity;
                item.Product.Quantity -= item.Quantity;
                if (item.Product is IShippable shippable)
                {
                    totalWeight += shippable.GetWeight() * item.Quantity;
                    shippableItems.Add(shippable);
                }
            }
            double shippingFees = totalWeight * 10;
            double totalAmount = subtotal + shippingFees;
            if (customer.Balance < totalAmount)
            {
                Console.WriteLine("Error: Insufficient balance.");
                return;
            }
            customer.Balance -= totalAmount;
            if (shippableItems.Count > 0)
                SendToShippingService(shippableItems);

            Console.WriteLine("** Checkout receipt **");
            foreach (var item in cart.GetItems())
                Console.WriteLine($"{item.Quantity}x {item.Product.Name}     {item.Product.Price * item.Quantity}");

            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Subtotal             {subtotal}");
            Console.WriteLine($"Shipping             {shippingFees}");
            Console.WriteLine($"Amount               {totalAmount}");
            Console.WriteLine($"New Customer Balance {customer.Balance}");
        }
    }
}
