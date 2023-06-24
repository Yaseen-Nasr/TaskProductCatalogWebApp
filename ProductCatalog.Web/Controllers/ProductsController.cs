using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
 
using System.Security.Claims;

namespace ProductCatalog.Web.Controllers
{
    [Authorize(Roles = AppRoles.Admin)]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper; 

        public ProductsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [AllowAnonymous]
        public IActionResult Index()
        { 
            var query= _context.Products;
            var products = query
                                 .FilterByDuration()
                                 .Include(p => p.Category) 
                                .ProjectTo<ProductShortInfoViewModel>(_mapper.ConfigurationProvider).ToList(); 

            var categories=_context.Categories.AsNoTracking().Select(p => p.Name).ToList();
            ViewBag.Categories = categories;
            return View(products);
        }
        [HttpGet("All")]
        public IActionResult GetAll ()
        {
            var products = _context.Products
                                 .Include(p => p.Category).OrderByDescending(p => p.CreationDate)
                                .ProjectTo<ProductShortInfoViewModel>(_mapper.ConfigurationProvider).ToList();

            var categories = _context.Categories.AsNoTracking().Select(p => p.Name).ToList();
            ViewBag.Categories = categories;
            return View(nameof(Index),products);
        }
        [HttpGet] 
        public IActionResult Create()
        {
            var viewModel = PopulateProductFormViewModel();
            viewModel.StartDate = DateTime.Now;
            return View("ProductForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductFormViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var product = _mapper.Map<Product>(model);
        
            product.CreatedById = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            _context.Add(product);
             _context.SaveChanges();
            return RedirectToAction(nameof(Details),new {id=product.Id});
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product= _context.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
                return NotFound();
            var model = _mapper.Map<ProductFormViewModel>(product); 
            var viewModel = PopulateProductFormViewModel(model); 
            return View("ProductForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductFormViewModel model)
        {
            if (!ModelState.IsValid)
                return View("ProductForm", PopulateProductFormViewModel(model));

            var product = _context.Products.Find(model.Id); 
            if (product is null)
                return NotFound();

            product = _mapper.Map(model, product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Details), new { id = product.Id });
        }

        [AllowAnonymous] 
        public IActionResult Details(int id)
        {
            var product = _context.Products  
                .Include(c => c.Category)
                .SingleOrDefault(b => b.Id == id);
            if (product is null)
                return NotFound();
            var viewModel = _mapper.Map<ProductViewModel>(product );
            return View(viewModel);
        }
        [HttpDelete] 
        public IActionResult Delete(int id)
        {
            var product=_context.Products.Find(id);
            if(product is null) 
                return NotFound();
            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok();
        }
        public  IActionResult AllowToAdd(ProductFormViewModel model)
        {
            var product =   _context.Products.SingleOrDefault(c => c.Name == model.Name);
            var allowToAdd = product is null || product.Id.Equals(model.Id);
            return Json(allowToAdd);
        }
         
        private ProductFormViewModel PopulateProductFormViewModel(ProductFormViewModel? model = null)
        {
            ProductFormViewModel viewModel = model is null ? new ProductFormViewModel() : model;
            viewModel.Categories = _context.Categories.Select(e => new SelectListItem()
            {
                Value = e.Id.ToString(),
                Text = e.Name,
            }).AsEnumerable();

            //foreach (DurationType durationType in Enum.GetValues(typeof(DurationType)))
            // {

            //     viewModel.DurationTypes.Add(new SelectListItem()
            //     {
            //         Value=durationType.ToString(),
            //         Text= durationType.ToString(),
            //     });
            // }
            return viewModel;
        }
    }
}
