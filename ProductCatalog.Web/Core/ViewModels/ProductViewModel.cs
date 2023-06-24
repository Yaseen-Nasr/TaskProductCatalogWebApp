namespace ProductCatalog.Web.Core.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Category { get; set; } = null!; 
        public DateTime CreationDate { get; set; }
        public DateTime StartDate { get; set; }
        [Range(0, int.MaxValue)]
        public int Duration { get; set; }
        public DurationType DurationType { get; set; }
        public decimal Price { get; set; }  
    }


    public class ProductShortInfoViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!; 
        public string Category { get; set; } = null!; 
        public decimal Price { get; set; }
    }
}
