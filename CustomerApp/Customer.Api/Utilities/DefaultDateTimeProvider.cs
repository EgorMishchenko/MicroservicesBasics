namespace Customer.Api.Utilities
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateOnly GetCurrentDate()
        {
            return DateOnly.FromDateTime(DateTime.Now);
        }
    }
}
