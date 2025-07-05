namespace E_commerce.System
{
    internal class Cheese : Product, IExpirable, IShippable
    {
        private double _weight;
        private DateOnly _expirationDate;
        public Cheese(string name, double price, int quantity, DateOnly expirationDate, double weight)
            : base(name, price, quantity)
        {
            _expirationDate = expirationDate;
            _weight = weight;
        }
        public DateOnly GetExpirationDate() => _expirationDate;
        
        public bool IsExpired() => _expirationDate < DateOnly.FromDateTime(DateTime.Now);
        public string GetName() => Name;
        public double GetWeight() => _weight;
    }
}