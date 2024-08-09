namespace Customer.Api.Utilities
{
    public interface IDateTimeProvider
    {
        DateOnly GetCurrentDate();
    }
}
