namespace E_commerce.System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product cheese = new Cheese("Cheese", 100, 10, DateOnly.FromDateTime(DateTime.Now.AddMonths(3)), 0.2);
            Product tv = new TV("Samsung TV", 5000, 5, 15.5);
            Product smCard = new SMCard("Mobile Card", 25, 100);

            var customer = new Customer("Eslam", 10000);

            var cart = new Cart();

            cart.AddItem(cheese, 2);       
            cart.AddItem(tv, 1);            
            cart.AddItem(smCard, 4);

            ECommerceSystem.Checkout(customer, cart);
        }
    }
}
