
using Microsoft.AspNetCore.Mvc;

namespace ProductCatalog.Web.Core.ViewModels
{
    public class ProductFormViewModel
    {
        public int Id { get; set; }
        [Required]
        [Remote("AllowToAdd", null, AdditionalFields = "Id"
            , ErrorMessage = ViewModelErrors.Duplicate)]
        public string Name { get; set; } = null!;
         [Range(0, int.MaxValue)]
        public int Duration { get; set; } 
        public DurationType DurationType { get; set; }
        public DateTime StartDate { get; set; }
        [Range(1, int.MaxValue)] 
        public decimal Price { get; set; }
        [Display(Name = "Category")] 
        public int CategoryId { get; set; } 
        public IEnumerable<SelectListItem>? Categories { get; set; }
         
    }
}
