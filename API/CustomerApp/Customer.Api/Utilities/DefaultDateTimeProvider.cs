namespace Customer.Api.Utilities
{
    public class DefaultDateTimeProvider : IDateTimeProvider
    {
        public DateOnly GetCurrentDate()
        {
            return DateOnly.FromDateTime(DateTime.Now);
        }
    }
}
