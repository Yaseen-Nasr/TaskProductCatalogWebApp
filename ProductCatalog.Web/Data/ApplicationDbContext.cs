
namespace ProductCatalog.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {


        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>()
                    .HasData(new Category { Id = 1, Name = "Home & Kitchen" }
                            , new Category { Id = 2, Name = "Clothing" }
                            , new Category { Id = 3, Name = "Toys & games" }
                            , new Category { Id = 4, Name = "Electronics" }
                            );
            builder.Entity<Product>().Property(c => c.CreationDate).HasDefaultValueSql("GETDATE()");
          
            base.OnModelCreating(builder); 
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}