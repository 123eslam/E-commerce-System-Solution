namespace E_commerce.System
{
    internal class TV : Product,IShippable
    {
        private double _weight;
        public TV(string name, double price, int quantity, double weight)
            : base(name, price, quantity)
        {
            _weight = weight;
        }
        public string GetName() => Name;
        public double GetWeight() => _weight;
    }
}
