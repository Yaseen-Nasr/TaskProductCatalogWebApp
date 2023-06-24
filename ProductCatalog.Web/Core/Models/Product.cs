namespace ProductCatalog.Web.Core.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required] 
        public string Name { get; set; } = null!;
        public DateTime CreationDate{ get; set; } 
        public DateTime StartDate{ get; set; }
        [Range(0, int.MaxValue)]
        public int Duration { get; set; }
        public DurationType DurationType { get; set; }
        public decimal Price { get; set; }
        public string?  CreatedById { get; set; }  
        public ApplicationUser? CreatedBy { get; set; }
        public int CategoryId { get; set; } 
        public Category Category { get; set; }     
    }
}
