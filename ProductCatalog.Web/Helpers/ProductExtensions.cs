namespace ProductCatalog.Web.Helpers
{
    public static class ProductExtensions
    {
        public static IQueryable<Product> FilterByDuration(this IQueryable<Product> query)
        {

            DateTime currentTime = DateTime.Now; 
            return query.Where(p =>
                (p.DurationType == DurationType.Minutes && p.StartDate.AddMinutes(p.Duration) >= currentTime) ||
                (p.DurationType == DurationType.Hours && p.StartDate.AddHours(p.Duration) >= currentTime) ||
                (p.DurationType == DurationType.Days && p.StartDate.AddDays(p.Duration) >= currentTime)
            );


        }
    }
}
