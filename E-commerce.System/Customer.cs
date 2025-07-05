namespace E_commerce.System
{
    internal class Customer
    {
        public string Name { get; private set; }
        public double Balance { get; set; }
        public Customer(string name, double balance)
        {
            Name = name;
            Balance = balance;
        }
    }
}
