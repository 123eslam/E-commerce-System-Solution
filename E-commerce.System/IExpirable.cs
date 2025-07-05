namespace E_commerce.System
{
    internal interface IExpirable
    {
        DateOnly GetExpirationDate();
        bool IsExpired();
    }
}
